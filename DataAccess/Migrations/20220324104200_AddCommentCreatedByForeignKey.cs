using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddCommentCreatedByForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Comments_CreatedBy",
                table: "Comments",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_UserProfiles_CreatedBy",
                table: "Comments",
                column: "CreatedBy",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserProfiles_CreatedBy",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CreatedBy",
                table: "Comments");
        }
    }
}
