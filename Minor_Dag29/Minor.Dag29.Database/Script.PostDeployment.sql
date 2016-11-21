/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/



ALTER DATABASE [$(DatabaseName)]
 MODIFY FILE
 (
  NAME = [$(DatabaseName)],
  SIZE = 10MB, FILEGROWTH = 100MB
 )
GO     
ALTER DATABASE [$(DatabaseName)]
 MODIFY FILE
 (
  NAME = [$(DatabaseName)_log],
  SIZE = 10MB, FILEGROWTH = 100MB
 )
GO  