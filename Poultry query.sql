CREATE TABLE Scategory(
    [id]   INT IDENTITY(1, 1) primary key not null,
    [category] NVARCHAR (50) ,
  
);

CREATE TABLE expensecategory(
    [Id]           INT            IDENTITY(1, 1) NOT NULL,
    [category] NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



create table dcategory(
id int identity(100,1) primary key,
category nvarchar(50),
);

create table deathpoultry(
did int identity (100,1) primary key,
category nvarchar(50) ,
amount int ,
deathdate datetime,
causeofdeath nvarchar(MAX),
);


create table Expense(
Id int identity (100,1) primary key,
[expense name] nvarchar(50) not null,
category nvarchar(50) not null,
amount int not null,
price int not null,
total decimal not null,
[date] datetime not null,
[description] nvarchar(MAX) not null,
);

create table login(
cid int identity(100,1) primary key,
email nvarchar(50) not null,
password nvarchar(50) not null,
type nvarchar(50),
);


create table Sales(
id int identity(100,1) primary key,
sales nvarchar(50) not null,
category nvarchar(50) not null,
amount int not null,
price int not null,
total decimal not null,
date datetime not null,
description nvarchar(50) not null,
);


CREATE TABLE addpoultry (
    SaleID INT PRIMARY KEY identity (1,1),
    Name NVARCHAR(255) NOT NULL,
    Category NVARCHAR(255) NOT NULL,
    amount int NOT NULL,
    SaleDate DATE NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
	price int not null,
	total int not null,
);



CREATE TABLE pcategory (
    SaleID INT PRIMARY KEY identity (1,1),
    Category NVARCHAR(255) NOT NULL
);

CREATE TABLE chicktoadult (
    SaleID INT PRIMARY KEY identity (1,1),
    totalchicks int NOT NULL,
    death int NOT NULL,
    hen int NOT NULL,
    roster int NOT NULL
);













