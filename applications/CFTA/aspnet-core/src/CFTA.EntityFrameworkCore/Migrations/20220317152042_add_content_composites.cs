using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CFTA.Migrations
{
    public partial class add_content_composites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CmsKitContentComponents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContentEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentComponentDiscriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CmsKitContentComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CmsKitContentComponents_CmsKitContentComponents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "CmsKitContentComponents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CmsKitContentEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CmsKitContentEntities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitContentComponents_CreationTime",
                table: "CmsKitContentComponents",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitContentComponents_ParentId",
                table: "CmsKitContentComponents",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitContentEntities_CreationTime",
                table: "CmsKitContentEntities",
                column: "CreationTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CmsKitContentComponents");

            migrationBuilder.DropTable(
                name: "CmsKitContentEntities");
        }
    }
}
