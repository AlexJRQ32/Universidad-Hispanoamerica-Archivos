--------------------------------------------------------------------------------
-- Creación de usuario para modelo Multidimensional.
-- Luego crea la conexión.
-- Se ejecuta con SYS.
--------------------------------------------------------------------------------
alter session set "_ORACLE_SCRIPT" = TRUE;
CREATE USER SISVENTAS_DW IDENTIFIED BY Oracle01 DEFAULT TABLESPACE USERS QUOTA UNLIMITED ON USERS;
GRANT CONNECT, RESOURCE TO SISVENTAS_DW;