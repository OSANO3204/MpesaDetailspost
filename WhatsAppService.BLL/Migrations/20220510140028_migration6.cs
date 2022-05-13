using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsAppService.BLL.Migrations
{
    public partial class migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "uniquecodeid",
                table: "mpesatransaction",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_mpesatransaction",
                table: "mpesatransaction",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "uniquecode",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uniquecode", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mpesatransaction_uniquecodeid",
                table: "mpesatransaction",
                column: "uniquecodeid");

            migrationBuilder.AddForeignKey(
                name: "FK_mpesatransaction_uniquecode_uniquecodeid",
                table: "mpesatransaction",
                column: "uniquecodeid",
                principalTable: "uniquecode",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mpesatransaction_uniquecode_uniquecodeid",
                table: "mpesatransaction");

            migrationBuilder.DropTable(
                name: "uniquecode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mpesatransaction",
                table: "mpesatransaction");

            migrationBuilder.DropIndex(
                name: "IX_mpesatransaction_uniquecodeid",
                table: "mpesatransaction");

            migrationBuilder.DropColumn(
                name: "uniquecodeid",
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
    }
}
