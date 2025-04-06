using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_MiSalud.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    id_administrador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    correo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    password_Administrator = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Administ__0FE822AA3259F27C", x => x.id_administrador);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    id_doctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rethus = table.Column<int>(type: "int", nullable: true),
                    nombre_completo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    especialidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    correo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    password_Doctor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Doctor__34D8A3054C5F3242", x => x.id_doctor);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    id_paciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cedula = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    nombre_completo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    password_patient = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Patient__2C2C72BB592B463E", x => x.id_paciente);
                });

            migrationBuilder.CreateTable(
                name: "MedicalAppointment",
                columns: table => new
                {
                    id_cita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_paciente = table.Column<int>(type: "int", nullable: true),
                    id_doctor = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    descriptionAppointment = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    placeAppointment = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    fecha_cita = table.Column<DateOnly>(type: "date", nullable: true),
                    hora_cita = table.Column<TimeOnly>(type: "time", nullable: true),
                    Hora_finalizacion = table.Column<TimeOnly>(type: "time", nullable: true),
                    estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MedicalA__6AEC3C0912C121F5", x => x.id_cita);
                    table.ForeignKey(
                        name: "FK__MedicalAp__id_do__4AB81AF0",
                        column: x => x.id_doctor,
                        principalTable: "Doctor",
                        principalColumn: "id_doctor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__MedicalAp__id_pa__49C3F6B7",
                        column: x => x.id_paciente,
                        principalTable: "Patient",
                        principalColumn: "id_paciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistory",
                columns: table => new
                {
                    id_historial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_paciente = table.Column<int>(type: "int", nullable: true),
                    nombre_paciente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    edad = table.Column<int>(type: "int", nullable: true),
                    genero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fecha_nacimiento = table.Column<DateOnly>(type: "date", nullable: true),
                    estado_civil = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ocupacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    aseguradora = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    tipo_sangre = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    contacto_emergencia = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    antecedentes_personales = table.Column<string>(type: "text", nullable: true),
                    antecedentes_familiares = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MedicalH__76E6C5020475C805", x => x.id_historial);
                    table.ForeignKey(
                        name: "FK__MedicalHi__id_pa__3B75D760",
                        column: x => x.id_paciente,
                        principalTable: "Patient",
                        principalColumn: "id_paciente");
                });

            migrationBuilder.CreateTable(
                name: "Diagnosis",
                columns: table => new
                {
                    id_diagnostico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_historial = table.Column<int>(type: "int", nullable: true),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    fecha_diagnostico = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Diagnosi__1384B745290F3966", x => x.id_diagnostico);
                    table.ForeignKey(
                        name: "FK__Diagnosis__id_hi__412EB0B6",
                        column: x => x.id_historial,
                        principalTable: "MedicalHistory",
                        principalColumn: "id_historial");
                });

            migrationBuilder.CreateTable(
                name: "MedicalExamination",
                columns: table => new
                {
                    id_examen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_historial = table.Column<int>(type: "int", nullable: true),
                    tipo_examen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    resultado = table.Column<string>(type: "text", nullable: true),
                    fecha_examen = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MedicalE__D16A231DF5E6874B", x => x.id_examen);
                    table.ForeignKey(
                        name: "FK__MedicalEx__id_hi__3E52440B",
                        column: x => x.id_historial,
                        principalTable: "MedicalHistory",
                        principalColumn: "id_historial");
                });

            migrationBuilder.CreateTable(
                name: "Recommendation",
                columns: table => new
                {
                    id_recomendacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_historial = table.Column<int>(type: "int", nullable: true),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    fecha_recomendacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Recommen__BC44D3FDA4117CC5", x => x.id_recomendacion);
                    table.ForeignKey(
                        name: "FK__Recommend__id_hi__440B1D61",
                        column: x => x.id_historial,
                        principalTable: "MedicalHistory",
                        principalColumn: "id_historial");
                });
            migrationBuilder.Sql(@"
                INSERT INTO Patient(nombre_completo, cedula, direccion, telefono, correo, password_patient) VALUES
                ('Juan Pérez','1023377521', 'Calle Falsa 123, Ciudad', '555-1234', 'juan.perez@yopmail.com', 'Juan123!'),
                ('María González','1013278529', 'Avenida Siempre Viva 456, Ciudad', '555-5678', 'maria.gonzalez@yopmail.com', 'Maria123!'),
                ('Carlos López','1124357425','Boulevard Los Olivos 789, Ciudad', '555-8765', 'carlos.lopez@yopmail.com', 'Carlos123!'),
                ('Ana Martínez','2023379854','Calle Luna 101, Ciudad', '555-4321', 'ana.martinez@yopmail.com', 'Ana123!'),
                ('Luis Rodríguez','1924327526','Avenida Sol 202, Ciudad', '555-6543', 'luis.rodriguez@yopmail.com', 'Luis123!'),
                ('Sofía Hernández','1783377527','Calle Estrella 303, Ciudad', '555-3456', 'sofia.hernandez@yopmail.com', 'Sofia123!'),
                ('Miguel Díaz','1025325529', 'Boulevard Jardines 404, Ciudad', '555-7890', 'miguel.diaz@yopmail.com', 'Miguel123!'),
                ('Elena Ruiz','1024358522','Avenida Bosques 505, Ciudad', '555-0987', 'elena.ruiz@yopmail.com', 'Elena123!'),
                ('Jorge Morales','1212377523','Calle Ríos 606, Ciudad', '555-6789', 'jorge.morales@yopmail.com', 'Jorge123!'),
                ('Lucía Castro','1129387550','Boulevard Montañas 707, Ciudad', '555-9876', 'lucia.castro@yopmail.com', 'Lucia123!');


                INSERT INTO MedicalHistory (id_paciente, nombre_paciente, edad, genero, fecha_nacimiento, estado_civil, ocupacion, aseguradora, tipo_sangre, contacto_emergencia, antecedentes_personales, antecedentes_familiares) VALUES
                (1, 'Juan Pérez', 30, 'Masculino', '1993-05-15', 'Soltero', 'Ingeniero', 'Seguros XYZ', 'O+', 'María Pérez - 555-1111', 'Ninguno', 'Diabetes en abuelo'),
                (2, 'María González', 25, 'Femenino', '1998-08-22', 'Casada', 'Diseñadora', 'Seguros ABC', 'A-', 'Carlos González - 555-2222', 'Asma', 'Hipertensión en madre'),
                (3, 'Carlos López', 40, 'Masculino', '1983-02-10', 'Divorciado', 'Abogado', 'Seguros DEF', 'B+', 'Ana López - 555-3333', 'Alergias', 'Cáncer en padre'),
                (4, 'Ana Martínez', 35, 'Femenino', '1988-11-30', 'Casada', 'Médico', 'Seguros GHI', 'AB+', 'Luis Martínez - 555-4444', 'Ninguno', 'Ninguno'),
                (5, 'Luis Rodríguez', 28, 'Masculino', '1995-07-19', 'Soltero', 'Programador', 'Seguros JKL', 'O-', 'Sofía Rodríguez - 555-5555', 'Ninguno', 'Ninguno'),
                (6, 'Sofía Hernández', 50, 'Femenino', '1973-04-25', 'Viuda', 'Enfermera', 'Seguros MNO', 'A+', 'Miguel Hernández - 555-6666', 'Hipertensión', 'Diabetes en madre'),
                (7, 'Miguel Díaz', 45, 'Masculino', '1978-09-12', 'Casado', 'Arquitecto', 'Seguros PQR', 'B-', 'Elena Díaz - 555-7777', 'Ninguno', 'Ninguno'),
                (8, 'Elena Ruiz', 33, 'Femenino', '1990-03-05', 'Soltera', 'Psicóloga', 'Seguros STU', 'AB-', 'Jorge Ruiz - 555-8888', 'Depresión', 'Ninguno'),
                (9, 'Jorge Morales', 60, 'Masculino', '1963-12-20', 'Casado', 'Empresario', 'Seguros VWX', 'O+', 'Lucía Morales - 555-9999', 'Diabetes', 'Ninguno'),
                (10, 'Lucía Castro', 22, 'Femenino', '2001-06-14', 'Soltera', 'Estudiante', 'Seguros YZ', 'A-', 'Miguel Castro - 555-0000', 'Ninguno', 'Ninguno');
                INSERT INTO MedicalExamination(id_historial, tipo_examen, resultado, fecha_examen) VALUES
                (1, 'Hemograma completo', 'Resultados normales', '2023-10-01'),
                (2, 'Radiografía de tórax', 'Sin hallazgos patológicos', '2023-10-02'),
                (3, 'Electrocardiograma', 'Ritmo sinusal normal', '2023-10-03'),
                (4, 'Prueba de glucosa', 'Niveles normales', '2023-10-04'),
                (5, 'Perfil lipídico', 'Colesterol elevado', '2023-10-05'),
                (6, 'Ecografía abdominal', 'Hígado y riñones normales', '2023-10-06'),
                (7, 'Prueba de función tiroidea', 'Resultados normales', '2023-10-07'),
                (8, 'Colonoscopía', 'Pólipos detectados', '2023-10-08'),
                (9, 'Resonancia magnética', 'Sin anomalías', '2023-10-09'),
                (10, 'Prueba de alergias', 'Alergia al polen detectada', '2023-10-10');
                INSERT INTO Diagnosis(id_historial, descripcion, fecha_diagnostico) VALUES
                (1, 'Hipertensión arterial', '2023-10-01'),
                (2, 'Asma leve', '2023-10-02'),
                (3, 'Alergias estacionales', '2023-10-03'),
                (4, 'Diabetes tipo 2', '2023-10-04'),
                (5, 'Colesterol alto', '2023-10-05'),
                (6, 'Artritis reumatoide', '2023-10-06'),
                (7, 'Depresión mayor', '2023-10-07'),
                (8, 'Cáncer de colon', '2023-10-08'),
                (9, 'Enfermedad de Parkinson', '2023-10-09'),
                (10, 'Alergia al polen', '2023-10-10');

                INSERT INTO Recommendation(id_historial, descripcion, fecha_recomendacion) VALUES
                (1, 'Reducir consumo de sal', '2023-10-01'),
                (2, 'Uso de inhalador según necesidad', '2023-10-02'),
                (3, 'Evitar exposición a alérgenos', '2023-10-03'),
                (4, 'Dieta baja en azúcares', '2023-10-04'),
                (5, 'Ejercicio regular y dieta saludable', '2023-10-05'),
                (6, 'Fisioterapia y medicación', '2023-10-06'),
                (7, 'Terapia psicológica y medicación', '2023-10-07'),
                (8, 'Cirugía y quimioterapia', '2023-10-08'),
                (9, 'Tratamiento farmacológico y terapia física', '2023-10-09'),
                (10, 'Uso de antihistamínicos', '2023-10-10');

                INSERT INTO Doctor (rethus, nombre_completo, especialidad, telefono, correo, direccion, password_Doctor) VALUES
                (123456, 'Dr. Alejandro Torres', 'Cardiología', '555-1111', 'alejandro.torres@yopmail.com', 'Calle Médicos 123, Ciudad', 'Alejandro123!'),
                (234567, 'Dra. Laura Méndez', 'Pediatría', '555-2222', 'laura.mendez@yopmail.com', 'Avenida Niños 456, Ciudad', 'Laura123!'),
                (345678, 'Dr. Roberto Sánchez', 'Dermatología', '555-3333', 'roberto.sanchez@yopmail.com', 'Boulevard Piel 789, Ciudad', 'Roberto123!'),
                (456789, 'Dra. Carmen Ruiz', 'Ginecología', '555-4444', 'carmen.ruiz@yopmail.com', 'Calle Mujeres 101, Ciudad', 'Carmen123!'),
                (567890, 'Dr. Javier López', 'Ortopedia', '555-5555', 'javier.lopez@yopmail.com', 'Avenida Huesos 202, Ciudad', 'Javier123!'),
                (678901, 'Dra. Patricia Díaz', 'Neurología', '555-6666', 'patricia.diaz@yopmail.com', 'Boulevard Cerebro 303, Ciudad', 'Patricia123!'),
                (789012, 'Dr. Manuel Castro', 'Psiquiatría', '555-7777', 'manuel.castro@yopmail.com', 'Calle Mente 404, Ciudad', 'Manuel123!'),
                (890123, 'Dra. Sofía Morales', 'Oncología', '555-8888', 'sofia.morales@yopmail.com', 'Avenida Cáncer 505, Ciudad', 'Sofia123!'),
                (901234, 'Dr. Ricardo Gómez', 'Endocrinología', '555-9999', 'ricardo.gomez@yopmail.com', 'Boulevard Hormonas 606, Ciudad', 'Ricardo123!'),
                (012345, 'Dra. Adriana Fernández', 'Oftalmología', '555-0000', 'adriana.fernandez@yopmail.com', 'Calle Ojos 707, Ciudad', 'Adriana123!');

                INSERT INTO MedicalAppointment (id_paciente, id_doctor, title, descriptionAppointment, placeAppointment, fecha_cita, hora_cita, Hora_finalizacion, estado) VALUES
                (1, 1, 'Consulta General', 'Revisión médica de rutina', 'Consultorio 101', '2023-10-15', '09:00', '09:30', 'Programada'),
                (2, 2, 'Consulta Pediátrica', 'Chequeo de niño sano', 'Consultorio 202', '2023-10-16', '10:00', '10:30', 'Programada'),
                (3, 3, 'Revisión Dermatológica', 'Evaluación de condición de piel', 'Consultorio 303', '2023-10-17', '11:00', '11:30', 'Programada'),
                (4, 4, 'Consulta Ginecológica', 'Chequeo ginecológico de rutina', 'Consultorio 404', '2023-10-18', '12:00', '12:30', 'Programada'),
                (5, 5, 'Evaluación Ortopédica', 'Revisión de dolor en articulaciones', 'Consultorio 505', '2023-10-19', '13:00', '13:30', 'Programada'),
                (6, 6, 'Consulta Neurológica', 'Evaluación de síntomas neurológicos', 'Consultorio 606', '2023-10-20', '14:00', '14:30', 'Programada'),
                (7, 7, 'Consulta Psiquiátrica', 'Consulta sobre salud mental', 'Consultorio 707', '2023-10-21', '15:00', '15:30', 'Programada'),
                (8, 8, 'Consulta Oncológica', 'Seguimiento de tratamiento', 'Consultorio 808', '2023-10-22', '16:00', '16:30', 'Programada'),
                (9, 9, 'Consulta Endocrinológica', 'Evaluación de desórdenes hormonales', 'Consultorio 909', '2023-10-23', '17:00', '17:30', 'Programada'),
                (10, 10, 'Consulta Oftalmológica', 'Revisión de la vista', 'Consultorio 1010', '2023-10-24', '18:00', '18:30', 'Programada');


                INSERT INTO Administrator(nombre, apellido, correo, telefono, password_Administrator) VALUES
                ('Carlos', 'Gómez', 'carlos.gomez@yopmail.com', '555-1111', 'Carlos123!'),
                ('María', 'López', 'maria.lopez@yopmail.com', '555-2222', 'Maria123!'),
                ('Juan', 'Martínez', 'juan.martinez@yopmail.com', '555-3333', 'Juan123!'),
                ('Ana', 'Rodríguez', 'ana.rodriguez@yopmail.com', '555-4444', 'Ana123!'),
                ('Luis', 'Hernández', 'luis.hernandez@yopmail.com', '555-5555', 'Luis123!'),
                ('Sofía', 'Díaz', 'sofia.diaz@yopmail.com', '555-6666', 'Sofia123!'),
                ('Miguel', 'Ruiz', 'miguel.ruiz@yopmail.com', '555-7777', 'Miguel123!'),
                ('Elena', 'Morales', 'elena.morales@yopmail.com', '555-8888', 'Elena123!'),
                ('Jorge', 'Castro', 'jorge.castro@yopmail.com', '555-9999', 'Jorge123!'),
                ('Lucía', 'Fernández', 'lucia.fernandez@yopmail.com', '555-0000', 'Lucia123!');
            ");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis_id_historial",
                table: "Diagnosis",
                column: "id_historial");

            migrationBuilder.CreateIndex(
                name: "UQ__Doctor__F4E7FF5755D956CD",
                table: "Doctor",
                column: "rethus",
                unique: true,
                filter: "[rethus] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAppointment_id_doctor",
                table: "MedicalAppointment",
                column: "id_doctor");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAppointment_id_paciente",
                table: "MedicalAppointment",
                column: "id_paciente");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExamination_id_historial",
                table: "MedicalExamination",
                column: "id_historial");

            migrationBuilder.CreateIndex(
                name: "UQ__MedicalH__2C2C72BAF6DCCAE0",
                table: "MedicalHistory",
                column: "id_paciente",
                unique: true,
                filter: "[id_paciente] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Patient__2A586E0B8556AC7E",
                table: "Patient",
                column: "correo",
                unique: true,
                filter: "[correo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Cedula",
                table: "Patient",
                column: "Cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recommendation_id_historial",
                table: "Recommendation",
                column: "id_historial");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "Diagnosis");

            migrationBuilder.DropTable(
                name: "MedicalAppointment");

            migrationBuilder.DropTable(
                name: "MedicalExamination");

            migrationBuilder.DropTable(
                name: "Recommendation");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "MedicalHistory");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
