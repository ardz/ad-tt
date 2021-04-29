using Xbehave;

namespace DemoQa.Com_Tests.Tests
{
    /// <summary>
    /// Must click on ‘On button click, alert will appear after 5 seconds’
    /// Must accept alert
    /// </summary>
    public class Alerts : E2ETestFixture
    {
        [Scenario]
        public void ClickAcceptAlert()
        {
            DemoQaPages.PageAlerts().NavigateTo();

            "Click and accept an alert"
                .x(() => { DemoQaPages.PageAlerts().ClickAndDismissAlert(); });
        }
    }
}