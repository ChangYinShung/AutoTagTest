using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CFTA.Migrations
{
    public partial class add_cms_kit_content_definitions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CmsKitAttachmentMedia");

            migrationBuilder.DropTable(
                name: "CmsKitContentProperties");

            migrationBuilder.DropTable(
                name: "CmsKitEntityBlogs");

            migrationBuilder.DropTable(
                name: "CmsKitEntityContents");

            migrationBuilder.DropTable(
                name: "CmsKitShapes");

            migrationBuilder.DropTable(
                name: "CmsKitEntityContentDefinitions");

            migrationBuilder.DropColumn(
                name: "EntityType",
                table: "CmsKitContentDefinitions");

            migrationBuilder.RenameColumn(
                name: "DisplayName",
                table: "CmsKitContentDefinitions",
                newName: "Version");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublish",
                table: "CmsKitContentDefinitions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CmsKitAttachments",
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
                    table.PrimaryKey("PK_CmsKitAttachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CmsKitContentPartDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContentDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemplateDefinitionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CmsKitContentPartDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CmsKitContentPartDefinitions_CmsKitContentDefinitions_ContentDefinitionId",
                        column: x => x.ContentDefinitionId,
                        principalTable: "CmsKitContentDefinitions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CmsKitContentTypeDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContentDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntityType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CmsKitContentTypeDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CmsKitContentTypeDefinitions_CmsKitContentDefinitions_ContentDefinitionId",
                        column: x => x.ContentDefinitionId,
                        principalTable: "CmsKitContentDefinitions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CmsKitContentTypeRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ContentTypeDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_CmsKitContentTypeRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CmsKitContentPartFieldDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentPartDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CmsKitContentPartFieldDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CmsKitContentPartFieldDefinitions_CmsKitContentPartDefinitions_ContentPartDefinitionId",
                        column: x => x.ContentPartDefinitionId,
                        principalTable: "CmsKitContentPartDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CmsKitContentTypePartDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContentTypeDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentPartDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CmsKitContentTypePartDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CmsKitContentTypePartDefinitions_CmsKitContentTypeDefinitions_ContentTypeDefinitionId",
                        column: x => x.ContentTypeDefinitionId,
                        principalTable: "CmsKitContentTypeDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CmsKitContentPartRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentPartDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContentTypeRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CmsKitContentPartRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CmsKitContentPartRecords_CmsKitContentTypeRecords_ContentTypeRecordId",
                        column: x => x.ContentTypeRecordId,
                        principalTable: "CmsKitContentTypeRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CmsKitContentPartFieldRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentPartRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CmsKitContentPartFieldRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CmsKitContentPartFieldRecords_CmsKitContentPartRecords_ContentPartRecordId",
                        column: x => x.ContentPartRecordId,
                        principalTable: "CmsKitContentPartRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitAttachments_CreationTime",
                table: "CmsKitAttachments",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitContentPartDefinitions_ContentDefinitionId",
                table: "CmsKitContentPartDefinitions",
                column: "ContentDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitContentPartDefinitions_CreationTime",
                table: "CmsKitContentPartDefinitions",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitContentPartFieldDefinitions_ContentPartDefinitionId",
                table: "CmsKitContentPartFieldDefinitions",
                column: "ContentPartDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitContentPartFieldRecords_ContentPartRecordId",
                table: "CmsKitContentPartFieldRecords",
                column: "ContentPartRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitContentPartRecords_ContentTypeRecordId",
                table: "CmsKitContentPartRecords",
                column: "ContentTypeRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitContentTypeDefinitions_ContentDefinitionId",
                table: "CmsKitContentTypeDefinitions",
                column: "ContentDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitContentTypeDefinitions_CreationTime",
                table: "CmsKitContentTypeDefinitions",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitContentTypePartDefinitions_ContentTypeDefinitionId",
                table: "CmsKitContentTypePartDefinitions",
                column: "ContentTypeDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitContentTypeRecords_CreationTime",
                table: "CmsKitContentTypeRecords",
                column: "CreationTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CmsKitAttachments");

            migrationBuilder.DropTable(
                name: "CmsKitContentPartFieldDefinitions");

            migrationBuilder.DropTable(
                name: "CmsKitContentPartFieldRecords");

            migrationBuilder.DropTable(
                name: "CmsKitContentTypePartDefinitions");

            migrationBuilder.DropTable(
                name: "CmsKitContentPartDefinitions");

            migrationBuilder.DropTable(
                name: "CmsKitContentPartRecords");

            migrationBuilder.DropTable(
                name: "CmsKitContentTypeDefinitions");

            migrationBuilder.DropTable(
                name: "CmsKitContentTypeRecords");

            migrationBuilder.DropColumn(
                name: "IsPublish",
                table: "CmsKitContentDefinitions");

            migrationBuilder.RenameColumn(
                name: "Version",
                table: "CmsKitContentDefinitions",
                newName: "DisplayName");

            migrationBuilder.AddColumn<string>(
                name: "EntityType",
                table: "CmsKitContentDefinitions",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CmsKitAttachmentMedia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntityId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MediaDescriptorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CmsKitAttachmentMedia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CmsKitContentProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CmsKitContentProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CmsKitContentProperties_CmsKitContentDefinitions_ContentDefinitionId",
                        column: x => x.ContentDefinitionId,
                        principalTable: "CmsKitContentDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CmsKitEntityBlogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntityId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CmsKitEntityBlogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CmsKitEntityContentDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CmsKitEntityContentDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CmsKitEntityContentDefinitions_CmsKitContentDefinitions_ContentDefinitionId",
                        column: x => x.ContentDefinitionId,
                        principalTable: "CmsKitContentDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CmsKitShapes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntityId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TextTemplateContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CmsKitShapes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CmsKitEntityContents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityContentDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntityId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CmsKitEntityContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CmsKitEntityContents_CmsKitEntityContentDefinitions_EntityContentDefinitionId",
                        column: x => x.EntityContentDefinitionId,
                        principalTable: "CmsKitEntityContentDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitAttachmentMedia_CreationTime",
                table: "CmsKitAttachmentMedia",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitContentProperties_ContentDefinitionId",
                table: "CmsKitContentProperties",
                column: "ContentDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitContentProperties_CreationTime",
                table: "CmsKitContentProperties",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitEntityBlogs_CreationTime",
                table: "CmsKitEntityBlogs",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitEntityContentDefinitions_ContentDefinitionId",
                table: "CmsKitEntityContentDefinitions",
                column: "ContentDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitEntityContentDefinitions_CreationTime",
                table: "CmsKitEntityContentDefinitions",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitEntityContents_CreationTime",
                table: "CmsKitEntityContents",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitEntityContents_EntityContentDefinitionId",
                table: "CmsKitEntityContents",
                column: "EntityContentDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitShapes_CreationTime",
                table: "CmsKitShapes",
                column: "CreationTime");
        }
    }
}
