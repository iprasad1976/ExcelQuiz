CREATE TABLE [dbo].[AdminLogin] (
    [AdminLoginId] INT            IDENTITY (1, 1) NOT NULL,
    [UserId]       NVARCHAR (20)  NOT NULL,
    [EmailId]      NVARCHAR (250) NOT NULL,
    [Password]     NVARCHAR (20)  NOT NULL,
    [IsActive]     CHAR (1)       NOT NULL
);

