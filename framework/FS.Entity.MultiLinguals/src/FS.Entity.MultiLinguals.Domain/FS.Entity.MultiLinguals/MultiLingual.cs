using System;
using System.Data;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Data;
using System.Threading.Tasks;
using FS.Entity.MultiLinguals;
using System.Globalization;
using FS.Entity.EntityFeatures;
using Volo.Abp.Domain.Entities;

namespace FS.Entity.MultiLinguals
{
    public partial class MultiLingual
    {
        public object GetOrDefaultLingualTranslation<T>(EntityFeaturesOptions options, T entity, string culture = null)
            where T : IEntity<Guid>
        {
            culture=culture??CultureInfo.CurrentCulture.Name;

            var translation = this.MultiLingualTranslations.SingleOrDefault(x => x.Culture==culture);

            var definition = options[typeof(MultiLingual)][typeof(T)] as MultiLinguals.MultiLingualsEntityFeatureDefinition;

            var result = Activator.CreateInstance(definition.TranslationType);

            definition.TranslationType.GetProperties()
                .ToList()
                .ForEach(p =>
                {
                    var value = translation == null
                        ? entity.GetType().GetProperties().SingleOrDefault(x => x.Name == p.Name).GetValue(entity)
                        : translation.Properties.SingleOrDefault(y => y.Name == p.Name).Value;
                    p.SetValue(result, value);
                });
            return result;
        }


        public TTranslation GetOrDefaultLingualTranslation<TEntity, TTranslation>(TEntity entity, string culture = null)
            where TEntity : IEntity<Guid>
            where TTranslation : class, new()
        {
            var result = new TTranslation();
            culture=culture??CultureInfo.CurrentCulture.Name;
            var translation = this.MultiLingualTranslations.SingleOrDefault(x => x.Culture==culture);

            typeof(TTranslation).GetProperties()
                .ToList()
                .ForEach(p =>
                {
                    var value = translation == null
                        ? entity.GetType().GetProperties().SingleOrDefault(x => x.Name == p.Name).GetValue(entity)
                        : translation.Properties.SingleOrDefault(y => y.Name == p.Name).Value;
                    p.SetValue(result, value);
                });
            return result;
        }

        public async Task AddOrReplaceTranslationAsync(IMultiLingualsStore store, string culture, List<Volo.Abp.NameValue> properties)
        {
            MultiLingualTranslations.Where(x => x.Culture == culture)
                .Skip(1)
                .ToList()
                .ForEach(t =>
                {
                    MultiLingualTranslations.Remove(t);
                });
            var translation = MultiLingualTranslations.SingleOrDefault(x => x.Culture == culture) ?? await store.CreateMultiLingualTranslationAsync(this, culture);

            translation.Properties = properties;

            MultiLingualTranslations.AddIfNotContains(translation);
        }
    }

}
