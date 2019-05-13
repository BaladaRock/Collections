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

        [Fact]
        public void Test_Object_Array_Contains_String_And_Int()
        {

            object a = (object)1;
            object b = (object)"Andrei";

            var array = new ObjectArray { a, b };

            Assert.Equal("Andrei", array[1]);
            Assert.Equal(2, array.Count);

        }

        [Fact]
        public void Test_Contains_When_Object_Array_of_String()
        {

            object a = (object)"Dota";
            object b = (object)"Andrei";

            var array = new ObjectArray { a, b };
            array[0] = "eu";

            Assert.True(array.Contains("eu"));
            Assert.False(array.Contains(null));
            Assert.Equal(2, array.Count);

        }

       

        [Fact]
        public void Test_IndexOf_Object_Array_of_Booleans()
        {

            var boolArray = new ObjectArray {(object)true, (object)false };
            

            Assert.False(boolArray.Contains("eu"));
            Assert.False(boolArray.Contains(null));
            Assert.Equal(0, boolArray.IndexOf(true));

        }

        [Fact]
        public void Test_Insert_Object_Mixed_Array()
        {

            var array = new ObjectArray {
                (object)true, (object)false,
                (object)"IT", (object)null,
                (object)string.Empty, (object)int.MaxValue
            };

            
            array.Insert(1, 1);
            array.Insert(4, string.Empty);

            Assert.False(array.Contains("eu"));
            Assert.True(array.Contains(null));
            Assert.Equal(0, array.IndexOf(true));
            Assert.Equal(1, array.IndexOf(1));
            Assert.Equal(8, array.Count);

        }

    }
}
