# ikt222
Software Security 

## Assignment 2 (Foodbyte)
To run this web application, simply build and run the Dockerfile, but make sure to fill the environment variables for the Client ID and Secret for Google OAuth 2.0.

To do this, change the "{}" placeholders to your own Client ID and Client Secret in the command bellow. After you have done this, you can run the commands from the foodbyte directory.
```shell
docker build --no-cache -t foodbyte .
docker run --rm --name foodbyte -p 127.0.0.1:8080:80 -e ASPNETCORE_ENVIRONMENT=Development -e "CLIENT_ID={}" -e "CLIENT_SECRET={}" foodbyte
```
