using System;
using System.Collections.Generic;

namespace PlaylistManager.Models;

public partial class Playlist
{
    public int PLH_ID { get; set; }

    public int? PLH_ArtistId { get; set; }

    public string? PLH_Artist { get; set; }

    public int? Plh_AlbumID { get; set; }

    public string? PLH_Album { get; set; }

    public int? PLH_AlbumYear { get; set; }

    public string? PLH_Genre { get; set; }

    public int? PLH_SongId { get; set; }

    public string? PLH_SongTitle { get; set; }

    public string? PLH_M3UPath { get; set; }

    public string? PLH_M3UName { get; set; }

    public DateOnly? PLH_DateCreated { get; set; }
}
