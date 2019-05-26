﻿// <auto-generated />
using System;
using Appslx.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Appslx.Repository.Migrations
{
    [DbContext(typeof(BaseContext))]
    [Migration("20190526155037_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Appslx.Core.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int>("OrderStatusId");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("OrderStatusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Appslx.Core.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Qty");

                    b.Property<decimal>("TotalPrice");

                    b.Property<decimal>("UnitPrice");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Appslx.Core.Models.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Descrition");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("OrderStatuses");
                });

            modelBuilder.Entity("Appslx.Core.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<decimal>("UnitPrice");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Appslx.Core.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Appslx.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("FirstName")
                        .HasMaxLength(32);

                    b.Property<string>("LastName")
                        .HasMaxLength(32);

                    b.Property<string>("MiddleInitial")
                        .HasMaxLength(1);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Appslx.Core.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Appslx.Core.Models.Order", b =>
                {
                    b.HasOne("Appslx.Core.Models.OrderStatus", "OrderStatus")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Appslx.Core.Models.OrderDetail", b =>
                {
                    b.HasOne("Appslx.Core.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Appslx.Core.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Appslx.Core.Models.UserRole", b =>
                {
                    b.HasOne("Appslx.Core.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Appslx.Core.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}