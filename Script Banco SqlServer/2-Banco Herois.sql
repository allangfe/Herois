use Herois
go

Create table Nivel(
	Cod_Nivel int primary key identity,
	Descricao varchar(50) not null
)

Create table Habilidade(
	Cod_Habilidade int primary key identity,
	Caracteristica varchar(50) not null,
	Descricao varchar(500),
)

create table Editora (
	Cod_Editora int primary key identity,
	Nome varchar(50) not null
)

Create table Personagem(
	Cod_Personagem int primary key identity,
	Codinome varchar(50) not null,
	Nome varchar(50) not null,
	Descricao varchar(500) not null,
	Cod_Nivel int not null,
	Cod_Editora int not null,
	Foto varchar(150) null
)

Create table Personagem_Habilidade(
	Cod_Personagem_Habilidade int primary key identity,
	Cod_Personagem int not null,
	Cod_Habilidade int not null
)

alter table Personagem
add constraint fk_personagens_niveis foreign key (Cod_Nivel)
references Nivel

alter table Personagem
add constraint fk_personagens_editoras foreign key (Cod_Editora)
references Editora

alter table Personagem_Habilidade
add constraint fk_personagens_habilidades_personagens foreign key (Cod_Personagem)
references Personagem

alter table Personagem_Habilidade
add constraint fk_personagens_habilidades_habilidades foreign key (Cod_Habilidade)
references Habilidade



--------- dados iniciais ----------

INSERT INTO [dbo].[Nivel]([Descricao])
     VALUES 
			('Desconhecido'),
			('D'),
			('C'),
			('A'),
			('S'),
			('Perigo Dimensional')

INSERT INTO [dbo].[Habilidade]([Caracteristica],[Descricao])
     VALUES
           ('Estrategista', 'Capacidade de planejar cada passo, prever movimentos físicos e extrafísicos, preparação de terreno. Alto nível e diversos tipos de inteligência.'),
		   ('Investigador', 'Capacidade de investigar e analisar as menores evidências possíveis para chegar a verdade de um crime ou algum objetivo investigativo.'),
		   ('Velocista', 'Capacidade de se mover em alta velocidade, gamas de poderes referente a essa quebra de velocidade. Varia bastante dependendo do nível do velocista e suas capacidades.')

INSERT INTO [dbo].[Editora]([Nome])
     VALUES
           ('DC'),
		   ('Marvel'),
		   ('Shonen Jump')

----- Teste Personagem --------------

INSERT INTO [dbo].[Personagem]([Codinome],[Nome],[Descricao],[Cod_Nivel],[Cod_Editora],[Foto])
     VALUES
           ('Batman', 'Bruce Wayne', 'Bruce Wayne criou o Batman para causar medo no submundo de Gotham e para defender os inocentes. O uniforme e a maneira como age quando o usa tem o objetivo de intimidar seus adversários. Enquanto Bruce Wayne é despreocupado e irresponsável, Batman é frio, determinado e implacável.', 4, 1, ''),
		   ('Flash', 'Barry Allen', 'Barry Allen era funcionário da polícia científica, quando sofreu um acidente químico, sendo banhado por produtos químicos após seu laboratório ser atingido por um raio. Esse acidente fez que ele, assim como Flash Jay Garrick, fosse capaz de acessar e canalizar o poder vindo da Força da aceleracão sendo a partir desse momento, capaz de correr em velocidades altíssimas.', 5, 1, '')

INSERT INTO [dbo].[Personagem_Habilidade]([Cod_Personagem],[Cod_Habilidade])
     VALUES
           (1, 1),
		   (1, 2),
		   (2, 3)
		   
