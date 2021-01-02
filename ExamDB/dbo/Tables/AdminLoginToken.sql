CREATE TABLE [dbo].[AdminLoginToken] (
    [AdminLoginTokenId] INT          IDENTITY (1, 1) NOT NULL,
    [AdminLoginId]      INT          NOT NULL,
    [Token]             VARCHAR (50) NOT NULL,
    [LoginStartTime]    DATETIME     NOT NULL,
    [LoginEndTime]      DATETIME     NOT NULL
);

