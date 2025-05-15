CREATE TABLE [dbo].[GSB.BI] (
    [RegisterUID]                   UNIQUEIDENTIFIER NOT NULL,    
    [DataCoordinatorId]             UNIQUEIDENTIFIER NOT NULL,
    [ReceiveDate]                   DATETIME2 (7)    NOT NULL,    
    [MessageUID]                    UNIQUEIDENTIFIER NOT NULL,
    [InsurerCoded_string]           INT              NOT NULL,
    [PolicyUnqiueCode]              NVARCHAR (36)    NOT NULL,
    [PolicyType]                    NVARCHAR (50)    NOT NULL,
    [ProvinceBranchCoded_string]    NVARCHAR (10)    NOT NULL,
    [InsuredType]                   INT              NOT NULL,
    [RelationTypeValue]             NVARCHAR (200)   NOT NULL,
    [RelationTypeCoded_string]      NVARCHAR (50)    NOT NULL,
    [ResponsibleGenderValue]        NVARCHAR (200)   NOT NULL,
    [ResponsibleGenderCoded_string] NVARCHAR (50)    NOT NULL,
    [InsuranceExpirationDate]       DATETIME2 (7)    NOT NULL,
    [InsurerType]                   TINYINT          NOT NULL,
    [IsCoverageUnlimited]           TINYINT          NOT NULL,
    [PersonIdType]                  NVARCHAR (50)    NOT NULL,
    [BirthDate]                     DATETIME2 (7)    NOT NULL,
    [MaritalStatusCoded_string]     NVARCHAR (20)    NOT NULL,
    [NationalityValue]              NVARCHAR (50)    NULL,
    [NationalCode]                  NVARCHAR (36)    NOT NULL,
    [RegisterIDStatus]              TINYINT          NOT NULL,
    [RegisterDate]                  DATETIME2 (7)    NULL,
    [CreatedDate] DATETIME2 NOT NULL DEFAULT GETDATE(), 
    PRIMARY KEY CLUSTERED ([RegisterUID] ASC)
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_unique_DataCoordinatorId]
    ON [dbo].[GSB.BI]([DataCoordinatorId] ASC);
