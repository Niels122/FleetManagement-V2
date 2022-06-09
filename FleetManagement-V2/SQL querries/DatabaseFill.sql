--Alle tables leegmaken, om ze daarna opnieuw op te vullen.

--TRUNCATE TABLE bestuurder
--TRUNCATE TABLE voertuig
--TRUNCATE TABLE adres
--TRUNCATE TABLE tankkaart
--GO


	INSERT INTO tankkaart

		([tankkaartnummer]
		,[geldigheidsDatum]
		,[brandstof]
		,[pincode]
		,[isGeblokkeerd])

	  VALUES
	  ('123456789', '2024-12-31', 'benzine'		, 1234, 0),
	  ('987654321', '2024-12-31', 'benzine'		, 1111, 0),
	  ('123654789', '2024-12-31', 'diesel'		, 4321, 0),
	  ('321456987', '2022-10-31', 'benzine'		, 3456, 0),
	  ('111222333', '2022-10-31', 'elektrisch'	, 6789, 0)
	 

  INSERT INTO voertuig

		([chassisnummer]
		,[nummerplaat]
		,[merk]
		,[model]
		,[typevoertuig]
		,[brandstof]
		,[kleur]
		,[aantalDeuren])

	  VALUES
	  ('WVWND23B5YE381216', 'AAA-111', 'mercedes'	, 'cls'	, 'personenauto', 'benzine'		, 'grijs'	, '5'),
	  ('1FT8W3BTXCEB73445',	'BBB-222', 'volkswagen'	, 'polo', 'personenauto', 'benzine'		, 'blauw'	, '3'),
	  ('JM1BK32F581189675', 'CCC-333', 'audi'		, 'a3'	, 'bestelwagen'	, 'diesel'		, 'zwart'	, '5'),
	  ('5TDZK22C39S270189',	'DDD-444', 'volkswagen'	, 'golf', 'personenauto', 'benzine'		, 'geel'	, '5'),
	  ('1G2ZM151764127062',	'EEE-555', 'audi'		, 'q8'	, 'bestelwagen'	, 'elektrisch'	, 'groen'	, '5')




	INSERT INTO adres

		([straat]
		,[huisnummer]
		,[postcode]
		,[stad])

	  VALUES
	  ('Pelikaanstraat' , '122'	, 9700	, 'Oudenaarde'),
	  ('Stationstraat'	, '6'	, 9070	, 'Destelbergen'),
	  ('Vogelstraat'	, '7a'	, 9000	, 'Gent'),
	  ('Kergate'		, '65'	, 9800	, 'Astene'),
	  ('Weedreef'		, '1'	, 8700	, 'Tielt')


INSERT INTO bestuurder

      ([id]
	  ,[naam]
      ,[voornaam]
      ,[geboortedatum]
      ,[rijksregisternummer]
      ,[rijbewijstype]
      ,[tankkaartnummer]
      ,[chassisnummerVoertuig]
      ,[adresId])

	  VALUES 
	  ('111111nv'	,'Van Maelzaeke'	,'Niels'	,'1999-12-07', '99120750392','B','123456789', 'WVWND23B5YE381216', 1),
	  ('222222bs'	,'Sajgo'			,'Benedek'	,'1996-07-15', '96071800169','B','987654321', '1FT8W3BTXCEB73445', 2),
	  ('333333jv'	,'Vos'				,'Jan'		,'1958-06-10', '58061000186','C','123654789', 'JM1BK32F581189675', 3),
	  ('444444bv'	,'Varen'			,'Bart'		,'2002-02-02', '02020200124','B','321456987', '5TDZK22C39S270189', 4),
	  ('555555vl'	,'Van Wal'			,'Lena'		,'1986-05-09', '86050900217','C','111222333', '1G2ZM151764127062', 5)

	  


	 

