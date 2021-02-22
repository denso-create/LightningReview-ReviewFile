@echo off
@echo Deleting bin,obj folders...
for /d /r .. %%d in (bin,obj) do @if exist "%%d" rd /s/q "%%d"
@echo Finished!! 
pause > nul



