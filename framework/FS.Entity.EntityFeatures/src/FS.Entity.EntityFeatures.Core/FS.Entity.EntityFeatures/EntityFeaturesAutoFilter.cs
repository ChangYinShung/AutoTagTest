namespace FS.Entity.EntityFeatures
{
    public class EntityFeaturesAutoFilter : AutoFilterer.Types.FilterBase
    {
        public string EntityType { get; set; }
        public string EntityId { get; set; }

        public EntityFeaturesAutoFilter(string entityType, string entityId)
        {
            EntityType =entityType;
            EntityId= entityId;
        }
        public EntityFeaturesAutoFilter(string entityType)
        {
            EntityType =entityType;
        }
    }
}
