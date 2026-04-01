# Accessing data from Database
> ## Naming Convention

```
snake_case
 college_course
```
> ## Database
```
Singular name for the database name
eg : movie_db
```
> ## table
```
noun
Table name can be plural or singular
eg users, user
```

>### SQL QUERY
``` SQL
-- DISTINCT
SELECT DISTINCT name,course,code FROM college;

-- WHERE
SELECT * FROM college WHERE course ='DEV';
```

>### AS / Alias
```SQL
-- ALIAS
SELECT course_id AS 'ID' FROM customers;
```
