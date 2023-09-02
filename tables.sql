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
-- UserTypes
CREATE TABLE UserTypes (
   UserTypeID INT PRIMARY KEY IDENTITY(1,1),
   UserType NVARCHAR(50) NOT NULL
);

INSERT INTO UserTypes (UserType) VALUES ('Manager'), ('Employee'), ('Customer');


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


-- use project
-- -- Employees
-- INSERT INTO Employees (FirstName, LastName, Email, PhoneNumber, HireDate, Salary, Password, UserTypeID) 
-- VALUES ('John', 'Doe', 'john.doe@email.com', '123-456-7890', '2022-01-10', 50000, 'hashed_password_123', 2),
--        ('Jane', 'Smith', 'jane.smith@email.com', '987-654-3210', '2021-12-01', 55000, 'hashed_password_456', 2);

-- -- Customers
-- INSERT INTO Customers (FirstName, LastName, Email, PhoneNumber, Address, Password, UserTypeID)
-- VALUES ('Alice', 'Johnson', 'alice.j@email.com', '111-222-3333', '123 Main St', 'hashed_password_789', 3),
--        ('Bob', 'Williams', 'bob.w@email.com', '444-555-6666', '456 Elm St', 'hashed_password_012', 3);

-- -- Add 10 tables with capacities ranging from 2 to 6.
-- DECLARE @i INT = 1;
-- WHILE @i <= 10
-- BEGIN
--    INSERT INTO Tables (TableNumber, Capacity)
--    VALUES (@i, (RAND() * 4) + 2); -- Random capacity between 2 and 6
--    SET @i = @i + 1;
-- END;

-- INSERT INTO MenuItems (Name, Description, Price)
-- VALUES ('Spaghetti', 'Classic spaghetti with marinara sauce', 12.99),
--        ('Burger', 'Juicy beef burger with lettuce and tomato', 9.99),
--        ('Caesar Salad', 'Crispy romaine with creamy Caesar dressing', 7.99);


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