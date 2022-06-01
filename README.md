# Auto-Generated Data Transfer Object Model
## Introduction
- Help quickly create entity dto files with same CRUD actions

## Prerequisites
- .NET 5

## 1. Pack
- Go to folder level of GenerateDto.csproj file
- This command will create nupkg store in nupkg folder
```
dotnet pack
```
## 2. Install program as dotnet tool
- Go to repository level and install with following command
```
dotnet tool install --add-source nupkg GenerateDto --version <version-define-in-csproj> -g
```
## 3. Usage
- After install success, use this command with entity and namespace name
- With entity name, if you have multiple entities, separate it using ","
- This command with create dto files, with pre-defined code template as simple C# class with given namespace
```
generate-dto entity=<entity-names> namespace=<namespace-name>
```
## 4. Uninstall
- If this tool is useless, you can uninstall it
```
dotnet tool uninstall generatedto -g
```
