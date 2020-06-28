/****** Object:  Table [dbo].[Hamburguers]    Script Date: 28/06/2020 7:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hamburguers](
	[HamburguerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Hamburguers] PRIMARY KEY CLUSTERED 
(
	[HamburguerId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Hamburguers]  WITH CHECK ADD  CONSTRAINT [FK_Hamburguers_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Hamburguers] CHECK CONSTRAINT [FK_Hamburguers_Categories_CategoryId]
GO
