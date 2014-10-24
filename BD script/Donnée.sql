INSERT INTO apparences(image)
VALUES
('/image/perso.png'
);

INSERT INTO apparences(image)
VALUES
('/image/carreBleu.png'
);

INSERT INTO apparences(image)
VALUES
('/image/carreVert.png'
);

INSERT INTO apparences(image)
VALUES
('/image/LosangeJaune.png'
);

INSERT INTO apparences(image)
VALUES
('/image/LosangeMauve.png'
);

INSERT INTO apparences(image)
VALUES
('/image/triangle.png'
);

INSERT INTO apparences(image)
VALUES
('/image/potionVie.png'
);

INSERT INTO apparences(image)
VALUES
('/image/armure.png'
);

INSERT INTO utilisateurs(idApparence,nom,motDePasse)
VALUES
((SELECT idApparence FROM Apparences WHERE image = '/image/perso.png')
 ,'Gabriel'
 ,'1232388'
);


INSERT INTO utilisateurs(idApparence,nom,motDePasse)
VALUES
((SELECT idApparence FROM Apparences WHERE image = '/image/perso.png')
 ,'Vincent'
 ,'1147998'
);

INSERT INTO utilisateurs(idApparence,nom,motDePasse)
VALUES
((SELECT idApparence FROM Apparences WHERE image = '/image/perso.png')
 ,'William'
 ,'1263998'
);

INSERT INTO utilisateurs(idApparence,nom,motDePasse)
VALUES
((SELECT idApparence FROM Apparences WHERE image = '/image/perso.png')
 ,'Admin'
 ,'Willgabvinc3'
);

INSERT INTO modesdejeu(idUtilisateur,nom)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
 ,'Normal'
);

INSERT INTO modesdejeu(idUtilisateur,nom)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
 ,'Survie'
);

INSERT INTO Niveaux(idModeDeJeu,idUtilisateur,numNiveau)
VALUES((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Normal')
	   ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
	   ,0
);


INSERT INTO Poursuivants(nom,idUtilisateur,idApparence,valeurPoint,listeCMD)
VALUES('carré vert'
	   ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
	   ,(SELECT idApparence FROM apparences WHERE image = '/image/carreVert.png')
	   ,100
	   ,'MhC'
);

INSERT INTO Poursuivants(nom,idUtilisateur,idApparence,valeurPoint,listeCMD)
VALUES('carré bleu'
	   ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
	   ,(SELECT idApparence FROM apparences WHERE image = '/image/carreBleu.png')
	   ,100
	   ,'MhC'
);


INSERT INTO Poursuivants(nom,idUtilisateur,idApparence,valeurPoint,listeCMD)
VALUES('Losange Jaune'
	   ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
	   ,(SELECT idApparence FROM apparences WHERE image = '/image/LosangeJaune.png')
	   ,250
	   ,'MhMgC'
);


INSERT INTO Poursuivants(nom,idUtilisateur,idApparence,valeurPoint,listeCMD)
VALUES('Losange Mauve'
	   ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
	   ,(SELECT idApparence FROM apparences WHERE image = '/image/LosangeMauve.png')
	   ,250
	   ,'MhMdC'
);

INSERT INTO Objets(idUtilisateur,idApparence,nom)
VALUES((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin' )
	   ,(SELECT idApparence FROM apparences WHERE image = '/image/potionVie.png')
	   ,'Potion de vie'
);

INSERT INTO Objets(idUtilisateur,idApparence,nom)
VALUES((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin' )
	   ,(SELECT idApparence FROM apparences WHERE image = '/image/armure.png')
	   ,'Armure'
);


INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rareté)
VALUES
((SELECT idNiveau FROM Niveaux WHERE numNiveau = 0 AND idModeDeJeu =  (SELECT idModeDeJeu FROM modesDeJeu WHERE nom = 'Normal'))
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'carré vert')	
,5
,5
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rareté)
VALUES
((SELECT idNiveau FROM Niveaux WHERE numNiveau = 0 AND idModeDeJeu =  (SELECT idModeDeJeu FROM modesDeJeu WHERE nom = 'Normal'))
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'carré bleu')	
,5
,5
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rareté)
VALUES
((SELECT idNiveau FROM Niveaux WHERE numNiveau = 0 AND idModeDeJeu =  (SELECT idModeDeJeu FROM modesDeJeu WHERE nom = 'Normal'))
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'Losange Jaune')	
,5
,7
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rareté)
VALUES
((SELECT idNiveau FROM Niveaux WHERE numNiveau = 0 AND idModeDeJeu =  (SELECT idModeDeJeu FROM modesDeJeu WHERE nom = 'Normal'))
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'Losange Mauve')	
,5
,7
);


INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux WHERE numNiveau = 0 AND idModeDeJeu =  (SELECT idModeDeJeu FROM modesDeJeu WHERE nom = 'Normal'))
,(SELECT idObjet FROM Objets WHERE nom = 'Potion de vie')	
,2
,25
);

INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux WHERE numNiveau = 0 AND idModeDeJeu =  (SELECT idModeDeJeu FROM modesDeJeu WHERE nom = 'Normal'))
,(SELECT idObjet FROM Objets WHERE nom = 'Armure')	
,2
,25
);

INSERT INTO Effets(idUtilisateur,nom,listeCMD)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
 ,'Vie 1'
 ,'V1'
);

INSERT INTO Effets(idUtilisateur,nom,listeCMD)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
 ,'Armure 1'
 ,'A1'
);

INSERT INTO ObjetsEffets(idObjet,idEffet)
VALUES
((SELECT idObjet FROM Objets WHERE nom = 'Potion de vie')
 ,(SELECT idEffet FROM Effets WHERE nom = 'Vie 1')
);

INSERT INTO ObjetsEffets(idObjet,idEffet)
VALUES
((SELECT idObjet FROM Objets WHERE nom = 'Armure')
 ,(SELECT idEffet FROM Effets WHERE nom = 'Armure 1')
)