REM set PATH=%PATH%;C:\Windows\Microsoft.NET\Framework64\v4.0.30319\
REM echo %path%
REM runtests.cmd %1

@pushd %~dp0


@cd ..\..\packages\SpecRun.Runner.3.*\tools\net45

@set profile=%1
@if "%profile%" == "" set profile=Default

SpecRun.exe run "%profile%.srprofile" --baseFolder "%~dp0\bin\Debug" --log "specrun.log" %2 %3 %4 %5

:end

@popd
exit 0