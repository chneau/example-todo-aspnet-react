FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS deps
RUN apk add --no-cache npm
WORKDIR /src/

# restore c# deps
COPY */*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done
RUN dotnet restore Todo.Web/Todo.Web.csproj

# restore node deps
COPY Todo.Web/ClientApp/package*.json ./Todo.Web/ClientApp/
RUN npm --prefix ./Todo.Web/ClientApp ci ./Todo.Web/ClientApp

FROM deps AS publish
COPY . .
RUN dotnet publish Todo.Web/Todo.Web.csproj -c Release --no-restore -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS final
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Todo.Web.dll"]
