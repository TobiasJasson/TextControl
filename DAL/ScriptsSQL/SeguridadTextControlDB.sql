USE [master]
GO
/****** Object:  Database [SeguridadTexControl]    Script Date: 17/11/2025 17:39:45 ******/
CREATE DATABASE [SeguridadTexControl]
WITH CATALOG_COLLATION = DATABASE_DEFAULT;
GO
GO
ALTER DATABASE [SeguridadTexControl] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SeguridadTexControl].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SeguridadTexControl] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SeguridadTexControl] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SeguridadTexControl] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SeguridadTexControl] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SeguridadTexControl] SET ARITHABORT OFF 
GO
ALTER DATABASE [SeguridadTexControl] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SeguridadTexControl] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SeguridadTexControl] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SeguridadTexControl] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SeguridadTexControl] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SeguridadTexControl] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SeguridadTexControl] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SeguridadTexControl] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SeguridadTexControl] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SeguridadTexControl] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SeguridadTexControl] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SeguridadTexControl] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SeguridadTexControl] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SeguridadTexControl] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SeguridadTexControl] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SeguridadTexControl] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SeguridadTexControl] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SeguridadTexControl] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SeguridadTexControl] SET  MULTI_USER 
GO
ALTER DATABASE [SeguridadTexControl] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SeguridadTexControl] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SeguridadTexControl] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SeguridadTexControl] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SeguridadTexControl] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SeguridadTexControl] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SeguridadTexControl] SET QUERY_STORE = ON
GO
ALTER DATABASE [SeguridadTexControl] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SeguridadTexControl]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 17/11/2025 17:39:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[ID_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[PasswordHash] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[ID_Empleado] [int] NULL,
	[Activo] [bit] NOT NULL,
	[RecoveryToken] [varchar](200) NULL,
	[RecoveryTokenExpiry] [datetime] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familia]    Script Date: 17/11/2025 17:39:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia](
	[ID_Familia] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Descripcion] [varchar](255) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Familia] PRIMARY KEY CLUSTERED 
(
	[ID_Familia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 17/11/2025 17:39:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[ID_Empleado] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[DNI] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[NumeroContacto] [varchar](50) NOT NULL,
	[ID_Rol] [int] NOT NULL,
 CONSTRAINT [PK__Empleado__B7872C90C74DA81E] PRIMARY KEY CLUSTERED 
(
	[ID_Empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioFamilia]    Script Date: 17/11/2025 17:39:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioFamilia](
	[ID_Usuario] [int] NOT NULL,
	[ID_Familia] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioFamilia] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC,
	[ID_Familia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_UsuariosSimple]    Script Date: 17/11/2025 17:39:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Crear la vista corregida (usar los nombres reales de columnas)
CREATE VIEW [dbo].[vw_UsuariosSimple]
AS
SELECT 
    U.ID_Usuario,
    E.ID_Empleado,
    E.Nombre      AS Nombre_Empleado,
    E.Apellido    AS Apellido_Empleado,
    E.DNI         AS DNI_Empleado,
    E.Email       AS Email,
    E.NumeroContacto AS Contacto,
    F.Nombre      AS Rol,         -- <-- CORRECCIÓN: 'Nombre' en la tabla Familia
    U.Activo      AS UsuarioActivo
FROM dbo.Usuario U
LEFT JOIN dbo.Empleado E ON U.ID_Empleado = E.ID_Empleado
LEFT JOIN dbo.UsuarioFamilia UF ON U.ID_Usuario = UF.ID_Usuario
LEFT JOIN dbo.Familia F ON UF.ID_Familia = F.ID_Familia;
GO
/****** Object:  Table [dbo].[Patente]    Script Date: 17/11/2025 17:39:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patente](
	[ID_Patente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Descripcion] [varchar](255) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Patente] PRIMARY KEY CLUSTERED 
(
	[ID_Patente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FamiliaPatente]    Script Date: 17/11/2025 17:39:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamiliaPatente](
	[ID_Familia] [int] NOT NULL,
	[ID_Patente] [int] NOT NULL,
 CONSTRAINT [PK_FamiliaPatente] PRIMARY KEY CLUSTERED 
(
	[ID_Familia] ASC,
	[ID_Patente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioPatente]    Script Date: 17/11/2025 17:39:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioPatente](
	[ID_Usuario] [int] NOT NULL,
	[ID_Patente] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioPatente] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC,
	[ID_Patente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_UsuariosPermisosCompleta]    Script Date: 17/11/2025 17:39:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_UsuariosPermisosCompleta]
AS
SELECT U.ID_Usuario, U.UserName, U.Email, U.ID_Empleado, U.Activo AS UsuarioActivo, F.ID_Familia, F.Nombre AS NombreFamilia, F.Descripcion AS DescripcionFamilia, F.Activo AS FamiliaActiva, P.ID_Patente, P.Nombre AS NombrePatente, 
                  P.Descripcion AS DescripcionPatente, P.Activo AS PatenteActiva, CASE WHEN UP.ID_Usuario IS NOT NULL THEN 'Asignada Directamente' WHEN FP.ID_Patente IS NOT NULL 
                  THEN 'Por Familia' ELSE 'No Asignada' END AS TipoAsignacion
FROM     dbo.Usuario AS U LEFT OUTER JOIN
                  dbo.UsuarioFamilia AS UF ON U.ID_Usuario = UF.ID_Usuario LEFT OUTER JOIN
                  dbo.Familia AS F ON UF.ID_Familia = F.ID_Familia LEFT OUTER JOIN
                  dbo.FamiliaPatente AS FP ON F.ID_Familia = FP.ID_Familia LEFT OUTER JOIN
                  dbo.Patente AS P ON FP.ID_Patente = P.ID_Patente LEFT OUTER JOIN
                  dbo.UsuarioPatente AS UP ON U.ID_Usuario = UP.ID_Usuario AND UP.ID_Patente = P.ID_Patente
WHERE  (U.Activo = 1)
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 17/11/2025 17:39:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[ID_Rol] [int] NOT NULL,
	[NombreRol] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Empleado] ON 
GO
INSERT [dbo].[Empleado] ([ID_Empleado], [Nombre], [Apellido], [DNI], [Email], [NumeroContacto], [ID_Rol]) VALUES (1, N'Tobias', N'Jasson', N'46274592', N'tobiasjasson@gmail.com', N'11 3027-4289', 1)
GO
INSERT [dbo].[Empleado] ([ID_Empleado], [Nombre], [Apellido], [DNI], [Email], [NumeroContacto], [ID_Rol]) VALUES (4, N'Matias', N'Jasson', N'48370999', N'tobiasjasson@gmail.com', N'11 30274289', 1)
GO
INSERT [dbo].[Empleado] ([ID_Empleado], [Nombre], [Apellido], [DNI], [Email], [NumeroContacto], [ID_Rol]) VALUES (12, N'Admin', N'admin', N'11111112', N'tobiasjasson@gmail.com', N'11111111112', 1)
GO
INSERT [dbo].[Empleado] ([ID_Empleado], [Nombre], [Apellido], [DNI], [Email], [NumeroContacto], [ID_Rol]) VALUES (15, N'empleado', N'empleado', N'222222222', N'tobiasjasson@gmail.com', N'2222222222', 2)
GO
SET IDENTITY_INSERT [dbo].[Empleado] OFF
GO
SET IDENTITY_INSERT [dbo].[Familia] ON 
GO
INSERT [dbo].[Familia] ([ID_Familia], [Nombre], [Descripcion], [Activo]) VALUES (1, N'Administrativo', N'Acceso total a todas las pantallas', 1)
GO
INSERT [dbo].[Familia] ([ID_Familia], [Nombre], [Descripcion], [Activo]) VALUES (2, N'Empleado', N'Acceso limitado: no gestiona usuarios, pedidos ni stock', 1)
GO
SET IDENTITY_INSERT [dbo].[Familia] OFF
GO
INSERT [dbo].[FamiliaPatente] ([ID_Familia], [ID_Patente]) VALUES (1, 1)
GO
INSERT [dbo].[FamiliaPatente] ([ID_Familia], [ID_Patente]) VALUES (1, 2)
GO
INSERT [dbo].[FamiliaPatente] ([ID_Familia], [ID_Patente]) VALUES (1, 3)
GO
INSERT [dbo].[FamiliaPatente] ([ID_Familia], [ID_Patente]) VALUES (1, 4)
GO
INSERT [dbo].[FamiliaPatente] ([ID_Familia], [ID_Patente]) VALUES (1, 5)
GO
INSERT [dbo].[FamiliaPatente] ([ID_Familia], [ID_Patente]) VALUES (2, 5)
GO
SET IDENTITY_INSERT [dbo].[Patente] ON 
GO
INSERT [dbo].[Patente] ([ID_Patente], [Nombre], [Descripcion], [Activo]) VALUES (1, N'GestionarUsuarios', N'Alta, baja y modificación de usuarios', 1)
GO
INSERT [dbo].[Patente] ([ID_Patente], [Nombre], [Descripcion], [Activo]) VALUES (2, N'VerPedidos', N'Visualizar pedidos', 1)
GO
INSERT [dbo].[Patente] ([ID_Patente], [Nombre], [Descripcion], [Activo]) VALUES (3, N'EditarPedidos', N'Modificar pedidos', 1)
GO
INSERT [dbo].[Patente] ([ID_Patente], [Nombre], [Descripcion], [Activo]) VALUES (4, N'GestionarStock', N'Control de stock e insumos', 1)
GO
INSERT [dbo].[Patente] ([ID_Patente], [Nombre], [Descripcion], [Activo]) VALUES (5, N'GenerarReportes', N'Acceso a reportes de gestión', 1)
GO
SET IDENTITY_INSERT [dbo].[Patente] OFF
GO
INSERT [dbo].[Rol] ([ID_Rol], [NombreRol]) VALUES (1, N'Administrativo')
GO
INSERT [dbo].[Rol] ([ID_Rol], [NombreRol]) VALUES (2, N'Empleado')
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([ID_Usuario], [UserName], [PasswordHash], [Email], [ID_Empleado], [Activo], [RecoveryToken], [RecoveryTokenExpiry]) VALUES (1, N'Tobias', N'TUljbGF2ZTc3', N'tobiasjasson@gmail.com', 1, 1, N'ZHLwmTgmMZB2rAJgOdW4hu4ODtmllCFpjiQHwMC29VI', CAST(N'2025-11-09T19:45:35.577' AS DateTime))
GO
INSERT [dbo].[Usuario] ([ID_Usuario], [UserName], [PasswordHash], [Email], [ID_Empleado], [Activo], [RecoveryToken], [RecoveryTokenExpiry]) VALUES (5, N'Matias', N'Y2xhdmVUZW1wb3JhbA==', N'tobiasjasson@gmail.com', 4, 1, N'vrGjBUQYBQALz7pItFcyyfLTxNFbe8re3ODwj1c68', CAST(N'2025-11-16T13:52:04.930' AS DateTime))
GO
INSERT [dbo].[Usuario] ([ID_Usuario], [UserName], [PasswordHash], [Email], [ID_Empleado], [Activo], [RecoveryToken], [RecoveryTokenExpiry]) VALUES (6, N'Admin', N'QURtaW4xMjM=', N'tobiasjasson@gmail.com', 12, 1, NULL, NULL)
GO
INSERT [dbo].[Usuario] ([ID_Usuario], [UserName], [PasswordHash], [Email], [ID_Empleado], [Activo], [RecoveryToken], [RecoveryTokenExpiry]) VALUES (8, N'empleado', N'RU1wbGVhZG8xMjM=', N'tobiasjasson@gmail.com', 15, 1, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
INSERT [dbo].[UsuarioFamilia] ([ID_Usuario], [ID_Familia]) VALUES (1, 1)
GO
INSERT [dbo].[UsuarioFamilia] ([ID_Usuario], [ID_Familia]) VALUES (5, 1)
GO
INSERT [dbo].[UsuarioFamilia] ([ID_Usuario], [ID_Familia]) VALUES (6, 1)
GO
INSERT [dbo].[UsuarioFamilia] ([ID_Usuario], [ID_Familia]) VALUES (8, 2)
GO
ALTER TABLE [dbo].[Familia] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Patente] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[FamiliaPatente]  WITH CHECK ADD  CONSTRAINT [FK_FamiliaPatente_Familia] FOREIGN KEY([ID_Familia])
REFERENCES [dbo].[Familia] ([ID_Familia])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FamiliaPatente] CHECK CONSTRAINT [FK_FamiliaPatente_Familia]
GO
ALTER TABLE [dbo].[FamiliaPatente]  WITH CHECK ADD  CONSTRAINT [FK_FamiliaPatente_Patente] FOREIGN KEY([ID_Patente])
REFERENCES [dbo].[Patente] ([ID_Patente])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FamiliaPatente] CHECK CONSTRAINT [FK_FamiliaPatente_Patente]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Empleado] FOREIGN KEY([ID_Empleado])
REFERENCES [dbo].[Empleado] ([ID_Empleado])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Empleado]
GO
ALTER TABLE [dbo].[UsuarioFamilia]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioFamilia_Familia] FOREIGN KEY([ID_Familia])
REFERENCES [dbo].[Familia] ([ID_Familia])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuarioFamilia] CHECK CONSTRAINT [FK_UsuarioFamilia_Familia]
GO
ALTER TABLE [dbo].[UsuarioFamilia]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioFamilia_Usuario] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuario] ([ID_Usuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuarioFamilia] CHECK CONSTRAINT [FK_UsuarioFamilia_Usuario]
GO
ALTER TABLE [dbo].[UsuarioPatente]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPatente_Patente] FOREIGN KEY([ID_Patente])
REFERENCES [dbo].[Patente] ([ID_Patente])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuarioPatente] CHECK CONSTRAINT [FK_UsuarioPatente_Patente]
GO
ALTER TABLE [dbo].[UsuarioPatente]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPatente_Usuario] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuario] ([ID_Usuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuarioPatente] CHECK CONSTRAINT [FK_UsuarioPatente_Usuario]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[37] 4[6] 2[28] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "U"
            Begin Extent = 
               Top = 225
               Left = 77
               Bottom = 462
               Right = 271
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UF"
            Begin Extent = 
               Top = 359
               Left = 563
               Bottom = 478
               Right = 757
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "F"
            Begin Extent = 
               Top = 305
               Left = 843
               Bottom = 468
               Right = 1037
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FP"
            Begin Extent = 
               Top = 172
               Left = 1325
               Bottom = 291
               Right = 1519
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "P"
            Begin Extent = 
               Top = 74
               Left = 701
               Bottom = 237
               Right = 895
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UP"
            Begin Extent = 
               Top = 177
               Left = 434
               Bottom = 296
               Right = 628
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 11
         Width = 284
         Width = 1200
         Width = 1200
         Width = 2112
        ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_UsuariosPermisosCompleta'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' Width = 1200
         Width = 1200
         Width = 1032
         Width = 1428
         Width = 3612
         Width = 1236
         Width = 1020
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_UsuariosPermisosCompleta'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_UsuariosPermisosCompleta'
GO
USE [master]
GO
ALTER DATABASE [SeguridadTexControl] SET  READ_WRITE 
GO
