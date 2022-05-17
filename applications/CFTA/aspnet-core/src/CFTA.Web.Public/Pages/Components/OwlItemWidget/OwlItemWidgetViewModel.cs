using System;

namespace CFTA.Web.Public.Components.OwlItemWidget
{

    public enum DisplayStyleEnum
    {
            Profile = 0,
            Artist=1,
            Banner=2,
            SportsProfile = 3
    }
    public class OwlItemCountdownWidgetViewModel
    {

        public DisplayStyleEnum DisplayStyle { get; set; }
        public string Title { get; set; } 
        public string CssClass { get; set; } 
        public Guid? MediaId { get; set; }
        public string LinkUrl { get; set; }
    }
}
