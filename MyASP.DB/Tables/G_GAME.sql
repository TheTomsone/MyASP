﻿CREATE TABLE [dbo].[G_GAME]
(
	[g_id] INT NOT NULL PRIMARY KEY IDENTITY,
	[g_title] VARCHAR(100) NOT NULL,
	[g_resume] VARCHAR(MAX)
)