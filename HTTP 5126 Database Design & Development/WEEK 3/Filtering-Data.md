> # Filtering Data from Table

``` sql
-- BASIC QUERY STRUCTURE
SELECT col1,col2 FROM table_name
WHERE condition(S)
ORDER BY column ASC|DES,column2 ASC|DES
LIMIT num
OFFSET num
```
>## LIMIT
```sql
SELECT * from table_name limit 5;
```

>## OFFSET
> offset must be used with the LIMIT
```sql
SELECT * from table_name LIMIT 5 OFFSET 5;
```


>## LOGICAL OPERATORS

> ### AND | OR | IN | LIKE | BETWEEN | NOT

>### IN
```sql
-- basic query
SELECT * FROM movies WHERE genre ='Action' OR genre= 'Animation' OR genre ='Documentary';

-- optimized query
SELECT * FROM movies WHERE genre NOT ('Action','Animation','Documentary')
```
>### NOT IN
```SQL
SELECT * FROM movies WHERE genre NOT IN ('Action','Animation','Documentary')
```
>### NOT
```SQL
SELECT * FROM MOVIES WHERE release_data >'2020-02-02' NOT genre='Action';
```

>### LIKE
```SQL
SELECT * FROM MOVIES WHERE release_data >'2020-02-02' NOT genre='Action';
```
>### BETWEEN

```SQL
SELECT * FROM stock_item WHERE item  BETWEEN 'A' AND 'N';
```

> ## NULL

>### IS NULL | IS NOT NULL