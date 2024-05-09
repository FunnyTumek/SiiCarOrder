UPDATE sales.Gearbox
SET Name = CONCAT(Code,SUBSTRING(Type,1,1),GearsCount);
ALTER TABLE sales.Gearbox 
ALTER COLUMN Name nvarchar(max) NOT NULL;
GO