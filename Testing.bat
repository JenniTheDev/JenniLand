set resultsDir="C:\temp\results.xml"
IF EXIST %resultsDir% del %resultsDir%
"C:\Program Files\Unity\Hub\Editor\2021.3.3f1\Editor\Unity.exe" -runTests -batchmode -projectPath "F:\TestLand" -testResults %resultsDir% -testPlatform PlayMode
C:\Users\jenni\AppData\Local\Unity\Editor\Editor.log
pause