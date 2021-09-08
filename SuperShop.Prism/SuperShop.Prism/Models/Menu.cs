using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.Prism.Models
{
    public class Menu
    {
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }

        public bool IsLoginRequired { get; set; }
    }
}
