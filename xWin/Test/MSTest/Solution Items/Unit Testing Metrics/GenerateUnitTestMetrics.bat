if exist "%~dp0xWinTestRes.trx" (
	del "%~dp0xWinTestRes.trx"
)

if exist "%~dp0..\GeneratedReports\xWinCoverageReport.xml" (
	del "%~dp0..\GeneratedReports\xWinCoverageReport.xml"
)

"%~dp0..\..\..\..\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" ^
-register:user ^
-target:"%VS140COMNTOOLS%..\IDE\mstest.exe" ^
-targetargs:"/testcontainer:\"%~dp0..\..\bin\Debug\MSTest.dll\" /resultsfile:\"%~dp0xWinTestRes.trx\"" ^
-filter:"+[xWin*]* -[xWin.Wrapper.*]* -[xWin.Forms.*]*" ^
-mergebyhash ^
-skipautoprops ^
-output:"%~dp0..\GeneratedReports\xWinCoverageReport.xml"

"%~dp0..\..\..\..\packages\ReportGenerator.2.5.6\tools\ReportGenerator.exe" ^
-reports:"%~dp0..\GeneratedReports\xWinCoverageReport.xml" ^
-targetdir:"%~dp0..\GeneratedReports\HRCoverageReport"