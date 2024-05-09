INSERT INTO [sales].[AvailableConfigurations]
           ([BrandCode]
           ,[ModelCode]
           ,[EquipMentVersionCode]
           ,[ClassCode]
           ,[EngineCode]
           ,[GearboxCode]
           ,[ColorCode]
           ,[InteriorCode])
     VALUES
('BC01', 'MC03','EV03','CC03','EC03','GC03','CO03','IC03'),
('BC01','MC02','EV02','CC02','EC02','GC02','CO02','IC02'),
('BC01','MC01','EV01','CC01','EC01','GC01','CO01','IC01'),
('BC01','MC04','EV04','CC04','EC04','GC04','CO04','IC04'),
('BC01','MC05','EV05','CC05','EC05','GC04','CO05','IC05'),
('BC01','MC06','EV05','CC06','EC06','GC04','CO06','IC06'),
('BC01','MC02','EV01','CC01','EC07','GC01','CO07','IC04'),
('BC01','MC02','EV02','CC01','EC08','GC02','CO08','IC06')

INSERT INTO [sales].[AvailableConfigurationAdditionalEquipment]
           ([AvailableConfigurationId]
           ,[EquipmentCode])
     VALUES
(1,'AE01'),
(2,'AE01'),
(3,'AE01'),
(4,'AE01'),
(5,'AE01'),
(6,'AE01'),
(7,'AE01'),
(8,'AE01'),
(2,'AE02'),
(3,'AE02'),
(4,'AE02'),
(5,'AE02'),
(6,'AE02'),
(4,'AE03'),
(5,'AE03'),
(6,'AE03'),
(4,'AE04'),
(5,'AE04'),
(6,'AE04'),
(4,'AE05'),
(5,'AE05'),
(6,'AE05'),
(4,'AE06'),
(5,'AE06'),
(6,'AE06')
