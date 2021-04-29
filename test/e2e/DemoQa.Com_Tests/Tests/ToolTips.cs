using Xbehave;

namespace DemoQa.Com_Tests.Tests
{
    public class ToolTips : E2ETestFixture
    {
        [Scenario]
        public void ClickAcceptAlert()
        {
            DemoQaPages.PageToolTips().NavigateTo();
            
            // is this meant to be testing anything?

            "Hover over button"
                .x(() => { DemoQaPages.PageToolTips().HoverOverButton(); });

            "Hover over field"
                .x(() => { DemoQaPages.PageToolTips().HoverOverField(); });
        }
    }
}