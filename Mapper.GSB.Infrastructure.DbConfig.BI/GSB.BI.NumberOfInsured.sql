CREATE TABLE [dbo].[GSB.BI.NumberOfInsured] (
    [Id]                                    BIGINT        IDENTITY (1, 1) NOT NULL,
    [PolicyUnqiueCode]                      NVARCHAR (36) NOT NULL,
    [InsurerCoded_string]                   INT           NOT NULL,
    [ProvinceBranchCoded_string]            NVARCHAR(10)     NOT NULL,
    [NumberOfRegisterUIDInPolicyUnqiueCode] INT           NOT NULL,
    [ClassType]                             SMALLINT      NOT NULL,
    [CreatedDate] DATETIME2 NOT NULL DEFAULT GETDATE(), 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [[IX_Unique_PolicyUniqueCode_InsurerCoded]
    ON [dbo].[GSB.BI.NumberOfInsured]([PolicyUnqiueCode] ASC, [InsurerCoded_string] ASC);

