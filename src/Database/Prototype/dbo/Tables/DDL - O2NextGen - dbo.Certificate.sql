/* 
* Project: O2NextGen 
* Table: dbo_Certificate 
* Autor: Denis Prokhorchik
* Date: 20-11-2021
*/

use O2NextGen_Prototype
go

if object_id('dbo.Certificate', 'U') is not null
	drop table dbo.Certificate

create table dbo.Certificate
(
    certificate_id int not null identity(1,1),
    category_id int not null,

    constraint PK_Certificate primary key (certificate_id)
)
go