using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddConstructionInspectionRequestList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TargetStepOrder",
                table: "WorkflowInstanceHistoryList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuotationId",
                table: "PurchaseOrderList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileData",
                table: "DrawingAttachment",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "DisciplinesList",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileData",
                table: "AttachmentList",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ConstructionInspectionRequestList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num = table.Column<int>(type: "int", nullable: true),
                    RegisterNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rev = table.Column<int>(type: "int", nullable: true),
                    PreparedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DisciplineId = table.Column<int>(type: "int", nullable: true),
                    SecondaryDisciplineId = table.Column<int>(type: "int", nullable: true),
                    InspectionActivityId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BOQRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DWGRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MSRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingId = table.Column<int>(type: "int", nullable: true),
                    FloorIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrjId = table.Column<int>(type: "int", nullable: true),
                    OverallStatus = table.Column<int>(type: "int", nullable: false),
                    CSTReviewStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CSTReviewComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmittedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CSTReturnedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewedJobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedJobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    DeletionBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionInspectionRequestList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConstructionInspectionRequestList_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConstructionInspectionRequestList_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConstructionInspectionRequestList_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionInspectionRequestList_CreatedBy",
                table: "ConstructionInspectionRequestList",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionInspectionRequestList_DeletionBy",
                table: "ConstructionInspectionRequestList",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionInspectionRequestList_UpdateBy",
                table: "ConstructionInspectionRequestList",
                column: "UpdateBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstructionInspectionRequestList");

            migrationBuilder.DropColumn(
                name: "TargetStepOrder",
                table: "WorkflowInstanceHistoryList");

            migrationBuilder.DropColumn(
                name: "QuotationId",
                table: "PurchaseOrderList");

            migrationBuilder.DropColumn(
                name: "FileData",
                table: "DrawingAttachment");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "DisciplinesList");

            migrationBuilder.DropColumn(
                name: "FileData",
                table: "AttachmentList");
        }
    }
}
