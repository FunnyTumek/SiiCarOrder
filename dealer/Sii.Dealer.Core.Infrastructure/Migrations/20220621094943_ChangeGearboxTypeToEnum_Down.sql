  UPDATE
sales.Gearbox
SET
Type = 'Manual'
WHERE Type LIKE '0'
UPDATE
sales.Gearbox
SET
Type = 'Automatic'
WHERE Type LIKE '1'
GO