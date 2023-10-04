CREATE PROCEDURE [dbo].[SP_FILTERGAMEBYTYPE]
	@typeId INT
AS
BEGIN
	SELECT *
	FROM [dbo].[G_GAMETYPES_VIEW]
	WHERE [g_id] IN
	(
		SELECT [g_id]
		FROM [dbo].[G_GAME] G
		INNER JOIN [dbo].[GT_GAME_TYPE] GT ON G.[g_id] = GT.[gt_game_id]
		WHERE GT.[gt_type_id] = @typeId
	)
END
