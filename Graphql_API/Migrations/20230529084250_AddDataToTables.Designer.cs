﻿// <auto-generated />
using System;
using Graphql_API.Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Graphql_API.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230529084250_AddDataToTables")]
    partial class AddDataToTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Graphql_API.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0aca45d7-72ee-43e8-80c0-521aac234c73"),
                            Description = "Cash acc",
                            OwnerId = new Guid("9b9692f5-be70-44d6-bb6c-a7df544fac6e"),
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("0583f813-6136-43a9-becd-f9c01dadf68c"),
                            Description = "Savings acc",
                            OwnerId = new Guid("8ca8c0c6-a305-430e-91d2-9e55ad9a28cc"),
                            Type = 2
                        },
                        new
                        {
                            Id = new Guid("4695d684-c9f4-49c7-9670-97a66f3402bf"),
                            Description = "Expense acc",
                            OwnerId = new Guid("8ca8c0c6-a305-430e-91d2-9e55ad9a28cc"),
                            Type = 1
                        });
                });

            modelBuilder.Entity("Graphql_API.Entities.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9b9692f5-be70-44d6-bb6c-a7df544fac6e"),
                            Address = "Jack's street",
                            Name = "Jack Dickins"
                        },
                        new
                        {
                            Id = new Guid("8ca8c0c6-a305-430e-91d2-9e55ad9a28cc"),
                            Address = "Bob's avenue",
                            Name = "Bob Baggins"
                        });
                });

            modelBuilder.Entity("Graphql_API.Entities.Account", b =>
                {
                    b.HasOne("Graphql_API.Entities.Owner", "Owner")
                        .WithMany("Accounts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Graphql_API.Entities.Owner", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}