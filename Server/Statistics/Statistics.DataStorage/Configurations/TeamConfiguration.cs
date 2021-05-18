using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Statistics.DataStorage.Entities;

namespace Statistics.DataStorage.DataContext
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder
                .ToTable(@"Team")
                .HasKey(x => x.Id)
                .HasName("PK_Team_Id");

            builder
                .Property(x => x.Id)
                .HasColumnName(@"Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Name)
                .HasColumnName(@"Name")
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsRequired();

            builder
                .Property(x => x.Code)
                .HasColumnName(@"Code")
                .HasColumnType("nvarchar")
                .HasMaxLength(3)
                .IsRequired();

            builder
                .HasIndex(x => x.Code)
                .IsUnique()
                .HasDatabaseName("UX_Team_Code");

            builder
                .Property(x => x.City)
                .HasColumnName(@"City")
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .HasMaxLength(64);

            builder
                .Property(x => x.Conference)
                .HasColumnName(@"Conference")
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsRequired();

            builder
                .Property(x => x.Division)
                .HasColumnName(@"Division")
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsRequired();

            builder
                .Property(x => x.Logo)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}
