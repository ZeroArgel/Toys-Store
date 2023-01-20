@ECHO
COLOR 0
CD ..
SET currentDirectory=%cd%\ToysStore.Desktop
CD %currentDirectory%
TITLE ToysStore-Api
dotnet build ToysStore.Desktop.csproj
dotnet run ToysStore.Desktop.csproj