CREATE TABLE Expenses (
	ExpenseId BIGINT IDENTITY(100,1) NOT NULL 
		CONSTRAINT PK_Expenses_ExpenseId PRIMARY KEY (ExpenseId),
	ExpenseCategoryId BIGINT NOT NULL
		CONSTRAINT FK_Expenses_ExpenseCategoryId FOREIGN KEY (ExpenseCategoryId)
			REFERENCES ExpenseCategories(ExpenseCategoryId),
	ExpenseAmount DECIMAL(18,3) NOT NULL	
		CONSTRAINT DF_Expenses_ExpenseAmount DEFAULT 0
		CONSTRAINT CK_Expenses_ExpenseAmount Check (ExpenseAmount >= 0),
	ExpenseDate DATE NOT NULL 
		CONSTRAINT DF_Expenses_ExpenseDate DEFAULT GETDATE(),
	PaymentMethod VARCHAR(15) NOT NULL,
	Remarks NVARCHAR(255) NULL,
	CreatedBy NVARCHAR(50) NOT NULL,
	CreatedAt DATETIME NOT NULL
		CONSTRAINT DF_Expenses_CreatedAt DEFAULT GETDATE(),
	InActive BIT NOT NULL 
		CONSTRAINT DF_Expenses_InActive DEFAULT 0,
	ModifiedBy NVARCHAR(50) NULL,
	ModifiedAt DATETIME NULL
)