create table Worker
(
    Id         int auto_increment
        primary key,
    LastName   varchar(255) not null,
    FirstName  varchar(255) not null,
    MiddleName varchar(255) not null,
    Phone      varchar(255) not null
);

INSERT INTO db.Worker (Id, LastName, FirstName, MiddleName, Phone) VALUES (1, 'Королев', 'Иван', 'Ярославович', '79816654877');
INSERT INTO db.Worker (Id, LastName, FirstName, MiddleName, Phone) VALUES (2, 'Акимов', 'Дмитрий', 'Эминович', '79796352637');
INSERT INTO db.Worker (Id, LastName, FirstName, MiddleName, Phone) VALUES (3, 'Шаповалов', 'Ростислав', 'Макарович', '79821850681');
INSERT INTO db.Worker (Id, LastName, FirstName, MiddleName, Phone) VALUES (4, 'Михайлов', 'Артём', 'Егорович', '79291502814');
INSERT INTO db.Worker (Id, LastName, FirstName, MiddleName, Phone) VALUES (5, 'Лазарев', 'Матвей', 'Яковлевич', '79196315897');
INSERT INTO db.Worker (Id, LastName, FirstName, MiddleName, Phone) VALUES (6, 'Зыков', 'Даниил', 'Тимофеевич', '79967451186');
INSERT INTO db.Worker (Id, LastName, FirstName, MiddleName, Phone) VALUES (7, 'Гусев', 'Максим', 'Алексеевич', '79320398597');
INSERT INTO db.Worker (Id, LastName, FirstName, MiddleName, Phone) VALUES (8, 'Малинин', 'Тимофей', 'Арсентьевич', '79229527670');
INSERT INTO db.Worker (Id, LastName, FirstName, MiddleName, Phone) VALUES (9, 'Виноградов', 'Арсений', 'Иванович', '79713406466');
INSERT INTO db.Worker (Id, LastName, FirstName, MiddleName, Phone) VALUES (10, 'Некрасов', 'Никита', 'Ильич', '79729750500');
INSERT INTO db.Worker (Id, LastName, FirstName, MiddleName, Phone) VALUES (11, 'Овчинников', 'Алексей', 'Артёмович', '79532857405');
INSERT INTO db.Worker (Id, LastName, FirstName, MiddleName, Phone) VALUES (12, 'Иванов', 'Алексей', 'Егорович', '79682445712');
INSERT INTO db.Worker (Id, LastName, FirstName, MiddleName, Phone) VALUES (13, 'Лыков', 'Иван', 'Максимович', '79484426284');
INSERT INTO db.Worker (Id, LastName, FirstName, MiddleName, Phone) VALUES (14, 'Петров', 'Арсений', 'Львович', '79108134996');
INSERT INTO db.Worker (Id, LastName, FirstName, MiddleName, Phone) VALUES (15, 'Соколов', 'Владислав', 'Макарович', '79800248585');
INSERT INTO db.Worker (Id, LastName, FirstName, MiddleName, Phone) VALUES (16, 'Лебедев', 'Борис', 'Максимович', '79704003810');
INSERT INTO db.Worker (Id, LastName, FirstName, MiddleName, Phone) VALUES (17, 'Семенов', 'Сергей', 'Артёмович', '79168263783');
INSERT INTO db.Worker (Id, LastName, FirstName, MiddleName, Phone) VALUES (18, 'Гордеев', 'Олег', 'Алексеевич', '79308795965');
INSERT INTO db.Worker (Id, LastName, FirstName, MiddleName, Phone) VALUES (19, 'Фомин', 'Матвей', 'Андреевич', '79831534428');
INSERT INTO db.Worker (Id, LastName, FirstName, MiddleName, Phone) VALUES (20, 'Левин', 'Михаил', 'Миронович', '79197610236');