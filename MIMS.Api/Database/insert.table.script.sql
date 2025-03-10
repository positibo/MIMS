-- Insert Products
INSERT INTO Products (ProductName) VALUES ('Self Adjusting Table');

-- Insert Packagings for a Product
INSERT INTO Packaging (PackagingType, ProductID) VALUES ('Box', 1);
INSERT INTO Packaging (PackagingType, ParentPackagingID, ProductID) VALUES ('Box', 1, 1);  -- Nested inside first box
INSERT INTO Packaging (PackagingType, ProductID) VALUES ('Box', 1);
INSERT INTO Packaging (PackagingType, ProductID) VALUES ('Packet', 1);
INSERT INTO Packaging (PackagingType, ProductID) VALUES ('Packet', 1);

-- Insert Items for Packaging
-- For Box 1
INSERT INTO Items (ItemName, PackagingID) VALUES ('Table Top', 1);
-- For Box 2
INSERT INTO Items (ItemName, PackagingID) VALUES ('Table Legs', 2);
-- For Packet 1
INSERT INTO Items (ItemName, PackagingID) VALUES ('Screwdriver', 4);
-- For Packet 2
INSERT INTO Items (ItemName, PackagingID) VALUES ('Screws', 5);