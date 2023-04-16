using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CantinaFacil.Infrastructure.Data.Mappings.Extensions;
using CantinaFacil.Shared.Kernel.Domain;

namespace CantinaFacil.Infrastructure.Data.Mappings
{
    public class Mapping<T> : EntityTypeConfiguration<T> where T : Entity
    {
        public override void Map(EntityTypeBuilder<T> builder)
        {
            builder.Ignore(x => x.IsInvalid);
            builder.Ignore(x => x.IsValid);
            builder.Ignore(x => x.DomainEvents);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
