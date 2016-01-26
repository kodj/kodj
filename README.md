# kodj simple service
This is a very simple service leverage the latest .NET Core technology. It includes:
* Kodj.Service: a very simple service
* Kodj.API: service enpoint

## Features
* Cross-platform (MacOS, Windows, Linux, Docker, Azure, Amazon...)
* Docker compatible
* Be able to scale smoothly
* Appropriate to be a microservice

## How to run on Mac / Windows / Linux
* Clone the source code to your local computer
* Go to Kodj.Api folder and run this commands to restore packages, create database and starting the web
```
git clone https://github.com/saigon-devs/kodj.git kodj
cd kodj/Templates/SimpleService/src/Kodj.Service
dnu restore
dnu build
cd kodj/Templates/SimpleService/src/Kodj.Api
dnu restore
dnu build
dnx ef database update
dnx web
```

## How to run on Docker
```
docker pull trumhemcut/kodjservice
docker run -it -p 5000:5000 trumhemcut/kodjservice
```
