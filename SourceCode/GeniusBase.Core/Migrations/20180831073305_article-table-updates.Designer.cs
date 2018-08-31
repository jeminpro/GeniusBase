﻿// <auto-generated />
using System;
using GeniusBase.Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GeniusBase.Core.Migrations
{
    [DbContext(typeof(GbContext))]
    [Migration("20180831073305_article-table-updates")]
    partial class articletableupdates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("post")
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GeniusBase.Core.Database.Entity.Post.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ArchivedDate");

                    b.Property<int?>("ArticleTagId");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("FirstPublishedDate");

                    b.Property<bool>("IsDraft");

                    b.Property<int>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("PlainContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("UrlIdentifier")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("Views");

                    b.HasKey("Id");

                    b.HasIndex("ArticleTagId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UrlIdentifier")
                        .IsUnique();

                    b.ToTable("Article");
                });

            modelBuilder.Entity("GeniusBase.Core.Database.Entity.Post.ArticleHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArticleId");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsDraft");

                    b.Property<int>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("ArticleHistory");
                });

            modelBuilder.Entity("GeniusBase.Core.Database.Entity.Post.ArticleTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArticleId");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<int>("TagId");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("TagId");

                    b.ToTable("ArticleTag");
                });

            modelBuilder.Entity("GeniusBase.Core.Database.Entity.Post.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryIdentifier")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.HasKey("Id");

                    b.HasIndex("CategoryIdentifier")
                        .IsUnique();

                    b.ToTable("Category");

                    b.HasData(
                        new { Id = 1, CategoryIdentifier = "uncategorized", CategoryName = "Uncategorized", CreatedBy = 1, CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), ModifiedBy = 1, ModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                    );
                });

            modelBuilder.Entity("GeniusBase.Core.Database.Entity.Post.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArticleHistoryId");

                    b.Property<int?>("ArticleId");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("ArticleHistoryId");

                    b.HasIndex("ArticleId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("GeniusBase.Core.Database.Entity.Post.Article", b =>
                {
                    b.HasOne("GeniusBase.Core.Database.Entity.Post.ArticleTag")
                        .WithMany("Articles")
                        .HasForeignKey("ArticleTagId");

                    b.HasOne("GeniusBase.Core.Database.Entity.Post.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GeniusBase.Core.Database.Entity.Post.ArticleHistory", b =>
                {
                    b.HasOne("GeniusBase.Core.Database.Entity.Post.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GeniusBase.Core.Database.Entity.Post.ArticleTag", b =>
                {
                    b.HasOne("GeniusBase.Core.Database.Entity.Post.Article", "Category")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GeniusBase.Core.Database.Entity.Post.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GeniusBase.Core.Database.Entity.Post.Tag", b =>
                {
                    b.HasOne("GeniusBase.Core.Database.Entity.Post.ArticleHistory")
                        .WithMany("Tags")
                        .HasForeignKey("ArticleHistoryId");

                    b.HasOne("GeniusBase.Core.Database.Entity.Post.Article")
                        .WithMany("Tags")
                        .HasForeignKey("ArticleId");
                });
#pragma warning restore 612, 618
        }
    }
}