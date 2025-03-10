WITH RecursivePackaging AS (
    SELECT PackagingID, PackagingType, ParentPackagingID, ProductID
    FROM Packaging
    WHERE ProductID = 1  -- Replace with specific ProductID
    UNION ALL
    SELECT p.PackagingID, p.PackagingType, p.ParentPackagingID, p.ProductID
    FROM Packaging p
    INNER JOIN RecursivePackaging rp ON p.ParentPackagingID = rp.PackagingID
)
SELECT rp.PackagingID, rp.PackagingType, rp.ParentPackagingID
FROM RecursivePackaging rp
ORDER BY rp.PackagingID;
