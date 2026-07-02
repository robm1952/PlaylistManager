using Microsoft.Extensions.Configuration;
using PlaylistManager.Models;

namespace PlaylistManager.Filters {
    internal class ToSpecification {
        IConfiguration _configuration;
        public ToSpecification(IConfiguration configuration) {
            _configuration = configuration;
        }

        public HashSet<Song> DoToUserCount(int userCount, HashSet<Song> songs) {
            HashSet<Song> result = new HashSet<Song>();
            //Randomizer randomizer = new Randomizer(_configuration);
            for (int i = 0; i < userCount; i++)
            {
                if (songs.Count <= userCount)
                {
                    break;
                }
                //int randomIndex = randomizer.GetRandomInt();
                //if (randomIndex >= songs.Count)
                //{
                //    randomIndex = songs.Count - 1;
                //}
                //result.Add(songs.ElementAt(randomIndex));
            }

            return result;
        }
    }
}
