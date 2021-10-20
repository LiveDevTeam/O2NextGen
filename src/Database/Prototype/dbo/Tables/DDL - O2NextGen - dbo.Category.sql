use O2NextGen_Prototype
go

if object_id('dbo.Category', 'U') is not null
	drop table dbo.Category

create table dbo.Category
(
    category_id int not null identity(1,1),

    constraint PK_Category primary key (category_id)
)
go