using FS.Entity.EntityFeatures;
using System;

namespace FS.Entity.EntityFeatures
{
    public class DefaultEntityFeatureDefinition : EntityFeatureDefinition
    {
        //public DefaultEntityFeatureDefinition(string name) : base(name) { }
        public DefaultEntityFeatureDefinition(System.Type type) : base(type) { }

        public static DefaultEntityFeatureDefinition Default<T>()
        {
            return new DefaultEntityFeatureDefinition(typeof(T));
        }
    }
}
