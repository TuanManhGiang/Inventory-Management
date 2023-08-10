﻿// <auto-generated />
using System;
using Inventory_0._2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inventory_0._2.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230808184108_change Export entities")]
    partial class changeExportentities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.6.23329.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Inventory_0._2.Domain.Entities.TodoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ListId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Reminder")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ListId" }, "IX_TodoItems_ListId");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("Inventory_0._2.Domain.Entities.TodoList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("TodoLists");
                });

            modelBuilder.Entity("Inventory_0._2.Infrastructure.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("ApplicationEditingAllowed")
                        .HasColumnType("bit");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.Department", b =>
                {
                    b.Property<string>("DepartmentId")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("DepartmentID")
                        .IsFixedLength();

                    b.Property<string>("DepartmentName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DepartmentId")
                        .HasName("PK__Departme__B2079BCD0EA330E9");

                    b.HasIndex(new[] { "DepartmentName" }, "UQ__Departme__D949CC34117F9D94")
                        .IsUnique()
                        .HasFilter("[DepartmentName] IS NOT NULL");

                    b.ToTable("Department", (string)null);
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.Employee", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasMaxLength(4)
                        .HasColumnType("nchar(4)")
                        .HasColumnName("EmployeeID")
                        .IsFixedLength();

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime");

                    b.Property<string>("DepartmentId")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("DepartmentID")
                        .IsFixedLength();

                    b.Property<string>("FirstName")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("LastName")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("EmployeeId")
                        .HasName("PK__Employee__7AD04FF1173876EA");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.ExportInvoice", b =>
                {
                    b.Property<string>("ExportId")
                        .HasMaxLength(8)
                        .HasColumnType("nchar(8)")
                        .HasColumnName("ExportID")
                        .IsFixedLength();

                    b.Property<string>("CreatedByEmployeeId")
                        .HasMaxLength(4)
                        .HasColumnType("nchar(4)")
                        .HasColumnName("CreatedByEmployeeID")
                        .IsFixedLength();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("ExportDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExportTo")
                        .HasMaxLength(4)
                        .HasColumnType("nchar(4)")
                        .IsFixedLength();

                    b.Property<string>("ExportedByEmployeeId")
                        .HasMaxLength(4)
                        .HasColumnType("nchar(4)")
                        .HasColumnName("ExportedByEmployeeID")
                        .IsFixedLength();

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WarehouseId")
                        .HasMaxLength(4)
                        .HasColumnType("nchar(4)")
                        .HasColumnName("WarehouseID")
                        .IsFixedLength();

                    b.HasKey("ExportId")
                        .HasName("PK__ExportIn__E5C997A41B0907CE");

                    b.HasIndex("CreatedByEmployeeId");

                    b.HasIndex("ExportedByEmployeeId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("ExportInvoice", (string)null);
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.ExportInvoiceDetail", b =>
                {
                    b.Property<string>("ExportId")
                        .HasMaxLength(8)
                        .HasColumnType("nchar(8)")
                        .HasColumnName("ExportID")
                        .IsFixedLength();

                    b.Property<string>("ProductId")
                        .HasMaxLength(4)
                        .HasColumnType("nchar(4)")
                        .HasColumnName("ProductID")
                        .IsFixedLength();

                    b.Property<int?>("ExportedQuantity")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<double?>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("ExportId", "ProductId")
                        .HasName("PK__ExportIn__2E895BCA1ED998B2");

                    b.HasIndex("ProductId");

                    b.ToTable("ExportInvoiceDetail", (string)null);
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.ImportInvoice", b =>
                {
                    b.Property<string>("ImportId")
                        .HasMaxLength(8)
                        .HasColumnType("nchar(8)")
                        .HasColumnName("ImportID")
                        .IsFixedLength();

                    b.Property<string>("CreatedByEmployeeId")
                        .HasMaxLength(4)
                        .HasColumnType("nchar(4)")
                        .HasColumnName("CreatedByEmployeeID")
                        .IsFixedLength();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("ImportDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImportedByEmployeeId")
                        .HasMaxLength(4)
                        .HasColumnType("nchar(4)")
                        .HasColumnName("ImportedByEmployeeID")
                        .IsFixedLength();

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SupplierId")
                        .HasMaxLength(4)
                        .HasColumnType("nchar(4)")
                        .HasColumnName("SupplierID")
                        .IsFixedLength();

                    b.Property<string>("WarehouseId")
                        .HasMaxLength(4)
                        .HasColumnType("nchar(4)")
                        .HasColumnName("WarehouseID")
                        .IsFixedLength();

                    b.HasKey("ImportId")
                        .HasName("PK__ImportIn__8697678A24927208");

                    b.HasIndex("CreatedByEmployeeId");

                    b.HasIndex("ImportedByEmployeeId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("ImportInvoice", (string)null);
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.ImportInvoiceDetail", b =>
                {
                    b.Property<string>("ImportId")
                        .HasMaxLength(8)
                        .HasColumnType("nchar(8)")
                        .HasColumnName("ImportID")
                        .IsFixedLength();

                    b.Property<string>("ProductId")
                        .HasMaxLength(4)
                        .HasColumnType("nchar(4)")
                        .HasColumnName("ProductID")
                        .IsFixedLength();

                    b.Property<int?>("ImportedQuantity")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<double?>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("ImportId", "ProductId")
                        .HasName("PK__ImportIn__4DD7ABE424927208");

                    b.HasIndex("ProductId");

                    b.ToTable("ImportInvoiceDetail", (string)null);
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.Product", b =>
                {
                    b.Property<string>("ProductId")
                        .HasMaxLength(4)
                        .HasColumnType("nchar(4)")
                        .HasColumnName("ProductID")
                        .IsFixedLength();

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaterialName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ProductId")
                        .HasName("PK__Product__B40CC6ED2C3393D0");

                    b.HasIndex(new[] { "MaterialName" }, "UQ__Product__9C87053C2F10007B")
                        .IsUnique()
                        .HasFilter("[MaterialName] IS NOT NULL");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.ProductDetail", b =>
                {
                    b.Property<string>("WarehouseId")
                        .HasMaxLength(4)
                        .HasColumnType("nchar(4)")
                        .HasColumnName("WarehouseID")
                        .IsFixedLength();

                    b.Property<string>("ProductId")
                        .HasMaxLength(4)
                        .HasColumnType("nchar(4)")
                        .HasColumnName("ProductID")
                        .IsFixedLength();

                    b.Property<string>("CabinetId")
                        .HasMaxLength(8)
                        .HasColumnType("nchar(8)")
                        .HasColumnName("CabinetID")
                        .IsFixedLength();

                    b.Property<int>("QuantityOnHand")
                        .HasColumnType("int");

                    b.Property<string>("ShelfId")
                        .HasMaxLength(8)
                        .HasColumnType("nchar(8)")
                        .HasColumnName("ShelfID")
                        .IsFixedLength();

                    b.HasKey("WarehouseId", "ProductId")
                        .HasName("PK__ProductD__ED4863B732E0915F");

                    b.HasIndex("ProductId");

                    b.HasIndex(new[] { "CabinetId" }, "UQ__ProductD__9C173EB238996AB5")
                        .IsUnique()
                        .HasFilter("[CabinetID] IS NOT NULL");

                    b.HasIndex(new[] { "ShelfId" }, "UQ__ProductD__DBD04F2635BCFE0A")
                        .IsUnique()
                        .HasFilter("[ShelfID] IS NOT NULL");

                    b.ToTable("ProductDetail", (string)null);
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.Supplier", b =>
                {
                    b.Property<string>("SupplierId")
                        .HasMaxLength(4)
                        .HasColumnType("nchar(4)")
                        .HasColumnName("SupplierID")
                        .IsFixedLength();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nchar(12)")
                        .IsFixedLength();

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nchar(100)")
                        .IsFixedLength();

                    b.HasKey("SupplierId");

                    b.ToTable("Supplier", (string)null);
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.Warehouse", b =>
                {
                    b.Property<string>("WarehouseId")
                        .HasMaxLength(4)
                        .HasColumnType("nchar(4)")
                        .HasColumnName("WarehouseID")
                        .IsFixedLength();

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("WarehouseName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("WarehouseId")
                        .HasName("PK__Warehous__2608AFD94222D4EF");

                    b.HasIndex(new[] { "WarehouseName" }, "UQ__Warehous__180C89D944FF419A")
                        .IsUnique()
                        .HasFilter("[WarehouseName] IS NOT NULL");

                    b.ToTable("Warehouse", (string)null);
                });

            modelBuilder.Entity("Inventory_0._2.Domain.Entities.TodoItem", b =>
                {
                    b.HasOne("Inventory_0._2.Domain.Entities.TodoList", "List")
                        .WithMany("Items")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("List");
                });

            modelBuilder.Entity("Inventory_0._2.Domain.Entities.TodoList", b =>
                {
                    b.OwnsOne("Inventory_0._2.Domain.ValueObjects.Colour", "Colour", b1 =>
                        {
                            b1.Property<int>("TodoListId")
                                .HasColumnType("int");

                            b1.Property<string>("Code")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TodoListId");

                            b1.ToTable("TodoLists");

                            b1.WithOwner()
                                .HasForeignKey("TodoListId");
                        });

                    b.Navigation("Colour");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Inventory_0._2.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Inventory_0._2.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inventory_0._2.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Inventory_0._2.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.Employee", b =>
                {
                    b.HasOne("warehouse_management.Domain.Entities.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK__Employee__Depart__52593CB8");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.ExportInvoice", b =>
                {
                    b.HasOne("warehouse_management.Domain.Entities.Employee", "CreatedByEmployee")
                        .WithMany("ExportInvoiceCreatedByEmployees")
                        .HasForeignKey("CreatedByEmployeeId")
                        .HasConstraintName("FK__ExportInv__Creat__534D60F1");

                    b.HasOne("warehouse_management.Domain.Entities.Employee", "ExportedByEmployee")
                        .WithMany("ExportInvoiceExportedByEmployees")
                        .HasForeignKey("ExportedByEmployeeId")
                        .HasConstraintName("FK__ExportInv__Expor__5441852A");

                    b.HasOne("warehouse_management.Domain.Entities.Warehouse", "Warehouse")
                        .WithMany("ExportInvoices")
                        .HasForeignKey("WarehouseId")
                        .HasConstraintName("FK__ExportInv__Wareh__5535A963");

                    b.Navigation("CreatedByEmployee");

                    b.Navigation("ExportedByEmployee");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.ExportInvoiceDetail", b =>
                {
                    b.HasOne("warehouse_management.Domain.Entities.ExportInvoice", "Export")
                        .WithMany("ExportInvoiceDetails")
                        .HasForeignKey("ExportId")
                        .IsRequired()
                        .HasConstraintName("FK__ExportInv__Expor__5629CD9C");

                    b.HasOne("warehouse_management.Domain.Entities.Product", "Product")
                        .WithMany("ExportInvoiceDetails")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK__ExportInv__Produ__571DF1D5");

                    b.Navigation("Export");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.ImportInvoice", b =>
                {
                    b.HasOne("warehouse_management.Domain.Entities.Employee", "CreatedByEmployee")
                        .WithMany("ImportInvoiceCreatedByEmployees")
                        .HasForeignKey("CreatedByEmployeeId")
                        .HasConstraintName("FK__ImportInv__Creat__276EDEB3");

                    b.HasOne("warehouse_management.Domain.Entities.Employee", "ImportedByEmployee")
                        .WithMany("ImportInvoiceImportedByEmployees")
                        .HasForeignKey("ImportedByEmployeeId")
                        .HasConstraintName("FK__ImportInv__Impor__286302EC");

                    b.HasOne("warehouse_management.Domain.Entities.Supplier", "Supplier")
                        .WithMany("ImportInvoices")
                        .HasForeignKey("SupplierId")
                        .HasConstraintName("FK_ImportInvoice_Supplier");

                    b.HasOne("warehouse_management.Domain.Entities.Warehouse", "Warehouse")
                        .WithMany("ImportInvoices")
                        .HasForeignKey("WarehouseId")
                        .HasConstraintName("FK__ImportInv__Wareh__29572725");

                    b.Navigation("CreatedByEmployee");

                    b.Navigation("ImportedByEmployee");

                    b.Navigation("Supplier");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.ImportInvoiceDetail", b =>
                {
                    b.HasOne("warehouse_management.Domain.Entities.ImportInvoice", "Import")
                        .WithMany("ImportInvoiceDetails")
                        .HasForeignKey("ImportId")
                        .IsRequired()
                        .HasConstraintName("FK__ImportInv__Impor__2E1BDC42");

                    b.HasOne("warehouse_management.Domain.Entities.Product", "Product")
                        .WithMany("ImportInvoiceDetails")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK__ImportInv__Produ__5CD6CB2B");

                    b.Navigation("Import");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.ProductDetail", b =>
                {
                    b.HasOne("warehouse_management.Domain.Entities.Product", "Product")
                        .WithMany("ProductDetails")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK__ProductDe__Produ__5DCAEF64");

                    b.HasOne("warehouse_management.Domain.Entities.Warehouse", "Warehouse")
                        .WithMany("ProductDetails")
                        .HasForeignKey("WarehouseId")
                        .IsRequired()
                        .HasConstraintName("FK__ProductDe__Wareh__5EBF139D");

                    b.Navigation("Product");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Inventory_0._2.Domain.Entities.TodoList", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.Employee", b =>
                {
                    b.Navigation("ExportInvoiceCreatedByEmployees");

                    b.Navigation("ExportInvoiceExportedByEmployees");

                    b.Navigation("ImportInvoiceCreatedByEmployees");

                    b.Navigation("ImportInvoiceImportedByEmployees");
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.ExportInvoice", b =>
                {
                    b.Navigation("ExportInvoiceDetails");
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.ImportInvoice", b =>
                {
                    b.Navigation("ImportInvoiceDetails");
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.Product", b =>
                {
                    b.Navigation("ExportInvoiceDetails");

                    b.Navigation("ImportInvoiceDetails");

                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.Supplier", b =>
                {
                    b.Navigation("ImportInvoices");
                });

            modelBuilder.Entity("warehouse_management.Domain.Entities.Warehouse", b =>
                {
                    b.Navigation("ExportInvoices");

                    b.Navigation("ImportInvoices");

                    b.Navigation("ProductDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
