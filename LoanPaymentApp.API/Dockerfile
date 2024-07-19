# Use the official ASP.NET Core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8001

# Copy the database folder to the container
COPY ./VakifBankKrediKullandirimAPI/Database/ /app/database/

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ./VakifBankKrediKullandirimAPI/VakifBankKrediKullandirimAPI.csproj ./
RUN dotnet restore "VakifBankKrediKullandirimAPI.csproj"
COPY . .
WORKDIR "/src/VakifBankKrediKullandirimAPI"
RUN dotnet build "VakifBankKrediKullandirimAPI.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "VakifBankKrediKullandirimAPI.csproj" -c Release -o /app/publish

# Use the runtime image to run the app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "LoanAPI.dll", "--urls=http://0.0.0.0:8001" ]