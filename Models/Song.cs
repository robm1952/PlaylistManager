using System;
using System.Collections.Generic;

namespace PlaylistManager.Models;

public partial class Song
{
    public int SongId { get; set; }

    public int SongAlbumId { get; set; }

    public string SongTitle { get; set; } = null!;

    public long SongDuration { get; set; }

    public int SongTrackNumber { get; set; }

    public int? SongRanking { get; set; }
}
