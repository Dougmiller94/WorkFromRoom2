create database notes_db;
use notes_db;
create table Weapons (
id int primary key auto_increment not null,
Weapon_name varchar(30));


select * from Note;

-- drop table Note;
create table Note (
id int primary key auto_increment not null,
text varchar(30),
notebookId int, 
foreign key(NoteBookId) references NoteBook(id));


select * from Note;

create table NoteBook (
id int primary key auto_increment not null,
Title varchar (30));


select * from NoteBook;


