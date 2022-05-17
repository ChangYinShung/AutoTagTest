using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CFTA.Migrations
{
    public partial class add_cms_kit_content_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CmsKitContentComponents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Height",
                table: "CmsKitContentComponents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LimitFileSize",
                table: "CmsKitContentComponents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LimitFileType",
                table: "CmsKitContentComponents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Width",
                table: "CmsKitContentComponents",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CmsKitContentComponents");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "CmsKitContentComponents");

            migrationBuilder.DropColumn(
                name: "LimitFileSize",
                table: "CmsKitContentComponents");

            migrationBuilder.DropColumn(
                name: "LimitFileType",
                table: "CmsKitContentComponents");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "CmsKitContentComponents");
        }
    }
}
