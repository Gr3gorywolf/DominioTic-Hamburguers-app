/****** Object:  Table [dbo].[UsersHamburguers]    Script Date: 28/06/2020 7:01:44 ******/
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
