using Microsoft.Extensions.Configuration;
using PlaylistManager.Models;

namespace PlaylistManager.Outputs {
    internal class WriteToDIsc(IConfiguration configuration) {
        private readonly IConfiguration? _config = configuration;

        public bool WritetoM3U(HashSet<Song> selectedSongs) {
            bool bSucces = false;
            string FileName = GetFileName();

            StreamWriter sw = new StreamWriter("D:\\DMusic\\M3U\\" + FileName);

            foreach (var Song in selectedSongs) {
                if (Song != null) {
                    string fqnPath = GetFromSongFiles(Song.SongId);
                    sw.WriteLine(fqnPath);
                    bSucces = true;
                }
                else {
                    bSucces = false;
                    throw new Exception($"songfiles return null");
                }
            }
            sw.Close();
            return bSucces;
        }

        private string GetFromSongFiles(int songId) {
            MediaCoreContext mcc = new();
            var fqn = mcc.SongFiles.Where(x => x.SongFileId == songId).FirstOrDefault().SongFileFqn;
            return fqn;
        }

        private static string GetFileName() {
            int lastfn = GetNewFileNumber();

            DateTime dt = DateTime.Now;

            string todayDay = dt.ToString("dd");
            string todayMonth = dt.ToString("MM");
            string todayYear = dt.ToString("yy");
            string FileName = lastfn.ToString() + "." + string.Join(string.Empty, todayYear + todayMonth + todayDay) + ".M3U";
            return FileName;
        }

        private static int GetNewFileNumber() {
            DirectoryInfo di = new(@"D:\DMusic\M3U");
            List<FileInfo> files = di.GetFiles("*.m3u", SearchOption.TopDirectoryOnly).ToList();
            files.OrderBy(u => u.Name);
            string fn = files.Last().Name;
            List<string> splitz = fn.Split(".").ToList();
            return int.Parse(splitz[0]) + 1;
        }
    }
}
