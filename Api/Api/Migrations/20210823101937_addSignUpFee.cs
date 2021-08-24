using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class addSignUpFee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "DiscountRate",
                table: "MembershipTypeItems",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "DurationInMonths",
                table: "MembershipTypeItems",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<long>(
                name: "SignUpFee",
                table: "MembershipTypeItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountRate",
                table: "MembershipTypeItems");

            migrationBuilder.DropColumn(
                name: "DurationInMonths",
                table: "MembershipTypeItems");

            migrationBuilder.DropColumn(
                name: "SignUpFee",
                table: "MembershipTypeItems");
        }
    }
}
