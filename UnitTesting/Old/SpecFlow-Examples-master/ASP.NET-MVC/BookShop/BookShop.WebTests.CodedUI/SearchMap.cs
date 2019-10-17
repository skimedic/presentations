namespace BookShop.WebTests.CodedUI.SearchMapClasses
{
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Input;
    using System.CodeDom.Compiler;
    using System.Text.RegularExpressions;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;


    public partial class SearchMap
    {

        private string _homeUrl;

        public void Search(string searchTerm)
        {
            HtmlEdit searchInputControl = this.ShopHome.DocumentSearch.SearchTerm;

            searchInputControl.Text = searchTerm;

            Keyboard.SendKeys(searchInputControl, "{Enter}", ModifierKeys.None);
        }


        public void Home()
        {
            this.BlankWindow.LaunchUrl(new System.Uri(_homeUrl));
        }

        
        public SearchMap(string homeUrl)
        {
            _homeUrl = homeUrl;
        }

    }
}

