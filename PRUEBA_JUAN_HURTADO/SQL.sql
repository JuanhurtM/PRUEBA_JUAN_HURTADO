﻿CREATE DATABASE RRESULTADOS

USE RESULTADOS

CREATE TABLE RESULTADOS (

Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
Nombre VARCHAR(50),
Pais VARCHAR(50),
Arranque INT,
Envio INT

);

INSERT INTO RESULTADOS VALUES ('Carlos Alviz','AUS',134,177),('Andres Sabogal','CHN',130,180)

Select * from RESULTADOS