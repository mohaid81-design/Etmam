-- Creates the two new tables backing frmPriceQuotationAddEdit (outbound "طلب عرض سعر" / RFQ).
-- Run this against whichever database DBSetting currently points to (Local or Cloud) before using the form.
-- Column names/types mirror Core/Tables/PriceQuotationRequestList.cs and PriceQuotationRequestDetails.cs exactly
-- (SqlDataHelper<T> maps by property name, so names must match verbatim).

IF OBJECT_ID('dbo.PriceQuotationRequestList', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.PriceQuotationRequestList
    (
        Id                       INT IDENTITY(1,1) PRIMARY KEY,
        Num                      INT NULL,
        PrjId                    INT NULL,
        StoreId                  INT NULL,
        StakeholderId            INT NULL,
        PRId                     INT NULL,
        RequestDate              DATETIME NULL,
        RequiredDate             DATETIME NULL,
        Purpose                  NVARCHAR(500) NULL,
        Priority                 NVARCHAR(50) NULL,
        RequestType              NVARCHAR(50) NULL,

        PaymentTerms             NVARCHAR(50) NULL,
        ExecutionDuration        DECIMAL(18,2) NULL,
        ExecutionDurationUnit    NVARCHAR(20) NULL,
        WarrantyDuration         DECIMAL(18,2) NULL,
        WarrantyDurationUnit     NVARCHAR(20) NULL,
        QuotationValidityPeriod  DECIMAL(18,2) NULL,
        QuotationValidityUnit    NVARCHAR(20) NULL,
        DailyPenaltyRate         DECIMAL(18,2) NULL,
        DailyPenaltyMaxPercent   DECIMAL(18,2) NULL,
        PerformanceBondPercent   DECIMAL(18,2) NULL,
        OtherConditions          NVARCHAR(MAX) NULL,

        Amount                   DECIMAL(18,2) NULL,
        Note                     NVARCHAR(500) NULL,

        CreatedDate              DATETIME NULL,
        CreatedMachine           NVARCHAR(100) NULL,
        CreatedBy                INT NOT NULL DEFAULT 0,
        UpdateDate               DATETIME NULL,
        UpdateMachine            NVARCHAR(100) NULL,
        UpdateBy                 INT NOT NULL DEFAULT 0,
        IsDelete                 BIT NOT NULL DEFAULT 0,
        DeletionDate             DATETIME NULL,
        DeletionMachine          NVARCHAR(100) NULL,
        DeletionBy               INT NOT NULL DEFAULT 0
    );
END
GO

IF OBJECT_ID('dbo.PriceQuotationRequestDetails', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.PriceQuotationRequestDetails
    (
        Id               INT IDENTITY(1,1) PRIMARY KEY,
        ParentId         INT NULL,
        PRDetailsId      INT NULL,
        ItemId           INT NULL,
        Description      NVARCHAR(500) NULL,
        Qty              DECIMAL(18,2) NULL,
        UnitId           INT NULL,
        UnitPrice        DECIMAL(18,2) NULL,
        DiscountPercent  DECIMAL(18,2) NULL,
        TaxPercent       DECIMAL(18,2) NULL,
        TotalPrice       DECIMAL(18,2) NULL,
        Note             NVARCHAR(500) NULL,

        CreatedDate      DATETIME NULL,
        CreatedMachine   NVARCHAR(100) NULL,
        CreatedBy        INT NOT NULL DEFAULT 0,
        UpdateDate       DATETIME NULL,
        UpdateMachine    NVARCHAR(100) NULL,
        UpdateBy         INT NOT NULL DEFAULT 0,
        IsDelete         BIT NOT NULL DEFAULT 0,
        DeletionDate     DATETIME NULL,
        DeletionMachine  NVARCHAR(100) NULL,
        DeletionBy       INT NOT NULL DEFAULT 0
    );
END
GO
