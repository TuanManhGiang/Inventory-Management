using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_0._2.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__B2079BCD0EA330E9", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: false),
                    MaterialName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product__B40CC6ED2C3393D0", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierID = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: false),
                    SupplierName = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nchar(12)", fixedLength: true, maxLength: 12, nullable: false),
                    Status = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    WarehouseID = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: false),
                    WarehouseName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Warehous__2608AFD94222D4EF", x => x.WarehouseID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DepartmentID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__7AD04FF1173876EA", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK__Employee__Depart__52593CB8",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID");
                });

            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    ProductID = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: false),
                    WarehouseID = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: false),
                    ShelfID = table.Column<string>(type: "nchar(8)", fixedLength: true, maxLength: 8, nullable: true),
                    CabinetID = table.Column<string>(type: "nchar(8)", fixedLength: true, maxLength: 8, nullable: true),
                    QuantityOnHand = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductD__ED4863B732E0915F", x => new { x.WarehouseID, x.ProductID });
                    table.ForeignKey(
                        name: "FK__ProductDe__Produ__5DCAEF64",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                    table.ForeignKey(
                        name: "FK__ProductDe__Wareh__5EBF139D",
                        column: x => x.WarehouseID,
                        principalTable: "Warehouse",
                        principalColumn: "WarehouseID");
                });

            migrationBuilder.CreateTable(
                name: "ExportInvoice",
                columns: table => new
                {
                    ExportID = table.Column<string>(type: "nchar(8)", fixedLength: true, maxLength: 8, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ExportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WarehouseID = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: true),
                    CreatedByEmployeeID = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: true),
                    ExportedByEmployeeID = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: true),
                    ExportTo = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ExportIn__E5C997A41B0907CE", x => x.ExportID);
                    table.ForeignKey(
                        name: "FK__ExportInv__Creat__534D60F1",
                        column: x => x.CreatedByEmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK__ExportInv__Expor__5441852A",
                        column: x => x.ExportedByEmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK__ExportInv__Wareh__5535A963",
                        column: x => x.WarehouseID,
                        principalTable: "Warehouse",
                        principalColumn: "WarehouseID");
                });

            migrationBuilder.CreateTable(
                name: "ImportInvoice",
                columns: table => new
                {
                    ImportID = table.Column<string>(type: "nchar(8)", fixedLength: true, maxLength: 8, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ImportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByEmployeeID = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: true),
                    ImportedByEmployeeID = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: true),
                    WarehouseID = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: true),
                    SupplierID = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ImportIn__8697678A24927208", x => x.ImportID);
                    table.ForeignKey(
                        name: "FK_ImportInvoice_Supplier",
                        column: x => x.SupplierID,
                        principalTable: "Supplier",
                        principalColumn: "SupplierID");
                    table.ForeignKey(
                        name: "FK__ImportInv__Creat__276EDEB3",
                        column: x => x.CreatedByEmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK__ImportInv__Impor__286302EC",
                        column: x => x.ImportedByEmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK__ImportInv__Wareh__29572725",
                        column: x => x.WarehouseID,
                        principalTable: "Warehouse",
                        principalColumn: "WarehouseID");
                });

            migrationBuilder.CreateTable(
                name: "ExportInvoiceDetail",
                columns: table => new
                {
                    ExportID = table.Column<string>(type: "nchar(8)", fixedLength: true, maxLength: 8, nullable: false),
                    ProductID = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    ExportedQuantity = table.Column<int>(type: "int", nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ExportIn__2E895BCA1ED998B2", x => new { x.ExportID, x.ProductID });
                    table.ForeignKey(
                        name: "FK__ExportInv__Expor__5629CD9C",
                        column: x => x.ExportID,
                        principalTable: "ExportInvoice",
                        principalColumn: "ExportID");
                    table.ForeignKey(
                        name: "FK__ExportInv__Produ__571DF1D5",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateTable(
                name: "ImportInvoiceDetail",
                columns: table => new
                {
                    ImportID = table.Column<string>(type: "nchar(8)", fixedLength: true, maxLength: 8, nullable: false),
                    ProductID = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    ImportedQuantity = table.Column<int>(type: "int", nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ImportIn__4DD7ABE424927208", x => new { x.ImportID, x.ProductID });
                    table.ForeignKey(
                        name: "FK__ImportInv__Impor__2E1BDC42",
                        column: x => x.ImportID,
                        principalTable: "ImportInvoice",
                        principalColumn: "ImportID");
                    table.ForeignKey(
                        name: "FK__ImportInv__Produ__5CD6CB2B",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Departme__D949CC34117F9D94",
                table: "Department",
                column: "DepartmentName",
                unique: true,
                filter: "[DepartmentName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentID",
                table: "Employee",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoice_CreatedByEmployeeID",
                table: "ExportInvoice",
                column: "CreatedByEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoice_ExportedByEmployeeID",
                table: "ExportInvoice",
                column: "ExportedByEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoice_WarehouseID",
                table: "ExportInvoice",
                column: "WarehouseID");

            migrationBuilder.CreateIndex(
                name: "IX_ExportInvoiceDetail_ProductID",
                table: "ExportInvoiceDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ImportInvoice_CreatedByEmployeeID",
                table: "ImportInvoice",
                column: "CreatedByEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ImportInvoice_ImportedByEmployeeID",
                table: "ImportInvoice",
                column: "ImportedByEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ImportInvoice_SupplierID",
                table: "ImportInvoice",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_ImportInvoice_WarehouseID",
                table: "ImportInvoice",
                column: "WarehouseID");

            migrationBuilder.CreateIndex(
                name: "IX_ImportInvoiceDetail_ProductID",
                table: "ImportInvoiceDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "UQ__Product__9C87053C2F10007B",
                table: "Product",
                column: "MaterialName",
                unique: true,
                filter: "[MaterialName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_ProductID",
                table: "ProductDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "UQ__ProductD__9C173EB238996AB5",
                table: "ProductDetail",
                column: "CabinetID",
                unique: true,
                filter: "[CabinetID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__ProductD__DBD04F2635BCFE0A",
                table: "ProductDetail",
                column: "ShelfID",
                unique: true,
                filter: "[ShelfID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Warehous__180C89D944FF419A",
                table: "Warehouse",
                column: "WarehouseName",
                unique: true,
                filter: "[WarehouseName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExportInvoiceDetail");

            migrationBuilder.DropTable(
                name: "ImportInvoiceDetail");

            migrationBuilder.DropTable(
                name: "ProductDetail");

            migrationBuilder.DropTable(
                name: "ExportInvoice");

            migrationBuilder.DropTable(
                name: "ImportInvoice");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
