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
