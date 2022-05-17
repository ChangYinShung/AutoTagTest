using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace FS.CmsKit.ContentDefinitions;

public class ContentDefinitionsAppService_Tests : ContentDefinitionsApplicationTestBase
{
    private readonly V1.IContentDefinitionCrudAppService ContentDefinitionCrudAppService;
    private readonly V1.IContentPartDefinitionCrudAppService ContentPartDefinitionCrudAppService;
    private readonly V1.IContentTypeDefinitionCrudAppService ContentTypeDefinitionCrudAppService;

    public ContentDefinitionsAppService_Tests()
    {
        ContentDefinitionCrudAppService = GetRequiredService<V1.IContentDefinitionCrudAppService>();
        ContentPartDefinitionCrudAppService=GetRequiredService<V1.IContentPartDefinitionCrudAppService>();
        ContentTypeDefinitionCrudAppService=GetRequiredService<V1.IContentTypeDefinitionCrudAppService>();
    }

    [Fact]
    public async Task Should_Create_ContentDefinition()
    {
        await ContentDefinitionCrudAppService.CreateAsync(new Dtos.ContentDefinitionCreateDto()
        {
            Version="Default_Test"
        });

        (await ContentDefinitionCrudAppService.GetListAsync(new Dtos.ContentDefinitionGetListDto()
        {
            MaxResultCount=10
        })).TotalCount.ShouldBeGreaterThan(1);
    }

    [Fact]
    public async Task Should_Throw_Exception_When_Create_The_Same_ContentDefinition_Version()
    {
        await Assert.ThrowsAsync<DuplicateContentDefinitionVersionException>(async () =>
        {
            await ContentDefinitionCrudAppService.CreateAsync(new Dtos.ContentDefinitionCreateDto()
            {
                Version="Default"
            });
        });
    }

    [Fact]
    public async Task Should_Patch_ContentType_And_ContentPart_Definitions()
    {
        var contentDefinition = (await ContentDefinitionCrudAppService.GetListAsync(new Dtos.ContentDefinitionGetListDto()
        {
            MaxResultCount=10
        })).Items.First();

        var contentPartDefinitionDto = await this.ContentPartDefinitionCrudAppService.PatchAsync(new Dtos.V1.ContentPartDefinitionPatchDto
        {
            ContentDefinitionId=contentDefinition.Id,
            Name="AboutUs",
            TextTemplateContentName="Hello",
            Type="Hello"
        });

        await this.ContentTypeDefinitionCrudAppService.PatchAsync(new Dtos.V1.ContentTypeDefinitionPatchDto
        {
            ContentDefinitionId=contentDefinition.Id,
            EntityType="Volo.CmsKit.Blogs.Page",
            EntityId="123",
            ContentPartDefinitionIds=new System.Collections.Generic.List<System.Guid>() { contentPartDefinitionDto.Id }
        });


        var result = await this.ContentDefinitionCrudAppService.GetAsync(contentDefinition.Id);

        result.ContentTypeDefinitions[0].ContentTypePartDefinitions.Count.ShouldBeGreaterThan(0);

        result.ContentPartDefinitions[0].ContentPartFieldDefinitions.Count.ShouldBeGreaterThan(0);

        



    }

   

}
