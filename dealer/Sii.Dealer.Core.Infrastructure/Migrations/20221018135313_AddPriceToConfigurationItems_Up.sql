-- Brands
UPDATE
sales.Brands
SET
Price = 0

-- CarClass
UPDATE
sales.CarClass
SET
Price = 15000
WHERE Code = 'CC01' or Code = 'CC03'
UPDATE
sales.CarClass
SET
Price = 10000
WHERE Code = 'CC02'
UPDATE
sales.CarClass
SET
Price = 20000
WHERE Code = 'CC04'
UPDATE
sales.CarClass
SET
Price = 22000
WHERE Code = 'CC05'
UPDATE
sales.CarClass
SET
Price = 22000
WHERE Code = 'CC06'

-- CarModel
UPDATE
sales.CarModel
SET
Price = 15000
WHERE Code = 'MC01'
UPDATE
sales.CarModel
SET
Price = 16000
WHERE Code = 'MC02'
UPDATE
sales.CarModel
SET
Price = 17000
WHERE Code = 'MC03'
UPDATE
sales.CarModel
SET
Price = 18000
WHERE Code = 'MC04' or Code = 'MC05' or Code = 'MC06'

-- EquipmentVersion
UPDATE
sales.EquipmentVersion
SET
Price = 10000
WHERE Code = 'EV01'
UPDATE
sales.EquipmentVersion
SET
Price = 15000
WHERE Code = 'EV02'
UPDATE
sales.EquipmentVersion
SET
Price = 25000
WHERE Code = 'EV03'
UPDATE
sales.EquipmentVersion
SET
Price = 30000
WHERE Code = 'EV04'
UPDATE
sales.EquipmentVersion
SET
Price = 35000
WHERE Code = 'EV05'

-- Colors
UPDATE
sales.Colors
SET
Price = 10000
WHERE Code = 'CO01' or Code = 'CO02' or Code = 'CO05' or Code = 'CO08'
UPDATE
sales.Colors
SET
Price = 13000
WHERE Code = 'CO03' or Code = 'CO04' or Code = 'CO06' or Code = 'CO07' or Code = 'CO09'

-- Interiors
UPDATE
sales.Interiors
SET
Price = 10000
WHERE Code = 'IC01' or Code = 'IC02'
UPDATE
sales.Interiors
SET
Price = 11000
WHERE Code = 'IC03' or Code = 'IC04' or Code = 'IC05' or Code = 'IC06'

-- Engine
UPDATE
sales.Engine
SET
Price = 10000
WHERE Code = 'EC01' or Code = 'EC07'
UPDATE
sales.Engine
SET
Price = 11000
WHERE Code = 'EC02' or Code = 'EC08'
UPDATE
sales.Engine
SET
Price = 12000
WHERE Code = 'EC03' or Code = 'EC09'
UPDATE
sales.Engine
SET
Price = 14000
WHERE Code = 'EC04' or Code = 'EC10'
UPDATE
sales.Engine
SET
Price = 16000
WHERE Code = 'EC05'
UPDATE
sales.Engine
SET
Price = 30000
WHERE Code = 'EC06' or Code = 'EC11'

-- Gearbox
UPDATE
sales.Gearbox
SET
Price = 10000
WHERE Code = 'GC01'
UPDATE
sales.Gearbox
SET
Price = 11500
WHERE Code = 'GC02'
UPDATE
sales.Gearbox
SET
Price = 12000
WHERE Code = 'GC03'
UPDATE
sales.Gearbox
SET
Price = 14000
WHERE Code = 'GC04'

-- AdditionalEquipment
UPDATE
sales.AdditionalEquipment
SET
Price = 5000
WHERE Code = 'AE01'
UPDATE
sales.AdditionalEquipment
SET
Price = 15000
WHERE Code = 'AE02'
UPDATE
sales.AdditionalEquipment
SET
Price = 10000
WHERE Code = 'AE03'
UPDATE
sales.AdditionalEquipment
SET
Price = 3000
WHERE Code = 'AE04' or Code = 'AE05' or Code = 'AE06'
UPDATE
sales.AdditionalEquipment
SET
Price = 1000
WHERE Code = 'AE07'
UPDATE
sales.AdditionalEquipment
SET
Price = 5000
WHERE Code = 'AE08'
UPDATE
sales.AdditionalEquipment
SET
Price = 4000
WHERE Code = 'AE09'