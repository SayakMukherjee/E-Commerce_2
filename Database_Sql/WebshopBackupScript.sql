USE [WebshopDB]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 01/28/2017 10:29:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bill](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[DeliveryDate] [datetime] NOT NULL,
	[TotalBill] [int] NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Phone] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Bill] ON
INSERT [dbo].[Bill] ([ID], [ClientID], [Quantity], [OrderDate], [DeliveryDate], [TotalBill], [Address], [Phone]) VALUES (1, N'180534c0-20d5-4f48-981e-1d7d46f7ddfb', 2, CAST(0x0000A70900A995BB AS DateTime), CAST(0x0000A70E00A995BB AS DateTime), 24350, N'west bengal', CAST(9869877565 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Bill] OFF
/****** Object:  Table [dbo].[AdminTable]    Script Date: 01/28/2017 10:29:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdminTable](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GUID] [varchar](50) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AdminTable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AdminTable] ON
INSERT [dbo].[AdminTable] ([ID], [GUID], [Username], [Password], [FirstName], [LastName], [Email]) VALUES (1, N'dd42d7e044b44079a86ca6a9a1421988', N'Root', N'toor', N'Admin', N'Admin', N'admin@email.com')
SET IDENTITY_INSERT [dbo].[AdminTable] OFF
/****** Object:  Table [dbo].[UserInformation]    Script Date: 01/28/2017 10:29:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserInformation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GUID] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[PostalCode] [int] NOT NULL,
	[IsVerified] [bit] NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Phone] [decimal](18, 0) NOT NULL,
	[SecretAnswer] [varchar](50) NOT NULL,
 CONSTRAINT [PK_UserInformation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[UserInformation] ON
INSERT [dbo].[UserInformation] ([ID], [GUID], [FirstName], [LastName], [Username], [Password], [Address], [PostalCode], [IsVerified], [Email], [Phone], [SecretAnswer]) VALUES (1, N'180534c0-20d5-4f48-981e-1d7d46f7ddfb', N'Trial', N'User', N'trialUser', N'pass', N'west bengal', 700061, 1, N'abc@gmail.com', CAST(9869877565 AS Decimal(18, 0)), N'bangalore')
SET IDENTITY_INSERT [dbo].[UserInformation] OFF
/****** Object:  Table [dbo].[ProductType]    Script Date: 01/28/2017 10:29:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductType](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ProductType] ON
INSERT [dbo].[ProductType] ([CategoryID], [Name]) VALUES (1, N'Engine')
SET IDENTITY_INSERT [dbo].[ProductType] OFF
/****** Object:  Table [dbo].[Product]    Script Date: 01/28/2017 10:29:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ProductNumber] [int] NOT NULL,
	[ManufactureDate] [datetime] NOT NULL,
	[Price] [int] NOT NULL,
	[Stock] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Image] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON
INSERT [dbo].[Product] ([ID], [Name], [ProductNumber], [ManufactureDate], [Price], [Stock], [CategoryID], [Image]) VALUES (1, N'Cylinder Heads', 6598, CAST(0x0000A6E400000000 AS DateTime), 10000, 3, 1, N'Cylinder Heads.jpg')
SET IDENTITY_INSERT [dbo].[Product] OFF
/****** Object:  Table [dbo].[Order]    Script Date: 01/28/2017 10:29:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [varchar](50) NOT NULL,
	[ProductID] [int] NOT NULL,
	[OrderQuantity] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[IsInCart] [bit] NOT NULL,
	[BillID] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON
INSERT [dbo].[Order] ([ID], [ClientID], [ProductID], [OrderQuantity], [OrderDate], [IsInCart], [BillID]) VALUES (1, N'180534c0-20d5-4f48-981e-1d7d46f7ddfb', 1, 2, CAST(0x0000A70900A995C9 AS DateTime), 0, 1)
INSERT [dbo].[Order] ([ID], [ClientID], [ProductID], [OrderQuantity], [OrderDate], [IsInCart], [BillID]) VALUES (2, N'180534c0-20d5-4f48-981e-1d7d46f7ddfb', 1, 2, CAST(0x0000A70900A9F3D7 AS DateTime), 1, NULL)
SET IDENTITY_INSERT [dbo].[Order] OFF
/****** Object:  ForeignKey [FK_Product_ProductType]    Script Date: 01/28/2017 10:29:58 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[ProductType] ([CategoryID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductType]
GO
/****** Object:  ForeignKey [FK_Order_Bill]    Script Date: 01/28/2017 10:29:58 ******/
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Bill] FOREIGN KEY([BillID])
REFERENCES [dbo].[Bill] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Bill]
GO
/****** Object:  ForeignKey [FK_Order_Product]    Script Date: 01/28/2017 10:29:58 ******/
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Product]
GO
