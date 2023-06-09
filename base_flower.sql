USE [flowers]
GO
/****** Object:  Table [dbo].[address]    Script Date: 10.04.2023 22:46:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[address](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NOT NULL,
	[street] [nvarchar](100) NOT NULL,
	[house] [int] NOT NULL,
	[room] [int] NOT NULL,
	[porch] [nvarchar](100) NOT NULL,
	[floor] [int] NOT NULL,
 CONSTRAINT [PK_address] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 10.04.2023 22:46:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[src] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[items]    Script Date: 10.04.2023 22:46:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[items](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[src] [nvarchar](max) NOT NULL,
	[price] [int] NOT NULL,
	[id_categories] [int] NOT NULL,
 CONSTRAINT [PK_items] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[items_order]    Script Date: 10.04.2023 22:46:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[items_order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_items] [int] NOT NULL,
	[id_orders] [int] NOT NULL,
 CONSTRAINT [PK_items_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order]    Script Date: 10.04.2023 22:46:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NOT NULL,
	[id_order] [int] NOT NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 10.04.2023 22:46:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[login] [nvarchar](100) NOT NULL,
	[password] [nvarchar](100) NOT NULL,
	[first_name] [nvarchar](100) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[last_name] [nvarchar](100) NOT NULL,
	[phone] [nvarchar](100) NOT NULL,
	[date_of_birth] [date] NOT NULL,
	[gender] [int] NOT NULL,
	[roll] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[address] ON 

INSERT [dbo].[address] ([id], [id_user], [street], [house], [room], [porch], [floor]) VALUES (1, 4, N'hdfgdfg', 435, 44, N'57', 3)
SET IDENTITY_INSERT [dbo].[address] OFF
GO
SET IDENTITY_INSERT [dbo].[categories] ON 

INSERT [dbo].[categories] ([id], [name], [src]) VALUES (1, N'Полевые букеты', N'полевые_превью.png')
INSERT [dbo].[categories] ([id], [name], [src]) VALUES (2, N'Букеты на заказ', N'на_заказ_превью.png')
INSERT [dbo].[categories] ([id], [name], [src]) VALUES (3, N'Авторские букеты', N'авторские_превью.png')
INSERT [dbo].[categories] ([id], [name], [src]) VALUES (4, N'Полевые цветы', N'полевые_цветы_превью.png')
INSERT [dbo].[categories] ([id], [name], [src]) VALUES (6, N'Декоративные букеты', N'декоративные_превью.png')
INSERT [dbo].[categories] ([id], [name], [src]) VALUES (7, N'Комнатные цветы', N'комнатные_превью.png')
INSERT [dbo].[categories] ([id], [name], [src]) VALUES (8, N'Свежесрезанные цветы', N'свежесрезанные_превью.png')
SET IDENTITY_INSERT [dbo].[categories] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([id], [login], [password], [first_name], [name], [last_name], [phone], [date_of_birth], [gender], [roll]) VALUES (2, N'vyborov', N'123123', N'Выборов', N'Лев', N'Сергеевич', N'8923472346', CAST(N'2002-12-12' AS Date), 1, N'1')
INSERT [dbo].[users] ([id], [login], [password], [first_name], [name], [last_name], [phone], [date_of_birth], [gender], [roll]) VALUES (4, N'test', N'123123', N'test', N'testeeeee', N'etsetset', N'6757567897', CAST(N'2023-04-21' AS Date), 1, N'0')
SET IDENTITY_INSERT [dbo].[users] OFF
GO
ALTER TABLE [dbo].[address]  WITH CHECK ADD  CONSTRAINT [FK_address_users] FOREIGN KEY([id_user])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[address] CHECK CONSTRAINT [FK_address_users]
GO
ALTER TABLE [dbo].[items]  WITH CHECK ADD  CONSTRAINT [FK_items_categories] FOREIGN KEY([id_categories])
REFERENCES [dbo].[categories] ([id])
GO
ALTER TABLE [dbo].[items] CHECK CONSTRAINT [FK_items_categories]
GO
ALTER TABLE [dbo].[items_order]  WITH CHECK ADD  CONSTRAINT [FK_items_order_items] FOREIGN KEY([id_items])
REFERENCES [dbo].[items] ([id])
GO
ALTER TABLE [dbo].[items_order] CHECK CONSTRAINT [FK_items_order_items]
GO
ALTER TABLE [dbo].[items_order]  WITH CHECK ADD  CONSTRAINT [FK_items_order_order] FOREIGN KEY([id_orders])
REFERENCES [dbo].[order] ([id])
GO
ALTER TABLE [dbo].[items_order] CHECK CONSTRAINT [FK_items_order_order]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_users] FOREIGN KEY([id_user])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_users]
GO
