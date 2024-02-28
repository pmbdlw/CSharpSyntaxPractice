using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalAPIBySelf.Migrations
{
    /// <inheritdoc />
    public partial class AddRolePropertyToSysUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "SysUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "SysUser",
                columns: new[] { "Id", "Email", "IsBan", "Role", "UsePwd", "UserName", "Ver" },
                values: new object[] { -10000, null, false, "visitor", "111111", "admin1", 0L });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SysUser",
                keyColumn: "Id",
                keyValue: -10000);

            migrationBuilder.DropColumn(
                name: "Role",
                table: "SysUser");
        }
    }
}
