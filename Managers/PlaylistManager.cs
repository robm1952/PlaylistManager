using Microsoft.Extensions.Configuration;
using PlaylistManager.Models;

namespace PlaylistManager.Managers {
    internal class PlaylistManager {
        private static IConfiguration? _config;
        private static MediaCoreContext? _mediaCoreContext;
        private static string M3UName = string.Empty;
        private static string? M3UFilePath = string.Empty;
        private static string M3UPath = string.Empty;
        public PlaylistManager(IConfiguration config) {
            _config = config;
            _mediaCoreContext = new MediaCoreContext();
            M3UFilePath = _config["AppSettings:M3UFilePath"];
        }
    }
}

