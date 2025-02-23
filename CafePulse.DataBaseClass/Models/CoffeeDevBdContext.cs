using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CafePulse.DataBaseClass.Models;

public partial class CoffeeDevBdContext : DbContext
{
    public CoffeeDevBdContext()
    {
    }

    public CoffeeDevBdContext(DbContextOptions<CoffeeDevBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BitLogErrore> BitLogErrores { get; set; }

    public virtual DbSet<CatEstatusPedido> CatEstatusPedidos { get; set; }

    public virtual DbSet<CatGenero> CatGeneros { get; set; }

    public virtual DbSet<CatRol> CatRols { get; set; }

    public virtual DbSet<CatTipoEntrega> CatTipoEntregas { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ShaggyMR\\SQLEXPRESS01;Database=CoffeeDevBD;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BitLogErrore>(entity =>
        {
            entity.HasKey(e => e.Iderror).HasName("PK__Bit_LogE__00D5F30A436CAC53");

            entity.ToTable("Bit_LogErrores");

            entity.Property(e => e.Iderror).HasColumnName("IDERROR");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.FechaError).HasColumnName("FECHA_ERROR");
        });

        modelBuilder.Entity<CatEstatusPedido>(entity =>
        {
            entity.HasKey(e => e.Idestatusproducto).HasName("PK__Cat_Esta__86D90921E3AD522E");

            entity.ToTable("Cat_Estatus_Pedido");

            entity.Property(e => e.Idestatusproducto).HasColumnName("IDESTATUSPRODUCTO");
            entity.Property(e => e.EstatusPedido)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("ESTATUS_PEDIDO");
        });

        modelBuilder.Entity<CatGenero>(entity =>
        {
            entity.HasKey(e => e.Idgenero).HasName("PK__Cat_Gene__7C4578F3C5FA997B");

            entity.ToTable("Cat_Genero");

            entity.Property(e => e.Idgenero).HasColumnName("IDGENERO");
            entity.Property(e => e.Genero)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("GENERO");
        });

        modelBuilder.Entity<CatRol>(entity =>
        {
            entity.HasKey(e => e.Idrol).HasName("PK__Cat_Rol__A686519E763C8F5F");

            entity.ToTable("Cat_Rol");

            entity.Property(e => e.Idrol).HasColumnName("IDROL");
            entity.Property(e => e.Rol)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("ROL");
        });

        modelBuilder.Entity<CatTipoEntrega>(entity =>
        {
            entity.HasKey(e => e.Idtipoentrega).HasName("PK__Cat_Tipo__81807C1919B99094");

            entity.ToTable("Cat_Tipo_Entrega");

            entity.Property(e => e.Idtipoentrega).HasColumnName("IDTIPOENTREGA");
            entity.Property(e => e.TipoEntrega)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("TIPO_ENTREGA");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente).HasName("PK__Cliente__1EA344C2E52643B6");

            entity.ToTable("Cliente");

            entity.Property(e => e.Idcliente).HasColumnName("IDCLIENTE");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDO");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.NumeroTelefonico)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NUMERO_TELEFONICO");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USUARIO");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.Idinventario).HasName("PK__Inventar__488470F674348545");

            entity.ToTable("Inventario");

            entity.Property(e => e.Idinventario).HasColumnName("IDINVENTARIO");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Idproductomenu).HasName("PK__Menu__68C739ED66D29B57");

            entity.ToTable("Menu");

            entity.Property(e => e.Idproductomenu).HasColumnName("IDPRODUCTOMENU");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PRECIO");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PRODUCTO");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Idpedido).HasName("PK__Pedidos__769F9E4E19E6B737");

            entity.Property(e => e.Idpedido).HasColumnName("IDPEDIDO");
            entity.Property(e => e.HoraPedido).HasColumnName("HORA_PEDIDO");
            entity.Property(e => e.Idcliente).HasColumnName("IDCLIENTE");
            entity.Property(e => e.Idcompra).HasColumnName("IDCOMPRA");
            entity.Property(e => e.Idestatuspedido).HasColumnName("IDESTATUSPEDIDO");
            entity.Property(e => e.Idtipoentrega).HasColumnName("IDTIPOENTREGA");
            entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.Idcliente)
                .HasConstraintName("FK_IDCLIENTE");

            entity.HasOne(d => d.IdcompraNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.Idcompra)
                .HasConstraintName("FK_IDCOMPRA");

            entity.HasOne(d => d.IdestatuspedidoNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.Idestatuspedido)
                .HasConstraintName("FK_IDESTATUSPEDIDO");

            entity.HasOne(d => d.IdtipoentregaNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.Idtipoentrega)
                .HasConstraintName("FK_IDTIPOENTREGA");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("FK_IDUSUARIO");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Idcompra).HasName("PK__Ticket__DC4C123A115034B1");

            entity.ToTable("Ticket");

            entity.Property(e => e.Idcompra).HasColumnName("IDCOMPRA");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.Idproductomenu).HasColumnName("IDPRODUCTOMENU");

            entity.HasOne(d => d.IdproductomenuNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.Idproductomenu)
                .HasConstraintName("FK_IDPRODUCTOMENU");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__Usuarios__98242AA9A1CC5821");

            entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDO");
            //entity.Property(e => e.Contrasenahash).HasColumnName("CONTRASENAHASH");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.FechaNacimiento).HasColumnName("FECHA_NACIMIENTO");
            entity.Property(e => e.Idgenero).HasColumnName("IDGENERO");
            entity.Property(e => e.Idrol).HasColumnName("IDROL");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USUARIO");

            entity.HasOne(d => d.IdgeneroNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Idgenero)
                .HasConstraintName("FK_IDGENERO");

            entity.HasOne(d => d.IdrolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Idrol)
                .HasConstraintName("FK_IDROL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
