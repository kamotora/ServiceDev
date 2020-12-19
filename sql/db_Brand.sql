create table Brand
(
    Id   int auto_increment
        primary key,
    Name varchar(255) not null
);

INSERT INTO db.Brand (Id, Name) VALUES (1, 'Chevrolet');
INSERT INTO db.Brand (Id, Name) VALUES (2, 'Ford');
INSERT INTO db.Brand (Id, Name) VALUES (3, 'Honda');
INSERT INTO db.Brand (Id, Name) VALUES (4, 'Hyundai');
INSERT INTO db.Brand (Id, Name) VALUES (10, 'Nissan');
INSERT INTO db.Brand (Id, Name) VALUES (13, 'Toyota');
INSERT INTO db.Brand (Id, Name) VALUES (14, 'Volkswagen');
INSERT INTO db.Brand (Id, Name) VALUES (16, 'Лада');
INSERT INTO db.Brand (Id, Name) VALUES (51, 'Test');