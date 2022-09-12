CREATE TABLE CartTable
(
	CartId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	UserId INT NOT NULL
	FOREIGN KEY (UserId) REFERENCES Users(Id),
	BookId INT NOT NULL
	FOREIGN KEY (BookId) REFERENCES BookTable(bookId),	
	Quantity INT Not Null
);

select * from Users

ALTER TABLE CartTable
DROP COLUMN Quantity; 

ALTER TABLE CartTable
ADD Quantity int default 1;
-------------------------Add cart-store procedure----------------------------

Create or ALTER procedure [dbo].[Sp_AddCart]
(
@UserId int,@BookId int,@Quantity int
)
as
begin
IF (EXISTS(SELECT * FROM BookTable WHERE bookId=@BookId))		
	begin
		INSERT INTO CartTable(UserId,BookId)
		VALUES (@UserId,@BookId)
	end
	else
	begin 
		select 2
	end
SET NOCOUNT ON;
END
-----------------------------Delete cart------------------------
Create or ALTER procedure [dbo].[Sp_DeleteCart]
(
@CartId int
)
as
begin
delete from CartTable where CartId=@CartId
select * from CartTable
SET NOCOUNT ON;
END

-----------------------Update cart-----------------------------
Create or ALTER procedure [dbo].[Sp_UpdateCart]
(@CartId int,
@BookId int,@UserId int,@Quantity int
)
as
begin
update CartTable set BookId=@BookId,Userid=@UserId,Quantity=@Quantity where CartId=@CartId
select * from CartTable
SET NOCOUNT ON;
END

--------------------------Getcart----------------------------
Create or ALTER procedure [dbo].[Sp_RetriveCart]
(@UserId int
)
as
begin
select * from CartTable where UserId=@UserId;
SET NOCOUNT ON;
END