using Xbehave;

namespace DemoQa.Com_Tests.Tests
{
    public class ModalDialogs : E2ETestFixture
    {
        [Scenario]
        public void SelectAndCloseSmallModal()
        {
            DemoQaPages.PageModalDialogs().NavigateTo();

            // is this meant to be testing anything?

            "Select and close small modal"
                .x(() => { DemoQaPages.PageModalDialogs().OpenAndCloseModal(); });
        }
    }
}