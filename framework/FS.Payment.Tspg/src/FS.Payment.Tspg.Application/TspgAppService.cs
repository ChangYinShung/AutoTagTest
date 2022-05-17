using System;
using System.Collections.Generic;
using System.Text;
using FS.Payment.Tspg.Localization;
using Volo.Abp.Application.Services;

namespace FS.Payment.Tspg;

/* Inherit your application services from this class.
 */
public abstract class TspgAppService : ApplicationService
{
    protected TspgAppService()
    {
        LocalizationResource = typeof(TspgResource);
    }
}
