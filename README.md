<!---
Template

-->

# Markdown to LateX converter

## Idée de base 

L'idée est de combiner la rapidité d'écriture du markdown et la lisibilité / propreté du LaTeX.

## Piste

Le markedown étant un language simple, des regex seront possibles pour un bonne partie des cas.

Pensez à créer un entête en markdown pour indiquer au compilateur les informations complémentaires (nom, classe de document, Titre, ...).

## Conversion markdown vers LateX

### Les en-tête

Markdown : 

```markdown
# h1 
## h2
.
.
###### h6
```

LaTeX : 

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
*asterisks*
_underscores_

**asterisks**
__underscores__

~~Scratch this.~~ (texte barré)
```

LaTeX
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

[voir site](https://tutoriels-latex.blogspot.com/2013/05/comment-ecrire-un-texte-barre-dans-latex.html)

### Liste

En markdown :

```md
* itm
* itm
* itm
    * itm

1. bla
2. bla
3. bla
   1. bla
```

En LaTeX : 

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


## Authors

[Leer0r](https://github.com/Leer0r) and [NoxFly](https://github.com/NoxFly).


## LICENSE

See MIT License.