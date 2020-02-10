# So this is an API reference for client user:

## Login:
GET `/Account/Login` 
### Query parameters: 
```C#
string Username
string Password
```
***
POST `/Account/Login`
### Request body:
```C#
{
    string Username
    string Password
}
```
### Return type:
The method returns coockie attach it to subsecuent requests to prove user's identoty;
***


## Logout:
GET `/Account/Logout`
### Query parameters: 
none
***
POST `/Account/Logout`
### Request body:
none
### Return type:
none;
***


## Plants:
[Plants class definition](https://github.com/googleHireMe/PlantsApi/blob/master/PlantsApi/Models/DbModels/Plant.cs)

GET `/Api/Plants` 
### Query parameters: 
none
### Return type:
```C#
Plant[]
```
***
GET `/Api/Plants/${id}` 
### Query parameters: 
```C#
int id
```
### Return type:
```C#
Plant
```
***
POST `/Api/Plants/${id}` 
### Query parameters: 
```C#
int id
```
### Request body:
```C#
Plant
```
### Return type:
```C#
Plant
```
***
PUT `/Api/Plants/${id}` 
### Query parameters: 
```C#
int id
```
### Request body:
```C#
Plant
```
### Return type:
none;
***
DELETE `/Api/Plants/${id}` 
### Query parameters: 
```C#
int id
```
### Request body:
none
### Return type:
none;
***


## PlantStates:
[PlantState class definition](https://github.com/googleHireMe/PlantsApi/blob/master/PlantsApi/Models/DbModels/PlantState.cs)

GET `/Api/PlantStates` 
### Query parameters: 
none
### Return type:
```C#
PlantState[]
```
***
GET `/Api/PlantStates/${id}` 
### Query parameters: 
```C#
int id
```
### Return type:
```C#
PlantState
```
***
POST `/Api/PlantStates/${id}` 
### Query parameters: 
```C#
int id
```
### Request body:
```C#
PlantState
```
### Return type:
```C#
PlantState
```
***
PUT `/Api/PlantStates/${id}` 
### Query parameters: 
```C#
int id
```
### Request body:
```C#
PlantState
```
### Return type:
none;
***
DELETE `/Api/PlantStates/${id}` 
### Query parameters: 
```C#
int id
```
### Request body:
none
### Return type:
none;
***



## UsersPlants:
[Plant class definition](https://github.com/googleHireMe/PlantsApi/blob/master/PlantsApi/Models/DbModels/Plant.cs)

GET `/Api/UsersPlants` 
### Query parameters: 
none
### Return type:
```C#
Plant[]
```
***
GET `/Api/UsersPlants/${id}` 
### Query parameters: 
```C#
int id
```
### Return type:
```C#
Plant
```
***
POST `/Api/UsersPlants/${id}` 
### Query parameters: 
```C#
int linkedPlantId
```
### Request body:
none
### Return type:
none
***
DELETE `/Api/UsersPlants/${id}` 
### Query parameters: 
```C#
int linkedPlantId
```
### Request body:
none
### Return type:
none;
***



## Users:
[User class definition](https://github.com/googleHireMe/PlantsApi/blob/master/PlantsApi/Models/DbModels/User.cs)
GET `/Api/Users` 
### Query parameters: 
none
### Return type:
```C#
User[]
```
***
GET `/Api/Users/${id}` 
### Query parameters: 
```C#
int id
```
### Return type:
```C#
User
```
***
GET `/Api/Users/Current` 
### Query parameters: 
none
### Return type:
```C#
User
```
***




