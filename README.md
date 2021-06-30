# example-todo-aspnet-react

This is a work in progress example.

## demo

https://demo.porridgewithprotein.xyz/

## context

- How this project is there: https://docs.microsoft.com/en-us/aspnet/core/client-side/spa/react?view=aspnetcore-5.0&tabs=visual-studio
- Create the react app the easy way https://create-react-app.dev/docs/getting-started/
- File structure https://reactjs.org/docs/faq-structure.html
- `rafc` snippet and other https://marketplace.visualstudio.com/items?itemName=dsznajder.es7-react-js-snippets
- Very good sessions to get graphql serverside / clientside right https://github.com/ChilliCream/graphql-workshop/blob/master/docs/1-creating-a-graphql-server-project.md
- Getting graphql clientside (~React) right https://www.apollographql.com/docs/react/get-started/

## dev logs graphql

```bash
# https://chillicream.com/docs/hotchocolate/get-started/
dotnet add Todo.Web package HotChocolate.AspNetCore

# https://github.com/ChilliCream/graphql-workshop/blob/master/docs/1-creating-a-graphql-server-project.md
dotnet add Todo.Web package Microsoft.EntityFrameworkCore.Sqlite

dotnet tool install dotnet-ef --global

# close dotnet watch run
dotnet add Todo.Web package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add Initial --project Todo.Web
dotnet ef database update --project Todo.Web
```

```graphql
# This is to add a TodoItem
# `AddTodoItem` does look like to just be a label (it can be anything)
mutation AddTodoItem {
  addTodoItem(input: { description: "Buy easy peeler oranges" }) {
    todoItem {
      id
    }
  }
}
# this is to get TodoItems
query GetTodoItemsDescriptions {
  todoItems {
    description
  }
}

# to test on https://localhost:5001/graphql/
```

```bash
# installing the graphql on react
npm install @apollo/client graphql

```

## dev logs setup

```bash
# initialize c# project
dotnet new sln -n Todo
dotnet new react -n Todo.Web -o Todo.Web
dotnet sln add Todo.Web

# install useful global npm packages
npm install --global create-react-app npm-check-updates typesync

# initialize correctly react project
cd Todo.Web
rm -rf ClientApp
create-react-app client-app --template typescript
mv client-app/ ClientApp/

# in package.json
# move @testing/* and @types/* and typescript to devDependencies

# upgrade to their latest version
npm-check-updates -u
npm install

# add all the type support needed
typesync
npm install

# nice thing about create-react-app is:
# https://create-react-app.dev/docs/getting-started/
# You don’t need to install or configure tools like webpack or Babel. They are preconfigured and hidden so that you can focus on the code.
# Create a project, and you’re good to go.

# How to make it work in a server?
dotnet publish -o publish

# It compiles your C#
# It "compiles" your React (down to a few js and css files)
# Running Todo.Web.exe just works and is instant, no nodejs on the server

# push other branch to current head ?
git push origin master:demo
```

## Docker build

```bash
# from the root (where Todo.sln is)
docker build -t todo-web . -f Todo.Web/Dockerfile
```
