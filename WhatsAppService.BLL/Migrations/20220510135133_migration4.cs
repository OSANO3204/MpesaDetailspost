using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsAppService.BLL.Migrations
{
    public partial class migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_mpesatransaction",
                table: "mpesatransaction");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "mpesatransaction",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "uniquecode",
                table: "mpesatransaction",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mpesatransaction",
                table: "mpesatransaction",
                column: "uniquecode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_mpesatransaction",
                table: "mpesatransaction");

            migrationBuilder.DropColumn(
                name: "uniquecode",
                table: "mpesatransaction");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "mpesatransaction",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mpesatransaction",
                table: "mpesatransaction",
                column: "Id");
        }
    }
}
