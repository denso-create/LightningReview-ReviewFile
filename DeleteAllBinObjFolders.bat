@echo off
@echo 全てのbin/objフォルダを削除します。
for /d /r . %%d in (bin,obj) do @if exist "%%d" rd /s/q "%%d"
@echo bin,objフォルダを削除しました。ウィンドウを閉じて下さい。
pause > nul



