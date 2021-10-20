use O2NextGen_Prototype
go 

if object_id('dbo.Certificate', 'U') is not null
	drop table dbo.Certificate

create table dbo.Certificate(
    certificate_id int not null identity(1,1),

    constraint PK_Certificate primary key (certificate_id)
)
go