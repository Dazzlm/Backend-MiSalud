﻿// <auto-generated />
using System;
using Backend_MiSalud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend_MiSalud.Migrations
{
    [DbContext(typeof(MiSaludContext))]
    partial class MiSaludContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backend_MiSalud.Models.Administrator", b =>
                {
                    b.Property<int>("IdAdministrador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_administrador");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAdministrador"));

                    b.Property<string>("Apellido")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("apellido");

                    b.Property<string>("Correo")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("correo");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nombre");

                    b.Property<string>("PasswordAdministrator")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("password_Administrator");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("telefono");

                    b.HasKey("IdAdministrador")
                        .HasName("PK__Administ__0FE822AA3259F27C");

                    b.ToTable("Administrator", (string)null);
                });

            modelBuilder.Entity("Backend_MiSalud.Models.Diagnosis", b =>
                {
                    b.Property<int>("IdDiagnostico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_diagnostico");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDiagnostico"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("text")
                        .HasColumnName("descripcion");

                    b.Property<DateOnly?>("FechaDiagnostico")
                        .HasColumnType("date")
                        .HasColumnName("fecha_diagnostico");

                    b.Property<int?>("IdHistorial")
                        .HasColumnType("int")
                        .HasColumnName("id_historial");

                    b.HasKey("IdDiagnostico")
                        .HasName("PK__Diagnosi__1384B745290F3966");

                    b.HasIndex("IdHistorial");

                    b.ToTable("Diagnosis", (string)null);
                });

            modelBuilder.Entity("Backend_MiSalud.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_doctor");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDoctor"));

                    b.Property<string>("Correo")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("correo");

                    b.Property<string>("Direccion")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("direccion");

                    b.Property<string>("Especialidad")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("especialidad");

                    b.Property<string>("NombreCompleto")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nombre_completo");

                    b.Property<string>("PasswordDoctor")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("password_Doctor");

                    b.Property<int?>("Rethus")
                        .HasColumnType("int")
                        .HasColumnName("rethus");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("telefono");

                    b.HasKey("IdDoctor")
                        .HasName("PK__Doctor__34D8A3054C5F3242");

                    b.HasIndex(new[] { "Rethus" }, "UQ__Doctor__F4E7FF5755D956CD")
                        .IsUnique()
                        .HasFilter("[rethus] IS NOT NULL");

                    b.ToTable("Doctor", (string)null);
                });

            modelBuilder.Entity("Backend_MiSalud.Models.MedicalAppointment", b =>
                {
                    b.Property<int>("IdCita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_cita");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCita"));

                    b.Property<string>("DescriptionAppointment")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("descriptionAppointment");

                    b.Property<string>("Estado")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("estado");

                    b.Property<DateOnly?>("FechaCita")
                        .HasColumnType("date")
                        .HasColumnName("fecha_cita");

                    b.Property<TimeOnly?>("HoraCita")
                        .HasColumnType("time")
                        .HasColumnName("hora_cita");

                    b.Property<TimeOnly?>("HoraFinalizacion")
                        .HasColumnType("time")
                        .HasColumnName("Hora_finalizacion");

                    b.Property<int?>("IdDoctor")
                        .HasColumnType("int")
                        .HasColumnName("id_doctor");

                    b.Property<int?>("IdPaciente")
                        .HasColumnType("int")
                        .HasColumnName("id_paciente");

                    b.Property<string>("PlaceAppointment")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("placeAppointment");

                    b.Property<string>("Title")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("title");

                    b.HasKey("IdCita")
                        .HasName("PK__MedicalA__6AEC3C0912C121F5");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPaciente");

                    b.ToTable("MedicalAppointment", (string)null);
                });

            modelBuilder.Entity("Backend_MiSalud.Models.MedicalExamination", b =>
                {
                    b.Property<int>("IdExamen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_examen");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdExamen"));

                    b.Property<DateOnly?>("FechaExamen")
                        .HasColumnType("date")
                        .HasColumnName("fecha_examen");

                    b.Property<int?>("IdHistorial")
                        .HasColumnType("int")
                        .HasColumnName("id_historial");

                    b.Property<string>("Resultado")
                        .HasColumnType("text")
                        .HasColumnName("resultado");

                    b.Property<string>("TipoExamen")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("tipo_examen");

                    b.HasKey("IdExamen")
                        .HasName("PK__MedicalE__D16A231DF5E6874B");

                    b.HasIndex("IdHistorial");

                    b.ToTable("MedicalExamination", (string)null);
                });

            modelBuilder.Entity("Backend_MiSalud.Models.MedicalHistory", b =>
                {
                    b.Property<int>("IdHistorial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_historial");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHistorial"));

                    b.Property<string>("AntecedentesFamiliares")
                        .HasColumnType("text")
                        .HasColumnName("antecedentes_familiares");

                    b.Property<string>("AntecedentesPersonales")
                        .HasColumnType("text")
                        .HasColumnName("antecedentes_personales");

                    b.Property<string>("Aseguradora")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("aseguradora");

                    b.Property<string>("ContactoEmergencia")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("contacto_emergencia");

                    b.Property<int?>("Edad")
                        .HasColumnType("int")
                        .HasColumnName("edad");

                    b.Property<string>("EstadoCivil")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("estado_civil");

                    b.Property<DateOnly?>("FechaNacimiento")
                        .HasColumnType("date")
                        .HasColumnName("fecha_nacimiento");

                    b.Property<string>("Genero")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("genero");

                    b.Property<int?>("IdPaciente")
                        .HasColumnType("int")
                        .HasColumnName("id_paciente");

                    b.Property<string>("NombrePaciente")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nombre_paciente");

                    b.Property<string>("Ocupacion")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ocupacion");

                    b.Property<string>("TipoSangre")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("tipo_sangre");

                    b.HasKey("IdHistorial")
                        .HasName("PK__MedicalH__76E6C5020475C805");

                    b.HasIndex(new[] { "IdPaciente" }, "UQ__MedicalH__2C2C72BAF6DCCAE0")
                        .IsUnique()
                        .HasFilter("[id_paciente] IS NOT NULL");

                    b.ToTable("MedicalHistory", (string)null);
                });

            modelBuilder.Entity("Backend_MiSalud.Models.Patient", b =>
                {
                    b.Property<int>("IdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_paciente");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPaciente"));

                    b.Property<string>("Correo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("correo");

                    b.Property<string>("Direccion")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("direccion");

                    b.Property<string>("NombreCompleto")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nombre_completo");

                    b.Property<string>("PasswordPatient")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("password_patient");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("telefono");

                    b.HasKey("IdPaciente")
                        .HasName("PK__Patient__2C2C72BB592B463E");

                    b.HasIndex(new[] { "Correo" }, "UQ__Patient__2A586E0B8556AC7E")
                        .IsUnique()
                        .HasFilter("[correo] IS NOT NULL");

                    b.ToTable("Patient", (string)null);
                });

            modelBuilder.Entity("Backend_MiSalud.Models.Recommendation", b =>
                {
                    b.Property<int>("IdRecomendacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_recomendacion");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRecomendacion"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("text")
                        .HasColumnName("descripcion");

                    b.Property<DateOnly?>("FechaRecomendacion")
                        .HasColumnType("date")
                        .HasColumnName("fecha_recomendacion");

                    b.Property<int?>("IdHistorial")
                        .HasColumnType("int")
                        .HasColumnName("id_historial");

                    b.HasKey("IdRecomendacion")
                        .HasName("PK__Recommen__BC44D3FDA4117CC5");

                    b.HasIndex("IdHistorial");

                    b.ToTable("Recommendation", (string)null);
                });

            modelBuilder.Entity("Backend_MiSalud.Models.Diagnosis", b =>
                {
                    b.HasOne("Backend_MiSalud.Models.MedicalHistory", "IdHistorialNavigation")
                        .WithMany("Diagnoses")
                        .HasForeignKey("IdHistorial")
                        .HasConstraintName("FK__Diagnosis__id_hi__412EB0B6");

                    b.Navigation("IdHistorialNavigation");
                });

            modelBuilder.Entity("Backend_MiSalud.Models.MedicalAppointment", b =>
                {
                    b.HasOne("Backend_MiSalud.Models.Doctor", "IdDoctorNavigation")
                        .WithMany("MedicalAppointments")
                        .HasForeignKey("IdDoctor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__MedicalAp__id_do__4AB81AF0");

                    b.HasOne("Backend_MiSalud.Models.Patient", "IdPacienteNavigation")
                        .WithMany("MedicalAppointments")
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__MedicalAp__id_pa__49C3F6B7");

                    b.Navigation("IdDoctorNavigation");

                    b.Navigation("IdPacienteNavigation");
                });

            modelBuilder.Entity("Backend_MiSalud.Models.MedicalExamination", b =>
                {
                    b.HasOne("Backend_MiSalud.Models.MedicalHistory", "IdHistorialNavigation")
                        .WithMany("MedicalExaminations")
                        .HasForeignKey("IdHistorial")
                        .HasConstraintName("FK__MedicalEx__id_hi__3E52440B");

                    b.Navigation("IdHistorialNavigation");
                });

            modelBuilder.Entity("Backend_MiSalud.Models.MedicalHistory", b =>
                {
                    b.HasOne("Backend_MiSalud.Models.Patient", "IdPacienteNavigation")
                        .WithOne("MedicalHistory")
                        .HasForeignKey("Backend_MiSalud.Models.MedicalHistory", "IdPaciente")
                        .HasConstraintName("FK__MedicalHi__id_pa__3B75D760");

                    b.Navigation("IdPacienteNavigation");
                });

            modelBuilder.Entity("Backend_MiSalud.Models.Recommendation", b =>
                {
                    b.HasOne("Backend_MiSalud.Models.MedicalHistory", "IdHistorialNavigation")
                        .WithMany("Recommendations")
                        .HasForeignKey("IdHistorial")
                        .HasConstraintName("FK__Recommend__id_hi__440B1D61");

                    b.Navigation("IdHistorialNavigation");
                });

            modelBuilder.Entity("Backend_MiSalud.Models.Doctor", b =>
                {
                    b.Navigation("MedicalAppointments");
                });

            modelBuilder.Entity("Backend_MiSalud.Models.MedicalHistory", b =>
                {
                    b.Navigation("Diagnoses");

                    b.Navigation("MedicalExaminations");

                    b.Navigation("Recommendations");
                });

            modelBuilder.Entity("Backend_MiSalud.Models.Patient", b =>
                {
                    b.Navigation("MedicalAppointments");

                    b.Navigation("MedicalHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
