using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsAppService.BLL.Migrations
{
    public partial class initila13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SenderPaybill",
                table: "mpesatransaction",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenderPaybill",
                table: "mpesatransaction");
        }
    }
}
