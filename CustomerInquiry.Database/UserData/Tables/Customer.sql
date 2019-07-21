CREATE TABLE [UserData].[Customer]
(
	[CustomerId] BIGINT NOT NULL identity(1,1) PRIMARY KEY,
	[CustomerName] NVARCHAR(30) NOT NULL,
	[ContactEmail] NVARCHAR(25) NOT NULL,
	[MobileNumber] BIGINT NOT NULL,

	CONSTRAINT UC_Customer UNIQUE ([ContactEmail])
)
