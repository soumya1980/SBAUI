USE [ProjectTrack]
GO

/****** Object:  StoredProcedure [dbo].[fsd_getprojectsandstatus]    Script Date: 25-09-2018 14:27:32 ******/
DROP PROCEDURE [dbo].[fsd_getprojectsandstatus]
GO

/****** Object:  StoredProcedure [dbo].[fsd_getprojectsandstatus]    Script Date: 25-09-2018 14:27:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[fsd_getprojectsandstatus] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT T.*, 
CASE 
WHEN T.EndDt > GETDATE() THEN 'OPEN'
ELSE 'CLOSED'
END AS [Status]
FROM
(select T.Project_Project_ID,P.ProjectDesc,P.[Priority],CAST(P.StartDt AS DATE) AS StartDt,CAST(P.EndDt AS DATE) AS EndDt, 
COUNT(T.Task_ID) AS TaskNos
FROM Tasks T,Projects P
WHERE T.Project_Project_ID=P.Project_ID
GROUP BY T.Project_Project_ID,P.ProjectDesc,P.[Priority],CAST(P.StartDt AS DATE),CAST(P.EndDt AS DATE)) AS T

UNION

SELECT P.Project_ID,P.ProjectDesc,P.[Priority],CAST(P.StartDt AS DATE) AS StartDt,CAST(P.EndDt AS DATE) AS EndDt,0 AS TaskNos,'OPEN'  
FROM Projects P WHERE P.Project_ID NOT IN (SELECT T.Project_Project_ID  FROM Tasks T)

END
GO


