USE [master]
GO
/****** Object:  Database [TextControl]    Script Date: 17/11/2025 17:33:28 ******/
CREATE DATABASE [TextControl]
WITH CATALOG_COLLATION = DATABASE_DEFAULT;
GO
GO
ALTER DATABASE [TextControl] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TextControl].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TextControl] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TextControl] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TextControl] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TextControl] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TextControl] SET ARITHABORT OFF 
GO
ALTER DATABASE [TextControl] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TextControl] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TextControl] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TextControl] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TextControl] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TextControl] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TextControl] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TextControl] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TextControl] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TextControl] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TextControl] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TextControl] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TextControl] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TextControl] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TextControl] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TextControl] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TextControl] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TextControl] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TextControl] SET  MULTI_USER 
GO
ALTER DATABASE [TextControl] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TextControl] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TextControl] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TextControl] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TextControl] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TextControl] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TextControl] SET QUERY_STORE = ON
GO
ALTER DATABASE [TextControl] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [TextControl]
GO
/****** Object:  Table [dbo].[Tipo_Insumo]    Script Date: 17/11/2025 17:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Insumo](
	[ID_TipoInsumo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tipo_Insumo] PRIMARY KEY CLUSTERED 
(
	[ID_TipoInsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Movimiento]    Script Date: 17/11/2025 17:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Movimiento](
	[ID_TipoMovimiento] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tipo_Movimiento] PRIMARY KEY CLUSTERED 
(
	[ID_TipoMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimiento_Stock]    Script Date: 17/11/2025 17:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimiento_Stock](
	[ID_Movimiento] [int] IDENTITY(1,1) NOT NULL,
	[ID_TipoMovimiento] [int] NOT NULL,
	[ID_Insumo] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[ID_Pedido] [int] NULL,
 CONSTRAINT [PK_Movimiento_Stock] PRIMARY KEY CLUSTERED 
(
	[ID_Movimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Insumo]    Script Date: 17/11/2025 17:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Insumo](
	[ID_Insumo] [int] IDENTITY(1,1) NOT NULL,
	[ID_TipoInsumo] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[ID_Color] [int] NULL,
	[CantidadPorUnidad] [float] NULL,
	[StockActual] [int] NOT NULL,
	[StockMinimo] [int] NOT NULL,
	[PrecioUnitario] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Insumo] PRIMARY KEY CLUSTERED 
(
	[ID_Insumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 17/11/2025 17:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ID_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Cliente] [varchar](50) NOT NULL,
	[Contacto_Cliente] [nchar](50) NOT NULL,
	[Email_Cliente] [varchar](100) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ID_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 17/11/2025 17:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[ID_pedido] [int] IDENTITY(1,1) NOT NULL,
	[FechaPedido] [datetime] NOT NULL,
	[FechaEntrega_pedido] [datetime] NULL,
	[ID_EstadoPedido] [int] NOT NULL,
	[PrecioTotal_pedido] [float] NOT NULL,
	[SaldoPendiente_pedido] [float] NOT NULL,
	[pagoAdelanto_pedido] [bit] NOT NULL,
	[ID_Cliente] [int] NOT NULL,
	[ID_Empleado] [int] NULL,
	[ID_Prioridad] [int] NOT NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[ID_pedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prioridad]    Script Date: 17/11/2025 17:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prioridad](
	[ID_Prioridad] [int] IDENTITY(1,1) NOT NULL,
	[Prioridad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Prioridad] PRIMARY KEY CLUSTERED 
(
	[ID_Prioridad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pago_Adelantado]    Script Date: 17/11/2025 17:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pago_Adelantado](
	[ID_pagoAdelantado] [int] IDENTITY(1,1) NOT NULL,
	[monto_pagoAdelantado] [float] NOT NULL,
	[fecha_pagoAdelantado] [date] NOT NULL,
	[ID_Pedido] [int] NOT NULL,
 CONSTRAINT [PK_Pago_Adelantado] PRIMARY KEY CLUSTERED 
(
	[ID_pagoAdelantado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado_Pedido]    Script Date: 17/11/2025 17:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado_Pedido](
	[ID_EstadoPedido] [int] NOT NULL,
	[Descripcion_EstadoPedido] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Talles]    Script Date: 17/11/2025 17:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Talles](
	[ID_Talles] [int] IDENTITY(1,1) NOT NULL,
	[Detalles_Talles] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Talles] PRIMARY KEY CLUSTERED 
(
	[ID_Talles] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_Pedido]    Script Date: 17/11/2025 17:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Pedido](
	[ID_Detalle] [int] IDENTITY(1,1) NOT NULL,
	[ID_Pedido] [int] NOT NULL,
	[ID_Tela] [int] NOT NULL,
	[Color_Detalle] [varchar](100) NOT NULL,
	[ID_Talle] [int] NOT NULL,
	[Cantidad_Detalle] [int] NOT NULL,
	[PrecioUnitario] [float] NOT NULL,
 CONSTRAINT [PK__Detalle___B3E0CED3AF216F84] PRIMARY KEY CLUSTERED 
(
	[ID_Detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personalizacion]    Script Date: 17/11/2025 17:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personalizacion](
	[ID_Personalizacion] [int] IDENTITY(1,1) NOT NULL,
	[ID_Detalle] [int] NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[Diseno] [varchar](255) NULL,
	[Tamano] [varchar](50) NULL,
	[Posicion] [char](10) NULL,
	[PrecioUnitario] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Personalizacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_PedidosCompleto]    Script Date: 17/11/2025 17:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[view_PedidosCompleto]
AS
SELECT p.ID_pedido, p.FechaPedido, p.FechaEntrega_pedido, p.PrecioTotal_pedido, p.SaldoPendiente_pedido, p.pagoAdelanto_pedido, cli.ID_Cliente, cli.Nombre_Cliente, cli.Contacto_Cliente, cli.Email_Cliente, emp.ID_Empleado, 
                  emp.Nombre AS Nombre_Empleado, emp.Apellido AS Apellido_Empleado, emp.NumeroContacto AS Contacto_Empleado, pr.Prioridad, d.ID_Detalle, d.ID_Tela, d.Color_Detalle, d.ID_Talle, t.Detalles_Talles, d.Cantidad_Detalle, 
                  d.PrecioUnitario AS Precio_Detalle, per.Tipo AS Personalizacion_Tipo, per.Diseno AS Personalizacion_Diseno, per.Tamano AS Personalizacion_Tamano, per.Posicion AS Personalizacion_Posicion, 
                  per.PrecioUnitario AS Personalizacion_Precio, ISNULL(SUM(pa.monto_pagoAdelantado), 0) AS TotalPagosAdelantados, dbo.Estado_Pedido.Descripcion_EstadoPedido
FROM     dbo.Pedidos AS p INNER JOIN
                  dbo.Cliente AS cli ON p.ID_Cliente = cli.ID_Cliente LEFT OUTER JOIN
                  SeguridadTexControl.dbo.Empleado AS emp ON p.ID_Empleado = emp.ID_Empleado INNER JOIN
                  dbo.Detalle_Pedido AS d ON p.ID_pedido = d.ID_Pedido INNER JOIN
                  dbo.Talles AS t ON d.ID_Talle = t.ID_Talles LEFT OUTER JOIN
                  dbo.Personalizacion AS per ON d.ID_Detalle = per.ID_Detalle LEFT OUTER JOIN
                  dbo.Pago_Adelantado AS pa ON p.ID_pedido = pa.ID_Pedido INNER JOIN
                  dbo.Prioridad AS pr ON p.ID_Prioridad = pr.ID_Prioridad INNER JOIN
                  dbo.Estado_Pedido ON p.ID_EstadoPedido = dbo.Estado_Pedido.ID_EstadoPedido
GROUP BY p.ID_pedido, p.FechaPedido, p.FechaEntrega_pedido, p.PrecioTotal_pedido, p.SaldoPendiente_pedido, p.pagoAdelanto_pedido, cli.ID_Cliente, cli.Nombre_Cliente, cli.Contacto_Cliente, cli.Email_Cliente, emp.ID_Empleado, emp.Nombre, 
                  emp.Apellido, emp.NumeroContacto, pr.Prioridad, d.ID_Detalle, d.ID_Tela, d.Color_Detalle, d.ID_Talle, t.Detalles_Talles, d.Cantidad_Detalle, d.PrecioUnitario, per.Tipo, per.Diseno, per.Tamano, per.Posicion, per.PrecioUnitario, 
                  dbo.Estado_Pedido.Descripcion_EstadoPedido
GO
/****** Object:  View [dbo].[vw_UsuariosExternos]    Script Date: 17/11/2025 17:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_UsuariosExternos]
AS
SELECT ID_Usuario, UserName, Email, ID_Empleado
FROM     SeguridadTexControl.dbo.Usuario AS u
WHERE  (Activo = 1)
GO
/****** Object:  Table [dbo].[Color]    Script Date: 17/11/2025 17:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[ID_Color] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion_Color] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[ID_Color] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notificacion_Stock]    Script Date: 17/11/2025 17:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notificacion_Stock](
	[ID_Notificacion] [int] IDENTITY(1,1) NOT NULL,
	[ID_Prioridad] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[ID_Insumo] [int] NOT NULL,
 CONSTRAINT [PK_Notificacion_Stock] PRIMARY KEY CLUSTERED 
(
	[ID_Notificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol_Empleado]    Script Date: 17/11/2025 17:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol_Empleado](
	[ID_Rol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Rol] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Rol_Empleado] PRIMARY KEY CLUSTERED 
(
	[ID_Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 
GO
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombre_Cliente], [Contacto_Cliente], [Email_Cliente]) VALUES (1, N'Carlos López', N'333-333                                           ', N'tobiasjasson2005@gmail.com')
GO
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombre_Cliente], [Contacto_Cliente], [Email_Cliente]) VALUES (2, N'María Fernández', N'444-444                                           ', N'tobiasjasson2005@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Color] ON 
GO
INSERT [dbo].[Color] ([ID_Color], [Descripcion_Color]) VALUES (1, N'Plateado')
GO
INSERT [dbo].[Color] ([ID_Color], [Descripcion_Color]) VALUES (2, N'Blanco')
GO
INSERT [dbo].[Color] ([ID_Color], [Descripcion_Color]) VALUES (3, N'Negro')
GO
INSERT [dbo].[Color] ([ID_Color], [Descripcion_Color]) VALUES (4, N'Marron')
GO
INSERT [dbo].[Color] ([ID_Color], [Descripcion_Color]) VALUES (5, N'Rojo')
GO
INSERT [dbo].[Color] ([ID_Color], [Descripcion_Color]) VALUES (6, N'Verde')
GO
INSERT [dbo].[Color] ([ID_Color], [Descripcion_Color]) VALUES (7, N'Azul')
GO
INSERT [dbo].[Color] ([ID_Color], [Descripcion_Color]) VALUES (8, N'Azul Oscuro')
GO
INSERT [dbo].[Color] ([ID_Color], [Descripcion_Color]) VALUES (9, N'Azul Galaxia')
GO
SET IDENTITY_INSERT [dbo].[Color] OFF
GO
SET IDENTITY_INSERT [dbo].[Detalle_Pedido] ON 
GO
INSERT [dbo].[Detalle_Pedido] ([ID_Detalle], [ID_Pedido], [ID_Tela], [Color_Detalle], [ID_Talle], [Cantidad_Detalle], [PrecioUnitario]) VALUES (1, 1, 4, N'Blanco', 3, 10, 1500)
GO
INSERT [dbo].[Detalle_Pedido] ([ID_Detalle], [ID_Pedido], [ID_Tela], [Color_Detalle], [ID_Talle], [Cantidad_Detalle], [PrecioUnitario]) VALUES (2, 1, 4, N'Negro', 4, 5, 2500)
GO
INSERT [dbo].[Detalle_Pedido] ([ID_Detalle], [ID_Pedido], [ID_Tela], [Color_Detalle], [ID_Talle], [Cantidad_Detalle], [PrecioUnitario]) VALUES (3, 2, 4, N'Blanco', 2, 8, 1500)
GO
SET IDENTITY_INSERT [dbo].[Detalle_Pedido] OFF
GO
INSERT [dbo].[Estado_Pedido] ([ID_EstadoPedido], [Descripcion_EstadoPedido]) VALUES (1, N'En Proceso')
GO
INSERT [dbo].[Estado_Pedido] ([ID_EstadoPedido], [Descripcion_EstadoPedido]) VALUES (2, N'Terminado')
GO
INSERT [dbo].[Estado_Pedido] ([ID_EstadoPedido], [Descripcion_EstadoPedido]) VALUES (3, N'En Espera')
GO
SET IDENTITY_INSERT [dbo].[Insumo] ON 
GO
INSERT [dbo].[Insumo] ([ID_Insumo], [ID_TipoInsumo], [Nombre], [ID_Color], [CantidadPorUnidad], [StockActual], [StockMinimo], [PrecioUnitario]) VALUES (1, 1, N'Botón metálico', 1, 2, 1000, 100, CAST(500.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Insumo] ([ID_Insumo], [ID_TipoInsumo], [Nombre], [ID_Color], [CantidadPorUnidad], [StockActual], [StockMinimo], [PrecioUnitario]) VALUES (2, 2, N'Hilo algodón', 2, 1, 90, 50, CAST(200.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Insumo] ([ID_Insumo], [ID_TipoInsumo], [Nombre], [ID_Color], [CantidadPorUnidad], [StockActual], [StockMinimo], [PrecioUnitario]) VALUES (4, 3, N'Frisa', 3, 1, 200, 100, CAST(100.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Insumo] ([ID_Insumo], [ID_TipoInsumo], [Nombre], [ID_Color], [CantidadPorUnidad], [StockActual], [StockMinimo], [PrecioUnitario]) VALUES (5, 4, N'Zapato de punta de metal', 4, 2, 100, 50, CAST(10000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Insumo] ([ID_Insumo], [ID_TipoInsumo], [Nombre], [ID_Color], [CantidadPorUnidad], [StockActual], [StockMinimo], [PrecioUnitario]) VALUES (7, 5, N'Chaleco de Polar', 2, 1, 80, 20, CAST(15000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Insumo] ([ID_Insumo], [ID_TipoInsumo], [Nombre], [ID_Color], [CantidadPorUnidad], [StockActual], [StockMinimo], [PrecioUnitario]) VALUES (8, 6, N'Campera de Polar', 3, 1, 100, 10, CAST(20000.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Insumo] OFF
GO
SET IDENTITY_INSERT [dbo].[Movimiento_Stock] ON 
GO
INSERT [dbo].[Movimiento_Stock] ([ID_Movimiento], [ID_TipoMovimiento], [ID_Insumo], [Cantidad], [Fecha], [ID_Pedido]) VALUES (1, 2, 1, 50, CAST(N'2025-09-06T18:29:04.830' AS DateTime), 1)
GO
INSERT [dbo].[Movimiento_Stock] ([ID_Movimiento], [ID_TipoMovimiento], [ID_Insumo], [Cantidad], [Fecha], [ID_Pedido]) VALUES (2, 2, 2, 100, CAST(N'2025-09-06T18:29:04.830' AS DateTime), 2)
GO
SET IDENTITY_INSERT [dbo].[Movimiento_Stock] OFF
GO
SET IDENTITY_INSERT [dbo].[Pago_Adelantado] ON 
GO
INSERT [dbo].[Pago_Adelantado] ([ID_pagoAdelantado], [monto_pagoAdelantado], [fecha_pagoAdelantado], [ID_Pedido]) VALUES (1, 10000, CAST(N'2025-09-06' AS Date), 1)
GO
INSERT [dbo].[Pago_Adelantado] ([ID_pagoAdelantado], [monto_pagoAdelantado], [fecha_pagoAdelantado], [ID_Pedido]) VALUES (2, 5000, CAST(N'2025-09-06' AS Date), 2)
GO
SET IDENTITY_INSERT [dbo].[Pago_Adelantado] OFF
GO
SET IDENTITY_INSERT [dbo].[Pedidos] ON 
GO
INSERT [dbo].[Pedidos] ([ID_pedido], [FechaPedido], [FechaEntrega_pedido], [ID_EstadoPedido], [PrecioTotal_pedido], [SaldoPendiente_pedido], [pagoAdelanto_pedido], [ID_Cliente], [ID_Empleado], [ID_Prioridad]) VALUES (1, CAST(N'2025-09-06T18:29:04.827' AS DateTime), CAST(N'2025-09-21T18:29:04.827' AS DateTime), 1, 27500, 17500, 1, 1, 1, 1)
GO
INSERT [dbo].[Pedidos] ([ID_pedido], [FechaPedido], [FechaEntrega_pedido], [ID_EstadoPedido], [PrecioTotal_pedido], [SaldoPendiente_pedido], [pagoAdelanto_pedido], [ID_Cliente], [ID_Empleado], [ID_Prioridad]) VALUES (2, CAST(N'2025-08-06T18:29:04.827' AS DateTime), CAST(N'2025-09-26T18:29:04.827' AS DateTime), 2, 12000, 7000, 1, 2, 4, 2)
GO
SET IDENTITY_INSERT [dbo].[Pedidos] OFF
GO
SET IDENTITY_INSERT [dbo].[Personalizacion] ON 
GO
INSERT [dbo].[Personalizacion] ([ID_Personalizacion], [ID_Detalle], [Tipo], [Diseno], [Tamano], [Posicion], [PrecioUnitario]) VALUES (1, 1, N'Estampado', N'Logo Empresa', N'10x10', N'Frente    ', 500)
GO
INSERT [dbo].[Personalizacion] ([ID_Personalizacion], [ID_Detalle], [Tipo], [Diseno], [Tamano], [Posicion], [PrecioUnitario]) VALUES (2, 2, N'Bordado', N'Iniciales', N'5x5', N'Espalda   ', 700)
GO
SET IDENTITY_INSERT [dbo].[Personalizacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Prioridad] ON 
GO
INSERT [dbo].[Prioridad] ([ID_Prioridad], [Prioridad]) VALUES (1, N'Alta')
GO
INSERT [dbo].[Prioridad] ([ID_Prioridad], [Prioridad]) VALUES (2, N'Media')
GO
SET IDENTITY_INSERT [dbo].[Prioridad] OFF
GO
SET IDENTITY_INSERT [dbo].[Rol_Empleado] ON 
GO
INSERT [dbo].[Rol_Empleado] ([ID_Rol], [Nombre_Rol]) VALUES (1, N'Administrador')
GO
INSERT [dbo].[Rol_Empleado] ([ID_Rol], [Nombre_Rol]) VALUES (2, N'Empleado')
GO
SET IDENTITY_INSERT [dbo].[Rol_Empleado] OFF
GO
SET IDENTITY_INSERT [dbo].[Talles] ON 
GO
INSERT [dbo].[Talles] ([ID_Talles], [Detalles_Talles]) VALUES (1, N'XS')
GO
INSERT [dbo].[Talles] ([ID_Talles], [Detalles_Talles]) VALUES (2, N'S')
GO
INSERT [dbo].[Talles] ([ID_Talles], [Detalles_Talles]) VALUES (3, N'M')
GO
INSERT [dbo].[Talles] ([ID_Talles], [Detalles_Talles]) VALUES (4, N'L')
GO
INSERT [dbo].[Talles] ([ID_Talles], [Detalles_Talles]) VALUES (5, N'XL')
GO
INSERT [dbo].[Talles] ([ID_Talles], [Detalles_Talles]) VALUES (6, N'XXL')
GO
INSERT [dbo].[Talles] ([ID_Talles], [Detalles_Talles]) VALUES (7, N'XXXL')
GO
SET IDENTITY_INSERT [dbo].[Talles] OFF
GO
SET IDENTITY_INSERT [dbo].[Tipo_Insumo] ON 
GO
INSERT [dbo].[Tipo_Insumo] ([ID_TipoInsumo], [Descripcion]) VALUES (1, N'Botón')
GO
INSERT [dbo].[Tipo_Insumo] ([ID_TipoInsumo], [Descripcion]) VALUES (2, N'Hilo')
GO
INSERT [dbo].[Tipo_Insumo] ([ID_TipoInsumo], [Descripcion]) VALUES (3, N'Tela')
GO
INSERT [dbo].[Tipo_Insumo] ([ID_TipoInsumo], [Descripcion]) VALUES (4, N'Zapato')
GO
INSERT [dbo].[Tipo_Insumo] ([ID_TipoInsumo], [Descripcion]) VALUES (5, N'Chaleco')
GO
INSERT [dbo].[Tipo_Insumo] ([ID_TipoInsumo], [Descripcion]) VALUES (6, N'Campera')
GO
SET IDENTITY_INSERT [dbo].[Tipo_Insumo] OFF
GO
SET IDENTITY_INSERT [dbo].[Tipo_Movimiento] ON 
GO
INSERT [dbo].[Tipo_Movimiento] ([ID_TipoMovimiento], [Descripcion]) VALUES (1, N'Entrada')
GO
INSERT [dbo].[Tipo_Movimiento] ([ID_TipoMovimiento], [Descripcion]) VALUES (2, N'Salida')
GO
SET IDENTITY_INSERT [dbo].[Tipo_Movimiento] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  View [dbo].[vw_InsumoUltimoMovimiento]    Script Date: 17/11/2025 17:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER VIEW [dbo].[vw_InsumoUltimoMovimiento]
AS
SELECT 
    i.ID_Insumo, 
    ti.Descripcion AS TipoInsumo, 
    i.Nombre, 
    i.CantidadPorUnidad, 
    i.StockActual, 
    i.StockMinimo, 
    i.PrecioUnitario, 
    m.Cantidad AS CantidadMovimiento, 
    m.Fecha, 
    tm.Descripcion AS TipoMovimiento, 
    c.Descripcion_Color
FROM dbo.Insumo AS i
LEFT JOIN dbo.Movimiento_Stock AS m ON m.ID_Insumo = i.ID_Insumo
LEFT JOIN dbo.Tipo_Movimiento AS tm ON m.ID_TipoMovimiento = tm.ID_TipoMovimiento
INNER JOIN dbo.Tipo_Insumo AS ti ON i.ID_TipoInsumo = ti.ID_TipoInsumo
INNER JOIN dbo.Color AS c ON i.ID_Color = c.ID_Color;
GO
/****** Object:  Index [IX_Cliente]    Script Date: 17/11/2025 17:33:28 ******/
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [IX_Cliente] UNIQUE NONCLUSTERED 
(
	[Contacto_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Detalle_Pedido] ADD  CONSTRAINT [DF__Detalle_P__Preci__17036CC0]  DEFAULT ((0)) FOR [PrecioUnitario]
GO
ALTER TABLE [dbo].[Insumo] ADD  CONSTRAINT [DF__Insumo__StockAct__05D8E0BE]  DEFAULT ((0)) FOR [StockActual]
GO
ALTER TABLE [dbo].[Insumo] ADD  CONSTRAINT [DF__Insumo__StockMin__06CD04F7]  DEFAULT ((0)) FOR [StockMinimo]
GO
ALTER TABLE [dbo].[Movimiento_Stock] ADD  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[Notificacion_Stock] ADD  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[Pedidos] ADD  CONSTRAINT [DF_Pedidos_pagoAdelanto_pedido]  DEFAULT ((0)) FOR [pagoAdelanto_pedido]
GO
ALTER TABLE [dbo].[Personalizacion] ADD  DEFAULT ((0)) FOR [PrecioUnitario]
GO
ALTER TABLE [dbo].[Insumo]  WITH CHECK ADD  CONSTRAINT [FK_Insumo_TipoInsumo] FOREIGN KEY([ID_TipoInsumo])
REFERENCES [dbo].[Tipo_Insumo] ([ID_TipoInsumo])
GO
ALTER TABLE [dbo].[Insumo] CHECK CONSTRAINT [FK_Insumo_TipoInsumo]
GO
ALTER TABLE [dbo].[Movimiento_Stock]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoStock_Insumo] FOREIGN KEY([ID_Insumo])
REFERENCES [dbo].[Insumo] ([ID_Insumo])
GO
ALTER TABLE [dbo].[Movimiento_Stock] CHECK CONSTRAINT [FK_MovimientoStock_Insumo]
GO
ALTER TABLE [dbo].[Movimiento_Stock]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoStock_Pedido] FOREIGN KEY([ID_Pedido])
REFERENCES [dbo].[Pedidos] ([ID_pedido])
GO
ALTER TABLE [dbo].[Movimiento_Stock] CHECK CONSTRAINT [FK_MovimientoStock_Pedido]
GO
ALTER TABLE [dbo].[Movimiento_Stock]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoStock_Tipo] FOREIGN KEY([ID_TipoMovimiento])
REFERENCES [dbo].[Tipo_Movimiento] ([ID_TipoMovimiento])
GO
ALTER TABLE [dbo].[Movimiento_Stock] CHECK CONSTRAINT [FK_MovimientoStock_Tipo]
GO
ALTER TABLE [dbo].[Notificacion_Stock]  WITH CHECK ADD  CONSTRAINT [FK_NotificacionStock_Insumo] FOREIGN KEY([ID_Insumo])
REFERENCES [dbo].[Insumo] ([ID_Insumo])
GO
ALTER TABLE [dbo].[Notificacion_Stock] CHECK CONSTRAINT [FK_NotificacionStock_Insumo]
GO
ALTER TABLE [dbo].[Pago_Adelantado]  WITH CHECK ADD  CONSTRAINT [FK_PagoAdelantado_Pedido] FOREIGN KEY([ID_Pedido])
REFERENCES [dbo].[Pedidos] ([ID_pedido])
GO
ALTER TABLE [dbo].[Pago_Adelantado] CHECK CONSTRAINT [FK_PagoAdelantado_Pedido]
GO
ALTER TABLE [dbo].[Personalizacion]  WITH CHECK ADD  CONSTRAINT [FK_Personalizacion_Detalle] FOREIGN KEY([ID_Detalle])
REFERENCES [dbo].[Detalle_Pedido] ([ID_Detalle])
GO
ALTER TABLE [dbo].[Personalizacion] CHECK CONSTRAINT [FK_Personalizacion_Detalle]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contacto_Cliente' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cliente', @level2type=N'CONSTRAINT',@level2name=N'IX_Cliente'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[19] 4[38] 3[23] 2) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1[50] 4[25] 3) )"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
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
         Configuration = "(H (1[69] 4) )"
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
      ActivePaneConfig = 1
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -120
         Left = 0
      End
      Begin Tables = 
         Begin Table = "p"
            Begin Extent = 
               Top = 247
               Left = 48
               Bottom = 544
               Right = 317
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "cli"
            Begin Extent = 
               Top = 247
               Left = 365
               Bottom = 425
               Right = 588
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "emp"
            Begin Extent = 
               Top = 247
               Left = 636
               Bottom = 478
               Right = 861
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "d"
            Begin Extent = 
               Top = 247
               Left = 909
               Bottom = 476
               Right = 1134
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "t"
            Begin Extent = 
               Top = 247
               Left = 1182
               Bottom = 366
               Right = 1392
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "per"
            Begin Extent = 
               Top = 366
               Left = 1182
               Bottom = 594
               Right = 1417
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "pa"
            Begin Extent = 
               Top = 518
               Left = 815
               Bottom = 709
               Right = 1089
            End
            DisplayFlags = 280
            TopColumn' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_PedidosCompleto'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' = 0
         End
         Begin Table = "pr"
            Begin Extent = 
               Top = 495
               Left = 480
               Bottom = 614
               Right = 690
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Estado_Pedido"
            Begin Extent = 
               Top = 548
               Left = 48
               Bottom = 667
               Right = 335
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
      PaneHidden = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 33
         Width = 284
         Width = 1080
         Width = 2052
         Width = 2052
         Width = 1716
         Width = 2064
         Width = 1980
         Width = 1464
         Width = 1668
         Width = 2412
         Width = 1740
         Width = 1728
         Width = 1752
         Width = 1800
         Width = 1860
         Width = 2052
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1668
         Width = 1200
         Width = 1320
         Width = 1836
         Width = 2028
         Width = 2100
         Width = 1200
         Width = 1968
         Width = 2052
         Width = 2280
         Width = 1200
         Width = 2136
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 3756
         Alias = 2340
         Table = 1368
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1356
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_PedidosCompleto'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_PedidosCompleto'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[68] 4[6] 2[3] 3) )"
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
         Begin Table = "i"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 291
               Right = 273
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "m"
            Begin Extent = 
               Top = 0
               Left = 431
               Bottom = 163
               Right = 657
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tm"
            Begin Extent = 
               Top = 194
               Left = 421
               Bottom = 313
               Right = 647
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ti"
            Begin Extent = 
               Top = 306
               Left = 133
               Bottom = 425
               Right = 327
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Color"
            Begin Extent = 
               Top = 127
               Left = 705
               Bottom = 246
               Right = 920
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
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
        ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_InsumoUltimoMovimiento'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' Output = 720
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_InsumoUltimoMovimiento'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_InsumoUltimoMovimiento'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[15] 3) )"
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
         Begin Table = "u"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
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
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 2112
         Width = 1584
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_UsuariosExternos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_UsuariosExternos'
GO
USE [master]
GO
ALTER DATABASE [TextControl] SET  READ_WRITE 
GO
