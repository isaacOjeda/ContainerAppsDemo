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