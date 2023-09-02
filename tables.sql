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

USE project

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetUserTypeByEmail')
    DROP PROCEDURE sp_GetUserTypeByEmail;
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_MakeReservation')
    DROP PROCEDURE sp_MakeReservation;

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_InsertNewOrder')
    DROP PROCEDURE sp_InsertNewOrder;
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_CreateNewUser')
    DROP PROCEDURE sp_CreateNewUser;
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_CreateNewEmployee')
    DROP PROCEDURE sp_CreateNewEmployee;
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

--------------------------------------------------------------------------------------------   
--------------------------------------create tables-----------------------------------------
--------------------------------------------------------------------------------------------   


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
   Salary FLOAT, 
   Password NVARCHAR(255),
   UserTypeID INT FOREIGN KEY REFERENCES UserTypes(UserTypeID)
);

-- Tables (physical tables in the restaurant)
CREATE TABLE Tables (
   TableID INT PRIMARY KEY IDENTITY(1,1),
   TableNumber INT NOT NULL UNIQUE,
   Capacity INT NOT NULL,
);

-- MenuItems
CREATE TABLE MenuItems (
   MenuItemID INT PRIMARY KEY IDENTITY(1,1),
   Name NVARCHAR(100) NOT NULL,
   Description NVARCHAR(255),
   Price FLOAT NOT NULL
);

-- Reservations
CREATE TABLE Reservations (
   ReservationID INT PRIMARY KEY IDENTITY(1,1),
   CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
   TableID INT FOREIGN KEY REFERENCES Tables(TableID),
   StartTime DATETIME NOT NULL,
   EndTime DATETIME
);

use project
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

--------------------------------------------------------------------------------------------   
--------------------------------------TRIGERS----------------------------------------------
--------------------------------------------------------------------------------------------   

CREATE TRIGGER tr_DefaultEndTime -- Trigger to set the default end time to 2 hours after the start time
ON Reservations
AFTER INSERT
AS
BEGIN
   UPDATE r
   SET r.EndTime = DATEADD(HOUR, 2, i.StartTime)
   FROM Reservations r 
   INNER JOIN inserted i ON r.ReservationID = i.ReservationID 
   WHERE r.EndTime IS NULL;
END;
GO
CREATE TRIGGER tr_UpdateEndTime
ON Reservations
AFTER UPDATE
AS
BEGIN
   -- Check if the StartTime column was updated
   IF UPDATE(StartTime)
   BEGIN
      UPDATE r
      SET r.EndTime = DATEADD(HOUR, 2, i.StartTime)
      FROM Reservations r
      INNER JOIN inserted i ON r.ReservationID = i.ReservationID
      INNER JOIN deleted d ON r.ReservationID = d.ReservationID
      WHERE r.StartTime <> d.StartTime;
   END
END;
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
        'New reservation for table ' + CAST(i.TableID AS NVARCHAR(10)) + ' at ' + CAST(i.StartTime AS NVARCHAR(50)) + '.'
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
        'Reservation for table ' + CAST(d.TableID AS NVARCHAR(10)) + ' at ' + CAST(d.StartTime AS NVARCHAR(50)) + ' deleted.'
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

USE project

-- Insert data for MenuItems
INSERT INTO MenuItems (Name, Description, Price) VALUES 
('Pizza', 'Delicious cheese pizza', 15),
('Pasta', 'Creamy alfredo pasta', 12),
('Burger', 'Juicy beef burger', 10);

-- Insert data for Tables (only once)
INSERT INTO Tables (TableNumber, Capacity) VALUES 
(101, 4 ),
(102, 2 ),
(103, 6 );

-- Insert data for Customers
INSERT INTO Customers (FirstName, LastName, Email, PhoneNumber, Address, Password, UserTypeID) VALUES 
('John', 'Doe', 'john@example.com', '1234567890', '123 Main St', 'pass123', 3),
('Jane', 'Smith', 'jane@example.com', '0987654321', '456 Elm St', 'pass456', 1),
('Lucas', 'Martin', 'lucas@example.com', '1234567890', '789 Oak St', 'pass789', 2);

-- Insert data for Reservations
INSERT INTO Reservations (CustomerID, TableID, StartTime) VALUES 
(1, 1, '2023-09-10 19:00:00'),   -- Note: Using TableID (1 for 101, 2 for 102, 3 for 103)
(2, 3, '2023-09-11 20:00:00');

-- Insert data for Orders
INSERT INTO Orders (CustomerID, EmployeeID, TotalPrice, DeliveryAddress, Status) VALUES 
(1, NULL, 25, '123 Main St', 'Delivered'),
(2, NULL, 35, '456 Elm St', 'Pending'),
(3, NULL, 45, '789 Oak St', 'Pending');

-- Insert data for OrderDetails
INSERT INTO OrderDetails (OrderID, MenuItemID, Quantity) VALUES 
(1, 1, 1),   -- John ordered a Pizza
(1, 2, 1),   -- John also ordered a Pasta
(10, 1, 2),  -- Lucas ordered 2 Pizzas
(10, 3, 3),  -- Lucas also ordered 3 Burgers
(11, 2, 1),  -- Jane ordered a Pasta
(12, 3, 1),  -- Jane ordered a Burger
(12, 1, 1),  -- Jane ordered a Pizza
(12, 2, 1),  -- Jane ordered a Pasta 
(2, 3, 3);   -- Jane ordered 3 Burgers
GO


use project
-- Retrieve the tables that were reserved by customers who have also placed an order with a total price greater than a specific value
SELECT t.TableNumber, r.StartTime
FROM Tables t
JOIN Reservations r ON t.TableID = r.TableID
WHERE r.CustomerID IN (
    SELECT o.CustomerID
    FROM Orders o
    WHERE o.TotalPrice > 20  -- Example value
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

use project
-- Parameters you'd provide:
DECLARE @desiredTimeStart DATETIME = '2023-09-02 19:00:00';
DECLARE @desiredTimeEnd DATETIME = '2023-09-02 21:00:00';

-- Query to find available tables:
SELECT t.TableID, t.Capacity
FROM Tables t
LEFT JOIN Reservations r ON t.TableID = r.TableID
AND (
    (r.StartTime <= @desiredTimeStart AND r.EndTime > @desiredTimeStart) OR
    (r.StartTime < @desiredTimeEnd AND r.EndTime >= @desiredTimeEnd) OR
    (r.StartTime >= @desiredTimeStart AND r.EndTime <= @desiredTimeEnd)
)
WHERE r.TableID IS NULL;
GO


----------------------------------------------------------------
------------------procedures------------------------------------
----------------------------------------------------------------

--create a new customer    if the cretion sucseed it will retuen 1 
USE project
GO

CREATE PROCEDURE sp_CreateNewUser
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Email NVARCHAR(100),
    @PhoneNumber NVARCHAR(20),
    @Address NVARCHAR(250),
    @Password NVARCHAR(255),
    @UserTypeID INT
AS
BEGIN
    -- Initialize return value to 0 (success)
    DECLARE @ReturnValue INT = 0

    -- Check if the email already exists
    IF EXISTS (SELECT 1 FROM Customers WHERE Email = @Email)
    BEGIN
        SET @ReturnValue = -1  -- Email already exists
        RETURN @ReturnValue
    END

    -- Insert the new user
    INSERT INTO Customers (FirstName, LastName, Email, PhoneNumber, Address, Password, UserTypeID)
    VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Address, @Password, @UserTypeID)

    -- Return success
    RETURN @ReturnValue
END
GO




--create a new employee
USE project
GO

CREATE PROCEDURE sp_CreateNewEmployee
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Email NVARCHAR(100),
    @PhoneNumber NVARCHAR(20),
    @HireDate DATE,
    @Salary FLOAT,
    @Password NVARCHAR(255),
    @UserTypeID INT
AS
BEGIN
    -- Initialize return value to 0 (success)
    DECLARE @ReturnValue INT = 1

    -- Check if the email already exists
    IF EXISTS (SELECT 1 FROM Employees WHERE Email = @Email)
    BEGIN
        SET @ReturnValue = 0  -- Email already exists
        RETURN @ReturnValue
    END

    -- Insert the new employee
    INSERT INTO Employees (FirstName, LastName, Email, PhoneNumber, HireDate, Salary, Password, UserTypeID)
    VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @HireDate, @Salary, @Password, @UserTypeID)

    -- Return success
    RETURN @ReturnValue
END
GO




--add new reservetion



--add new order
USE project
GO
CREATE PROCEDURE sp_InsertNewOrder
(
    @CustomerID INT,
    @EmployeeID INT,
    @TotalPrice DECIMAL(10,2),
    @DeliveryAddress NVARCHAR(250),
    @Status NVARCHAR(50) = 'Pending', -- Using default value as 'Pending'
    @Success BIT OUTPUT,             -- Output parameter to indicate success or failure
    @Message NVARCHAR(255) OUTPUT    -- Output parameter to hold the message
)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
    -- Insert new order into Orders table
        INSERT INTO Orders 
        (
            CustomerID,
            EmployeeID,
            TotalPrice,
            DeliveryAddress,
            Status
        )
        VALUES 
        (
            @CustomerID,
            @EmployeeID,
            @TotalPrice,
            @DeliveryAddress,
            @Status
        )
        SET @Success = 1
        SET @Message = 'Order insertion was successful.'
    END TRY
    BEGIN CATCH
        SET @Success = 0
        SET @Message = ERROR_MESSAGE()
    END CATCH
END
GO

-- DECLARE @Success BIT
-- DECLARE @ResultMessage NVARCHAR(255)

-- EXEC sp_InsertNewOrder 
--     @CustomerID = 1, 
--     @EmployeeID = 1, 
--     @TotalPrice = 99.99, 
--     @DeliveryAddress = '123 Main St, City, Country',
--     @Success = @Success OUTPUT,
--     @Message = @ResultMessage OUTPUT

-- -- Check the result
-- SELECT @Success AS Success, @ResultMessage AS Message



--add new order detail



--find available tables
USE project
GO

CREATE PROCEDURE sp_MakeReservation
    @CustomerEmail NVARCHAR(100),
    @StartTime DATETIME,
    @NumberOfPeople INT,
    @OutputMessage NVARCHAR(255) OUTPUT
AS
BEGIN
    -- Declare variables
    DECLARE @CustomerID INT
    DECLARE @EndTime DATETIME
    DECLARE @AvailableTableID INT

    -- Initialize variables
    SET @EndTime = DATEADD(HOUR, 2, @StartTime) -- 2 hours after the start time

    -- Check if the customer already exists
    SELECT @CustomerID = CustomerID FROM Customers WHERE Email = @CustomerEmail

    -- If customer doesn't exist, exit the procedure
    IF @CustomerID IS NULL
    BEGIN
        SET @OutputMessage = 'Customer does not exist.'
        RETURN
    END

    -- Check for an available table
    SELECT TOP 1 @AvailableTableID = T.TableID
    FROM Tables T
    WHERE T.Capacity >= @NumberOfPeople
    AND NOT EXISTS (
        SELECT 1 FROM Reservations R
        WHERE R.TableID = T.TableID
        AND (
            (R.StartTime <= @StartTime AND R.EndTime >= @StartTime)
            OR (R.StartTime <= @EndTime AND R.EndTime >= @EndTime)
            OR (@StartTime <= R.StartTime AND @EndTime >= R.StartTime)
        )
    )
    ORDER BY T.Capacity ASC

    -- If an available table is found, make the reservation
    IF @AvailableTableID IS NOT NULL
    BEGIN
        INSERT INTO Reservations (CustomerID, TableID, StartTime, EndTime)
        VALUES (@CustomerID, @AvailableTableID, @StartTime, @EndTime)

        SET @OutputMessage = 'Reservation made successfully.'
    END
    ELSE
    BEGIN
        SET @OutputMessage = 'No available tables for the given time and capacity.'
    END
END
GO





--create a function that look for the accses lvl and return the the user type
USE project
GO

CREATE PROCEDURE sp_GetUserTypeByEmail
    @Email NVARCHAR(100),
    @UserType NVARCHAR(50) OUTPUT
AS
BEGIN
    -- Initialize the output parameter
    SET @UserType = NULL

    -- Get the user type based on the email
    SELECT @UserType = UT.UserType
    FROM Customers C
    INNER JOIN UserTypes UT ON C.UserTypeID = UT.UserTypeID
    WHERE C.Email = @Email

    -- If no user is found with the given email, set UserType to 'Not Found'
    IF @UserType IS NULL
    BEGIN
        SET @UserType = 'Not Found'
    END
END
GO






----------------------------------------------------------------
------------------------accsess---------------------------------
----------------------------------------------------------------

