--------------------------------------------------------------------------------
-- Primer Ejercicio
--------------------------------------------------------------------------------

SELECT * FROM(
    SELECT CLIENTE, MES, SALDO
    FROM SALDO_CLIENTE
    )
PIVOT(
    SUM(SALDO)
    FOR MES IN( 
               1 "ENERO",
               2 "FEBRERO",
               3 "MARZO",
               4 "ABRIL",
               5 "MAYO",
               6 "JUNIO",
               7 "JULIO",
               8 "AGOSTO",
               9 "SEPTIEMBRE",
               10 "OCTUBRE",
               11 "NOVIEMBRE",
               12 "DICIEMBRE"
               )
    )
ORDER BY CLIENTE;

--------------------------------------------------------------------------------
-- Segundo Ejercicio
--------------------------------------------------------------------------------

SELECT SUCURSAL, MES, PRODUCTO, CANTIDAD 
FROM(
    SELECT SUCURSAL, 
           MES,
           SUM(MOUSE) MOUSE,
           SUM(IMPRESORA) IMPRESORA,
           SUM(TECLADO) TECLADO,
           SUM(LAPTOP) LAPTOP
    FROM VENTAS_SUCURSALES
    GROUP BY SUCURSAL, MES
)
UNPIVOT(
    CANTIDAD
    FOR PRODUCTO IN(
        MOUSE AS 'MOUSE',
        IMPRESORA AS 'IMPRESORA',
        TECLADO AS 'TECLADO',
        LAPTOP AS 'LAPTOP'
    )
)
ORDER BY SUCURSAL, MES, PRODUCTO;

--------------------------------------------------------------------------------
-- Tercer Ejercicio
--------------------------------------------------------------------------------

SELECT S.*,
       SUM(S.SALDO) OVER(PARTITION BY S.CLIENTE) TOTAL_CLIENTE,
       SUM(S.SALDO) OVER() TOTAL_GENERAL
FROM SALDO_CLIENTE S
ORDER BY CLIENTE, MES;

CREATE USER C##TC-4 IDENTIFIED BY Oracle01;
GRANT DBA TO C##TC-4;












