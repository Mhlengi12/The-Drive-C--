CREATE TABLE [dbo].[Account] (
    [Account_number]      NVARCHAR(50)           NOT NULL,
    [Client_ID]           INT           NULL,
    [Payment_method]      NCHAR (10)    NULL,
    [Total_cost]          NVARCHAR(50)         NULL,
    [Bank_name]           NVARCHAR (50) NULL,
    [Monthly_installment] NVARCHAR(50)         NULL,
    [Credit_score]        NCHAR (10)    NULL,
    PRIMARY KEY CLUSTERED ([Account_number] ASC)
);

