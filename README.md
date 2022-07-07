# Blazor app deployment on linux machine using github actions

## Build "latest" image
- `docker build -f LiteObject.App/Dockerfile --force-rm -t liteobject/liteobject-app:latest . --label "created-by=mhoque" --no-cache --progress plain`

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
  - `printenv` or `env` // type either one to see all environment variables
  - `env VAR1="ValueOne"` // type env with key=value to set environment variable
  - `export VAR1="ValueOne"` // to set for the current shell and all processes started from current shell
  - `set` // to get a list of all shell variables, environmental variables, local variables, and shell functions
  - `echo $VAR1` // to get the value of a variable "VAR1"

## Check nginx logs:
- `sudo tail -f /var/log/nginx/access.log`
---
## ToDo:
- 
