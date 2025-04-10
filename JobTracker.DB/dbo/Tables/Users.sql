CREATE TABLE [dbo].[Users] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [FName]    VARCHAR (50)   NOT NULL,
    [LName]    VARCHAR (50)   NOT NULL,
    [Email]    VARCHAR (50)   NOT NULL,
    [Password] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

