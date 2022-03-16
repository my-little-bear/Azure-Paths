FROM mcr.microsoft.com/dotnet/aspnet:6.0

RUN mkdir /app
WORKDIR /app

COPY ./webapp/bin/Release/netcoreapp6.0/publish ./
COPY ./config.sh ./

RUN bash config.sh

EXPOSE 80
ENTRYPOINT ["dotnet", "webapp.dll"]