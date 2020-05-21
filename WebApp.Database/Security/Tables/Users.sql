CREATE TABLE [Security].[Users] (
    [Id]          NVARCHAR (128) NOT NULL,
    [UserName]    VARCHAR (255)  NOT NULL,
    [Password]    VARCHAR (255)  NOT NULL,
    [Active]      BIT            DEFAULT ((1)) NULL,
    [CreatedDate] DATETIME       DEFAULT (getdate()) NULL,
    [CreatedBy]   VARCHAR (50)   NULL,
    [UpdatedDate] DATETIME       NULL,
    [UpdatedBy]   VARCHAR (50)   NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

