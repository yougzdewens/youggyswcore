#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY YouggySW.sln ./
COPY youggyswlib/*.csproj ./youggyswlib/
COPY YouggySW/*.csproj ./YouggySW/

RUN dotnet restore
COPY . .
WORKDIR /src/youggyswlib
RUN dotnet build -c Release -o /app

WORKDIR /src/YouggySW
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app/ .
ENTRYPOINT ["dotnet", "YouggySW.dll"]