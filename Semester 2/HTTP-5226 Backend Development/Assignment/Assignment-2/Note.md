### Create Migration
```cs
dotnet ef migrations add InitialCreate --context Assignment_2.Data.ApplicationDbContext && dotnet ef migrations add SeedRoles --context Assignment_2.Data.ApplicationDbContext &&  dotnet ef database update --context Assignment_2.Data.ApplicationDbContext 
```

###  Update Migration
```cs
dotnet ef database update --context Assignment_2.Data.ApplicationDbContext
```
### Add Seed
```cs
dotnet ef migrations add SeedRoles --context Assignment_2.Data.ApplicationDbContext
```
### Drop all the tables
```sql
-- Drops all tables in the public schema
DO $$ 
DECLARE 
    r RECORD;
BEGIN
    FOR r IN (SELECT tablename FROM pg_tables WHERE schemaname = 'public') LOOP
        EXECUTE 'DROP TABLE IF EXISTS public.' || quote_ident(r.tablename) || ' CASCADE;';
    END LOOP;
END $$;
```