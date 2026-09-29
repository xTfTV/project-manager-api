DROP PROCEDURE IF EXISTS SP_Priority_GetAll;

DELIMITER //

CREATE PROCEDURE SP_Priority_GetAll()

BEGIN

    SELECT
        priority_id, priority_name
    FROM Priority
    WHERE LCV = 0
    ORDER BY priority_id;

END //

DELIMITER ;
