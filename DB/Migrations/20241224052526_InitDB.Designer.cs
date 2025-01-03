﻿// <auto-generated />
using System;
using DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DB.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20241224052526_InitDB")]
    partial class InitDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DB.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("Likes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<int>("ProfileId")
                        .HasColumnType("integer");

                    b.Property<bool>("WasEdited")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DB.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Enterprise")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("ProfileId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("DB.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("Likes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("ProfileId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("DB.Profile", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("UserId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("DB.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<int>("ProfileId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("DB.SocialLinks", b =>
                {
                    b.Property<int>("ProfileId")
                        .HasColumnType("integer");

                    b.Property<string>("Github")
                        .HasColumnType("text");

                    b.Property<string>("Linkedin")
                        .HasColumnType("text");

                    b.Property<string>("Web")
                        .HasColumnType("text");

                    b.HasKey("ProfileId");

                    b.ToTable("SocialLinks");
                });

            modelBuilder.Entity("DB.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("DB.Technology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Technologies");
                });

            modelBuilder.Entity("DB.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<bool>("Verified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ExperienceTechnology", b =>
                {
                    b.Property<int>("ExperiencesId")
                        .HasColumnType("integer");

                    b.Property<int>("TechnologiesId")
                        .HasColumnType("integer");

                    b.HasKey("ExperiencesId", "TechnologiesId");

                    b.HasIndex("TechnologiesId");

                    b.ToTable("ExperienceTechnology");
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.Property<int>("PostsId")
                        .HasColumnType("integer");

                    b.Property<int>("TagsId")
                        .HasColumnType("integer");

                    b.HasKey("PostsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("PostTag");
                });

            modelBuilder.Entity("ProfileTechnology", b =>
                {
                    b.Property<int>("ProfilesUserId")
                        .HasColumnType("integer");

                    b.Property<int>("TechnologiesId")
                        .HasColumnType("integer");

                    b.HasKey("ProfilesUserId", "TechnologiesId");

                    b.HasIndex("TechnologiesId");

                    b.ToTable("ProfileTechnology");
                });

            modelBuilder.Entity("ProjectTechnology", b =>
                {
                    b.Property<int>("ProjectsId")
                        .HasColumnType("integer");

                    b.Property<int>("TechnologiesId")
                        .HasColumnType("integer");

                    b.HasKey("ProjectsId", "TechnologiesId");

                    b.HasIndex("TechnologiesId");

                    b.ToTable("ProjectTechnology");
                });

            modelBuilder.Entity("DB.Comment", b =>
                {
                    b.HasOne("DB.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Profile", "Profile")
                        .WithMany("Comments")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("DB.Experience", b =>
                {
                    b.HasOne("DB.Profile", "Profile")
                        .WithMany("Experiences")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("DB.Post", b =>
                {
                    b.HasOne("DB.Profile", "Profile")
                        .WithMany("Posts")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("DB.Profile", b =>
                {
                    b.HasOne("DB.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("DB.Profile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DB.Project", b =>
                {
                    b.HasOne("DB.Profile", "Profile")
                        .WithMany("Projects")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("DB.SocialLinks", b =>
                {
                    b.HasOne("DB.Profile", "Profile")
                        .WithOne("Links")
                        .HasForeignKey("DB.SocialLinks", "ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("ExperienceTechnology", b =>
                {
                    b.HasOne("DB.Experience", null)
                        .WithMany()
                        .HasForeignKey("ExperiencesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Technology", null)
                        .WithMany()
                        .HasForeignKey("TechnologiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.HasOne("DB.Post", null)
                        .WithMany()
                        .HasForeignKey("PostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProfileTechnology", b =>
                {
                    b.HasOne("DB.Profile", null)
                        .WithMany()
                        .HasForeignKey("ProfilesUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Technology", null)
                        .WithMany()
                        .HasForeignKey("TechnologiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectTechnology", b =>
                {
                    b.HasOne("DB.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Technology", null)
                        .WithMany()
                        .HasForeignKey("TechnologiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DB.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("DB.Profile", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Experiences");

                    b.Navigation("Links")
                        .IsRequired();

                    b.Navigation("Posts");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("DB.User", b =>
                {
                    b.Navigation("Profile")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
