/****** Скрипт для команды SelectTopNRows из среды SSMS  ******/
SELECT TOP 1000 [Id]
      ,[Name]
      ,[Description]
      ,[ProductTypeId]
  FROM [u0349538_irbis_pirogi].[u0349538_irbis].[Product]

  select * from [u0349538_irbis_pirogi].[u0349538_irbis].[ProductType]

  --insert into [Product] Values ('Уалибах','Уалибах',1)
  --insert into [Product] Values ('Фыдджын','Фыдджын',1)
  --insert into [Product] Values ('Цахараджын','Цахараджын',1)
  --insert into [Product] Values ('Картофджын','Картофджын',1)
  --insert into [Product] Values ('Къабускаджын','Къабускаджын',1)
  --insert into [Product] Values ('Пирог с фасолью','Пирог с фасолью',1)

  --update [Product] set Name='Фыдджын', Description='Фыдджын' where ID=2