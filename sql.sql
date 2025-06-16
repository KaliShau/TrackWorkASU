-- Таблица Statuses
CREATE TABLE Statuses (
    status_id SERIAL PRIMARY KEY,
    status_name VARCHAR(255) NOT NULL UNIQUE
);

-- Таблица Users
CREATE TABLE Users (
    user_id SERIAL PRIMARY KEY,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    username VARCHAR(255) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    full_name VARCHAR(255) NOT NULL,
    role VARCHAR(50) NOT NULL CHECK (role IN ('Admin', 'ASU_staff', 'Client'))
);

-- Таблица Requests
CREATE TABLE Requests (
    request_id SERIAL PRIMARY KEY,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    client_id INT NOT NULL,
    content TEXT NOT NULL,
    status_id INT NOT NULL,
    assigned_to INT,
    closed_at TIMESTAMP,
    FOREIGN KEY (client_id) REFERENCES Users(user_id) ON DELETE CASCADE,
    FOREIGN KEY (status_id) REFERENCES Statuses(status_id) ON DELETE RESTRICT,
    FOREIGN KEY (assigned_to) REFERENCES Users(user_id) ON DELETE SET NULL
);

-- Таблица Reports
CREATE TABLE Reports (
    report_id SERIAL PRIMARY KEY,
    user_id INT NOT NULL,
    report_title VARCHAR(255) NOT NULL,
    report_text TEXT NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES Users(user_id) ON DELETE CASCADE
);

-- Данные Statuses
INSERT INTO Statuses (status_name) VALUES 
('Новая'),
('Принята'),
('Закрыта');
	
-- Данные Users
INSERT INTO Users (username, password, full_name, role) VALUES
-- Администраторы
('admin1', 'securepass1', 'Иванов Иван Иванович', 'Admin'),
('admin2', 'securepass2', 'Петров Петр Петрович', 'Admin'),
-- Сотрудники АСУ
('asu1', 'asu1pass', 'Сидорова Анна Михайловна', 'ASU_staff'),
('asu2', 'asu2pass', 'Кузнецов Дмитрий Сергеевич', 'ASU_staff'),
('asu3', 'asu3pass', 'Морозова Елена Владимировна', 'ASU_staff'),
('asu4', 'asu4pass', 'Николаев Андрей Игоревич', 'ASU_staff'),
-- Клиенты
('client1', 'clientpass1', 'Абрамова Ольга Дмитриевна', 'Client'),
('client2', 'clientpass2', 'Белов Алексей Викторович', 'Client'),
('client3', 'clientpass3', 'Волкова Ирина Сергеевна', 'Client'),
('client4', 'clientpass4', 'Григорьев Павел Александрович', 'Client'),
('client5', 'clientpass5', 'Дмитриева Светлана Олеговна', 'Client'),
('client6', 'clientpass6', 'Егоров Артем Николаевич', 'Client'),
('client7', 'clientpass7', 'Жукова Марина Вадимовна', 'Client'),
('client8', 'clientpass8', 'Зайцев Константин Игоревич', 'Client'),
('client9', 'clientpass9', 'Ильина Татьяна Борисовна', 'Client'),
('client10', 'clientpass10', 'Ковалев Михаил Юрьевич', 'Client'),
('client11', 'clientpass11', 'Лебедева Наталья Геннадьевна', 'Client'),
('client12', 'clientpass12', 'Миронов Сергей Васильевич', 'Client'),
('client13', 'clientpass13', 'Новикова Екатерина Алексеевна', 'Client'),
('client14', 'clientpass14', 'Орлов Денис Петрович', 'Client');

-- Данные Requests
INSERT INTO Requests (client_id, content, status_id, assigned_to, closed_at) VALUES
-- Новые заявки (status_id = 1)
(7, 'Не работает принтер в кабинете 305', 1, NULL, NULL),
(8, 'Требуется установка ПО на новый компьютер', 1, NULL, NULL),
(9, 'Проблемы с доступом к корпоративной почте', 1, NULL, NULL),
(10, 'Не запускается специализированное ПО', 1, NULL, NULL),
-- Принятые заявки (status_id = 2)
(11, 'Зависает система при работе с большими файлами', 2, 3, NULL),
(12, 'Требуется замена монитора', 2, 4, NULL),
(13, 'Настройка VPN для удаленной работы', 2, 5, NULL),
(14, 'Проблемы с доступом к сетевому диску', 2, 6, NULL),
(7, 'Не работает сканер в отделе бухгалтерии', 2, 3, NULL),
(8, 'Требуется обновление антивирусного ПО', 2, 4, NULL),
-- Закрытые заявки (status_id = 3)
(9, 'Восстановление удаленных файлов', 3, 5, '2023-05-15 14:30:00'),
(10, 'Настройка почтового клиента', 3, 6, '2023-05-16 10:15:00'),
(11, 'Ремонт системного блока', 3, 3, '2023-05-17 16:45:00'),
(12, 'Установка дополнительного ПО', 3, 4, '2023-05-18 11:20:00'),
(13, 'Проблемы с интернет-соединением', 3, 5, '2023-05-19 09:30:00'),
(14, 'Настройка доступа к базе данных', 3, 6, '2023-05-20 13:10:00'),
(7, 'Замена клавиатуры', 3, 3, '2023-05-21 15:00:00'),
(8, 'Консультация по работе с Excel', 3, 4, '2023-05-22 12:45:00'),
(9, 'Устранение вирусной атаки', 3, 5, '2023-05-23 14:20:00'),
(10, 'Настройка резервного копирования', 3, 6, '2023-05-24 10:30:00');