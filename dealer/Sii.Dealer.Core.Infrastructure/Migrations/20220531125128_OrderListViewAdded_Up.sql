CREATE VIEW sales.OrderListView
AS
SELECT o.Id, o.Customer_FirstName AS CustomerFirstName, o.Customer_LastName AS CustomerLastName, o.CreationDate, o.Price, o.OriginalPrice - o.Price AS Discount, o.Status, COUNT(c.Id) AS Comments
FROM sales.Orders o
LEFT OUTER JOIN sales.OrderComments c ON c.OrderId = o.Id
WHERE o.Status != 3
GROUP BY o.Id, o.Customer_FirstName, o.Customer_LastName, o.CreationDate, o.Price, o.OriginalPrice - o.Price, o.Status
GO
