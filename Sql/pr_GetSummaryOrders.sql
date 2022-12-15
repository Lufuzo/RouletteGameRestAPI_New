CREATE PROCEDURE pr_GetOrderSummary
@StartDate date ,
@EndDate date ,
@CustomerID varchar(250) null,
@EmployeeID int null,
@Result varchar out
AS
SELECT 
	CONCAT( TitleOfCourtesy,' ',FirstName,' ', LastName) AS EmployeeFullName, 
	s.CompanyName as ShipperCompanyName, 
	c.CompanyName as Customer CompanyName,
	COUNT(o.OrderID) as NumberOfOrders,
	o.OrderDate as [Date],
	SUM(o.Freight) as TotalFreightCost,
	COUNT(DISTINCT od.ProductID) as NumberOfDifferentProducts,
	SUM(os.Subtotal) as TotalOrderValue
FROM Orders As o
	INNER JOIN Employees As e ON o.EmployeeID = e.EmployeeID
	INNER JOIN Customers AS c ON o.CustomerID = c.CustomerID
	INNER JOIN [Order Details] As  od ON o.OrderID = od.OrderID
	INNER JOIN [Order Subtotals] as os  ON o.OrderID = os.OrderID
	INNER JOIN Shippers as s ON o.ShipVia = s.ShipperID
WHERE   (o.OrderDate BETWEEN @StartDate AND @EndDate)
		AND o.CustomerID = ISNULL(NULLIF(@CustomerID,''),o.CustomerID)
		AND o.EmployeeID = ISNULL(NULLIF(@EmployeeID,''),o.EmployeeID)
		
GROUP BY e.TitleOfCourtesy, e.FirstName,e.LastName,
c.CompanyName, o.OrderDate, s.CompanyName
GO