@ECHO OFF
setlocal ENABLEEXTENSIONS
set KEY_NAME=HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\VisualStudio\12.0
set VALUE_NAME=ShellFolder

FOR /F "usebackq skip=4 tokens=1-3" %%A IN (`REG QUERY %KEY_NAME% /v %VALUE_NAME% 2^>nul`) DO (
    set ValueValue=%%C
)

if defined ValueName (
    @echo Registry Value = %ValueValue%
) else (
    @echo %KEY_NAME%\%VALUE_NAME% not found.
)
pause