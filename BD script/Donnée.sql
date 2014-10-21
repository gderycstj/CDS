INSERT INTO apparences(image)
VALUES
('test.pnj'
);

INSERT INTO utilisateurs(idApparence,nom,motDePasse)
VALUES
((SELECT idApparence FROM Apparences WHERE image = 'test.pnj')
 ,'Gabriel'
 ,'1232388'
);


INSERT INTO utilisateurs(idApparence,nom,motDePasse)
VALUES
((SELECT idApparence FROM Apparences WHERE image = 'test.pnj')
 ,'Vincent'
 ,'1147998'
);

INSERT INTO utilisateurs(idApparence,nom,motDePasse)
VALUES
((SELECT idApparence FROM Apparences WHERE image = 'test.pnj')
 ,'William'
 ,'1263998'
);

INSERT INTO utilisateurs(idApparence,nom,motDePasse)
VALUES
((SELECT idApparence FROM Apparences WHERE image = 'test.pnj')
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
VALUES((SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = 'Survie')
	   ,(SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin')
	   ,0);
};

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rareté)
VALUES
((SELECT idNiveau FROM Niveaux WHERE numNiveau = 0 AND idModeDeJeu =  (SELECT idModeDeJeu FROM modesDeJeu WHERE nom = 'Survie'))
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'carré vert')	
,5
,5
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rareté)
VALUES
((SELECT idNiveau FROM Niveaux WHERE numNiveau = 0 AND idModeDeJeu =  (SELECT idModeDeJeu FROM modesDeJeu WHERE nom = 'Survie'))
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'carré bleu')	
,5
,5
);

INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rareté)
VALUES
((SELECT idNiveau FROM Niveaux WHERE numNiveau = 0 AND idModeDeJeu =  (SELECT idModeDeJeu FROM modesDeJeu WHERE nom = 'Survie'))
,(SELECT idPoursuivant FROM Poursuivants WHERE nom = 'triangle')	
,15
,25
);

