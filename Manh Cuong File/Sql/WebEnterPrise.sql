

Create table Students(
Id int identity,
Username varchar(50),
Pass varchar(50),
Email varchar(60),
Fullname varchar(60),
Primary key(Id)
)
Create table Turtors(
Id int identity,
Username varchar(50),
Pass varchar(50),
Email varchar(60),
Fullname varchar(60),
Primary key(Id)
)
Create table Masters(
Id int identity,
Username varchar(50),
Pass varchar(50),
Primary key(Id)
)
Create table Roles(
Id int identity,
RoleName varchar(50),
Primary key(Id)
)
Create table MasterRoles(
Id int identity,
RoleId int,
MasterId int,
Foreign key(RoleId) references Roles(Id),
Foreign key(MasterId) references Masters(Id)
)
Create table Arranges(
Id int identity,
TutorId int,
StudentId int,
Primary key(Id),
Foreign key(TutorId) references Turtors(Id),
Foreign key(StudentId) references Students(Id)
)
Create table Reports(
Id int identity,
Meeting varchar(max),
Documents varchar(max),
Comments varchar(max),
TutorId int,
StudentId int,
Primary key(Id),
Foreign key(TutorId) references Turtors(Id),
Foreign key(StudentId) references Students(Id)
)
Create table Feedback(
Id int identity,
TutorId int,
StudentId int,
Feedback varchar(max),
Primary key(Id),
Foreign key(TutorId) references Turtors(Id),
Foreign key(StudentId) references Students(Id)
)
