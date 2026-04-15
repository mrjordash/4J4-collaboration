# [Pratique 5] Remplacer le DELETE par un "soft delete"
<!-- labels: practice, feature -->

## Objectif d'apprentissage

Modifier un comportement existant **sans casser les endpoints publics**. Comprendre l'impact transversal d'un changement et le discuter en review.

## Ce qu'il faut livrer

Aujourd'hui, `DELETE /api/v1/books/{id}` supprime physiquement le livre. On veut passer à une suppression logique:

- Ajouter un champ `IsDeleted` (et/ou `DeletedAt`) sur l'entité
- `DELETE /api/v1/books/{id}` marque le livre comme supprimé (toujours `204 No Content`)
- `GET /api/v1/books` n'inclut plus les livres supprimés
- `GET /api/v1/books/{id}` pour un livre supprimé → `404 Not Found`
- Ajouter `GET /api/v1/books/deleted` (pour administration) qui liste les livres supprimés
- Ajouter `POST /api/v1/books/{id}/restore` qui restaure un livre supprimé

## Critères d'acceptation

- [ ] Les comportements listés fonctionnent comme décrit
- [ ] Tests ajoutés pour chaque cas
- [ ] PR ouverte avec le template rempli et relue par un coéquipier

## Discussion en review

- Faut-il interdire la création d'un nouveau livre avec le même ISBN qu'un livre supprimé?
- Faut-il une limite au nombre d'essais de restauration?
