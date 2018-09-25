USE [ProjectTrack]
GO

/****** Object:  StoredProcedure [dbo].[fsd_updatetaskwithprojectandparent]    Script Date: 25-09-2018 14:27:45 ******/
DROP PROCEDURE [dbo].[fsd_updatetaskwithprojectandparent]
GO

/****** Object:  StoredProcedure [dbo].[fsd_updatetaskwithprojectandparent]    Script Date: 25-09-2018 14:27:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[fsd_updatetaskwithprojectandparent] 
	@taskId int,
	@projectId int,
	@parentTaskId int=NULL,
	@userId int
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Tasks SET Project_Project_ID=@projectId,
	 ParentTask_Parent_ID=@parentTaskId
	WHERE [Task_ID] = @taskId
	UPDATE Users SET Task_Task_ID=@taskId
	WHERE [User_ID]= @userId
END

GO


