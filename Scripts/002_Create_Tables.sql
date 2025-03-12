-- ************************************************************************************************
-- Autor: Abraham Reyes Jimenez
-- Fecha de Creacion: 25 de Octubre del 2024
-- Motivo del Cambio: Creacion de Tablas
-- Comentario o Consideracion: N/A
-- ************************************************************************************************

USE CoffeeDevBD;

PRINT '---> INICIA CREACION DE CATALOGOS <---';

        IF OBJECT_ID('dbo.Cat_Genero', 'U') IS NULL
        BEGIN
            CREATE TABLE Cat_Genero(
                IDGENERO INT PRIMARY KEY IDENTITY (1,1),
                GENERO VARCHAR(25) NOT NULL
            );
        END

        IF OBJECT_ID('dbo.Cat_Rol', 'U') IS NULL
        BEGIN
            CREATE TABLE Cat_Rol(
                IDROL INT PRIMARY KEY IDENTITY (1,1),
                ROL VARCHAR(25) NOT NULL
            );
        END

        IF OBJECT_ID('dbo.Cat_Tipo_Entrega', 'U') IS NULL
        BEGIN
            CREATE TABLE Cat_Tipo_Entrega(
                IDTIPOENTREGA INT PRIMARY KEY IDENTITY (1,1),
                TIPO_ENTREGA VARCHAR(25) NOT NULL
            );
        END

        IF OBJECT_ID('dbo.Cat_Estatus_Pedido', 'U') IS NULL
        BEGIN
            CREATE TABLE Cat_Estatus_Pedido(
                IDESTATUSPRODUCTO INT PRIMARY KEY IDENTITY (1,1),
                ESTATUS_PEDIDO VARCHAR(25) NOT NULL
            );
        END

PRINT '---> FIN DE CREACION DE CATALOGOS <---';

PRINT '---> INICIA CREACION DE TABLAS PRIMARIAS <---';


    IF OBJECT_ID('dbo.Usuarios', 'U') IS NULL
    BEGIN
        CREATE TABLE Usuarios(
            IDUSUARIO INT PRIMARY KEY IDENTITY (1,1),
            NOMBRE VARCHAR(50),
            APELLIDO VARCHAR(50),
            FECHA_NACIMIENTO DATE,
            IDGENERO INT,
            IDROL INT,
            TELEFONO VARCHAR(20),
            EMAIL VARCHAR(50),
            USUARIO VARCHAR(50),
            CONTRASENA VARCHAR(50),

            CONSTRAINT FK_IDGENERO FOREIGN KEY (IDGENERO) REFERENCES Cat_Genero(IDGENERO),
            CONSTRAINT FK_IDROL FOREIGN KEY (IDROL) REFERENCES Cat_Rol(IDROL)
        );
    END

    IF OBJECT_ID('dbo.Inventario', 'U') IS NULL
    BEGIN
        CREATE TABLE Inventario(
            IDINVENTARIO INT PRIMARY KEY IDENTITY (1,1),
            NOMBRE VARCHAR(50),
            CANTIDAD INT
        );
    END

    IF OBJECT_ID('dbo.MENU', 'U') IS NULL
        BEGIN
            CREATE TABLE Menu(
                IDPRODUCTOMENU INT PRIMARY KEY IDENTITY (1,1),
                NOMBRE_PRODUCTO VARCHAR(50),
                CANTIDAD DECIMAL
            );
    END

    IF OBJECT_ID('dbo.Ticket', 'U') IS NULL
        BEGIN
            CREATE TABLE Ticket(
                IDCOMPRA INT PRIMARY KEY IDENTITY (1,1),
                IDPRODUCTOMENU INT,
                CANTIDAD INT,

                CONSTRAINT FK_IDPRODUCTOMENU FOREIGN KEY (IDPRODUCTOMENU) REFERENCES MENU(IDPRODUCTOMENU)
            );
        END


    IF OBJECT_ID('dbo.Cliente', 'U') IS NULL
        BEGIN
            CREATE TABLE Cliente(
                IDCLIENTE INT PRIMARY KEY IDENTITY (1,1),
                NOMBRE VARCHAR(50),
                APELLIDO VARCHAR(50),
                USUARIO VARCHAR (50),
                NUMERO_TELEFONICO VARCHAR(50),
                DIRECCION VARCHAR(50)
            );
        END


    IF OBJECT_ID('dbo.Pedidos', 'U') IS NULL
        BEGIN
            CREATE TABLE Pedidos(
                IDPEDIDO INT PRIMARY KEY IDENTITY (1,1),
                IDCOMPRA INT,
                HORA_PEDIDO DATE,
                IDCLIENTE INT,
                IDTIPOENTREGA INT, 
                IDUSUARIO INT,
                IDESTATUSPEDIDO INT,

                CONSTRAINT FK_IDCOMPRA FOREIGN KEY (IDCOMPRA) REFERENCES Ticket(IDCOMPRA),
                CONSTRAINT FK_IDCLIENTE FOREIGN KEY (IDCLIENTE) REFERENCES Cliente(IDCLIENTE),
                CONSTRAINT FK_IDTIPOENTREGA FOREIGN KEY (IDTIPOENTREGA) REFERENCES Cat_Tipo_Entrega(IDTIPOENTREGA),

                CONSTRAINT FK_IDUSUARIO FOREIGN KEY (IDUSUARIO) REFERENCES Usuarios(IDUSUARIO),
                CONSTRAINT FK_IDESTATUSPEDIDO FOREIGN KEY (IDESTATUSPEDIDO) REFERENCES Cat_Estatus_Pedido(IDESTATUSPRODUCTO)
            );
        END

PRINT '---> FIN DE CREACION DE TABLAS PRIMARIAS <---';
