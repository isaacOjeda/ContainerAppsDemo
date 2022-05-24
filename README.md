# Cheat Sheet

### Build
```bash
docker build --tag containerappsdemo -f ".\ContainerAppsDemo\Dockerfile"  .
```
### Run
```bash
docker run -d  -p 50100:80 --name containerappsdemo01 containerappsdemo
```
### Login to registry
```bash
docker login balusoft.azurecr.io
```
### Tag
```bash
docker tag containerappsdemo:latest balusoft.azurecr.io/containerappsdemo:latest
```
### Push
```bash
docker image push balusoft.azurecr.io/containerappsdemo:latest
```

## GitHub Action
```yaml
name: Docker Image CI

on:
  push:
    branches: [master]
  pull_request:
    branches: [master]

jobs:
  build:
    runs-on: ubuntu-latest

    steps:
      - name: "Checkout"
        uses: actions/checkout@v3

      - name: "Build the Docker image"
        run: docker build --tag containerappsdemo:latest -f "./ContainerAppsDemo/ContainerAppsDemo/Dockerfile"  "./ContainerAppsDemo"

      - name: "Login Azure Container Registry"
        uses: docker/login-action@v2.0.0
        with:
          registry: balusoft.azurecr.io
          username: ${{ secrets.REGISTRY_USERNAME }}
          password: ${{ secrets.REGISTRY_PASSWORD }}

      - name: "Tag docker image"
        run: docker tag containerappsdemo:latest balusoft.azurecr.io/containerappsdemo:latest

      - name: "Push docker image"
        run: docker image push balusoft.azurecr.io/containerappsdemo:latest

```