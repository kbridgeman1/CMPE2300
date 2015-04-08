create proc GetTitles
	@filter varchar(80) = ''
as
select title_id, title
from eirla1_pubs.dbo.titles
where title like '%' + @filter + '%'
go

execute GetTitles 'st'
go