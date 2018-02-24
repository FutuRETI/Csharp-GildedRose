IF EXIST VisualStudio.coverage DEL VisualStudio.coverage
IF EXIST VisualStudio.coveragexml DEL VisualStudio.coveragexml
IF EXIST TestResults RMDIR TestResults /S /Q

SET VS_PATH=C:\Program Files (x86)\Microsoft Visual Studio\2017\Community
SET TEST_DLL=UnitTests\bin\Debug
SET SONAR_PATH=C:\Program Files\SonarQube
SET MSBUILD_PATH=%VS_PATH%\MSBuild\15.0\Bin\amd64
SET NUNIT_PATH=packages\NUnit.ConsoleRunner.3.8.0\tools
SET OPENCOVER_PATH=packages\OpenCover.4.6.519\tools

"%SONAR_PATH%\SonarQube.Scanner.MSBuild.exe" begin /k:"GildedRose-Csharp" /d:sonar.cs.nunit.reportsPaths=NUnitResults.xml /d:sonar.cs.opencover.reportsPaths=Coverage.xml
rem /d:sonar.cs.vscoveragexml.reportsPaths="%CD%\VisualStudio.coveragexml"
"%MSBUILD_PATH%\MsBuild.exe" /t:Rebuild

"%NUNIT_PATH%\nunit3-console.exe" --result=NUnitResults.xml "%TEST_DLL%\UnitTests.dll"
"%OPENCOVER_PATH%\OpenCover.Console.exe" -output:Coverage.xml -register:user -target:"%NUNIT_PATH%\nunit3-console.exe" -targetargs:"%TEST_DLL%\UnitTests.dll"

rem "%VS_PATH%\Team Tools\Dynamic Code Coverage Tools\CodeCoverage.exe" collect /output:VisualStudio.coverage "%VS_PATH%\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" "%TEST_DLL%\UnitTests.dll" "%TEST_DLL%\ApprovalUtilities.dll" "%TEST_DLL%\ApprovalUtilities.Net45.dll" "%TEST_DLL%\GildedRose.exe"  /logger:trx
rem "%VS_PATH%\Team Tools\Dynamic Code Coverage Tools\CodeCoverage.exe" analyze /output:VisualStudio.coveragexml VisualStudio.coverage
	
"%SONAR_PATH%\SonarQube.Scanner.MSBuild.exe" end