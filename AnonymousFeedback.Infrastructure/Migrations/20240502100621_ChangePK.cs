using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnonymousFeedback.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangePK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Users_ReceiverUserName",
                table: "FeedBacks");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Users_SenderUserName",
                table: "FeedBacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_FeedBacks_ReceiverUserName",
                table: "FeedBacks");

            migrationBuilder.DropIndex(
                name: "IX_FeedBacks_SenderUserName",
                table: "FeedBacks");

            migrationBuilder.DropColumn(
                name: "ReceiverUserName",
                table: "FeedBacks");

            migrationBuilder.DropColumn(
                name: "SenderUserName",
                table: "FeedBacks");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ReceiverId",
                table: "FeedBacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "FeedBacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_ReceiverId",
                table: "FeedBacks",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_SenderId",
                table: "FeedBacks",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Users_ReceiverId",
                table: "FeedBacks",
                column: "ReceiverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Users_SenderId",
                table: "FeedBacks",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Users_ReceiverId",
                table: "FeedBacks");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Users_SenderId",
                table: "FeedBacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_FeedBacks_ReceiverId",
                table: "FeedBacks");

            migrationBuilder.DropIndex(
                name: "IX_FeedBacks_SenderId",
                table: "FeedBacks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "FeedBacks");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "FeedBacks");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverUserName",
                table: "FeedBacks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderUserName",
                table: "FeedBacks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_ReceiverUserName",
                table: "FeedBacks",
                column: "ReceiverUserName");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_SenderUserName",
                table: "FeedBacks",
                column: "SenderUserName");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Users_ReceiverUserName",
                table: "FeedBacks",
                column: "ReceiverUserName",
                principalTable: "Users",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Users_SenderUserName",
                table: "FeedBacks",
                column: "SenderUserName",
                principalTable: "Users",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
