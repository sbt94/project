USE FinalSQL
-- Drop child tables (those having foreign keys)
DROP TABLE IF EXISTS OrderProduct;
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

USE FinalSQL

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetUserTypeByEmail')
    DROP PROCEDURE sp_GetUserTypeByEmail;
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_MakeReservation')
    DROP PROCEDURE sp_MakeReservation;

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_InsertOrderWithProducts')
    DROP PROCEDURE sp_InsertOrderWithProducts;
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_CreateNewUser')
    DROP PROCEDURE sp_CreateNewUser;
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_CreateNewEmployee')
    DROP PROCEDURE sp_CreateNewEmployee;
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_AddMenuItem')
    DROP PROCEDURE sp_AddMenuItem;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetReservationsByEmail')
    DROP PROCEDURE sp_GetReservationsByEmail;
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetUpcomingReservations')
    DROP PROCEDURE sp_GetUpcomingReservations;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_CreateNewOrder')
    DROP PROCEDURE sp_CreateNewOrder;
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_InsertOrderProduct')
    DROP PROCEDURE sp_InsertOrderProduct;
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetAllMenuItems')
    DROP PROCEDURE sp_GetAllMenuItems;
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetOrderDetails')
    DROP PROCEDURE sp_GetOrderDetails;
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_GetTotalPriceByOrderID')
    DROP PROCEDURE sp_GetTotalPriceByOrderID;
GO



USE FinalSQL
-- Check and drop the tr_Customers_Delete_Log trigger if it exists
IF OBJECT_ID('tr_Customers_Insert_Log', 'TR') IS NOT NULL
    DROP TRIGGER tr_Customers_Delete_Log;
GO
USE FinalSQL
-- Check and drop the tr_Reservations_Delete_Log trigger if it exists
IF OBJECT_ID('tr_Reservations_Insert_Log', 'TR') IS NOT NULL
    DROP TRIGGER tr_Reservations_Delete_Log;
GO
USE FinalSQL
-- Check and drop the tr_Orders_Delete_Log trigger if it exists
IF OBJECT_ID('tr_Orders_Insert_Log', 'TR') IS NOT NULL
    DROP TRIGGER tr_Orders_Delete_Log;
GO
USE FinalSQL
-- Check and drop the tr_Customers_Delete_Log trigger if it exists
IF OBJECT_ID('tr_Customers_Delete_Log', 'TR') IS NOT NULL
    DROP TRIGGER tr_Customers_Delete_Log;
GO
USE FinalSQL
-- Check and drop the tr_Reservations_Delete_Log trigger if it exists
IF OBJECT_ID('tr_Reservations_Delete_Log', 'TR') IS NOT NULL
    DROP TRIGGER tr_Reservations_Delete_Log;
GO
USE FinalSQL
-- Check and drop the tr_Orders_Delete_Log trigger if it exists
IF OBJECT_ID('tr_Orders_Delete_Log', 'TR') IS NOT NULL
    DROP TRIGGER tr_Orders_Delete_Log;
GO

--------------------------------------------------------------------------------------------   
--------------------------------------create tables-----------------------------------------
--------------------------------------------------------------------------------------------   


USE FinalSQL
-- UserTypes
CREATE TABLE UserTypes (
   UserTypeID INT PRIMARY KEY IDENTITY(1,1),
   UserType NVARCHAR(50) NOT NULL
);

INSERT INTO UserTypes (UserType) VALUES ('Manager'), ('Employee'), ('Customer'); -- only manager can add new employee
GO

USE FinalSQL
-- Customers
CREATE TABLE Customers (
   CustomerID INT PRIMARY KEY IDENTITY(1,1),
   FirstName NVARCHAR(50) NOT NULL,
   LastName NVARCHAR(50),
   Email NVARCHAR(100) UNIQUE,
   PhoneNumber NVARCHAR(20),
   Address NVARCHAR(250),
   Password NVARCHAR(255),
   UserTypeID INT FOREIGN KEY REFERENCES UserTypes(UserTypeID) DEFAULT 3
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

use FinalSQL
-- Orders
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
    OrderDate DATETIME DEFAULT GETDATE(),
    TotalPrice FLOAT DEFAULT 0
);

-- OrderDetails
CREATE TABLE OrderProduct (
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

CREATE TRIGGER tr_Orders_After_Insert
ON Orders
AFTER INSERT
AS
BEGIN
    INSERT INTO Logs (UserID, UserType, Action, Description)
    SELECT 
        i.CustomerID, 
        'Customer', 
        'Insert Order', 
        'New order placed with OrderID: ' + CAST(i.OrderID AS NVARCHAR(10)) + ' and total price of ' + CAST(i.TotalPrice AS NVARCHAR(50)) + '.'
    FROM INSERTED i;
END;
GO
CREATE TRIGGER tr_Orders_After_Delete
ON Orders
AFTER DELETE
AS
BEGIN
    INSERT INTO Logs (UserID, UserType, Action, Description)
    SELECT 
        d.CustomerID, 
        'Customer', 
        'Delete Order', 
        'Order with OrderID: ' + CAST(d.OrderID AS NVARCHAR(10)) + ' and total price of ' + CAST(d.TotalPrice AS NVARCHAR(50)) + ' was deleted.'
    FROM DELETED d;
END;
GO

---
-- Assuming you have a Prices column in the MenuItems table
-- Trigger on the Orders table
CREATE TRIGGER tr_SetDefaultTotalPriceOnOrder
ON Orders
AFTER INSERT
AS
BEGIN
    -- Setting default price, this is optional as you already have a default in the table definition
    UPDATE Orders
    SET TotalPrice = 0
    WHERE OrderID IN (SELECT OrderID FROM inserted)
END
GO

-- Trigger on the OrderProduct table
CREATE TRIGGER tr_UpdateTotalPriceAfterOrderProductInsert
ON OrderProduct
AFTER INSERT
AS
BEGIN
    -- Update the TotalPrice in the Orders table based on the inserted products
    UPDATE Orders
    SET TotalPrice = TotalPrice + (i.Quantity * m.Price)
    FROM Orders o
    JOIN inserted i ON o.OrderID = i.OrderID
    JOIN MenuItems m ON i.MenuItemID = m.MenuItemID
END
GO

--------------------------------------------------------------------------------------------
--------------------------------------insert data------------------------------------------
--------------------------------------------------------------------------------------------

use FinalSQL
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

use FinalSQL
DECLARE @orderCounter INT = 1;
WHILE @orderCounter <= 100 -- Assuming 100 customers
BEGIN
    -- Insert order
    INSERT INTO Orders (CustomerID, TotalPrice)
    VALUES (@orderCounter, 
           (3.99 + (RAND() * 40)));  -- Random total price

    -- Get the last inserted Order ID
    DECLARE @lastOrderID INT;
    SET @lastOrderID = SCOPE_IDENTITY();

    -- Insert 3 random dishes for this order
    DECLARE @detailCounter INT = 1;
    WHILE @detailCounter <= 3
    BEGIN
        INSERT INTO OrderProduct (OrderID, MenuItemID, Quantity)
        VALUES (@lastOrderID, 
               (RAND() * 20) + 1,  -- Random dish from the menu
               (RAND() * 3) + 1);  -- Random quantity between 1 and 3

        SET @detailCounter = @detailCounter + 1;
    END

    SET @orderCounter = @orderCounter + 1;
END;
GO

USE FinalSQL

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
(2, 3, '2023-09-11 20:00:00'),
(101, 1, '2023-12-10 19:00:00'),   -- Note: Using TableID (1 for 101, 2 for 102, 3 for 103)
(101, 3, '2023-11-11 20:00:00');

-- Insert data for Orders
INSERT INTO Orders (CustomerID, TotalPrice)
VALUES (1, 25.99), 
       (2, 30.50), 
       (3, 15.75);

INSERT INTO OrderProduct (OrderID, MenuItemID, Quantity)
VALUES (1, 1, 2),  -- 2 units of MenuItem 1
       (1, 2, 1),  -- 1 unit of MenuItem 2
       (1, 3, 1);  -- 1 unit of MenuItem 3

-- Details for Order with ID 2
INSERT INTO OrderProduct (OrderID, MenuItemID, Quantity)
VALUES (2, 4, 2),
       (2, 5, 2),
       (2, 6, 1);

-- Details for Order with ID 3
INSERT INTO OrderProduct (OrderID, MenuItemID, Quantity)
VALUES (3, 7, 1),
       (3, 8, 1),
       (3, 9, 2),
       (3, 10, 1);
GO

use FinalSQL
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


----------------------------------------------------------------
------------------procedures------------------------------------
----------------------------------------------------------------

--create a new customer    if the cretion sucseed it will retuen 1 
USE FinalSQL
GO
CREATE PROCEDURE sp_CreateNewUser
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Email NVARCHAR(100),
    @PhoneNumber NVARCHAR(20),
    @Address NVARCHAR(250),
    @Password NVARCHAR(255),
    @UserTypeID INT,
	@outvar INT OUTPUT
AS
BEGIN
	set @outvar=0;
    BEGIN TRANSACTION;  -- Start the transaction
    BEGIN TRY
        -- Check if the email already exists
        IF EXISTS (SELECT 1 FROM Customers WHERE Email = @Email)
        BEGIN
            ROLLBACK;
            RETURN @outvar;  -- Email already exists
        END

        -- Insert the new user
        INSERT INTO Customers (FirstName, LastName, Email, PhoneNumber, Address, Password, UserTypeID)
        VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Address, @Password, @UserTypeID)

        -- Commit the transaction if successful
        COMMIT;
        
        -- Return success
		set @outvar=1;
        RETURN @outvar;
    END TRY
    BEGIN CATCH
        ROLLBACK;  -- Rollback the transaction if there's an error
       set @outvar =0;
	   RETURN @outvar;
    END CATCH;
END;
GO




--create a new employee
USE FinalSQL
GO

CREATE PROCEDURE sp_CreateNewEmployee
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Email NVARCHAR(100),
    @PhoneNumber NVARCHAR(20),
    @HireDate DATE,
    @Salary FLOAT,
    @Password NVARCHAR(255),
    @UserTypeID INT,
	@outvar INT OUTPUT

AS
BEGIN
-- we use transaction to make sure that the employee will be added only if the email is not exist
    BEGIN TRANSACTION;  -- Start the transaction
    BEGIN TRY
        -- Check if the email already exists
        IF EXISTS (SELECT 1 FROM Employees WHERE Email = @Email)
        BEGIN
            ROLLBACK;
            set @outvar =0;
			RETURN @outvar; -- Email already exists
        END

        -- Insert the new employee
        INSERT INTO Employees (FirstName, LastName, Email, PhoneNumber, HireDate, Salary, Password, UserTypeID)
        VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @HireDate, @Salary, @Password, @UserTypeID)

        -- Commit the transaction if successful
        COMMIT;
        
        -- Return success
		set @outvar =1;
	   RETURN @outvar;    END TRY
    BEGIN CATCH
        ROLLBACK;  -- Rollback the transaction if there's an error
		set @outvar =0;
	   RETURN @outvar;    END CATCH;
END;
GO





--add new reservetion


-- add new order
USE FinalSQL
GO

CREATE PROCEDURE sp_InsertOrderWithProducts
    @CustomerID INT,
    @MenuItemIDs NVARCHAR(MAX),  -- Comma-separated list of MenuItemIDs
    @Quantities NVARCHAR(MAX),   -- Comma-separated list of Quantities
    @Success BIT OUTPUT,         -- Output parameter to indicate success or failure
    @Message NVARCHAR(255) OUTPUT-- Output parameter to hold the message
AS
BEGIN
    SET NOCOUNT ON;
-- we use transaction to make sure that the order will be added only if the order details are added
    BEGIN TRANSACTION;  -- Start the transaction
    BEGIN TRY
        DECLARE @NewOrderID INT;

        -- Insert new order into Orders table
        INSERT INTO Orders (CustomerID)
        VALUES (@CustomerID);

        -- Get the ID of the newly inserted order
        SET @NewOrderID = SCOPE_IDENTITY();

        -- Split MenuItemIDs and Quantities
        ;WITH MenuItemsCTE AS
        (
            SELECT value AS MenuItemID, ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS RowNum
            FROM STRING_SPLIT(@MenuItemIDs, ',')
        ),
        QuantitiesCTE AS
        (
            SELECT value AS Quantity, ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS RowNum
            FROM STRING_SPLIT(@Quantities, ',')
        )

        -- Insert product details for the new order
        INSERT INTO OrderProduct (OrderID, MenuItemID, Quantity)
        SELECT @NewOrderID, CAST(m.MenuItemID AS INT), CAST(q.Quantity AS INT) 
        FROM MenuItemsCTE m
        JOIN QuantitiesCTE q ON m.RowNum = q.RowNum;

        -- Commit the transaction if successful
        COMMIT;
        
        SET @Success = 1;
        SET @Message = 'Order and OrderProducts insertion was successful.';
        RETURN 1;
    END TRY
    BEGIN CATCH
        ROLLBACK;  -- Rollback the transaction if there's an error
        SET @Success = 0;
        SET @Message = ERROR_MESSAGE();
        RETURN 0;
    END CATCH;
END;
GO


USE FinalSQL;
GO

CREATE PROCEDURE sp_AddMenuItem
    @Name NVARCHAR(100),
    @Description NVARCHAR(255) = NULL, -- Making this optional by setting a default of NULL
    @Price FLOAT
AS
BEGIN
    -- Insert the provided details into the MenuItems table
    INSERT INTO MenuItems (Name, Description, Price)
    VALUES (@Name, @Description, @Price);
    
    -- You can add any additional logging or error handling here if needed
END;
GO

EXEC sp_AddMenuItem @Name='Cheeseburger', @Description='Delicious burger with cheese', @Price=9.99;


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
-- we use transaction to make sure that the table will be available when the customer make the reservation
USE FinalSQL
GO
CREATE PROCEDURE sp_MakeReservation
    @CustomerEmail NVARCHAR(100),
    @StartTime DATETIME,
    @NumberOfPeople INT,
    @OutputMessage NVARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;  -- Start the transaction
    BEGIN TRY
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
            ROLLBACK;  -- Rollback the transaction
            RETURN 0;
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

            -- Commit the transaction if successful
            COMMIT;

            SET @OutputMessage = 'Reservation made successfully.';
            RETURN 1;
        END
        ELSE
        BEGIN
            SET @OutputMessage = 'No available tables for the given time and capacity.';
            ROLLBACK;  -- Rollback the transaction
            RETURN 0;
        END
    END TRY
    BEGIN CATCH
        ROLLBACK;  -- Rollback the transaction if there's an error
        SET @OutputMessage = ERROR_MESSAGE();
        RETURN 0;
    END CATCH;
END;
GO






--create a function that look for the accses lvl and return the the user type
USE FinalSQL
GO

CREATE PROCEDURE sp_GetUserTypeByEmail
    @Email NVARCHAR(100),
	@Password NVARCHAR(100),
    @UserType NVARCHAR(50) OUTPUT
AS
BEGIN
    -- Initialize the output parameter
    SET @UserType = NULL

    -- Get the user type based on the email
    SELECT @UserType = UT.UserType
    FROM Customers C
    INNER JOIN UserTypes UT ON C.UserTypeID = UT.UserTypeID
    WHERE C.Email = @Email and C.Password= @Password

    -- If no user is found with the given email, set UserType to 'Not Found'
    IF @UserType IS NULL
    BEGIN
        SET @UserType = 'Not Found'
    END
END
GO

USE FinalSQL
GO
--show all the future reservations or those that are still in progres 
CREATE PROCEDURE sp_GetUpcomingReservations
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * 
    FROM Reservations
    WHERE StartTime > GETDATE() OR EndTime > GETDATE();
    
    SET NOCOUNT OFF;
END;
GO


USE FinalSQL
GO
-- return all all the reservations of a costumer based on Email
CREATE PROCEDURE sp_GetReservationsByEmail
    @Email NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT r.*
    FROM Reservations r
    INNER JOIN Customers c ON r.CustomerID = c.CustomerID
    WHERE c.Email = @Email;

    SET NOCOUNT OFF;
END;
GO

USE FinalSQL
GO

CREATE PROCEDURE sp_InsertOrderProduct
    @OrderID INT,
    @MenuItemID INT,
    @Quantity INT
AS
BEGIN
    SET NOCOUNT ON;  -- Suppress the count of affected rows

    BEGIN TRANSACTION;  -- Start a new transaction

    BEGIN TRY
        -- Insert the order details into the OrderProduct table
        INSERT INTO OrderProduct (OrderID, MenuItemID, Quantity)
        VALUES (@OrderID, @MenuItemID, @Quantity);

        -- Commit the transaction
        COMMIT;
    END TRY
    BEGIN CATCH
        -- An error occurred, rollback the transaction
        ROLLBACK;

    END CATCH;
END;
GO

USE FinalSQL
GO

CREATE PROCEDURE sp_CreateNewOrder
    @Email NVARCHAR(100),
    @NewOrderID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;  -- Suppress the count of affected rows

    BEGIN TRANSACTION;  -- Start a new transaction

    BEGIN TRY
        -- Declare a variable to hold the CustomerID
        DECLARE @CustomerID INT;

        -- Get the CustomerID based on the email
        SELECT @CustomerID = CustomerID FROM Customers WHERE Email = @Email;

        -- Check if the customer exists
        IF @CustomerID IS NULL
        BEGIN
            ROLLBACK;  -- Rollback the transaction
            SET @NewOrderID = 0;  -- Indicate that the customer was not found
            RETURN;
        END

        -- Create a new order for the customer
        INSERT INTO Orders (CustomerID)
        VALUES (@CustomerID);

        -- Get the ID of the newly created order
        SET @NewOrderID = SCOPE_IDENTITY();

        -- Commit the transaction
        COMMIT;
    END TRY
    BEGIN CATCH
        -- An error occurred, rollback the transaction
        ROLLBACK;

        -- Set @NewOrderID to indicate an error
        SET @NewOrderID = 0;

        
    END CATCH;
END;
GO

USE FinalSQL
GO

CREATE PROCEDURE sp_GetAllMenuItems
AS
BEGIN
    SET NOCOUNT ON;  -- Suppress the count of affected rows

    -- Select all rows from the MenuItems table
    SELECT * FROM MenuItems;
END;
GO

USE FinalSQL
GO

CREATE PROCEDURE sp_GetOrderDetails
    @OrderID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Join the OrderProduct table with the MenuItems table to get details
    SELECT 
        O.OrderID,
        M.MenuItemID,
        M.Name AS MenuItemName,
        M.Description AS MenuItemDescription,
        M.Price AS MenuItemPrice,
        O.Quantity
    FROM 
        OrderProduct O
    INNER JOIN 
        MenuItems M ON O.MenuItemID = M.MenuItemID
    WHERE 
        O.OrderID = @OrderID;
END;
GO

USE FinalSQL
GO

CREATE PROCEDURE sp_GetTotalPriceByOrderID
    @OrderID INT,
    @TotalPrice FLOAT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Initialize the output parameter
    SET @TotalPrice = 0.0

    -- Get the total price based on the order ID
    SELECT @TotalPrice = TotalPrice
    FROM Orders
    WHERE OrderID = @OrderID

    -- If no order is found with the given order ID, set TotalPrice to NULL
    IF @TotalPrice IS NULL
    BEGIN
        SET @TotalPrice = NULL
    END
END
GO


----------------------------------------------------------------
------------------------accsess---------------------------------
----------------------------------------------------------------

-- Create Manager login
CREATE LOGIN Manager WITH PASSWORD = '12345';
GO

-- Create Employee login
CREATE LOGIN Employee WITH PASSWORD = '6789';
GO

-- Create Customer login
CREATE LOGIN Customer WITH PASSWORD = '54321';
GO


USE FinalSQL;
GO

-- Create a database user for Manager and associate it with the login
CREATE USER ManagerUser FOR LOGIN Manager;
GO

-- Create a database user for Employee and associate it with the login
CREATE USER EmployeeUser FOR LOGIN Employee;
GO

-- Create a database user for Customer and associate it with the login
CREATE USER CustomerUser FOR LOGIN Customer;
GO


-- Grant SELECT permission on the Customers table to the CustomerUser
USE FinalSQL;
GO

-- Grant execute permissions on sp_InsertOrderWithProducts
GRANT EXECUTE ON sp_InsertOrderWithProducts TO ManagerUser, EmployeeUser, CustomerUser;
GO

-- Grant execute permissions on sp_MakeReservation
GRANT EXECUTE ON sp_MakeReservation TO ManagerUser, EmployeeUser, CustomerUser;
GO

-- Grant execute permissions on sp_CreateNewUser
GRANT EXECUTE ON sp_CreateNewUser TO ManagerUser, EmployeeUser, CustomerUser;
GO


-- Grant execute permissions on sp_CreateNewEmployee
GRANT EXECUTE ON sp_CreateNewEmployee TO ManagerUser;

USE FinalSQL;
GO

-- Grant execute permissions on sp_GetUserTypeByEmail to ManagerUser
GRANT EXECUTE ON sp_GetUserTypeByEmail TO ManagerUser,EmployeeUser;
GO

-- Grant execute permissions on sp_GetReservationsByEmail
GRANT EXECUTE ON sp_GetReservationsByEmail TO ManagerUser, EmployeeUser,CustomerUser;
GO


-- Grant execute permissions on sp_GetUpcomingReservations
GRANT EXECUTE ON sp_GetUpcomingReservations TO ManagerUser,EmployeeUser;
GO

-- Grant execute permissions on sp_InsertOrderProduct
GRANT EXECUTE ON sp_InsertOrderProduct TO CustomerUser;
GO

-- Grant execute permissions on sp_CreateNewOrder
GRANT EXECUTE ON sp_CreateNewOrder TO CustomerUser;
GO

GRANT EXECUTE ON sp_GetAllMenuItems TO CustomerUser;
GO

GRANT EXECUTE ON sp_GetOrderDetails TO CustomerUser;
GO

GRANT EXECUTE ON sp_GetTotalPriceByOrderID TO CustomerUser;
GO
