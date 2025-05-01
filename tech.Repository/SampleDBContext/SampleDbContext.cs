using Microsoft.EntityFrameworkCore;
using tech.Common.dbmodel;
using tech.Common.ViewModel;

namespace sample_project_tech.SampleDBContext
{
    public class SampleDbContext : DbContext
    {

        public SampleDbContext(DbContextOptions<SampleDbContext> options)
       : base(options)
        {
        }

        public DbSet<Root> Roots { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Multimedium> Multimedias { get; set; }
        public DbSet<DesFacet> DesFacets { get; set; }
        public DbSet<OrgFacet> OrgFacets { get; set; }
        public DbSet<PerFacet> PerFacets { get; set; }
        public DbSet<GeoFacet> GeoFacets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Root>(entity =>
            {
                entity.HasKey(e => e.RootId).HasName("root_pk");

                entity.ToTable("root");

                entity.Property(e => e.RootId).HasColumnName("root_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.Property(e => e.Copyright)
                    .HasColumnName("copyright");

                entity.Property(e => e.Section)
                    .HasMaxLength(100)
                    .HasColumnName("section");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("datetime2")
                    .HasColumnName("last_updated");

                entity.Property(e => e.NumResults).HasColumnName("num_results");

                // Relationship
                entity.HasMany(e => e.Results)
                    .WithOne()
                    .HasForeignKey(r => r.RootId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasKey(e => e.ResultId).HasName("result_pk");

                entity.ToTable("result");

                entity.Property(e => e.ResultId).HasColumnName("result_id");

                entity.Property(e => e.Section).HasColumnName("section");
                entity.Property(e => e.Subsection).HasColumnName("subsection");
                entity.Property(e => e.Title).HasColumnName("title");                
                entity.Property(e => e.Url).HasColumnName("url");
                entity.Property(e => e.Uri).HasColumnName("uri");
                entity.Property(e => e.Byline).HasColumnName("byline");
                entity.Property(e => e.ItemType).HasColumnName("item_type");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime2")
                    .HasColumnName("updated_date");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime2")
                    .HasColumnName("created_date");

                entity.Property(e => e.PublishedDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("published_date");

                entity.Property(e => e.MaterialTypeFacet).HasColumnName("material_type_facet");
                entity.Property(e => e.Kicker).HasColumnName("kicker");
                entity.Property(e => e.ShortUrl).HasColumnName("short_url");

                entity.Property(e => e.RootId).HasColumnName("root_id");

                // Relationships
                entity.HasMany(e => e.Multimedia)
                    .WithOne(m => m.Result)
                    .HasForeignKey(m => m.ResultId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.DesFacets)
                    .WithOne(d => d.Result)
                    .HasForeignKey(d => d.ResultId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.OrgFacets)
                    .WithOne(o => o.Result)
                    .HasForeignKey(o => o.ResultId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.PerFacets)
                    .WithOne(p => p.Result)
                    .HasForeignKey(p => p.ResultId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.GeoFacets)
                    .WithOne(g => g.Result)
                    .HasForeignKey(g => g.ResultId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Multimedium>(entity =>
            {
                entity.HasKey(e => e.MultimediaId).HasName("multimedia_pk");

                entity.ToTable("Multimedia");

                entity.Property(e => e.MultimediaId).HasColumnName("multimedia_id");

                entity.Property(e => e.Url).HasColumnName("url");
                entity.Property(e => e.Format).HasColumnName("format");
                entity.Property(e => e.Height).HasColumnName("height");
                entity.Property(e => e.Width).HasColumnName("width");
                entity.Property(e => e.Type).HasColumnName("type");
                entity.Property(e => e.Subtype).HasColumnName("subtype");
                entity.Property(e => e.Caption).HasColumnName("caption");
                entity.Property(e => e.Copyright).HasColumnName("copyright");

                entity.Property(e => e.ResultId).HasColumnName("result_id");

                // Relationship
                entity.HasOne(e => e.Result)
                    .WithMany(r => r.Multimedia)
                    .HasForeignKey(e => e.ResultId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<DesFacet>(entity =>
            {
                entity.HasKey(e => e.DesFacetId).HasName("des_facet_pk");

                entity.ToTable("DesFacet");

                entity.Property(e => e.DesFacetId).HasColumnName("des_facet_id");
                entity.Property(e => e.FacetName).HasColumnName("facet_name");
                entity.Property(e => e.ResultId).HasColumnName("result_id");

                entity.HasOne(e => e.Result)
                    .WithMany(r => r.DesFacets)
                    .HasForeignKey(e => e.ResultId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OrgFacet>(entity =>
            {
                entity.HasKey(e => e.OrgFacetId).HasName("org_facet_pk");

                entity.ToTable("OrgFacet");

                entity.Property(e => e.OrgFacetId).HasColumnName("org_facet_id");
                entity.Property(e => e.FacetName).HasColumnName("facet_name");
                entity.Property(e => e.ResultId).HasColumnName("result_id");

                entity.HasOne(e => e.Result)
                    .WithMany(r => r.OrgFacets)
                    .HasForeignKey(e => e.ResultId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PerFacet>(entity =>
            {
                entity.HasKey(e => e.PerFacetId).HasName("per_facet_pk");

                entity.ToTable("PerFacet");

                entity.Property(e => e.PerFacetId).HasColumnName("per_facet_id");
                entity.Property(e => e.FacetName).HasColumnName("facet_name");
                entity.Property(e => e.ResultId).HasColumnName("result_id");

                entity.HasOne(e => e.Result)
                    .WithMany(r => r.PerFacets)
                    .HasForeignKey(e => e.ResultId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<GeoFacet>(entity =>
            {
                entity.HasKey(e => e.GeoFacetId).HasName("geo_facet_pk");

                entity.ToTable("GeoFacet");

                entity.Property(e => e.GeoFacetId).HasColumnName("geo_facet_id");
                entity.Property(e => e.FacetName).HasColumnName("facet_name");
                entity.Property(e => e.ResultId).HasColumnName("result_id");

                entity.HasOne(e => e.Result)
                    .WithMany(r => r.GeoFacets)
                    .HasForeignKey(e => e.ResultId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

        }



    }
}
