﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by YinChang.
// 5.1.3
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

namespace FS.CmsKit.ContentComposites.Dtos
{
    public partial class AttachmentCompositeJsonSubtypesConverterProfile : FS.Abp.JsonSubTypes.JsonSubtypesConverterProfile
    {
        public AttachmentCompositeJsonSubtypesConverterProfile()
        {
            this.CreateJsonSubtypesConverter<ContentComponentDto>("ContentComponentDiscriminator")
                .RegisterSubtype<FS.CmsKit.ContentComposites.Dtos.AttachmentCompositeDto>("AttachmentComposite")
                ;

            this.CreateJsonSubtypesConverter<ContentComponentCreateDto>("ContentComponentDiscriminator")
                .RegisterSubtype<FS.CmsKit.ContentComposites.Dtos.AttachmentCompositeCreateDto>("AttachmentComposite")
                ;

            this.CreateJsonSubtypesConverter<ContentComponentUpdateDto>("ContentComponentDiscriminator")
                .RegisterSubtype<FS.CmsKit.ContentComposites.Dtos.AttachmentCompositeUpdateDto>("AttachmentComposite")
                ;

            this.CreateJsonSubtypesConverter<ContentComponentGetListDto>("ContentComponentDiscriminator")
                .RegisterSubtype<FS.CmsKit.ContentComposites.Dtos.AttachmentCompositeGetListDto>("AttachmentComposite")
                ;

            this.CreateJsonSubtypesConverter<ContentComponentWithDetailsDto>("ContentComponentDiscriminator")
                .RegisterSubtype<FS.CmsKit.ContentComposites.Dtos.AttachmentCompositeWithDetailsDto>("AttachmentComposite")
                ;

        }
    }

}