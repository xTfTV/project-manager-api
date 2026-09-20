DROP PROCEDURE IF EXISTS SP_User_GetForLogin;

DELIMITER //

CREATE PROCEDURE SP_User_GetForLogin(
    IN p_email_address VARCHAR(255)
)
BEGIN

SELECT user_id, first_name, last_name, email_address, password_hash,
       user_role_id, logical_cancel_value, created_date
FROM user_info
WHERE email_address = p_email_address
    AND IFNULL(logical_cancel_value, 0) = 0
LIMIT 1;

END //

DELIMITER ;
