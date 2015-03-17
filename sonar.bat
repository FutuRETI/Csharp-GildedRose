IF EXIST VisualStudio.coverage DEL VisualStudio.coverage
IF EXIST VisualStudio.coveragexml DEL VisualStudio.coveragexml
IF EXIST TestResults RMDIR TestResults /S /Q

SET VS_PATH=C:\Program Files (x86)\Microsoft Visual Studio 12.0
SET TEST_DLL=GildedRose_Tests\bin\Debug\GildedRose_Tests.dll

"%VS_PATH%\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" "%TEST_DLL%" /logger:trx
"%VS_PATH%\Team Tools\Dynamic Code Coverage Tools\CodeCoverage.exe" collect /output:VisualStudio.coverage "%VS_PATH%\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" "%TEST_DLL%"
"%VS_PATH%\Team Tools\Dynamic Code Coverage Tools\CodeCoverage.exe" analyze /output:VisualStudio.coveragexml VisualStudio.coverage
REM sonar-runner.bat
