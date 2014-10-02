
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
 motDePasse VARCHAR(30) NOT NULL
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
 listeCMD VARCHAR(100)
);

ALTER TABLE Effets
ADD CONSTRAINT Effets_Utilisateurs_FK
FOREIGN KEY(idUtilisateur) REFERENCES Utilisateurs(idUtilisateur);


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




