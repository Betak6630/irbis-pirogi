--Go
--create table ProductType (
--Id int PRIMARY KEY IDENTITY(1, 1) not null,
--Name nvarchar(100) not null
--)

--GO
--create table Product (
--Id int PRIMARY KEY IDENTITY(1, 1) not null,
--Name nvarchar(100) not null,
--Description nvarchar(255),
--ProductTypeId int not null FOREIGN KEY REFERENCES  ProductType(Id)
--)

--go
--create table ProductOption(
--Id int PRIMARY KEY IDENTITY(1, 1) not null,
--ProductId int not null,
--[Weight] float not null,
--Price float  not null
--)

--insert into ProductOption values (1, 600, 350)
  --insert into ProductOption values (1, 1000, 550)
  --insert into ProductOption values (1, 1200, 650)

  --insert into ProductOption values (2, 600, 350)
  --insert into ProductOption values (2, 1000, 550)
  --insert into ProductOption values (2, 1200, 650)

  --go 
  --create table Token(
  --Id uniqueidentifier PRIMARY KEY not null,
  --UserId int not null,
  --CreatedAt datetime not null default getdate()
  --)

  --go
  --create table Busket(
  --Id int PRIMARY KEY IDENTITY(1,1) not null,
  --Token uniqueidentifier not null,
  --P


  select * from Token

  