SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol_usuario](
	[idRolUsuario] [int] IDENTITY(1,1) NOT NULL,
	[idRol] [int] NOT NULL,
	[idUsuario] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[rol_usuario] ADD  CONSTRAINT [PK_roles_usuarios] PRIMARY KEY CLUSTERED 
(
	[idRolUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[rol_usuario]  WITH CHECK ADD  CONSTRAINT [FK_roles_usuarios_roles] FOREIGN KEY([idRol])
REFERENCES [dbo].[rol] ([idRol])
GO
ALTER TABLE [dbo].[rol_usuario] CHECK CONSTRAINT [FK_roles_usuarios_roles]
GO
ALTER TABLE [dbo].[rol_usuario]  WITH CHECK ADD  CONSTRAINT [FK_roles_usuarios_usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[rol_usuario] CHECK CONSTRAINT [FK_roles_usuarios_usuarios]
GO
