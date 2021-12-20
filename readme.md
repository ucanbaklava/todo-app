# To-Do App
[Yet another To-Do application.](http://70.34.215.182:5000/swagger/index.html)
## Tech Stack

* .Net Core
* Postgresql
* Docker

## CI-CD

![CI](https://github.com/ucanbaklava/todo-app/actions/workflows/publish.yml/badge.svg?raw=true)

<hr>

Github Actions configuration is triggered when changes pushed to ```main``` branch. There are 3 Github secrets for this pipeline to deploy successfully to a remote server.

- HOST
    * Host server IP address.
- USER
    * Server user name.
- PASSWORD
    * Server password.

Docker and Docker Compose should be installed on the server before the pipeline works.    

## Running the application
This app can be run as a docker container. Open a terminal in the directory which holds the ```docker-compose.yml``` file and run the following command.

```
docker-compose -f docker-compose.yml up -d --build
```
<hr>

## API Endpoints

For OpenAPI(swagger) support visit  ```localhost:5000/swagger```

### Get All Tasks

- URL
```
/api/todo
```
- METHOD
```
GET
```
- SUCCESS RESPONSE
    * Code: 200
    * Content =>  
    ```json
    [{"id": 1, "task": "Do dishes", "completed": false,  "createdAt": "2021-12-18T..."}] 
    ```


<hr>

### Get Task By Id

- URL
```
/api/todo/{id}
```
- METHOD
```
GET
```
- SUCCESS RESPONSE
    * Code: 200
    * Content 
    ```json
    {"id": 1, "task": "Do dishes", "completed": false} 
    ```


- ERROR RESPONSE
    * Code: 404 NOT FOUND
    * Content =>
    ```json
     {"StatusCode": 404, "Message": "No task found with the given id. (Parameter toDoItem')" 
     ```


<hr>

### Create Task

- URL
```
/api/todo
```
- METHOD
```
POST
```
- REQUEST BODY

```json
{
  "id": 1,
  "createdAt": "2021-12-20T09:21:18.573Z",
  "taskContent": "Do the dishes",
  "isCompleted": true
}
```

