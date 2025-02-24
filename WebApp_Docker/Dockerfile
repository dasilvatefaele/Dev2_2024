# BUILD ---------------------------------------------------

# Usa l'SDK di .NET 8 per compilare l'app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Directory all'interno dell'immagine Docker che verrà creata
WORKDIR /app

# Copia e ripristino delle dipendenze 
COPY *.csproj ./
RUN dotnet restore

# RUNTIME -------------------------------------------------

# Copia i file da una Directory locale al Container 
COPY . ./

# RUN esegue un comando all interno del Container
# dotnet publish: serve a compilare e pubblicarla in una Directory di Output
# -c Release : ottimizzazione del codiceper la produzione
# -o /out: indica la destinazione dentro il Container 
# --no-restore : serve a non ripristinare le dipendenze ogni volta
RUN dotnet publish -c Release -o out --no-restore

# Usa l'immagine runtime di .NET 8 in modo da avere un'immagine più leggera
# AS runtime (di default: da provare velocità-dimensione)
FROM mcr.microsoft.com/dotnet/sdk:8.0 

# Imposta la cartella di lavoro ALL'INTERNO dell'immagine Docker 
WORKDIR /app

# Copia il file pubblicato dall'immagine di build al container
COPY --from=build /app/out ./

# espongo la porta 8080:80
EXPOSE 8080:80

# DotNet.Docker.dll è il file che verrà eseguito all'avvio del container
ENTRYPOINT ["dotnet", "WebApp_Docker.dll"]

# Attributi aggiuntivi:
# --no-restore : non ricarica le dipendenze ogni volta
# -c : indica che viene fatta la build in modalità release/produzione (?)
# -o : sta per --output, indica la destinazione del percorso in Docker


