USE [DIPLOM5.1]
GO

INSERT INTO [dbo].[Roles]
           ([Title])
     VALUES
           ('����. ���������'),
		   ('���������')
GO
INSERT INTO [dbo].[Users]
           ([Login]
           ,[Password]
           ,[FirstName]
           ,[LastName]
           ,[MiddleName]
           ,[RoleId])
     VALUES
           ('User1','User1','�����������','�����','��������',1),
		   ('User2','User2','���������','����','����������',2),
		   ('User3','User3','�������','���������','����������',2),
		   ('User4','User4','������','�����','���������',2)
GO
INSERT INTO [dbo].[�mployees]
           ([FirstName]
           ,[LastName]
           ,[MiddleName])
     VALUES
          ('�����������','�����','��������'),
		   ('���������','����','����������'),
		   ('�������','���������','����������'),
		   ('������','�����','���������')
GO
INSERT INTO [dbo].[Organizations]
           ([Title]
           ,[LegalAddress]
           ,[INN]
           ,[KPP]
           ,[Owner]
           ,[MailingAddress]
           ,[NumberPhone]
           ,[BankAccountNumber]
           ,[OGRN]
           ,[OKATO]
           ,[OKPO])
     VALUES
           ('��� "�����-�����"','���. ����������, �. ����������, ��. ���������, �. 19','25695362587','256412369','������ ������ ��������','���������� �������, ��������� ����� ����� ����������, ����� ����������, ����� ���������, ��� 19, 347369','89996968580','50977526600000007717','1547852300082','60412000000','000325006'),
		   ('��� "���-��������"',' ���. ����������, �. ����������, ��. ����������, �. 12','5003650098','245006005','�������� ��������� ����������','���������� �������, ��������� ����� ����� ����������, ����� ����������, ����� ����������, ��� 12, 347386','89281145517','40844339900000006708','5000650036025','60412000000','900050640'),
		   ('��� "�������������"',' ���. ����������, �. ����������, ��. �.��������, �.5','4002596325','400006523','���������� ����� ���������','���������� �������, ��������� ����� ����� ����������, ����� ����������, ����� �.��������, ��� 107, 347386','89885695862','40844339900000006708','5000650036025','60412000000','900050640'),
           ('��� "������������"','���. ����������, �. ����������, ��. �������, �. 3�','2033654789','112553669','������� ������ ����������','���������� �������, ��������� ����� ����� ����������, ����� ����������, ����� �������, ��� 3�, 347382','89965845236','40995362500004785','5000650036025','60412000000','000325006'),
           ('��� "������-������"','���. ����������, �. ����������, �. �����������, �. 23�','58800365840','45503695','������ ������� ��������','���������� �������, ��������� ����� ����� ����������, ����� ����������, ����� �����������, ��� 23�, 347380','89287456859','40995000036254785','5000650036025','60412000000','000325006')
GO


INSERT INTO [dbo].[Categories]
           ([Title])
     VALUES
           ('�����������'),
		   ('�������� � ���������� ����������'),
		   ('��������'),
		   ('���������� �������'),
		   ('��������'),
		   ('���������� ���������'),
		   ('�������������� �����������'),
		   ('���� ����������, ���������, ����������')
GO
INSERT INTO [dbo].[PictureProducts]
           ([Picture])
     VALUES
('NonPicture.png'),
('product_1.png'),
('product_2.png'),
('product_3.png'),
('product_4.png'),
('product_5.png'),
('product_6.png'),
('product_7.png'),
('product_8.png'),
('product_9.png'),
('product_10.png'),
('product_11.png'),
('product_12.png'),
('product_13.png'),
('product_14.png'),
('product_15.png'),
('product_16.png'),
('product_80.png')
GO
	
		   INSERT INTO [dbo].[Products]
           ([Title],[Description],[PictureProductId],[Cost],[Guarantee],[Discount],[CategorieId])
     VALUES
			--�����������
           ('������ ����','�������� ���� �������� ��������, �������� � ���������� ��������, ���������� �����, ������������������� � �������� ����, ��� ��������� ���������������� ����� ���������� � ������� �������. ����� ��������� ������������ ���������� ������������������ ����������, �������� ��� ����� ������� ���������������.',2,13000,1,0,1),
		   ('����','����������� ��� ����������� ���, ��� � ��� �������������� ����������������. ������������ ��������������������� �����, �������� ��� ����������� �� ������� ������������ ���������� �������������, � ������� ������������ ���� �� ���������� ������������ ��� �������������� �������������� ����� ������.',2,33600,1,0,1),
		   ('������� ������','����� ������� � �������� ���������, ��������� �� ������� ������ � ����� ����������������. ������ ���������� �������� ����� ����������������, ��� ��������� ��������� ����� � �������� ������. ��������� ��������� ������ ����������, �������� ���� ����������� ������������ ��� ������� �������� ��������, ��� ���� ��������� ������� ���������.',2,5400,1,0,1),
		   ('�������� �� 5 �������������','��� ������� 1�:����������� 8. �������� �� 5 ������������� �� ��������� �� ��������� � �������� �������� 1� ����������� 8 ���� � �������� �� 5 ������� ����.',2,26000,1,0,1),
		   ('����','�������������� ����������� ��������� ����� ������������������� ������������. ������ ���� ������������ ���������� ��������, � ����� � ���� � ��������� ��� ����������� ��������, � ������������ � ������������ �� ��.',4,43200,1,0,1),
		   ('����','��������� �������� � ���� ��������� �1�:����������� 8.3� � ������������ ������������ �������������� �����������. ��� ����������� � ������������ � �������� ������� �� ��� ����������� ����� ������ �������������� ����� ���������-������������� ������������ ����������� � ���������� �� ��� ����������� �� 31.10.2000 � 94�.',5,14400,1,0,1),
		   ('���. ������� ������','������� �1�:����������� ��Ҕ ������������� ��� ������������� �������������� � ���������� �����, ������� ���������� ������������ (������������������) ���������� � �������������/�������������� �������������� �������������, ������ ������������, ���������� �������� � �������-������������ (��������) ������������ (���), ������� ���� � �������� �������������� �����������.',6,7200,1,0,1),
		   ('��������� 8','����������� ������� �1� ��������� 8� � ��� ��������������������, ������������������ �������� ������������ �1�:����������� 8. ������� ������� ��� �������� � ����������� ������� �������������� � ���������� ����� �� ���, � ����� ��� ���������� ������������������ ����������.',7,5400,1,0,1),

		   --�������� � ���������� ���������v
		   ('����','� ��������� 1�:�������� � ���������� ���������� 8 ���� ����� ������������ ���������� ���� ������������ ����� ����� � � ���� �� ��������� ������ � ����������: ����������������� �������� �������� ����������, �������� ����������� ������������ � ���� HR �������.',8,100900,1,0,2),
		   ('����','������ ������� ������� �����������, � ������ �������, ��� �������� ����� � ����������� ������� �����������, ���� ���������� � ������ � ������������.',8,22600,1,0,2),
		   ('������� ������','������ ��������� � ��� ������� ������� � ������� ������������. Ÿ �� ����� ������������ � ������������ ����������� �����������, � ����� ����� ������ ������������ ��������� ��������� ������� ��� ������ ������ ����������������.',8,8100,1,0,2),

		   --��������
		   ('�������','(���������)',9,3600,1,0,3),
		   ('���������� ���������','������� ��������� ����������� ��������� ���� ������������� �������, ��������� ����������� ������ ������������� �������� ������������ � ����������� �������� �������� �����������, � ����� ��������� ���������, ��������, ����������, �������������� � ���������� ��������.',10,22600,1,50,3),
		   ('������� ������','���������� ������� 1�:���������� ��������� 8. ������� ������ ������������ ����������� ������������ ��������� �������: �� ������ � �������� ������, �� ����������� ��������� �����������, �� ������� ������ �������, ������� � ���������� ����� ������������ ��� ���������� ������ ������� �������� ������������ �����������.',10,7200,1,70,3),

		   --���������� �������
		   ('�����:����� ���������� ����������','����������� ������� �1�-�����:����� ���������� ����������. ������ 5.5� ��� ���������� ��������� �������� ����� ���������� � ��������� �1�-�����:�������� ��� ��������� ����������. ������ 5.5�.',6,8000,1,0,4),
		   ('����� �������','������������ ������������� ����� � ���������� ��� ����� ��� � ��������� ������� �������, ���������� � ��������� �������, ������ ������� � ��������������.',13,25000,1,0,4),
		   ('����������','�������� ���������� �������� ��� ������������� ���������� ������� ��������� ������������, ��������, ������� ������������ ������������ �����������.',11,28000,1,0,4),
		   ('����������','��������� ��� ������������� ������������ ��������� ������ ���� � ����������.',12,30000,1,0,4),

		   --��������
		   ('����. ���������� �������� �� ������� �����','�������������� ���������� �������� ������������ ����������� ������ ������� ���������� ������������� � �������������� �� ������ ���������� ������� ����: 1, 5, 10, 20, 50, 100, 300 ��� 500.',14,6300,1,0,5),
		   ('����������� ������������� ��������','�1�:����������� 8. ����������� ������������� ��������� (����� 1�:���) ����������� �� ������������ ����, � ������� �������� ����� ������������ ������ � ������ ��������� �1�:����������� 8 ���ϻ, ���������� �� ��������� �������� 1�:���.',6,300000,1,0,5),
		   ('����. �������� �� ������','�������� ��� ������������� ������-���������� �������� ������ �� ������������ �������� � �������� �������. ��� ��������, ������� ��������� ������������� ������� ���������� ������� ���� �� ����������� ������ �������� �� ������ ������ ����. ��� ����� ����� ������� ����������� ����������, ������� ���������� ��������� �� ��������� ������������.',6,50400,1,0,5),

		   --���������� ���������
		   ('����������� �������������','������ ��������� � ��� ������� ������� � ������� ������������. Ÿ �� ����� ������������ � ������������ ����������� �����������, � ����� ����� ������ ������������ ��������� ��������� ������� ��� ������ ������ ����������������.',15,61700,1,90,6),
		   ('���������� ����� ������','������� ����������� ������� ��� ����������� ������ �������. � ��������� ����������� ��� ����������� �������� ��� ������������� �����, �������, ������������ � ��������. ',16,17400,1,0,6),

		   --�������������� �����������

		   --���� ����������, ���������, ���������
		   ('�������������� ���������� ����� �� ��������� ������������� ������� ����� ������� ��� 1�:�����������','�������������� ���������� ����� �� ��������� ������������� ������� ����� ������� �� ��� ���������, �� ��������� ������� ��� ����������� ���������� ���������� �������. ����� ��� ������ ��������� ������� ���� �� ������� ����� �������������.',17,16800,1,0,8),
		   ('����� ������������������� ��������� � ����','������� ����� ��� 1�:����������� ������������������ ��������� � ������������ �������� �������, � ���������� ������������ ��� ���� �����: ��� ����������� ����� ��������� ������� ���� ��������� �������������� � �������� ��� �������� ��� ��� ���� ������ ������. ���� ����������� �� �������� �����������.',17,9600,1,0,8),
		   ('������� ����� ��� 1�: ����������� ��������������������� �����������','��������� ����� ��������� ������������: ������� ����� ��� 1�: ����������� ��������������������� �����������, ��������� �������� ����� ��������, ��� ����� �������, ���� �������, ������������ �������������, ��������� ������ �������� �������, ������� � ����.',17,7800,1,0,8)
GO

INSERT INTO [dbo].[Services]
           ([Title],[Description],[CostPerHour])
     VALUES
           ('������������ 1�','���������� ���������, �������� �������, ������ � ��������� - ������ ������ �������������� �� ��������� ����� ����������� ��������� 1�. ������ ��������� ������� ������, ������������ ���������, ����� �������������� ��������� � ������. ����������� ���������� � �������, �������24, � ��������������,  � �����������.',1600),
		   ('������ 1�','������ 1� � ��� ����� �����������, ������������ �� ��, ����� 1� � �������� ����������.',1600),
		   ('��������� 1�','��������� �������� 1�, ���������� � ������� �����������, ���������� ���������, ���� ������� ��� ������� � ����.',0),
		   ('�������� ������������� 1�','������� ��������� ��� ���������� �������� � ���������� ������� � ������� �������������. ���� ����� ������ � ���� ������������� ��� ������� ������ �������.',0),
		   ('������������ 1�','��������� 1� � ���������������� ������� �������� �� ������������� 1� ��� ����������� �� ���������� ���������. �� ������������� ����������� �����.',1600)
GO
INSERT INTO [dbo].[Reports]
           ([Title]
           ,[DateOf�reation]
           ,[UserId])
     VALUES
            ('������� 1','2023-03-23',2),
		    ('������� 2','2023-03-24',2),
			('������� 3','2023-03-25',2),
			('������� 4','2023-04-05',2),
		    ('������� 5','2023-04-27',2),
			('������� 6','2023-05-30',2)
GO
INSERT INTO [dbo].[SaleProducts]
           ([Article]
           ,[DateOfSale]
           ,[Income]
           ,[Profit]
           ,[OrganizationId]
           ,[ProductId]
           ,[�mployeesId]
           ,[UserId])
     VALUES
           ('00002','2023-03-23',10000,5000,1,1,1,2),
		   ('00003','2023-03-24',17000,8500,2,3,2,2),
		   ('00004','2023-03-25',20000,10000,3,4,1,2),
		   ('00005','2023-04-23',15500,7250,4,7,1,2),
		   ('00006','2023-03-27',42560,21280,5,6,1,2)
GO
INSERT INTO [dbo].[SaleServices]
           ([Article]
           ,[DateOfSale]
           ,[Income]
           ,[Profit]
           ,[ServiceId]
           ,[OrganizationId]
           ,[�mployeesiD]
           ,[UserId])
     VALUES
           ('10001','2023-05-01',1600,800,1,1,2,2),
		   ('10002','2023-05-11',1600,800,1,2,2,2),
		   ('10001','2023-05-15',1600,800,1,3,2,2),
		   ('10001','2023-05-01',500,250,2,4,2,2)
GO
