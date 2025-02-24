
--CREATE DATABASE BOOKHUP;

use BOOKHUP


create table Authors (
	AuthorID int IDENTITY(1,1) primary key ,
	AuthorsName varchar(255) not null,
	Bio text ,
	Nationality varchar(100) not null ,
	DateOfBirth date,
	Website varchar(255) NOT NULL
);

create table Categories (
	CategoryID int IDENTITY(1,1) primary key ,
	CategoryName varchar(100) not null unique
);

create table Publishers(
	PublisherID int IDENTITY(1,1) primary key,
	PublisherName varchar(255) NOT NULL,
	PublisherAddress text,
	website varchar(255) NOT NULL
);



create table Books (
	BookID  int IDENTITY(1,1) primary key  ,
	Title varchar(255) NOT NULL,
	AuthorID int FOREIGN KEY REFERENCES Authors(AuthorID) NOT NULL ,
	CategoryID int FOREIGN KEY REFERENCES Categories(CategoryID) NOT NULL,
	PublisherID int FOREIGN KEY REFERENCES Publishers(PublisherID) NOT NULL,
	ISBN varchar(20),-- الرقم الدولى للكتاب 
	BookDescription text ,
	CoverImage VARBINARY(MAX) NOT NULL,
	Price money NOT NULL ,
	Stock int ,
	DownloadLink varchar(225) NOT NULL,
	UploadDate datetime NOT NULL

);


create table Users(
UserID int primary key IDENTITY(1,1),
FullName varchar(255) not null,
Email varchar(255)unique not null,
PasswordHash varchar(255) not null,
UserRole varchar(50) ,
JoinDate datetime ,
ProfilePicture varchar(255) not NULL
);

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT not null,
    BookID INT not null,
    Quantity INT,
    Price DECIMAL(10, 2) 
);

alter table OrderDetails
add FOREIGN key (BookID) REFERENCES Books(BookID);
alter table OrderDetails
add FOREIGN key (OrderID) REFERENCES Orders(OrderID);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT not null,
    OrderDate DATETIME,
    TotalAmount DECIMAL(10, 2), 
    OrderStatus VARCHAR(50)
);

alter table Orders
add FOREIGN key (UserID) REFERENCES Users(UserID);

CREATE TABLE Reviews (
    ReviewID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT not null,
    BookID INT not null,
    Rating INT,
    Comment TEXT,
    ReviewDate DATETIME
);

alter table Reviews
add FOREIGN key (UserID) REFERENCES Users(UserID);
alter table Reviews
add FOREIGN key (BookID) REFERENCES Books(BookID);

CREATE TABLE Cart (
    CartID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT not null,
    BookID INT ,
    Quantity INT
);
alter table Cart
add FOREIGN key (UserID) REFERENCES Users(UserID);
alter table Cart
add FOREIGN key (BookID) REFERENCES Books(BookID);