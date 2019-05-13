using Xunit;
using CollectionsClasses;

namespace CollectionsTests
{
    public class ObjectArrayFacts
    {
        [Fact]
        public void Test_Object_Array_Contains_String_And_Int()
        {

            var mixedArray = new ObjectArray();
            mixedArray.Add("Andrei");
            mixedArray.Add(1);

            Assert.Equal("Andrei", mixedArray[0]);
            Assert.Equal(2, mixedArray.Count);

        }

        [Fact]
        public void Test_Set_Object_Array_of_String()
        {

            var stringArray = new ObjectArray();
            stringArray.Add("Andrei");
            stringArray.Add("Dota");

            stringArray[0] = "eu";
            Assert.Equal("eu", stringArray[0]);
            Assert.Equal(2, stringArray.Count);

        }

        [Fact]
        public void Test_Contains_Object_Array_of_String()
        {

            var stringArray = new ObjectArray();
            stringArray.Add("Andrei");
            stringArray.Add("Dota");

            stringArray[0] = "eu";
            Assert.True(stringArray.Contains("eu"));
            Assert.False(stringArray.Contains(null));
            Assert.Equal(2, stringArray.Count);

        }

        [Fact]
        public void Test_IndexOf_Object_Array_of_Booleans()
        {

            var boolArray = new ObjectArray();
            boolArray.Add(true);
            boolArray.Add(false);

            Assert.False(boolArray.Contains("eu"));
            Assert.False(boolArray.Contains(null));
            Assert.Equal(0, boolArray.IndexOf(true));

        }

        [Fact]
        public void Test_Insert_Object_Mixed_Array()
        {

            var mixedArray = new ObjectArray();
            mixedArray.Add(true);
            mixedArray.Add(false);
            mixedArray.Add("IT");
            mixedArray.Add(null);
            mixedArray.Add(string.Empty);
            mixedArray.Add(int.MaxValue);
            mixedArray.Insert(1, 1);
            mixedArray.Insert(4, string.Empty);

            Assert.False(mixedArray.Contains("eu"));
            Assert.True(mixedArray.Contains(null));
            Assert.Equal(0, mixedArray.IndexOf(true));
            Assert.Equal(1, mixedArray.IndexOf(1));
            Assert.Equal(8, mixedArray.Count);

        }
        
    }
}
