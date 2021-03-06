/****** Object:  Table [dbo].[Hamburguers]    Script Date: 28/06/2020 9:48:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hamburguers](
	[HamburguerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[RestaurantId] [int] NOT NULL,
 CONSTRAINT [PK_Hamburguers] PRIMARY KEY CLUSTERED 
(
	[HamburguerId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HamburguersIngredients]    Script Date: 28/06/2020 9:48:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HamburguersIngredients](
	[HamburguersIngredientId] [int] IDENTITY(1,1) NOT NULL,
	[IngredientId] [int] NOT NULL,
	[HamburguerId] [int] NOT NULL,
 CONSTRAINT [PK_HamburguersIngredients] PRIMARY KEY CLUSTERED 
(
	[HamburguersIngredientId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredients]    Script Date: 28/06/2020 9:48:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredients](
	[IngredientId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Quantity] [int] NOT NULL,
	[Mesure] [nvarchar](max) NULL,
 CONSTRAINT [PK_Ingredients] PRIMARY KEY CLUSTERED 
(
	[IngredientId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Restaurants]    Script Date: 28/06/2020 9:48:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restaurants](
	[RestaurantId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Restaurants] PRIMARY KEY CLUSTERED 
(
	[RestaurantId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 28/06/2020 9:48:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersHamburguers]    Script Date: 28/06/2020 9:48:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersHamburguers](
	[UsersHamburguerId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[HamburguerId] [int] NOT NULL,
 CONSTRAINT [PK_UsersHamburguers] PRIMARY KEY CLUSTERED 
(
	[UsersHamburguerId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Hamburguers]  WITH CHECK ADD  CONSTRAINT [FK_Hamburguers_Restaurants_RestaurantId] FOREIGN KEY([RestaurantId])
REFERENCES [dbo].[Restaurants] ([RestaurantId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Hamburguers] CHECK CONSTRAINT [FK_Hamburguers_Restaurants_RestaurantId]
GO
ALTER TABLE [dbo].[HamburguersIngredients]  WITH CHECK ADD  CONSTRAINT [FK_HamburguersIngredients_Hamburguers_HamburguerId] FOREIGN KEY([HamburguerId])
REFERENCES [dbo].[Hamburguers] ([HamburguerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HamburguersIngredients] CHECK CONSTRAINT [FK_HamburguersIngredients_Hamburguers_HamburguerId]
GO
ALTER TABLE [dbo].[HamburguersIngredients]  WITH CHECK ADD  CONSTRAINT [FK_HamburguersIngredients_Ingredients_IngredientId] FOREIGN KEY([IngredientId])
REFERENCES [dbo].[Ingredients] ([IngredientId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HamburguersIngredients] CHECK CONSTRAINT [FK_HamburguersIngredients_Ingredients_IngredientId]
GO
ALTER TABLE [dbo].[UsersHamburguers]  WITH CHECK ADD  CONSTRAINT [FK_UsersHamburguers_Hamburguers_HamburguerId] FOREIGN KEY([HamburguerId])
REFERENCES [dbo].[Hamburguers] ([HamburguerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersHamburguers] CHECK CONSTRAINT [FK_UsersHamburguers_Hamburguers_HamburguerId]
GO
ALTER TABLE [dbo].[UsersHamburguers]  WITH CHECK ADD  CONSTRAINT [FK_UsersHamburguers_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersHamburguers] CHECK CONSTRAINT [FK_UsersHamburguers_Users_UserId]
GO
