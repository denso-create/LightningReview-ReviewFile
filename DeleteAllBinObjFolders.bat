@echo off
@echo �S�Ă�bin/obj�t�H���_���폜���܂��B
for /d /r . %%d in (bin,obj) do @if exist "%%d" rd /s/q "%%d"
@echo bin,obj�t�H���_���폜���܂����B�E�B���h�E����ĉ������B
pause > nul



