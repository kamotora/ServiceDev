create table Model
(
    Id      int auto_increment
        primary key,
    Name    varchar(255) not null,
    BrandId int          not null,
    constraint Model_ibfk_1
        foreign key (BrandId) references Brand (Id)
);

create index BrandId
    on Model (BrandId);

INSERT INTO db.Model (Id, Name, BrandId) VALUES (1, 'Aveo', 1);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (2, 'Captiva', 1);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (3, 'Cobalt', 1);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (4, 'Cruze', 1);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (5, 'Epica', 1);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (6, 'Lacetti', 1);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (7, 'Lanos', 1);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (8, 'Niva', 1);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (9, 'Orlando', 1);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (10, 'Spark', 1);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (11, 'Tahoe', 1);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (12, 'C-MAX', 2);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (13, 'EcoSport', 2);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (14, 'Escape', 2);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (15, 'Explorer', 2);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (16, 'Fiesta', 2);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (17, 'Focus', 2);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (18, 'Fusion', 2);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (19, 'Galaxy', 2);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (20, 'Kuga', 2);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (21, 'Mondeo', 2);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (22, 'Tourneo Connect', 2);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (23, 'Accord', 3);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (24, 'Civic', 3);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (25, 'Civic Ferio', 3);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (26, 'CR-V', 3);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (27, 'Fit', 3);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (28, 'Freed', 3);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (29, 'HR-V', 3);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (30, 'Odyssey', 3);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (31, 'Pilot', 3);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (32, 'Stepwgn', 3);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (33, 'Stream', 3);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (34, 'Accent', 4);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (35, 'Creta', 4);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (36, 'Elantra', 4);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (37, 'Getz', 4);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (38, 'Grand Starex', 4);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (39, 'i40', 4);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (40, 'ix35', 4);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (41, 'Santa Fe', 4);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (42, 'Solaris', 4);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (43, 'Sonata', 4);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (44, 'Almera', 10);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (45, 'Almera Classic', 10);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (46, 'Juke', 10);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (47, 'Murano', 10);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (48, 'Note', 10);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (49, 'Primera', 10);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (50, 'Qashqai', 10);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (51, 'Teana', 10);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (52, 'Terrano', 10);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (53, 'Tiida', 10);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (54, 'Avensis', 13);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (55, 'Camry', 13);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (56, 'Carina', 13);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (57, 'Corolla', 13);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (58, 'Corona', 13);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (59, 'Land Cruiser', 13);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (60, 'Land Cruiser Prado', 13);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (61, 'Mark II', 13);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (62, 'Prius', 13);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (63, 'RAV4', 13);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (64, 'Caddy', 14);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (65, 'Caravelle', 14);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (66, 'Golf', 14);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (67, 'Jetta', 14);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (68, 'Multivan', 14);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (69, 'Passat', 14);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (70, 'Passat CC', 14);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (71, 'Polo', 14);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (72, 'Tiguan', 14);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (73, 'Touareg', 14);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (74, '2107', 16);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (75, '2110', 16);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (76, '2112', 16);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (77, '2114', 16);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (78, '2115', 16);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (79, '2121 (4x4)', 16);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (80, 'Granta', 16);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (81, 'Kalina', 16);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (82, 'Largus', 16);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (83, 'Priora', 16);
INSERT INTO db.Model (Id, Name, BrandId) VALUES (84, 'Vesta', 16);