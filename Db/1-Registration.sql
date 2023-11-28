CREATE TABLE IF NOT EXISTS AppUser
(
	UserId serial PRIMARY KEY,
	Email varchar(50),
	Password varchar (100),
	Salt varchar(50),
	Status int
);

CREATE TABLE IF NOT EXISTS UserSecrurity
(
	UserSecrurityId serial PRIMARY KEY,
	UserId int,
	VerificationCode varchar (50)
);

CREATE TABLE IF NOT EXISTS EmailQueue
(
	EmailQueueId serial PRIMARY KEY,
	EmailTo varchar(200),
	EmailFrom varchar(200),
	EmailSubject varchar(200),
	EmailBody time,
	ProcessingId varchar(100),
	Retry int
);

CREATE INDEX IF NOT EXISTS IX_AppUser_Email ON AppUser
(
	Email
);

ALTER TABLE AppUser DROP IF EXISTS FirstName;
ALTER TABLE AppUser DROP IF EXISTS LastName;
ALTER TABLE AppUser DROP IF EXISTS ProfileImage;







