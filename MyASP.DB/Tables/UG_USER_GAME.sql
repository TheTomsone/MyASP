CREATE TABLE [dbo].[UG_USER_GAME]
(
	[ug_user_id] INT NOT NULL,
	[ug_game_id] INT NOT NULL,
	PRIMARY KEY ([ug_user_id], [ug_game_id])
)
