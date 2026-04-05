--------------------------------------------------------------------------------
-- Creación de usuario para modelo Staging Area.
-- Luego crea la conexión.
-- Se ejecuta con SYS.
--------------------------------------------------------------------------------
alter session set "_ORACLE_SCRIPT" = TRUE;
CREATE USER SISVENTAS_SA IDENTIFIED BY Oracle01 DEFAULT TABLESPACE USERS QUOTA UNLIMITED ON USERS;
GRANT CONNECT, RESOURCE TO SISVENTAS_SA;