using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class removeMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerItems_MembershipTypeItems_MembershipTypeId",
                table: "CustomerItems");

            migrationBuilder.DropIndex(
                name: "IX_CustomerItems_MembershipTypeId",
                table: "CustomerItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CustomerItems_MembershipTypeId",
                table: "CustomerItems",
                column: "MembershipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerItems_MembershipTypeItems_MembershipTypeId",
                table: "CustomerItems",
                column: "MembershipTypeId",
                principalTable: "MembershipTypeItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
