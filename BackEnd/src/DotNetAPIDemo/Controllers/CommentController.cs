using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetAPIDemo.Models;
using DotNetAPIDemo.Data;
using Swashbuckle.AspNetCore.Annotations;


namespace DotNetAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all comments", Description = "Retrieves a list of all comments.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the list of comments", typeof(IEnumerable<Comment>))]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            return await _context.Comments.Include(c => c.User).ToListAsync();
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a specific comment", Description = "Retrieves a specific comment by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the requested comment", typeof(Comment))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Comment not found")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        [HttpGet("bypost/{postId}")]
        [SwaggerOperation(Summary = "Get comments for a specific post", Description = "Retrieves all comments for a given post ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the list of comments for the post", typeof(IEnumerable<Comment>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Post not found")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsByPost(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post == null)
            {
                return NotFound("Post not found");
            }

            return await _context.Comments.Where(c => c.PostID == postId).ToListAsync();
        }

        [HttpGet("byauthor/{author}")]
        [SwaggerOperation(Summary = "Get comments by a specific author", Description = "Retrieves all comments by a given author.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the list of comments by the author", typeof(IEnumerable<Comment>))]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsByAuthor(string author)
        {
            return await _context.Comments.Where(c => c.Author == author).ToListAsync();
        }

        [HttpGet("byuser/{userID}")]
        [SwaggerOperation(Summary = "Get comments by a specific author (a user)", Description = "Retrieves all comments by a given author.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the list of comments by the user", typeof(IEnumerable<Comment>))]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsByUser(int userID)
        {
            return await _context.Comments.Where(c => c.User.ID == userID).Include(c => c.User).ToListAsync();
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an existing comment", Description = "Updates an existing comment with the provided data.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Comment successfully updated")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid comment data or ID mismatch")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Comment not found")]
        public async Task<IActionResult> PutComment(int id, [FromBody] Comment comment)
        {
            if (id != comment.ID)
            {
                return BadRequest("ID mismatch");
            }

            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new comment", Description = "Creates a new comment with the provided data.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Comment created successfully", typeof(Comment))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid comment data")]
        public async Task<ActionResult<Comment>> PostComment([FromBody] Comment comment, [FromHeader] string Authorization)
        {
            if (!UserController.VerifyJWT(Authorization))
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrWhiteSpace(comment.Author))
            {
                comment.Author = comment.User?.Email;
            }

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComment), new { id = comment.ID }, comment);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a specific comment", Description = "Deletes a specific comment by its ID.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Comment successfully deleted")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Comment not found")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.ID == id);
        }
    }
}