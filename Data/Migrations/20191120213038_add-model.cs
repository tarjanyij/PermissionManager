using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PermissionManager.Data.Migrations
{
    public partial class addmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Approvers",
                columns: table => new
                {
                    ApproverID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApproverName = table.Column<string>(nullable: true),
                    ApproverEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approvers", x => x.ApproverID);
                });

            migrationBuilder.CreateTable(
                name: "OfficeRights",
                columns: table => new
                {
                    OfficeRightsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeRights", x => x.OfficeRightsID);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    OfficeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.OfficeID);
                });

            migrationBuilder.CreateTable(
                name: "Responsibles",
                columns: table => new
                {
                    ResponsibleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponsibleName = table.Column<string>(nullable: true),
                    ResponsibleEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsibles", x => x.ResponsibleID);
                });

            migrationBuilder.CreateTable(
                name: "Rights",
                columns: table => new
                {
                    RightsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RightsName = table.Column<string>(nullable: true),
                    RightsValue = table.Column<string>(nullable: true),
                    OfficeRightsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rights", x => x.RightsID);
                    table.ForeignKey(
                        name: "FK_Rights_OfficeRights_OfficeRightsID",
                        column: x => x.OfficeRightsID,
                        principalTable: "OfficeRights",
                        principalColumn: "OfficeRightsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonName = table.Column<string>(nullable: true),
                    PersonEmail = table.Column<string>(nullable: true),
                    OfficeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Persons_Offices_OfficeID",
                        column: x => x.OfficeID,
                        principalTable: "Offices",
                        principalColumn: "OfficeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(nullable: false),
                    RightsID = table.Column<int>(nullable: false),
                    BeginDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ApproverID = table.Column<int>(nullable: false),
                    ResponsibleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionID);
                    table.ForeignKey(
                        name: "FK_Permissions_Approvers_ApproverID",
                        column: x => x.ApproverID,
                        principalTable: "Approvers",
                        principalColumn: "ApproverID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_Responsibles_ResponsibleID",
                        column: x => x.ResponsibleID,
                        principalTable: "Responsibles",
                        principalColumn: "ResponsibleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_Rights_RightsID",
                        column: x => x.RightsID,
                        principalTable: "Rights",
                        principalColumn: "RightsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ApproverID",
                table: "Permissions",
                column: "ApproverID");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PersonID",
                table: "Permissions",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ResponsibleID",
                table: "Permissions",
                column: "ResponsibleID");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RightsID",
                table: "Permissions",
                column: "RightsID");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_OfficeID",
                table: "Persons",
                column: "OfficeID");

            migrationBuilder.CreateIndex(
                name: "IX_Rights_OfficeRightsID",
                table: "Rights",
                column: "OfficeRightsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Approvers");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Responsibles");

            migrationBuilder.DropTable(
                name: "Rights");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "OfficeRights");
        }
    }
}
