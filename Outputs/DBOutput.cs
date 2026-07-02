using Microsoft.Extensions.Configuration;
using PlaylistManager.Models;

namespace PlaylistManager.Outputs {
    internal class DBOutput(IConfiguration configuration) {
        private readonly IConfiguration? _config = configuration;
        private readonly MediaCoreContext _MCC = new();
        private PlaylistHistoryContext _PLH = new();

        private Artist? art;
        private Album? alb;
        private Song? son;
        private Genre? gen;

        public bool StartDBOutput(HashSet<Song> selectedSongs) {

            foreach (var songSelected in selectedSongs) {
                //    GetSongAlbumArtistInfo(songSelected.SongId);
                //    Console.WriteLine($"songId: {songSelected.SongId}\tsongAlbumID: {songSelected.SongAlbumId}\tsongTitle: {songSelected.SongTitle}");

                //    Playlist pl = new Playlist() {
                //        PLH_SongId = son.SongId,
                //        PLH_SongTitle = son.SongTitle,

                //        Plh_AlbumID = alb.AlbumId,
                //        PLH_Album = alb.AlbumTitle,

                //        PLH_ArtistId = art.ArtistId,
                //        PLH_Artist = art.ArtistName,


                //        PLH_AlbumYear = alb.AlbumYear,
                //        PLH_Genre = gen.GenreName,

                //        PLH_DateCreated = GetDateCreated(),
                //        PLH_M3UName = GetFileName(),
                //        PLH_M3UPath = GetM3UPath()
                //    };
            }

            DateOnly doTemp = GetDateCreated();
            _ = GetFileName();

            return false;
        }

        private static string GetM3UPath() {
            return @"D:\DMusic\M3U";
        }

        private string GetFileName() {
            _PLH = new PlaylistHistoryContext();
            Playlist _pla = new();
            List<Playlist> PLtemp = [];
            try {
                PLtemp = [.. _PLH.Playlists];
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            //return lastPlaylist.PLH_M3UName;
            return string.Empty;
        }

        private static DateOnly GetDateCreated() {
            return new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        private void GetSongAlbumArtistInfo(int selectedSongId) {
            son = _MCC.Songs.Where(x => x.SongId == selectedSongId).FirstOrDefault();
            alb = _MCC.Albums.Where(x => x.AlbumId == son.SongAlbumId).FirstOrDefault();
            art = _MCC.Artists.Where(x => x.ArtistId == alb.AlbumArtistId).FirstOrDefault();
            gen = _MCC.Genres.Where(x => x.GenreId == alb.AlbumGenre).FirstOrDefault();

        }

    }
}
