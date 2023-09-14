# Projet de Gestion Scolaire

Ce projet WPF en C# avec une architecture à 3 couches est un système qui interagit avec une base de données gérée par SQL Server Management 19 pour gérer les informations sur les élèves et leurs notes.

## Architecture à 3 couches

Cette application suit une architecture à 3 couches, ce qui signifie qu'elle est divisée en trois parties distinctes :

1. **Interface Utilisateur (UI)** : Réalisée en WPF, cette couche permet aux utilisateurs d'interagir avec le programme.

2. **Couche Métier** : Cette couche contient les règles et la logique de gestion des élèves et des notes.

3. **Base de Données** : Cette couche stocke toutes les informations de manière organisée.

## Base de données SQL Server

J'utilise SQL Server Management 19 comme système de gestion de base de données. C'est comme une immense bibliothèque où l'on peut stocker toutes les informations sur les élèves et leurs notes. SQL Server aide à gérer, organiser et récupérer ces données de manière efficace.

## Gestion des élèves

À travers l'interface utilisateur, nous pouvons ajouter de nouveaux élèves en saisissant leurs détails. Ces détails sont ensuite envoyés à la couche métier, qui les traite avant de les enregistrer dans la base de données. De même, si nous voulons modifier, chercher ou supprimer un élève, l'interface utilisateur communique ces actions à la couche métier, qui les exécute en conséquence.

## Gestion des notes

Pour les notes, le processus est similaire. Nous pouvons ajouter de nouvelles notes pour un élève, les modifier ou les supprimer. Encore une fois, ces actions passent par l'interface utilisateur et sont gérées par la couche métier avant d'être enregistrées ou mises à jour dans la base de données.

## Consultation des notes par cours et Calcul de la moyenne

Si nous voulons consulter les notes des élèves pour un cours spécifique, l'interface utilisateur demande à la couche métier de récupérer ces informations à partir de la base de données. La couche métier effectue la requête appropriée et renvoie les résultats à l'interface utilisateur. En même temps, la moyenne du cours est automatiquement calculée et affichée à l'utilisateur.
