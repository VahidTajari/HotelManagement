dotnet tool update --global dotnet-ef --version 5.0.3
dotnet build
dotnet ef --startup-project ../BlazorServer.App/ database update --context ApplicationDbContext
pause