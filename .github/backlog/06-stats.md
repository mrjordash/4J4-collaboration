# [Pratique 6] Endpoint de statistiques de la bibliothèque
<!-- labels: practice, feature -->

## Objectif d'apprentissage

Calculer des agrégats à partir des données en mémoire. Discuter en review du format de réponse et des cas limites (bibliothèque vide, etc.).

## Ce qu'il faut livrer

Un nouvel endpoint `GET /api/v1/books/stats` qui retourne:

```json
{
  "totalBooks": 42,
  "averageYear": 2005.3,
  "averagePages": 324,
  "byGenre": {
    "Programming": 15,
    "Fantasy": 8,
    "Dystopian": 3
  },
  "oldest": { "id": 5, "title": "...", "year": 1937 },
  "newest": { "id": 12, "title": "...", "year": 2023 }
}
```

## Critères d'acceptation

- [ ] Toutes les valeurs sont calculées à partir du repository, pas en dur
- [ ] Si la bibliothèque est vide: réponse cohérente (`totalBooks: 0`, `oldest` et `newest` à `null`, etc.)
- [ ] Les moyennes sont arrondies à une décimale
- [ ] `byGenre` trie les genres par nombre décroissant
- [ ] Tests ajoutés pour: cas nominal, bibliothèque vide, plusieurs livres même année
- [ ] PR ouverte avec le template rempli et relue par un coéquipier

## Discussion en review

- Si la Pratique 5 (soft delete) est mergée, les livres supprimés doivent-ils compter dans les stats?
- Si la Pratique 3 (rating) est mergée, ajouter `averageRating` semble naturel — est-ce que ça doit être dans cette PR ou une suivante?
