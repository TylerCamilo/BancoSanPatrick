using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transactions.Persistence.Migrations
{
    public partial class Changedatetime2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "transactions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatedAt",
                table: "transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedAt",
                table: "transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
