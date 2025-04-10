CREATE TABLE [dbo].[JobApplications] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [JobTitle]        NVARCHAR (150) NOT NULL,
    [CompanyId]       INT            NOT NULL,
    [JobLink]         NVARCHAR (250) NULL,
    [Postion]         VARCHAR (50)   NULL,
    [JobDescription]  NVARCHAR (MAX) NULL,
    [SalaryRange]     NVARCHAR (50)  NULL,
    [JobStatus]       TINYINT        NULL,
    [ApplicationDate] DATETIME       NULL,
    [RejectionReason] NVARCHAR (500) NULL,
    [UserId]          INT            NOT NULL,
    CONSTRAINT [PK_JobApplications] PRIMARY KEY CLUSTERED ([Id] ASC)
);

