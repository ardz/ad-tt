using Xbehave;

namespace DemoQa.Com_Tests.Tests
{
    /// <summary>
    /// Must hover over the ‘Hover me to see’ button
    /// Must hover over the ‘Hover me to see’ field
    /// </summary>
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