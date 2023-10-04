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
INSERT INTO [dbo].[GT_GAME_TYPE] ([gt_game_id], [gt_type_id])
VALUES  (1003, 010),
        (1003, 110),
        (1003, 200),
        (1004, 000),
        (1004, 100),
        (1004, 110),
        (1004, 210);

*/
