-- Tax Collection Tracker
-- Database Setup Script
-- Uses fictional taxpayer information only

-- Create the database if it doesn't exist
IF DB_ID('TaxCollectionDB') IS NULL
BEGIN
    CREATE DATABASE TaxCollectionDB;
END;
GO

USE TaxCollectionDB;
GO

-- Create the Taxpayers table
IF OBJECT_ID('dbo.Taxpayers', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Taxpayers
    (
        TaxpayerID INT IDENTITY(1,1) PRIMARY KEY,
        AccountNumber VARCHAR(20) NOT NULL UNIQUE,
        FirstName NVARCHAR(50) NOT NULL,
        LastName NVARCHAR(50) NOT NULL,
        Email NVARCHAR(100) NULL
    );
END;
GO

-- Create the TaxAccounts table
IF OBJECT_ID('dbo.TaxAccounts', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.TaxAccounts
    (
        TaxAccountID INT IDENTITY(1,1) PRIMARY KEY,
        TaxpayerID INT NOT NULL,

        OriginalAmount DECIMAL(10,2) NOT NULL,
        AmountPaid DECIMAL(10,2) NOT NULL DEFAULT 0,

        -- Automatically calculate remaining balance
        Balance AS (OriginalAmount - AmountPaid),

        CONSTRAINT FK_TaxAccounts_Taxpayers
            FOREIGN KEY (TaxpayerID)
            REFERENCES dbo.Taxpayers(TaxpayerID),

        CONSTRAINT CK_TaxAccounts_Amounts
            CHECK (OriginalAmount >= 0 AND AmountPaid >= 0)
    );
END;
GO

-- Create the Payments table
IF OBJECT_ID('dbo.Payments', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Payments
    (
        PaymentID INT IDENTITY(1,1) PRIMARY KEY,
        TaxAccountID INT NOT NULL,

        PaymentAmount DECIMAL(10,2) NOT NULL,

        PaymentDate DATETIME2 NOT NULL
            DEFAULT SYSDATETIME(),

        Notes NVARCHAR(200) NULL,

        CONSTRAINT FK_Payments_TaxAccounts
            FOREIGN KEY (TaxAccountID)
            REFERENCES dbo.TaxAccounts(TaxAccountID),

        CONSTRAINT CK_Payments_PositiveAmount
            CHECK (PaymentAmount > 0)
    );
END;
GO

-- Add fictional sample taxpayers
-- Skip existing account numbers

IF NOT EXISTS
(
    SELECT 1 FROM dbo.Taxpayers
    WHERE AccountNumber = '100001'
)
BEGIN
    INSERT INTO dbo.Taxpayers
        (AccountNumber, FirstName, LastName, Email)
    VALUES
        ('100001', 'John', 'Smith',
         'john.smith@example.com');
END;

IF NOT EXISTS
(
    SELECT 1 FROM dbo.Taxpayers
    WHERE AccountNumber = '100002'
)
BEGIN
    INSERT INTO dbo.Taxpayers
        (AccountNumber, FirstName, LastName, Email)
    VALUES
        ('100002', 'Jane', 'Johnson',
         'jane.johnson@example.com');
END;

IF NOT EXISTS
(
    SELECT 1 FROM dbo.Taxpayers
    WHERE AccountNumber = '100003'
)
BEGIN
    INSERT INTO dbo.Taxpayers
        (AccountNumber, FirstName, LastName, Email)
    VALUES
        ('100003', 'Michael', 'Brown',
         'michael.brown@example.com');
END;

IF NOT EXISTS
(
    SELECT 1 FROM dbo.Taxpayers
    WHERE AccountNumber = '100004'
)
BEGIN
    INSERT INTO dbo.Taxpayers
        (AccountNumber, FirstName, LastName, Email)
    VALUES
        ('100004', 'Sarah', 'Williams',
         'sarah.williams@example.com');
END;
GO

-- Give the sample taxpayer an initial tax balance
-- Starting paid amount is zero in a fresh installation

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.TaxAccounts a
    INNER JOIN dbo.Taxpayers t
        ON a.TaxpayerID = t.TaxpayerID
    WHERE t.AccountNumber = '100004'
)
BEGIN
    INSERT INTO dbo.TaxAccounts
        (TaxpayerID, OriginalAmount, AmountPaid)
    SELECT
        TaxpayerID,
        1500.00,
        0.00
    FROM dbo.Taxpayers
    WHERE AccountNumber = '100004';
END;
GO

-- Verify the sample taxpayers
SELECT *
FROM dbo.Taxpayers;

-- Verify the tax account balances
SELECT
    t.AccountNumber,
    t.FirstName,
    t.LastName,
    a.OriginalAmount,
    a.AmountPaid,
    a.Balance
FROM dbo.Taxpayers t
INNER JOIN dbo.TaxAccounts a
    ON t.TaxpayerID = a.TaxpayerID;
GO
