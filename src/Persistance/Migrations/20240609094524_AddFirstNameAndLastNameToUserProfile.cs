using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstNameAndLastNameToUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_SystemRoles_SystemRoleId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserProfiles",
                newName: "LastName");

            migrationBuilder.AlterColumn<int>(
                name: "SystemRoleId",
                table: "UserProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_SystemRoles_SystemRoleId",
                table: "UserProfiles",
                column: "SystemRoleId",
                principalTable: "SystemRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_SystemRoles_SystemRoleId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "UserProfiles",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "SystemRoleId",
                table: "UserProfiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "UserProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_SystemRoles_SystemRoleId",
                table: "UserProfiles",
                column: "SystemRoleId",
                principalTable: "SystemRoles",
                principalColumn: "Id");
        }
    }
}
