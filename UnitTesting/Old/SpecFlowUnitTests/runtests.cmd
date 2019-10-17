@pushd %~dp0

@where /q msbuild

@IF ERRORLEVEL 1 (
    echo "MSBuild is not in your PATH. Please use a developer command prompt!"
    goto :end
) ELSE (
    MSBuild.exe "SpecFlowUnitTests.csproj"
)

@if ERRORLEVEL 1 goto end

@cd ..\packages\SpecRun.Runner.*\tools\net45

@set profile=%1
@if "%profile%" == "" set profile=Default

@if exist "%~dp0\bin\Debug\%profile%.srprofile" (
    SpecRun.exe run "%profile%.srprofile" --baseFolder "%~dp0\bin\Debug" --log "specrun.log" %2 %3 %4 %5
) else (
    SpecRun.exe run --baseFolder "%~dp0\bin\Debug" --log "specrun.log" %2 %3 %4 %5
)

:end

@popd
