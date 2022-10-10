


Create table WishList
(
	WishListId int identity(1,1) not null primary key,
	UserId int foreign key references Users(Id) on delete no action,
	BookId int foreign key references BookTable(bookId) on delete no action
);

Select * from WishList

Insert into WishList values(1,6)



----------- Store procedure for add wishlist ----------
create procedure AddWishList
(
@UserId int,
@BookId int
)
as
begin 
       insert into WishList
	   values (@UserId,@BookId);
end;

------------- Store procedure for Delete wishlist ----------------
create or alter procedure DeleteWishList
(
@WishListId int
)
as
begin
delete WishList where WishListId = @WishListId;
end;

delete WishList where WishListId = 7;

select * from Users
select * from BookTable
select * from CartTable



update BookTable set bookName='React Material UI',authorName='Steve Krug' where bookId=1
update BookTable set bookImage='image2.png' where bookId=2

Insert into BookTable values('Group Discussion','Steve Krug',4.2,15,1100,1500,'Group Discussion or GD is a type of discussion that involves people sharing ideas or activities.','GroupDiscussion.png',50)

Insert into BookTable values('Group Discussion','Steve Krug',4.2,15,1100,1500,'Group Discussion or GD is a type of discussion that involves people sharing ideas or activities.','GroupDiscussion.png',50)
Insert into BookTable values('Lean UX','Steve Krug',4.2,15,1100,1500,'Inspired by Lean and Agile development theories, Lean UX lets you focus on the actual experience.','LeanUX.png',50)
Insert into BookTable values('SharePoint Framework ','Steve Krug',4.2,15,1100,1500,'This book presents the SharePoint Framework concept with a practical approach and real-world examples.','SharePointFramework.png',50)
Insert into BookTable values('The Design Of Everyday Things','Steve Krug',4.2,15,1100,1400,'The Design of Everyday Things is a best-selling book by cognitive scientist','TheDesignOfEverydayThings.png',50)
Insert into BookTable values('UX Design','Steve Krug',4.5,15,1100,1800,'A Project Guide to UX Design: For User Experience Designers in the Field.','UX_Design.png',50)

update BookTable set bookName='Everyday Things' where bookId=6


------Stored Procedure for wishlist--------------------Get all With Book Details-----------

Create or ALTER procedure [dbo].[Sp_GetAllWishListItems]
as
begin
SELECT p.bookName, p.authorName,p.originalPrice,p.discountPrice,p.bookImage,
       s.WishListId,s.BookId,s.UserId
FROM BookTable AS p
INNER JOIN WishList AS s ON p.bookId=s.BookId;
SET NOCOUNT ON;
END