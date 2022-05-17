using FS.Abp.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FS.Entity.EntityFeatures
{
    public class EntityFeatureDefinitions : TypeDictionary<EntityFeatureDefinition>
    {
        public override void AddOrReplace<TKey>(EntityFeatureDefinition value = null)
        {
            if (value==null)
                value=new DefaultEntityFeatureDefinition(typeof(TKey));
            base.AddOrReplace<TKey>(value);
        }
    }

    public class EntityFeaturesOptions : TypeDictionary<EntityFeatureDefinitions>
    {
        public List<(EntityFeatureDefinition Owner, Type Feature)> OwnerFeaturePairs
        {
            get
            {
                return this.SelectMany(x => x.Value, (x, y) => (y.Value, x.Key)).ToList();
            }
        }
    }
}
