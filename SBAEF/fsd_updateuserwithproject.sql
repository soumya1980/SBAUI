USE [ProjectTrack]
GO

/****** Object:  StoredProcedure [dbo].[fsd_updateuserwithproject]    Script Date: 25-09-2018 14:27:50 ******/
DROP PROCEDURE [dbo].[fsd_updateuserwithproject]
GO

/****** Object:  StoredProcedure [dbo].[fsd_updateuserwithproject]    Script Date: 25-09-2018 14:27:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[fsd_updateuserwithproject] 
	@employeeId int,
	@projectId int
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Users SET Project_Project_ID=@projectId,
	 IsMgr=1
	WHERE [User_ID] = @employeeId
END

GO


