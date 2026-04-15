# [Pratique 1] Ajouter un endpoint de recherche de livres
<!-- labels: practice, good-first-pr, feature -->

## Objectif d'apprentissage

Première PR individuelle — créer une branche, pousser, ouvrir une PR, faire relire, merger.

## Ce qu'il faut livrer

Un nouvel endpoint `GET /api/v1/books/search?q=...` qui retourne les livres dont le titre **ou** l'auteur contient la chaîne recherchée (insensible à la casse).

## Exemple d'utilisation

```
GET /api/v1/books/search?q=clean
→ retourne "Clean Code"

GET /api/v1/books/search?q=tolkien
→ retourne "The Hobbit"
```

## Critères d'acceptation

- [ ] La recherche est insensible à la casse
- [ ] Elle cherche dans `Title` et `Author`
- [ ] Une chaîne vide ou manquante retourne `400 Bad Request`
- [ ] Aucun résultat retourne un tableau vide (`200 OK`, pas `404`)
- [ ] Au moins un test unitaire ajouté pour la recherche
- [ ] PR ouverte avec le template rempli et relue par un coéquipier

## Flux Git attendu

1. `git checkout -b feat/search-books`
2. Coder + commiter
3. `git push -u origin feat/search-books`
4. Ouvrir la PR vers `main`
5. Répondre aux commentaires, pousser les corrections
6. Merge après approbation + CI verte
