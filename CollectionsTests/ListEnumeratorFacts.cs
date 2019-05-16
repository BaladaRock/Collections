using Xunit;
using CollectionsClasses;

namespace CollectionsTests
{
    public class ListEnumeratorFacts
    {
        [Fact]
        public void Test_Enumerator_For_List_Of_Objects()
        {
            //Given
            var list = new List<object> {
                true, false,
                "IT", null,
                string.Empty,
                int.MaxValue
            };

            list.Insert(1, 1);
            list.Insert(4, string.Empty);

            //When
            var enumerator = list.GetEnumerator();

            for (int i = 0; i < 8; i++)
                enumerator.MoveNext();

            var getCurrent = enumerator.Current;

            //Then
            Assert.Equal(int.MaxValue, getCurrent);
            Assert.False(list.Contains("eu"));
            Assert.True(list.Contains(null));
            Assert.Equal(0, list.IndexOf(true));
            Assert.Equal(1, list.IndexOf(1));
            Assert.Equal(8, list.Count);
        }

        [Fact]
        public void Test_Enumerator_For_List_Of_3_Booleans()
        {
            var array = new List<bool> { true, false, false };
            var enumerator = array.GetEnumerator();/*new ObjectEnumerator(array)*/
            enumerator.MoveNext();
            enumerator.MoveNext();
            var getCurrent = enumerator.Current;

            Assert.False(getCurrent);
            Assert.Equal(0, array.IndexOf(true));
        }

        [Fact]
        public void Test_Enumerator_For_List_Of_2_Strings()
        {
            var list = new List<string> { "DOTA", "Witcher"};
            var enumerator = list.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal("DOTA", enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal("Witcher", enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void Test_Current_Property_For_Int_Array_List()
        {
            //Given
            int[] a = new int[] { 1, 2, 3 };
            int[] b = new int[] { -2, 0, 44 };
            int[] newArray = new int[] { 1, 1, 1 };
            //When
            var array = new List<int[]> { a, b };
            array[0] = newArray;

            var enumerator = array.GetEnumerator();
            //Then
            Assert.True(enumerator.MoveNext());
            Assert.Equal(newArray, enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(b, enumerator.Current);
            Assert.False(enumerator.MoveNext());

        }

        [Fact]
        public void Test_Empty_List()
        {
            //Given
            var array = new List<int>();
            //When
            var enumerator = array.GetEnumerator();
            //Then
            Assert.False(enumerator.MoveNext());

            // This section will be tested only after implementing Throw() Exceptions
            //Assert.Null(enumerator.Current);
            //When
            // ObjectEnumerator.Reset() method can only be used when using an auxiliary class
            // to implement the enumerating attribute.
            // enumerator.Reset();
            //Then
            //Assert.Null(enumerator.Current);
        }

    }
}