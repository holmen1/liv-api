# liv-api


1. start sql server
   
    /liv-api$ docker-compose up -d
2. update database

   liv-api/LivApi$ dotnet ef database update
3. run

   liv-api/LivApi$ dotnet run



## lessons learned
USE master

GO

ALTER DATABASE TodoDb SET SINGLE_USER WITH ROLLBACK IMMEDIATE

GO

DROP DATABASE TodoDb

GO
