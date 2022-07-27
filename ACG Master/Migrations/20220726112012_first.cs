using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACG_Master.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "MobileNumber",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "MoralisId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "MobileNumber");

            migrationBuilder.RenameColumn(
                name: "MoralisId",
                table: "Users",
                newName: "UserId");
        }
    }
}
