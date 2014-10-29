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
DROP TABLE IF EXISTS ModesDeJeu;
DROP TABLE IF EXISTS Scores;
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

/*******************************Table Score********************************************/
CREATE TABLE IF NOT EXISTS Scores
(idScore INT AUTO_INCREMENT PRIMARY KEY,
 idUtilisateur INT NOT NULL,
 score INT NOT NULL
);

ALTER TABLE Scores
ADD CONSTRAINT Scores_Utilisateurs_FK
FOREIGN KEY(idUtilisateur) REFERENCES Utilisateurs(idUtilisateur);

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


/*******************************Table Progression*******************************************/
CREATE TABLE IF NOT EXISTS Progressions
(idProgression INT AUTO_INCREMENT PRIMARY KEY,
 idUtilisateur INT NOT NULL,
 idModeDeJeu INT NOT NULL,
 niveauAtteint INT NOT NULL
);

ALTER TABLE Progressions
ADD CONSTRAINT Progression_Utilisateurs_FK
FOREIGN KEY(idUtilisateur) REFERENCES Utilisateurs(idUtilisateur);

/*******************************Table option général******************************************/
CREATE TABLE Niveaux	
(idNiveau INT AUTO_INCREMENT PRIMARY KEY,
 idModeDeJeu INT NOT NULL,
 idUtilisateur INT NOT NULL,
 numNiveau INT NOT NULL
);

ALTER TABLE Niveaux
ADD CONSTRAINT Niveaux_Utilisateurs_FK
FOREIGN KEY(idUtilisateur) REFERENCES Utilisateurs(idUtilisateur);

ALTER TABLE Niveaux
ADD CONSTRAINT Niveaux_ModeDeJeu_FK
FOREIGN KEY(idModeDeJeu) REFERENCES ModesDeJeu(idModeDeJeu);

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
 rareté INT NOT NULL
);

ALTER TABLE NiveauxPoursuivants
ADD CONSTRAINT NiveauxPoursuivants_Niveaux_FK
FOREIGN KEY(idNiveau) REFERENCES Niveaux(idNiveau);

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
FOREIGN KEY(idNiveau) REFERENCES Niveaux(idNiveau);

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
,1
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rareté)
VALUES
((SELECT idNiveau FROM Niveaux WHERE numNiveau = 0 AND idModeDeJeu =  (SELECT idModeDeJeu FROM modesDeJeu WHERE nom = 'Normal'))
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'Losange Mauve')	
,5
,3
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
 ,'S'
);

INSERT INTO Effets(idUtilisateur,nom,listeCMD)
VALUES
((SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
 ,'Armure 1'
 ,'A'
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

COMMIT
