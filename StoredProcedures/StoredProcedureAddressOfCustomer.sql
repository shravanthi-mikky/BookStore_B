
create table AddressType
(
    TypeId int IDENTITY(1,1) PRIMARY KEY,
	Type varchar(200)
);

select * from AddressType

create table Addresses
(
    AddressId int IDENTITY(1,1) PRIMARY KEY,
	Address varchar(max),
	City varchar(100),
	State varchar(100),
	Type int FOREIGN KEY (Type) REFERENCES AddressType(TypeId),
	UserId INT NOT NULL FOREIGN KEY (UserId) REFERENCES Users(Id),
	--Fullname varchar(200) foreign key (Fullname) References Users(Fullname)
);
select * from Addresses

insert into AddressType values('Home');
insert into AddressType values('Office');
insert into AddressType values('Other');

----------------------Add Address Store procedure-------------------

create or ALTER procedure [dbo].[SpAddress]
(
	--@AddressId int ,
	@Address varchar(600),@City varchar(200),@State varchar(200),@Type varchar(200),@UserId int
)
as
begin
	IF (EXISTS(SELECT * FROM Users WHERE @UserId = @UserId))
	Begin
	insert into Addresses values(@Address,@City,@State,@Type,@UserId);
	End
	Else
	Begin
		Select 1
	End
END

----------
-----------------------------Update address--------------------
create or ALTER PROCEDURE [dbo].[Sp_UpdateAddress]
	@AddressId int,
	@Address varchar(200),@City varchar(200),@State varchar(200),@Type int
AS
BEGIN
  If (exists(Select * from Addresses where AddressId=@AddressId))
		begin
			
update Addresses set Address=@Address,City=@City,State=@State,Type=@Type where AddressId=@AddressId
		 end
		 else
		 begin
		 select 1;
		 end
SELECT * from Addresses
END
-----------------------------Get all Address--------------------
create or ALTER PROCEDURE [dbo].[Sp_GetUserAddress]
AS
BEGIN
	SELECT * from Addresses
END

update Addresses set UserId = 2 where AddressId=2

------------------------get address by userid--------------------
create or alter PROCEDURE [dbo].[Sp_GetUserAddressById]
(@UserId int
)
AS
BEGIN
	SELECT * from Addresses where UserId=@UserId
END

-----Get Address details and user details ---------------

create or alter PROCEDURE [dbo].[Sp_GetUserAllAddress]
AS
BEGIN
SELECT p.AddressId, p.Address,p.City,p.state,p.Type,p.UserId,
       s.Fullname,s.Mobile
FROM Addresses AS p
INNER JOIN Users AS s ON p.UserId=s.Id where UserId = 1;
END

Delete from Addresses where AddressId = 8

