﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace CFTA.Web.Public.Pages;
public class ShopModel : CFTAPublicPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
    
}
