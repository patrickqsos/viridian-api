# Rest API Viridian POC

### Requisitos previos
- Tener zookeper y kafka corriendo en las direcciones por defecto

`  http://localhost:2181 (zookeeper)`

`  http://localhost:9092 (kafka)`

- Tener un topic con el nombre "viridian-test"

` bin/kafka-topics.sh --create --zookeeper localhost:2181 --replication-factor 1 --partitions 1 --topic viridian-test`

Para ejecutar el proyecto seguir los siguientes pasos:

1. Clonar el proyecto 

	`git clone https://github.com/patrickqsos/viridian-api.git`
2. Entrar a la carpeta del proyecto clonado

	` cd viridian-api`
3. Ejecutar el  proyecto

	` dotnet run`

El proyecto estara en ejecucion en la siguiente direccion:

**[http://localhost:4300/](http://localhost:4300/ "http://localhost:4300/")**

El endpoint para insertar data en el topic es el siguiente:

**[http://localhost:4300/api/kafka](http://localhost:4300/api/kafka "http://localhost:4300/api/kafka")**

Para insertar data se puede usar cualquier cliente rest o curl

`curl -d '{"Nombres":"Juan", "Telefono":"89898", "NumeroDocumento":"132678"}' -H "Content-Type: application/json" -X POST http://localhost:4300/api/kafka
`


# Librerias usadas

- Confluent.Kafka Version "0.11.5": Libreria para interactuar con kafka

- Newtonsoft.Json Version="11.0.2": Libreria para serializar/deserializar objetos JSON