--DROP DATABASE FleetmanagementDB


--DROP TABLE tankkaart;
--DROP TABLE adres;
--DROP TABLE bestuurder;
--DROP TABLE voertuig;
--GO

CREATE DATABASE FleetmanagementDB;

GO
USE FleetmanagementDB;
GO

CREATE TABLE FleetmanagementDB.dbo.tankkaart(
	tankkaartnummer VARCHAR(18) PRIMARY KEY,
	geldigheidsDatum DATE NOT NULL,
	brandstof VARCHAR(45) NULL, 
	pincode INT NULL,
	isGeblokkeerd BIT NOT NULL,
	isDeleted BIT NOT NULL DEFAULT 0,
)

GO


CREATE TABLE FleetmanagementDB.dbo.voertuig (

	chassisnummer VARCHAR(17) PRIMARY KEY,
	nummerplaat VARCHAR(45) NOT NULL,
	merk VARCHAR(45) NOT NULL,
	model VARCHAR(45) NOT NULL,
	typevoertuig VARCHAR(45) NOT NULL,
	brandstof VARCHAR(45) NOT NULL,
	kleur VARCHAR(45) NULL,
	aantalDeuren int NULL,
	isDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT UC_Nummerplaat UNIQUE (nummerplaat),
)
	
GO

CREATE TABLE FleetmanagementDB.dbo.adres(
	id INT IDENTITY(1,1) PRIMARY KEY,
	straat VARCHAR(255) NOT NULL,
	huisnummer VARCHAR(10) NOT NULL,
	postcode INT NOT NULL,
	stad VARCHAR(255) NOT NULL,
)
GO

CREATE TABLE FleetmanagementDB.dbo.bestuurder (
	id VARCHAR(8) PRIMARY KEY,
	naam VARCHAR(45) NOT NULL,
	voornaam VARCHAR(45) NOT NULL,
	geboortedatum DATE NOT NULL,
	rijksregisternummer VARCHAR(11) NOT NULL,
	rijbewijstype VARCHAR(15) NOT NULL,
	chassisnummerVoertuig VARCHAR(17) NULL,
	tankkaartnummer VARCHAR(18) NULL,
	adresId INT NULL,
	isDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT UC_Rijksregisternummer UNIQUE (rijksregisternummer),
	--CONSTRAINT UC_VoertuigId UNIQUE (voertuigId),
	--CONSTRAINT UC_TankkaartId UNIQUE (tankkaartId),

)

	CREATE UNIQUE INDEX UI_ChassisnummerVoertuig
	ON bestuurder(chassisnummerVoertuig)
	WHERE chassisnummerVoertuig IS NOT NULL

	CREATE UNIQUE INDEX UI_Tankkaartnummer
	ON bestuurder(tankkaartnummer)
	WHERE tankkaartnummer IS NOT NULL
GO



ALTER TABLE bestuurder ADD CONSTRAINT FK_AdresBestuurder FOREIGN KEY (adresId) REFERENCES adres(id);
ALTER TABLE bestuurder ADD CONSTRAINT FK_VoertuigBestuurder FOREIGN KEY (chassisnummerVoertuig) REFERENCES voertuig(chassisnummer);
ALTER TABLE bestuurder ADD CONSTRAINT FK_TankkaartBestuurder FOREIGN KEY (tankkaartnummer) REFERENCES tankkaart(tankkaartnummer);