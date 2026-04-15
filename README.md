# 4J4-collaboration — BookLibrary API

Repo d'entraînement pour le cours **420-4J4-SO**. On y pratique le flot de collaboration sur GitHub: **branches, Pull Requests, revue de code, merge**. Le projet est **volontairement simple** (une seule entité, stockage en mémoire, aucune dépendance externe) pour garder toute l'attention sur les mécaniques Git/GitHub.

## Stack

- .NET 8 — ASP.NET Core Web API
- xUnit + FluentAssertions pour les tests
- Swagger pour explorer l'API à la main
- Stockage **en mémoire** — aucune base de données, aucun Docker

## Démarrage rapide

```bash
dotnet restore
dotnet build
dotnet test
dotnet run --project src/Api
```

Puis ouvrir http://localhost:5050/swagger.

## Structure

```
src/
├── Api/       — Contrôleurs, Program.cs, Swagger
└── Core/      — Entités, DTOs, services, interfaces, repository en mémoire
tests/
└── Core.Tests/  — Tests xUnit
```

## Exercices

Le backlog d'exercices est dans [`.github/backlog/`](./.github/backlog/). Lancer le workflow **Seed Practice Issues** (onglet Actions → Run workflow) pour créer automatiquement les issues correspondantes dans ce repo.

### Flot attendu pour chaque exercice

1. S'assigner une issue (`/assign @me` ou via l'UI)
2. Créer une branche depuis `main`: `git checkout -b feat/<court-descriptif>`
3. Coder, commiter, pousser
4. Ouvrir une Pull Request vers `main`; remplir le template
5. Demander la revue à un coéquipier
6. Répondre aux commentaires, pousser les corrections
7. Une fois la CI verte et la PR approuvée → **Squash and merge**
8. Supprimer la branche

### Bonnes pratiques de PR

- **Petites PR** — une fonctionnalité = une PR
- **Commits atomiques** — un changement logique par commit
- **Messages clairs** — verbe à l'impératif au début (`Add book search endpoint`)
- **Tests** — toute nouvelle route ou logique doit avoir au moins un test
- **Description** — expliquer le *pourquoi*, pas juste le *quoi*; la review en dépend

## CI

Chaque PR déclenche `.github/workflows/ci.yml`: `dotnet build` + `dotnet test`. Une PR rouge n'est pas mergeable.
