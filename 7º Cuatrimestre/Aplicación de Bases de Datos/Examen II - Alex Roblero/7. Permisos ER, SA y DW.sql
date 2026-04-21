--------------------------------------------------------------------------------
-- Esto se ejecuta con el usuario SYS.
--------------------------------------------------------------------------------
GRANT SELECT ON SISFINANZAS_ER.CLIENTE TO SISFINANZAS_SA;
GRANT SELECT ON SISFINANZAS_ER.PRESTAMO TO SISFINANZAS_SA;
--------------------------------------------------------------------------------
GRANT SELECT, INSERT ON SISFINANZAS_SA.SA_CLIENTE TO SISFINANZAS_DW;
GRANT SELECT, INSERT ON SISFINANZAS_SA.SA_PRESTAMO TO SISFINANZAS_DW;
--------------------------------------------------------------------------------
