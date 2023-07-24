-- Dumping database structure for AccountServiceDB
CREATE DATABASE "AccountServiceDB";
USE "AccountServiceDB";

-- Dumping structure for table AccountServiceDB.Users
-- DROP TABLE "Users";
CREATE TABLE "Users" (
	"UserGuid" UNIQUEIDENTIFIER NOT NULL,
	"Username" NVARCHAR(max) NOT NULL,
	"Email" NVARCHAR(max) NOT NULL,
	"Password" NVARCHAR(max) NOT NULL,
	"StreetAddress" NVARCHAR(max) NOT NULL,
	"City" NVARCHAR(max) NOT NULL,
	"State" NVARCHAR(max) NOT NULL,
	"Country" NVARCHAR(max) NOT NULL,
	"ZipCode" NVARCHAR(max) NOT NULL,
	"CardNumber" INT NOT NULL,
	"ExpirationDate" DATETIME2(7) NOT NULL,
	"CVV" NVARCHAR(max) NOT NULL,
	PRIMARY KEY ("UserGuid")
);