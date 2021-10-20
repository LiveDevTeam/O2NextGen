/* 
* Project: O2NextGen 
* Function: udf_DateTimeToUnixTimeStamp 
* Autor: Denis Prokhorchik
* Date: 20-11-2021
*/

if (object_id('dbo.udf_UnixTimeStampToDateTime') is not null)
	drop function dbo.udf_UnixTimeStampToDateTime;
go


create function dbo.udf_UnixTimeStampToDateTime (
@ctimestamp bigint
)
RETURNS datetime
as 
begin
  /* Function body */
  declare @return datetime
  select @return = DATEADD(SECOND, @ctimestamp, {d '1970-01-01'})
  return @return
end