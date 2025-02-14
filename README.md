# Llamanager

## Run in Docker

Start the Ollama container
```bash
docker run -p 11434:11434 ollama/ollama
```

Pull your desired model
```bash
curl http://localhost:11434/api/pull -d '{
  "model": "llama3.2"
}'
```

If you change the port number and/or the language model, you'll need to update the appsettings as well.