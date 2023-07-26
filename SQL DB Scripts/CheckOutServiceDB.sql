-- Dumping database structure for CheckOutServiceDB
CREATE DATABASE "CheckOutServiceDB";
USE "CheckOutServiceDB";

-- Dumping structure for table CheckOutServiceDB.Users
CREATE TABLE "Users" (
	"userGuid" UNIQUEIDENTIFIER NOT NULL,
	"username" NVARCHAR(max) NOT NULL,
	"email" NVARCHAR(max) NOT NULL,
	"password" NVARCHAR(max) NOT NULL,
	"streetAddress" NVARCHAR(max) NOT NULL,
	"city" NVARCHAR(max) NOT NULL,
	"state" NVARCHAR(max) NOT NULL,
	"country" NVARCHAR(max) NOT NULL,
	"zipCode" NVARCHAR(max) NOT NULL,
	"cardNumber" INT NOT NULL,
	"expirationDate" DATETIME2(7) NOT NULL,
	"cvv" NVARCHAR(3) NOT NULL,
	PRIMARY KEY ("userGuid")
);

-- Dumping structure for table CheckOutServiceDB.Orders
CREATE TABLE "Orders" (
	"orderGuid" UNIQUEIDENTIFIER NOT NULL,
	"userGuid" UNIQUEIDENTIFIER NOT NULL,
	"basketGuid" UNIQUEIDENTIFIER NOT NULL,
	"placedDate" DATETIME2(7) NOT NULL,
	PRIMARY KEY ("orderGuid"),
	CONSTRAINT "FK_Orders_Users_userGuid" FOREIGN KEY ("userGuid") REFERENCES "Users" ("userGuid")
);

-- Dumping structure for table CheckOutServiceDB.Products
CREATE TABLE "Products" (
	"productGuid" UNIQUEIDENTIFIER NOT NULL,
	"orderGuid" UNIQUEIDENTIFIER NOT NULL,
	"name" NVARCHAR(max) NOT NULL,
	"description" NVARCHAR(4000) NOT NULL,
	"dimensions" NVARCHAR(max) NOT NULL,
	"weight" FLOAT NOT NULL,
	"price" FLOAT NOT NULL,
	"amount" INT NOT NULL,
	PRIMARY KEY ("productGuid"),
	CONSTRAINT "FK_Products_Orders_orderGuid" FOREIGN KEY ("orderGuid") REFERENCES "Orders" ("orderGuid")
);
