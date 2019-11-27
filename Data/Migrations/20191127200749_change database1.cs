using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PermissionManager.Data.Migrations
{
    public partial class changedatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Approvers_ApproverID",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Responsibles_ResponsibleID",
                table: "Permissions");

            migrationBuilder.DropTable(
                name: "Approvers");

            migrationBuilder.DropTable(
                name: "Responsibles");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_ApproverID",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_ResponsibleID",
                table: "Permissions");

            migrationBuilder.AddColumn<bool>(
                name: "Approver",
                table: "Persons",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Responsible",
                table: "Persons",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PermissionPaperID",
                table: "Permissions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PermissionLog",
                columns: table => new
                {
                    PermissionLogID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionID = table.Column<int>(nullable: false),
                    LogDate = table.Column<DateTime>(nullable: false),
                    ModifiKey = table.Column<string>(nullable: true),
                    ModifyValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionLog", x => x.PermissionLogID);
                    table.ForeignKey(
                        name: "FK_PermissionLog_Permissions_PermissionID",
                        column: x => x.PermissionID,
                        principalTable: "Permissions",
                        principalColumn: "PermissionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionPaper",
                columns: table => new
                {
                    PermissionPaperID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Paper = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPaper", x => x.PermissionPaperID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionPaperID",
                table: "Permissions",
                column: "PermissionPaperID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionLog_PermissionID",
                table: "PermissionLog",
                column: "PermissionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_PermissionPaper_PermissionPaperID",
                table: "Permissions",
                column: "PermissionPaperID",
                principalTable: "PermissionPaper",
                principalColumn: "PermissionPaperID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_PermissionPaper_PermissionPaperID",
                table: "Permissions");

            migrationBuilder.DropTable(
                name: "PermissionLog");

            migrationBuilder.DropTable(
                name: "PermissionPaper");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_PermissionPaperID",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "Approver",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Responsible",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PermissionPaperID",
                table: "Permissions");

            migrationBuilder.CreateTable(
                name: "Approvers",
                columns: table => new
                {
                    ApproverID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApproverEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApproverName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approvers", x => x.ApproverID);
                });

            migrationBuilder.CreateTable(
                name: "Responsibles",
                columns: table => new
                {
                    ResponsibleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponsibleEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsibleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsibles", x => x.ResponsibleID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ApproverID",
                table: "Permissions",
                column: "ApproverID");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ResponsibleID",
                table: "Permissions",
                column: "ResponsibleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Approvers_ApproverID",
                table: "Permissions",
                column: "ApproverID",
                principalTable: "Approvers",
                principalColumn: "ApproverID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Responsibles_ResponsibleID",
                table: "Permissions",
                column: "ResponsibleID",
                principalTable: "Responsibles",
                principalColumn: "ResponsibleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
