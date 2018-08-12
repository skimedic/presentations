@pushd %~dp0

@where /q msbuild

@IF ERRORLEVEL 1 (
	echo "MSBuild is not in your PATH. Please use a developer command prompt!"
	goto :end
) ELSE (
	MSBuild.exe "ExcelExample.csproj"
)

@if ERRORLEVEL 1 goto end

@cd ..\packages\SpecRun.Runner.*\tools

@set profile=%1
@if "%profile%" == "" set profile=Default

SpecRun.exe run %profile%.srprofile "/baseFolder:%~dp0\bin\Debug" /log:specrun.log %2 %3 %4 %5

:end

@popd
