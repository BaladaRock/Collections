using Xunit;
using CollectionsClasses;

namespace CollectionsTests
{
    public class ObjectEnumeratorFacts
    {
        [Fact]
        public void Test_Add_Should_Correctly_Add_Elements_Without_Explicity_Calling_Add_Method()
        {
            object a = (object)2;
            object b = (object)"Coding is hard";

            var array = new ObjectArray { a, b };

            Assert.Equal(2, array.Count);
            Assert.Equal(1, array.IndexOf("Coding is hard"));

        }



    }
}
