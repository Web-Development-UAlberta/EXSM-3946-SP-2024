using DotNetAPIDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using DotNetAPIDemo.Data;
using Microsoft.EntityFrameworkCore;

public class UserController : Controller
{
    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }

    /*
    [HttpPost]
    public ActionResult<string> Register([FromForm] string email, [FromForm] string password) => Register("Basic " + Base64UrlEncoder.Encode(email + ":" + password));
    */


    [HttpPost("/api/register")]
    [SwaggerOperation(
        Summary = "Register a User",
        Description = "Register a new application user.",
        OperationId = "RegisterUser",
        Tags = new[] { "API", "Authentication" }
    )]
    [SwaggerResponse(201, "Success", typeof(string))]
    [SwaggerResponse(400, "Bad Request", typeof(string))]

    public ActionResult<string> Register([FromHeader][SwaggerParameter("Authorization Header (Basic)", Required = true)] string Authorization)
    {
        try
        {
            string AuthorizationDecoded = Base64UrlEncoder.Decode(Authorization.Replace("Basic ", ""));
            string EMail = AuthorizationDecoded.Split(':')[0];
            byte[] Password = Encoding.Unicode.GetBytes(AuthorizationDecoded.Split(':')[1]);
            byte[] EncryptionSecret = Encoding.Unicode.GetBytes(Environment.GetEnvironmentVariable("ENCRYPTION_SECRET") ?? "");
            byte[] HashedPassword = SHA256.HashData(EncryptionSecret.Concat(Password).ToArray());
            _context.Users.Add(new User() { Email = EMail, Password = Convert.ToBase64String(HashedPassword) });
            _context.SaveChanges();
            return StatusCode(201, "User Registered");
        }
        catch (Exception e)
        {
            return StatusCode(400, e.Message);
        }
    }

    /*
    [HttpPost]
    [SwaggerOperation(
        Summary = "Login a User From Form",
        Description = "Provide a username and password and get a JWT.")
    ]
    public ActionResult<string> Login([FromForm] string email, [FromForm] string password)
    {
        return Authorize("Basic " + Base64UrlEncoder.Encode(email + ":" + password));
    }
    */
    [HttpPost("/api/authorize")] // Route parameters are defined in the route itself
    [SwaggerOperation(
        Summary = "Authorize a User",
        Description = "Provide a username and password and get a JWT.",
        OperationId = "AuthorizeUser",
        Tags = new[] { "API", "Authentication" }
    )]

    [SwaggerResponse(200, "Success", typeof(string))]
    [SwaggerResponse(400, "Bad Request", typeof(string))]
    [SwaggerResponse(401, "Unauthorized", typeof(string))]
    [SwaggerResponse(500, "Internal Server Error", typeof(string))]
    public ActionResult<string> Authorize(
        [FromHeader][SwaggerParameter("Authorization Header (Basic)", Required = true)] string Authorization
    )
    {
        string AuthorizationDecoded = Base64UrlEncoder.Decode(Authorization.Replace("Basic ", ""));
        string EMail = AuthorizationDecoded.Split(':')[0];
        byte[] Password = Encoding.Unicode.GetBytes(AuthorizationDecoded.Split(':')[1]);
        byte[] EncryptionSecret = Encoding.Unicode.GetBytes(Environment.GetEnvironmentVariable("ENCRYPTION_SECRET") ?? "");
        string HashedPassword = Convert.ToBase64String(SHA256.HashData(EncryptionSecret.Concat(Password).ToArray()));
        User user = _context.Users.Where(u => u.Email == EMail).FirstOrDefault();

        if (user == null || user.Password != HashedPassword)
        {
            return StatusCode(401, "Unauthorized");
        }
        else
        {
            string JWTHeader = Base64UrlEncoder.Encode("{\"alg\": \"HS256\",\"typ\": \"JWT\"}");
            string JWTPayload = Base64UrlEncoder.Encode("{\"sub\": \"" + user.ID + "\", \"email\": \"" + user.Email + "\"}");
            string JWTSignature = Base64UrlEncoder.Encode(SHA256.HashData(Encoding.UTF8.GetBytes(JWTHeader + "." + JWTPayload + "." + Environment.GetEnvironmentVariable("ENCRYPTION_SECRET") ?? "")).ToString());
            string JWT = JWTHeader + "." + JWTPayload + "." + JWTSignature;
            return StatusCode(200, JWT);
        }

    }


    [HttpPost("/api/user")] // Route parameters are defined in the route itself
    [SwaggerOperation(
        Summary = "Authorize a User",
        Description = "Provide a username and password and get a JWT.",
        OperationId = "AuthorizeUser",
        Tags = new[] { "API", "Authentication" }
    )]

    [SwaggerResponse(200, "Success", typeof(string))]
    [SwaggerResponse(400, "Bad Request", typeof(string))]
    [SwaggerResponse(401, "Unauthorized", typeof(string))]
    [SwaggerResponse(500, "Internal Server Error", typeof(string))]
    public ActionResult<string> GetUser(
        [FromHeader][SwaggerParameter("Authorization Header (JWT)", Required = true)] string Authorization
    )
    {
        if (!VerifyJWT(Authorization))
        {
            return StatusCode(401, "Invalid JWT");
        }
        User user;
        try
        {
            user = GetUserFromJWT(Authorization);

        }
        catch (Exception e)
        {
            return StatusCode(400, e.Message);
        }

        if (user == null)
        {
            return StatusCode(404, "Could not find that user.");
        }
        else
        {
            return StatusCode(200, user);
        }

    }
    [HttpGet("/api/user/exists")] // Route parameters are defined in the route itself
    [SwaggerOperation(
       Summary = "Check if a User Exists",
       Description = "See if a user exists.",
       OperationId = "CheckIfUserExists",
       Tags = new[] { "API", "Authentication" }
   )]

    [SwaggerResponse(200, "Success", typeof(string))]
    [SwaggerResponse(404, "Not Found", typeof(string))]
    [SwaggerResponse(500, "Internal Server Error", typeof(string))]
    public ActionResult<string> UserExists(
       [FromQuery][SwaggerParameter("Authorization Header (JWT)", Required = true)] string email
   )
    {
        User user = _context.Users.SingleOrDefault(u => u.Email == email);

        if (user == null)
        {
            return StatusCode(404, "Could not find that user.");
        }
        else
        {
            return StatusCode(200, "User exists.");
        }

    }
    public User GetUserFromJWT(string JWT)
    {
        string[] JWTParts = JWT.Replace("Bearer ", "").Split('.');
        string JWTPayload = Base64UrlEncoder.Decode(JWTParts[1]);
        int ID = int.Parse(JWTPayload.Split(':')[1].Split(',')[0].Replace("\"", ""));
        User target = _context.Users.SingleOrDefault(user => user.ID == ID);
        target.Password = "";
        return target;
    }
    public static bool VerifyJWT(string JWT)
    {
        string[] JWTParts = JWT.Replace("Bearer ", "").Split('.');
        string JWTHeader = JWTParts[0];
        string JWTPayload = JWTParts[1];
        string JWTSignature = JWTParts[2];
        string JWTSignatureCheck = Base64UrlEncoder.Encode(SHA256.HashData(Encoding.UTF8.GetBytes(JWTHeader + "." + JWTPayload + "." + Environment.GetEnvironmentVariable("ENCRYPTION_SECRET") ?? "")).ToString());
        return JWTSignature == JWTSignatureCheck;
    }
}
