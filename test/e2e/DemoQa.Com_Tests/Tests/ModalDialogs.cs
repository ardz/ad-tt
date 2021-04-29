using System.Reflection;
using Xbehave;
using Xunit;

namespace DemoQa.Com_Tests.Tests
{
    public class ModalDialogs : E2ETestFixture
    {
        [Scenario]
        public void SelectAndCloseSmallModal()
        {
            DemoQaPages.PageDroppable().NavigateTo();

            // is this meant to be testing anything?

            "Perform drag and drop"
                .x(() =>
                {
                    DemoQaPages.PageDroppable().DragAndDrop();
                    Assert.True(DemoQaPages.PageDroppable().DropSuccessful());
                });
        }
    }
}