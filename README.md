# Marlin Motors

Projeto final da matéria de lp3. Tema escolhido: loja de automóveis.

## Autores - 331

- Paulo Kenji
- Thiago César
- Ryan Salomão

## Comando para criar o banco de dados

```SQL
DROP DATABASE marlinmotors;

CREATE DATABASE marlinmotors;

USE marlinmotors;

CREATE TABLE Vendas(
    Id int NOT NULL PRIMARY KEY,
    TipoVeiculo varchar(25) NOT NULL,
    Marca varchar(25) NOT NULL,
    Modelo varchar(25) NOT NULL,
    Placa varchar(7) NOT NULL,
    Ano int NOT NULL,
    NomeCliente varchar(50) NOT NULL,
    CPFCliente varchar(11) NOT NULL    
);

CREATE TABLE Carros(
    Id int NOT NULL PRIMARY KEY,
    Marca varchar(25) NOT NULL,
    Modelo varchar(25) NOT NULL,
    Placa varchar(7) NOT NULL,
    Ano int NOT NULL,
    Tipo varchar(25) NOT NULL
);

CREATE TABLE Motos(
    Id int NOT NULL PRIMARY KEY,
    Marca varchar(25) NOT NULL,
    Modelo varchar(25) NOT NULL,
    Placa varchar(7) NOT NULL,
    Ano int NOT NULL,
    Tipo varchar(25) NOT NULL
);

CREATE TABLE Caminhoes(
    Id int NOT NULL PRIMARY KEY,
    Marca varchar(25) NOT NULL,
    Modelo varchar(25) NOT NULL,
    Placa varchar(7) NOT NULL,
    Ano int NOT NULL,
    Tipo varchar(25) NOT NULL
);

CREATE TABLE Vans(
    Id int NOT NULL PRIMARY KEY,
    Marca varchar(25) NOT NULL,
    Modelo varchar(25) NOT NULL,
    Placa varchar(7) NOT NULL,
    Ano int NOT NULL,
    Tipo varchar(25) NOT NULL
);

CREATE TABLE Onibuss(
    Id int NOT NULL PRIMARY KEY,
    Marca varchar(25) NOT NULL,
    Modelo varchar(25) NOT NULL,
    Placa varchar(7) NOT NULL,
    Ano int NOT NULL,
    Tipo varchar(25) NOT NULL
);



```
