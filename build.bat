@echo off

set compile=%windir%\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe
::set refpath=C:\Program Files\Reference Assemblies\Microsoft\Framework\v3.0
set projname=FirstGameInWPF

::%compile% -t:winexe -out:"release\Program.exe" -r:"%refpath%\PresentationCore.dll" -r:"%refpath%\PresentationFramework.dll" -r:"%refpath%\WindowsBase.dll" src\*.cs
%compile%  "%projname%.csproj"


