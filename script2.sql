INSERT INTO utilisateurs(idApparence,nom,motDePasse)
VALUES
((SELECT idApparence FROM Apparences WHERE image = '/image/bonhommeMod.png')
 ,'Mathieu'
 ,'1232388'
);

INSERT INTO modesdejeu(idUtilisateur,nom)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Gabriel')
 ,'Test survie'
);

INSERT INTO modesdejeu(idUtilisateur,nom)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Vincent')
 ,'test armure'
);

INSERT INTO modesdejeu(idUtilisateur,nom)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Vincent')
 ,'test Score'
);

INSERT INTO modesdejeu(idUtilisateur,nom)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Vincent')
 ,'test tours'
);

INSERT INTO Scores(idModeDeJeu,idUtilisateur,score)
VALUES
(((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Normal'))
  ,(SELECT idUtilisateur FROM Utilisateur WHERE nom = 'Mathieu')
  ,750
);

INSERT INTO Scores(idModeDeJeu,idUtilisateur,score)
VALUES
(((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Normal'))
  ,(SELECT idUtilisateur FROM Utilisateur WHERE nom = 'Gabriel')
  ,2000
);

INSERT INTO Scores(idModeDeJeu,idUtilisateur,score)
VALUES
(((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Normal'))
  ,(SELECT idUtilisateur FROM Utilisateur WHERE nom = 'William')
  ,3000
);

INSERT INTO Scores(idModeDeJeu,idUtilisateur,score)
VALUES
(((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Normal'))
  ,(SELECT idUtilisateur FROM Utilisateur WHERE nom = 'Vincent')
  ,4000
);

INSERT INTO Scores(idModeDeJeu,idUtilisateur,score)
VALUES
(((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Normal'))
  ,(SELECT idUtilisateur FROM Utilisateur WHERE nom = 'Gabriel')
  ,5000
);

INSERT INTO Scores(idModeDeJeu,idUtilisateur,score)
VALUES
(((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Normal'))
  ,(SELECT idUtilisateur FROM Utilisateur WHERE nom = 'Admin')
  ,6000
);

INSERT INTO Scores(idModeDeJeu,idUtilisateur,score)
VALUES
(((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Normal'))
  ,(SELECT idUtilisateur FROM Utilisateur WHERE nom = 'Gabriel')
  ,7000
);

INSERT INTO Scores(idModeDeJeu,idUtilisateur,score)
VALUES
(((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Normal'))
  ,(SELECT idUtilisateur FROM Utilisateur WHERE nom = 'Gabriel')
  ,8000
);

INSERT INTO Scores(idModeDeJeu,idUtilisateur,score)
VALUES
(((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Normal'))
  ,(SELECT idUtilisateur FROM Utilisateur WHERE nom = 'Gabriel')
  ,9000
);

INSERT INTO Scores(idModeDeJeu,idUtilisateur,score)
VALUES
(((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Normal'))
  ,(SELECT idUtilisateur FROM Utilisateur WHERE nom = 'Gabriel')
  ,10000
);


INSERT INTO Niveaux(idModeDeJeu,idUtilisateur,numNiveau)
VALUES((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Test survie')
	   ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Gabriel')
	   ,0
);

INSERT INTO Niveaux(idModeDeJeu,idUtilisateur,numNiveau)
VALUES((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'test armure')
	   ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Vincent')
	   ,0
);

INSERT INTO Niveaux(idModeDeJeu,idUtilisateur,numNiveau)
VALUES((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'test Score')
	   ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'William')
	   ,0
);

INSERT INTO Niveaux(idModeDeJeu,idUtilisateur,numNiveau)
VALUES((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'test tours')
	   ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'William')
	   ,0
);

INSERT INTO 

