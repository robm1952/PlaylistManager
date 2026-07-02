--All Files
Select count (*) as dLines
from Playlists

--All files order by M3U Name
select *
from Playlists
order by PLH_M3UName, PLH_SongId desc, Plh_AlbumID

--Artists order by Artists count desc
select count(pla.PLH_Artist) as daCountArtists,pla.PLH_Artist
from Playlists pla
group by pla.PLH_Artist
order by daCountArtists  desc

--Albums order by Albums count desc
select count(pla.PLH_Album) as daCountALBUMS,pla.PLH_Album,PLA.PLH_Artist
from Playlists pla
group by pla.PLH_Album,PLA.PLH_Artist
order by daCountALBUMS  desc

--Albums order by Songs count desc
select count( pla.PLH_SongTitle) dCount, pla.PLH_SongTitle,pla.PLH_Album,pla.PLH_Artist
from Playlists pla
group by pla.PLH_SongTitle,pla.PLH_Album,pla.PLH_Artist
order by dCount desc

--AlbumYear order by AlbumYear count desc
select count(pla.PLH_AlbumYear) dCountYears, pla.PLH_AlbumYear
from Playlists pla
group by pla.PLH_AlbumYear,pla.PLH_Artist
order by dCountYears desc

--Genres order by Genres desc
select count(pla.PLH_Genre) as daCount,pla.PLH_Genre
from Playlists pla
group by pla.PLH_Genre
order by daCount desc