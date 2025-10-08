CREATE TABLE Deposits (
	DepositId BIGINT IDENTITY(100,1) NOT NULL 
		CONSTRAINT PK_Deposits_DepositId PRIMARY KEY (DepositId),
	DepositAmount DECIMAL(18,3) NOT NULL 
		CONSTRAINT DF_Deposits_DepositAmount DEFAULT 0
		CONSTRAINT CK_Deposits_DepositAmount CHECK (DepositAmount >= 0),
	DepositDate DATE NOT NULL
		CONSTRAINT DF_Deposits_DepositDate DEFAULT GETDATE(),
	Remarks NVARCHAR(255) NULL,
	CreatedBy NVARCHAR(50) NOT NULL,
	CreatedAt DATETIME NOT NULL
		CONSTRAINT DF_Deposits_CreatedAt DEFAULT GETDATE(),
	InActive BIT NOT NULL 
		CONSTRAINT DF_Deposits_InActive DEFAULT 0,
	ModifiedBy NVARCHAR(50) NULL,
	ModifiedAt DATETIME NULL
)