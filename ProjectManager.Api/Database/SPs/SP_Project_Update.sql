DROP PROCEDURE IF EXISTS SP_Project_Update;

DELIMITER //

CREATE PROCEDURE SP_Project_Update
(
    IN p_project_id INT,
    IN p_project_name VARCHAR(255),
    IN p_priority_id INT,
    IN p_project_status_id INT,
    IN p_project_due_date DATETIME,
    IN p_comments VARCHAR(500),
    IN p_created_by_user_id INT
)

BEGIN

    UPDATE Projects
    SET
        project_name = p_project_name,
        priority_id = p_priority_id,
        project_status_id = p_project_status_id,
        project_due_date = p_project_due_date,
        comments = p_comments
    WHERE project_id = p_project_id
        AND created_by_user_id = p_created_by_user_id
        AND logical_cancel_value = 0;

    SELECT ROW_COUNT() AS affected_rows;

END //

DELIMITER ;