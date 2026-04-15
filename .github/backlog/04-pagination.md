# [Pratique 4] Paginer la liste des livres
<!-- labels: practice, feature -->

## Objectif d'apprentissage

Préparer l'API pour un catalogue qui grandit. Décider en équipe du format de réponse — c'est un exercice de revue de code où la structure compte autant que la fonctionnalité.

## Ce qu'il faut livrer

Ajouter deux paramètres optionnels à `GET /api/v1/books`:

- `page` (défaut: `1`)
- `pageSize` (défaut: `10`, maximum: `50`)

La réponse doit renvoyer un bloc structuré avec les items **et** les métadonnées de navigation.

## Exemple attendu

```json
GET /api/v1/books?page=1&pageSize=2

{
  "items": [ /* 2 livres */ ],
  "page": 1,
  "pageSize": 2,
  "totalItems": 5,
  "totalPages": 3
}
```

## Critères d'acceptation

- [ ] Les valeurs par défaut s'appliquent si les paramètres sont absents
- [ ] `pageSize` > 50 est plafonné à 50 (ou rejeté `400` — à discuter)
- [ ] `page < 1` ou `pageSize < 1` → `400`
- [ ] La pagination se combine avec les filtres de la Pratique 2 (si déjà mergée)
- [ ] Les tests couvrent: sans paramètres, page/pageSize valides, valeurs invalides, dernière page partielle
- [ ] PR ouverte avec le template rempli et relue par un coéquipier

## Discussion en review

- Le changement de format casse-t-il les clients existants? Comment gérer?
- Pourriez-vous retourner les méta-infos dans les headers HTTP plutôt que dans le body?
