Go
create table ProductType (
Id int PRIMARY KEY IDENTITY(1, 1) not null,
Name nvarchar(100) not null
)
GO
create table Product (
Id int PRIMARY KEY IDENTITY(1, 1) not null,
Name nvarchar(100) not null,
ProductTypeId int not null FOREIGN KEY REFERENCES  ProductType(Id)
)

