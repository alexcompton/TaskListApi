# TaskListApi
Simple api that manages a todo-list for various users

## Installation
This code should be self sufficient since all external dependencies are running in the cloud. If you run into issues you might need to create a virtual directory for IIS instead of using IIS express.

## Usage
1. First visit the swagger page of the cloud hosted solution [swagger page](http://tasklistapi.azurewebsites.net/swagger)
2. The page uses basis auth so either use a default user with the following credentials username: "user" and password: "password" or create your own using the register endpoint
3. Then use the other endpoints, with basic auth you should only have to enter your credentials once as long as you keep the same browser open.