INSERT INTO
	sales.Brands (Code, Name)
VALUES
	('BC01', 'Sii');


INSERT INTO
	sales.CarModel (Code, Name)
VALUES
	('MC01', 'Model S'),
	('MC02', 'Model M'),
	('MC03', 'Model L'),
	('MC04', 'Model X'),
	('MC05', 'Model Y'),
	('MC06', 'Model T');

INSERT INTO
	sales.CarClass (Code, Name)
VALUES
	('CC01', 'City'),
	('CC02', 'Compact'),
	('CC03', 'Midsize'),
	('CC04', 'Fullsize'),
	('CC05', 'SUV'),
	('CC06', 'GT');


INSERT INTO
	sales.EngineType (Id, Type)
VALUES
	('PT', 'Petrol'),
	('DS', 'Diesel');

INSERT INTO
	sales.Engine (Code, Name, Capacity, Power, TypeId)
VALUES
	('EC01', '1.0 TSI',  998,  75, 'PT'),
	('EC02', '1.2 TSI', 1198, 110, 'PT'),
	('EC03', '1.4 TSI', 1399, 125, 'PT'),
	('EC04', '2.0 TSI', 1998, 211, 'PT'),
	('EC05', '2.0 TSI', 1998, 300, 'PT'),
	('EC06', '4.0 V8 TFSI', 3989, 650, 'PT'),
	('EC07', '1.4 TDI', 1388,  90, 'DS'),
	('EC08', '1.6 TDI', 1599, 110, 'DS'),
	('EC09', '2.0 TDI', 1998, 170, 'DS'),
	('EC10', '3.0 TDI', 2999, 350, 'DS'),
	('EC11', '6.0 V12 TDI', 5999, 500, 'DS');


INSERT INTO
	sales.Gearbox (Code, Type, GearsCount)
VALUES
	('GC01', 'Manual',    5),
	('GC02', 'Manual',    6),
	('GC03', 'Automatic', 6),
	('GC04', 'Automatic', 7);

INSERT INTO
	sales.EquipmentVersion (Code, Name)
VALUES
	('EV01', 'Basic'),
	('EV02', 'Comfort'),
	('EV03', 'Premium'),
	('EV04', 'Exclusive'),
	('EV05', 'Luxury');

INSERT INTO
	sales.Colors (Code, Name)
VALUES
	('CO01', 'Black'),
	('CO02', 'White'),
	('CO03', 'Red'),
	('CO04', 'Blue'),
	('CO05', 'Grey'),
	('CO06', 'Green'),
	('CO07', 'Yellow'),
	('CO08', 'Silver'),
	('CO09', 'Orange');

INSERT INTO
	sales.Interiors (Code, Name)
VALUES
	('IC01', 'Black leather'),
	('IC02', 'Light leather'),
	('IC03', 'Dark'),
	('IC04', 'Light'),
	('IC05', 'Beige'),
	('IC06', 'Grey');

INSERT INTO
	sales.AdditionalEquipment (Code, Name)
VALUES
	('AE01', 'Comfort seat package'),
	('AE02', 'Sport package'),
	('AE03', 'Family package'),
	('AE04', 'Assisted drive package'),
	('AE05', 'Safety package'),
	('AE06', 'Exclusive sound system'),
	('AE07', 'Tow bar'),
	('AE08', 'Interior protection package'),
	('AE09', 'Park assist system');