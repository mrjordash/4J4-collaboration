# [Pratique 3] Ajouter un champ `Rating` et un endpoint pour le mettre à jour
<!-- labels: practice, feature -->

## Objectif d'apprentissage

Modifier l'entité et son DTO simultanément, garder la cohérence à travers plusieurs couches (entité → DTO → service → contrôleur → tests).

## Ce qu'il faut livrer

1. Ajouter un champ `Rating` de type `int?` sur l'entité `Book` et le DTO `BookDto`. Valeurs permises: `1` à `5`, ou `null` (non noté).
2. Créer un endpoint `PATCH /api/v1/books/{id}/rating` qui accepte:
   ```json
   { "rating": 4 }
   ```
   et met à jour uniquement ce champ.
3. Mettre à jour les livres *seedés* pour leur donner des notes variées.

## Critères d'acceptation

- [ ] Le champ `Rating` apparaît dans les réponses JSON de tous les endpoints existants
- [ ] `PATCH .../rating` accepte les valeurs 1 à 5; autre valeur → `400`
- [ ] `PATCH .../rating` avec `rating: null` réinitialise la note
- [ ] `PATCH .../rating` sur un livre inexistant → `404`
- [ ] Tests ajoutés pour les cas valides et invalides
- [ ] PR ouverte avec le template rempli et relue par un coéquipier

## Flux Git attendu

- Branche dédiée
- Si la PR est trop grosse, découper en deux: (a) ajout du champ, (b) endpoint de mise à jour. Discuter en review.
