DROP PROCEDURE IF EXISTS SP_Project_GetByFilter;

DELIMITER //

CREATE PROCEDURE SP_Project_GetByFilter
(
    IN p_created_by_user_id INT,
    IN p_priority_id INT,
    IN p_project_status_id INT,
    IN p_page INT,
    IN p_page_size INT
)

BEGIN

    DECLARE v_offset INT;

    SET v_offset = (p_page - 1) * p_page_size;

    SELECT project_id, project_name, priority_id, project_status_id, project_created_date,
           project_due_date, comments, created_by_user_id, logical_cancel_value, project_complete_date
    FROM Projects
    WHERE created_by_user_id = p_created_by_user_id
        AND logical_cancel_value = 0
        AND project_status_id IN (1,2,3)
        AND ( p_priority_id IS NULL OR priority_id = p_priority_id )
        AND ( p_project_status_id IS NULL OR project_status_id = p_project_status_id )
    ORDER BY project_created_date DESC
    LIMIT p_page_size OFFSET v_offset;

    SELECT COUNT(*) AS total_count
    FROM Projects
    WHERE created_by_user_id = p_created_by_user_id
        AND logical_cancel_value = 0
        AND project_status_id IN (1,2,3)
        AND ( p_priority_id IS NULL OR priority_id = p_priority_id )
        AND ( p_project_status_id IS NULL OR project_status_id = p_project_status_id )

END //

DELIMITER ;
