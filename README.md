# 🎟️ BachelorParis2024 

Application web de billetterie développée en ASP.NET Core 8.0, permettant de consulter les épreuves, acheter des billets et gerer les offres depuis une interface administrateur.
Projet complet incluant CRUD, authentification, base SQL et architecture MVC.
Conception et développement réalisés dans le cadre d'un examen.

## 🚀 Fonctionnalités
- Consultation des épreuves (MOQ)
- Gestion des offres (CRUD complet)
- Réservation d'évennements
- Gestion du panier (ajout et suppression)
- Simulation du paiement
- Edition des billets avec QR Code (securisation HMAC)
- Authentification et rôles (admin / utilisateur)
- Base de données SQL (EF Core)
- Architecture MVC propre et structurée
- Interface Razor simple et fonctionnelle

## 🛠️ Stack
- **Backend :** ASP.NET Core 8 (MVC)
- **ORM :** Entity Framework Core
- **Base de données :** SQL Server / SQLite - Code first
- **Frontend :** Razor, HTML, CSS, Javascript
- **Authentification et rôles:** Identity
- **Génération de QRCodes:** QRCoder
- **Déploiement :** Render

## 📦 Installation
```bash
git clone https://github.com/cvitali/BachelorParis2024.git
cd BachelorParis2024
dotnet restore
dotnet run
```

## Variables d'environnement
appsetting.json
```JSON
"ConnectionStrings": {
  "DefaultConnection": "..."
},
"AdminUser": {
  "Email": "...",
  "Password": "...",
  "FirstName": "...",
  "LastName": "..."
},
"QrCode": {
  "SecretKey": "..."
}
```

## 🗄️ Migrations EF Core
Créer la base de données
```bash
dotnet ef database update
```
Ajouter une migration
```bash
dotnet ef migrations add NomDeMigration 
  --context DbProjectContext 
  --project BachelorParis2024.Repository/BachelorParis2024.Repository.csproj 
  --startup-project BachelorParis2024/BachelorParis2024.csproj
```
Mettre à jour la base de données
```bash
--context DbProjectContext
--project BachelorParis2024.Repository/BachelorParis2024.Repository.csproj
--startup-project BachelorParis2024/BachelorParis2024.csproj
```

## 📁 Structure de la solution
```code
/BachelorParis2024
|-BachelorParis2024 //couche applicative
  |-wwwroot
  |-Areas
    |-Identity
  |-Controllers
  |-DataTransferObject
  |-Model ->ErrorViewModel
  |-Services
    |-Payment
    |-QRCode
  |-Views
|-BachelorParis2024.Domain //couche métier
  |-Identity -> BachelorParis2024User //ajout de champs personalisés
  |-Interfaces
  |-Models
|-BachelorParis2024.Mocks
|-BachelorParis2024.Repository //couche d'accès aux donnée
  |-Context
  |-Migrations
|-BachelorParis2024.Tests
```
## ⚠️ Limites actuelles
Ce projet a été réalisé dans le cadre d’un examen, avec un temps limité.
Il contient donc quelques bugs connus et fonctionnalités incomplètes.
Limite liée à l’hébergement gratuit : 
La base de données utilisée pour la billetterie est hébergée sur Render (free tier). Ce plan impose une réinitialisation mensuelle, pouvant entraîner une indisponibilité temporaire. Le fonctionnement normal est rétabli dès que la base est réinitialisée.

## 🔧 Améliorations prévues
- Finaliser la partie **analyse des ventes**.
- Supprimer l’icône panier sur la page **checkout** (bug si on clique dessus).
- Ajouter et finaliser les **tests unitaires**.
- Déplacer les appels au **DbContext** de la couche applicative vers la couche Repository.
- Ajouter un message concernant les **données collectées** pour respecter le RGPD.
- Remplacer les messages d’alerte par des **fenêtres stylisées**.
- Permettre **l’impression et/ou l’enregistrement** des billets.
- Ajouter une **recherche d’événements par sport**.
- Vérifier et afficher le **nombre de places restantes**.

## 🔗 Liens
- Site: https://ma-billetterie.onrender.com
- Repo: https://github.com/cvitali/BachelorParis2024



