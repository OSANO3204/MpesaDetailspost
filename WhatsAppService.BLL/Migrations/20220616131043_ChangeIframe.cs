using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsAppService.BLL.Migrations
{
    public partial class ChangeIframe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifedAt",
                table: "mpesatransaction");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "mpesatransaction",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "mpesatransaction",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "mpesatransaction",
                newName: "recieverFullName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "mpesatransaction",
                newName: "receiverMobile");

            migrationBuilder.AlterColumn<string>(
                name: "amount",
                table: "mpesatransaction",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "narration",
                table: "mpesatransaction",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "narration",
                table: "mpesatransaction");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "mpesatransaction",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "mpesatransaction",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "recieverFullName",
                table: "mpesatransaction",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "receiverMobile",
                table: "mpesatransaction",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "mpesatransaction",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifedAt",
                table: "mpesatransaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
