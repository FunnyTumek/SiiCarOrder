INSERT INTO
sales.EngineType (Id, Type)
VALUES
('PT', 'Petrol'),
('DS', 'Diesel');

UPDATE sales.Engine
SET TypeId = 'PT'
WHERE Code IN ('EC01','EC02','EC03','EC04','EC05','EC06');

UPDATE sales.Engine
SET TypeId = 'DS'
WHERE Code IN ('EC07','EC08','EC09','EC10','EC11');