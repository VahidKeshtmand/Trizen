using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T.Domain.Common;

namespace T.Persistence.ConfigTables.Common
{
    internal class PersonalInformationConfig : IEntityTypeConfiguration<PersonalInformation>
    {
        public void Configure(EntityTypeBuilder<PersonalInformation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.JobTitle)
                .WithMany(x => x.PersonalInformations)
                .HasForeignKey(x => x.JobTitleId);
        }
    }
}
