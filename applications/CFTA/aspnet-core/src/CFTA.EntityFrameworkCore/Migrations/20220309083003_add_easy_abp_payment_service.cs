using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CFTA.Migrations
{
    public partial class add_easy_abp_payment_service : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EasyAbpPaymentServicePayments",
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
                    table.PrimaryKey("PK_EasyAbpPaymentServicePayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpPaymentServiceRefunds",
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
                    table.PrimaryKey("PK_EasyAbpPaymentServiceRefunds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpPaymentServicePaymentItems",
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
                    table.PrimaryKey("PK_EasyAbpPaymentServicePaymentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EasyAbpPaymentServicePaymentItems_EasyAbpPaymentServicePayments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "EasyAbpPaymentServicePayments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EasyAbpPaymentServiceRefundItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "decimal(20,8)", nullable: false),
                    CustomerRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_EasyAbpPaymentServiceRefundItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EasyAbpPaymentServiceRefundItems_EasyAbpPaymentServiceRefunds_RefundId",
                        column: x => x.RefundId,
                        principalTable: "EasyAbpPaymentServiceRefunds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpPaymentServicePaymentItems_PaymentId",
                table: "EasyAbpPaymentServicePaymentItems",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpPaymentServiceRefundItems_RefundId",
                table: "EasyAbpPaymentServiceRefundItems",
                column: "RefundId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EasyAbpPaymentServicePaymentItems");

            migrationBuilder.DropTable(
                name: "EasyAbpPaymentServiceRefundItems");

            migrationBuilder.DropTable(
                name: "EasyAbpPaymentServicePayments");

            migrationBuilder.DropTable(
                name: "EasyAbpPaymentServiceRefunds");
        }
    }
}
