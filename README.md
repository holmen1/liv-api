# liv-api


1. start sql server
   
    /LivApi$ docker-compose up -d
2. update database

   /LivApi$ dotnet ef database update
3. run

   /LivApi$ dotnet run



## lessons learned
USE master

GO

ALTER DATABASE TodoDb SET SINGLE_USER WITH ROLLBACK IMMEDIATE

GO

DROP DATABASE TodoDb

GO
