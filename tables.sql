USE project
-- Drop child tables (those having foreign keys)
DROP TABLE IF EXISTS OrderDetails;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS Reservations;

-- Drop other tables
DROP TABLE IF EXISTS MenuItems;
DROP TABLE IF EXISTS Tables;
DROP TABLE IF EXISTS Customers;
DROP TABLE IF EXISTS Employees;
DROP TABLE IF EXISTS Logs;

-- Drop the parent table
DROP TABLE IF EXISTS UserTypes;
GO

USE project
-- Check and drop the tr_Customers_Delete_Log trigger if it exists
IF OBJECT_ID('tr_Customers_Insert_Log', 'TR') IS NOT NULL
    DROP TRIGGER tr_Customers_Delete_Log;
GO
USE project
-- Check and drop the tr_Reservations_Delete_Log trigger if it exists
IF OBJECT_ID('tr_Reservations_Insert_Log', 'TR') IS NOT NULL
    DROP TRIGGER tr_Reservations_Delete_Log;
GO
USE project
-- Check and drop the tr_Orders_Delete_Log trigger if it exists
IF OBJECT_ID('tr_Orders_Insert_Log', 'TR') IS NOT NULL
    DROP TRIGGER tr_Orders_Delete_Log;
GO
USE project
-- Check and drop the tr_Customers_Delete_Log trigger if it exists
IF OBJECT_ID('tr_Customers_Delete_Log', 'TR') IS NOT NULL
    DROP TRIGGER tr_Customers_Delete_Log;
GO
USE project
-- Check and drop the tr_Reservations_Delete_Log trigger if it exists
IF OBJECT_ID('tr_Reservations_Delete_Log', 'TR') IS NOT NULL
    DROP TRIGGER tr_Reservations_Delete_Log;
GO
USE project
-- Check and drop the tr_Orders_Delete_Log trigger if it exists
IF OBJECT_ID('tr_Orders_Delete_Log', 'TR') IS NOT NULL
    DROP TRIGGER tr_Orders_Delete_Log;
GO




USE project
-- UserTypes
CREATE TABLE UserTypes (
   UserTypeID INT PRIMARY KEY IDENTITY(1,1),
   UserType NVARCHAR(50) NOT NULL
);

INSERT INTO UserTypes (UserType) VALUES ('Manager'), ('Employee'), ('Customer');
GO

USE project
-- Customers
CREATE TABLE Customers (
   CustomerID INT PRIMARY KEY IDENTITY(1,1),
   FirstName NVARCHAR(50) NOT NULL,
   LastName NVARCHAR(50),
   Email NVARCHAR(100) UNIQUE,
   PhoneNumber NVARCHAR(20),
   Address NVARCHAR(250),
   Password NVARCHAR(255),
   UserTypeID INT FOREIGN KEY REFERENCES UserTypes(UserTypeID)
);

-- Employees
CREATE TABLE Employees (
   EmployeeID INT PRIMARY KEY IDENTITY(1,1),
   FirstName NVARCHAR(50) NOT NULL,
   LastName NVARCHAR(50),
   Email NVARCHAR(100) UNIQUE,
   PhoneNumber NVARCHAR(20),
   HireDate DATE,
   Salary DECIMAL(10,2),
   Password NVARCHAR(255),
   UserTypeID INT FOREIGN KEY REFERENCES UserTypes(UserTypeID)
);

-- Tables (physical tables in the restaurant)
CREATE TABLE Tables (
   TableID INT PRIMARY KEY IDENTITY(1,1),
   TableNumber INT NOT NULL UNIQUE,
   Capacity INT NOT NULL,
   Status NVARCHAR(50) DEFAULT 'Available'
);

-- MenuItems
CREATE TABLE MenuItems (
   MenuItemID INT PRIMARY KEY IDENTITY(1,1),
   Name NVARCHAR(100) NOT NULL,
   Description NVARCHAR(255),
   Price DECIMAL(10,2) NOT NULL
);

-- Reservations
CREATE TABLE Reservations (
   ReservationID INT PRIMARY KEY IDENTITY(1,1),
   CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
   TableID INT FOREIGN KEY REFERENCES Tables(TableID),
   ReservationTime DATETIME NOT NULL
);

-- Orders
CREATE TABLE Orders (
   OrderID INT PRIMARY KEY IDENTITY(1,1),
   CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
   EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID),
   OrderDate DATETIME DEFAULT GETDATE(),
   TotalPrice DECIMAL(10,2) NOT NULL,
   DeliveryAddress NVARCHAR(250),
   Status NVARCHAR(50) DEFAULT 'Pending'
);

-- OrderDetails
CREATE TABLE OrderDetails (
   OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
   OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
   MenuItemID INT FOREIGN KEY REFERENCES MenuItems(MenuItemID),
   Quantity INT NOT NULL
);

-- Logs
CREATE TABLE Logs (
   LogID INT PRIMARY KEY IDENTITY(1,1),
   Date DATETIME DEFAULT GETDATE(),
   UserID INT NOT NULL,
   UserType NVARCHAR(50) NOT NULL,
   Action NVARCHAR(100),
   Description NVARCHAR(255)
);
GO

CREATE TRIGGER tr_Customers_Insert_Log
ON Customers
AFTER INSERT
AS
BEGIN
    INSERT INTO Logs (UserID, UserType, Action, Description)
    SELECT 
        i.CustomerID, 
        'Customer', 
        'Insert', 
        'New customer ' + i.FirstName + ' ' + i.LastName + ' added.'
    FROM INSERTED i;
END;
GO
CREATE TRIGGER tr_Customers_Delete_Log
ON Customers
AFTER DELETE
AS
BEGIN
    INSERT INTO Logs (UserID, UserType, Action, Description)
    SELECT 
        d.CustomerID, 
        'Customer', 
        'Delete', 
        'Customer ' + d.FirstName + ' ' + d.LastName + ' deleted.'
    FROM DELETED d;
END;
GO


CREATE TRIGGER tr_Reservations_Insert_Log
ON Reservations
AFTER INSERT
AS
BEGIN
    INSERT INTO Logs (UserID, UserType, Action, Description)
    SELECT 
        i.CustomerID, 
        'Customer', 
        'Reservation', 
        'New reservation for table ' + CAST(i.TableID AS NVARCHAR(10)) + ' at ' + CAST(i.ReservationTime AS NVARCHAR(50)) + '.'
    FROM INSERTED i;
END;
GO
CREATE TRIGGER tr_Reservations_Delete_Log
ON Reservations
AFTER DELETE
AS
BEGIN
    INSERT INTO Logs (UserID, UserType, Action, Description)
    SELECT 
        d.CustomerID, 
        'Customer', 
        'Reservation Deletion', 
        'Reservation for table ' + CAST(d.TableID AS NVARCHAR(10)) + ' at ' + CAST(d.ReservationTime AS NVARCHAR(50)) + ' deleted.'
    FROM DELETED d;
END;
GO



CREATE TRIGGER tr_Orders_Insert_Log
ON Orders
AFTER INSERT
AS
BEGIN
    INSERT INTO Logs (UserID, UserType, Action, Description)
    SELECT 
        i.CustomerID, 
        'Customer', 
        'Order', 
        'New order placed with total price ' + CAST(i.TotalPrice AS NVARCHAR(10)) + '.'
    FROM INSERTED i;
END;
GO
CREATE TRIGGER tr_Orders_Delete_Log
ON Orders
AFTER DELETE
AS
BEGIN
    INSERT INTO Logs (UserID, UserType, Action, Description)
    SELECT 
        d.CustomerID, 
        'Customer', 
        'Order Deletion', 
        'Order with total price ' + CAST(d.TotalPrice AS NVARCHAR(10)) + ' deleted.'
    FROM DELETED d;
END;
GO


use project
DECLARE @counter INT = 1;
WHILE @counter <= 100
BEGIN
    -- Employees
    INSERT INTO Employees (FirstName, LastName, Email, PhoneNumber, HireDate, Salary, Password, UserTypeID) 
    VALUES ('EmployeeFirstName' + CAST(@counter AS NVARCHAR), 
           'EmployeeLastName' + CAST(@counter AS NVARCHAR), 
           'employee' + CAST(@counter AS NVARCHAR) + '@restaurant.com', 
           '555-01' + CAST(@counter AS NVARCHAR),
           DATEADD(DAY, -@counter, GETDATE()), 
           30000 + (@counter * 10), 
           'hashed_password_' + CAST(@counter AS NVARCHAR), 2);

    -- Customers
    INSERT INTO Customers (FirstName, LastName, Email, PhoneNumber, Address, Password, UserTypeID)
    VALUES ('CustomerFirstName' + CAST(@counter AS NVARCHAR), 
           'CustomerLastName' + CAST(@counter AS NVARCHAR), 
           'customer' + CAST(@counter AS NVARCHAR) + '@mail.com', 
           '555-02' + CAST(@counter AS NVARCHAR), 
           CAST(@counter AS NVARCHAR) + ' Main St', 
           'customer_hashed_password_' + CAST(@counter AS NVARCHAR), 3);
           
    SET @counter = @counter + 1;
END;
-- Insert 20 different dishes
DECLARE @dish INT = 1;
WHILE @dish <= 20
BEGIN
    INSERT INTO MenuItems (Name, Description, Price)
    VALUES ('Dish' + CAST(@dish AS NVARCHAR), 
           'This is a description for Dish' + CAST(@dish AS NVARCHAR), 
           (5.99 + (@dish * 0.5)));
    SET @dish = @dish + 1;
END;

DECLARE @orderCounter INT = 1;
WHILE @orderCounter <= 100 -- Assuming 100 customers
BEGIN
    -- Insert order
    INSERT INTO Orders (CustomerID, EmployeeID, TotalPrice, Status)
    VALUES (@orderCounter, 
           (RAND() * 100) + 1,  -- Assigning random employee 
           (3.99 + (RAND() * 40)),  -- Random total price
           'Pending');

    -- Get the last inserted Order ID
    DECLARE @lastOrderID INT;
    SET @lastOrderID = SCOPE_IDENTITY();

    -- Insert 3 random dishes for this order
    DECLARE @detailCounter INT = 1;
    WHILE @detailCounter <= 3
    BEGIN
        INSERT INTO OrderDetails (OrderID, MenuItemID, Quantity)
        VALUES (@lastOrderID, 
               (RAND() * 20) + 1,  -- Random dish from the menu
               (RAND() * 3) + 1);  -- Random quantity between 1 and 3

        SET @detailCounter = @detailCounter + 1;
    END

    SET @orderCounter = @orderCounter + 1;
END;
GO

use project
-- Retrieve the names of customers who have placed orders for a specific menu item
SELECT c.FirstName, c.LastName
FROM Customers c
WHERE c.CustomerID IN (
    SELECT o.CustomerID
    FROM Orders o
    WHERE o.OrderID IN (
        SELECT od.OrderID
        FROM OrderDetails od
        WHERE od.MenuItemID IN (
            SELECT mi.MenuItemID
            FROM MenuItems mi
            WHERE mi.Name = 'SpecificMenuItemName'  -- Replace with the actual menu item name
        )
    )
);
GO

use project
-- Retrieve the tables that were reserved by customers who have also placed an order with a total price greater than a specific value
SELECT t.TableNumber, r.ReservationTime
FROM Tables t
JOIN Reservations r ON t.TableID = r.TableID
WHERE r.CustomerID IN (
    SELECT o.CustomerID
    FROM Orders o
    WHERE o.TotalPrice > 100  -- Example value
    AND o.CustomerID IN (
        SELECT c.CustomerID
        FROM Customers c
        WHERE c.CustomerID IN (
            SELECT r.CustomerID
            FROM Reservations r
            JOIN Tables t ON r.TableID = t.TableID
        )
    )
);
