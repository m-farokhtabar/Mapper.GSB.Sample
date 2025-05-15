CREATE TABLE [dbo].[GSB.BI.BirthDateRange] (
    [Id]                                    BIGINT        IDENTITY (1, 1) NOT NULL,
    [PolicyUnqiueCode]                      NVARCHAR (36) NOT NULL,
    [InsurerCoded_string]                   INT           NOT NULL,
    [ProvinceBranchCoded_string]            NVARCHAR(10)     NOT NULL,    
    [From0To2]                              INT      NOT NULL DEFAULT 0,
    [From2To10]                             INT     NOT NULL DEFAULT 0,
    [From10To20]                            INT     NOT NULL DEFAULT 0,
    [From20To40]                            INT     NOT NULL DEFAULT 0,
    [From40To60]                            INT     NOT NULL DEFAULT 0,
    [From60To70]                            INT     NOT NULL DEFAULT 0,
    [More70]                             INT     NOT NULL,
    [CreatedDate] DATETIME2 NOT NULL DEFAULT GETDATE(), 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [[IX_Unique_PolicyUniqueCode_InsurerCoded]
    ON [dbo].[GSB.BI.BirthDateRange]([PolicyUnqiueCode] ASC, [InsurerCoded_string] ASC);

