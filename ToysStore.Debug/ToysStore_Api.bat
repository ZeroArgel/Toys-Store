@ECHO
COLOR 0
CD ..
SET currentDirectory=%cd%\ToysStore.Api
CD %currentDirectory%
TITLE ToysStore-Api
dotnet build ToysStore.Api.csproj
dotnet run ToysStore.Api.csproj