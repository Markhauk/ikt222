# ikt222
Software Security 

## Assignment 2 (Foodbyte)
To run this web application, simply build and run the Dockerfile.
To do this, run the following commands from the foodbyte directory.
```shell
docker build -t foodbyte .
docker run --name foodbyte -p 127.0.0.1:8080:80 foodbyte
```