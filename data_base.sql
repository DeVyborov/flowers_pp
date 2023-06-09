USE [flowers]
GO
/****** Object:  Table [dbo].[address]    Script Date: 15.04.2023 0:09:28 ******/
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
/****** Object:  Table [dbo].[categories]    Script Date: 15.04.2023 0:09:29 ******/
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
/****** Object:  Table [dbo].[items]    Script Date: 15.04.2023 0:09:29 ******/
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
/****** Object:  Table [dbo].[items_order]    Script Date: 15.04.2023 0:09:29 ******/
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
/****** Object:  Table [dbo].[order]    Script Date: 15.04.2023 0:09:29 ******/
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
/****** Object:  Table [dbo].[users]    Script Date: 15.04.2023 0:09:29 ******/
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
INSERT [dbo].[address] ([id], [id_user], [street], [house], [room], [porch], [floor]) VALUES (2, 2, N'Светлогорская', 11, 5, N'55', 3)
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
SET IDENTITY_INSERT [dbo].[items] ON 

INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (1, N'Гипсофилы', N'авторские_гипсофилы.png', 200, 3)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (2, N'Лилии', N'авторские_лилии.png', 90, 3)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (3, N'Пионы', N'авторские_пионы.png', 150, 3)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (4, N'Розы', N'авторские_розы.png', 220, 3)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (5, N'Гипсофилы', N'на_заказ_гипсофилы.png', 660, 2)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (6, N'Лилии', N'на_заказ_лилии.png', 450, 2)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (7, N'Нарциссы', N'на_заказ_нарциссы.png', 800, 2)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (8, N'Розы', N'на_заказ_розы.png', 900, 2)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (9, N'Сет: Весна', N'декоративные_1.png', 1500, 6)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (10, N'Сет: Розовый', N'декоративные_2.png', 1300, 6)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (11, N'Сет: Для дома', N'декоративные_3.png', 3000, 6)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (12, N'Сет: Природа', N'декоративные_4.png', 6200, 6)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (13, N'Гортензия', N'комнатные_гортензия.png', 1400, 7)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (14, N'Денежное дерево', N'комнатные_денежное_дерево.png', 2500, 7)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (15, N'Орхидея', N'комнатные_орхидея.png', 1800, 7)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (16, N'Фикус', N'комнатные_фикус.png', 2000, 7)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (17, N'Анютины глазки', N'полевые_анютины_глазки.png', 200, 1)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (18, N'Васильки', N'полевые_васильки.png', 260, 1)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (19, N'Незабудки', N'полевые_незабудки.png', 150, 1)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (20, N'Ромашки', N'полевые_ромашки.png', 120, 1)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (21, N'Клевер', N'полевые_клевер.png', 240, 4)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (22, N'Колокольчик', N'полевые_колокольчик.png', 260, 4)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (23, N'Ландыш', N'полевые_ландыш.png', 300, 4)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (24, N'Одуванчик', N'полевые_одуванчик.png', 230, 4)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (25, N'Ирис', N'свежесрезанные_ирис.png', 560, 8)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (26, N'Пионы', N'свежесрезанные_пионы.png', 490, 8)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (27, N'Розы', N'свежесрезанные_розы.png', 700, 8)
INSERT [dbo].[items] ([id], [name], [src], [price], [id_categories]) VALUES (28, N'Тюльпаны', N'свежесрезанные_тюльпаны.png', 620, 8)
SET IDENTITY_INSERT [dbo].[items] OFF
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
