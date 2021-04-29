using Xbehave;

namespace DemoQa.Com_Tests.Tests
{
    /// <summary>
    /// Must select ‘Small modal’ button
    /// Must close the modal
    /// </summary>
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