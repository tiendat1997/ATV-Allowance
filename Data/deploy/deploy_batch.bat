@echo off

set /p server_instance=ENTER INSTANCE NAME ([COMPUTER_NAME]\SQLEXPRESS):
REM DATTTSE62330\SQLEXPRESS

sqlcmd -S %server_instance% -i .\1_db.sql 
echo END_OF_CREATING_DB...
sqlcmd -S %server_instance% -i .\2_seeder.sql
echo END_OF_APPLY_SEEDER...
sqlcmd -S %server_instance% -i .\3_employee_new.sql
echo END_OF_ADD_EMPLOYEES...

:END
cmd /k