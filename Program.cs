using Microsoft.Extensions.Configuration;
using PlaylistManager.Inputs;
using PlaylistManager.Models;
using PlaylistManager.Outputs;


internal class Program {
    private static int UserRequest;

    private static void Main(string[] args) {
        IConfiguration config = InitConf.InitConfig.InitializeConfig();

        //retrieve and validate incoming data
        UserInput ui = new(config);

        //safely convert to int
        UserRequest = ui.ConvertToInt(args[0]);

        //class  getallsongs and getSongSelections
        MusicInput mi = new MusicInput(config);

        //GetAllSongs() returns a set that has been filteree by a list of excluded albums**
        HashSet<Song> filteredSongs = mi.GetAllSongs();
        if (filteredSongs != null && filteredSongs.Count > 0) {

            //GetSongSelections(int,set of songs with some albums removed
            HashSet<Song> RandSelSongs = mi.GetRandomSongSelections(UserRequest, filteredSongs);

            //class handling the task of writing data to be persisted to local hard drive
            //work is done but needs a full debug

            WriteToDIsc wtd = new WriteToDIsc(config);
            wtd.WritetoM3U(RandSelSongs);

            //class handling task of creating and storing playlist in playlisthistory database
            //DBOutput dBOutput = new DBOutput(config);
            //bool test = dBOutput.StartDBOutput(RandSelSongs);
        }
        else {
            throw new Exception("filteredSongs is null or zero count");
        }
    }
}




//**
//several christmas and some soundtracks have been excluded so now there is a set of filtered songs.
//; retrieve filtered and random picked set of songs, Write list of FQN = FI.FullNameit out to m3u file 
//Create playlist objects and store them in the playlist table in PlaylistHistory