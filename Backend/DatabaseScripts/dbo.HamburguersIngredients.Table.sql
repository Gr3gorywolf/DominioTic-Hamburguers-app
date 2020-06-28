/****** Object:  Table [dbo].[HamburguersIngredients]    Script Date: 28/06/2020 7:01:44 ******/
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
