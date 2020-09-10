<!---
Template

-->

# Markdown to LateX converter

## Idée de base 

    L'idée est de combiner la rapiditée d'éctirure du markdown et la lisibilitée/propreté du LateX

## Piste

    Le markedown étant un language simple, des regex seront possible pour un bonne partie des cas
    Penser à créer un entete en markdown pour indiquer au compilateur les informations complémentaires (nom, classe de document, Titre) 

## Conversion markdown vers LateX

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
*asterisks*
_underscores_

**asterisks**
__underscores__

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
* itm
* itm
* itm
    * itm

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