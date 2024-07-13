﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using DotNetAPIDemo.Data;
#nullable disable

namespace DotNetAPIDemo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240713013706_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("DotNetAPIDemo.Models.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("author");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<int>("PostID")
                        .HasColumnType("int")
                        .HasColumnName("post_id");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("text");

                    b.HasKey("ID");

                    b.HasIndex("PostID")
                        .HasDatabaseName("FK_Comment_Post");

                    b.ToTable("comment");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            Author = "John Doe",
                            CreatedAt = new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(2779),
                            PostID = -1,
                            Text = "Wow I didn't think a post could be so cool."
                        },
                        new
                        {
                            ID = -2,
                            Author = "Jane Doe",
                            CreatedAt = new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(2801),
                            PostID = -1,
                            Text = "I agree with John, this post is cool."
                        },
                        new
                        {
                            ID = -3,
                            Author = "John Doe",
                            CreatedAt = new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(2803),
                            PostID = -2,
                            Text = "Wow I didn't think a post could be so hot."
                        },
                        new
                        {
                            ID = -4,
                            Author = "Jane Doe",
                            CreatedAt = new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(2804),
                            PostID = -2,
                            Text = "I agree with John, this post is hot."
                        },
                        new
                        {
                            ID = -5,
                            Author = "John Doe",
                            CreatedAt = new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(2806),
                            PostID = -3,
                            Text = "Wow I didn't think a post could be so cold."
                        },
                        new
                        {
                            ID = -6,
                            Author = "Jane Doe",
                            CreatedAt = new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(2807),
                            PostID = -3,
                            Text = "I agree with John, this post is cold."
                        },
                        new
                        {
                            ID = -7,
                            Author = "John Doe",
                            CreatedAt = new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(2808),
                            PostID = -4,
                            Text = "Wow I didn't think a post could be so warm."
                        },
                        new
                        {
                            ID = -8,
                            Author = "Jane Doe",
                            CreatedAt = new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(2810),
                            PostID = -4,
                            Text = "I agree with John, this post is warm."
                        },
                        new
                        {
                            ID = -9,
                            Author = "John Doe",
                            CreatedAt = new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(2811),
                            PostID = -5,
                            Text = "Wow I didn't think a post could be so dry."
                        },
                        new
                        {
                            ID = -10,
                            Author = "Jane Doe",
                            CreatedAt = new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(2813),
                            PostID = -5,
                            Text = "I agree with John, this post is dry."
                        });
                });

            modelBuilder.Entity("DotNetAPIDemo.Models.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("title");

                    b.HasKey("ID");

                    b.ToTable("post");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            Content = "This is a cool post.",
                            CreatedAt = new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(1151),
                            Title = "A Cool Post"
                        },
                        new
                        {
                            ID = -2,
                            Content = "This is a hot post.",
                            CreatedAt = new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(1199),
                            Title = "A Hot Post"
                        },
                        new
                        {
                            ID = -3,
                            Content = "This is a cold post.",
                            CreatedAt = new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(1201),
                            Title = "A Cold Post"
                        },
                        new
                        {
                            ID = -4,
                            Content = "This is a warm post.",
                            CreatedAt = new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(1203),
                            Title = "A Warm Post"
                        },
                        new
                        {
                            ID = -5,
                            Content = "This is a dry post.",
                            CreatedAt = new DateTime(2024, 7, 12, 19, 37, 6, 442, DateTimeKind.Local).AddTicks(1204),
                            Title = "A Dry Post"
                        });
                });

            modelBuilder.Entity("DotNetAPIDemo.Models.Comment", b =>
                {
                    b.HasOne("DotNetAPIDemo.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Comment_Post");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("DotNetAPIDemo.Models.Post", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
