FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /app

COPY . .

RUN dotnet restore FinniezProject.csproj

RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0

WORKDIR /app

#build stage ekedi api generate krpu publish folder eke dewal tika dan aaye copy krgnnawa me image eke wada krgnna  
COPY --from=build /publish .

#mehm damma puluwn 8080 eke run nowi apita one port ekek run krgnna 
ENV ASPNETCORE_URLS=http://+:5000

EXPOSE 5000

ENTRYPOINT ["dotnet" , "FinniezProject.dll"]
