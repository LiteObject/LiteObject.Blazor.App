# LiteObject.Blazor.App


## Build "latest" image
- `docker build -f LiteObject.App/Dockerfile --force-rm -t liteobject/liteobject-app:latest . --label "created-by=mhoque" --no-cache`

## Push "latest" image
- `docker push liteobject/liteobject-app:latest`

## Pull "latest" image
- `docker pull liteobject/liteobject-app:latest`

## Stop the running liteobject-app container
- `docker stop liteobject-app`

## Remove container
- `docker rm liteobject-app`

## Remove image
- `docker rmi liteobject/liteobject-app:latest`

## Run latest liteobject-app
- `docker run --rm -d -p 5000:80 --name liteobject-app liteobject/liteobject-app:latest --pull=always`

## Connect to the running "liteobject-app" container
- `docker exec -it liteobject-app bash`

## Check nginx logs:
- `sudo tail -f /var/log/nginx/access.log`
