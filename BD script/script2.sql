INSERT INTO utilisateurs(idApparence,nom,motDePasse)
VALUES
((SELECT idApparence FROM Apparences WHERE image = '/image/bonhommeMod.png')
 ,'Mathieu'
 ,'1232388'
);

INSERT INTO utilisateurs(idApparence,nom,motDePasse)
VALUES
((SELECT idApparence FROM Apparences WHERE image = '/image/bonhommeMod.png')
 ,'Alain'
 ,'professeur'
);

INSERT INTO modesdejeu(idUtilisateur,nom)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Alain')
 ,'surprise'
);

INSERT INTO Scores(idModeDeJeu,idUtilisateur,score)
VALUES
(((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Normal'))
  ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Mathieu')
  ,750
);

INSERT INTO Scores(idModeDeJeu,idUtilisateur,score)
VALUES
(((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Normal'))
  ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Gabriel')
  ,2000
);

INSERT INTO Scores(idModeDeJeu,idUtilisateur,score)
VALUES
(((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Normal'))
  ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'William')
  ,3000
);

INSERT INTO Scores(idModeDeJeu,idUtilisateur,score)
VALUES
(((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Normal'))
  ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Vincent')
  ,4000
);

INSERT INTO Scores(idModeDeJeu,idUtilisateur,score)
VALUES
(((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Normal'))
  ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Gabriel')
  ,5000
);

INSERT INTO Scores(idModeDeJeu,idUtilisateur,score)
VALUES
(((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Normal'))
  ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
  ,6000
);

INSERT INTO Scores(idModeDeJeu,idUtilisateur,score)
VALUES
(((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Normal'))
  ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Gabriel')
  ,7000
);

INSERT INTO Scores(idModeDeJeu,idUtilisateur,score)
VALUES
(((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Normal'))
  ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Gabriel')
  ,8000
);

INSERT INTO Scores(idModeDeJeu,idUtilisateur,score)
VALUES
(((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Normal'))
  ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Gabriel')
  ,9000
);

INSERT INTO Scores(idModeDeJeu,idUtilisateur,score)
VALUES
(((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Normal'))
  ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Gabriel')
  ,10000
);

INSERT INTO Objectifs(valeurObjectif,nom)
VALUES
(3
,'Armure');

INSERT INTO Niveaux(idModeDeJeu,idUtilisateur,numNiveau,idObjectif)
VALUES((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'surprise')
	   ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Alain')
	   ,0
	   ,(SELECT idObjectif FROM Objectifs WHERE nom = 'Armure' AND valeurObjectif = 3)
);


INSERT INTO Poursuivants(nom,idUtilisateur,idApparence,valeurPoint,listeCMD)
VALUES('Cheval'
	   ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Alain')
	   ,(SELECT idApparence FROM apparences WHERE image = '/image/Poursuivants/coeurtoxic.png')
	   ,250
	   ,'MhMhMhMdC'
);

INSERT INTO Poursuivants(nom,idUtilisateur,idApparence,valeurPoint,listeCMD)
VALUES('Ziggy'
	   ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Alain')
	   ,(SELECT idApparence FROM apparences WHERE image = '/image/Poursuivants/orangeSpeed.png')
	   ,250
	   ,'MhMdC/MhMgC'
);

INSERT INTO Objets(idUtilisateur,idApparence,nom)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Alain')
,(SELECT idApparence FROM Apparences WHERE image = '/image/Objets/bluePotion.png')
,'Super potion'
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux WHERE numNiveau = 0 AND idModeDeJeu =  (SELECT idModeDeJeu FROM modesDeJeu WHERE nom = 'surprise'))
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'cheval')	
,2
,1
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux WHERE numNiveau = 0 AND idModeDeJeu =  (SELECT idModeDeJeu FROM modesDeJeu WHERE nom = 'surprise'))
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'Ziggy')	
,2
,1
);

INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux WHERE numNiveau = 0 AND idModeDeJeu =  (SELECT idModeDeJeu FROM modesDeJeu WHERE nom = 'surprise'))
,(SELECT idObjet FROM Objets WHERE nom = 'Super potion')	
,0
,0
);

INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux WHERE numNiveau = 0 AND idModeDeJeu =  (SELECT idModeDeJeu FROM modesDeJeu WHERE nom = 'surprise'))
,(SELECT idObjet FROM Objets WHERE nom = 'Armure')	
,0
,0
);

INSERT INTO ObjetsEffets(idObjet,idEffet)
VALUES
((SELECT idObjet FROM Objets WHERE nom = 'Super potion')
 ,(SELECT idEffet FROM Effets WHERE nom = 'Vie 2')
);


INSERT INTO progressions(idUtilisateur,idModeDeJeu,niveauAtteint,niveauAtteintMax)
VALUES
((SELECT idUtilisateur FROM utilisateurs WHERE nom='Alain')
,(SELECT idModeDeJeu FROM modesdejeu WHERE nom='survie')
,5
,10
);
