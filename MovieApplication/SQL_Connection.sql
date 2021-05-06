use pubs;

select * from authors;

create table tblMovie
(id int identity(1,1) primary key,
name varchar(20),
duration float)

select * from tblMovie