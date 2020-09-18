# Markdown to LateX converter

## Idée de base

    L'idée est de combiner la rapiditée d'éctirure du markdown et la lisibilitée/propreté du LateX

## Piste

    Le markedown étant un language simple, des regex seront possible pour un bonne partie des cas
    Penser à créer un entete en markdown pour indiquer au compilateur les informations complémentaires (nom, classe de document, Titre)

## Conversion markdown vers LateX

### Le template

    Le template est un bloc de commentaire en début de markdown permetant d'indiquer au compilateur des informations non écrite dans le documents (ex : auteur, date ...) qui sont des composantes essentielles dans un document latex pour certain. Il n'est pas obligatoire d'avoir un template par soucis de globalisation, il y aura donc des paramètres par défault pour les informations essentielles

### le format du template

    Chaque instruction du template sera de la forme : <instruction>:<valeurs> (pensez bien a ne pas mettre d'espace avant et après les :)
    L'ordre d'intruction n'a pas d'importance, mais il existe un nombre limite qui est le nombres d'instruction maximum que le template peut contenir. Si la limite est atteinte et qu'il reste des instructions après, le compilateur n'en tiendra pas compte.

### Les instructions :

Les instructions sont pour l'insant au nombre de 4, affiché sous la forme : instruction (valeur par défault quand nécessaire) (valeurs possible)

- auteur(s) (nom de l'utilisateur courant) (\*)
- Titre (nom du document passé en paramètre) (\*)
- classe du document (article) (report,book,slides)
- Table des matières (non) (oui,non)
  - voir [Les classes latex](https://fr.wikibooks.org/wiki/LaTeX/Les_classes) pour plus d'informations

### Les en-tête

Markdown :

```markdown
# h1

## h2

.
.
.
```

LateX :

```latex

\part{titre}
\chapter{titre}
.
.
.
```

[Voir le wiki](https://fr.wikibooks.org/wiki/LaTeX/Structuration_du_texte#Parties_d'un_texte)

### Les Emphasis

Markdown :

```md
_asterisks_
_underscores_

**asterisks**
**underscores**

~~Scratch this.~~ (texte barré)
```

LateX

```latex
\textit{asterisks}
\textbf{blabla}
```

[voir wiki](https://fr.wikibooks.org/wiki/LaTeX/Mise_en_forme_du_texte#/media/Fichier:LaTeX_table_formes_series_fontes.png)

Pour le texte barré :

```latex
\usepackage[normalem]{ ulem }
\usepackage{soul}

\st{barré}
```

[voir site ](https://tutoriels-latex.blogspot.com/2013/05/comment-ecrire-un-texte-barre-dans-latex.html)

### Liste

En markdown :

```md
- itm
- itm
- itm
  - itm

1. bla
2. bla
3. bla
   1. bla
```

En latex :

```latex
\begin{itemize}
    \item itm
    \item itm
    \item itm
    \begin{itemize}{
        \item itm
    }

\begin{enumerate}
    \item bla
    \item bla
    \item bla
    \begin{enumerate}
        \item bla
```
