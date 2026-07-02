using Microsoft.Extensions.Configuration;
using PlaylistManager.Filters;
using PlaylistManager.Models;
using PlaylistManager.Random;

namespace PlaylistManager.Inputs {
    internal class MusicInput {
        private static IConfiguration? _config;
        private readonly MediaCoreContext _mediaCoreContext = new();

        public MusicInput(IConfiguration configuration) {
            _config = configuration;
        }

        public HashSet<Song> GetAllSongs() {
            HashSet<Song>? allSongs;

            if (_mediaCoreContext != null) {
                allSongs = [.. _mediaCoreContext.Songs];
            }
            else {
                throw new Exception("MCContext not instantiated");
            }
            if (allSongs != null && allSongs.Count > 0) {
                allSongs = RemovedExcludedAlbums(allSongs);
            }
            else {
                allSongs.Clear();
                throw new Exception("allSongs not ready");
            }
            return allSongs;
        }

        private static HashSet<Song> RemovedExcludedAlbums(HashSet<Song> allSongs) {
            ExcludeAlbums exa = new(_config);
            allSongs = exa.DoExclusion(allSongs);
            return allSongs;
        }

        internal HashSet<Song> GetRandomSongSelections(int UserRequest, HashSet<Song> filteredSongs) {
            List<Song> filteredSongsList = [.. filteredSongs];
            HashSet<Song> RandSelectedSongs = [];
            bool Failure = true;
            if (UserRequest != 0 && filteredSongs != null) {

                Song randomSong;

                Randomizer localRand = new(_config) {
                    ListSize = filteredSongs.Count
                };

                int randInt = 0;
                for (int i = 0; i <= UserRequest; i++) {

                    randInt = localRand.GetRandomInt() + 1;
                    //Console.WriteLine($"{randInt}");
                    randomSong = (Song)filteredSongsList.FirstOrDefault(x => x.SongId == randInt);

                    if (randomSong != null) {
                        RandSelectedSongs.Add(randomSong);
                        //Console.WriteLine($"{i}\t{randInt}\t{randomSong.SongTitle}");
                    }
                    else {//most of the spelling errors that require this have been excluded, but still probably half of classical
                        while (Failure) {
                            Console.WriteLine($"{randInt} Failed");
                            randInt = localRand.GetRandomInt() + 1;

                            randomSong = (Song)filteredSongsList.FirstOrDefault(x => x.SongId == randInt);
                            //this exists because of naming problems in the database

                            if (randomSong != null) {
                                RandSelectedSongs.Add(randomSong);
                                //Console.WriteLine($"{i}\t{randInt}\t{randomSong.SongTitle}");
                                Failure = false;
                            }
                            else {
                                //collect songIds here, these will be the onses to fix.
                                String Path2File = String.Join(Directory.GetCurrentDirectory(), "ErrantIds.txt");
                                StreamWriter sw = new(Path2File, true);
                                sw.WriteLine(randInt.ToString());
                                sw.Close();
                                continue;
                            }
                        }
                    }

                }
            }
            return RandSelectedSongs;
        }
    }
}


