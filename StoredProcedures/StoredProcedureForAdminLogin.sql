use BookStore

------create admin table-------------
CREATE TABLE AdminTable(
	AdminId int Identity(1,1) PRIMARY KEY,
	AdminName varchar (200),
	AdminEmail varchar (100),
	AdminPassword varchar(150),
	AdminMobile Bigint,
	Address varchar(150)
	);

select * from AdminTable

Insert into AdminTable values('Shravanthi','shravanthi@gmail.com','Shravanthi@123',1234567890,'Old Alwal');

---------SP for AdminLogin-----------------
create or ALTER procedure [dbo].[SP_AdminLogin]
(
	@AdminEmail varchar(200),
	@AdminPassword varchar(100)
)
as
begin
select * from AdminTable where AdminEmail=@AdminEmail and AdminPassword=@AdminPassword

END