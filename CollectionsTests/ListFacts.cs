using Xunit;
using CollectionsClasses;

namespace CollectionsTests
{
    public class ListFacts
    {
        [Fact]
        public void Test_List_Of_String_Objects()
        {
            var stringList = new List<string>();

            stringList.Add("Andrei");
            stringList.Add("1");
            
            Assert.Equal("Andrei", stringList[0]);
            Assert.Equal(2, stringList.Count);
        }

        [Fact]
        public void Test_Longer_List_Of_String_Objects_With_Null_Value()
        {
            var objectsList = new List<string>
            {
                "Andrei",
                "1",
                "Dota",
                "PSD",
                string.Empty
            };

            objectsList.Insert(3, null);
            Assert.Equal("Andrei", objectsList[0]);
            Assert.True(objectsList.Contains(null));
            Assert.Equal(6, objectsList.Count);
        }

        [Fact]
        public void Test_Contains_List_of_Integers()
        {
            var intList = new List<int>();
            intList.Add(123);
            intList.Add(int.MaxValue);
            intList[1] = int.MaxValue;

            Assert.True(intList.Contains(123));
            Assert.False(intList.Contains(int.MinValue));
            Assert.Equal(2, intList.Count);
        }

        [Fact]
        public void Test_IndexOf_List_of_Booleans()
        {
            var boolValues = new List<bool>
            {
                true,
                false
            };

            Assert.True(boolValues.Contains(false));
            Assert.True(boolValues.Contains(true));
            Assert.Equal(0, boolValues.IndexOf(true));

        }

        [Fact]
        public void Test_More_Complex_List_Of_Objects()
        {
            var listOfObjects = new List<object>();
            listOfObjects.Add(true);
            listOfObjects.Add(false);
            listOfObjects.Add("IT");
            listOfObjects.Add(null);
            listOfObjects.Add(string.Empty);
            listOfObjects.Add(int.MaxValue);
            listOfObjects.Insert(1, 1);
            listOfObjects.Insert(4, string.Empty);

            Assert.False(listOfObjects.Contains("eu"));
            Assert.True(listOfObjects.Contains(null));
            Assert.Equal(0, listOfObjects.IndexOf(true));
            Assert.Equal(1, listOfObjects.IndexOf(1));
            Assert.Equal(8, listOfObjects.Count);
        }
    }
}
