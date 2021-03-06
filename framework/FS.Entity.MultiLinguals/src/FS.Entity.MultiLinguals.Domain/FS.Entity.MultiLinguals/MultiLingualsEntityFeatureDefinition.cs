using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace FS.Entity.MultiLinguals
{
    public class MultiLingualProperty
    {
        public string Name { get; set; }
        public string DataType => "string";
        public MultiLingualProperty(string name)
        {
            Name = name;
        }
    }

    [Serializable]
    public class MultiLingualsEntityFeatureDefinition : Entity.EntityFeatures.EntityFeatureDefinition, IEquatable<MultiLingualsEntityFeatureDefinition>
    {
        public Type TranslationType;
        public string TranslationTypeFullName { get; protected set; }
        public List<MultiLingualProperty> Properties { get; protected set; }
        private MultiLingualsEntityFeatureDefinition(Type entityType, Type translationType) : base(entityType)
        {
            TranslationType=translationType;
            TranslationTypeFullName = translationType.FullName;
            Properties = translationType.GetProperties().Select(x => new MultiLingualProperty(x.Name)).ToList(); //EntityPropertyDefinition.CreateMany(translationType);
        }
        public static MultiLingualsEntityFeatureDefinition Default<TEntity, TTranslation>()
        {
            return new MultiLingualsEntityFeatureDefinition(typeof(TEntity), typeof(TTranslation));
        }

        public bool Equals(MultiLingualsEntityFeatureDefinition other)
        {
            return EntityTypeFullName == other?.EntityTypeFullName && TranslationTypeFullName == other?.TranslationTypeFullName;
        }
    }
}
