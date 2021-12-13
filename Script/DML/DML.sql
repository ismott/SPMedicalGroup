Use SPMedicalGroup_israel;
Go

Insert Into TipoMedico (NomeTipo)
Values ('Acupuntura'), ('Anestesiologia'), ('Angiologia'), ('Cardiologia'), ('Cirurgia Cardiovascular'), ('Cirurgia da M�o'), ('Cirurgia do Aparelho Digestivo'), ('Cirurgia Geral'), ('Cirurgia Pedi�trica'), ('Cirurgia Pl�stica'), ('Cirurgia Tor�cica'), ('Cirurgia Vascular'), ('Dermatologia'), ('Radioterapia'), ('Urologia'), ('Pediatria'), ('Psiquiatria');
Go

Insert Into TipoUsuario (NomeTipo)
Values ('ADM'), ('Medico'), ('Paciente');
Go

Insert Into Clinica (Endereco, HorarioAbertura, HorarioFechamento, CNPJ, NomeFantasia, RazaoSocial)
Values ('Av. Bar�o Limeira, 532, S�o Paulo, SP', '05:00:00', '05:00:00', '86400902000130', 'Clinica Possarle', 'SP Medical Group');
Go

Insert Into Situacao (NomeSituacao)
Values ('Agendada'), ('Realizada'), ('Cancelada');
Go

Insert Into Usuario (TipoUsuarioID, Email, Senha)
Values (2, 'ricardo.lemos@spmedicalgroup.com.br', '12345'), (2, 'roberto.possarle@spmedicalgroup.com.br', '32145'), (2, 'helena.souza@spmedicalgroup.com.br', '12345'), (3, 'ligia@gmail.com', '21314'), (3, 'alexandre@gmail.com', '12345'), (3, 'fernando@gmail.com', '32124'), (3, 'henrique@gmail.com', '12331'), (3, 'joao@hotmail.com', '12323'), (3, 'bruno@gmail.com', '123231'), (3, 'mariana@outlook.com', '2132131'), (1, 'andrey.ad@hotmail.com.br', '13245');
Go

Insert Into Paciente (UsuarioID, Nome, DataNacimento, Telefone, RG, Cpf, Endereco)
--Values (5, 'Ligia', '10/13/1983', '11 3456-7654', '435225435', '94839859000', 'Rua Estado de Israel 240,�S�o Paulo, Estado de S�o Paulo, 04022-000'), (6, 'Alexandre', '7/23/2001', '11 98765-6543', '32654345-7', '73556944057', 'Av. Paulista, 1578 - Bela Vista, S�o Paulo - SP, 01310-200'), (7, 'Fernando', '10/10/1978', '11 97208-4453', '54636525-3', '16839338002', 'Av. Ibirapuera - Indian�polis, 2927,  S�o Paulo - SP, 04029-200'), (8, 'Henrique', '10/13/1985', '11 3456-6543', '54366362-5', '14332654765', 'R. Vit�ria, 120 - Vila Sao Jorge, Barueri - SP, 06402-030'), (9, 'Jo�o', '8/27/1975', '11 7656-6377', '53254444-1', '91305348010', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeir�o Pires - SP, 09405-380'), (10, 'Bruno', '3/21/1972', '11 95436-8769', '54566266-7', '79799299004', 'Alameda dos Arapan�s, 945 - Indian�polis, S�o Paulo - SP, 04524-001'), (11, 'Mariana', '03/05/2018', NULL, '54566266-8', '13771913039', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');
Values (5, 'Ligia', '13/10/1983', '11 3456-7654', '435225435', '94839859000', 'Rua Estado de Israel 240,�S�o Paulo, Estado de S�o Paulo, 04022-000'), (6, 'Alexandre', '23/7/2001', '11 98765-6543', '32654345-7', '73556944057', 'Av. Paulista, 1578 - Bela Vista, S�o Paulo - SP, 01310-200'), (7, 'Fernando', '10/10/1978', '11 97208-4453', '54636525-3', '16839338002', 'Av. Ibirapuera - Indian�polis, 2927,  S�o Paulo - SP, 04029-200'), (8, 'Henrique', '13/10/1985', '11 3456-6543', '54366362-5', '14332654765', 'R. Vit�ria, 120 - Vila Sao Jorge, Barueri - SP, 06402-030'), (9, 'Jo�o', '27/8/1975', '11 7656-6377', '53254444-1', '91305348010', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeir�o Pires - SP, 09405-380'), (10, 'Bruno', '21/3/1972', '11 95436-8769', '54566266-7', '79799299004', 'Alameda dos Arapan�s, 945 - Indian�polis, S�o Paulo - SP, 04524-001'), (11, 'Mariana', '05/03/2018', NULL, '54566266-8', '13771913039', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');
Go

Insert Into Medico (ClinicaID, UsuarioID, TipoMedicoID, Crm, Nome)
Values (1, 2, 2, '54356-SP', 'Ricardo Lemos'), (1, 3, 17, '53452-SP', 'Roberto Possarle'), (1, 4, 16, '65463-SP', 'Helena Strada');
Go

Insert Into Consulta (MedicoID, SituacaoID, PacienteID, DataConsulta, Descricao)
--Values (1, 2, 7, '01/20/20 15:00', Null), (2, 1, 3, '01/06/2020  10:00:00', Null), (2, 2, 7, '02/07/2020 11:00', Null), (2, 2, 2, '02/06/2018 10:00', Null), (1, 3, 4, '02/07/2019 11:00', Null), (3, 1, 7, '03/08/2020 15:00', Null), (1, 1, 4, '03/09/2020 11:00', Null);
Values (1, 2, 7, '20/01/20 15:00', Null), (2, 1, 3, '06/01/2020  10:00:00', Null), (2, 2, 7, '07/02/2020 11:00', Null), (2, 2, 2, '06/02/2018 10:00', Null), (1, 3, 4, '07/02/2019 11:00', Null), (3, 1, 7, '08/03/2020 15:00', Null), (1, 1, 4, '09/03/2020 11:00', Null);
Go