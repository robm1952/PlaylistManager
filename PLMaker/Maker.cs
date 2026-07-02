using Microsoft.Extensions.Configuration;

namespace PlaylistUpdater.PLMaker {
    public class Maker {
        public static IConfiguration? _configuration;

        //private static DataLayer? _layer;

        public Maker(IConfiguration configuration) {
            _configuration = configuration;
            //  _layer = new DataLayer(configuration);
        }
        #region Notes
        //fill playlist by selecting songs matching the generated random number.
        //40.2025.05.23 current name format 40 is the playlist number the yyyymmdd separated by a dot
        //File name set to this style, all existing files have been renamed in this style.
        //40.260523.M3U or YYMMDD
        //inside file is fqn of song, one per line, to the number of songs specified in the args parameter.  This will be used by the playlist player to play the songs in the playlist.

        // }
        #endregion

    }

    public class MakerTaker {
        public MakerTaker() { }
        public int? SongId { get; set; }
        public string? SongTitle { get; set; }
        public int? SongAlbumId { get; set; }
        public string? AlbumTitle { get; set; }
        public int? AlbumArtistId { get; set; }
        public string? ArtistName { get; set; }
    }
}

/*
 * //Datalayer commented out as it will move to the not yet implemented Maker class. 
 * //DataLayer dl = new(config);
*/
