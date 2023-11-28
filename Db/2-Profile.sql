CREATE TABLE IF NOT EXISTS Profile
(
	ProfileId serial PRIMARY KEY,
	UserId int,
	ProfaileName varchar(50),
	FirstName varchar(50),
	LastName varchar(50),
	ProfileImage varchar(100)
);