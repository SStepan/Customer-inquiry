CREATE TABLE [UserData].[Transaction]
(
	[TransactionId] INT NOT NULL PRIMARY KEY,
	[CustomerId] INT NOT NULL,
	[TransactionDate] DATETIME,
	[Amount] DECIMAL(16, 2),

)
