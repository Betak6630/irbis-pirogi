/****** Скрипт для команды SelectTopNRows из среды SSMS  ******/
SELECT TOP 1000 [Id]
      ,[Name]
      ,[Description]
      ,[ProductTypeId]
  FROM [u0349538_irbis_pirogi].[u0349538_irbis].[Product]

  select * from [u0349538_irbis_pirogi].[u0349538_irbis].[ProductType]

  ---ProductType
--INSERT INTO [ProductType]([Id],[Name])
--VALUES(1,'Осетинские пироги')

--INSERT INTO [ProductType]([Id],[Name])
--VALUES(2,'Сладкие пироги')

--INSERT INTO [ProductType]([Id],[Name])
--VALUES(3,'Постные пироги')
  
  --product 
  
--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(1,'Уалибах','Уалибах',1)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(2,'Фыдджын','Фыдджын',1)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(3,'Цахараджын','Цахараджын',1)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(4,'Картофджын','Картофджын',1)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(5,'Къабускаджын','Къабускаджын',1)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(6,'Пирог с фасолью','Пирог с фасолью',1)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(7,'Пирог с мясом и грибами','Пирог с мясом и грибами',1)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(8,'Пирог с мясом и капустой','Пирог с мясом и капустой',1)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(9,'Пирог со шпинатом и сыром','Пирог со шпинатом и сыром',1)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(10,'Фирменный','Пирог со шпинатом, зеленью, цуккини и сыром',1)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(11,'Пирог с сыром и зеленым луком','Пирог с сыром и зеленым луком',1)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(12,'Пирог с сыром и картошкой','Пирог с сыром и картошкой',1)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(13,'Пирог с сыром и грибами','Пирог с сыром и грибами',1)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(14,'Пирог с сыром, грибами и курицей','Пирог с сыром, грибами и курицей',1)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(15,'Пирог с сыром и курицей','Пирог с сыром и курицей',1)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(16,'Пирог с сыром и тыквой','Пирог с сыром и тыквой',1)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(17,'Пирог с сыром и семгой','Пирог с сыром и семгой',1)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(18,'Пирог с картошкой и семгой','Пирог с картошкой и семгой',1)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(19,'Пирог с бараниной','Пирог с бараниной',1)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(20,'Пирог с индейкой','Пирог с индейкой',1)
  
  --Сладкие пироги
  
--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(22,'Лимонник','По весу, цена за 1кг',2)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(23,'Творожник','По весу, цена за 1кг',2)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(24,'Пирог с бананом (1,5кг)','Пирог с бананом (1,5кг)',2)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(25,'Пирог с вишней (1кг)','Пирог с вишней (1кг)',2)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(26,'Пирог с клубникой (1кг)','Пирог с клубникой (1кг)',2)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(27,'Шарлотта (1,5кг)','Шарлотта (1,5кг)',2)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(28,'Каравай (1,5кг)','Каравай (1,5кг)',2)

--------Постные пироги

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(29,'Пирог с цуккини','Пирог с цуккини и зеленью',3)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(30,'Пирог с капустой','Пирог с капустой',3)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(31,'Пирог с тыквой','Пирог с тыквой',3)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(32,'Пирог с картошкой и грибами','Пирог с картошкой и грибами',3)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(33,'Пирог с капустой и грибами','Пирог с капустой и грибами',3)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(34,'Пирог с капустой и орехами','Пирог с капустой и орехами',3)

--INSERT INTO [Product]([Id],[Name],[Description],[ProductTypeId])
--VALUES(35,'Пирог с фасолью','Пирог с фасолью',3)


--ProductOption

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(1,1,600,350)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(2,1,1000,550)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(3,1,1200,650)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(4,2,600,350)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(5,2,1000,550)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(6,2,1200,650)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(7,3,600,350)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(8,3,1000,550)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(9,3,1200,650)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(10,4,600,350)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(11,4,1000,550)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(12,4,1200,650)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(13,5,600,350)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(14,5,1000,550)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(15,5,1200,650)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(16,6,600,350)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(17,6,1000,550)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(18,6,1200,650)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(19,7,600,350)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(20,7,1000,550)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(21,7,1200,650)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(22,8,600,310)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(23,8,1000,500)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(24,8,1200,600)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(25,9,600,350)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(26,9,1000,550)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(27,9,1200,650)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(28,10,600,360)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(29,10,1000,560)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(30,10,1200,660)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(31,11,600,350)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(32,11,1000,550)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(33,11,1200,650)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(34,12,600,310)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(35,12,1000,500)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(36,12,1200,600)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(37,13,600,350)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(38,13,1000,550)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(39,13,1200,650)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(40,14,600,350)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(41,14,1000,550)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(42,14,1200,650)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(43,15,600,350)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(44,15,1000,550)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(45,15,1200,650)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(46,16,600,320)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(47,16,1000,520)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(48,16,1200,620)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(49,17,600,450)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(50,17,1000,650)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(51,17,1200,750)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(52,18,600,350)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(53,18,1000,550)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(54,18,1200,650)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(55,19,600,500)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(56,19,1000,600)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(57,19,1200,700)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(58,20,600,500)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(59,20,1000,600)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(60,20,1200,700)

---- Сладкие пироги

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(61,22,1000,450)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(62,23,1000,550)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(63,24,1500,600)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(64,25,1000,650)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(65,26,1000,550)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(66,27,1500,550)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(67,28,1500,1500)

 ------ Постные пироги
 
 
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(68,29,600,310)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(69,29,1000,500)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(70,29,1200,600)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(71,30,600,310)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(72,30,1000,500)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(73,30,1200,600)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(74,31,600,310)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(75,31,1000,500)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(76,31,1200,600)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(77,32,600,320)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(78,32,1000,530)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(79,32,1200,630)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(80,33,600,320)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(81,33,1000,530)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(82,33,1200,630)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(83,34,600,320)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(84,34,1000,530)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(85,34,1200,630)

--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(86,35,600,310)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(87,35,1000,500)
--INSERT INTO [ProductOption]([Id],[ProductId],[Weight],[Price])
--VALUES(88,35,1200,600)
  
  
  --update [Product] set Name='Фыдджын', Description='Фыдджын' where ID=2
  
  
  --- ProductPicture
  
--insert into ProductPicture Values (1,'/Content/img/product/product1.jpg')
--insert into ProductPicture Values (2,'/Content/img/product/product2.jpg')
--insert into ProductPicture Values (3,'/Content/img/product/product3.jpg')
--insert into ProductPicture Values (4,'/Content/img/product/product4.jpg')
--insert into ProductPicture Values (5,'/Content/img/product/product5.jpg')
--insert into ProductPicture Values (8,'/Content/img/product/product5.jpg')
--insert into ProductPicture Values (9,'/Content/img/product/product9.jpg')
--insert into ProductPicture Values (10,'/Content/img/product/product9.jpg')
--insert into ProductPicture Values (13,'/Content/img/product/product13.jpg')
--insert into ProductPicture Values (14,'/Content/img/product/product13.jpg')
--insert into ProductPicture Values (15,'/Content/img/product/product15.jpg')
--insert into ProductPicture Values (19,'/Content/img/product/product19.jpg')
--insert into ProductPicture Values (24,'/Content/img/product/product24.jpg')
--insert into ProductPicture Values (25,'/Content/img/product/product25.jpg')
--insert into ProductPicture Values (26,'/Content/img/product/product26.jpg')
--insert into ProductPicture Values (27,'/Content/img/product/product27.jpg')
--insert into ProductPicture Values (28,'/Content/img/product/product28.jpg')
--insert into ProductPicture Values (29,'/Content/img/product/product29.jpg')
--insert into ProductPicture Values (30,'/Content/img/product/product5.jpg')
--insert into ProductPicture Values (33,'/Content/img/product/product5.jpg')
--insert into ProductPicture Values (32,'/Content/img/product/product13.jpg')
--insert into ProductPicture Values (34,'/Content/img/product/product5.jpg')