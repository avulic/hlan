FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /publish
COPY /publish /publish
CMD ASPNETCORE_URLS=http://*:$PORT dotnet HLAN.dll