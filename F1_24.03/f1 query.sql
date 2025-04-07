/*. �������: Teams (������)
���� ������� �� ������� ���������� �� �������� � ������� 1.
����	��� �� �������	��������
team_id	INT, PRIMARY KEY	�������� ������������� �� ������
team_name	VARCHAR(255)	��� �� ������ (��������, "Mercedes", "Ferrari")
country	VARCHAR(100)	������ �� ������ (��������, "Germany", "Italy")
foundation_year	INT	������ �� ��������� �� ������
2. �������: Drivers (������)
���� ������� �� ������� ���������� �� ��������.
����	��� �� �������	��������
driver_id	INT, PRIMARY KEY	�������� ������������� �� ������
first_name	VARCHAR(100)	����� ��� �� ������
last_name	VARCHAR(100)	������� �� ������
birth_date	DATE	���� �� ������� �� ������
nationality	VARCHAR(100)	������������ �� ������
team_id	INT, FOREIGN KEY	������������� �� ������, �� ����� ���� ������� (������ ��� Teams)
3. �������: Races (����������)
���� ������� �� ������� ���������� �� ������������.
����	��� �� �������	��������
race_id	INT, PRIMARY KEY	�������� ������������� �� ������������
race_name	VARCHAR(255)	��� �� ������������
location	VARCHAR(255)	�������������� �� ������������
race_date	DATE	���� �� ������������
season_year	INT	������ �� ������

4. �������: Race_Results (��������� �� ����������)
���� ������� �� ������� ����������� �� ������������.
����	��� �� �������	��������
result_id	INT, PRIMARY KEY	�������� ������������� �� ���������
race_id	INT, FOREIGN KEY	������������� �� ������������ (������ ��� Races)
driver_id	INT, FOREIGN KEY	������������� �� ������ (������ ��� Drivers)
position	INT	�������, �� ����� � �������� �������
points	DECIMAL(5, 2)	�����, �������� �� ������ �� ������������
laps	INT	���� ��������, ��������� �� ������
time	TIME	�����, �� ����� ������� �������� ������������
*/

--create database F1
use F1

/*
�������: Teams (������)
���� ������� �� ������� ���������� �� �������� � ������� 1.
����	��� �� �������	��������
team_id	INT, PRIMARY KEY	�������� ������������� �� ������
team_name	VARCHAR(255)	��� �� ������ (��������, "Mercedes", "Ferrari")
country	VARCHAR(100)	������ �� ������ (��������, "Germany", "Italy")
foundation_year	INT	������ �� ��������� �� ������
*/
create table Teams
(
	team_id int primary key identity,
	team_name varchar(255),
	country varchar(100),
	foundation_year int
)

/*
2. �������: Drivers (������)
���� ������� �� ������� ���������� �� ��������.
����	��� �� �������	��������
driver_id	INT, PRIMARY KEY	�������� ������������� �� ������
first_name	VARCHAR(100)	����� ��� �� ������
last_name	VARCHAR(100)	������� �� ������
birth_date	DATE	���� �� ������� �� ������
nationality	VARCHAR(100)	������������ �� ������
team_id	INT, FOREIGN KEY	������������� �� ������, �� ����� ���� ������� (������ ��� Teams)
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
3. �������: Races (����������)
���� ������� �� ������� ���������� �� ������������.
����	��� �� �������	��������
race_id	INT, PRIMARY KEY	�������� ������������� �� ������������
race_name	VARCHAR(255)	��� �� ������������
location	VARCHAR(255)	�������������� �� ������������
race_date	DATE	���� �� ������������
season_year	INT	������ �� ������
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
4. �������: Race_Results (��������� �� ����������)
���� ������� �� ������� ����������� �� ������������.
����	��� �� �������	��������
result_id	INT, PRIMARY KEY	�������� ������������� �� ���������
race_id	INT, FOREIGN KEY	������������� �� ������������ (������ ��� Races)
driver_id	INT, FOREIGN KEY	������������� �� ������ (������ ��� Drivers)
position	INT	�������, �� ����� � �������� �������
points	DECIMAL(5, 2)	�����, �������� �� ������ �� ������������
laps	INT	���� ��������, ��������� �� ������
time	TIME	�����, �� ����� ������� �������� ������������
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