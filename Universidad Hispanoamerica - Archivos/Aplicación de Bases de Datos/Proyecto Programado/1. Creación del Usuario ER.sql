--------------------------------------------------------------------------------
-- Creación de usuario para modelo Entidad-Relación.
-- Luego crea la conexión.
-- Se crea con el usuario SYS.
--------------------------------------------------------------------------------
alter session set "_ORACLE_SCRIPT" = TRUE;
CREATE USER SISVENTAS_ER IDENTIFIED BY Oracle01 DEFAULT TABLESPACE USERS QUOTA UNLIMITED ON USERS;
GRANT CONNECT, RESOURCE TO SISVENTAS_ER;