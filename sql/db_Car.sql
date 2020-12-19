create table Car
(
    Id       int auto_increment
        primary key,
    Name     varchar(255) null,
    ModelId  int          not null,
    ClientId int          not null,
    constraint Car_ibfk_1
        foreign key (ModelId) references Model (Id),
    constraint Car_ibfk_2
        foreign key (ClientId) references Client (Id)
);

create index ClientId
    on Car (ClientId);

create index ModelId
    on Car (ModelId);

INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (1, 'Изменённый авто', 5, 5);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (2, 'Автомобиль', 72, 51);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (3, 'Автомобиль', 72, 82);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (4, 'Автомобиль', 75, 60);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (5, 'Автомобиль', 84, 10);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (6, 'Автомобиль', 7, 65);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (7, 'Автомобиль', 40, 91);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (8, 'Автомобиль', 6, 54);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (9, 'Автомобиль', 84, 91);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (10, 'Автомобиль', 46, 91);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (11, 'Автомобиль', 10, 18);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (12, 'Автомобиль', 55, 62);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (13, 'Автомобиль', 68, 36);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (14, 'Автомобиль', 83, 28);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (15, 'Автомобиль', 2, 48);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (16, 'Автомобиль', 47, 49);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (17, 'Автомобиль', 25, 87);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (18, 'Автомобиль', 17, 79);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (19, 'Автомобиль', 49, 30);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (20, 'Автомобиль', 79, 62);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (21, 'Автомобиль', 40, 24);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (22, 'Автомобиль', 55, 57);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (23, 'Автомобиль', 41, 32);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (24, 'Автомобиль', 30, 64);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (25, 'Автомобиль', 19, 86);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (26, 'Автомобиль', 50, 47);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (27, 'Автомобиль', 44, 61);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (28, 'Автомобиль', 45, 97);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (29, 'Автомобиль', 24, 79);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (30, 'Автомобиль', 1, 40);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (31, 'Автомобиль', 80, 91);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (32, 'Автомобиль', 18, 18);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (33, 'Автомобиль', 73, 91);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (34, 'Автомобиль', 68, 73);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (35, 'Автомобиль', 9, 78);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (36, 'Автомобиль', 72, 1);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (37, 'Автомобиль', 74, 38);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (38, 'Автомобиль', 48, 68);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (39, 'Автомобиль', 78, 55);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (40, 'Автомобиль', 73, 28);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (41, 'Автомобиль', 10, 58);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (42, 'Автомобиль', 3, 72);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (43, 'Автомобиль', 44, 89);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (44, 'Автомобиль', 78, 94);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (45, 'Автомобиль', 2, 100);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (46, 'Автомобиль', 46, 36);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (47, 'Автомобиль', 40, 42);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (48, 'Автомобиль', 26, 86);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (49, 'Автомобиль', 62, 15);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (50, 'Автомобиль', 5, 72);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (51, 'Автомобиль', 21, 48);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (52, 'Автомобиль', 18, 39);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (53, 'Автомобиль', 60, 28);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (54, 'Автомобиль', 61, 79);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (55, 'Автомобиль', 47, 2);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (56, 'Автомобиль', 78, 14);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (57, 'Автомобиль', 27, 26);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (58, 'Автомобиль', 7, 63);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (59, 'Автомобиль', 39, 10);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (60, 'Автомобиль', 51, 4);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (61, 'Автомобиль', 7, 2);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (62, 'Автомобиль', 35, 100);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (63, 'Автомобиль', 68, 21);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (64, 'Автомобиль', 79, 93);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (65, 'Автомобиль', 18, 73);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (66, 'Автомобиль', 76, 98);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (67, 'Автомобиль', 67, 93);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (68, 'Автомобиль', 8, 10);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (69, 'Автомобиль', 40, 66);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (70, 'Автомобиль', 60, 47);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (71, 'Автомобиль', 80, 38);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (72, 'Автомобиль', 50, 24);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (73, 'Автомобиль', 63, 19);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (74, 'Автомобиль', 40, 26);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (75, 'Автомобиль', 43, 17);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (76, 'Автомобиль', 64, 18);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (77, 'Автомобиль', 1, 62);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (78, 'Автомобиль', 83, 59);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (79, 'Автомобиль', 6, 4);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (80, 'Автомобиль', 63, 76);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (81, 'Автомобиль', 3, 30);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (82, 'Автомобиль', 26, 51);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (83, 'Автомобиль', 81, 14);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (84, 'Автомобиль', 62, 57);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (85, 'Автомобиль', 3, 29);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (86, 'Автомобиль', 43, 16);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (87, 'Автомобиль', 56, 70);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (88, 'Автомобиль', 29, 55);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (89, 'Автомобиль', 49, 78);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (90, 'Автомобиль', 10, 79);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (91, 'Автомобиль', 80, 58);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (92, 'Автомобиль', 56, 80);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (93, 'Автомобиль', 44, 79);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (94, 'Автомобиль', 63, 78);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (95, 'Автомобиль', 51, 73);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (96, 'Автомобиль', 62, 52);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (97, 'Автомобиль', 55, 76);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (98, 'Автомобиль', 34, 65);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (99, 'Автомобиль', 69, 61);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (100, 'Автомобиль', 11, 41);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (101, 'Автомобиль', 9, 12);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (102, 'Автомобиль', 65, 99);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (103, 'Автомобиль', 60, 64);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (104, 'Автомобиль', 71, 30);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (105, 'Автомобиль', 20, 24);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (106, 'Автомобиль', 19, 81);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (107, 'Автомобиль', 51, 48);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (108, 'Автомобиль', 21, 86);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (109, 'Автомобиль', 17, 39);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (110, 'Автомобиль', 56, 51);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (111, 'Автомобиль', 84, 62);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (112, 'Автомобиль', 19, 68);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (113, 'Автомобиль', 82, 1);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (114, 'Автомобиль', 80, 76);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (115, 'Автомобиль', 81, 24);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (116, 'Автомобиль', 84, 30);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (117, 'Автомобиль', 39, 91);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (118, 'Автомобиль', 52, 94);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (119, 'Автомобиль', 29, 84);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (120, 'Автомобиль', 4, 69);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (121, 'Автомобиль', 62, 73);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (122, 'Автомобиль', 24, 42);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (123, 'Автомобиль', 59, 49);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (124, 'Автомобиль', 22, 52);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (125, 'Автомобиль', 2, 20);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (126, 'Автомобиль', 26, 21);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (127, 'Автомобиль', 83, 3);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (128, 'Автомобиль', 57, 95);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (129, 'Автомобиль', 59, 85);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (130, 'Автомобиль', 67, 64);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (131, 'Автомобиль', 67, 36);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (132, 'Автомобиль', 67, 97);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (133, 'Автомобиль', 47, 62);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (134, 'Автомобиль', 42, 100);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (135, 'Автомобиль', 54, 27);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (136, 'Автомобиль', 67, 86);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (137, 'Автомобиль', 61, 80);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (138, 'Автомобиль', 21, 74);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (139, 'Автомобиль', 3, 71);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (140, 'Автомобиль', 77, 18);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (141, 'Автомобиль', 76, 25);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (142, 'Автомобиль', 2, 32);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (143, 'Автомобиль', 12, 85);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (144, 'Автомобиль', 73, 25);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (145, 'Автомобиль', 82, 8);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (146, 'Автомобиль', 8, 9);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (147, 'Автомобиль', 73, 55);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (148, 'Автомобиль', 36, 98);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (149, 'Автомобиль', 60, 3);
INSERT INTO db.Car (Id, Name, ModelId, ClientId) VALUES (150, 'Автомобиль', 17, 39);