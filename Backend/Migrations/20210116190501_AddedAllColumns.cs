using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LayoutWebAPi.Migrations
{
    public partial class AddedAllColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouses",
                table: "Warehouses");

            migrationBuilder.RenameTable(
                name: "Warehouses",
                newName: "warehouses");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "warehouses",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "warehouses",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "warehouses",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "warehouses",
                newName: "is_available");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "warehouses",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DisplayValue",
                table: "warehouses",
                newName: "display_value");

            migrationBuilder.AddPrimaryKey(
                name: "PK_warehouses",
                table: "warehouses",
                column: "id");

            migrationBuilder.CreateTable(
                name: "modules",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    layout_name = table.Column<string>(type: "text", nullable: true),
                    width = table.Column<float>(type: "real", nullable: false),
                    length = table.Column<float>(type: "real", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    is_available = table.Column<bool>(type: "boolean", nullable: false),
                    warehouse_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modules", x => x.id);
                    table.ForeignKey(
                        name: "FK_modules_warehouses_warehouse_id",
                        column: x => x.warehouse_id,
                        principalTable: "warehouses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "layout_objects",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "text", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    is_rack = table.Column<bool>(type: "boolean", nullable: false),
                    module_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_layout_objects", x => x.id);
                    table.ForeignKey(
                        name: "FK_layout_objects_modules_module_id",
                        column: x => x.module_id,
                        principalTable: "modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "layers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    layer_level_no = table.Column<int>(type: "integer", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    is_available = table.Column<bool>(type: "boolean", nullable: false),
                    layout_object_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_layers", x => x.id);
                    table.ForeignKey(
                        name: "FK_layers_layout_objects_layout_object_id",
                        column: x => x.layout_object_id,
                        principalTable: "layout_objects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "properties",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    width = table.Column<float>(type: "real", nullable: false),
                    height = table.Column<float>(type: "real", nullable: false),
                    x_axis = table.Column<float>(type: "real", nullable: false),
                    y_axis = table.Column<float>(type: "real", nullable: false),
                    max_width = table.Column<float>(type: "real", nullable: false),
                    max_height = table.Column<float>(type: "real", nullable: false),
                    min_width = table.Column<float>(type: "real", nullable: false),
                    min_height = table.Column<float>(type: "real", nullable: false),
                    layout_object_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_properties", x => x.id);
                    table.ForeignKey(
                        name: "FK_properties_layout_objects_layout_object_id",
                        column: x => x.layout_object_id,
                        principalTable: "layout_objects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_layers_layout_object_id",
                table: "layers",
                column: "layout_object_id");

            migrationBuilder.CreateIndex(
                name: "IX_layout_objects_module_id",
                table: "layout_objects",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "IX_modules_warehouse_id",
                table: "modules",
                column: "warehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_properties_layout_object_id",
                table: "properties",
                column: "layout_object_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "layers");

            migrationBuilder.DropTable(
                name: "properties");

            migrationBuilder.DropTable(
                name: "layout_objects");

            migrationBuilder.DropTable(
                name: "modules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_warehouses",
                table: "warehouses");

            migrationBuilder.RenameTable(
                name: "warehouses",
                newName: "Warehouses");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Warehouses",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Warehouses",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Warehouses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "is_available",
                table: "Warehouses",
                newName: "IsAvailable");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "Warehouses",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "display_value",
                table: "Warehouses",
                newName: "DisplayValue");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouses",
                table: "Warehouses",
                column: "Id");
        }
    }
}
