using BookShop.WebTests.CodedUI.SearchMapClasses;

namespace BookShop.WebTests.CodedUI.Support
{
    public abstract class CodedUIStepsBase
    {
        protected SearchMap map
        {
            get { return CodedUIController.Instance.Map; }
        }
    }
}