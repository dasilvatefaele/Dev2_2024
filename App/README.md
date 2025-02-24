## Dockerfile: Spiegazione Passo Passo

> Esempio
```dockerfile
# Fase di build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o /publish

# Fase di runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "MyWebApp.dll"]

```

### **Fase 1: Build dell'Applicazione**
Questa fase serve per compilare l'applicazione .NET 8 all'interno di un container.

```dockerfile
# Usa l'SDK di .NET 8 per compilare l'app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
```
- Usa l'immagine ufficiale di [.NET SDK 8.0](w), che include gli strumenti necessari per compilare e pubblicare l'applicazione.
- L'alias `AS build` viene usato per identificare questa fase nella build multistage.

```dockerfile
WORKDIR /app
```
- Imposta la directory di lavoro dentro il container su `/app`.

```dockerfile
# Copia i file del progetto e ripristina i pacchetti
COPY *.csproj ./
RUN dotnet restore
```
- Copia solo il file `.csproj` (file di progetto) all'interno del container.
- Esegue `dotnet restore`, che scarica tutte le dipendenze necessarie definite nel file `.csproj`.

```dockerfile
# Copia tutti i file dell'app e compila in modalità Release
COPY . ./
RUN dotnet publish -c Release -o /publish
```
- Copia tutti i file del progetto nella cartella `/app` del container.
- Esegue `dotnet publish -c Release -o /publish`, che:
  - Compila l'applicazione in modalità `Release` (ottimizzata per la produzione).
  - Salva l'output della build nella cartella `/publish`.

---

### **Fase 2: Runtime dell'Applicazione**
Questa fase serve per creare un container più leggero per eseguire l'applicazione.

```dockerfile
# Usa l'immagine runtime di .NET 8 per eseguire l'app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
```
- Usa l'immagine ufficiale di [.NET Runtime 8.0](w), che contiene solo il necessario per eseguire applicazioni ASP.NET Core, ma non per compilarle.
- Questo riduce le dimensioni finali dell'immagine.

```dockerfile
WORKDIR /app
```
- Imposta la directory di lavoro all'interno del container.

```dockerfile
# Copia l'output della build nell'ambiente runtime
COPY --from=build /publish .
```
- Copia i file compilati dalla fase `build` nella directory di lavoro del container (`/app`).
- Il comando `--from=build` prende l'output dalla fase precedente.

```dockerfile
# Espone la porta 8080 (puoi cambiarla se necessario)
EXPOSE 8080
```
- Indica che l'applicazione ascolterà sulla porta `8080`. Questo non mappa automaticamente la porta, ma documenta che il container utilizza questa porta. (senza Mapping: far corrispondere a una porta software una porta hardware) (con Mapping: 8080:80)

in questo caso
```dockerfile
# Comando per avviare l'app
ENTRYPOINT ["dotnet", "DotNetDocker.dll"]
```
- Definisce il comando che verrà eseguito quando il container parte.
- Avvia l'applicazione eseguendo `dotnet MyWebApp.dll`.

---

### **Perché usare una Build Multistage?**
Usare due fasi (`build` e `runtime`) ha diversi vantaggi:
1. **Immagine più leggera** → Il runtime di .NET 8 è molto più piccolo rispetto all'SDK.
2. **Migliore sicurezza** → Evita di includere strumenti di sviluppo inutili nel container finale.
3. **Migliore gestione della cache** → Copiare prima il `.csproj` e fare `dotnet restore` permette di sfruttare la cache di Docker ed evitare di scaricare le dipendenze ogni volta.

---

## Formato del Dockerfile

Il `Dockerfile` è un file di testo scritto in un formato dichiarativo specifico per Docker. Segue una sintassi basata su istruzioni chiave, che vengono eseguite in ordine sequenziale per costruire un'immagine.

### **Struttura del Dockerfile**

#### **1. Definizione dell'immagine di base**
```dockerfile
FROM <immagine>:<tag>
```
- Specifica l'immagine di partenza da cui derivare l'ambiente del container.
- Esempio:
  ```dockerfile
  FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
  ```

#### **2. Impostazione della directory di lavoro**
```dockerfile
WORKDIR /percorso
```
- Cambia la directory all'interno del container in cui verranno eseguiti i comandi successivi.

#### **3. Copia dei file**
```dockerfile
COPY <source> <destination>
```
- Copia file o directory dal sistema host al filesystem del container.

#### **4. Esecuzione di comandi**
```dockerfile
RUN <comando>
```
- Esegue comandi durante la **build** dell'immagine.

#### **5. Esposizione delle porte**
```dockerfile
EXPOSE <porta>
```
- Indica su quale porta il container ascolterà le richieste.

#### **6. Definizione del comando di avvio**
```dockerfile
ENTRYPOINT ["eseguibile", "arg1", "arg2"]
```
- Specifica il processo principale che il container eseguirà.

---

## **Che estensione ha il Dockerfile?**

Il `Dockerfile` **non ha un'estensione**. Deve essere chiamato semplicemente:

```
Dockerfile
```

senza alcuna estensione come `.txt` o `.docker`.

---

## **Per cosa sta `-o` in `dotnet publish -o out`?**

L'opzione **`-o`** in `dotnet publish -o out` sta per **`--output`** ed è usata per specificare la cartella di destinazione in cui verranno pubblicati i file compilati dell'applicazione.

### **Spiegazione del comando:**
```bash
dotnet publish -o out
```
È equivalente a:
```bash
dotnet publish --output out
```
Significa che i file pubblicati (compilati e pronti per l'esecuzione) verranno salvati nella cartella **`out/`** all'interno della directory corrente.

### **Esempio in un Dockerfile**
```dockerfile
RUN dotnet publish -c Release -o /publish
```
- `-c Release` → Compila l'app in modalità **Release** (invece di Debug).
- `-o /publish` → Salva i file pubblicati nella cartella `/publish` dentro il container.

### **Perché usare `dotnet publish` con `-o` in Docker?**
- **Ottimizza lo spazio**: pubblica solo i file necessari per l'esecuzione, senza file di sviluppo.
- **Migliora le performance**: il codice è precompilato e ottimizzato per il runtime.
- **Facilita la distribuzione**: puoi copiare solo i file pubblicati nel container finale.

---

# Creazione dell'immagine


> NOTA: il `.` indica la dir corrente come contesto di `build`

```powershell
docker build -t <NomeApp> .
```

ESEGUO IL CONTAINER

```powershell
docker run docker 
```

memo per accessi a gruppo docker: 

```powershell
lusrmgr.msc
```