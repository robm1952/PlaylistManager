using System;
using System.Collections.Generic;

namespace PlaylistManager.Models;

public partial class Artist
{
    public int ArtistId { get; set; }

    public string? ArtistName { get; set; }

    public string? ArtistSortName { get; set; }

    public int? ArtistRanking { get; set; }
}
