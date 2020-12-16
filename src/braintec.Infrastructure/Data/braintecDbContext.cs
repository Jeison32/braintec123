using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using braintec.Infrastructure;

namespace braintec.Infrastructure.Data
{
    public partial class braintecDbContext : DbContext
    {
        public braintecDbContext()
        {
        }

        public braintecDbContext(DbContextOptions<braintecDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estadoordenpag> Estadoordenpag { get; set; }
        public virtual DbSet<Estadoordenped> Estadoordenped { get; set; }
        public virtual DbSet<Estadoordenserv> Estadoordenserv { get; set; }
        public virtual DbSet<Estadousuarioemp> Estadousuarioemp { get; set; }
        public virtual DbSet<Menuusuario> Menuusuario { get; set; }
        public virtual DbSet<Ordenpagoc> Ordenpagoc { get; set; }
        public virtual DbSet<Ordenpedido> Ordenpedido { get; set; }
        public virtual DbSet<Ordenservicio> Ordenservicio { get; set; }
        public virtual DbSet<Tcategoria> Tcategoria { get; set; }
        public virtual DbSet<Tdocumento> Tdocumento { get; set; }
        public virtual DbSet<Templeado> Templeado { get; set; }
        public virtual DbSet<Testadoservicio> Testadoservicio { get; set; }
        public virtual DbSet<Tinventario> Tinventario { get; set; }
        public virtual DbSet<Tprioridad> Tprioridad { get; set; }
        public virtual DbSet<Tproveedor> Tproveedor { get; set; }
        public virtual DbSet<Troles> Troles { get; set; }
        public virtual DbSet<Tservicio> Tservicio { get; set; }
        public virtual DbSet<Tusuario> Tusuario { get; set; }
        public virtual DbSet<Tvehiculo> Tvehiculo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("database=dbbraintecpro;server=localhost;port=3306;user id=root;password=");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estadoordenpag>(entity =>
            {
                entity.HasKey(e => e.Idestordenpag)
                    .HasName("PRIMARY");

                entity.ToTable("estadoordenpag");

                entity.Property(e => e.Idestordenpag)
                    .HasColumnName("idestordenpag")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Estadoordenpag1)
                    .HasColumnName("estadoordenpag")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Estadoordenped>(entity =>
            {
                entity.HasKey(e => e.Idestordenped)
                    .HasName("PRIMARY");

                entity.ToTable("estadoordenped");

                entity.Property(e => e.Idestordenped)
                    .HasColumnName("idestordenped")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Estadoordenped1)
                    .HasColumnName("estadoordenped")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Estadoordenserv>(entity =>
            {
                entity.HasKey(e => e.Idestordenserv)
                    .HasName("PRIMARY");

                entity.ToTable("estadoordenserv");

                entity.Property(e => e.Idestordenserv)
                    .HasColumnName("idestordenserv")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Estadoordenserv1)
                    .HasColumnName("estadoordenserv")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Estadousuarioemp>(entity =>
            {
                entity.HasKey(e => e.Idestadou)
                    .HasName("PRIMARY");

                entity.ToTable("estadousuarioemp");

                entity.Property(e => e.Idestadou)
                    .HasColumnName("idestadou")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Estadousuario)
                    .HasColumnName("estadousuario")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Menuusuario>(entity =>
            {
                entity.HasKey(e => e.Mcodigo)
                    .HasName("PRIMARY");

                entity.ToTable("menuusuario");

                entity.HasIndex(e => e.Codigosubmenu)
                    .HasName("menuusuario_ibfk_2");

                entity.HasIndex(e => e.Idroles)
                    .HasName("idroles");

                entity.Property(e => e.Mcodigo)
                    .HasColumnName("mcodigo")
                    .HasColumnType("tinyint(11)");

                entity.Property(e => e.Codigosubmenu)
                    .HasColumnName("codigosubmenu")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Idroles)
                    .HasColumnName("idroles")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Mnombre)
                    .HasColumnName("mnombre")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Tipomenu)
                    .HasColumnName("tipomenu")
                    .HasColumnType("enum('S','I')")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.CodigosubmenuNavigation)
                    .WithMany(p => p.InverseCodigosubmenuNavigation)
                    .HasForeignKey(d => d.Codigosubmenu)
                    .HasConstraintName("menuusuario_ibfk_2");

                entity.HasOne(d => d.IdrolesNavigation)
                    .WithMany(p => p.Menuusuario)
                    .HasForeignKey(d => d.Idroles)
                    .HasConstraintName("menuusuario_ibfk_1");
            });

            modelBuilder.Entity<Ordenpagoc>(entity =>
            {
                entity.HasKey(e => e.Idordenpag)
                    .HasName("PRIMARY");

                entity.ToTable("ordenpagoc");

                entity.HasIndex(e => e.Idcasoservicio)
                    .HasName("idcasoservicio");

                entity.HasIndex(e => e.Idestordenpag)
                    .HasName("idestordenpag");

                entity.HasIndex(e => e.Idopedido)
                    .HasName("idopedido");

                entity.HasIndex(e => e.Numdocumento)
                    .HasName("numdocumento");

                entity.Property(e => e.Idordenpag)
                    .HasColumnName("idordenpag")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fechaorden)
                    .HasColumnName("fechaorden")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Idcasoservicio)
                    .HasColumnName("idcasoservicio")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Idestordenpag)
                    .HasColumnName("idestordenpag")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Idopedido)
                    .HasColumnName("idopedido")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Numdocumento)
                    .HasColumnName("numdocumento")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdcasoservicioNavigation)
                    .WithMany(p => p.Ordenpagoc)
                    .HasForeignKey(d => d.Idcasoservicio)
                    .HasConstraintName("ordenpagoc_ibfk_3");

                entity.HasOne(d => d.IdestordenpagNavigation)
                    .WithMany(p => p.Ordenpagoc)
                    .HasForeignKey(d => d.Idestordenpag)
                    .HasConstraintName("ordenpagoc_ibfk_4");

                entity.HasOne(d => d.IdopedidoNavigation)
                    .WithMany(p => p.Ordenpagoc)
                    .HasForeignKey(d => d.Idopedido)
                    .HasConstraintName("ordenpagoc_ibfk_2");

                entity.HasOne(d => d.NumdocumentoNavigation)
                    .WithMany(p => p.Ordenpagoc)
                    .HasForeignKey(d => d.Numdocumento)
                    .HasConstraintName("ordenpagoc_ibfk_1");
            });

            modelBuilder.Entity<Ordenpedido>(entity =>
            {
                entity.HasKey(e => e.Idopedido)
                    .HasName("PRIMARY");

                entity.ToTable("ordenpedido");

                entity.HasIndex(e => e.Idestordenped)
                    .HasName("idestordenped");

                entity.HasIndex(e => e.Numdocumento)
                    .HasName("numdocumento");

                entity.HasIndex(e => e.Refrepuesto)
                    .HasName("refrepuesto");

                entity.Property(e => e.Idopedido)
                    .HasColumnName("idopedido")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fpedido)
                    .HasColumnName("fpedido")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Idestordenped)
                    .HasColumnName("idestordenped")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Numdocumento)
                    .HasColumnName("numdocumento")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Refrepuesto)
                    .HasColumnName("refrepuesto")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdestordenpedNavigation)
                    .WithMany(p => p.Ordenpedido)
                    .HasForeignKey(d => d.Idestordenped)
                    .HasConstraintName("ordenpedido_ibfk_3");

                entity.HasOne(d => d.NumdocumentoNavigation)
                    .WithMany(p => p.Ordenpedido)
                    .HasForeignKey(d => d.Numdocumento)
                    .HasConstraintName("ordenpedido_ibfk_1");

                entity.HasOne(d => d.RefrepuestoNavigation)
                    .WithMany(p => p.Ordenpedido)
                    .HasForeignKey(d => d.Refrepuesto)
                    .HasConstraintName("ordenpedido_ibfk_2");
            });

            modelBuilder.Entity<Ordenservicio>(entity =>
            {
                entity.HasKey(e => e.Idcasoservicio)
                    .HasName("PRIMARY");

                entity.ToTable("ordenservicio");

                entity.HasIndex(e => e.Idestordenserv)
                    .HasName("idestordenserv");

                entity.HasIndex(e => e.Idprioridad)
                    .HasName("idprioridad");

                entity.HasIndex(e => e.Idservicio)
                    .HasName("idservicio");

                entity.HasIndex(e => e.Numdocumento)
                    .HasName("numdocumento");

                entity.HasIndex(e => e.Placavehiculo)
                    .HasName("ordenservicio_ibfk_5");

                entity.Property(e => e.Idcasoservicio)
                    .HasColumnName("idcasoservicio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idestordenserv)
                    .HasColumnName("idestordenserv")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Idprioridad)
                    .HasColumnName("idprioridad")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Idservicio)
                    .HasColumnName("idservicio")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Numdocumento)
                    .HasColumnName("numdocumento")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Placavehiculo)
                    .HasColumnName("placavehiculo")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Resumenservicio)
                    .HasColumnName("resumenservicio")
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdestordenservNavigation)
                    .WithMany(p => p.Ordenservicio)
                    .HasForeignKey(d => d.Idestordenserv)
                    .HasConstraintName("ordenservicio_ibfk_3");

                entity.HasOne(d => d.IdprioridadNavigation)
                    .WithMany(p => p.Ordenservicio)
                    .HasForeignKey(d => d.Idprioridad)
                    .HasConstraintName("ordenservicio_ibfk_4");

                entity.HasOne(d => d.IdservicioNavigation)
                    .WithMany(p => p.Ordenservicio)
                    .HasForeignKey(d => d.Idservicio)
                    .HasConstraintName("ordenservicio_ibfk_2");

                entity.HasOne(d => d.NumdocumentoNavigation)
                    .WithMany(p => p.Ordenservicio)
                    .HasForeignKey(d => d.Numdocumento)
                    .HasConstraintName("ordenservicio_ibfk_1");

                entity.HasOne(d => d.PlacavehiculoNavigation)
                    .WithMany(p => p.Ordenservicio)
                    .HasForeignKey(d => d.Placavehiculo)
                    .HasConstraintName("ordenservicio_ibfk_5");
            });

            modelBuilder.Entity<Tcategoria>(entity =>
            {
                entity.HasKey(e => e.Idcategoria)
                    .HasName("PRIMARY");

                entity.ToTable("tcategoria");

                entity.Property(e => e.Idcategoria)
                    .HasColumnName("idcategoria")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Categoriarepuesto)
                    .HasColumnName("categoriarepuesto")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tdocumento>(entity =>
            {
                entity.HasKey(e => e.Iddocumento)
                    .HasName("PRIMARY");

                entity.ToTable("tdocumento");

                entity.Property(e => e.Iddocumento)
                    .HasColumnName("iddocumento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tipodocumento)
                    .HasColumnName("tipodocumento")
                    .HasMaxLength(25)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Templeado>(entity =>
            {
                entity.HasKey(e => e.Idempleado)
                    .HasName("PRIMARY");

                entity.ToTable("templeado");

                entity.HasIndex(e => e.Idestadou)
                    .HasName("idestadou");

                entity.HasIndex(e => e.Idroles)
                    .HasName("idroles");

                entity.HasIndex(e => e.Numdocumento)
                    .HasName("numdocumento");

                entity.Property(e => e.Idempleado)
                    .HasColumnName("idempleado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cargoempleado)
                    .HasColumnName("cargoempleado")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Contrasenaempleado)
                    .HasColumnName("contrasenaempleado")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Fcreacion)
                    .HasColumnName("fcreacion")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Fultimoacceso)
                    .HasColumnName("fultimoacceso")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Idestadou)
                    .HasColumnName("idestadou")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Idroles)
                    .HasColumnName("idroles")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Numdocumento)
                    .HasColumnName("numdocumento")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Usuarioempleado)
                    .HasColumnName("usuarioempleado")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdestadouNavigation)
                    .WithMany(p => p.Templeado)
                    .HasForeignKey(d => d.Idestadou)
                    .HasConstraintName("templeado_ibfk_3");

                entity.HasOne(d => d.IdrolesNavigation)
                    .WithMany(p => p.Templeado)
                    .HasForeignKey(d => d.Idroles)
                    .HasConstraintName("templeado_ibfk_2");

                entity.HasOne(d => d.NumdocumentoNavigation)
                    .WithMany(p => p.Templeado)
                    .HasForeignKey(d => d.Numdocumento)
                    .HasConstraintName("templeado_ibfk_1");
            });

            modelBuilder.Entity<Testadoservicio>(entity =>
            {
                entity.HasKey(e => e.Idestadoserv)
                    .HasName("PRIMARY");

                entity.ToTable("testadoservicio");

                entity.Property(e => e.Idestadoserv)
                    .HasColumnName("idestadoserv")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tipoestado)
                    .HasColumnName("tipoestado")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tinventario>(entity =>
            {
                entity.HasKey(e => e.Refrepuesto)
                    .HasName("PRIMARY");

                entity.ToTable("tinventario");

                entity.HasIndex(e => e.Idcategoria)
                    .HasName("idcategoria");

                entity.HasIndex(e => e.Idproveedor)
                    .HasName("idproveedor");

                entity.Property(e => e.Refrepuesto)
                    .HasColumnName("refrepuesto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cantidadexistente)
                    .HasColumnName("cantidadexistente")
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Idcategoria)
                    .HasColumnName("idcategoria")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Idproveedor)
                    .HasColumnName("idproveedor")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Marcarepuesto)
                    .HasColumnName("marcarepuesto")
                    .HasMaxLength(60)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nombrerepuesto)
                    .HasColumnName("nombrerepuesto")
                    .HasMaxLength(60)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Tarifarepuesto)
                    .HasColumnName("tarifarepuesto")
                    .HasColumnType("decimal(10,0)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.Tinventario)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("tinventario_ibfk_1");

                entity.HasOne(d => d.IdproveedorNavigation)
                    .WithMany(p => p.Tinventario)
                    .HasForeignKey(d => d.Idproveedor)
                    .HasConstraintName("tinventario_ibfk_2");
            });

            modelBuilder.Entity<Tprioridad>(entity =>
            {
                entity.HasKey(e => e.Idprioridad)
                    .HasName("PRIMARY");

                entity.ToTable("tprioridad");

                entity.Property(e => e.Idprioridad)
                    .HasColumnName("idprioridad")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tipoprioridad)
                    .HasColumnName("tipoprioridad")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tproveedor>(entity =>
            {
                entity.HasKey(e => e.Idproveedor)
                    .HasName("PRIMARY");

                entity.ToTable("tproveedor");

                entity.Property(e => e.Idproveedor)
                    .HasColumnName("idproveedor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Correoproveedor)
                    .HasColumnName("correoproveedor")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Percontactoproveedor)
                    .HasColumnName("percontactoproveedor")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Rsocialproveedor)
                    .HasColumnName("rsocialproveedor")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Telefonoproveedor)
                    .HasColumnName("telefonoproveedor")
                    .HasColumnType("bigint(12)")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Troles>(entity =>
            {
                entity.HasKey(e => e.Idroles)
                    .HasName("PRIMARY");

                entity.ToTable("troles");

                entity.Property(e => e.Idroles)
                    .HasColumnName("idroles")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tiporol)
                    .HasColumnName("tiporol")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tservicio>(entity =>
            {
                entity.HasKey(e => e.Idservicio)
                    .HasName("PRIMARY");

                entity.ToTable("tservicio");

                entity.Property(e => e.Idservicio)
                    .HasColumnName("idservicio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descservicio)
                    .HasColumnName("descservicio")
                    .HasMaxLength(60)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nombreservicio)
                    .HasColumnName("nombreservicio")
                    .HasMaxLength(60)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Tarifaservicio)
                    .HasColumnName("tarifaservicio")
                    .HasColumnType("decimal(10,0)")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tusuario>(entity =>
            {
                entity.HasKey(e => e.Numdocumento)
                    .HasName("PRIMARY");

                entity.ToTable("tusuario");

                entity.HasIndex(e => e.Iddocumento)
                    .HasName("iddocumento");

                entity.Property(e => e.Numdocumento)
                    .HasColumnName("numdocumento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellido)
                    .HasColumnName("apellido")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Iddocumento)
                    .HasColumnName("iddocumento")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasColumnType("bigint(15)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IddocumentoNavigation)
                    .WithMany(p => p.Tusuario)
                    .HasForeignKey(d => d.Iddocumento)
                    .HasConstraintName("tusuario_ibfk_1");
            });

            modelBuilder.Entity<Tvehiculo>(entity =>
            {
                entity.HasKey(e => e.Placavehiculo)
                    .HasName("PRIMARY");

                entity.ToTable("tvehiculo");

                entity.HasIndex(e => e.Numdocumento)
                    .HasName("numdocumento");

                entity.Property(e => e.Placavehiculo)
                    .HasColumnName("placavehiculo")
                    .HasMaxLength(8);

                entity.Property(e => e.Aniovehiculo)
                    .HasColumnName("aniovehiculo")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Cilindrajevehiculo)
                    .HasColumnName("cilindrajevehiculo")
                    .HasColumnType("int(5)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Kilometrajevehiculo)
                    .HasColumnName("kilometrajevehiculo")
                    .HasColumnType("int(20)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Marcavehiculo)
                    .HasColumnName("marcavehiculo")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Modelovehiculo)
                    .HasColumnName("modelovehiculo")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Numdocumento)
                    .HasColumnName("numdocumento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Trasmisionvehiculo)
                    .HasColumnName("trasmisionvehiculo")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.NumdocumentoNavigation)
                    .WithMany(p => p.Tvehiculo)
                    .HasForeignKey(d => d.Numdocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tvehiculo_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
