--DROP TABLE bestuurder; 
CREATE TABLE bestuurder (
	id INT IDENTITY(1,1) PRIMARY KEY,
	naam VARCHAR(45) NULL,
	voornaam VARCHAR(45) NULL,
	geboortedatum DATE NOT NULL,
	rijksregisternummer VARCHAR(11) NOT NULL UNIQUE,
	rijbewijstype VARCHAR(45) NULL,
	voertuigId INT NULL UNIQUE,
	tankkaartId INT NULL UNIQUE,
	adresId INT NOT NULL,
)
GO

-- DROP TABLE tankkaart;
CREATE TABLE tankkaart(
	id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	tankkaartnummer VARCHAR(45) NOT NULL UNIQUE,
	geldigheidsDatum DATE NOT NULL,
	brandstof VARCHAR(45) NULL,
	pincode INT NULL,
	isActief BIT NOT NULL,
)
GO

--
--DROP TABLE voertuig;
CREATE TABLE voertuig (
	id INT IDENTITY(1,1) PRIMARY KEY,
	nummerplaat VARCHAR(45) NOT NULL UNIQUE,
	chassisnummer VARCHAR(45) NOT NULL UNIQUE,
	merk VARCHAR(45) NULL,
	model VARCHAR(45) NULL,
	typevoertuig VARCHAR(45) NULL,
	brandstof VARCHAR(45) NULL,
	kleur VARCHAR(45) NULL,
	aantalDeuren VARCHAR(45) NULL,
)
GO

CREATE TABLE adres(
	id INT IDENTITY(1,1) PRIMARY KEY,
	straat VARCHAR(255) NOT NULL,
	huisnummer VARCHAR(10) NOT NULL,
	postcode INT NOT NULL,
	stad VARCHAR(255) NOT NULL,
)
GO

ALTER TABLE bestuurder ADD CONSTRAINT FK_AdresIdBestuurder FOREIGN KEY (adresId) REFERENCES adres(id);
ALTER TABLE bestuurder ADD CONSTRAINT FK_VoertuigIdBestuurder FOREIGN KEY (voertuigId) REFERENCES voertuig(id);
ALTER TABLE bestuurder ADD CONSTRAINT FK_TankkaartIdBestuurder FOREIGN KEY (tankkaartId) REFERENCES tankkaart(id);