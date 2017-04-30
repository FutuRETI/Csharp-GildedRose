IF EXIST VisualStudio.coverage DEL VisualStudio.coverage
IF EXIST VisualStudio.coveragexml DEL VisualStudio.coveragexml
IF EXIST TestResults RMDIR TestResults /S /Q

SET NET_PATH=C:\Program Files (x86)\MSBuild\14.0\Bin
SET VS_PATH=C:\Program Files (x86)\Microsoft Visual Studio 14.0
SET NUNIT_PATH="%CD%\packages\NUnit.ConsoleRunner.3.6.1\tools"
SET COVER_PATH="%CD%\packages\OpenCover.4.6.519\tools"
SET TEST_DLL=UnitTests\bin\Debug\UnitTests.dll
SET SONAR_PATH=C:\SonarQube

"%SONAR_PATH%\MSBuild.SonarQube.Runner.exe" begin /key:"it.reti.futureti" /name:"Gilded Rose Kata for CSharp" /version:"1.0" /d:sonar.language="cs" /d:sonar.sources="." /d:sonar.cs.nunit.reportsPaths="%CD%\TestResult.xml" /d:sonar.cs.opencover.reportsPaths="%CD%\TestCoverage.xml"

"%NET_PATH%\MSBuild.exe" /t:Rebuild
"%COVER_PATH%\OpenCover.Console.exe" -target:"%NUNIT_PATH%\nunit3-console.exe" -targetargs:"%TEST_DLL% --result=TestResult.xml;format=nunit2" -output:"TestCoverage.xml" -register:user

"%SONAR_PATH%\MSBuild.SonarQube.Runner.exe" end
