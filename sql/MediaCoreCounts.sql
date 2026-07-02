--All Artists	688	260621
select *
from Artists	

--All Albums	1062 260621
select *
from Albums

--All Songs		11877 260621
select *
from Songs

--MediaCore Artist alpha, Albumtitle
select art.artistName, alb.albumTitle
from artists art inner join albums alb on art.artistId = alb.albumArtistId
order by art.artistName, alb.albumTitle