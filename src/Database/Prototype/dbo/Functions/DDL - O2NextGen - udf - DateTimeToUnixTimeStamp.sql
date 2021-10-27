/* 
* Project: O2NextGen 
* Function: udf_DateTimeToUnixTimeStamp 
* Autor: Denis Prokhorchik
* Date: 20-11-2021
*/

if (object_id('dbo.udf_DateTimeToUnixTimeStamp') is not null)
	drop function dbo.udf_DateTimeToUnixTimeStamp;
go


create function dbo.udf_DateTimeToUnixTimeStamp (
@ctimestamp datetime
)
returns bigint
AS 
begin
  /* Function body */
  declare @return bigint
  select @return = DATEDIFF(SECOND,{d '1970-01-01'}, @ctimestamp)
  return @return
end