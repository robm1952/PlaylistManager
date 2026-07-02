using Microsoft.Extensions.Configuration;

namespace PlaylistManager.Random {
    internal class Randomizer(IConfiguration configuration) {
        private readonly System.Random _rng = new System.Random();
        private readonly IConfiguration _configuration = configuration;
        public int ListSize { get; set; }

        // Returns a random integer between 0 and 11883 (inclusive)
        //This is a bug. MaxNumberSongs needs to float
        public int GetRandomInt() {
            int max = ListSize;
            return _rng.Next(0, max);
        }
    }
}
