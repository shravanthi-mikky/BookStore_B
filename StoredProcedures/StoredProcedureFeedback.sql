
create table Feedback(FeedbackId int identity(1,1) primary key,
UserID int foreign key (Userid) References Users(Id),
BookId int foreign key (bookId) References BookTable(bookId),
Comment varchar(500),
Ratings int);
select * from Feedback;

---Add Feedback-----

Create or alter procedure Sp_AddFeedback
(
@UserId int,@BookId int,@Comment varchar(max),@Ratings int
)
as
Declare @AverageRating int;
Begin
	IF (EXISTS(SELECT * FROM Feedback WHERE BookId = @BookId and UserId=@UserId))
		select 1; --already given feedback--
	Else
	Begin
		IF (EXISTS(SELECT * FROM BookTable WHERE bookId = @BookId))
		Begin
			Begin try
				Begin transaction
					Insert into Feedback values (@UserId,@BookId,@Comment,@Ratings);		
					select @AverageRating=AVG(Ratings) from Feedback where BookId = @BookId;
					Update BookTable set rating=@AverageRating, totalRating=totalRating+1 where bookId = @BookId;
				Commit Transaction
			End Try
			Begin catch
				Rollback transaction
			End catch
		End
		Else
		Begin
			Select 2; 
		End
	End
End

-------Get Feedback---------------------------
Create or alter PROC spGetFeedback
	@BookId INT
AS
BEGIN
	select 
		Feedback.FeedbackId,Feedback.UserId,Feedback.BookId,Feedback.Comment,Feedback.Ratings,Users.Fullname
		FROM Users
		inner join Feedback
		on Feedback.UserId=Users.id
		where BookId=@BookId
END
select * from Feedback

--------------get feedback -------------------------

Create or alter PROC spGetFeedbacks
	@BookId INT
AS
BEGIN
	select *
		FROM Feedback
		where BookId=@BookId
END
select * from Feedback

update Feedback set Comment='Good Book' where FeedbackId = 3