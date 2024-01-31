# TIA-Project

## Authors

* BERROUCHE Issameddine
* HAMONO Morvan

## Design

Nous n'avons pas pu implémenter la plus part des fonctionnalités demandées. En effet, un bug de Google AR [spécifique à mon model de smartphone](https://github.com/google-ar/arcore-android-sdk/issues/1553) nous empêchait de faire fonctionner l'application sur nos téléphones (c'est aussi la raison pour laquelle l'application du tp d'introduction ne marchait pas sur nos telephone). Ce bug nous a grandement découragé. Nous n'avons compris la source de ce bug que trop tard (pendant ma semaine de vacance de noel) et nous n'avons toujours pas trouvé de solution. Pour tester l'application, nous avons donc du utiliser une application de streaming de caméra (DroidCam) pour utiliser la caméra d'un téléphone comme une webcam, couplé à Unity Remote pour pouvoir tester l'application sur un téléphone. Nous n'avons donc pas pu tester l'application en condition réel, nous ne savons donc pas si l'APK fonctionne (bien qu'il ne semble pas y avoir de raison pour que ça ne fonctionne pas).

Initialement nous avions prévu de faire un jeu de parcour simple. Avec une balle de golf qui devait parcourir un chemin mis AR, mis réel pour aller ce mettre dans un trou (le trou aurait été un autre objet AR). Nous avions aussi prévu de faire un système de score, avec un timer et un nombre d'objet à ramasser.

La balle de golf aurait été un objet 3D animé par la physique. L'UI du jeu aurait permis à l'utilisateur de "pousser" la balle dans la direction qu'il voulait avec un joystick. La bale n'aurait pas de bouton "stop" et aurait continué à rouler jusqu'à ce qu'elle s'arrête d'elle même grace à une simulation de friction. Nous avions aussi prévu de faire un système de "saut" pour la balle, qui aurait été déclenché par un bouton sur l'UI visible uniquement quand la balle se trouvait sur le bon type de terrain.

## Implémentation

Les seul fonctionnalités implémentées sont:

* La detection de l'image target "Terrain" qui permet de placer un terrain de golf sur une surface plane.
* L'UI de base du jeu, avec un bouton pour lancer la balle et un joystick pour la diriger.
* Les mouvements de base de la balle de golf.

## Mode d'emploi

* Télécharger et installer l'APK dans release.
* Imprimer l'image target "Terrain" (dans le dossier\Assets\Targets).
  