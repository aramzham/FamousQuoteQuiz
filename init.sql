create database pollDb collate SQL_Latin1_General_CP1_CI_AS
go

use pollDb
go

create table Author
(
    Id   int identity
        primary key,
    Name varchar(250) not null
)
go

create table Quote
(
    Id       int identity
        primary key,
    Body     varchar(250) not null,
    AuthorId int          not null
        references Author
)
go

create table [User]
(
    Id           int identity
        primary key,
    Name         varchar(100)               not null,
    QuestionType int                        not null,
    CreatedAt    datetime default getdate() not null
)
go

create table UserAchievement
(
    Id                  int identity
        primary key,
    UserId              int not null
        references [User],
    QuoteId             int not null
        references Quote,
    IsAnsweredCorrectly bit not null
)


insert into [User] (Name, QuestionType) values ('admin', 0)
insert into Author (Name) values ('Danny De Vito')
insert into Quote(Body, AuthorId) values ('first quote', 1)

select * from Quote
select * from Author
select * from [User]
select * from UserAchievement
