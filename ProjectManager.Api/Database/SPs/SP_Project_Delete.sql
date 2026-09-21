DROP PROCEDURE IF EXISTS SP_Project_Delete;

DELIMITER //

CREATE PROCEDURE SP_Project_Delete
(
    IN p_project_id INT,
    IN p_created_by_user_id INT
)

BEGIN

    DECLARE v_cancelled_status INT;
    
    SELECT project_status_id
    INTO v_cancelled_status
    FROM Project_Status
    WHERE project_status_name = 'Cancelled'
    LIMIT 1;

    UPDATE Projects
    SET 
        logical_cancel_value = 1,
        project_status_id = v_cancelled_status
    WHERE project_id = p_project_id
        AND created_by_user_id = p_created_by_user_id
        AND logical_cancel_value = 0;

    SELECT ROW_COUNT() AS affected_rows;

END //

DELIMITER ;