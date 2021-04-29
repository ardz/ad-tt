using Xbehave;
using Xunit;

namespace DemoQa.Com_Tests.Tests
{
    /// <summary>
    /// Must drag and drop the ‘Drag me’ element into the specified area
    /// </summary>
    public class DragAndDrop : E2ETestFixture
    {
        [Scenario]
        public void CheckElementCanBeDraggedAndDropped()
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