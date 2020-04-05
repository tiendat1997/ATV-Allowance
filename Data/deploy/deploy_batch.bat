@echo off

set /p server_instance=ENTER INSTANCE NAME ([COMPUTER_NAME]\SQLEXPRESS):
REM DATTTSE62330\SQLEXPRESS

REM sqlcmd -S %server_instance% -i .\1_db.sql 
REM echo END_OF_CREATING_DB...
REM sqlcmd -S %server_instance% -i .\2_seeder.sql
REM echo END_OF_APPLY_SEEDER...
REM sqlcmd -S %server_instance% -i .\3_employee_new.sql
REM echo END_OF_ADD_EMPLOYEES...
REM sqlcmd -S %server_instance% -i .\atv_update_release_27_03_2020.sql
REM echo END_OF_UPDATE_ORGANIZATION...

sqlcmd -S %server_instance% -i .\pttt-criteria-value-data.sql
echo END_OF_UPDATE_CRITERIA_VALUE_OF_PTTT
:END
cmd /k