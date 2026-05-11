># MySQL Aggregate
```SQL
-- CONCATENATE
SELECT CONCAT(price + inventory) AS 'Combined' FROM stock_item ;
-- MIN()
SELECT MAX(price) AS 'MAX' FROM stock_item;

-- MIN()
SELECT MIN(price) AS 'MIN' FROM stock_item;

-- SUM()
SELECT SUM(price) AS 'SUM' FROM stock_item;

-- COUNT()
SELECT COUNT(*) AS 'TOTAL' FROM stock_item;

-- GROUP BY | ORDER BY 
SELECT category AS Category,COUNT(*) AS 'Total' FROM stock_item GROUP BY category ORDER BY Total ASC, Category ASC;

-- HAVING
SELECT category AS Category,COUNT(*) AS 'Total' FROM stock_item  GROUP BY category HAVING Total >5 ORDER BY Total ASC, Category ASC;

-- LIMIT
SELECT category AS Category,COUNT(*) AS 'Total' FROM stock_item  GROUP BY category HAVING Total >5 ORDER BY Total ASC, Category ASC LIMIT 2;

-- OFFSET

SELECT category AS Category,COUNT(*) AS 'Total' FROM stock_item  GROUP BY category HAVING Total >5 ORDER BY Total ASC, Category ASC LIMIT 2 OFFSET 1;

```