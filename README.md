# Llamanager

## Run in Docker

Start the RavenDb container
```bash
docker run -p 8080:8080 -p 38888:38888 -v Data:/var/lib/ravendb/data --name llama-ravendb -e RAVEN_Setup_Mode=None -e RAVEN_License_Eula_Accepted=true -e RAVEN_Security_UnsecuredAccessAllowed=PrivateNetwork ravendb/ravendb
```
Storage is mounted to a local `Data` directory. Initially, you will need to create a database named `Llamanager` in the RavenDB UI at `http://localhost:8080`. You can use a different name if you change the name in the appsettings as well.

Start the Ollama container
```bash
docker run -p 11434:11434 --name llama-ollama ollama/ollama
```
No changes are persisted outside of the container. You can restart the stopped container and it will resume with the modified configuration and pulled models.

```bash
docker start llama-ollama llama-ravendb
```

Pull your desired model
```bash
curl http://localhost:11434/api/pull -d '{
  "model": "llama3.2"
}'
```

If you change the port number and/or the language model, you'll need to update the appsettings as well.