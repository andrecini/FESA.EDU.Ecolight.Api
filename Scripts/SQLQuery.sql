---------------------------------------------------------------------------------------------------
-- Drops para reinicialização
---------------------------------------------------------------------------------------------------

DROP TABLE Historic
DROP TABLE Sensor
DROP TABLE Settings
DROP TABLE Users
DROP TABLE Device
DROP TABLE Company

---------------------------------------------------------------------------------------------------
-- Criação das Tabelas
---------------------------------------------------------------------------------------------------

CREATE TABLE Company (
      Id INT PRIMARY KEY IDENTITY(1,1),
      Company_Name NVARCHAR(50),
      Cnpj NVARCHAR(14)
)

CREATE TABLE Device (
      Id INT PRIMARY KEY IDENTITY(1,1),
      Device_Name NVARCHAR(50) NOT NULL,
      Verification_Code NVARCHAR(MAX) NOT NULL,
      Lamp_Amount INT NOT NULL,
      Local_Description NVARCHAR(200) NOT NULL,
      Status_Enable INT,      
      Company_Id INT NOT NULL,
      CONSTRAINT Company_Device FOREIGN KEY (Company_Id) REFERENCES Company (Id)
)

CREATE TABLE Users (
      Id INT PRIMARY KEY IDENTITY(1,1),
      Username NVARCHAR(100),
      Email NVARCHAR(50),
      User_Password NVARCHAR(MAX),
      Number NVARCHAR(14),
      Cpf NVARCHAR(11),
      Uf INT,
      User_Role INT,
      Active INT,
      Company_Id INT NOT NULL,
      CONSTRAINT Company_Users FOREIGN KEY (Company_Id) REFERENCES Company (Id)
)

CREATE TABLE Settings (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Settings_Name NVARCHAR(255),
    Settings_Description NVARCHAR(MAX),
    OnDate TIME(7),
    OffDate Time(7),
    Brightness INT,
    Settings_Enable BIT,
    Device_Id INT,
    CONSTRAINT Device_Settings FOREIGN KEY (Device_Id) REFERENCES Device (Id)
)

CREATE TABLE Sensor (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Sensor_Type INT, -- Suponhamos que SensorTypes seja um enum representado como um inteiro
    Unity INT, -- Suponhamos que SensorUnities seja um enum representado como um inteiro
    Reads FLOAT,
    ReadDate DATETIME,
    Device_Id INT
    CONSTRAINT Device_Sensor FOREIGN KEY (Device_Id) REFERENCES Device (Id)
);

CREATE TABLE Historic (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Historic_Date DATETIME,
    Historic_Description NVARCHAR(MAX),
    Historic_Status INT,
    Device_Id INT,
    Company_Id int,
    CONSTRAINT Device_Historic FOREIGN KEY (Device_Id) REFERENCES Device (Id),
    CONSTRAINT Company_Historic FOREIGN KEY (Company_Id) REFERENCES Company (Id)
);

---------------------------------------------------------------------------------------------------
-- Inserts Iniciais
---------------------------------------------------------------------------------------------------

INSERT INTO Company (Company_Name, Cnpj) 
VALUES
('Empresa Alpha', '12345678000199'),
('Beta Soluções', '23456789000188'),
('Gamma Tecnologia', '34567890000177'),
('Delta Serviços', '45678901000166'),
('Epsilon Indústria', '56789012000155');

SELECT * FROM Company;

---------------------------------------------------------------------------------------------------

INSERT INTO Device (Device_Name, Verification_Code, Lamp_Amount, Local_Description, Status_Enable, Company_Id) 
VALUES
('Sensor Luminoso A1', 'ABC123XYZ789A1', 5, 'Área de recepção principal.', 1, 1),
('Controlador Temperatura B2', 'DEF456UVW789B2', 3, 'Sala de controle central.', 1, 2),
('Monitoramento Câmeras C3', 'GHI789RST789C3', 8, 'Sistema de segurança do perímetro.', 0, 3),
('Regulador Umidade D4', 'JKL012MNO789D4', 4, 'Estufa de plantas do lobby.', 1, 4),
('Sistema Automação E5', 'MNO345PQR789E5', 10, 'Sistema integrado de gerenciamento do edifício.', 1, 5);

SELECT * FROM Device;

---------------------------------------------------------------------------------------------------

INSERT INTO Users (Username, Email, User_Password, Number, Cpf, Uf, User_Role, Active, Company_Id) 
VALUES
('André Cini', 'andre@teste.com', '69pVtpPYpAJhYvLNcyRc1MFX6j6cAknSTf0BmJOb5gY=', '11987654321', '12345678901', 35, 1, 1, 1),
('Murilo Tinari', 'murilo@teste.com', '69pVtpPYpAJhYvLNcyRc1MFX6j6cAknSTf0BmJOb5gY=', '21987654321', '23456789012', 31, 2, 1, 2),
('Gustavo Peterlini', 'gustavo@teste.com', '69pVtpPYpAJhYvLNcyRc1MFX6j6cAknSTf0BmJOb5gY=', '31987654321', '34567890123', 42, 1, 1, 3),
('Lucas Leite', 'lucas@teste.com', '69pVtpPYpAJhYvLNcyRc1MFX6j6cAknSTf0BmJOb5gY=', '41987654321', '45678901234', 13, 1, 1, 4),
('Admin', 'admin@teste.com', '69pVtpPYpAJhYvLNcyRc1MFX6j6cAknSTf0BmJOb5gY=', '51987654321', '56789012345', 27, 1, 1, 5);

SELECT * FROM Users;

---------------------------------------------------------------------------------------------------

INSERT INTO Settings (Settings_Name, Settings_Description, OnDate, OffDate, Brightness, Settings_Enable, Device_Id) VALUES
-- Settings for Device 1
('Config 1.1', 'Configuração de luminosidade para a manhã.', '08:00:00', '12:00:00', 75, 1, 1),
('Config 1.2', 'Configuração de luminosidade para a tarde.', '12:00:00', '18:00:00', 85, 1, 1),
('Config 1.3', 'Configuração de luminosidade para a noite.', '18:00:00', '23:00:00', 60, 1, 1),
('Config 1.4', 'Configuração de luminosidade para a madrugada.', '23:00:00', '05:00:00', 30, 0, 1),
('Config 1.5', 'Configuração de luminosidade para o amanhecer.', '05:00:00', '08:00:00', 50, 1, 1),

-- Settings for Device 2
('Config 2.1', 'Configuração de temperatura para a manhã.', '07:00:00', '11:00:00', 70, 1, 2),
('Config 2.2', 'Configuração de temperatura para a tarde.', '11:00:00', '17:00:00', 75, 1, 2),
('Config 2.3', 'Configuração de temperatura para a noite.', '17:00:00', '22:00:00', 65, 1, 2),
('Config 2.4', 'Configuração de temperatura para a madrugada.', '22:00:00', '04:00:00', 60, 0, 2),
('Config 2.5', 'Configuração de temperatura para o amanhecer.', '04:00:00', '07:00:00', 68, 1, 2),

-- Settings for Device 3
('Config 3.1', 'Configuração do monitoramento para a manhã.', '06:00:00', '12:00:00', 80, 1, 3),
('Config 3.2', 'Configuração do monitoramento para a tarde.', '12:00:00', '18:00:00', 90, 1, 3),
('Config 3.3', 'Configuração do monitoramento para a noite.', '18:00:00', '00:00:00', 100, 1, 3),
('Config 3.4', 'Configuração do monitoramento para a madrugada.', '00:00:00', '06:00:00', 100, 0, 3),
('Config 3.5', 'Configuração do monitoramento para o amanhecer.', '06:00:00', '08:00:00', 85, 1, 3),

-- Settings for Device 4
('Config 4.1', 'Configuração de umidade para a manhã.', '09:00:00', '13:00:00', 60, 1, 4),
('Config 4.2', 'Configuração de umidade para a tarde.', '13:00:00', '17:00:00', 65, 1, 4),
('Config 4.3', 'Configuração de umidade para a noite.', '17:00:00', '21:00:00', 70, 1, 4),
('Config 4.4', 'Configuração de umidade para a madrugada.', '21:00:00', '05:00:00', 55, 0, 4),
('Config 4.5', 'Configuração de umidade para o amanhecer.', '05:00:00', '09:00:00', 58, 1, 4),

-- Settings for Device 5
('Config 4.1', 'Configuração de umidade para a manhã.', '09:00:00', '13:00:00', 60, 1, 5),
('Config 4.2', 'Configuração de umidade para a tarde.', '13:00:00', '17:00:00', 65, 1, 5),
('Config 4.3', 'Configuração de umidade para a noite.', '17:00:00', '21:00:00', 70, 1, 5),
('Config 4.4', 'Configuração de umidade para a madrugada.', '21:00:00', '05:00:00', 55, 0, 5),
('Config 4.5', 'Configuração de umidade para o amanhecer.', '05:00:00', '09:00:00', 58, 1, 5);

SELECT * FROM Settings;

---------------------------------------------------------------------------------------------------

INSERT INTO Sensor (Sensor_Type, Unity, Reads, ReadDate, Device_Id) VALUES
-- Dados para o dispositivo 1
(1, 1, 25.5, '2023-11-04 08:00:00', 1),
(2, 2, 15.2, '2023-11-04 12:00:00', 1),

-- Dados para o dispositivo 2
(1, 1, 27.8, '2023-11-04 09:00:00', 2),
(2, 2, 14.7, '2023-11-04 13:00:00', 2),

-- Dados para o dispositivo 3
(1, 1, 30.2, '2023-11-04 10:00:00', 3),
(2, 2, 13.5, '2023-11-04 14:00:00', 3),

-- Dados para o dispositivo 4
(1, 1, 28.6, '2023-11-04 11:00:00', 4),
(2, 2, 17.3, '2023-11-04 15:00:00', 4),

-- Dados para o dispositivo 5
(1, 1, 26.1, '2023-11-04 12:00:00', 5),
(2, 2, 18.9, '2023-11-04 16:00:00', 5);

SELECT * FROM Sensor;

---------------------------------------------------------------------------------------------------

INSERT INTO Historic (Historic_Date, Historic_Description, Historic_Status, Device_Id, Company_Id) VALUES
('2023-11-04 08:00:00', 'Ligar', 1, 1, 1),
('2023-11-04 09:00:00', 'Desligar', 0, 1, 1),
('2023-11-04 10:00:00', 'Ligar', 1, 2, 1),
('2023-11-04 11:00:00', 'Desligar', 0, 2, 1),
('2023-11-04 12:00:00', 'Ligar', 1, 1, 1),
('2023-11-04 13:00:00', 'Desligar', 0, 1, 1),
('2023-11-04 14:00:00', 'Ligar', 1, 2, 1),
('2023-11-04 15:00:00', 'Desligar', 0, 2, 1),
('2023-11-04 16:00:00', 'Ligar', 1, 3, 1),
('2023-11-04 17:00:00', 'Desligar', 0, 3, 1),
('2023-11-04 18:00:00', 'Ligar', 1, 4, 1),
('2023-11-04 19:00:00', 'Desligar', 0, 4, 1),
('2023-11-04 20:00:00', 'Ligar', 1, 5, 1),
('2023-11-04 21:00:00', 'Desligar', 0, 5, 1),
('2023-11-04 23:00:00', 'Ligar', 1, 3, 1),
('2023-11-05 00:00:00', 'Desligar', 0, 3, 1),
('2023-11-05 01:00:00', 'Ligar', 1, 4, 1),
('2023-11-05 02:00:00', 'Desligar', 0, 4, 1),
('2023-11-05 03:00:00', 'Ligar', 1, 5, 1),
('2023-11-05 04:00:00', 'Desligar', 0, 5, 1);


SELECT * FROM Historic;

---------------------------------------------------------------------------------------------------
-- Chamadas
---------------------------------------------------------------------------------------------------

-- Settings

-- Buscar todas as automações de uma empresa
SELECT * FROM Settings as S
INNER JOIN Device as D
ON S.Device_Id = D.Id
WHERE D.Company_Id = 1

-- Buscar uma automação por um Id específico
SELECT * FROM Settings as S
WHERE S.Id = 1

-- Cadastrar uma automação
INSERT INTO Settings (Settings_Name, Settings_Description, OnDate, OffDate, Brightness, Settings_Enable, Device_Id) VALUES
('Config 1.6', 'Configuração de luminosidade para a manhã.', '09:00:00', '10:00:00', 75, 1, 1)

-- Atualizar uma automação
UPDATE Settings
SET
    Settings_Name = 'Modo Noturno',
    Settings_Description = 'Configurações para o modo noturno',
    OnDate = '22:00:00',
    OffDate = '06:00:00',
    Brightness = 50,
    Settings_Enable = 1
WHERE
    Id = 6;

-- Historic

SELECT * FROM Historic
WHERE Company_Id = 1
AND Historic_Date BETWEEN 
'2023-11-04 08:00:00.000' AND '2023-11-04 17:00:00.000'
ORDER BY Historic_Date;

SELECT * FROM Historic
WHERE Company_Id = 1
AND Device_Id = 1
AND Historic_Date BETWEEN 
'2023-11-04 08:00:00.000' AND '2023-11-04 17:00:00.000'
ORDER BY Historic_Date;