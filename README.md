# kodj simple service
This is a very simple service leverage the latest .NET Core technology. It includes:
* Kodj.Service: a very simple service
* Kodj.API: service enpoint

## Features
* Cross-platform (MacOS, Windows, Linux, Docker, Azure, Amazon...)
* Docker compatible
* Be able to scale smoothly
* Appropriate to be a microservice
* Able to work with service discovery to discover services

## How to run on Docker
Assume you're familiar with Docker / Consul / Registrator, you can use Kitematic / Boot2Docker to run this example. I'm using Kitematic to test it.

```
cd ~/projects/kodj/src
docker-compose up
```

## How to run on Mac / Windows / Linux
* Clone the source code to your local computer
* Go to Kodj.Api folder and run this commands to restore packages, create database and starting the web
```
git clone https://github.com/kodj/kodj.git kodj
cd kodj/src/SimpleService/src/Kodj.Service
dnu restore
cd kodj/src/SimpleService/src/Kodj.ServiceDiscovery
dnu restore
cd kodj/Templates/SimpleService/src/Kodj.Api
dnu restore
dnx ef database update
dnx web
```

