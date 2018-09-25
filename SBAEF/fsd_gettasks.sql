USE [ProjectTrack]
GO

/****** Object:  StoredProcedure [dbo].[fsd_gettasks]    Script Date: 25-09-2018 14:27:38 ******/
DROP PROCEDURE [dbo].[fsd_gettasks]
GO

/****** Object:  StoredProcedure [dbo].[fsd_gettasks]    Script Date: 25-09-2018 14:27:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[fsd_gettasks] 
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT T.Task_ID,T.TaskName,CAST(T.StartDt AS DATE) AS StartDt,CAST(T.EndDt AS DATE) AS EndDt,T.[Priority],T.[Status],PT.Parent_Task,PT.Parent_ID,
	P.Project_ID,P.ProjectDesc
  FROM Tasks T, ParentTasks PT, Projects P
  WHERE
  T.Project_Project_ID=P.Project_ID AND
  T.ParentTask_Parent_ID=PT.Parent_ID

  UNION
    

  select T.Task_ID,T.TaskName,CAST(T.StartDt AS DATE) AS StartDt,CAST(T.EndDt AS DATE) AS EndDt,T.[Priority],T.[Status],NULL,NULL,
  T.Project_Project_ID,P.ProjectDesc
  from Tasks T,Projects P
  where	 T.ParentTask_Parent_ID IS NULL AND
  T.Project_Project_ID=P.Project_ID
	
	
END
GO


