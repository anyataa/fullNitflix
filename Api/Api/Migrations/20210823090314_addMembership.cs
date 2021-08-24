using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class addMembership : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "MovieItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MembershipTypeItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembershipTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipTypeItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSubscribedToNewsLetter = table.Column<bool>(type: "bit", nullable: false),
                    MembershipTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerItems_MembershipTypeItems_MembershipTypeId",
                        column: x => x.MembershipTypeId,
                        principalTable: "MembershipTypeItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerItems_MembershipTypeId",
                table: "CustomerItems",
                column: "MembershipTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerItems");

            migrationBuilder.DropTable(
                name: "MembershipTypeItems");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "MovieItems");
        }
    }
}
