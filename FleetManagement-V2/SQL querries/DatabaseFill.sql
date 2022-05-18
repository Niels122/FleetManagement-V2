--Alle tables leegmaken, om ze daarna opnieuw op te vullen.

--TRUNCATE TABLE bestuurder
--TRUNCATE TABLE voertuig
--TRUNCATE TABLE adres
--TRUNCATE TABLE tankkaart
--GO


INSERT INTO bestuurder
      ([naam]
      ,[voornaam]
      ,[geboortedatum]
      ,[rijksregisternummer]
      ,[rijbewijstype]
      ,[voertuigId]
      ,[tankkaartId]
      ,[adresId])

	  VALUES 
	  ('Van Maelzaeke','Niels','1999-12-07', '99120750392','B',1,1,1),
	  ('Sajgo','Benedek','1996-07-15', '96071800169','B',2,2,2),
	  ('Vos','Jan','1958-06-10', '58061000186','C',3,3,3),
	  ('Varen','Bart','2002-02-02', '02020200124','B',4,4,4),
	  ('Van Wal','Lena','1986-05-09', '86050900217','C',5,5,5)


  INSERT INTO voertuig
		([nummerplaat]
      ,[chassisnummer]
      ,[merk]
      ,[model]
      ,[typevoertuig]
      ,[brandstof]
      ,[kleur]
      ,[aantalDeuren])

	  VALUES
	  ('AAA-111', 'WVWND23B5YE381216', 'mercedes'	, 'cls'	, 'personenauto', 'benzine'		, 'grijs'	, '5'),
	  ('BBB-222', '1FT8W3BTXCEB73445', 'volkswagen'	, 'polo', 'personenauto', 'benzine'		, 'blauw'	, '3'),
	  ('CCC-333', 'JM1BK32F581189675', 'audi'		, 'a3'	, 'bestelwagen'	, 'diesel'		, 'zwart'	, '5'),
	  ('DDD-444', '5TDZK22C39S270189', 'volkswagen'	, 'golf', 'personenauto', 'benzine'		, 'geel'	, '5'),
	  ('EEE-555', '1G2ZM151764127062', 'audi'		, 'q8'	, 'bestelwagen'	, 'elektrisch'	, 'groen'	, '5')


	INSERT INTO tankkaart
		([tankkaartnummer]
      ,[geldigheidsDatum]
      ,[brandstof]
      ,[pincode]
      ,[isActief])

	  VALUES
	  ('123456789', '2024-12-31', 'benzine'		, 1234, 1),
	  ('987654321', '2024-12-31', 'benzine'		, 1111, 1),
	  ('123654789', '2024-12-31', 'diesel'		, 4321, 1),
	  ('321456987', '2022-10-31', 'benzine'		, 3456, 1),
	  ('111222333', '2022-10-31', 'elektrisch'	, 6789, 1)
	 



	INSERT INTO adres
	(  [straat]
      ,[huisnummer]
      ,[postcode]
      ,[stad])

	  VALUES
	  ('Pelikaanstraat' , '122'	, 9700	, 'Oudenaarde'),
	  ('Stationstraat'	, '6'	, 9070	, 'Destelbergen'),
	  ('Vogelstraat'	, '7a'	, 9000	, 'Gent'),
	  ('Kergate'		, '65'	, 9800	, 'Astene'),
	  ('Weedreef'		, '1'	, 8700	, 'Tielt')