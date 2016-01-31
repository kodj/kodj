# kodj simple service
This is a very simple service leveraging the latest .NET Core technology. It includes:
* Kodj.Service: a very simple service
* Kodj.API: service endpoint

## Features
* Cross-platform (MacOS, Windows, Linux, Docker, Azure, Amazon...)
* Docker compatible
* Able to scale smoothly
* Appropriate to be a microservice
* Able to work with service discovery to discover services

## How to run on Docker
Assume you're familiar with Docker / Consul / Registrator, you can use Kitematic / Boot2Docker to run this example. I'm using Kitematic to test it.

### Running the project
```
cd ~/projects
git clone https://github.com/kodj/kodj.git kodj
cd ~/projects/kodj/src
docker-compose up
```
After running the ```docker-compose up``` we will see the following containers in the Kitematic:
![Kitematic containers](https://cloud.githubusercontent.com/assets/5198341/12700724/dae24e38-c820-11e5-9d46-85179e24e385.png)

A small description of containers:
* **src_consul1_1**: This is Consul service discovery where we store all of service information such as service name, ip address, port ...
* **src_registrator_1**: This is a listener which will update the service information to the Service Registry based on container creating / deleting. For example: when a new container is created, that container will be registered to the Service Registry and the de-registered will be run when the container is deleted.
* **src_web1_1**: the simple service running on aspnet
* **src_web2_1**: another simple service running on aspnet

### How to scale
Kodj microservices are available to scale. For example, if we want to scale the ```web1``` to 2 more instances, we can do as follow:

```docker-compose scale web1=3```

We will see in the Kitematic, there will be 2 more instances created.

## How to run on Mac / Windows / Linux
* Clone the source code to your local computer
* Go to Kodj.Api folder and run this commands to restore packages, create database and starting the web
```
git clone https://github.com/kodj/kodj.git kodj
cd kodj/src/Kodj.Service
dnu restore
cd kodj/src/Kodj.ServiceDiscovery
dnu restore
cd kodj/src/Kodj.Api
dnu restore
dnx ef database update
dnx web
```

