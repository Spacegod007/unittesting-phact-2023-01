@ECHO OFF

REM Locate the IDE folder (vswhere will be a better alternative http://bit.ly/2rr0CBx)

if exist "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\MSTest.exe" (
  SET VSPATH="C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\Extensions\TestPlatform"
)

if exist "C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\Common7\IDE\MSTest.exe" (
  SET VSPATH="C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\Common7\IDE\Extensions\TestPlatform"
)

if exist "C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\IDE\MSTest.exe" (
  SET VSPATH="C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\IDE\Extensions\TestPlatform"
)

CD C:\Course\Labs\Lab01\CoolCalcTests\CoolCalc.Tests\bin\Debug
%VSPATH%\vstest.console.exe CoolCalc.Tests.dll /Tests:PerformOperationTest /Logger:trx

PAUSE