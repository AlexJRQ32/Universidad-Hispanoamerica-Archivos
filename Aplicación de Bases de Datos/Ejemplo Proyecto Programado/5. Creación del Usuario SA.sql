--------------------------------------------------------------------------------
-- Creación de usuario para modelo Sataging Area
-- Luego crea la conexión.
-- Se crea con el usuario SYS.
--------------------------------------------------------------------------------
alter session set "_ORACLE_SCRIPT" = TRUE;
CREATE USER SISBANCA_SA IDENTIFIED BY Oracle01 DEFAULT TABLESPACE USERS QUOTA UNLIMITED ON USERS;
GRANT CONNECT, RESOURCE TO SISBANCA_SA;