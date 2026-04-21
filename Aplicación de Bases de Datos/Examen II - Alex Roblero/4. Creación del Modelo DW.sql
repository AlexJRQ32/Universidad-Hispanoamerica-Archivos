--------------------------------------------------------------------------------
-- Creacion del Modelo Multidimensional.
-- Se conecta con el usuario creado para el modelo DW.
--------------------------------------------------------------------------------

CREATE TABLE DIM_CLIENTE(
    CTE_ID INTEGER PRIMARY KEY NOT NULL,
    CTE_NOMBRE    VARCHAR2(100) NOT NULL,
    CTE_DIRECCION VARCHAR2(255) NOT NULL
);

CREATE TABLE FACT_PRESTAMOS(
    PRS_ID INTEGER PRIMARY KEY NOT NULL,
    PRS_CTE_ID INTEGER NOT NULL,
    PRS_MONTO  DECIMAL(10,2) NOT NULL,
    PRS_TASA_INTERES DECIMAL(5,2) NOT NULL,
    PRS_LIMITE_CREDITO DECIMAL(20,2) NOT NULL,
    CONSTRAINT FK_PRS_CTE FOREIGN KEY(PRS_CTE_ID) REFERENCES DIM_CLIENTE(CTE_ID)
);





