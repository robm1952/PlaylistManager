using Microsoft.EntityFrameworkCore;

namespace PlaylistManager.Models;

public partial class PlaylistHistoryContext : DbContext {
    private const string ConnectionString = "Name=DefaultConnection";

    public PlaylistHistoryContext() {
    }

    public PlaylistHistoryContext(DbContextOptions<PlaylistHistoryContext> options)
        : base(options) {
    }

    public virtual DbSet<Playlist> Playlists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.HasKey(e => e.PLH_ID);

            entity.Property(e => e.PLH_Album)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.PLH_Artist)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.PLH_Genre)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.PLH_M3UName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.PLH_M3UPath)
                .HasMaxLength(254)
                .IsFixedLength();
            entity.Property(e => e.PLH_SongTitle)
                .HasMaxLength(200)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
