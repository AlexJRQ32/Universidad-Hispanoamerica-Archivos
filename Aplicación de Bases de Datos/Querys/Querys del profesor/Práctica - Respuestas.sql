SELECT *
  FROM (SELECT *
          FROM (SELECT CLIENTE,
                       NVL(ENERO,0) ENERO,
                       NVL(FEBRERO,0) FEBRERO,
                       NVL(MARZO,0) MARZO,
                       NVL(ABRIL,0) ABRIL,
                       NVL(MAYO,0) MAYO,
                       NVL(JUNIO,0) JUNIO,
                       NVL(JULIO,0) JULIO,
                       NVL(AGOSTO,0) AGOSTO,
                       NVL(SEPTIEMBRE,0) SEPTIEMBRE,
                       NVL(OCTUBRE,0) OCTUBRE,
                       NVL(NOVIEMBRE,0) NOVIEMBRE,
                       NVL(DICIEMBRE,0) DICIEMBRE
                  FROM SALDO_CLIENTE
                 PIVOT (SUM(SALDO) FOR MES IN (1 ENERO, 2 FEBRERO, 3 MARZO, 4 ABRIL, 5 MAYO,
                                               6 JUNIO, 7 JULIO, 8 AGOSTO, 9 SEPTIEMBRE,
                                               10 OCTUBRE, 11 NOVIEMBRE, 12 DICIEMBRE))
                 
               )
       );
--------------------------------------------------------------------------------

SELECT DISTINCT
       SUCURSAL,
       MES,
       PRODUCTO,
       SUM(CANTIDAD) OVER(PARTITION BY SUCURSAL, MES, PRODUCTO) CANTIDAD
  FROM ventas_sucursales
UNPIVOT (CANTIDAD FOR PRODUCTO IN (MOUSE, IMPRESORA, TECLADO, LAPTOP))
ORDER BY SUCURSAL, MES, PRODUCTO;

--------------------------------------------------------------------------------

SELECT DISTINCT
               SC.CLIENTE,
               SC.MES,
               SUM(SC.SALDO) OVER(PARTITION BY CLIENTE, MES) SALDO,
               SUM(SC.SALDO) OVER(PARTITION BY CLIENTE) TOTAL_CLIENTE,
               SUM(SC.SALDO) OVER() TOTAL_GENERAL
          FROM SALDO_CLIENTE SC
         ORDER BY CLIENTE, MES;
         
--------------------------------------------------------------------------------

SELECT A.CLIENTE,
       A.MES,
       A.SALDO,
       A.TOTAL_CLIENTE,
       A.TOTAL_GENERAL,
       ROUND(SALDO / TOTAL_GENERAL * 100, 2) PORC_TOTAL,
       TOTAL_GENERAL - SALDO DIFERENCIA
  FROM (SELECT DISTINCT
               SC.CLIENTE,
               SC.MES,
               SUM(SC.SALDO) OVER(PARTITION BY CLIENTE, MES) SALDO,
               SUM(SC.SALDO) OVER(PARTITION BY CLIENTE) TOTAL_CLIENTE,
               SUM(SC.SALDO) OVER() TOTAL_GENERAL
          FROM SALDO_CLIENTE SC
         ORDER BY CLIENTE, MES) A;
         
         
         
         
         
         
         