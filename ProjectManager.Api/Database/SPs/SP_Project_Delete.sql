DROP PROCEDURE IF EXISTS SP_Project_Delete

DELIMITER //

CREATE PROCEDURE SP_Project_Delete
(
    IN p_project_id INT,
    IN p_created_by_user_id INT
)

BEGIN

    UPDATE Projects
    SET logical_cancel_value = 1
    WHERE project_id = p_project_id
        AND created_by_user_id = p_created_by_user_id
        AND logical_cancel_value = 0;

    SELECT ROW_COUNT() AS affected_rows;

END //

DELIMITER ;