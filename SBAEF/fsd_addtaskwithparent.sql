USE [ProjectTrack]
GO

/****** Object:  StoredProcedure [dbo].[fsd_addtaskwithparent]    Script Date: 25-09-2018 14:27:21 ******/
DROP PROCEDURE [dbo].[fsd_addtaskwithparent]
GO

/****** Object:  StoredProcedure [dbo].[fsd_addtaskwithparent]    Script Date: 25-09-2018 14:27:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[fsd_addtaskwithparent] 
	@parentTaskId int,
	@projectId int,
	@taskName varchar(300),
	@startDt date,
	@endDt date,
	@priority int,
	@status varchar(20),
	@userId int
AS
BEGIN
	SET NOCOUNT ON;
	
	INSERT Tasks (TaskName,StartDt,EndDt,[Priority],[Status],ParentTask_Parent_ID,Project_Project_ID) 
    VALUES (@taskName,@startDt,@endDt,@priority,@status,@parentTaskId,@projectId)
	UPDATE Users SET Task_Task_ID=(select MAX(Task_ID) from Tasks) 
	WHERE [User_ID]=@userId
	
	
END

GO


