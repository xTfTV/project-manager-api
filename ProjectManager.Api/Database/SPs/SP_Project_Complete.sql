DROP PROCEDURE IF EXISTS SP_Project_Complete;

DELIMITER //

CREATE PROCEDURE SP_Project_Complete
(
    IN p_project_id INT,
    IN p_created_by_user_id INT
)

BEGIN

    DECLARE v_completed_status_id INT;

    SELECT project_status_id 
    INTO v_completed_status_id
    FROM Project_Status
    WHERE project_status_name = 'Completed'
    LIMIT 1;

    UPDATE Projects
    SET
        project_status_id = v_completed_status_id,
        project_complete_date = CURRENT_TIMESTAMP
    WHERE project_id = p_project_id
        AND created_by_user_id = p_created_by_user_id
        AND logical_cancel_value = 0;

    SELECT ROW_COUNT() AS affected_rows;

END //

DELIMITER ;