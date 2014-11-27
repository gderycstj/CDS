DROP TABLE IF EXISTS ObjetsEffets;
DROP TABLE IF EXISTS PoursuivantsEffets;
DROP TABLE IF EXISTS Effets;
DROP TABLE IF EXISTS NiveauxObjets;
DROP TABLE IF EXISTS Objets;
DROP TABLE IF EXISTS NiveauxPoursuivants;
DROP TABLE IF EXISTS Poursuivants;
DROP TABLE IF EXISTS Apparences;
DROP TABLE IF EXISTS Niveaux;
DROP TABLE IF EXISTS Progressions;
DROP TABLE IF EXISTS Objectifs;
DROP TABLE IF EXISTS Scores;
DROP TABLE IF EXISTS ModesDeJeu;
DROP TABLE IF EXISTS Utilisateurs;


/*******************************Table utilisateur***************************************/
CREATE TABLE IF NOT EXISTS Utilisateurs
(idUtilisateur INT AUTO_INCREMENT PRIMARY KEY,
 idApparence INT NOT NULL,
 nom VARCHAR(30) NOT NULL,
 motDePasse VARCHAR(30) NOT NULL,
 estActive BOOL DEFAULT TRUE
);

/*le nom de l'utilisateur doit être unique*/
ALTER TABLE Utilisateurs
ADD CONSTRAINT nom_UK
UNIQUE(nom);

/*********************************Table mode de jeu***************************************/
CREATE TABLE IF NOT EXISTS ModesDeJeu
(idModeDeJeu INT AUTO_INCREMENT PRIMARY KEY,
 idUtilisateur INT NOT NULL,
 nom VARCHAR(30) NOT NULL
);

ALTER TABLE ModesDeJeu
ADD CONSTRAINT ModeDeJeu_Utilisateurs_FK
FOREIGN KEY(idUtilisateur) REFERENCES Utilisateurs(idUtilisateur);

/*le nom du mode de jeu doit être unique*/
ALTER TABLE ModesDeJeu
ADD CONSTRAINT nomMode_UK
UNIQUE(nom);


/*******************************Table Score********************************************/
CREATE TABLE IF NOT EXISTS Scores
(idScore INT AUTO_INCREMENT PRIMARY KEY,
 idModeDeJeu INT NOT NULL,
 idUtilisateur INT NOT NULL,
 score INT NOT NULL
);

ALTER TABLE Scores
ADD CONSTRAINT Scores_ModesDeJeu_FK
FOREIGN KEY(idModeDeJeu) REFERENCES ModesDeJeu(idModeDeJeu)
ON DELETE CASCADE;

ALTER TABLE Scores
ADD CONSTRAINT Scores_Utilisateurs_FK
FOREIGN KEY(idUtilisateur) REFERENCES Utilisateurs(idUtilisateur);


/*************************************Table Objectifs********************************************/
CREATE TABLE Objectifs
(idObjectif INT AUTO_INCREMENT PRIMARY KEY,
nom VARCHAR(30) NOT NULL,
valeurObjectif INT NOT NULL
);

/*******************************Table Progression*******************************************/
CREATE TABLE IF NOT EXISTS Progressions
(idProgression INT AUTO_INCREMENT PRIMARY KEY,
 idUtilisateur INT NOT NULL,
 idModeDeJeu INT NOT NULL,
 niveauAtteint INT NOT NULL,
 niveauAtteintMax INT NOT NULL
);

ALTER TABLE Progressions
ADD CONSTRAINT Progression_Utilisateurs_FK
FOREIGN KEY(idUtilisateur) REFERENCES Utilisateurs(idUtilisateur);

/*******************************Table Niveaux******************************************/
CREATE TABLE Niveaux	
(idNiveau INT AUTO_INCREMENT PRIMARY KEY,
 idModeDeJeu INT NOT NULL,
 idUtilisateur INT NOT NULL,
 idObjectif INT,
 numNiveau INT NOT NULL
);

ALTER TABLE Niveaux
ADD CONSTRAINT Niveaux_Objectifs_FK
FOREIGN KEY (idObjectif) REFERENCES Objectifs(idObjectif);

ALTER TABLE Niveaux
ADD CONSTRAINT Niveaux_Utilisateurs_FK
FOREIGN KEY(idUtilisateur) REFERENCES Utilisateurs(idUtilisateur);

ALTER TABLE Niveaux
ADD CONSTRAINT Niveaux_ModeDeJeu_FK
FOREIGN KEY(idModeDeJeu) REFERENCES ModesDeJeu(idModeDeJeu)
ON DELETE CASCADE;


/*****************************Table Apparences*************************************************/
CREATE TABLE Apparences
(idApparence INT AUTO_INCREMENT PRIMARY KEY,
  image VARCHAR(50)			/*Temp pas trouvé comment mettre image*/
);

/*****************************Table Poursuivants**********************************************/
CREATE TABLE Poursuivants
(idPoursuivant INT AUTO_INCREMENT PRIMARY KEY,
 nom VARCHAR(30),
 idUtilisateur INT NOT NULL,
 idApparence INT NOT NULL,
 valeurPoint INT NOT NULL,
 listeCMD VARCHAR(50)
);

ALTER TABLE Poursuivants
ADD CONSTRAINT Poursuivants_Utilisateurs_FK
FOREIGN KEY(idUtilisateur) REFERENCES Utilisateurs(idUtilisateur);

ALTER TABLE Poursuivants
ADD CONSTRAINT Poursuivants_Apparences_FK
FOREIGN KEY(idApparence) REFERENCES Apparences(idApparence);

/*chaque poursuivants doit avoir un nom unique*/
ALTER TABLE Poursuivants
ADD CONSTRAINT nomPoursuivant_UK
UNIQUE(nom);

/****************************Table option poursuivant******************************************/
CREATE TABLE NiveauxPoursuivants
(idNiveauPoursuivant INT AUTO_INCREMENT PRIMARY KEY,
 idNiveau INT NOT NULL,
 idPoursuivant INT NOT NULL,
 valeur INT NOT NULL,
 rarete INT NOT NULL
);

ALTER TABLE NiveauxPoursuivants
ADD CONSTRAINT NiveauxPoursuivants_Niveaux_FK
FOREIGN KEY(idNiveau) REFERENCES Niveaux(idNiveau)
ON DELETE CASCADE;

ALTER TABLE NiveauxPoursuivants
ADD CONSTRAINT NiveauxPoursuivants_Poursuivants_FK
FOREIGN KEY(idPoursuivant) REFERENCES Poursuivants(idPoursuivant);

/***********************************Table objet*********************************************************/

CREATE TABLE Objets
(idObjet INT AUTO_INCREMENT PRIMARY KEY,
 idUtilisateur INT NOT NULL,
 idApparence INT NOT NULL,
 nom VARCHAR(30)
);

ALTER TABLE Objets
ADD CONSTRAINT Objets_Utilisateurs_FK
FOREIGN KEY(idUtilisateur) REFERENCES Utilisateurs(idUtilisateur);

ALTER TABLE Objets
ADD CONSTRAINT Objets_Apparences_FK
FOREIGN KEY(idApparence) REFERENCES Apparences(idApparence);

/*chaque objet doit avoir un nom unique*/
ALTER TABLE Objets
ADD CONSTRAINT nomObjet_UK
UNIQUE(nom);

/***************************************table option objet***********************************8*/

CREATE TABLE NiveauxObjets
(idNiveauObjet INT AUTO_INCREMENT PRIMARY KEY,
 idNiveau INT NOT NULL,
 idObjet INT NOT NULL,
 valeur INT NOT NULL,
 rarete INT NOT NULL
);

ALTER TABLE NiveauxObjets
ADD CONSTRAINT NiveauxObjets_Niveaux_FK
FOREIGN KEY(idNiveau) REFERENCES Niveaux(idNiveau)
ON DELETE CASCADE;

ALTER TABLE NiveauxObjets
ADD CONSTRAINT NiveauxObjets_Objets_FK
FOREIGN KEY(idObjet) REFERENCES Objets(idObjet);

/**************************************table Effets********************************************/

CREATE TABLE Effets
(idEffet INT AUTO_INCREMENT PRIMARY KEY,
 idUtilisateur INT NOT NULL,
 nom VARCHAR(60) NOT NULL, 
 listeCMD VARCHAR(100)
);

ALTER TABLE Effets
ADD CONSTRAINT Effets_Utilisateurs_FK
FOREIGN KEY(idUtilisateur) REFERENCES Utilisateurs(idUtilisateur);

ALTER TABLE Effets
ADD CONSTRAINT nomEffet_UK
UNIQUE(nom);

/**************************************Table logique effet****************************************/
CREATE TABLE PoursuivantsEffets
(idPoursuivantsEffets INT AUTO_INCREMENT PRIMARY KEY,
 idPoursuivant INT NOT NULL,
 idEffet INT NOT NULL,
 numAttaque INT NOT NULL
);

ALTER TABLE PoursuivantsEffets
ADD CONSTRAINT PoursuivantsEffets_Poursuivants_FK
FOREIGN KEY(idPoursuivant) REFERENCES Poursuivants(idPoursuivant);

ALTER TABLE PoursuivantsEffets
ADD CONSTRAINT PoursuivantsEffets_Effets_FK
FOREIGN KEY(idEffet) REFERENCES Effets(idEffet);

/**************************************Table logique effet****************************************/
CREATE TABLE ObjetsEffets
(idObjetsEffets INT AUTO_INCREMENT PRIMARY KEY,
 idObjet INT NOT NULL,
 idEffet INT NOT NULL
);


ALTER TABLE ObjetsEffets
ADD CONSTRAINT ObjetsEffets_Objets_FK
FOREIGN KEY(idObjet) REFERENCES Objets(idObjet);

ALTER TABLE ObjetsEffets
ADD CONSTRAINT ObjetsEffets_Effets_FK
FOREIGN KEY(idEffet) REFERENCES Effets(idEffet);

INSERT INTO apparences(image)
VALUES
('/image/bonhommeMod.png'
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

INSERT INTO Apparences(image)
VALUES
('/image/sprint.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/zappy.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/barriere.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/cercle.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/Poursuivants/bubley.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/Poursuivants/coeurtoxic.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/Poursuivants/firey.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/Poursuivants/fleche.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/Poursuivants/orangeSpeed.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/Poursuivants/pinky.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/Poursuivants/pinstar.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/Poursuivants/polen.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/Poursuivants/sparkley.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/Poursuivants/talktome.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/Objets/bluePotion.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/Objets/etoileDeNinja.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/Objets/greenOrb.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/Objets/greenPotion.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/Objets/happyBoum.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/Objets/orangePotion.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/Objets/purpleOrb.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/Objets/redOrb.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/Objets/redPotion.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/Objets/superBox.png'
);

INSERT INTO Apparences(image)
VALUES
('/image/Objets/yellowPotion.png'
);

INSERT INTO utilisateurs(idApparence,nom,motDePasse)
VALUES
((SELECT idApparence FROM Apparences WHERE image = '/image/bonhommeMod.png')
 ,'Gabriel'
 ,'1232388'
);


INSERT INTO utilisateurs(idApparence,nom,motDePasse)
VALUES
((SELECT idApparence FROM Apparences WHERE image = '/image/bonhommeMod.png')
 ,'Vincent'
 ,'1147998'
);

INSERT INTO utilisateurs(idApparence,nom,motDePasse)
VALUES
((SELECT idApparence FROM Apparences WHERE image = '/image/bonhommeMod.png')
 ,'William'
 ,'1263998'
);

INSERT INTO utilisateurs(idApparence,nom,motDePasse)
VALUES
((SELECT idApparence FROM Apparences WHERE image = '/image/bonhommeMod.png')
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
VALUES('Losange Mauve'
	   ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
	   ,(SELECT idApparence FROM apparences WHERE image = '/image/LosangeMauve.png')
	   ,250
	   ,'MhMdC'
);

INSERT INTO Poursuivants(nom,idUtilisateur,idApparence,valeurPoint,listeCMD)
VALUES('triangle'
	   ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
	   ,(SELECT idApparence FROM apparences WHERE image = '/image/triangle.png')
	   ,400
	   ,'Ijp{MhC}MhIjg{Mg}Ijd{Md}C'
);

INSERT INTO Poursuivants(nom,idUtilisateur,idApparence,valeurPoint,listeCMD)
VALUES('zappy'
,(SELECT idUtilisateur FROM Utilisateurs WHERE nom='Admin')
,(SELECT idApparence FROM apparences WHERE image = '/image/zappy.png')
,350
,'Mh/MhCMh/MhCMhCMh/MhCMhCMh'
);

INSERT INTO Poursuivants(nom,idUtilisateur,idApparence,valeurPoint,listeCMD)
VALUES('Cercle'
	   ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
	   ,(SELECT idApparence FROM apparences WHERE image = '/image/cercle.png')
	   ,600
	   ,'MhR{Md}{Mg}{}'
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

INSERT INTO Objets(idUtilisateur,idApparence,nom)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
,(SELECT idApparence FROM Apparences WHERE image = '/image/sprint.png')
,'Sprint'
);

INSERT INTO Objets(idUtilisateur,idApparence,nom)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
,(SELECT idApparence FROM Apparences WHERE image = '/image/barriere.png')
,'Barriere'
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux WHERE numNiveau = 0 AND idModeDeJeu =  (SELECT idModeDeJeu FROM modesDeJeu WHERE nom = 'Normal'))
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'carré vert')	
,5
,1
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux WHERE numNiveau = 0 AND idModeDeJeu =  (SELECT idModeDeJeu FROM modesDeJeu WHERE nom = 'Normal'))
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'Losange Mauve')	
,5
,3
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux WHERE numNiveau = 0 AND idModeDeJeu =  (SELECT idModeDeJeu FROM modesDeJeu WHERE nom = 'Normal'))
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'triangle')	
,1
,12
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux WHERE numNiveau = 0 AND idModeDeJeu =  (SELECT idModeDeJeu FROM modesDeJeu WHERE nom = 'Normal'))
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'zappy')	
,3
,6
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux WHERE numNiveau = 0 AND idModeDeJeu =  (SELECT idModeDeJeu FROM modesDeJeu WHERE nom = 'Normal'))
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'Cercle')	
,2
,10
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

INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux WHERE numNiveau = 0 AND idModeDeJeu =  (SELECT idModeDeJeu FROM modesDeJeu WHERE nom = 'Normal'))
,(SELECT idObjet FROM Objets WHERE nom = 'Sprint')	
,2
,25
);

INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux WHERE numNiveau = 0 AND idModeDeJeu =  (SELECT idModeDeJeu FROM modesDeJeu WHERE nom = 'Normal'))
,(SELECT idObjet FROM Objets WHERE nom = 'Barriere')	
,2
,25
);

INSERT INTO Effets(idUtilisateur,nom,listeCMD)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
 ,'Vie 1'
 ,'S'
);

INSERT INTO Effets(idUtilisateur,nom,listeCMD)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
 ,'Armure 1'
 ,'A'
);

INSERT INTO Effets(idUtilisateur,nom,listeCMD)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
 ,'Sprint 1'
 ,'V'
);

INSERT INTO Effets(idUtilisateur,nom,listeCMD)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
 ,'Invincibilité 2'
 ,'**'
);

INSERT INTO Effets(idUtilisateur,nom,listeCMD)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
 ,'Vie 2'
 ,'SS'
);

INSERT INTO Effets(idUtilisateur,nom,listeCMD)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
 ,'Armure 2'
 ,'AA'
);

INSERT INTO Effets(idUtilisateur,nom,listeCMD)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
 ,'Armure 3'
 ,'AAA'
);

INSERT INTO Effets(idUtilisateur,nom,listeCMD)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
 ,'Sprint 2'
 ,'VV'
);

INSERT INTO Effets(idUtilisateur,nom,listeCMD)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
 ,'Sprint 3'
 ,'VVV'
);

INSERT INTO Effets(idUtilisateur,nom,listeCMD)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
 ,'Invincibilité 1'
 ,'*'
);

INSERT INTO Effets(idUtilisateur,nom,listeCMD)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
 ,'Invincibilité 3'
 ,'***'
);

INSERT INTO Effets(idUtilisateur,nom,listeCMD)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
 ,'Invincibilité 4'
 ,'****'
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
);

INSERT INTO ObjetsEffets(idObjet,idEffet)
VALUES
((SELECT idObjet FROM Objets WHERE nom = 'Sprint')
 ,(SELECT idEffet FROM Effets WHERE nom = 'Sprint 1')
);

INSERT INTO ObjetsEffets(idObjet,idEffet)
VALUES
((SELECT idObjet FROM Objets WHERE nom = 'Barriere')
 ,(SELECT idEffet FROM Effets WHERE nom = 'Invincibilité 2')
);

INSERT INTO Objectifs(nom,valeurObjectif)
VALUES
('Point'
,7500
);

INSERT INTO Objectifs(nom,valeurObjectif)
VALUES
('Tour'
,150
);

INSERT INTO Objectifs(nom,valeurObjectif)
VALUES
('Tour'
,100
);

INSERT INTO Objectifs(nom,valeurObjectif)
VALUES
('Point'
,25000
);

INSERT INTO Objectifs(nom,valeurObjectif)
VALUES
('Armure'
,12
);

INSERT INTO Objectifs(nom,valeurObjectif)
VALUES
('Armure'
,6
);

INSERT INTO Objectifs(nom,valeurObjectif)
VALUES
('Tour'
,500
);

INSERT INTO Objectifs(nom,valeurObjectif)
VALUES
('Tour'
,250
);

INSERT INTO Objectifs(nom,valeurObjectif)
VALUES
('Point'
,12500
);

INSERT INTO Objectifs(nom,valeurObjectif)
VALUES
('Point'
,16000
);

INSERT INTO Objectifs(nom,valeurObjectif)
VALUES
('Survivre'
,0
);

INSERT INTO Niveaux(idModeDeJeu,idUtilisateur,idObjectif,numNiveau)
VALUES
((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Survie')
,(SELECT idUtilisateur  FROM Utilisateurs  WHERE nom = 'Admin')
,(SELECT idObjectif FROM Objectifs WHERE nom = 'Point' AND valeurObjectif = '7500')
,1
);

INSERT INTO Niveaux(idModeDeJeu,idUtilisateur,idObjectif,numNiveau)
VALUES
((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Survie')
,(SELECT idUtilisateur  FROM Utilisateurs  WHERE nom = 'Admin')
,(SELECT idObjectif FROM Objectifs WHERE nom = 'Tour' AND valeurObjectif = '150')
,2
);

INSERT INTO Niveaux(idModeDeJeu,idUtilisateur,idObjectif,numNiveau)
VALUES
((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Survie')
,(SELECT idUtilisateur  FROM Utilisateurs  WHERE nom = 'Admin')
,(SELECT idObjectif FROM Objectifs WHERE nom = 'Tour' AND valeurObjectif = '150')
,3
);

INSERT INTO Niveaux(idModeDeJeu,idUtilisateur,idObjectif,numNiveau)
VALUES
((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Survie')
,(SELECT idUtilisateur  FROM Utilisateurs  WHERE nom = 'Admin')
,(SELECT idObjectif FROM Objectifs WHERE nom = 'Tour' AND valeurObjectif = '100')
,4
);

INSERT INTO Niveaux(idModeDeJeu,idUtilisateur,idObjectif,numNiveau)
VALUES
((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Survie')
,(SELECT idUtilisateur  FROM Utilisateurs  WHERE nom = 'Admin')
,(SELECT idObjectif FROM Objectifs WHERE nom = 'Tour' AND valeurObjectif = '150')
,5
);

INSERT INTO Niveaux(idModeDeJeu,idUtilisateur,idObjectif,numNiveau)
VALUES
((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Survie')
,(SELECT idUtilisateur  FROM Utilisateurs  WHERE nom = 'Admin')
,(SELECT idObjectif FROM Objectifs WHERE nom = 'Point' AND valeurObjectif = '25000')
,6
);

INSERT INTO Niveaux(idModeDeJeu,idUtilisateur,idObjectif,numNiveau)
VALUES
((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Survie')
,(SELECT idUtilisateur  FROM Utilisateurs  WHERE nom = 'Admin')
,(SELECT idObjectif FROM Objectifs WHERE nom = 'Armure' AND valeurObjectif = '6')
,7
);

INSERT INTO Niveaux(idModeDeJeu,idUtilisateur,idObjectif,numNiveau)
VALUES
((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Survie')
,(SELECT idUtilisateur  FROM Utilisateurs  WHERE nom = 'Admin')
,(SELECT idObjectif FROM Objectifs WHERE nom = 'Point' AND valeurObjectif = '12500')
,8
);

INSERT INTO Niveaux(idModeDeJeu,idUtilisateur,idObjectif,numNiveau)
VALUES
((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Survie')
,(SELECT idUtilisateur  FROM Utilisateurs  WHERE nom = 'Admin')
,(SELECT idObjectif FROM Objectifs WHERE nom = 'Point' AND valeurObjectif = '16000')
,9
);

INSERT INTO Niveaux(idModeDeJeu,idUtilisateur,idObjectif,numNiveau)
VALUES
((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Survie')
,(SELECT idUtilisateur  FROM Utilisateurs  WHERE nom = 'Admin')
,(SELECT idObjectif FROM Objectifs WHERE nom = 'Tour' AND valeurObjectif = '150')
,10
);

/* Objet Niveau 1 */
INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '1')
,(SELECT idObjet FROM Objets WHERE nom = 'Potion de vie')
,2
,25
);

INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '1')
,(SELECT idObjet FROM Objets WHERE nom = 'Barriere')
,2
,25
);

INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '1')
,(SELECT idObjet FROM Objets WHERE nom = 'Sprint')
,2
,25
);
/* */

/* Objet Niveau 2 */
INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '2')
,(SELECT idObjet FROM Objets WHERE nom = 'Sprint')
,2
,25
);

INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '2')
,(SELECT idObjet FROM Objets WHERE nom = 'Armure')
,2
,25
);

/* */

/* Objet Niveau 3 */
INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '3')
,(SELECT idObjet FROM Objets WHERE nom = 'Barriere')
,2
,25
);

INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '3')
,(SELECT idObjet FROM Objets WHERE nom = 'Sprint')
,2
,25
);

INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '3')
,(SELECT idObjet FROM Objets WHERE nom = 'Armure')
,2
,25
);

/* */
/* Objet Niveau 4 */
INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '4')
,(SELECT idObjet FROM Objets WHERE nom = 'Armure')
,2
,25
);

INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '4')
,(SELECT idObjet FROM Objets WHERE nom = 'Barriere')
,2
,25
);

INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '4')
,(SELECT idObjet FROM Objets WHERE nom = 'Sprint')
,2
,25
);
/* */

/* Objet Niveau 5 */
INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '5')
,(SELECT idObjet FROM Objets WHERE nom = 'Barriere')
,2
,25
);

INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '5')
,(SELECT idObjet FROM Objets WHERE nom = 'Sprint')
,2
,25
);

INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '5')
,(SELECT idObjet FROM Objets WHERE nom = 'Armure')
,2
,25
);
/* */

/* Objet Niveau 6 */
INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '6')
,(SELECT idObjet FROM Objets WHERE nom = 'Sprint')
,2
,25
);
/* */

/* Objet Niveau 7 */
INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '7')
,(SELECT idObjet FROM Objets WHERE nom = 'Barriere')
,2
,25
);

INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '7')
,(SELECT idObjet FROM Objets WHERE nom = 'Armure')
,2
,25
);

/* */

/* Objet Niveau 8 */
INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '8')
,(SELECT idObjet FROM Objets WHERE nom = 'Barriere')
,2
,25
);

INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '8')
,(SELECT idObjet FROM Objets WHERE nom = 'Sprint')
,2
,25
);
/* */

/* Objet Niveau 9 */
INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '9')
,(SELECT idObjet FROM Objets WHERE nom = 'Armure')
,2
,25
);

INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '9')
,(SELECT idObjet FROM Objets WHERE nom = 'Potion de vie')
,2
,25
);
/* */

/* Objet niveau 10 */
INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '10')
,(SELECT idObjet FROM Objets WHERE nom = 'Armure')
,2
,25
);

INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '10')
,(SELECT idObjet FROM Objets WHERE nom = 'Potion de vie')
,2
,25
);

INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '10')
,(SELECT idObjet FROM Objets WHERE nom = 'Sprint')
,2
,25
);

INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '10')
,(SELECT idObjet FROM Objets WHERE nom = 'Barriere')
,2
,25
);
/* */

/* Poursuivant Niveau 1 */
INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '1')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'carré vert')
,5
,1
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '1')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'Losange Mauve')
,5
,3
);

/* */

/* Poursuivant Niveau 2 */
INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '2')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'carré vert')
,5
,1
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '2')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'Losange Mauve')
,5
,3
);
/* */

/* Poursuivant Niveau 3 */
INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '3')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'Losange Mauve')
,10
,1
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '3')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'Triangle')
,1
,15
);
/* */

/* Poursuivant Niveau 4 */
INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '4')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'carré vert')
,5
,1
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '4')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'Losange Mauve')
,5
,3
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '4')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'Triangle')
,1
,12
);
/* */

/* Poursuivant Niveau 5 */
INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '5')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'carré vert')
,5
,1
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '5')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'Losange Mauve')
,5
,3
);


INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '5')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'zappy')
,3
,6
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '5')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'cercle')
,7
,10
);
/* */

/* Poursuivant Niveau 6 */
INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '6')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'zappy')
,15
,1
);

/* */

/* Poursuivant Niveau 7 */
INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '7')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'carré vert')
,5
,1
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '7')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'Losange Mauve')
,5
,3
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '7')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'Triangle')
,1
,12
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '7')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'zappy')
,3
,6
);
/* */

/* Poursuivant Niveau 8 */
INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '8')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'Triangle')
,3
,8
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '8')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'zappy')
,5
,4
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '8')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'cercle')
,5
,4
);

/* */

/* Poursuivant Niveau 9 */
INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '9')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'Triangle')
,10
,3
);
/* */

/* Poursuivant Niveau 10 */
INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)
VALUES
((SELECT idNiveau FROM Niveaux AS n
INNER JOIN ModesDeJeu AS m ON m.idModeDeJeu = n.idModeDeJeu
WHERE nom = 'Survie' AND numNiveau = '10')
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'Cercle')
,10
,1
);

/* */



INSERT INTO progressions(idUtilisateur,idModeDeJeu,niveauAtteint,niveauAtteintMax)
VALUES
((SELECT idUtilisateur FROM utilisateurs WHERE nom='admin')
,(SELECT idModeDeJeu FROM modesdejeu WHERE nom='survie')
,10
,10
);

COMMIT