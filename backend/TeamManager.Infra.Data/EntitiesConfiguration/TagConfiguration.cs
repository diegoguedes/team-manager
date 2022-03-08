using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamManager.Domain.Entities;

namespace TeamManager.Infra.Data.EntitiesConfiguration;

public class TagConfiguration: IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

        builder.HasData(
            new Tag(1, "C#"),
            new Tag(2, "Angular"),
            new Tag(3, "General Frontend"),
            new Tag(4, "Seasoned Leader")
        );

    }
}