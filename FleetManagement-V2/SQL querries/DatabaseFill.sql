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
	  ('Van Maelzaeke','Niels','2024-12-31', '99120750392','B',1,1,1)



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
	  ('AAA-111', 'WVWND23B5YE381216', 'mercedes', 'CLS', 'personenauto', 'benzine', 'grijs', '5')


	INSERT INTO tankkaart
		([tankkaartnummer]
      ,[geldigheidsDatum]
      ,[brandstof]
      ,[pincode]
      ,[isActief])

	  VALUES
	  ('123456789', '2024-12-31', 'benzine', 1234, 1)



	INSERT INTO adres
	(  [straat]
      ,[huisnummer]
      ,[postcode]
      ,[stad])

	  VALUES
	  ('Pelikaanstraat', '122', 9700, 'Oudenaarde')