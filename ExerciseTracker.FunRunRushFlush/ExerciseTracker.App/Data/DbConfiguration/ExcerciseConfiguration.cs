using ExerciseTracker.App.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExerciseTracker.App.Data.DbConfiguration;

public class ExcerciseConfiguration : IEntityTypeConfiguration<Excercise>
{
    public void Configure(EntityTypeBuilder<Excercise> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .IsUnicode(false)
            .ValueGeneratedOnAdd();
        builder.Property(x => x.ExerciseName).HasMaxLength(256).IsRequired();
        builder.Property(x => x.Comments).HasMaxLength(512).IsRequired();
        builder.Property(x => x.ExerciseStart).IsRequired();
        builder.Property(x => x.ExerciseEnd).IsRequired();

    }
}