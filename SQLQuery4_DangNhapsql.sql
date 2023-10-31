create table users
(
userID int primary key identity,
userName varchar(50) not null,
upass varchar(10) not null,
uName varchar(50) not null,
uPhone varchar(20) 
)

insert into users values('admin',123456,'User 1','037676999')