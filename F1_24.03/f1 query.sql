/*. Таблица: Teams (Отбори)
Тази таблица ще съдържа информация за отборите в Формула 1.
Поле	Тип на данните	Описание
team_id	INT, PRIMARY KEY	Уникален идентификатор на отбора
team_name	VARCHAR(255)	Име на отбора (например, "Mercedes", "Ferrari")
country	VARCHAR(100)	Страна на отбора (например, "Germany", "Italy")
foundation_year	INT	Година на създаване на отбора
2. Таблица: Drivers (Пилоти)
Тази таблица ще съдържа информация за пилотите.
Поле	Тип на данните	Описание
driver_id	INT, PRIMARY KEY	Уникален идентификатор на пилота
first_name	VARCHAR(100)	Първо име на пилота
last_name	VARCHAR(100)	Фамилия на пилота
birth_date	DATE	Дата на раждане на пилота
nationality	VARCHAR(100)	Националност на пилота
team_id	INT, FOREIGN KEY	Идентификатор на отбора, за който кара пилотът (връзка към Teams)
3. Таблица: Races (Състезания)
Тази таблица ще съдържа информация за състезанията.
Поле	Тип на данните	Описание
race_id	INT, PRIMARY KEY	Уникален идентификатор на състезанието
race_name	VARCHAR(255)	Име на състезанието
location	VARCHAR(255)	Местоположение на състезанието
race_date	DATE	Дата на състезанието
season_year	INT	Година на сезона

4. Таблица: Race_Results (Резултати от състезания)
Тази таблица ще съдържа резултатите от състезанията.
Поле	Тип на данните	Описание
result_id	INT, PRIMARY KEY	Уникален идентификатор на резултата
race_id	INT, FOREIGN KEY	Идентификатор на състезанието (връзка към Races)
driver_id	INT, FOREIGN KEY	Идентификатор на пилота (връзка към Drivers)
position	INT	Позиция, на която е завършил пилотът
points	DECIMAL(5, 2)	Точки, получени от пилота за състезанието
laps	INT	Брой обиколки, завършени от пилота
time	TIME	Време, за което пилотът завършва състезанието
*/

--create database F1
use F1

/*
Таблица: Teams (Отбори)
Тази таблица ще съдържа информация за отборите в Формула 1.
Поле	Тип на данните	Описание
team_id	INT, PRIMARY KEY	Уникален идентификатор на отбора
team_name	VARCHAR(255)	Име на отбора (например, "Mercedes", "Ferrari")
country	VARCHAR(100)	Страна на отбора (например, "Germany", "Italy")
foundation_year	INT	Година на създаване на отбора
*/
create table Teams
(
	team_id int primary key identity,
	team_name varchar(255),
	country varchar(100),
	foundation_year int
)

/*
2. Таблица: Drivers (Пилоти)
Тази таблица ще съдържа информация за пилотите.
Поле	Тип на данните	Описание
driver_id	INT, PRIMARY KEY	Уникален идентификатор на пилота
first_name	VARCHAR(100)	Първо име на пилота
last_name	VARCHAR(100)	Фамилия на пилота
birth_date	DATE	Дата на раждане на пилота
nationality	VARCHAR(100)	Националност на пилота
team_id	INT, FOREIGN KEY	Идентификатор на отбора, за който кара пилотът (връзка към Teams)
*/
create table Drivers
(
	driver_id int primary key identity,
	first_name varchar(100),
	last_name varchar(100),
	birth_date date,
	nationality varchar(100),
	team_id int references Teams(team_id)
)

/*
3. Таблица: Races (Състезания)
Тази таблица ще съдържа информация за състезанията.
Поле	Тип на данните	Описание
race_id	INT, PRIMARY KEY	Уникален идентификатор на състезанието
race_name	VARCHAR(255)	Име на състезанието
location	VARCHAR(255)	Местоположение на състезанието
race_date	DATE	Дата на състезанието
season_year	INT	Година на сезона
*/
create table Races
(
	race_id int primary key identity,
	race_name varchar(100),
	[location] varchar(100),
	race_date date,
	season_year int
)

/*
4. Таблица: Race_Results (Резултати от състезания)
Тази таблица ще съдържа резултатите от състезанията.
Поле	Тип на данните	Описание
result_id	INT, PRIMARY KEY	Уникален идентификатор на резултата
race_id	INT, FOREIGN KEY	Идентификатор на състезанието (връзка към Races)
driver_id	INT, FOREIGN KEY	Идентификатор на пилота (връзка към Drivers)
position	INT	Позиция, на която е завършил пилотът
points	DECIMAL(5, 2)	Точки, получени от пилота за състезанието
laps	INT	Брой обиколки, завършени от пилота
time	TIME	Време, за което пилотът завършва състезанието
*/
create table Race_Results
(
	result_id int primary key identity,
	race_id int references Races(race_id),
	driver_id int references Drivers(driver_id),
	position int,
	points decimal(5,2),
	laps int,
	[time] time
)



INSERT INTO Teams (team_name, country, foundation_year) VALUES
('Mercedes', 'Germany', 1926),
('Ferrari', 'Italy', 1929),
('Red Bull Racing', 'Austria', 2005),
('McLaren', 'United Kingdom', 1963);

INSERT INTO Drivers (first_name, last_name, birth_date, nationality, team_id) VALUES
('Lewis', 'Hamilton', '1985-01-07', 'British', 1),
('Sebastian', 'Vettel', '1987-07-03', 'German', 2),
('Max', 'Verstappen', '1997-09-30', 'Dutch', 3),
('Lando', 'Norris', '1999-11-13', 'British', 4);

INSERT INTO Races (race_name, [location], race_date, season_year) VALUES
('Australian Grand Prix', 'Melbourne', '2023-03-31', 2023),
('Bahrain Grand Prix', 'Sakhir', '2023-04-07', 2023),
('Monaco Grand Prix', 'Monaco', '2023-05-28', 2023),
('Canadian Grand Prix', 'Montreal', '2023-06-11', 2023);

INSERT INTO Race_Results (race_id, driver_id, position, points, laps, [time]) VALUES
(1, 1, 1, 25.00, 58, '1:31:21.000'),
(1, 2, 2, 18.00, 58, '1:31:25.000'),
(2, 3, 1, 25.00, 57, '1:31:10.000'),
(3, 1, 1, 25.00, 78, '1:42:15.000');