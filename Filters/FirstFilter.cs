using Microsoft.Extensions.Configuration;
using PlaylistManager.Models;

namespace PlaylistUpdater.Filters {
    internal class FirstFilter {
        private readonly IConfiguration _configuration;

        public FirstFilter(IConfiguration configuration) {
            _configuration = configuration;
            Artists = new List<Artist>();
        }

        public List<Artist> Artists { get; set; }
        private static List<Artist> GetListArtistAlbum(int _artistId, int _albumId) {
            //this function returns a liist of artists matching an artist.rating = 1
            //
            //
            if (_artistId == 0 || _albumId == 0)
            {
                throw new ArgumentException("_artistId or _albumId == 0");
            }
            else
            {
                Artist artist = new Artist();
            }

            return new List<Artist>();
        }
    }
}
