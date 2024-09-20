DELETE FROM sach
WHERE maSach IN (
    SELECT maSach FROM (
        SELECT maSach FROM sach
        ORDER BY maSach
        LIMIT 18446744073709551615 OFFSET 32
    ) AS temp
);
SET SQL_SAFE_UPDATES = 0;

WITH records_to_delete AS (
    SELECT maSach
    FROM chitietphieunhap
    ORDER BY maSach
    LIMIT 18446744073709551615 OFFSET 45
)
DELETE FROM chitietphieunhap
WHERE maSach IN (SELECT maSach FROM records_to_delete);

SET SQL_SAFE_UPDATES = 0;
SET SQL_SAFE_UPDATES = 1;

SELECT * FROM qlchs_cnpm.sach;
SELECT * FROM qlchs_cnpm.taikhoan;
SELECT * FROM qlchs_cnpm.khuyenmai;

UPDATE sach
SET maSach = maSach + 1
WHERE maSach >= 10;