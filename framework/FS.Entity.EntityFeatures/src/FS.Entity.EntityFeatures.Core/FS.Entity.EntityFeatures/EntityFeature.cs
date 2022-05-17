using System.Collections.Generic;

namespace FS.Entity.EntityFeatures
{
    public class EntityFeature
    {
        public string Name { get; set; }
        public List<EntityFeatureDefinition> Definitions { get; set; }
    }

    public abstract class EntityFeatureDefinition
    {
        public System.Type EntityType;

        public EntityFeatureDefinition(System.Type type)
        {
            EntityType=type;
            EntityTypeFullName = type.FullName;
        }

        public string EntityTypeFullName { get; protected set; }
    }
}
