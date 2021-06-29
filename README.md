# example-todo-aspnet-react

This is a work in progress example.

## context

- https://docs.microsoft.com/en-us/aspnet/core/client-side/spa/react?view=aspnetcore-5.0&tabs=visual-studio
- https://create-react-app.dev/docs/getting-started/

## dev logs

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
