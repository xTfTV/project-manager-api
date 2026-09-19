DROP PROCEDURE IF EXISTS SP_Project_GetAll;

DELIMITER //

CREATE PROCEDURE SP_Project_GetAll(
    IN p_created_by_user_id INT 
)

BEGIN

SELECT project_id, project_name, priority_id, project_status_id, project_created_date, project_due_date,
       comments, created_by_user_id, logical_cancel_value, project_complete_date
FROM Projects
WHERE logical_cancel_value = 0 AND created_by_user_id = p_created_by_user_id
ORDER BY project_created_date DESC;

END //

DELIMITER ;
