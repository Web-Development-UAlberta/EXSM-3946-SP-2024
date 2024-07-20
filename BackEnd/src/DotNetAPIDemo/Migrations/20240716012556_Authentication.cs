using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetAPIDemo.Migrations
{
    /// <inheritdoc />
    public partial class Authentication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "app_user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    first_name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_user", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "post",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    content = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    author = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    text = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    post_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comment_Post",
                        column: x => x.post_id,
                        principalTable: "post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comment_app_user_user_id",
                        column: x => x.user_id,
                        principalTable: "app_user",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "post",
                columns: new[] { "id", "content", "created_at", "title" },
                values: new object[,]
                {
                    { -5, "This is a dry post.", new DateTime(2024, 7, 16, 1, 25, 55, 891, DateTimeKind.Utc).AddTicks(7772), "A Dry Post" },
                    { -4, "This is a warm post.", new DateTime(2024, 7, 16, 1, 25, 55, 891, DateTimeKind.Utc).AddTicks(7771), "A Warm Post" },
                    { -3, "This is a cold post.", new DateTime(2024, 7, 16, 1, 25, 55, 891, DateTimeKind.Utc).AddTicks(7771), "A Cold Post" },
                    { -2, "This is a hot post.", new DateTime(2024, 7, 16, 1, 25, 55, 891, DateTimeKind.Utc).AddTicks(7770), "A Hot Post" },
                    { -1, "This is a cool post.", new DateTime(2024, 7, 16, 1, 25, 55, 891, DateTimeKind.Utc).AddTicks(7765), "A Cool Post" }
                });

            migrationBuilder.InsertData(
                table: "comment",
                columns: new[] { "id", "author", "created_at", "post_id", "text", "user_id" },
                values: new object[,]
                {
                    { -10, "Jane Doe", new DateTime(2024, 7, 16, 1, 25, 55, 891, DateTimeKind.Utc).AddTicks(8889), -5, "I agree with John, this post is dry.", null },
                    { -9, "John Doe", new DateTime(2024, 7, 16, 1, 25, 55, 891, DateTimeKind.Utc).AddTicks(8888), -5, "Wow I didn't think a post could be so dry.", null },
                    { -8, "Jane Doe", new DateTime(2024, 7, 16, 1, 25, 55, 891, DateTimeKind.Utc).AddTicks(8888), -4, "I agree with John, this post is warm.", null },
                    { -7, "John Doe", new DateTime(2024, 7, 16, 1, 25, 55, 891, DateTimeKind.Utc).AddTicks(8887), -4, "Wow I didn't think a post could be so warm.", null },
                    { -6, "Jane Doe", new DateTime(2024, 7, 16, 1, 25, 55, 891, DateTimeKind.Utc).AddTicks(8886), -3, "I agree with John, this post is cold.", null },
                    { -5, "John Doe", new DateTime(2024, 7, 16, 1, 25, 55, 891, DateTimeKind.Utc).AddTicks(8885), -3, "Wow I didn't think a post could be so cold.", null },
                    { -4, "Jane Doe", new DateTime(2024, 7, 16, 1, 25, 55, 891, DateTimeKind.Utc).AddTicks(8885), -2, "I agree with John, this post is hot.", null },
                    { -3, "John Doe", new DateTime(2024, 7, 16, 1, 25, 55, 891, DateTimeKind.Utc).AddTicks(8884), -2, "Wow I didn't think a post could be so hot.", null },
                    { -2, "Jane Doe", new DateTime(2024, 7, 16, 1, 25, 55, 891, DateTimeKind.Utc).AddTicks(8883), -1, "I agree with John, this post is cool.", null },
                    { -1, "John Doe", new DateTime(2024, 7, 16, 1, 25, 55, 891, DateTimeKind.Utc).AddTicks(8880), -1, "Wow I didn't think a post could be so cool.", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Post",
                table: "comment",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_user_id",
                table: "comment",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "post");

            migrationBuilder.DropTable(
                name: "app_user");
        }
    }
}
