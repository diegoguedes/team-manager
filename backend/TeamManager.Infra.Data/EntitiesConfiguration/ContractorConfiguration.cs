using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamManager.Domain.Entities;

namespace TeamManager.Infra.Data.EntitiesConfiguration;

public class ContractorConfiguration: IEntityTypeConfiguration<Contractor>
{
    public void Configure(EntityTypeBuilder<Contractor> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
    }
}