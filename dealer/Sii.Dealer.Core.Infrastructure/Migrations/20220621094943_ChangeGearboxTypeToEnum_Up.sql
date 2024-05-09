UPDATE
sales.Gearbox
SET
Type = '0'
WHERE Type LIKE 'Manual'
UPDATE
sales.Gearbox
SET
Type = '1'
WHERE Type LIKE 'Automatic'
GO