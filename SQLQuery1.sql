create database BooksDb

use BooksDb

--Author-AuthorID,AuhorName

create table tbl_Author
(
AuthorID int identity(1,1),
AuthorName varchar(20),
constraint PK_auth primary key (AuthorID)
)

select * from tbl_Author

--drop table tbl_author
--Books-BookID,Title,AuthorID,Price

create table tbl_Books
(
BookID int identity(1000,1),
Title varchar(50),
AuthorID int,
Price money,
constraint PK_book primary key (BookID),
constraint FK_auth foreign key(AuthorID)
references tbl_author(AuthorID)
)

--drop table tbl_Books
select * from tbl_Books

--insertbooks
create proc sp_INSBooks
@Title varchar(20),
@AuthorID int,
@Price money
as
Begin
insert tbl_Books
values(@Title,@AuthorID,@Price)
end

--insert authors

create proc sp_INSAuthor
@AuthorName varchar(50)
as
Begin
insert tbl_Author
values(@AuthorName)
end

--update Author Name

create proc sp_UpdateAuthor
@AuthorID int,
@AuthorName varchar(50)
as
Begin
Update tbl_Author set AuthorName=@AuthorName where AuthorID=@AuthorID
end

--update Book Price

create proc sp_UpdateBooks
@BookID int,
@Price money
as
Begin
Update tbl_Books set Price=@Price where BookID=@BookID
end

--Delete Book using id
create proc sp_DeleteBooks
@BookID int
as
Begin
delete from tbl_Books where BookID=@BookID
end

--delete Author using id

create proc sp_DeleteAuthor
@AuthorID int
as
Begin
delete from tbl_Author where AuthorID=@AuthorID
end
