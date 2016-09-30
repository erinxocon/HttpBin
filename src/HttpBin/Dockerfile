FROM microsoft/dotnet:1.0.0-core
WORKDIR /app
ENV ASPNETCORE_URLS http://*:8000
EXPOSE 8000
ENTRYPOINT ["dotnet", "HttpBin.dll"]
COPY . /app
