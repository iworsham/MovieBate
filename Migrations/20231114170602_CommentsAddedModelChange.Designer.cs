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
    [Migration("20231114170602_CommentsAddedModelChange")]
    partial class CommentsAddedModelChange
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MovieBate.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.HasKey("Id")
                        .HasName("pk_comments");

                    b.ToTable("comments", (string)null);
                });

            modelBuilder.Entity("MovieBate.Models.MovieApiResponse", b =>
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

                    b.Property<string>("totalResults")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("total_results");

                    b.HasKey("Id")
                        .HasName("pk_movies");

                    b.ToTable("movies", (string)null);
                });

            modelBuilder.Entity("MovieBate.Models.Search", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("MovieApiResponseId")
                        .HasColumnType("integer")
                        .HasColumnName("movie_api_response_id");

                    b.Property<string>("Plot")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("plot");

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
                        .HasName("pk_search");

                    b.HasIndex("MovieApiResponseId")
                        .HasDatabaseName("ix_search_movie_api_response_id");

                    b.ToTable("search", (string)null);
                });

            modelBuilder.Entity("MovieBate.Models.Search", b =>
                {
                    b.HasOne("MovieBate.Models.MovieApiResponse", null)
                        .WithMany("Search")
                        .HasForeignKey("MovieApiResponseId")
                        .HasConstraintName("fk_search_movies_movie_api_response_id");
                });

            modelBuilder.Entity("MovieBate.Models.MovieApiResponse", b =>
                {
                    b.Navigation("Search");
                });
#pragma warning restore 612, 618
        }
    }
}
