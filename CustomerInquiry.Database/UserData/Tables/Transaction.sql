CREATE TABLE [UserData].[Transaction]
(
	[TransactionId] INT NOT NULL PRIMARY KEY,
	[CustomerId] INT NOT NULL,
	[TransactionDate] DATETIME NOT NULL,
	[Amount] DECIMAL(16, 2) NOT NULL,
	[CurrencyCodeId] INT NOT NULL,
	[TransactionStatusId] INT NOT NULL,

	CONSTRAINT [FK_Transaction_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [UserData].[Customer]([CustomerId]),
	CONSTRAINT [FK_Transaction_CurrencyCode] FOREIGN KEY ([CurrencyCodeId]) REFERENCES [Installation].[CurrencyCode]([CurrencyCodeId]),
	CONSTRAINT [FK_Transaction_TransactionStatus] FOREIGN KEY ([TransactionStatusId]) REFERENCES [Installation].[TransactionStatus]([TransactionStatusId])
)
