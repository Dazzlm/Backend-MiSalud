using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend_MiSalud.Models;

public partial class MiSaludContext : DbContext
{
    public MiSaludContext()
    {
    }

    public MiSaludContext(DbContextOptions<MiSaludContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrator> Administrators { get; set; }

    public virtual DbSet<Diagnosis> Diagnoses { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<MedicalAppointment> MedicalAppointments { get; set; }

    public virtual DbSet<MedicalExamination> MedicalExaminations { get; set; }

    public virtual DbSet<MedicalHistory> MedicalHistories { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Recommendation> Recommendations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
           .SetBasePath(AppContext.BaseDirectory)
           .AddJsonFile("appsettings.json", optional: false)
           .Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("CadenaSQL"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.HasKey(e => e.IdAdministrador).HasName("PK__Administ__0FE822AA3259F27C");

            entity.ToTable("Administrator");

            entity.Property(e => e.IdAdministrador).HasColumnName("id_administrador");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .HasColumnName("correo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.PasswordAdministrator)
                .HasMaxLength(100)
                .HasColumnName("password_Administrator");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Diagnosis>(entity =>
        {
            entity.HasKey(e => e.IdDiagnostico).HasName("PK__Diagnosi__1384B745290F3966");

            entity.ToTable("Diagnosis");

            entity.Property(e => e.IdDiagnostico).HasColumnName("id_diagnostico");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaDiagnostico).HasColumnName("fecha_diagnostico");
            entity.Property(e => e.IdHistorial).HasColumnName("id_historial");

            entity.HasOne(d => d.IdHistorialNavigation).WithMany(p => p.Diagnoses)
                .HasForeignKey(d => d.IdHistorial)
                .HasConstraintName("FK__Diagnosis__id_hi__412EB0B6");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.IdDoctor).HasName("PK__Doctor__34D8A3054C5F3242");

            entity.ToTable("Doctor");

            entity.HasIndex(e => e.Rethus, "UQ__Doctor__F4E7FF5755D956CD").IsUnique();

            entity.Property(e => e.IdDoctor).HasColumnName("id_doctor");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(100)
                .HasColumnName("especialidad");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .HasColumnName("nombre_completo");
            entity.Property(e => e.PasswordDoctor)
                .HasMaxLength(100)
                .HasColumnName("password_Doctor");
            entity.Property(e => e.Rethus).HasColumnName("rethus");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<MedicalAppointment>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("PK__MedicalA__6AEC3C0912C121F5");

            entity.ToTable("MedicalAppointment");

            entity.Property(e => e.IdCita).HasColumnName("id_cita");
            entity.Property(e => e.DescriptionAppointment)
                .HasMaxLength(150)
                .HasColumnName("descriptionAppointment");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCita).HasColumnName("fecha_cita");
            entity.Property(e => e.HoraCita).HasColumnName("hora_cita");
            entity.Property(e => e.HoraFinalizacion).HasColumnName("Hora_finalizacion");
            entity.Property(e => e.IdDoctor).HasColumnName("id_doctor");
            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            entity.Property(e => e.PlaceAppointment)
                .HasMaxLength(150)
                .HasColumnName("placeAppointment");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .HasColumnName("title");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.MedicalAppointments)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__MedicalAp__id_do__4AB81AF0");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.MedicalAppointments)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__MedicalAp__id_pa__49C3F6B7");
        });

        modelBuilder.Entity<MedicalExamination>(entity =>
        {
            entity.HasKey(e => e.IdExamen).HasName("PK__MedicalE__D16A231DF5E6874B");

            entity.ToTable("MedicalExamination");

            entity.Property(e => e.IdExamen).HasColumnName("id_examen");
            entity.Property(e => e.FechaExamen).HasColumnName("fecha_examen");
            entity.Property(e => e.IdHistorial).HasColumnName("id_historial");
            entity.Property(e => e.Resultado)
                .HasColumnType("text")
                .HasColumnName("resultado");
            entity.Property(e => e.TipoExamen)
                .HasMaxLength(255)
                .HasColumnName("tipo_examen");

            entity.HasOne(d => d.IdHistorialNavigation).WithMany(p => p.MedicalExaminations)
                .HasForeignKey(d => d.IdHistorial)
                .HasConstraintName("FK__MedicalEx__id_hi__3E52440B");
        });

        modelBuilder.Entity<MedicalHistory>(entity =>
        {
            entity.HasKey(e => e.IdHistorial).HasName("PK__MedicalH__76E6C5020475C805");

            entity.ToTable("MedicalHistory");

            entity.HasIndex(e => e.IdPaciente, "UQ__MedicalH__2C2C72BAF6DCCAE0").IsUnique();

            entity.Property(e => e.IdHistorial).HasColumnName("id_historial");
            entity.Property(e => e.AntecedentesFamiliares)
                .HasColumnType("text")
                .HasColumnName("antecedentes_familiares");
            entity.Property(e => e.AntecedentesPersonales)
                .HasColumnType("text")
                .HasColumnName("antecedentes_personales");
            entity.Property(e => e.Aseguradora)
                .HasMaxLength(100)
                .HasColumnName("aseguradora");
            entity.Property(e => e.ContactoEmergencia)
                .HasMaxLength(255)
                .HasColumnName("contacto_emergencia");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.EstadoCivil)
                .HasMaxLength(50)
                .HasColumnName("estado_civil");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .HasColumnName("genero");
            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            entity.Property(e => e.NombrePaciente)
                .HasMaxLength(100)
                .HasColumnName("nombre_paciente");
            entity.Property(e => e.Ocupacion)
                .HasMaxLength(100)
                .HasColumnName("ocupacion");
            entity.Property(e => e.TipoSangre)
                .HasMaxLength(10)
                .HasColumnName("tipo_sangre");

            entity.HasOne(d => d.IdPacienteNavigation).WithOne(p => p.MedicalHistory)
                .HasForeignKey<MedicalHistory>(d => d.IdPaciente)
                .HasConstraintName("FK__MedicalHi__id_pa__3B75D760");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__Patient__2C2C72BB592B463E");

            entity.ToTable("Patient");

            entity.HasIndex(e => e.Correo, "UQ__Patient__2A586E0B8556AC7E").IsUnique();

            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .HasColumnName("nombre_completo");
            entity.Property(e => e.PasswordPatient)
                .HasMaxLength(100)
                .HasColumnName("password_patient");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Recommendation>(entity =>
        {
            entity.HasKey(e => e.IdRecomendacion).HasName("PK__Recommen__BC44D3FDA4117CC5");

            entity.ToTable("Recommendation");

            entity.Property(e => e.IdRecomendacion).HasColumnName("id_recomendacion");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaRecomendacion).HasColumnName("fecha_recomendacion");
            entity.Property(e => e.IdHistorial).HasColumnName("id_historial");

            entity.HasOne(d => d.IdHistorialNavigation).WithMany(p => p.Recommendations)
                .HasForeignKey(d => d.IdHistorial)
                .HasConstraintName("FK__Recommend__id_hi__440B1D61");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
