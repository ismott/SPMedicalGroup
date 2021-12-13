Create Database SPMedicalGroup_israel;
Go

Use SPMedicalGroup_israel;
Go

Create Table TipoUsuario(
TipoUsuarioID Tinyint Primary Key Identity,
NomeTipo Varchar(15) Not Null 
);
Go

Create Table TipoMedico(
TipoMedicoID Tinyint Primary Key Identity,
NomeTipo Varchar(55) Not Null
);
Go

Create Table Clinica(
CLinicaID Smallint Primary Key Identity,
Endereco Varchar(250) Not Null,
HorarioAbertura Time Not Null,
HorarioFechamento Time Not Null,
CNPJ Varchar(14) Not Null,
NomeFantasia Varchar(50) Not Null,
RazaoSocial Varchar(300) Not Null
);
Go

Create Table Situacao(
SituacaoID Tinyint Primary Key  Identity,
NomeSituacao Varchar(20) Not Null
);
Go

Create Table Usuario(
UsuarioID Int Primary Key Identity,
TipoUsuarioID Tinyint Foreign Key References TipoUsuario(TipoUsuarioID),
Email VarChar(256) Not Null,
Senha Varchar(10) Not Null Check(len(senha) >= 5)
);
Go

Create Table Paciente(
PacienteID Int Primary Key Identity,
UsuarioID Int Foreign Key References Usuario(UsuarioID),
Nome Varchar(25) Not Null,
DataNacimento Date Not Null,
Telefone VarChar(15),
RG VarChar(15) Not Null,
Cpf Char(14) Unique Not Null, 
Endereco Varchar(200) Not Null
);
Go

Create Table Medico(
MedicoID Smallint Primary Key Identity,
ClinicaID Smallint Foreign Key References Clinica(ClinicaID),
UsuarioID Int Foreign Key References Usuario(UsuarioID),
TipoMedicoID Tinyint Foreign Key References TipoMedico(TipoMedicoID),
Crm Varchar(20) Not Null,
Nome Varchar(25) Not Null
);
Go

Create Table Consulta(
ConsultaID Bigint Primary Key Identity,
MedicoID Smallint Foreign Key References Medico(MedicoID),
SituacaoID Tinyint Foreign Key References Situacao(SituacaoID) Default(1) Not Null,
PacienteID Int Foreign Key References Paciente(PacienteID),
DataConsulta DateTime Not Null,
Descricao Varchar(250) 
);
Go

Drop Table Consulta;
Go