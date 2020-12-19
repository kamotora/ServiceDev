create table TypeService
(
    Id   int auto_increment
        primary key,
    Name varchar(255) not null
);

INSERT INTO db.TypeService (Id, Name) VALUES (1, 'Замена масла ДВС');
INSERT INTO db.TypeService (Id, Name) VALUES (2, 'Замена масла АКПП');
INSERT INTO db.TypeService (Id, Name) VALUES (3, 'Замена масла МКПП');
INSERT INTO db.TypeService (Id, Name) VALUES (4, 'Замена охлаждающей жидкости');
INSERT INTO db.TypeService (Id, Name) VALUES (5, 'Шиномонтаж');
INSERT INTO db.TypeService (Id, Name) VALUES (6, 'Замена тормозных колодок');
INSERT INTO db.TypeService (Id, Name) VALUES (7, 'Замена тормозных дисков');
INSERT INTO db.TypeService (Id, Name) VALUES (8, 'Замена двигателя');
INSERT INTO db.TypeService (Id, Name) VALUES (9, 'Замена КПП');
INSERT INTO db.TypeService (Id, Name) VALUES (10, 'Покраска бампера');
INSERT INTO db.TypeService (Id, Name) VALUES (11, 'Покраска капота');
INSERT INTO db.TypeService (Id, Name) VALUES (12, 'Полная покраска');
INSERT INTO db.TypeService (Id, Name) VALUES (13, 'Кузовной ремонт');
INSERT INTO db.TypeService (Id, Name) VALUES (14, 'Прошивка');