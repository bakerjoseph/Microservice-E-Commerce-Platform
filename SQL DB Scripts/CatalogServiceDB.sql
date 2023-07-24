-- Dumping database structure for CatalogService
CREATE DATABASE "CatalogService";
USE "CatalogService";

-- Dumping structure for table CatalogService.products
-- DROP TABLE "products";
CREATE TABLE "products" (
	"product_guid" UNIQUEIDENTIFIER NOT NULL,
	"amount" INT NOT NULL,
	"description" VARCHAR(4000) NULL,
	"dimensions" VARCHAR(255) NULL,
	"name" VARCHAR(255) NULL,
	"price" FLOAT NOT NULL,
	"weight" FLOAT NOT NULL,
	PRIMARY KEY ("product_guid")
);
