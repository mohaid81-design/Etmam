using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MachineName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalMatrixList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalMatrixList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityRecordId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoredPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSizeKB = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UploadedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldValuesJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValuesJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrelationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachineName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrawingAttachment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrawingId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoredPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSizeKB = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UploadedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawingAttachment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrawingsCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawingsCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrawingsIssuerList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawingsIssuerList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrawingsRegisterDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Building = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrawingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revision = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultantDecision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReSubmittedRejectedItems = table.Column<bool>(type: "bit", nullable: true),
                    SigningCompleted = table.Column<bool>(type: "bit", nullable: true),
                    ConsultantNotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawingsRegisterDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrawingsRegisterList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num = table.Column<int>(type: "int", nullable: true),
                    RegisterNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rev = table.Column<int>(type: "int", nullable: true),
                    PreparedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    SubCategory = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Building = table.Column<int>(type: "int", nullable: true),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrawingIssuer = table.Column<int>(type: "int", nullable: true),
                    PrjId = table.Column<int>(type: "int", nullable: true),
                    OverallStatus = table.Column<int>(type: "int", nullable: true),
                    SubmittedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CSTReturnedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CSTReviewComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CSTReviewStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawingsRegisterList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrawingsStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawingsStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrawingsSubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawingsSubCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrawingsSubmittalList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num = table.Column<int>(type: "int", nullable: true),
                    Rev = table.Column<int>(type: "int", nullable: true),
                    PreparedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Abb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrjId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssuedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CSTDateReceived = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CSTDateReturned = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CSTReviewComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CSTReviewStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawingsSubmittalList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrawingsType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawingsType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialIssuedDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CCId = table.Column<int>(type: "int", nullable: true),
                    BdgId = table.Column<int>(type: "int", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialIssuedDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialIssuedList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num = table.Column<int>(type: "int", nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: true),
                    IssuedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceivedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialIssuedList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialIssueReturnDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CCId = table.Column<int>(type: "int", nullable: true),
                    BdgId = table.Column<int>(type: "int", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialIssueReturnDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialIssueReturnList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num = table.Column<int>(type: "int", nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CCIdId = table.Column<int>(type: "int", nullable: true),
                    BdgId = table.Column<int>(type: "int", nullable: true),
                    ReturnBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialIssueReturnList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialReceiveDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    PODetailId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialReceiveDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialReceiveList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num = table.Column<int>(type: "int", nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: true),
                    StakeholderId = table.Column<int>(type: "int", nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoucherNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialReceiveList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialTransferDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CCId = table.Column<int>(type: "int", nullable: true),
                    BdgId = table.Column<int>(type: "int", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTransferDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialTransferList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num = table.Column<int>(type: "int", nullable: true),
                    TransferDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FromStoreId = table.Column<int>(type: "int", nullable: true),
                    ToStoreId = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTransferList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NumberSeriesCounter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriesKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberSeriesCounter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpeningBalanceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningBalanceDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpeningBalanceList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num = table.Column<int>(type: "int", nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: true),
                    BalanceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningBalanceList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionsList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    SortID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionsList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceQuotationCompareDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    PriceQuotationRequestId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceQuotationCompareDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceQuotationCompareList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num = table.Column<int>(type: "int", nullable: true),
                    PrjId = table.Column<int>(type: "int", nullable: true),
                    PRId = table.Column<int>(type: "int", nullable: true),
                    RFQId = table.Column<int>(type: "int", nullable: true),
                    RequestType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceQuotationCompareList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceQuotationList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num = table.Column<int>(type: "int", nullable: true),
                    StakeholderId = table.Column<int>(type: "int", nullable: true),
                    PrjId = table.Column<int>(type: "int", nullable: true),
                    PRId = table.Column<int>(type: "int", nullable: true),
                    QuotationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceQuotationList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceQuotationRequestDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    PRDetailsId = table.Column<int>(type: "int", nullable: true),
                    RFQDetailId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DiscountPercent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TaxPercent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceQuotationRequestDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceQuotationRequestList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num = table.Column<int>(type: "int", nullable: true),
                    PrjId = table.Column<int>(type: "int", nullable: true),
                    RFQId = table.Column<int>(type: "int", nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: true),
                    StakeholderId = table.Column<int>(type: "int", nullable: true),
                    PRId = table.Column<int>(type: "int", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecutionDuration = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ExecutionDurationUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarrantyDuration = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    WarrantyDurationUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotationValidityPeriod = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    QuotationValidityUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DailyPenaltyRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DailyPenaltyMaxPercent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PerformanceBondPercent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    OtherConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceQuotationRequestList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    PRDetailId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    BdgId = table.Column<int>(type: "int", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DiscountPercent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TaxPercent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierManufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num = table.Column<int>(type: "int", nullable: true),
                    PrjId = table.Column<int>(type: "int", nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: true),
                    StakeholderId = table.Column<int>(type: "int", nullable: true),
                    PRId = table.Column<int>(type: "int", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OverallStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RejectReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    OriginalValue = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriorityLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecutionDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DailyPenaltyRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DailyPenaltyMaxPercent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PerformanceBondPercent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    WarrantyDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractTermsOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReturnDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    RVDetailId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReturnDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReturnList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StakeholderId = table.Column<int>(type: "int", nullable: true),
                    MRId = table.Column<int>(type: "int", nullable: true),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrjId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReturnList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFQList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num = table.Column<int>(type: "int", nullable: true),
                    PrjId = table.Column<int>(type: "int", nullable: true),
                    PRId = table.Column<int>(type: "int", nullable: true),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecutionDuration = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    ExecutionDurationUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarrantyDuration = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    WarrantyDurationUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotationValidityPeriod = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    QuotationValidityUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DailyPenaltyRate = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    DailyPenaltyMaxPercent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PerformanceBondPercent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    OtherConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFQList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StakeholdersCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StakeholdersCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    SystemQty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockingDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockingList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num = table.Column<int>(type: "int", nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: true),
                    StockingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockingList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SettingKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SettingValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsFirstLogin = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Signature = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowDefinitionList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowDefinitionList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NegotiationList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFQId = table.Column<int>(type: "int", nullable: true),
                    PriceQuotationRequestId = table.Column<int>(type: "int", nullable: true),
                    RoundNumber = table.Column<int>(type: "int", nullable: true),
                    NegotiationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PreviousAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    NewAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    IsBAFO = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NegotiationList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NegotiationList_PriceQuotationRequestList_PriceQuotationRequestId",
                        column: x => x.PriceQuotationRequestId,
                        principalTable: "PriceQuotationRequestList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "POAmendmentList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num = table.Column<int>(type: "int", nullable: true),
                    POId = table.Column<int>(type: "int", nullable: true),
                    AmendmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PreviousValue = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    AmendmentValue = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RevisedValue = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POAmendmentList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_POAmendmentList_PurchaseOrderList_POId",
                        column: x => x.POId,
                        principalTable: "PurchaseOrderList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AwardRecommendationList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num = table.Column<int>(type: "int", nullable: true),
                    RFQId = table.Column<int>(type: "int", nullable: true),
                    PriceQuotationRequestId = table.Column<int>(type: "int", nullable: true),
                    RecommendedAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RecommendationReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLowestBid = table.Column<bool>(type: "bit", nullable: false),
                    DeviationJustification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnicalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BudgetStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkflowInstanceId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardRecommendationList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AwardRecommendationList_PriceQuotationRequestList_PriceQuotationRequestId",
                        column: x => x.PriceQuotationRequestId,
                        principalTable: "PriceQuotationRequestList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AwardRecommendationList_RFQList_RFQId",
                        column: x => x.RFQId,
                        principalTable: "RFQList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CostCenterList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    PrjId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_CostCenterList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostCenterList_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostCenterList_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostCenterList_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentsList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_DepartmentsList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentsList_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentsList_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentsList_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinesList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_DisciplinesList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisciplinesList_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DisciplinesList_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DisciplinesList_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_EquipmentList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentList_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentList_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentList_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    LvlId = table.Column<int>(type: "int", nullable: true),
                    SortId = table.Column<int>(type: "int", nullable: true),
                    IsFixed = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_ItemCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCategory_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemCategory_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemCategory_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManpowerList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ManpowerList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManpowerList_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManpowerList_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManpowerList_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialApprovalRequestDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MARId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BOQRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrawingRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrjId = table.Column<int>(type: "int", nullable: true),
                    ReviewComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRejectedItemRequiredResubmitt = table.Column<bool>(type: "bit", nullable: true),
                    IsRejectedItemResubmitted = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_MaterialApprovalRequestDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialApprovalRequestDetails_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialApprovalRequestDetails_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialApprovalRequestDetails_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialApprovalRequestList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num = table.Column<int>(type: "int", nullable: true),
                    Rev = table.Column<int>(type: "int", nullable: true),
                    PreparedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: true),
                    SubCategory = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrjId = table.Column<int>(type: "int", nullable: true),
                    OverallStatus = table.Column<int>(type: "int", nullable: true),
                    IssuedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSubmitted = table.Column<bool>(type: "bit", nullable: true),
                    SubmittedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachCalculations = table.Column<bool>(type: "bit", nullable: true),
                    AttachCatalogues = table.Column<bool>(type: "bit", nullable: true),
                    AttachCertificates = table.Column<bool>(type: "bit", nullable: true),
                    AttachDrawings = table.Column<bool>(type: "bit", nullable: true),
                    AttachTest = table.Column<bool>(type: "bit", nullable: true),
                    AttachSpecifications = table.Column<bool>(type: "bit", nullable: true),
                    AttachSample = table.Column<bool>(type: "bit", nullable: true),
                    AttachOther = table.Column<bool>(type: "bit", nullable: true),
                    AttachOtherText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSubmittedFormSigned = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_MaterialApprovalRequestList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialApprovalRequestList_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialApprovalRequestList_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialApprovalRequestList_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequestList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num = table.Column<int>(type: "int", nullable: true),
                    PrjId = table.Column<int>(type: "int", nullable: true),
                    DeptId = table.Column<int>(type: "int", nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: true),
                    DisciplineId = table.Column<int>(type: "int", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverallStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssuedBy = table.Column<int>(type: "int", nullable: true),
                    IssuedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RejectReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequestList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestList_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestList_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestList_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StakeholdersList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommercialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsVendor = table.Column<bool>(type: "bit", nullable: true),
                    PaymentTermsDays = table.Column<int>(type: "int", nullable: true),
                    CreditLimit = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    IsSponsor = table.Column<bool>(type: "bit", nullable: true),
                    IsClient = table.Column<bool>(type: "bit", nullable: true),
                    IsConsultant = table.Column<bool>(type: "bit", nullable: true),
                    IsSubcontractor = table.Column<bool>(type: "bit", nullable: true),
                    IsOther = table.Column<bool>(type: "bit", nullable: true),
                    CommercialIssuedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommercialEndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommercialManager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommercialAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATIssuedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StakeholdersList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StakeholdersList_StakeholdersCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "StakeholdersCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StakeholdersList_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StakeholdersList_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StakeholdersList_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    PrjId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_StoreList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreList_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreList_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreList_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubmittalCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abb = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SubmittalCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmittalCategory_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubmittalCategory_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubmittalCategory_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubmittalStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SubmittalStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmittalStatus_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubmittalStatus_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubmittalStatus_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubmittalSubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_SubmittalSubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmittalSubCategory_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubmittalSubCategory_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubmittalSubCategory_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalEvaluationList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFQId = table.Column<int>(type: "int", nullable: true),
                    PriceQuotationRequestId = table.Column<int>(type: "int", nullable: true),
                    EvaluationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EvaluatedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverallComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalEvaluationList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalEvaluationList_PriceQuotationRequestList_PriceQuotationRequestId",
                        column: x => x.PriceQuotationRequestId,
                        principalTable: "PriceQuotationRequestList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TechnicalEvaluationList_UsersList_EvaluatedBy",
                        column: x => x.EvaluatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Units_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Units_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissionStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    PermsID = table.Column<int>(type: "int", nullable: false),
                    PermsStatus = table.Column<bool>(type: "bit", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissionStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPermissionStatus_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProjectAccess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    PrjId = table.Column<int>(type: "int", nullable: false),
                    PermsStatus = table.Column<bool>(type: "bit", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjectAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProjectAccess_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserStoreAccess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    PermsStatus = table.Column<bool>(type: "bit", nullable: false),
                    CanReceive = table.Column<bool>(type: "bit", nullable: false),
                    CanIssue = table.Column<bool>(type: "bit", nullable: false),
                    CanTransfer = table.Column<bool>(type: "bit", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStoreAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserStoreAccess_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserWorkflowAccess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    WorkflowId = table.Column<int>(type: "int", nullable: false),
                    PermsStatus = table.Column<bool>(type: "bit", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWorkflowAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWorkflowAccess_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalLimitList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatrixId = table.Column<int>(type: "int", nullable: true),
                    MinAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MaxAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    WorkflowDefinitionId = table.Column<int>(type: "int", nullable: true),
                    EffectiveFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EffectiveTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalLimitList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalLimitList_ApprovalMatrixList_MatrixId",
                        column: x => x.MatrixId,
                        principalTable: "ApprovalMatrixList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalLimitList_WorkflowDefinitionList_WorkflowDefinitionId",
                        column: x => x.WorkflowDefinitionId,
                        principalTable: "WorkflowDefinitionList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowInstanceList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkflowDefinitionId = table.Column<int>(type: "int", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityRecordId = table.Column<int>(type: "int", nullable: false),
                    CurrentStepOrder = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartedBy = table.Column<int>(type: "int", nullable: false),
                    StartedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowInstanceList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowInstanceList_UsersList_StartedBy",
                        column: x => x.StartedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowInstanceList_WorkflowDefinitionList_WorkflowDefinitionId",
                        column: x => x.WorkflowDefinitionId,
                        principalTable: "WorkflowDefinitionList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowStepList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkflowDefinitionId = table.Column<int>(type: "int", nullable: false),
                    StepOrder = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowStepList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowStepList_WorkflowDefinitionList_WorkflowDefinitionId",
                        column: x => x.WorkflowDefinitionId,
                        principalTable: "WorkflowDefinitionList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "POAmendmentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    POLineId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldValue = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    NewValue = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POAmendmentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_POAmendmentDetails_POAmendmentList_ParentId",
                        column: x => x.ParentId,
                        principalTable: "POAmendmentList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_POAmendmentDetails_PurchaseOrderDetails_POLineId",
                        column: x => x.POLineId,
                        principalTable: "PurchaseOrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BudgetList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrjId = table.Column<int>(type: "int", nullable: true),
                    CostCenterId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AllocatedAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_BudgetList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetList_CostCenterList_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "CostCenterList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BudgetList_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BudgetList_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BudgetList_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowDefinitionDisciplineList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkflowDefinitionId = table.Column<int>(type: "int", nullable: false),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowDefinitionDisciplineList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowDefinitionDisciplineList_DisciplinesList_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "DisciplinesList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowDefinitionDisciplineList_WorkflowDefinitionList_WorkflowDefinitionId",
                        column: x => x.WorkflowDefinitionId,
                        principalTable: "WorkflowDefinitionList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Situation = table.Column<int>(type: "int", nullable: true),
                    ProjectStartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitialHandover = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalHandover = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContractAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    AdvancePaymentAmount = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    AdvancePaymentPercent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RetentionPercent = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    CLId = table.Column<int>(type: "int", nullable: true),
                    CSTId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectsList_StakeholdersList_CLId",
                        column: x => x.CLId,
                        principalTable: "StakeholdersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectsList_StakeholdersList_CSTId",
                        column: x => x.CSTId,
                        principalTable: "StakeholdersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectsList_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectsList_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectsList_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RFQVendorList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFQId = table.Column<int>(type: "int", nullable: true),
                    StakeholderId = table.Column<int>(type: "int", nullable: true),
                    InvitedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFQVendorList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RFQVendorList_RFQList_RFQId",
                        column: x => x.RFQId,
                        principalTable: "RFQList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RFQVendorList_StakeholdersList_StakeholderId",
                        column: x => x.StakeholderId,
                        principalTable: "StakeholdersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalEvaluationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    PriceQuotationRequestDetailId = table.Column<int>(type: "int", nullable: true),
                    IsCompliant = table.Column<bool>(type: "bit", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalEvaluationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalEvaluationDetails_PriceQuotationRequestDetails_PriceQuotationRequestDetailId",
                        column: x => x.PriceQuotationRequestDetailId,
                        principalTable: "PriceQuotationRequestDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TechnicalEvaluationDetails_TechnicalEvaluationList_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TechnicalEvaluationList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemsList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_ItemsList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsList_ItemCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ItemCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemsList_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemsList_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemsList_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemsList_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowInstanceStepList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkflowInstanceId = table.Column<int>(type: "int", nullable: false),
                    StepOrder = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowInstanceStepList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowInstanceStepList_WorkflowInstanceList_WorkflowInstanceId",
                        column: x => x.WorkflowInstanceId,
                        principalTable: "WorkflowInstanceList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowInstanceHistoryList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkflowInstanceId = table.Column<int>(type: "int", nullable: false),
                    WorkflowStepId = table.Column<int>(type: "int", nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowInstanceHistoryList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowInstanceHistoryList_UsersList_ActionBy",
                        column: x => x.ActionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowInstanceHistoryList_WorkflowInstanceList_WorkflowInstanceId",
                        column: x => x.WorkflowInstanceId,
                        principalTable: "WorkflowInstanceList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowInstanceHistoryList_WorkflowStepList_WorkflowStepId",
                        column: x => x.WorkflowStepId,
                        principalTable: "WorkflowStepList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowStepAssigneeList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkflowStepId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowStepAssigneeList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowStepAssigneeList_UsersList_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowStepAssigneeList_WorkflowStepList_WorkflowStepId",
                        column: x => x.WorkflowStepId,
                        principalTable: "WorkflowStepList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DailyReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Weather = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperature = table.Column<int>(type: "int", nullable: true),
                    Shift = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    CreatedId = table.Column<int>(type: "int", nullable: true),
                    UpdateId = table.Column<int>(type: "int", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    PrjId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyReport_ProjectsList_PrjId",
                        column: x => x.PrjId,
                        principalTable: "ProjectsList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReport_UsersList_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReport_UsersList_DeletionId",
                        column: x => x.DeletionId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReport_UsersList_UpdateId",
                        column: x => x.UpdateId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    PrjId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleList_ProjectsList_PrjId",
                        column: x => x.PrjId,
                        principalTable: "ProjectsList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleList_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleList_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleList_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequestDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRId = table.Column<int>(type: "int", nullable: true),
                    PrjId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    CCId = table.Column<int>(type: "int", nullable: true),
                    BdgId = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierManufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortId = table.Column<int>(type: "int", nullable: true),
                    Num = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_PurchaseRequestDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestDetails_BudgetList_BdgId",
                        column: x => x.BdgId,
                        principalTable: "BudgetList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestDetails_CostCenterList_CCId",
                        column: x => x.CCId,
                        principalTable: "CostCenterList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestDetails_ItemsList_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ItemsList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestDetails_PurchaseRequestList_PRId",
                        column: x => x.PRId,
                        principalTable: "PurchaseRequestList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestDetails_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestDetails_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestDetails_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestDetails_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RFQDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFQId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortId = table.Column<int>(type: "int", nullable: true),
                    Num = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFQDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RFQDetails_ItemsList_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ItemsList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RFQDetails_RFQList_RFQId",
                        column: x => x.RFQId,
                        principalTable: "RFQList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RFQDetails_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowInstanceStepAssigneeList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkflowInstanceStepId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowInstanceStepAssigneeList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowInstanceStepAssigneeList_UsersList_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowInstanceStepAssigneeList_WorkflowInstanceStepList_WorkflowInstanceStepId",
                        column: x => x.WorkflowInstanceStepId,
                        principalTable: "WorkflowInstanceStepList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DailyReportDisruptedActivity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisruptionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Impact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    CreatedId = table.Column<int>(type: "int", nullable: true),
                    UpdateId = table.Column<int>(type: "int", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DailyReportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReportDisruptedActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyReportDisruptedActivity_DailyReport_DailyReportId",
                        column: x => x.DailyReportId,
                        principalTable: "DailyReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportDisruptedActivity_UsersList_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportDisruptedActivity_UsersList_DeletionId",
                        column: x => x.DeletionId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportDisruptedActivity_UsersList_UpdateId",
                        column: x => x.UpdateId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DailyReportEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    CreatedId = table.Column<int>(type: "int", nullable: true),
                    UpdateId = table.Column<int>(type: "int", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DailyReportId = table.Column<int>(type: "int", nullable: true),
                    EquipmentListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReportEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyReportEquipment_DailyReport_DailyReportId",
                        column: x => x.DailyReportId,
                        principalTable: "DailyReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportEquipment_EquipmentList_EquipmentListId",
                        column: x => x.EquipmentListId,
                        principalTable: "EquipmentList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportEquipment_UsersList_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportEquipment_UsersList_DeletionId",
                        column: x => x.DeletionId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportEquipment_UsersList_UpdateId",
                        column: x => x.UpdateId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DailyReportInspection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    DailyReportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReportInspection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyReportInspection_DailyReport_DailyReportId",
                        column: x => x.DailyReportId,
                        principalTable: "DailyReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportInspection_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportInspection_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportInspection_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DailyReportIssue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recommendation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Importance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    CreatedId = table.Column<int>(type: "int", nullable: true),
                    UpdateId = table.Column<int>(type: "int", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DailyReportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReportIssue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyReportIssue_DailyReport_DailyReportId",
                        column: x => x.DailyReportId,
                        principalTable: "DailyReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportIssue_UsersList_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportIssue_UsersList_DeletionId",
                        column: x => x.DeletionId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportIssue_UsersList_UpdateId",
                        column: x => x.UpdateId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DailyReportManpower",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    CreatedId = table.Column<int>(type: "int", nullable: true),
                    UpdateId = table.Column<int>(type: "int", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DailyReportId = table.Column<int>(type: "int", nullable: true),
                    ManpowerListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReportManpower", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyReportManpower_DailyReport_DailyReportId",
                        column: x => x.DailyReportId,
                        principalTable: "DailyReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportManpower_ManpowerList_ManpowerListId",
                        column: x => x.ManpowerListId,
                        principalTable: "ManpowerList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportManpower_UsersList_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportManpower_UsersList_DeletionId",
                        column: x => x.DeletionId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportManpower_UsersList_UpdateId",
                        column: x => x.UpdateId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DailyReportMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    CreatedId = table.Column<int>(type: "int", nullable: true),
                    UpdateId = table.Column<int>(type: "int", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DailyReportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReportMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyReportMaterial_DailyReport_DailyReportId",
                        column: x => x.DailyReportId,
                        principalTable: "DailyReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportMaterial_UsersList_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportMaterial_UsersList_DeletionId",
                        column: x => x.DeletionId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportMaterial_UsersList_UpdateId",
                        column: x => x.UpdateId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DailyReportPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    DailyReportId = table.Column<int>(type: "int", nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReportPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyReportPhoto_DailyReport_DailyReportId",
                        column: x => x.DailyReportId,
                        principalTable: "DailyReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportPhoto_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportPhoto_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportPhoto_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DailyReportWorkPlanned",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    CreatedId = table.Column<int>(type: "int", nullable: true),
                    UpdateId = table.Column<int>(type: "int", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DailyReportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReportWorkPlanned", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyReportWorkPlanned_DailyReport_DailyReportId",
                        column: x => x.DailyReportId,
                        principalTable: "DailyReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportWorkPlanned_UsersList_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportWorkPlanned_UsersList_DeletionId",
                        column: x => x.DeletionId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportWorkPlanned_UsersList_UpdateId",
                        column: x => x.UpdateId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdParent = table.Column<int>(type: "int", nullable: false),
                    IdCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActuaStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    PrjId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleDetails_ProjectsList_PrjId",
                        column: x => x.PrjId,
                        principalTable: "ProjectsList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleDetails_ScheduleList_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "ScheduleList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleDetails_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleDetails_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleDetails_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRRFQLineLink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRLineId = table.Column<int>(type: "int", nullable: true),
                    RFQDetailId = table.Column<int>(type: "int", nullable: true),
                    LinkedQuantity = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRRFQLineLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRRFQLineLink_PurchaseRequestDetails_PRLineId",
                        column: x => x.PRLineId,
                        principalTable: "PurchaseRequestDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRRFQLineLink_RFQDetails_RFQDetailId",
                        column: x => x.RFQDetailId,
                        principalTable: "RFQDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    ScheduleActivityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityList_ScheduleDetails_ScheduleActivityId",
                        column: x => x.ScheduleActivityId,
                        principalTable: "ScheduleDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityList_UsersList_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityList_UsersList_DeletionBy",
                        column: x => x.DeletionBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityList_UsersList_UpdateBy",
                        column: x => x.UpdateBy,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DailyReportWorkDone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletionBy = table.Column<int>(type: "int", nullable: false),
                    CreatedId = table.Column<int>(type: "int", nullable: true),
                    UpdateId = table.Column<int>(type: "int", nullable: true),
                    DeletionId = table.Column<int>(type: "int", nullable: true),
                    DailyReportId = table.Column<int>(type: "int", nullable: true),
                    ActivityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReportWorkDone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyReportWorkDone_ActivityList_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "ActivityList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportWorkDone_DailyReport_DailyReportId",
                        column: x => x.DailyReportId,
                        principalTable: "DailyReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportWorkDone_UsersList_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportWorkDone_UsersList_DeletionId",
                        column: x => x.DeletionId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyReportWorkDone_UsersList_UpdateId",
                        column: x => x.UpdateId,
                        principalTable: "UsersList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityList_CreatedBy",
                table: "ActivityList",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityList_DeletionBy",
                table: "ActivityList",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityList_ScheduleActivityId",
                table: "ActivityList",
                column: "ScheduleActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityList_UpdateBy",
                table: "ActivityList",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalLimitList_MatrixId",
                table: "ApprovalLimitList",
                column: "MatrixId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalLimitList_WorkflowDefinitionId",
                table: "ApprovalLimitList",
                column: "WorkflowDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardRecommendationList_PriceQuotationRequestId",
                table: "AwardRecommendationList",
                column: "PriceQuotationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardRecommendationList_RFQId",
                table: "AwardRecommendationList",
                column: "RFQId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetList_CostCenterId",
                table: "BudgetList",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetList_CreatedBy",
                table: "BudgetList",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetList_DeletionBy",
                table: "BudgetList",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetList_UpdateBy",
                table: "BudgetList",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_CostCenterList_CreatedBy",
                table: "CostCenterList",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CostCenterList_DeletionBy",
                table: "CostCenterList",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_CostCenterList_UpdateBy",
                table: "CostCenterList",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReport_CreatedId",
                table: "DailyReport",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReport_DeletionId",
                table: "DailyReport",
                column: "DeletionId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReport_PrjId",
                table: "DailyReport",
                column: "PrjId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReport_UpdateId",
                table: "DailyReport",
                column: "UpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportDisruptedActivity_CreatedId",
                table: "DailyReportDisruptedActivity",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportDisruptedActivity_DailyReportId",
                table: "DailyReportDisruptedActivity",
                column: "DailyReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportDisruptedActivity_DeletionId",
                table: "DailyReportDisruptedActivity",
                column: "DeletionId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportDisruptedActivity_UpdateId",
                table: "DailyReportDisruptedActivity",
                column: "UpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportEquipment_CreatedId",
                table: "DailyReportEquipment",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportEquipment_DailyReportId",
                table: "DailyReportEquipment",
                column: "DailyReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportEquipment_DeletionId",
                table: "DailyReportEquipment",
                column: "DeletionId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportEquipment_EquipmentListId",
                table: "DailyReportEquipment",
                column: "EquipmentListId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportEquipment_UpdateId",
                table: "DailyReportEquipment",
                column: "UpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportInspection_CreatedBy",
                table: "DailyReportInspection",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportInspection_DailyReportId",
                table: "DailyReportInspection",
                column: "DailyReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportInspection_DeletionBy",
                table: "DailyReportInspection",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportInspection_UpdateBy",
                table: "DailyReportInspection",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportIssue_CreatedId",
                table: "DailyReportIssue",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportIssue_DailyReportId",
                table: "DailyReportIssue",
                column: "DailyReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportIssue_DeletionId",
                table: "DailyReportIssue",
                column: "DeletionId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportIssue_UpdateId",
                table: "DailyReportIssue",
                column: "UpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportManpower_CreatedId",
                table: "DailyReportManpower",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportManpower_DailyReportId",
                table: "DailyReportManpower",
                column: "DailyReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportManpower_DeletionId",
                table: "DailyReportManpower",
                column: "DeletionId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportManpower_ManpowerListId",
                table: "DailyReportManpower",
                column: "ManpowerListId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportManpower_UpdateId",
                table: "DailyReportManpower",
                column: "UpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportMaterial_CreatedId",
                table: "DailyReportMaterial",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportMaterial_DailyReportId",
                table: "DailyReportMaterial",
                column: "DailyReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportMaterial_DeletionId",
                table: "DailyReportMaterial",
                column: "DeletionId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportMaterial_UpdateId",
                table: "DailyReportMaterial",
                column: "UpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportPhoto_CreatedBy",
                table: "DailyReportPhoto",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportPhoto_DailyReportId",
                table: "DailyReportPhoto",
                column: "DailyReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportPhoto_DeletionBy",
                table: "DailyReportPhoto",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportPhoto_UpdateBy",
                table: "DailyReportPhoto",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportWorkDone_ActivityId",
                table: "DailyReportWorkDone",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportWorkDone_CreatedId",
                table: "DailyReportWorkDone",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportWorkDone_DailyReportId",
                table: "DailyReportWorkDone",
                column: "DailyReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportWorkDone_DeletionId",
                table: "DailyReportWorkDone",
                column: "DeletionId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportWorkDone_UpdateId",
                table: "DailyReportWorkDone",
                column: "UpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportWorkPlanned_CreatedId",
                table: "DailyReportWorkPlanned",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportWorkPlanned_DailyReportId",
                table: "DailyReportWorkPlanned",
                column: "DailyReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportWorkPlanned_DeletionId",
                table: "DailyReportWorkPlanned",
                column: "DeletionId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportWorkPlanned_UpdateId",
                table: "DailyReportWorkPlanned",
                column: "UpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsList_CreatedBy",
                table: "DepartmentsList",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsList_DeletionBy",
                table: "DepartmentsList",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsList_UpdateBy",
                table: "DepartmentsList",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinesList_CreatedBy",
                table: "DisciplinesList",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinesList_DeletionBy",
                table: "DisciplinesList",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinesList_UpdateBy",
                table: "DisciplinesList",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentList_CreatedBy",
                table: "EquipmentList",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentList_DeletionBy",
                table: "EquipmentList",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentList_UpdateBy",
                table: "EquipmentList",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategory_CreatedBy",
                table: "ItemCategory",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategory_DeletionBy",
                table: "ItemCategory",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategory_UpdateBy",
                table: "ItemCategory",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsList_CategoryId",
                table: "ItemsList",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsList_CreatedBy",
                table: "ItemsList",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsList_DeletionBy",
                table: "ItemsList",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsList_UnitId",
                table: "ItemsList",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsList_UpdateBy",
                table: "ItemsList",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_ManpowerList_CreatedBy",
                table: "ManpowerList",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ManpowerList_DeletionBy",
                table: "ManpowerList",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_ManpowerList_UpdateBy",
                table: "ManpowerList",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialApprovalRequestDetails_CreatedBy",
                table: "MaterialApprovalRequestDetails",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialApprovalRequestDetails_DeletionBy",
                table: "MaterialApprovalRequestDetails",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialApprovalRequestDetails_UpdateBy",
                table: "MaterialApprovalRequestDetails",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialApprovalRequestList_CreatedBy",
                table: "MaterialApprovalRequestList",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialApprovalRequestList_DeletionBy",
                table: "MaterialApprovalRequestList",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialApprovalRequestList_UpdateBy",
                table: "MaterialApprovalRequestList",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_NegotiationList_PriceQuotationRequestId",
                table: "NegotiationList",
                column: "PriceQuotationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_POAmendmentDetails_ParentId",
                table: "POAmendmentDetails",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_POAmendmentDetails_POLineId",
                table: "POAmendmentDetails",
                column: "POLineId");

            migrationBuilder.CreateIndex(
                name: "IX_POAmendmentList_POId",
                table: "POAmendmentList",
                column: "POId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsList_CLId",
                table: "ProjectsList",
                column: "CLId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsList_CreatedBy",
                table: "ProjectsList",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsList_CSTId",
                table: "ProjectsList",
                column: "CSTId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsList_DeletionBy",
                table: "ProjectsList",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsList_UpdateBy",
                table: "ProjectsList",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_PRRFQLineLink_PRLineId",
                table: "PRRFQLineLink",
                column: "PRLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PRRFQLineLink_RFQDetailId",
                table: "PRRFQLineLink",
                column: "RFQDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestDetails_BdgId",
                table: "PurchaseRequestDetails",
                column: "BdgId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestDetails_CCId",
                table: "PurchaseRequestDetails",
                column: "CCId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestDetails_CreatedBy",
                table: "PurchaseRequestDetails",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestDetails_DeletionBy",
                table: "PurchaseRequestDetails",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestDetails_ItemId",
                table: "PurchaseRequestDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestDetails_PRId",
                table: "PurchaseRequestDetails",
                column: "PRId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestDetails_UnitId",
                table: "PurchaseRequestDetails",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestDetails_UpdateBy",
                table: "PurchaseRequestDetails",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestList_CreatedBy",
                table: "PurchaseRequestList",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestList_DeletionBy",
                table: "PurchaseRequestList",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestList_UpdateBy",
                table: "PurchaseRequestList",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_RFQDetails_ItemId",
                table: "RFQDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RFQDetails_RFQId",
                table: "RFQDetails",
                column: "RFQId");

            migrationBuilder.CreateIndex(
                name: "IX_RFQDetails_UnitId",
                table: "RFQDetails",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_RFQVendorList_RFQId",
                table: "RFQVendorList",
                column: "RFQId");

            migrationBuilder.CreateIndex(
                name: "IX_RFQVendorList_StakeholderId",
                table: "RFQVendorList",
                column: "StakeholderId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDetails_CreatedBy",
                table: "ScheduleDetails",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDetails_DeletionBy",
                table: "ScheduleDetails",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDetails_PrjId",
                table: "ScheduleDetails",
                column: "PrjId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDetails_ScheduleId",
                table: "ScheduleDetails",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDetails_UpdateBy",
                table: "ScheduleDetails",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleList_CreatedBy",
                table: "ScheduleList",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleList_DeletionBy",
                table: "ScheduleList",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleList_PrjId",
                table: "ScheduleList",
                column: "PrjId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleList_UpdateBy",
                table: "ScheduleList",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_StakeholdersList_CategoryId",
                table: "StakeholdersList",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StakeholdersList_CreatedBy",
                table: "StakeholdersList",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_StakeholdersList_DeletionBy",
                table: "StakeholdersList",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_StakeholdersList_UpdateBy",
                table: "StakeholdersList",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_StoreList_CreatedBy",
                table: "StoreList",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_StoreList_DeletionBy",
                table: "StoreList",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_StoreList_UpdateBy",
                table: "StoreList",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittalCategory_CreatedBy",
                table: "SubmittalCategory",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittalCategory_DeletionBy",
                table: "SubmittalCategory",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittalCategory_UpdateBy",
                table: "SubmittalCategory",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittalStatus_CreatedBy",
                table: "SubmittalStatus",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittalStatus_DeletionBy",
                table: "SubmittalStatus",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittalStatus_UpdateBy",
                table: "SubmittalStatus",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittalSubCategory_CreatedBy",
                table: "SubmittalSubCategory",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittalSubCategory_DeletionBy",
                table: "SubmittalSubCategory",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittalSubCategory_UpdateBy",
                table: "SubmittalSubCategory",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalEvaluationDetails_ParentId",
                table: "TechnicalEvaluationDetails",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalEvaluationDetails_PriceQuotationRequestDetailId",
                table: "TechnicalEvaluationDetails",
                column: "PriceQuotationRequestDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalEvaluationList_EvaluatedBy",
                table: "TechnicalEvaluationList",
                column: "EvaluatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalEvaluationList_PriceQuotationRequestId",
                table: "TechnicalEvaluationList",
                column: "PriceQuotationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_CreatedBy",
                table: "Units",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Units_DeletionBy",
                table: "Units",
                column: "DeletionBy");

            migrationBuilder.CreateIndex(
                name: "IX_Units_UpdateBy",
                table: "Units",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissionStatus_UpdateBy",
                table: "UserPermissionStatus",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjectAccess_UpdateBy",
                table: "UserProjectAccess",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserStoreAccess_UpdateBy",
                table: "UserStoreAccess",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkflowAccess_UpdateBy",
                table: "UserWorkflowAccess",
                column: "UpdateBy");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowDefinitionDisciplineList_DisciplineId",
                table: "WorkflowDefinitionDisciplineList",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowDefinitionDisciplineList_WorkflowDefinitionId",
                table: "WorkflowDefinitionDisciplineList",
                column: "WorkflowDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstanceHistoryList_ActionBy",
                table: "WorkflowInstanceHistoryList",
                column: "ActionBy");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstanceHistoryList_WorkflowInstanceId",
                table: "WorkflowInstanceHistoryList",
                column: "WorkflowInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstanceHistoryList_WorkflowStepId",
                table: "WorkflowInstanceHistoryList",
                column: "WorkflowStepId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstanceList_StartedBy",
                table: "WorkflowInstanceList",
                column: "StartedBy");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstanceList_WorkflowDefinitionId",
                table: "WorkflowInstanceList",
                column: "WorkflowDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstanceStepAssigneeList_UserId",
                table: "WorkflowInstanceStepAssigneeList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstanceStepAssigneeList_WorkflowInstanceStepId",
                table: "WorkflowInstanceStepAssigneeList",
                column: "WorkflowInstanceStepId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstanceStepList_WorkflowInstanceId",
                table: "WorkflowInstanceStepList",
                column: "WorkflowInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowStepAssigneeList_UserId",
                table: "WorkflowStepAssigneeList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowStepAssigneeList_WorkflowStepId",
                table: "WorkflowStepAssigneeList",
                column: "WorkflowStepId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowStepList_WorkflowDefinitionId",
                table: "WorkflowStepList",
                column: "WorkflowDefinitionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionLogs");

            migrationBuilder.DropTable(
                name: "ApprovalLimitList");

            migrationBuilder.DropTable(
                name: "AttachmentList");

            migrationBuilder.DropTable(
                name: "AuditLog");

            migrationBuilder.DropTable(
                name: "AwardRecommendationList");

            migrationBuilder.DropTable(
                name: "DailyReportDisruptedActivity");

            migrationBuilder.DropTable(
                name: "DailyReportEquipment");

            migrationBuilder.DropTable(
                name: "DailyReportInspection");

            migrationBuilder.DropTable(
                name: "DailyReportIssue");

            migrationBuilder.DropTable(
                name: "DailyReportManpower");

            migrationBuilder.DropTable(
                name: "DailyReportMaterial");

            migrationBuilder.DropTable(
                name: "DailyReportPhoto");

            migrationBuilder.DropTable(
                name: "DailyReportWorkDone");

            migrationBuilder.DropTable(
                name: "DailyReportWorkPlanned");

            migrationBuilder.DropTable(
                name: "DepartmentsList");

            migrationBuilder.DropTable(
                name: "DrawingAttachment");

            migrationBuilder.DropTable(
                name: "DrawingsCategory");

            migrationBuilder.DropTable(
                name: "DrawingsIssuerList");

            migrationBuilder.DropTable(
                name: "DrawingsRegisterDetails");

            migrationBuilder.DropTable(
                name: "DrawingsRegisterList");

            migrationBuilder.DropTable(
                name: "DrawingsStatus");

            migrationBuilder.DropTable(
                name: "DrawingsSubCategory");

            migrationBuilder.DropTable(
                name: "DrawingsSubmittalList");

            migrationBuilder.DropTable(
                name: "DrawingsType");

            migrationBuilder.DropTable(
                name: "MaterialApprovalRequestDetails");

            migrationBuilder.DropTable(
                name: "MaterialApprovalRequestList");

            migrationBuilder.DropTable(
                name: "MaterialIssuedDetails");

            migrationBuilder.DropTable(
                name: "MaterialIssuedList");

            migrationBuilder.DropTable(
                name: "MaterialIssueReturnDetails");

            migrationBuilder.DropTable(
                name: "MaterialIssueReturnList");

            migrationBuilder.DropTable(
                name: "MaterialReceiveDetails");

            migrationBuilder.DropTable(
                name: "MaterialReceiveList");

            migrationBuilder.DropTable(
                name: "MaterialTransferDetails");

            migrationBuilder.DropTable(
                name: "MaterialTransferList");

            migrationBuilder.DropTable(
                name: "NegotiationList");

            migrationBuilder.DropTable(
                name: "NumberSeriesCounter");

            migrationBuilder.DropTable(
                name: "OpeningBalanceDetails");

            migrationBuilder.DropTable(
                name: "OpeningBalanceList");

            migrationBuilder.DropTable(
                name: "PermissionsList");

            migrationBuilder.DropTable(
                name: "POAmendmentDetails");

            migrationBuilder.DropTable(
                name: "PriceQuotationCompareDetails");

            migrationBuilder.DropTable(
                name: "PriceQuotationCompareList");

            migrationBuilder.DropTable(
                name: "PriceQuotationList");

            migrationBuilder.DropTable(
                name: "PRRFQLineLink");

            migrationBuilder.DropTable(
                name: "PurchaseReturnDetails");

            migrationBuilder.DropTable(
                name: "PurchaseReturnList");

            migrationBuilder.DropTable(
                name: "RFQVendorList");

            migrationBuilder.DropTable(
                name: "StockingDetails");

            migrationBuilder.DropTable(
                name: "StockingList");

            migrationBuilder.DropTable(
                name: "StoreList");

            migrationBuilder.DropTable(
                name: "SubmittalCategory");

            migrationBuilder.DropTable(
                name: "SubmittalStatus");

            migrationBuilder.DropTable(
                name: "SubmittalSubCategory");

            migrationBuilder.DropTable(
                name: "SystemSettings");

            migrationBuilder.DropTable(
                name: "TechnicalEvaluationDetails");

            migrationBuilder.DropTable(
                name: "UserPermissionStatus");

            migrationBuilder.DropTable(
                name: "UserProjectAccess");

            migrationBuilder.DropTable(
                name: "UsersRole");

            migrationBuilder.DropTable(
                name: "UserStoreAccess");

            migrationBuilder.DropTable(
                name: "UserWorkflowAccess");

            migrationBuilder.DropTable(
                name: "WorkflowDefinitionDisciplineList");

            migrationBuilder.DropTable(
                name: "WorkflowInstanceHistoryList");

            migrationBuilder.DropTable(
                name: "WorkflowInstanceStepAssigneeList");

            migrationBuilder.DropTable(
                name: "WorkflowStepAssigneeList");

            migrationBuilder.DropTable(
                name: "ApprovalMatrixList");

            migrationBuilder.DropTable(
                name: "EquipmentList");

            migrationBuilder.DropTable(
                name: "ManpowerList");

            migrationBuilder.DropTable(
                name: "ActivityList");

            migrationBuilder.DropTable(
                name: "DailyReport");

            migrationBuilder.DropTable(
                name: "POAmendmentList");

            migrationBuilder.DropTable(
                name: "PurchaseOrderDetails");

            migrationBuilder.DropTable(
                name: "PurchaseRequestDetails");

            migrationBuilder.DropTable(
                name: "RFQDetails");

            migrationBuilder.DropTable(
                name: "PriceQuotationRequestDetails");

            migrationBuilder.DropTable(
                name: "TechnicalEvaluationList");

            migrationBuilder.DropTable(
                name: "DisciplinesList");

            migrationBuilder.DropTable(
                name: "WorkflowInstanceStepList");

            migrationBuilder.DropTable(
                name: "WorkflowStepList");

            migrationBuilder.DropTable(
                name: "ScheduleDetails");

            migrationBuilder.DropTable(
                name: "PurchaseOrderList");

            migrationBuilder.DropTable(
                name: "BudgetList");

            migrationBuilder.DropTable(
                name: "PurchaseRequestList");

            migrationBuilder.DropTable(
                name: "ItemsList");

            migrationBuilder.DropTable(
                name: "RFQList");

            migrationBuilder.DropTable(
                name: "PriceQuotationRequestList");

            migrationBuilder.DropTable(
                name: "WorkflowInstanceList");

            migrationBuilder.DropTable(
                name: "ScheduleList");

            migrationBuilder.DropTable(
                name: "CostCenterList");

            migrationBuilder.DropTable(
                name: "ItemCategory");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "WorkflowDefinitionList");

            migrationBuilder.DropTable(
                name: "ProjectsList");

            migrationBuilder.DropTable(
                name: "StakeholdersList");

            migrationBuilder.DropTable(
                name: "StakeholdersCategory");

            migrationBuilder.DropTable(
                name: "UsersList");
        }
    }
}
