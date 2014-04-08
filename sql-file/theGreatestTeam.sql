ALTER TABLE customer
  ADD isAdmin bit;

UPDATE Customer
SET isAdmin = 0;

UPDATE Customer
SET isAdmin = 1
WHERE customer_id = 1;