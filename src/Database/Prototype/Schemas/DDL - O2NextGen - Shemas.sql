go

if (select [name] from sys.schemas where [name] like '%audit%') is not null
	drop schema [audit]

go

if (select [name] from sys.schemas where [name] like '%test%') is not null
	drop schema [test]

go

if (select [name] from sys.schemas where [name] like '%config%') is not null
	drop schema [config]

go

create schema [audit]

go

create schema [test]

go

create schema [config]

go