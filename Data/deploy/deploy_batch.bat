@echo off

set /p server_instance=ENTER INSTANCE NAME ([COMPUTER_NAME]\SQLEXPRESS):
REM DATTTSE62330\SQLEXPRESS

REM sqlcmd -S %server_instance% -i .\1_db.sql 
REM echo END_OF_CREATING_DB...
REM sqlcmd -S %server_instance% -i .\2_seeder.sql
REM echo END_OF_APPLY_SEEDER...
REM sqlcmd -S %server_instance% -i .\3_employee_new.sql
REM echo END_OF_ADD_EMPLOYEES...
sqlcmd -S %server_instance% -i .\atv_update_release_27_03_2020.sql
echo END_OF_UPDATE_ORGANIZATION...

:END
cmd /k