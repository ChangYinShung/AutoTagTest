using System.Threading.Tasks;
using Volo.Abp.TextTemplating;
using Xunit;

namespace FS.CmsKit.ContentDefinitions.Samples;

public class SampleManager_Tests : ContentDefinitionsDomainTestBase
{

    protected ITemplateDefinitionManager templateDefinitionManager;
    //private readonly SampleManager _sampleManager;

    public SampleManager_Tests()
    {
        templateDefinitionManager = GetRequiredService<ITemplateDefinitionManager>();
    }

    [Fact]
    public async Task Method1Async()
    {
        var templates = templateDefinitionManager.GetAll();
    }
}
