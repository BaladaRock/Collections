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

            var stringArray = new ObjectArray();
            stringArray.Add(true);
            stringArray.Add(false);

            Assert.False(stringArray.Contains("eu"));
            Assert.False(stringArray.Contains(null));
            Assert.Equal(0, stringArray.IndexOf(true));

        }

        [Fact]
        public void Test_Insert_Object_Mixed_Array()
        {

            var stringArray = new ObjectArray();
            stringArray.Add(true);
            stringArray.Add(false);
            stringArray.Add("IT");
            stringArray.Add(null);
            stringArray.Add(string.Empty);
            stringArray.Add(int.MaxValue);
            stringArray.Insert(1, 1);
            stringArray.Insert(4, string.Empty);

            Assert.False(stringArray.Contains("eu"));
            Assert.True(stringArray.Contains(null));
            Assert.Equal(0, stringArray.IndexOf(true));
            Assert.Equal(1, stringArray.IndexOf(1));
            Assert.Equal(8, stringArray.Count);

        }
        
    }
}
