# TodoList Project

## Description

Basic ToDo list app.
Created using .Net Core MVC, Sql Server, Entity Framework.

## Features

- Add new ToDoItem
- Edit ToDoItem
- Delete ToDoItem
- View detailed ToDoItem
- Mark ToDoItem as completed

## Main Page

![Main Page](https://github.com/brueqlv/Assets1/blob/master/Assets1/Images/Index.png)

## Create

![Create](https://github.com/brueqlv/Assets1/blob/master/Assets1/Images/Create.png)

## Edit

![Edit](https://github.com/brueqlv/Assets1/blob/master/Assets1/Images/Edit.png)


## Details

![Details](https://github.com/brueqlv/Assets1/blob/master/Assets1/Images/Details.png)


## Delete

![Delete](https://github.com/brueqlv/Assets1/blob/master/Assets1/Images/Delete.png)

## Setup

1. **Clone the repository:**

   ```bash
   git clone https://github.com/brueqlv/ToDoListApp.git
   ```

2. **Navigate to the project directory:**

   ```bash
   cd ToDoListApp
   ```

3. **Update the connection string:**

   Update the connection string in `appsettings.json` to point to your SQL Server instance.

4. **Run the database migrations:**

   ```bash
   dotnet ef database update
   ```

5. **Build and run the project:**

   ```bash
   dotnet run
   ```

6. **Access the application:**

   To access your application go to site 'http://localhost:5014'.
