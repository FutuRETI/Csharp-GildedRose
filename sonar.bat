IF EXIST VisualStudio.coverage DEL VisualStudio.coverage
IF EXIST VisualStudio.coveragexml DEL VisualStudio.coveragexml
IF EXIST TestResults RMDIR TestResults /S /Q

SET VS_PATH=C:\Program Files (x86)\Microsoft Visual Studio 12.0
SET TEST_DLL=UnitTests\bin\Debug

"%VS_PATH%\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" "%TEST_DLL%\UnitTests.dll" "%TEST_DLL%\ApprovalUtilities.dll" "%TEST_DLL%\ApprovalUtilities.Net45.dll" "%TEST_DLL%\GildedRose.exe" /logger:trx
"%VS_PATH%\Team Tools\Dynamic Code Coverage Tools\CodeCoverage.exe" collect /output:VisualStudio.coverage "%VS_PATH%\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" "%TEST_DLL%\UnitTests.dll" "%TEST_DLL%\ApprovalUtilities.dll" "%TEST_DLL%\ApprovalUtilities.Net45.dll" "%TEST_DLL%\GildedRose.exe"
"%VS_PATH%\Team Tools\Dynamic Code Coverage Tools\CodeCoverage.exe" analyze /output:VisualStudio.coveragexml VisualStudio.coverage
sonar-runner.bat
