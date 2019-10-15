# shapesay
Wrap text in cool shapes, like cowsay! Cross-platform on .Net Core

![Shapesay rectangle](img/shapesay.png)

## Soptisticated options

Rectangles with -Rect

Triangles with -Tri

Slanted parallelograms with -Ital

Invert shape content with -Inv

Invert random shape content with -InvRand

Replace content with "sparkles" with -Spark

Add text anywhere in between shapes.

Back-track to previous shape line with -/

### Examples:

```sh
shapesay "wow this is pretty cool stuff" -Tri -Inv -/ " Pretty cool indeed" -Rect
```

![Shapesay abstract art - Triangle in slanted rectangle](img/shapesay_advanced_flags.png)

```sh
shapesay "`figlet wow this is pretty cool stuff`" -Inv  -Rect -Inv -Rect
```

Combined with *nix package figlet.
![Shapesay abstract art - Rectangles and inverse combined with text in figlet](img/combined_with_figlet.png)

Going crazy

```sh
shapesay "abcd wat is this" -Tri -Rect -Sparkle -Ital "`figlet -c wow`" -Rect -Inv -Ital "`figlet -c '~ imagination ~'`" -Rect
```

![Shapesay abstract art - Combining a bunch of stuff going crazy](img/go_crazy.png)