/* Table User */

create table Userr(
	id int primary key identity(1,1),
	first_name varchar(50),
	last_name varchar(50),
	email varchar(50) unique , 
	phone_number varchar(20),
	password varchar(50),
	birthday varchar(15),
	gender varchar(15),
	block BIT DEFAULT 0
);

/* Table personal_info*/
create table Personal_info(
	id int primary key identity(1,1),
	first_name varchar(50),
	last_name varchar(50),
	email varchar(50) unique , 
	phone_number varchar(20),
	birthday varchar(15),
	profession varchar(50),
	address text,
	user_id int FOREIGN KEY REFERENCES Userr(id)
)

/*Table summary*/
create table Summary(
	id int primary key identity(1,1),
	description text,
	user_id int FOREIGN KEY REFERENCES Userr(id)
)

/* Table experience*/
create table Experience(
	id int primary key identity(1,1),
	position varchar(30),
	company varchar(30),
	date_from date,
	date_to date ,
	description text,
	user_id int FOREIGN KEY REFERENCES Userr(id)
)

/* Table education */
create table Education(
	id int primary key identity(1,1),
	school_name varchar(50),
	description text,
	date_from date ,
	date_to date,
	user_id int FOREIGN KEY REFERENCES Userr(id)
)

/* Table skills*/
create table Skill(
	id int primary key identity(1,1),
	skill_nam varchar(30),
	user_id int FOREIGN KEY REFERENCES Userr(id)

)

/* Table language*/
create table Language(
	id int primary key identity(1,1),
	language_name varchar(15),
	mastery varchar(15),
	user_id int FOREIGN KEY REFERENCES Userr(id)
)

/* Table Courses */
create table Course(
	id int primary key identity(1,1),
	name varchar(50),
	date_from date ,
	date_to date,
	user_id int FOREIGN KEY REFERENCES Userr(id)
)

/* Table certificates */
create table Certificate(
	id int primary key identity(1,1),
	title varchar(50),
	date_from date ,
	date_to date,
	user_id int FOREIGN KEY REFERENCES Userr(id)
)