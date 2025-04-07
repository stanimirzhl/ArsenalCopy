/*. Medicines (Лекарства)
•	id (INT, PRIMARY KEY, IDENTITY) – идентификатор на лекарството
•	name (VARCHAR(100), UNIQUE) – име на лекарството
•	manufacturer (VARCHAR(100), NOT NULL) – производител
•	price (DECIMAL(10,2), NOT NULL) – цена
•	quantity_in_stock (INT, NOT NULL) – наличност
2. Prescriptions (Рецепти)
•	id (INT, PRIMARY KEY, IDENTITY) – идентификатор на рецептата
•	medicine_id (INT, FOREIGN KEY → Medicines) – предписано лекарство
•	doctor_name (VARCHAR(100) , NOT NULL) – име на лекаря
•	patient_name (VARCHAR(100) , NOT NULL) – име на пациента
•	date_issued (DATE, NOT NULL) – дата на издаване
•	employee_id (INT, FOREIGN KEY → Employees) – фармацевт, обработил рецептата
3. Orders (Поръчки)
•	id (INT, PRIMARY KEY, IDENTITY) – идентификатор на поръчката
•	medicine_id (INT, FOREIGN KEY → Medicines) – лекарство в поръчката
•	supplier_name (VARCHAR(100) , NOT NULL) – доставчик
•	order_date (DATE, NOT NULL) – дата на поръчката
•	quantity_ordered (INT, NOT NULL) – поръчано количество
•	employee_id (INT, FOREIGN KEY → Employees) – служител, обработил поръчката
4. Employees (Служители)
•	id (INT, PRIMARY KEY, IDENTITY) – идентификатор на служителя
•	name (VARCHAR(100)) – име на служителя
•	position (VARCHAR(50)) – длъжност (фармацевт, касиер, управител)
•	salary (DECIMAL(10,2)) – заплата
*/

create database PharmacyDB
use PharmacyDB

/*. Medicines (Лекарства)
•	id (INT, PRIMARY KEY, IDENTITY) – идентификатор на лекарството
•	name (VARCHAR(100), UNIQUE) – име на лекарството
•	manufacturer (VARCHAR(100), NOT NULL) – производител
•	price (DECIMAL(10,2), NOT NULL) – цена
•	quantity_in_stock (INT, NOT NULL) – наличност
*/

create table Medicines
(
	id int primary key identity,
	[name] varchar(100) unique,
	manufacturer varchar(100) not null,
	price decimal(10,2) not null,
	quantity_in_stock int not null
)

/*4. Employees (Служители)
•	id (INT, PRIMARY KEY, IDENTITY) – идентификатор на служителя
•	name (VARCHAR(100)) – име на служителя
•	position (VARCHAR(50)) – длъжност (фармацевт, касиер, управител)
•	salary (DECIMAL(10,2)) – заплата
*/
create table Employees
(
	id int primary key identity,
	[name] varchar(100),
	position varchar(50),
	salary decimal(10,2)
)


/*2. Prescriptions (Рецепти)
•	id (INT, PRIMARY KEY, IDENTITY) – идентификатор на рецептата
•	medicine_id (INT, FOREIGN KEY → Medicines) – предписано лекарство
•	doctor_name (VARCHAR(100) , NOT NULL) – име на лекаря
•	patient_name (VARCHAR(100) , NOT NULL) – име на пациента
•	date_issued (DATE, NOT NULL) – дата на издаване
•	employee_id (INT, FOREIGN KEY → Employees) – фармацевт, обработил рецептата
*/
create table Prescriptions
(
	id int primary key identity,
	medicine_id int references Medicines(id),
	doctor_name varchar(100) not null,
	patient_name varchar(100) not null,
	date_issued date not null,
	employee_id int references Employees(id)
)

/*3. Orders (Поръчки)
•	id (INT, PRIMARY KEY, IDENTITY) – идентификатор на поръчката
•	medicine_id (INT, FOREIGN KEY → Medicines) – лекарство в поръчката
•	supplier_name (VARCHAR(100) , NOT NULL) – доставчик
•	order_date (DATE, NOT NULL) – дата на поръчката
•	quantity_ordered (INT, NOT NULL) – поръчано количество
•	employee_id (INT, FOREIGN KEY → Employees) – служител, обработил поръчката
*/

create table Orders
(
	id int primary key identity,
	medicine_id int references Medicines(id),
	supplier_name varchar(100) not null,
	order_date date not null,
	quantity_ordered int not null,
	employee_id int references Employees(id)
)



INSERT INTO Employees (name, position, salary) VALUES
('Elena Petrova', 'Pharmacist', 2500.00),
('Ivan Ivanov', 'Cashier', 1200.00),
('Mihail Hristov', 'Manager', 3500.00);

INSERT INTO Medicines (name, manufacturer, price, quantity_in_stock) VALUES
('Paracetamol', 'Bayer', 5.50, 100),
('Ibuprofen', 'Pfizer', 8.20, 150),
('Aspirin', 'Novartis', 4.75, 200);

INSERT INTO Prescriptions (medicine_id, doctor_name, patient_name, date_issued, employee_id) VALUES
(1, 'Dr. Ivan Petrov', 'Georgi Dimitrov', '2025-03-10', 1),
(2, 'Dr. Maria Nikolova', 'Anna Ivanova', '2025-03-12', 1),
(3, 'Dr. Peter Stoyanov', 'Nikolay Georgiev', '2025-03-14', 2);

INSERT INTO Orders (medicine_id, supplier_name, order_date, quantity_ordered, employee_id) VALUES
(1, 'PharmaSupply Ltd.', '2025-03-01', 500, 3),
(2, 'MedExpress', '2025-03-05', 300, 3),
(3, 'GlobalPharm', '2025-03-08', 400, 2);
