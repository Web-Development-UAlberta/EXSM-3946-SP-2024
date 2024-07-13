using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetAPIDemo.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "post",
                columns: new[] { "id", "content", "created_at", "title" },
                values: new object[,]
                {
                    { -5, "This is a dry post.", new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(1204), "A Dry Post" },
                    { -4, "This is a warm post.", new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(1203), "A Warm Post" },
                    { -3, "This is a cold post.", new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(1201), "A Cold Post" },
                    { -2, "This is a hot post.", new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(1199), "A Hot Post" },
                    { -1, "This is a cool post.", new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(1151), "A Cool Post" }
                });

            migrationBuilder.InsertData(
                table: "comment",
                columns: new[] { "id", "author", "created_at", "post_id", "text" },
                values: new object[,]
                {
                    { -10, "Jane Doe", new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(2813), -5, "I agree with John, this post is dry." },
                    { -9, "John Doe", new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(2811), -5, "Wow I didn't think a post could be so dry." },
                    { -8, "Jane Doe", new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(2810), -4, "I agree with John, this post is warm." },
                    { -7, "John Doe", new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(2808), -4, "Wow I didn't think a post could be so warm." },
                    { -6, "Jane Doe", new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(2807), -3, "I agree with John, this post is cold." },
                    { -5, "John Doe", new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(2806), -3, "Wow I didn't think a post could be so cold." },
                    { -4, "Jane Doe", new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(2804), -2, "I agree with John, this post is hot." },
                    { -3, "John Doe", new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(2803), -2, "Wow I didn't think a post could be so hot." },
                    { -2, "Jane Doe", new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(2801), -1, "I agree with John, this post is cool." },
                    { -1, "John Doe", new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(2779), -1, "Wow I didn't think a post could be so cool." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "comment",
                keyColumn: "id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "comment",
                keyColumn: "id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "comment",
                keyColumn: "id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "comment",
                keyColumn: "id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "comment",
                keyColumn: "id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "comment",
                keyColumn: "id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "comment",
                keyColumn: "id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "comment",
                keyColumn: "id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "comment",
                keyColumn: "id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "comment",
                keyColumn: "id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "post",
                keyColumn: "id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "post",
                keyColumn: "id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "post",
                keyColumn: "id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "post",
                keyColumn: "id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "post",
                keyColumn: "id",
                keyValue: -1);
        }
    }
}
