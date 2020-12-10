create database pacotedeviagens;
use pacotedeviagens;

create table usuario(
idUsuario int not null primary key auto_increment,
nomeUsuario varchar(255),
dtNascimento date,
login varchar(80),
senha varchar(80),
tipo char(1)
);

create table pacote(
idPacote int not null primary key auto_increment,
nomePacote varchar(255),
origem varchar(255),
destino varchar(255),
atrativos varchar(255),
saida date,
retorno date
);
select * from usuario;

select * from pacote;