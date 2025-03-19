create database CLINICAUH

use CLINICAUH
go

CREATE TABLE Pacientes (
    Cedula VARCHAR(20) PRIMARY KEY,
    Nombre VARCHAR(100),
    PrimerApellido VARCHAR(100),
    FechaNacimiento DATE,
    Edad INT,
    Medico VARCHAR(100),
    Telefono VARCHAR(20),
    Especialidad VARCHAR(100),
    NumeroConsulta VARCHAR(50),
    FechaAtencion DATE,
    HoraAtencion TIME,
    Consultorio VARCHAR(50)
);
