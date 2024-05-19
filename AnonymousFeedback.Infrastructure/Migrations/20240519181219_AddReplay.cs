using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnonymousFeedback.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddReplay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReplied",
                table: "FeedBacks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Replay",
                table: "FeedBacks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReplied",
                table: "FeedBacks");

            migrationBuilder.DropColumn(
                name: "Replay",
                table: "FeedBacks");
        }
    }
}
