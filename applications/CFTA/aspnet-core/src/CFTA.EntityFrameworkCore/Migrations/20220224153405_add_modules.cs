using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CFTA.Migrations
{
    public partial class add_modules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CmsKitAttachmentMedia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    MediaDescriptorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_CmsKitAttachmentMedia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CmsKitContentDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_CmsKitContentDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CmsKitEntityBlogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_CmsKitEntityBlogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CmsKitShapes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    TextTemplateContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_CmsKitShapes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopOrdersOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CustomerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductTotalPrice = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    TotalDiscount = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    ActualTotalPrice = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    CustomerRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaidTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CanceledTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancellationReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReducedInventoryAfterPlacingTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReducedInventoryAfterPaymentTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopOrdersOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopPaymentsPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayeeAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalTradingCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalPaymentAmount = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    PaymentDiscount = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    ActualPaymentAmount = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    PendingRefundAmount = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    CompletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CanceledTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopPaymentsPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopPaymentsRefunds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefundPaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalTradingCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefundAmount = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    DisplayReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CanceledTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopPaymentsRefunds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopProductsCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UniqueName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediaResources = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopProductsCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EasyAbpEShopProductsCategories_EasyAbpEShopProductsCategories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "EasyAbpEShopProductsCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopProductsProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopProductsProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopProductsProductDetailHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SerializedEntityData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopProductsProductDetailHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopProductsProductDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopProductsProductDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopProductsProductHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SerializedEntityData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopProductsProductHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopProductsProductInventories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductSkuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: false),
                    Sold = table.Column<long>(type: "bigint", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopProductsProductInventories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopProductsProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UniqueName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventoryStrategy = table.Column<int>(type: "int", nullable: false),
                    MediaResources = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    PaymentExpireIn = table.Column<TimeSpan>(type: "time", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopProductsProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopProductsProductViews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UniqueName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventoryStrategy = table.Column<int>(type: "int", nullable: false),
                    MediaResources = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    ProductGroupDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinimumPrice = table.Column<decimal>(type: "decimal(20,8)", nullable: true),
                    MaximumPrice = table.Column<decimal>(type: "decimal(20,8)", nullable: true),
                    Sold = table.Column<long>(type: "bigint", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopProductsProductViews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopStoresStoreOwners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopStoresStoreOwners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopStoresStores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopStoresStores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopStoresTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopStoresTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityEntityDefaults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityEntityDefaults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityMultiLinguals",
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
                    table.PrimaryKey("PK_EntityMultiLinguals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FmDirectoryDescriptors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FmDirectoryDescriptors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FmDirectoryDescriptors_FmDirectoryDescriptors_ParentId",
                        column: x => x.ParentId,
                        principalTable: "FmDirectoryDescriptors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FormManagementEntityForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_FormManagementEntityForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FrmFormResponses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrmFormResponses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FrmForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    CanEditResponse = table.Column<bool>(type: "bit", nullable: false),
                    IsCollectingEmail = table.Column<bool>(type: "bit", nullable: false),
                    HasLimitOneResponsePerUser = table.Column<bool>(type: "bit", nullable: false),
                    IsAcceptingResponses = table.Column<bool>(type: "bit", nullable: false),
                    IsQuiz = table.Column<bool>(type: "bit", nullable: false),
                    RequiresLogin = table.Column<bool>(type: "bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrmForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FrmQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: true),
                    HasOtherOption = table.Column<bool>(type: "bit", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrmQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CmsKitContentProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_CmsKitContentProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CmsKitContentProperties_CmsKitContentDefinitions_ContentDefinitionId",
                        column: x => x.ContentDefinitionId,
                        principalTable: "CmsKitContentDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CmsKitEntityContentDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContentDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                name: "EasyAbpEShopOrdersOrderExtraFees",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fee = table.Column<decimal>(type: "decimal(20,8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopOrdersOrderExtraFees", x => new { x.OrderId, x.Name, x.Key });
                    table.ForeignKey(
                        name: "FK_EasyAbpEShopOrdersOrderExtraFees_EasyAbpEShopOrdersOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "EasyAbpEShopOrdersOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopOrdersOrderLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductSkuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductDetailModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductGroupDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductUniqueName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediaResources = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    TotalDiscount = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    ActualTotalPrice = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RefundedQuantity = table.Column<int>(type: "int", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopOrdersOrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EasyAbpEShopOrdersOrderLines_EasyAbpEShopOrdersOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "EasyAbpEShopOrdersOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopPaymentsPaymentItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalPaymentAmount = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    PaymentDiscount = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    ActualPaymentAmount = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    PendingRefundAmount = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopPaymentsPaymentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EasyAbpEShopPaymentsPaymentItems_EasyAbpEShopPaymentsPayments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "EasyAbpEShopPaymentsPayments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopPaymentsRefundItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    CustomerRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefundId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopPaymentsRefundItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EasyAbpEShopPaymentsRefundItems_EasyAbpEShopPaymentsRefunds_RefundId",
                        column: x => x.RefundId,
                        principalTable: "EasyAbpEShopPaymentsRefunds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopProductsProductAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopProductsProductAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EasyAbpEShopProductsProductAttributes_EasyAbpEShopProductsProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "EasyAbpEShopProductsProducts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopProductsProductSkus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerializedAttributeOptionIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalPrice = table.Column<decimal>(type: "decimal(20,8)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    OrderMinQuantity = table.Column<int>(type: "int", nullable: false),
                    OrderMaxQuantity = table.Column<int>(type: "int", nullable: false),
                    PaymentExpireIn = table.Column<TimeSpan>(type: "time", nullable: true),
                    MediaResources = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopProductsProductSkus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EasyAbpEShopProductsProductSkus_EasyAbpEShopProductsProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "EasyAbpEShopProductsProducts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EntityEntityDefaultItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityDefaultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityEntityDefaultItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityEntityDefaultItems_EntityEntityDefaults_EntityDefaultId",
                        column: x => x.EntityDefaultId,
                        principalTable: "EntityEntityDefaults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityMultiLingualTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Culture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MultiLingualId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_EntityMultiLingualTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityMultiLingualTranslations_EntityMultiLinguals_MultiLingualId",
                        column: x => x.MultiLingualId,
                        principalTable: "EntityMultiLinguals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FmFileDescriptors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DirectoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Size = table.Column<int>(type: "int", maxLength: 2147483647, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FmFileDescriptors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FmFileDescriptors_FmDirectoryDescriptors_DirectoryId",
                        column: x => x.DirectoryId,
                        principalTable: "FmDirectoryDescriptors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FrmAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormResponseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AnswerDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrmAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FrmAnswers_FrmFormResponses_FormResponseId",
                        column: x => x.FormResponseId,
                        principalTable: "FrmFormResponses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FrmChoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChoosableQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrmChoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FrmChoices_FrmQuestions_ChoosableQuestionId",
                        column: x => x.ChoosableQuestionId,
                        principalTable: "FrmQuestions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CmsKitEntityContents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityContentDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_CmsKitEntityContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CmsKitEntityContents_CmsKitEntityContentDefinitions_EntityContentDefinitionId",
                        column: x => x.EntityContentDefinitionId,
                        principalTable: "CmsKitEntityContentDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopPaymentsRefundItemOrderLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefundedQuantity = table.Column<int>(type: "int", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    RefundItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopPaymentsRefundItemOrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EasyAbpEShopPaymentsRefundItemOrderLines_EasyAbpEShopPaymentsRefundItems_RefundItemId",
                        column: x => x.RefundItemId,
                        principalTable: "EasyAbpEShopPaymentsRefundItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpEShopProductsProductAttributeOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductAttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpEShopProductsProductAttributeOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EasyAbpEShopProductsProductAttributeOptions_EasyAbpEShopProductsProductAttributes_ProductAttributeId",
                        column: x => x.ProductAttributeId,
                        principalTable: "EasyAbpEShopProductsProductAttributes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitAttachmentMedia_CreationTime",
                table: "CmsKitAttachmentMedia",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitContentDefinitions_CreationTime",
                table: "CmsKitContentDefinitions",
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

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopOrdersOrderLines_OrderId",
                table: "EasyAbpEShopOrdersOrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopOrdersOrders_OrderNumber",
                table: "EasyAbpEShopOrdersOrders",
                column: "OrderNumber",
                unique: true,
                filter: "[OrderNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopPaymentsPaymentItems_PaymentId",
                table: "EasyAbpEShopPaymentsPaymentItems",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopPaymentsRefundItemOrderLines_RefundItemId",
                table: "EasyAbpEShopPaymentsRefundItemOrderLines",
                column: "RefundItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopPaymentsRefundItems_RefundId",
                table: "EasyAbpEShopPaymentsRefundItems",
                column: "RefundId");

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopProductsCategories_ParentId",
                table: "EasyAbpEShopProductsCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopProductsProductAttributeOptions_ProductAttributeId",
                table: "EasyAbpEShopProductsProductAttributeOptions",
                column: "ProductAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopProductsProductAttributes_ProductId",
                table: "EasyAbpEShopProductsProductAttributes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopProductsProductDetailHistories_ModificationTime",
                table: "EasyAbpEShopProductsProductDetailHistories",
                column: "ModificationTime");

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopProductsProductDetailHistories_ProductDetailId",
                table: "EasyAbpEShopProductsProductDetailHistories",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopProductsProductHistories_ModificationTime",
                table: "EasyAbpEShopProductsProductHistories",
                column: "ModificationTime");

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopProductsProductHistories_ProductId",
                table: "EasyAbpEShopProductsProductHistories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopProductsProductInventories_ProductSkuId",
                table: "EasyAbpEShopProductsProductInventories",
                column: "ProductSkuId");

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopProductsProducts_UniqueName",
                table: "EasyAbpEShopProductsProducts",
                column: "UniqueName");

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopProductsProductSkus_ProductId",
                table: "EasyAbpEShopProductsProductSkus",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopProductsProductViews_UniqueName",
                table: "EasyAbpEShopProductsProductViews",
                column: "UniqueName");

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpEShopStoresStoreOwners_OwnerUserId_StoreId",
                table: "EasyAbpEShopStoresStoreOwners",
                columns: new[] { "OwnerUserId", "StoreId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntityEntityDefaultItems_CreationTime",
                table: "EntityEntityDefaultItems",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_EntityEntityDefaultItems_EntityDefaultId",
                table: "EntityEntityDefaultItems",
                column: "EntityDefaultId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityEntityDefaults_CreationTime",
                table: "EntityEntityDefaults",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_EntityMultiLinguals_CreationTime",
                table: "EntityMultiLinguals",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_EntityMultiLinguals_EntityType_EntityId",
                table: "EntityMultiLinguals",
                columns: new[] { "EntityType", "EntityId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntityMultiLingualTranslations_CreationTime",
                table: "EntityMultiLingualTranslations",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_EntityMultiLingualTranslations_MultiLingualId",
                table: "EntityMultiLingualTranslations",
                column: "MultiLingualId");

            migrationBuilder.CreateIndex(
                name: "IX_FmDirectoryDescriptors_ParentId",
                table: "FmDirectoryDescriptors",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_FmDirectoryDescriptors_TenantId_ParentId_Name",
                table: "FmDirectoryDescriptors",
                columns: new[] { "TenantId", "ParentId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_FmFileDescriptors_DirectoryId",
                table: "FmFileDescriptors",
                column: "DirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FmFileDescriptors_TenantId_DirectoryId_Name",
                table: "FmFileDescriptors",
                columns: new[] { "TenantId", "DirectoryId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_FormManagementEntityForms_CreationTime",
                table: "FormManagementEntityForms",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_FrmAnswers_FormResponseId",
                table: "FrmAnswers",
                column: "FormResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_FrmAnswers_Id_QuestionId_FormResponseId_TenantId",
                table: "FrmAnswers",
                columns: new[] { "Id", "QuestionId", "FormResponseId", "TenantId" });

            migrationBuilder.CreateIndex(
                name: "IX_FrmChoices_ChoosableQuestionId",
                table: "FrmChoices",
                column: "ChoosableQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_FrmChoices_Id_ChoosableQuestionId_TenantId",
                table: "FrmChoices",
                columns: new[] { "Id", "ChoosableQuestionId", "TenantId" });

            migrationBuilder.CreateIndex(
                name: "IX_FrmFormResponses_Id_FormId_UserId_TenantId",
                table: "FrmFormResponses",
                columns: new[] { "Id", "FormId", "UserId", "TenantId" });

            migrationBuilder.CreateIndex(
                name: "IX_FrmForms_Id_TenantId",
                table: "FrmForms",
                columns: new[] { "Id", "TenantId" });

            migrationBuilder.CreateIndex(
                name: "IX_FrmQuestions_Id_FormId_TenantId",
                table: "FrmQuestions",
                columns: new[] { "Id", "FormId", "TenantId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "EasyAbpEShopOrdersOrderExtraFees");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopOrdersOrderLines");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopPaymentsPaymentItems");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopPaymentsRefundItemOrderLines");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopProductsCategories");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopProductsProductAttributeOptions");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopProductsProductCategories");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopProductsProductDetailHistories");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopProductsProductDetails");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopProductsProductHistories");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopProductsProductInventories");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopProductsProductSkus");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopProductsProductViews");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopStoresStoreOwners");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopStoresStores");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopStoresTransactions");

            migrationBuilder.DropTable(
                name: "EntityEntityDefaultItems");

            migrationBuilder.DropTable(
                name: "EntityMultiLingualTranslations");

            migrationBuilder.DropTable(
                name: "FmFileDescriptors");

            migrationBuilder.DropTable(
                name: "FormManagementEntityForms");

            migrationBuilder.DropTable(
                name: "FrmAnswers");

            migrationBuilder.DropTable(
                name: "FrmChoices");

            migrationBuilder.DropTable(
                name: "FrmForms");

            migrationBuilder.DropTable(
                name: "CmsKitEntityContentDefinitions");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopOrdersOrders");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopPaymentsPayments");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopPaymentsRefundItems");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopProductsProductAttributes");

            migrationBuilder.DropTable(
                name: "EntityEntityDefaults");

            migrationBuilder.DropTable(
                name: "EntityMultiLinguals");

            migrationBuilder.DropTable(
                name: "FmDirectoryDescriptors");

            migrationBuilder.DropTable(
                name: "FrmFormResponses");

            migrationBuilder.DropTable(
                name: "FrmQuestions");

            migrationBuilder.DropTable(
                name: "CmsKitContentDefinitions");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopPaymentsRefunds");

            migrationBuilder.DropTable(
                name: "EasyAbpEShopProductsProducts");
        }
    }
}
