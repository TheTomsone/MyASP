CREATE VIEW [dbo].[G_GAMETYPES_VIEW]
	AS
		SELECT G.[g_id], G.[g_title], G.[g_resume], STRING_AGG(T.[t_name], ', ') AS GameTypes
		FROM [dbo].[G_GAME] G
		INNER JOIN [dbo].[GT_GAME_TYPE] GT ON G.[g_id] = GT.[gt_game_id]
		INNER JOIN [dbo].[T_TYPE] T ON GT.[gt_type_id] = T.[t_id]
		GROUP BY G.[g_id], G.[g_title], G.[g_resume]