use BookStore


create TABLE BookTable(
	bookId int Identity(1,1) PRIMARY KEY,
	bookName varchar(200),
	authorName varchar(200),
    rating varchar(200),   
	totalRating int,
	discountPrice int,
	originalPrice int,
	description varchar(255),
	bookImage varchar(200),
	BookCount int not null
	);
select * from BookTable


-------------SP Add Book -------------------

Create or ALTER PROCEDURE Sp_AddBook
@bookName varchar(200),
@authorName varchar(200),@rating varchar(200),@totalRating int,@discountPrice int,
@originalPrice int,@description varchar(255),@bookImage varchar(200),@BookCount int

AS
BEGIN
insert into BookTable(bookName,authorName,rating,totalRating,discountPrice,originalPrice,description,bookImage,BookCount)
values(@bookName,@authorName,@rating,@totalRating,@discountPrice,@originalPrice,@description,@bookImage,@BookCount);
SELECT * from BookTable
END

-------------------------------

create or ALTER PROCEDURE [dbo].[Sp_Delete]
	@bookId int
AS
BEGIN
delete from BookTable where bookId=@bookId

	SELECT * from BookTable
END
---------------------------Update book---------------------
create or ALTER PROCEDURE [dbo].[Sp_Updatebook]
@bookId int,
@bookName varchar(200),
@authorName varchar(200),@rating varchar(200),@totalRating int,@discountPrice int,
@originalPrice int,@description varchar(255),@bookImage varchar(200),@BookCount int
AS
BEGIN
update BookTable set bookName=@bookName,authorName=@authorName,rating=@rating,totalRating=@totalRating,discountPrice=@discountPrice,
originalPrice=@originalPrice,description=@description,bookImage=@bookImage,BookCount=@BookCount where bookId=@bookId
SELECT * from BookTable
END

-------------------------Get all books--------------------------
create or ALTER procedure [dbo].[spGetAll]
as
begin
select * from BookTable
END
----------------------------Get book By id---------------------create or -
create or ALTER procedure [dbo].[Retrive_1_BookDetails]
(
	@bookId int
)
as
begin
select * from BookTable where bookId=@bookId
END


