# Following This Video 
# How To Code An ATM Console App In C# | Programming Tutorial For Beginners | Visual Studio 2022

[![Video thumbnail](https://img.youtube.com/vi/qBI7Qnz9Zho/maxresdefault.jpg)](https://www.youtube.com/watch?v=qBI7Qnz9Zho)

https://youtu.be/qBI7Qnz9Zho?si=hxw-6c68G8LCVzbn

```sql

-- Create ATM database
CREATE DATABASE ATM;

-- Use the ATM database
USE ATM;

-- Create CardHolders table
CREATE TABLE CardHolders (
    CardHolderId INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    CardNumber VARCHAR(16) NOT NULL,
    PINNumber VARCHAR(4) NOT NULL,
    Balance DECIMAL(10, 2) NOT NULL
    Amount DECIMAL(10, 2)  NULL
);

-- Insert sample data
INSERT INTO CardHolders (FirstName, LastName, CardNumber, PINNumber, Balance)
VALUES
    ('John', 'Doe', '1234567890123456', '1234', 1000.00),
    ('Jane', 'Smith', '9876543210987654', '5678', 500.00),
    ('Alice', 'Johnson', '1111222233334444', '4321', 1500.00);


```
