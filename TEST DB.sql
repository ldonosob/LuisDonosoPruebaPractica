CREATE DATABASE TEST_LD
GO

USE TEST_LD
GO


CREATE TABLE USUARIO
(
	username	VARCHAR(10) PRIMARY KEY,
	password	VARCHAR(50) NOT NULL,
	nombre		VARCHAR(50) NOT NULL
)

CREATE TABLE ESTADO
(
	id				SMALLINT PRIMARY KEY,
	descripcion		VARCHAR(20)
)

CREATE TABLE TAREA
(
	id			INT			PRIMARY KEY IDENTITY,
	nombre		VARCHAR(50),
	estado_id		SMALLINT FOREIGN KEY REFERENCES ESTADO(id),
	descripcion	VARCHAR(500),
	usuario_id  VARCHAR(10) FOREIGN KEY REFERENCES USUARIO(username)
)



insert into usuario values('admin','1a1dc91c907325c69271ddf0c944bc72','Administrador de Sistemas')
insert into usuario values('ldonoso','1a1dc91c907325c69271ddf0c944bc72','Luis Donoso Báez')


INSERT INTO ESTADO VALUES(1,'NO RESUELTO')
INSERT INTO ESTADO VALUES(2,'RESUELTO')

insert into TAREA values('tarea 1', 1,'descripcion','ldonoso')


