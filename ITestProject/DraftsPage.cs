using Atata;

namespace ITestProject
{
    using _ = DraftsPage;

    public class DraftsPage : BasePage<_>
    {
        [FindByXPath("//*[@id='mesgList']/form/div[1]/span/input")]
        public CheckBox<_> FirstDraft { get; private set; }

        //[WaitFor(Until.MissingOrHidden)]
        [FindByXPath("//*[@id='fieldset1']/fieldset[3]/span")]
        public Clickable<_> DeleteBtn { get; private set; }

        //*[@class='row new']
        public ControlList<ProductItem, _> Products { get; private set; }

        [ControlDefinition("div", ContainingClass = "row new")]
        public class ProductItem : Control<_>
        {
            [FindByClass]
            public Number<_> Amount { get; private set; }
        }

    }
}
