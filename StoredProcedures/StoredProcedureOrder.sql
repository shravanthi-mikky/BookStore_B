
create table OrderTable(
OrdersId int identity(1,1) not null primary key,
UserId int FOREIGN KEY (UserId) REFERENCES Users(Id),
BookId int FOREIGN KEY (BookId) REFERENCES BookTable(bookId),
AddressId int FOREIGN KEY (AddressId) REFERENCES Addresses(AddressId),
TotalPrice int,
BookQuantity int,
OrderDate Date);

Select * from OrderTable


---------Add Orders------------------

Create or ALTER PROCEDURE [dbo].[Sp_AddOrder]
	@UserId INT,
	@AddressId int,
	@BookId INT ,
	@BookQuantity int
AS
	Declare @TotPrice int
BEGIN
Select @TotPrice=discountprice from BookTable where BookId = @BookId;
	IF (EXISTS(SELECT * FROM BookTable WHERE bookId = @BookId))
	begin
		IF (EXISTS(SELECT * FROM Users WHERE Id = @UserId))
		Begin
		Begin try
			Begin transaction			
				INSERT INTO OrderTable(UserId,AddressId,BookId,Totalprice,BookQuantity,OrderDate)
				VALUES ( @UserId,@AddressId,@BookId,@BookQuantity*@TotPrice,@BookQuantity,GETDATE())
				Update BookTable set BookCount=BookCount-@BookQuantity
				Delete from CartTable where BookId = @BookId and UserId = @UserId
				select * from OrderTable
			commit Transaction
		End try
		Begin catch
			Rollback transaction
		End catch
		end
		Else
		begin
			Select 1
		end
	end 
	Else
	begin
			Select 2
	end	
END

--------------------------

Create or ALTER PROCEDURE [dbo].[Sp_GetOrderById]
@UserId INT
as
begin
select 
		BookTable.bookId,BookTable.bookName,BookTable.AuthorName,BookTable.DiscountPrice,BookTable.OriginalPrice,BookTable.bookImage,OrderTable.OrdersId
		--OrderTable.OrderDate
		FROM BookTable
		inner join OrderTable
		on OrderTable.BookId=BookTable.bookId where OrderTable.UserId=@UserId
SET NOCOUNT ON;
END

Select * from Users

Select * from AdminTable