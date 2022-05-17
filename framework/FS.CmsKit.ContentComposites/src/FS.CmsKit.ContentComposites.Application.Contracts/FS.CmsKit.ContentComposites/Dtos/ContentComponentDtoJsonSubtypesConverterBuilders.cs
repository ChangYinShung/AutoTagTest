
namespace FS.CmsKit.ContentComposites.Dtos
{
    namespace V1
    {
        public partial class ContentComponentJsonSubtypesConverterProfile : FS.Abp.JsonSubTypes.JsonSubtypesConverterProfile
        {
            public ContentComponentJsonSubtypesConverterProfile()
            {


                this.CreateJsonSubtypesConverter<V1.ContentComponentPatchDto>("ContentComponentDiscriminator")
                    .RegisterSubtype<FS.CmsKit.ContentComposites.Dtos.V1.ContentItemPatchDto>("ContentItem")
                    .RegisterSubtype<FS.CmsKit.ContentComposites.Dtos.V1.ContentCompositePatchDto>("ContentComposite")
                    ;

            }
        }
    }


}
