using Xunit;

namespace DemoQa.Com_Tests
{
    // you need to use a collection in xunit if you want to share
    // the driver between tests, again, pros and cons
    [CollectionDefinition("E2E Test Collection")]
    public class E2ETestCollection : ICollectionFixture<E2ETestFixture>
    {
    }
}