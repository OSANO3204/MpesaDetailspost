using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsAppService.BLL.Migrations
{
    public partial class migration15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TranscationId",
                table: "mpesatransaction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TranscationId",
                table: "mpesatransaction",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
