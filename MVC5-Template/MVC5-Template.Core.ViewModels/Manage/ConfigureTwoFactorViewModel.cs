using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC5_Template.Core.ViewModels.Manage
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }
    }
}
