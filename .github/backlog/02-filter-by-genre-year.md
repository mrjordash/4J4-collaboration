# [Pratique 2] Filtrer les livres par genre et/ou année
<!-- labels: practice, feature -->

## Objectif d'apprentissage

Modifier un endpoint existant sans casser les clients actuels. Exercice de revue de code: deux collègues ont des avis différents sur le format des paramètres — négociez en review.

## Ce qu'il faut livrer

Étendre `GET /api/v1/books` pour accepter deux paramètres optionnels:

- `genre` (ex: `?genre=Programming`)
- `year` (ex: `?year=2018`)

Les deux peuvent être combinés.

## Critères d'acceptation

- [ ] `GET /api/v1/books` sans paramètre continue à retourner tous les livres (pas de régression)
- [ ] `genre` filtre de façon insensible à la casse
- [ ] `year` doit être un entier valide — sinon `400`
- [ ] Les filtres sont combinables (intersection)
- [ ] Tests unitaires ajoutés pour chaque cas (genre seul, year seul, combiné, sans filtre)
- [ ] PR ouverte avec le template rempli et relue par un coéquipier

## Flux Git attendu

- Branche dédiée (ex: `feat/filter-books`)
- Commits atomiques et bien nommés
- PR avec description du changement et exemples de requêtes
