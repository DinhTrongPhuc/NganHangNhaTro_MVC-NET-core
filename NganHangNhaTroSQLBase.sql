-- ==========================================
-- T?o c? s? d? li?u
-- ==========================================
CREATE DATABASE NganHangNhaTro_Simple;
GO

USE NganHangNhaTro_Simple;
GO

-- ==========================================
-- B?ng Users
-- ==========================================
CREATE TABLE Users (
    IdUser INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(100),
    Email NVARCHAR(100),
    PhoneNumber NVARCHAR(20),
    Role NVARCHAR(20)  -- User, Owner, Admin
);
GO

-- ==========================================
-- B?ng Properties (Nhà tr? / phòng cho thuê)
-- ==========================================
CREATE TABLE Properties (
    IdProperty INT IDENTITY(1,1) PRIMARY KEY,
    IdOwner INT NOT NULL,
    Title NVARCHAR(200),
    Description NVARCHAR(MAX),
    Address NVARCHAR(300),
    Price DECIMAL(18,2),
    MaxOccupancy INT,
    Status NVARCHAR(20),  -- Available, Booked
    CONSTRAINT FK_Properties_Owners FOREIGN KEY (IdOwner)
        REFERENCES Users(IdUser)
);
GO

-- ==========================================
-- B?ng Bookings
-- ==========================================
CREATE TABLE Bookings (
    IdBooking INT IDENTITY(1,1) PRIMARY KEY,
    IdUser INT NOT NULL,
    IdProperty INT NOT NULL,
    CheckInDate DATE,
    CheckOutDate DATE,
    TotalPrice DECIMAL(18,2),
    BookingStatus NVARCHAR(20),  -- Pending, Confirmed, Cancelled
    CONSTRAINT FK_Bookings_Users FOREIGN KEY (IdUser)
        REFERENCES Users(IdUser),
    CONSTRAINT FK_Bookings_Properties FOREIGN KEY (IdProperty)
        REFERENCES Properties(IdProperty)
);
GO

-- ==========================================
-- B?ng Payments
-- ==========================================
CREATE TABLE Payments (
    IdPayment INT IDENTITY(1,1) PRIMARY KEY,
    IdBooking INT NOT NULL,
    Amount DECIMAL(18,2),
    PaymentDate DATETIME,
    PaymentMethod NVARCHAR(50),  -- CreditCard, PayPal, Cash
    PaymentStatus NVARCHAR(20),  -- Pending, Completed, Failed
    CONSTRAINT FK_Payments_Bookings FOREIGN KEY (IdBooking)
        REFERENCES Bookings(IdBooking)
);
GO

-- ==========================================
-- D? li?u m?u c? b?n
-- ==========================================
-- Users
INSERT INTO Users (Username, Password, FullName, Email, PhoneNumber, Role)
VALUES
('user1','123456','Nguyen Van A','user1@mail.com','0901111111','User'),
('owner1','123456','Tran Thi B','owner1@mail.com','0902222222','Owner'),
('admin1','123456','Le Van C','admin1@mail.com','0903333333','Admin');

-- Properties
INSERT INTO Properties (IdOwner, Title, Description, Address, Price, MaxOccupancy, Status)
VALUES
(2,'Phòng tr? ti?n nghi 1','Phòng r?ng, thoáng mát','123 ???ng A, Qu?n 1',5000000,2,'Available'),
(2,'Phòng tr? ti?n nghi 2','G?n ch?, có máy l?nh','456 ???ng B, Qu?n 2',4000000,2,'Available');

-- Bookings
INSERT INTO Bookings (IdUser, IdProperty, CheckInDate, CheckOutDate, TotalPrice, BookingStatus)
VALUES
(1,1,'2025-11-10','2025-11-15',25000000,'Pending');

-- Payments
INSERT INTO Payments (IdBooking, Amount, PaymentMethod, PaymentStatus, PaymentDate)
VALUES
(1,25000000,'CreditCard','Pending',GETDATE());
GO
