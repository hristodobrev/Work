CREATE TABLE [dbo].[users] (
    [id]            INT              IDENTITY (1, 1) NOT NULL,
    [username]      VARCHAR (50)     NOT NULL,
    [password_hash] BINARY (64)      NOT NULL,
    [salt]          UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_users_id] PRIMARY KEY CLUSTERED ([id] ASC)
);

