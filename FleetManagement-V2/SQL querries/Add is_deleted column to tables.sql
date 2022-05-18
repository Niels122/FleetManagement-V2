--Add is_deleted column to tables (for soft deletion)

  ALTER TABLE adres ADD is_deleted BIT 
  UPDATE adres
  SET is_deleted = 0
   
   ALTER TABLE voertuig ADD is_deleted BIT 
  UPDATE adres
  SET is_deleted = 0
   
   ALTER TABLE tankkaart ADD is_deleted BIT 
  UPDATE adres
  SET is_deleted = 0
   
   ALTER TABLE bestuurder ADD is_deleted BIT 
  UPDATE adres
  SET is_deleted = 0