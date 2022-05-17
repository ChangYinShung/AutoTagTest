using FS.CmsKit.ContentComposites.Samples;
using Xunit;

namespace FS.CmsKit.ContentComposites.MongoDB.Samples;

[Collection(MongoTestCollection.Name)]
public class SampleRepository_Tests : SampleRepository_Tests<ContentCompositesMongoDbTestModule>
{
    /* Don't write custom repository tests here, instead write to
     * the base class.
     * One exception can be some specific tests related to MongoDB.
     */
}
