# Prérequis
* Installer Visual Studio Code    
* Installer Dotnet Core SDK & Runtime : https://www.microsoft.com/net/download/core    

# Préparatifs
`mkdir Isen.DotNet`     
`cd Isen.DotNet`     
`git init`     
`touch .gitignore`     
`touch readme.md`     
`code .`     

# Création de l'espace de travail
## Création d'un projet console
Depuis le dossier Isen.DotNet :  
`mkdir Isen.DotNet.ConsoleApp`  
`cd Isen.DotNet.ConsoleApp`  
`dotnet new console`  
`dotnet run`  

## Commit Git
Depuis la racine du projet :  
Etat des fichiers (non trackés) : `git status`  
Tracker les fichiers : `git add .`  
Ils sont maintenant suivis : `git status`  
Commit : `git commit -m "Initial commit"`  
Prendre en compte les modifs (**mais pas les ajouts de fichiers**) au moment du commit (donc faire un add et un commit en même temps :  
`git commit -a -m "updated readme"`  

## Création d'un projet librairie
Depuis le dossier Isen.DotNet :  
`mkdir Isen.DotNet.Library`  
`cd Isen.DotNet.Library`  
`dotnet new classlib`  

## Ajout de la librairie en référence du projet console
Depuis le dossier du projet Console :  
`dotnet add reference ..\Isen.DotNet.Library\Isen.DotNet.Library.csproj`  
Coder la classe Hello.  
Dans le Program.cs, ajouter le using, et appeler la classe Hello.  

## Création d'une solution et ajout des projets
Depuis le dossier racine  
Créer le fichier solution : `dotnet new sln`  
Ajouter le projet librairie :
`dotnet sln add Isen.DotNet.Library\Isen.DotNet.Library.csproj`  
Ajouter le projet console :  
`dotnet sln add Isen.DotNet.ConsoleApp\Isen.DotNet.ConsoleApp.csproj`  
Commit git :   
`git add .`  
`git commit -m "Console, lib, solution"`  

## Ajout d'un projet de test
*TDD = Test Driven Development*  
Depuis le dossier racine :  
`mkdir Isen.DotNet.Tests && cd Isen.DotNet.Tests`  
Créer le projet de tests
`dotnet new xunit`  
Ajouter ce projet à la solution (depuis le dossier racine)
`dotnet sln add Isen.DotNet.Tests\Isen.DotNet.Tests.csproj`  
Depuis le dossier du projet de tests :  
 `dotnet add reference ..\Isen.DotNet.Library\Isen.DotNet.Library.csproj`  
 Commit git (penser à se remettre dans le dossier racine)  
`git add .`  
`git commit -m "Test project"`  

## Push du projet sur un repo remote
Créer un projet sur le serveur Git de votre choix (GitHub, GitLab, interne ISEN...)  
L'url de mon repo est https://github.com/BastienRo/monProjetC-.git  
`git remote add origin https://github.com/BastienRo/monProjetC-.git`  
Push, en indiquant que master correspond à origin/master  
`git push -u origin master`  

## Ajout d'un tag Git
Créer le tag dans le repo local  
`git tag v0.1`  
Pusher le tag dans le remote repo  
`git push origin v0.1`  

# Ajout d'un modèle
## Types Person et City
Dans le projet Library :  
* Créer un dossier Models/Implementation
* Créer un classe `Person` :
  * `Id` (int)
  * `Name` (string)
  * `FirstName` (string)
  * `LastName` (string)
  * `BirthDate` (DateTime)
* Créer une classe `City` : 
  * `Id` (int)
  * `Name` (string)

## Refactoring : extraction d'un BaseModel
Les classes Person et City ont une partie de leur logique commune.  
Extraire ce qui est commun dans une classe abtraite `BaseModel`.  
La classe de base sera dans le dossier Models/Base.  

# Ajout de Repositories
## CityRepository
A la racine du projet Library, créer un dossier `Repositories/InMemory`  
Ajouter une classe `InMemoryCityRepository`  
Extraire l'interface de ce repo dans `Repositories/Interfaces/IInMemoryCityRepository.cs`  

## Refactoring interface : extraire IBaseRepository
Déplacer les 3 méthodes de l'interface vers IBaseRepository  

## Refactoring Repository
* Créer la classe abstraite Repositories/Base/_BaseRepository.cs  
* Déplacer la logique de CityReposiory vers cette classe  
