using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace payapp.data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "client_operations",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    client_id = table.Column<Guid>(nullable: false),
                    operation_type = table.Column<int>(nullable: false),
                    operation_value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client_operations", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "client_operations");
        }
    }
}
