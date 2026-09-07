using Microsoft.Extensions.Configuration;
using PlaylistManager.Models;

namespace PlaylistManager.Filters {
    internal class ExcludeAlbums {
        private static HashSet<int>? excludedAlbums;
        private static IConfiguration? _config;
        private static int taDa = 0;
        private readonly MediaCoreContext? mcContext;        //connection to MediaCore database

        public ExcludeAlbums(IConfiguration configuration) {
            _config = configuration;
            mcContext = new MediaCoreContext();
            taDa++;
        }

        public HashSet<Song> DoExclusion(HashSet<Song> allSongs) {

            HashSet<Song> FilteredAlbumIds = [];
            string excludedAlbumIds = string.Empty;

            if (_config != null) {
                excludedAlbumIds = _config["appSettings:ExcludedAlbums"];
            }

            excludedAlbums = [.. excludedAlbumIds
                .Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Where(yy => int.TryParse(yy, out _))
                .Select(int.Parse)];

            HashSet<Song> filteredSongs = [.. mcContext.Songs.Where(s => !excludedAlbums.Contains(s.SongAlbumId))];
            if (filteredSongs.Count < allSongs.Count) {
                return filteredSongs;
            }
            else {
                return [.. allSongs];
            }

        }
    }
}


/*
 *     //internal void LoadDateForWrite() {
        //    throw new NotImplementedException();
        //}

        //internal bool WriteM3UToDisk(HashSet<string> songFullFilenames, HashSet<Song> songsForPlaylist) {
        //    bool returnedValue = false;

        //    if (!string.IsNullOrWhiteSpace(M3UFilePath))
        //    {
        //        M3UPath = Path.Combine(M3UFilePath, M3UName);
        //    }
        //    else
        //    {
        //        returnedValue = false;
        //        throw new Exception("M3UFilePath is not set in the configuration.");
        //    }

        //    StreamWriter sw = new(M3UPath);
        //    foreach (string songFilename in songFullFilenames)
        //    {
        //        sw.WriteLine(songFilename);
        //        sw.Flush();
        //    }
        //    sw.Close();
        //    returnedValue = true;
        //    return returnedValue;
        //}



        //private string MakeFileName() {
        //    int NewListNumber = GetCurrentPlaylistNumber() + 1;
        //    if (_config != null)
        //    {
        //        string? M3UFilePath = _config["AppSettings:M3UFilePath"];
        //        if (M3UFilePath != null)
        //        {
        //            string fileName = $"{NewListNumber}.{DateTime.Now:yyMMdd}.M3U";
        //            return Path.Combine(M3UFilePath, fileName);
        //        }
        //    }
        //    throw new Exception("M3UFilePath is not set in the configuration.");
        //}

        //public static int GetCurrentPlaylistNumber() {

        //    if (_config != null)
        //    {
        //        M3UFilePath = _config["AppSettings:M3UFilePath"];
        //    }
        //    int retint = 0;
        //    if (M3UFilePath != null)
        //    {
        //        DirectoryInfo dir = new DirectoryInfo(M3UFilePath);
        //        List<FileInfo> files = dir.GetFiles("*.M3U").ToList();
        //        FileInfo? mostRecentFile = files.OrderByDescending(f => f.LastWriteTime).FirstOrDefault();
        //        if (mostRecentFile != null)
        //        {
        //            // Use Split and check result instead of invalid range syntax
        //            string[] playlistFileNumbers = mostRecentFile.Name.Split('.');
        //            if (playlistFileNumbers.Length > 0 && int.TryParse(playlistFileNumbers[0], out int n))
        //            {
        //                retint = Convert.ToInt16(n);
        //            }
        //        }
        //        return retint;
        //    }
        //    throw new Exception("M3UFilePath is not set in the configuration.");
        //}

        //internal bool WritePLSToDB(HashSet<Song> songsForPlaylist) {
        //    string ArtistName = string.Empty;
        //    int ArtistId = 0;
        //    int AlbumId = 0;
        //    int AlbumYear = 0;
        //    string Genre = string.Empty;
        //    string SongTitle = string.Empty;

        //    foreach (Song song in songsForPlaylist)
        //    {
        //        Album? alb = _mediaCoreContext?.Albums.FirstOrDefault(a => a.AlbumId == song.SongAlbumId);
        //        if (alb == null)
        //        {
        //            // album not found, skip this song or handle appropriately
        //            continue;
        //        }

        //        Artist? art = _mediaCoreContext?.Artists.FirstOrDefault(a => a.ArtistId == alb.AlbumArtistId);

        //        AlbumId = alb.AlbumId;
        //        SongTitle = song.SongTitle ?? string.Empty;
        //        // AlbumYear is nullable in the model; use GetValueOrDefault or null-coalescing
        //        AlbumYear = alb.AlbumYear.GetValueOrDefault(0);

        //        // AlbumGenre is nullable (int?); pass a safe default if your GetGenreFromId expects non-nullable
        //        Genre = GetGenreFromId(alb.AlbumGenre);

        //        // Artist may be null; use safe fallbacks
        //        ArtistName = art?.ArtistName ?? string.Empty;
        //        ArtistId = art?.ArtistId ?? 0;


        //        try
        //        {
        //            PlaylistHistoryContext plhContext = new PlaylistHistoryContext();
        //            Playlist newPlaylist = new Playlist()
        //            {
        //                PLH_ArtistId = ArtistId,
        //                PLH_Artist = ArtistName,
        //                Plh_AlbumID = songsForPlaylist.FirstOrDefault()?.SongAlbumId,
        //                PLH_Album = alb.AlbumTitle,
        //                PLH_AlbumYear = alb.AlbumYear,
        //                PLH_Genre = Genre,
        //                PLH_SongTitle = songsForPlaylist.FirstOrDefault()?.SongTitle,
        //                PLH_M3UPath = Path.Combine(_config["AppSettings:M3UFilePath"], M3UName),
        //                PLH_M3UName = MakeFileName(),
        //                PLH_DateCreated = DateOnly.FromDateTime(DateTime.Now)
        //            };
        //            plhContext.Playlists.Add(newPlaylist);
        //            plhContext.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            //    return false;
        //        }
        //    }
        //    return true;
        //}

        //private string GetGenreFromId(int? v) {
        //    string genreName = string.Empty;
        //    if (v.HasValue)
        //    {
        //        Genre? genre = _mediaCoreContext?.Genres.FirstOrDefault(g => g.GenreId == v.Value);
        //        if (genre != null)
        //        {
        //            genreName = genre.GenreName ?? string.Empty;
        //        }
        //    }
        //    return genreName;
 */