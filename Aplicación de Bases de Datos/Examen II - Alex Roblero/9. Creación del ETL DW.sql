--------------------------------------------------------------------------------
-- Función para validar numeros enteros.
--------------------------------------------------------------------------------
CREATE OR REPLACE FUNCTION VALIDA_NUMERO_ENTERO(P_NUMERO VARCHAR2) RETURN CHAR AS
   V_NUMERO NUMBER;
BEGIN
   V_NUMERO := TO_NUMBER(P_NUMERO);
   IF V_NUMERO = TRUNC(V_NUMERO) THEN
      RETURN 'S';
   ELSE
      RETURN 'N';
   END IF;
EXCEPTION
   WHEN OTHERS THEN
      RETURN 'N';
END;
/

CREATE OR REPLACE FUNCTION VALIDA_NUMERO_DECIMAL(P_NUMERO VARCHAR2) RETURN CHAR AS
   V_NUMERO NUMBER(20,2);
BEGIN
   V_NUMERO := TO_NUMBER(P_NUMERO);
   IF V_NUMERO <> TRUNC(V_NUMERO) THEN
      RETURN 'S';
   ELSE
      RETURN 'N';
   END IF;
EXCEPTION
   WHEN OTHERS THEN
      RETURN 'N';
END;
/
--------------------------------------------------------------------------------
-- Se crea una tabla de errores por cada tabla del DW.
--------------------------------------------------------------------------------

CREATE TABLE SISFINANZAS_DW.ERROR_SA_CLIENTE (
    CTE_ID              VARCHAR2(4000),
    CTE_NOMBRE          VARCHAR2(4000),
    CTE_DIRECCION       VARCHAR2(4000),
    CTE_LIMITE_CREDITO  VARCHAR2(4000),
    CTE_ERROR           VARCHAR2(4000)
);

CREATE TABLE SISFINANZAS_DW.ERROR_SA_PRESTAMO (
    PST_ID              VARCHAR2(4000),
    PST_CTE_ID          VARCHAR2(4000),
    PST_MONTO           VARCHAR2(4000),
    PST_TASA_INTERES    VARCHAR2(4000),
    PST_ERROR           VARCHAR2(4000)
);

--------------------------------------------------------------------------------
-- Especificación del parquete.
--------------------------------------------------------------------------------

CREATE OR REPLACE PACKAGE SISFINANZAS_DW.ETL_DW AS
   PROCEDURE MigrarCliente;
   PROCEDURE MigrarPrestamo;
   PROCEDURE MigrarDatos;
END ETL_DW;
/
--------------------------------------------------------------------------------
-- Cuerpo del parquete.
--------------------------------------------------------------------------------

CREATE OR REPLACE PACKAGE BODY SISFINANZAS_DW.ETL_DW AS
   -- Migración de Clientes.
   PROCEDURE MigrarCliente IS
      V_ERROR  INTEGER;
      V_NUMERO NUMBER;
      V_ERROR_MENSAJE VARCHAR2(4000);
      CURSOR C_DATOS IS
         SELECT TC.CTE_ID,
                TC.CTE_NOMBRE,
                TC.CTE_DIRECCION,
                TC.CTE_LIMITE_CREDITO
           FROM SISFINANZAS_SA.SA_CLIENTE TC
          WHERE TC.CTE_ID NOT IN (SELECT D.CTE_ID FROM SISFINANZAS_DW.DIM_CLIENTE D)
          ORDER BY TC.CTE_ID;
   BEGIN
      FOR D_DATOS IN C_DATOS LOOP
         BEGIN
             V_ERROR := 0;
             V_ERROR_MENSAJE := '';
             -----------------------------------------------------------------------
             IF D_DATOS.CTE_ID IS NULL THEN
                V_ERROR := 1;
                V_ERROR_MENSAJE := V_ERROR_MENSAJE || 'Código Nulo. ';
             END IF;
             --- Codigo de Cliente no num rico.
             IF VALIDA_NUMERO_ENTERO(D_DATOS.CTE_ID) = 'N' THEN
                V_ERROR := 1;
                V_ERROR_MENSAJE := V_ERROR_MENSAJE || 'Código no numérico. ';
             ELSE
                V_NUMERO := TO_NUMBER(D_DATOS.CTE_ID);
                --- Codigo de Cliente negativo.
                IF V_NUMERO <= 0 THEN
                   V_ERROR := 1;
                   V_ERROR_MENSAJE := V_ERROR_MENSAJE || 'Código Negativo o cero. ';
                END IF;
             END IF;
             -----------------------------------------------------------------------
             IF D_DATOS.CTE_NOMBRE IS NULL OR LENGTH(D_DATOS.CTE_NOMBRE) < 3 THEN
                 V_ERROR := 1;
                 V_ERROR_MENSAJE := V_ERROR_MENSAJE || 'Nombre inválido o nulo. ';
              END IF;
             -----------------------------------------------------------------------
             IF VALIDA_NUMERO_DECIMAL(D_DATOS.CTE_LIMITE_CREDITO) = 'N' 
                 AND VALIDA_NUMERO_ENTERO(D_DATOS.CTE_LIMITE_CREDITO) = 'N' THEN
                 V_ERROR := 1;
                 V_ERROR_MENSAJE := V_ERROR_MENSAJE || 'Límite crédito no es un número. ';
              END IF;
             -----------------------------------------------------------------------
             IF V_ERROR = 0 THEN
                 INSERT INTO SISFINANZAS_DW.DIM_CLIENTE (CTE_ID, CTE_NOMBRE, CTE_DIRECCION)
                 VALUES (TO_NUMBER(D_DATOS.CTE_ID), D_DATOS.CTE_NOMBRE, D_DATOS.CTE_DIRECCION);
              ELSE

                 INSERT INTO SISFINANZAS_DW.ERROR_SA_CLIENTE (CTE_ID, CTE_NOMBRE, CTE_DIRECCION, CTE_LIMITE_CREDITO, CTE_ERROR)
                 VALUES (D_DATOS.CTE_ID, D_DATOS.CTE_NOMBRE, D_DATOS.CTE_DIRECCION, D_DATOS.CTE_LIMITE_CREDITO, V_ERROR_MENSAJE);
              END IF;
             EXCEPTION
                WHEN OTHERS THEN
                    INSERT INTO SISFINANZAS_DW.ERROR_SA_CLIENTE (CTE_ID, CTE_NOMBRE, CTE_DIRECCION, CTE_LIMITE_CREDITO, CTE_ERROR)
                                                       VALUES (D_DATOS.CTE_ID, D_DATOS.CTE_NOMBRE, D_DATOS.CTE_DIRECCION, D_DATOS.CTE_LIMITE_CREDITO, 'Registro válido, pero con error al insertar');
         END;
      END LOOP;
   END;
   -- Migrar Prestamo
   PROCEDURE MigrarPrestamo IS
      V_ERROR         INTEGER;
      V_ERROR_MENSAJE VARCHAR2(4000);
      CURSOR C_DATOS IS
          SELECT TP.PST_ID,
                 TP.PST_CTE_ID,
                 TP.PST_MONTO,
                 TP.PST_TASA_INTERES
            FROM SISFINANZAS_SA.SA_PRESTAMO TP
           WHERE TP.PST_ID NOT IN (SELECT D.PRS_ID FROM SISFINANZAS_DW.FACT_PRESTAMOS D)
           ORDER BY TP.PST_ID;
   BEGIN
      FOR D_DATOS IN C_DATOS LOOP
         BEGIN
            V_ERROR := 0;
            V_ERROR_MENSAJE := '';
            -----------------------------------------------------------------------
            IF D_DATOS.PST_MONTO IS NULL OR TO_NUMBER(D_DATOS.PST_MONTO) <= 0 THEN
               V_ERROR := 1;
               V_ERROR_MENSAJE := V_ERROR_MENSAJE || 'Monto debe ser positivo. ';
            END IF;
            -----------------------------------------------------------------------
            IF VALIDA_NUMERO_DECIMAL(D_DATOS.PST_TASA_INTERES) = 'N' 
               AND VALIDA_NUMERO_ENTERO(D_DATOS.PST_TASA_INTERES) = 'N' THEN
               V_ERROR := 1;
               V_ERROR_MENSAJE := V_ERROR_MENSAJE || 'Tasa inválida. ';
            END IF;
            -----------------------------------------------------------------------
            DECLARE
               V_EXISTE INTEGER;
            BEGIN
               SELECT COUNT(*) INTO V_EXISTE 
                 FROM SISFINANZAS_DW.DIM_CLIENTE 
                WHERE CTE_ID = TO_NUMBER(D_DATOS.PST_CTE_ID);
               
               IF V_EXISTE = 0 THEN
                  V_ERROR := 1;
                  V_ERROR_MENSAJE := V_ERROR_MENSAJE || 'Cliente no existe en DW. ';
               END IF;
            EXCEPTION 
               WHEN OTHERS THEN 
                  V_ERROR := 1; 
                  V_ERROR_MENSAJE := V_ERROR_MENSAJE || 'Error validando cliente. ';
            END;
            -----------------------------------------------------------------------
            IF V_ERROR = 0 THEN
               INSERT INTO SISFINANZAS_DW.FACT_PRESTAMOS (PRS_ID, PRS_CTE_ID, PRS_MONTO, PRS_TASA_INTERES, PRS_LIMITE_CREDITO)
               VALUES (TO_NUMBER(D_DATOS.PST_ID), TO_NUMBER(D_DATOS.PST_CTE_ID),
                       TO_NUMBER(D_DATOS.PST_MONTO), TO_NUMBER(D_DATOS.PST_TASA_INTERES), 0);
            ELSE
               INSERT INTO SISFINANZAS_DW.ERROR_SA_PRESTAMO (PST_ID, PST_CTE_ID, PST_MONTO, PST_TASA_INTERES, PST_ERROR)
               VALUES (D_DATOS.PST_ID, D_DATOS.PST_CTE_ID, D_DATOS.PST_MONTO, D_DATOS.PST_TASA_INTERES, V_ERROR_MENSAJE);
            END IF;

         EXCEPTION
            WHEN OTHERS THEN
               INSERT INTO SISFINANZAS_DW.ERROR_SA_PRESTAMO (PST_ID, PST_CTE_ID, PST_MONTO, PST_TASA_INTERES, PST_ERROR)
               VALUES (D_DATOS.PST_ID, D_DATOS.PST_CTE_ID, D_DATOS.PST_MONTO, D_DATOS.PST_TASA_INTERES, 'Error inesperado al insertar');
         END;
      END LOOP;
   END MigrarPrestamo;
   ------------------------------
   -- Migración de los datos.
   PROCEDURE MigrarDatos IS
      BEGIN
         MigrarCliente;
         COMMIT;
         MigrarPrestamo;
         COMMIT;
      END;
END ETL_DW;
/

EXECUTE ETL_DW.MigrarDatos;