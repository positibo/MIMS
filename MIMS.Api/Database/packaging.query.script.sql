SELECT p.PackagingID, p.PackagingType
FROM Packaging p
JOIN Items i ON p.PackagingID = i.PackagingID
WHERE i.ItemName = 'Screws';
