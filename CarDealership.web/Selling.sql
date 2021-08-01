USE [DB1]
GO

/****** Object:  Table [dbo].[Selling]    Script Date: 8/1/2021 10:26:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Selling](
	[Id] [int] NOT NULL,
	[CarId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[PurchaseDay] [date] NOT NULL,
 CONSTRAINT [PK_Selling] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Selling]  WITH CHECK ADD  CONSTRAINT [FK_Selling_Car] FOREIGN KEY([CarId])
REFERENCES [dbo].[Car] ([Id])
GO

ALTER TABLE [dbo].[Selling] CHECK CONSTRAINT [FK_Selling_Car]
GO

ALTER TABLE [dbo].[Selling]  WITH CHECK ADD  CONSTRAINT [FK_Selling_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO

ALTER TABLE [dbo].[Selling] CHECK CONSTRAINT [FK_Selling_Customer]
GO


