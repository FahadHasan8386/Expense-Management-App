CREATE TABLE ExpenseCategories (
	ExpenseCategoryId BIGINT IDENTITY(100,1) NOT NULL 
		CONSTRAINT PK_ExpenseCategories_ExpenseCategoryId PRIMARY KEY (ExpenseCategoryId),
	ExpenseCategoryName NVARCHAR (100) NOT NULL,
	Remarks NVARCHAR(255) NULL,
	CreatedBy NVARCHAR(50) NOT NULL,
	CreatedAt DATETIME NOT NULL
		CONSTRAINT DF_ExpenseCategories_CreatedAt DEFAULT GETDATE(),
	InActive BIT NOT NULL 
		CONSTRAINT DF_ExpenseCategories_InActive DEFAULT 0,
	ModifiedBy NVARCHAR(50) NULL,
	ModifiedAt DATETIME NULL
)