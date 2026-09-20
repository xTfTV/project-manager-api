DROP PROCEDURE IF EXISTS SP_Project_Insert;

DELIMITER //

CREATE PROCEDURE SP_Project_Insert (
    IN p_project_name VARCHAR(255),
    IN p_priority_id INT,
    IN p_project_status_id INT,
    IN p_project_due_date DATETIME,
    IN p_comments VARCHAR(500),
    IN p_created_by_user_id INT
)

BEGIN

    INSERT INTO Projects 
    (
        project_name,
        priority_id,
        project_status_id,
        project_due_date,
        comments,
        created_by_user_id,
        logical_cancel_value
    )
    VALUES
    (
        p_project_name,
        p_priority_id,
        p_project_status_id,
        p_project_due_date,
        p_comments,
        p_created_by_user_id,
        0
    );

    SELECT LAST_INSERT_ID() AS project_id;

END //

DELIMITER ;

