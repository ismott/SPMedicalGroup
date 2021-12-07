Use SPMedicalGroup_israel;
Go

Select * From Consulta;
Go

Select * From Medico;
Go

Select * From Paciente;
Go

Select * From Usuario;
Go

Select * From Situacao;
Go

Select * From Paciente;
Go

Select * From Clinica;
Go

Select * From TipoUsuario;
Go

Select * From TipoMedico;
Go

Select Paciente.Nome [Nome do paciente], Medico.Nome [Nome do m�dico], DataConsulta [Data da consulta], NomeSituacao [situa��o] 
From Paciente Inner Join Consulta On Paciente.PacienteID = Consulta.PacienteID 
Inner Join Medico On Medico.MedicoID = Consulta.MedicoID 
Inner Join Situacao On Situacao.SituacaoID = Consulta.SituacaoID;
Go

Select count(UsuarioID) from Usuario;
Go

Select Convert(Varchar(10), DataConsulta, 103) From Consulta;
Go

Create Function MediQUant (@TituloEspc Varchar(50))
Returns Table As Return (
	Select @TituloEspc As MQ, Count(TipoMedico.NomeTipo) [Nume de medicos] From TipoMedico Where TipoMedico.NomeTipo Like '%' + @TituloEspc + '%'  
);
Go

Select * From MediQUant('Acupuntura');
Go

Create Procedure IdadePac @Idade Varchar(20) 
As Begin 
	Select Paciente.Nome, Datediff(Year, Paciente.DataNacimento, Getdate()) As Idade From Paciente Where Paciente.Nome = @Idade 
End;

Exec IdadePac 'Jo�o';
Go