using FS.CmsKit.ContentDefinitions.Samples;
using Xunit;

namespace FS.CmsKit.ContentDefinitions.MongoDB.Samples;

[Collection(MongoTestCollection.Name)]
public class SampleRepository_Tests : SampleRepository_Tests<ContentDefinitionsMongoDbTestModule>
{
    /* Don't write custom repository tests here, instead write to
     * the base class.
     * One exception can be some specific tests related to MongoDB.
     */
}
