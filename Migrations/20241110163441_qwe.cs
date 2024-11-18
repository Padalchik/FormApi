using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormApi.Migrations
{
    /// <inheritdoc />
    public partial class qwe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relatives_Forms_FormEntityId",
                table: "Relatives");

            migrationBuilder.DropIndex(
                name: "IX_Relatives_FormEntityId",
                table: "Relatives");

            migrationBuilder.DropColumn(
                name: "FormEntityId",
                table: "Relatives");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Relatives",
                newName: "FormId");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Relatives",
                newName: "CreateDate");

            migrationBuilder.CreateIndex(
                name: "IX_Relatives_FormId",
                table: "Relatives",
                column: "FormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Relatives_Forms_FormId",
                table: "Relatives",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relatives_Forms_FormId",
                table: "Relatives");

            migrationBuilder.DropIndex(
                name: "IX_Relatives_FormId",
                table: "Relatives");

            migrationBuilder.RenameColumn(
                name: "FormId",
                table: "Relatives",
                newName: "OwnerId");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Relatives",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<Guid>(
                name: "FormEntityId",
                table: "Relatives",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Relatives_FormEntityId",
                table: "Relatives",
                column: "FormEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Relatives_Forms_FormEntityId",
                table: "Relatives",
                column: "FormEntityId",
                principalTable: "Forms",
                principalColumn: "Id");
        }
    }
}
