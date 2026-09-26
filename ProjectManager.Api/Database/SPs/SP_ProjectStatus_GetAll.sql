DROP PROCEDURE IF EXISTS SP_ProjectStatus_GetAll;

DELIMITER //

CREATE PROCEDURE SP_ProjectStatus_GetAll()

BEGIN

    SELECT project_status_id, project_status_name
    FROM Project_Status
    WHERE LCV = 0 AND project_status_id IN (1,2,3)
    ORDER BY project_status_id;

END //

DELIMITER ;
