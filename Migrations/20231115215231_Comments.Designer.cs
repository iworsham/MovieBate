﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieBate.DataAccess;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MovieBate.Migrations
{
    [DbContext(typeof(MovieBateContext))]
    [Migration("20231115215231_Comments")]
    partial class Comments
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MovieBate.Models.ApiResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Response")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("response");

                    b.Property<string>("TotalResults")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("total_results");

                    b.HasKey("Id")
                        .HasName("pk_movies");

                    b.ToTable("movies", (string)null);
                });

            modelBuilder.Entity("MovieBate.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AnonId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("anon_id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<int>("movieId")
                        .HasColumnType("integer")
                        .HasColumnName("movie_id");

                    b.HasKey("Id")
                        .HasName("pk_comments");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_comments_user_id");

                    b.HasIndex("movieId")
                        .HasDatabaseName("ix_comments_movie_id");

                    b.ToTable("comments", (string)null);
                });

            modelBuilder.Entity("MovieBate.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApiResponseId")
                        .HasColumnType("integer")
                        .HasColumnName("api_response_id");

                    b.Property<string>("ImdbID")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("imdb_id");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("poster");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("year");

                    b.HasKey("Id")
                        .HasName("pk_movie");

                    b.HasIndex("ApiResponseId")
                        .HasDatabaseName("ix_movie_api_response_id");

                    b.ToTable("movie", (string)null);
                });

            modelBuilder.Entity("MovieBate.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("MovieBate.Models.Comment", b =>
                {
                    b.HasOne("MovieBate.Models.User", null)
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_comments_users_user_id");

                    b.HasOne("MovieBate.Models.Movie", "movie")
                        .WithMany("Comments")
                        .HasForeignKey("movieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_comments_movie_movie_id");

                    b.Navigation("movie");
                });

            modelBuilder.Entity("MovieBate.Models.Movie", b =>
                {
                    b.HasOne("MovieBate.Models.ApiResponse", null)
                        .WithMany("Search")
                        .HasForeignKey("ApiResponseId")
                        .HasConstraintName("fk_movie_movies_api_response_id");
                });

            modelBuilder.Entity("MovieBate.Models.ApiResponse", b =>
                {
                    b.Navigation("Search");
                });

            modelBuilder.Entity("MovieBate.Models.Movie", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("MovieBate.Models.User", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
