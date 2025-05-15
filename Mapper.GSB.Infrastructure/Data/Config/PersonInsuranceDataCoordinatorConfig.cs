using Mapper.GSB.Domain.InsuranceDataCoordinator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.Intrinsics.X86;

namespace Mapper.GSB.Infrastructure.Data.Config
{
    /// <summary>
    /// تنظیمات جدول مربوط به مدل مورد نظر
    /// </summary>
    internal class PersonInsuranceDataCoordinatorConfig : IEntityTypeConfiguration<PersonInsuranceDataCoordinator>
    {
        /// <summary>
        /// تنظیمات جدول
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<PersonInsuranceDataCoordinator> builder)
        {
            builder.ToTable(nameof(PersonInsuranceDataCoordinator));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.RowVersion).IsRequired().IsRowVersion();

            builder.Property(x => x.RegisterUID).IsRequired(true);
            builder.Property(x => x.MessageUID).IsRequired(true);
            builder.Property(x => x.openEHRPartyId).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.openEHRPartyRelationshipId).IsRequired(false).HasMaxLength(100);
            builder.Ignore(x => x.RegisterDateTime);
            
            builder.Property(x => x.PersonId).IsRequired(true).HasMaxLength(36);
            builder.Property(x => x.PersonIdType).IsRequired(true).HasMaxLength(50);
            builder.Property<string>("personIdentifier").IsRequired(true).HasMaxLength(500);
            builder.Ignore(x => x.PersonIdentifier);

            builder.Property(x => x.PolicyUniqueCode).IsRequired(true).HasMaxLength(36);
            builder.Property(x => x.CompanyInsuredId).IsRequired(true).HasMaxLength(36);
            builder.Property(x => x.CompanyPolicyId).IsRequired(true).HasMaxLength(36);

            builder.Property(x => x.InsurerId).IsRequired(true);
            builder.Property<string>("insurer").IsRequired(false).HasMaxLength(500);
            builder.Ignore(x => x.Insurer);

            builder.Property<string>("policyType").IsRequired(false).HasMaxLength(500);
            builder.Ignore(x => x.PolicyType);

            builder.Property(x => x.AccountID).IsRequired(false).HasMaxLength(36);

            builder.Property<DateTime>("insuranceExpirationDate").IsRequired(true);
            builder.Ignore(x => x.InsuranceExpirationDate);


            builder.Property(x => x.DomainModel).IsRequired(true);
            builder.Ignore(x => x.DomainModelName);
            builder.Property(x => x.PatientUID).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.CompositionUID).IsRequired(false).HasMaxLength(100);

            builder.Property(x => x.ShebadId).IsRequired(false).HasMaxLength(100);
            builder.Property<string>("shebad").IsRequired(false).HasMaxLength(500);
            builder.Ignore(x => x.Shebad);

            builder.Property(x => x.GSBResult).IsRequired(false);
            builder.Property(x => x.GSBAttemptsFailCount).IsRequired(true).HasDefaultValue(0);
            builder.Property(x => x.LocalId).IsRequired(false).HasMaxLength(150);
            builder.Property(x => x.Status).IsRequired(true);
            builder.Property(x => x.Operation).IsRequired(true);
            
            //builder.Property(x => x.Error).IsRequired(false);
            builder.Property<string>("error").IsRequired(false);
            builder.Ignore(x => x.Error);

            builder.Property(x => x.PersonInsuranceCreatedEventId).IsRequired(true);

            builder.Property(x => x.GSBIgin).IsRequired(false).HasMaxLength(36);
            builder.Property(x => x.GSBRegisterID).IsRequired(false).HasMaxLength(36);

            builder.Ignore(x => x.Events);



            /**
             * <see cref="IPersonInsuranceDataCoordinatorProvider.FindByCreatedDateAsync" />
             */
            builder.HasIndex(x => new { x.CreatedDate, x.InsurerId });
            /**
             * <see cref="IPersonInsuranceDataCoordinatorProvider.FindInsurancesWhichEncountersErrorByCreatedDateAsync" />
             * <see cref="FindAllInsurancesWhichIsNotSendingDataToDDRBeforeTheCreatedDateAndSortedByCreatedDate"/>
             */
            builder.HasIndex(x => new { x.CreatedDate, x.Status, x.InsurerId }).IncludeProperties(x=>x.Version);
            /**
             * <see cref="IPersonInsuranceDataCoordinatorProvider.FindIdentifiersAtLeastHasSavePersonInopenEHRSuccessfulStatusByRegisterUIDAsync" />
             */
            builder.HasIndex(x => x.RegisterUID).IncludeProperties(x => new { x.PersonIdType, x.openEHRPartyId, x.openEHRPartyRelationshipId, x.Status, x.PersonId })
                                             .HasFilter($"[{nameof(PersonInsuranceDataCoordinator.Status)}]>={(int)InsuranceDataStatus.SavePersonInopenEHRRepositoryIsSucceessful}");

            /**
             * <see cref="IPersonInsuranceDataCoordinatorProvider.FindIdentifiersByPersonIdAsync"/>
             */
            //builder.HasIndex(x => new { x.PersonId, x.PersonIdType }).IncludeProperties(x => new { x.openEHRPartyId, x.openEHRPartyRelationshipId, x.Status, x.RegisterUID })
            //                                 .HasFilter($"[{nameof(PersonInsuranceDataCoordinator.Status)}]>={(int)InsuranceDataStatus.SavePersonInopenEHRRepositoryIsSucceessful}");
            builder.HasIndex(x => new { x.PersonId, x.Status }).IncludeProperties(x => new { x.PersonIdType, x.openEHRPartyId, x.openEHRPartyRelationshipId, x.RegisterUID });

            /**
             * <see cref="IPersonInsuranceDataCoordinatorProvider.FindByPersonIdAndInsurerIdAndPolicyUniqueCodeAsync"/>
             */
            builder.HasIndex(x => new { x.PersonId, x.InsurerId, x.PolicyUniqueCode }).IncludeProperties(x=> new {x.Id, x.RegisterUID, x.MessageUID, x.Version });
            /**
             * <see cref="IPersonInsuranceDataCoordinatorProvider.FindByPersonIdAndInsurerIdAndAccountIdAsync"/>
             */
            builder.HasIndex(x => new { x.PersonId, x.InsurerId, x.AccountID }).IncludeProperties(x => new { x.Id, x.RegisterUID, x.MessageUID, x.Version });

            /**
             * <see cref="IPersonInsuranceDataCoordinatorProvider.FindByRegisterUIDAsync"/>
             */
            builder.HasIndex(x => x.RegisterUID);
            /**
             * <see cref="IPersonInsuranceDataCoordinatorProvider.FindByPersonIdAndPersonTypeAsync"/>
             */
            builder.HasIndex(x => new { x.PersonId, x.PersonIdType});
        }
    }
}
