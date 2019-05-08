
using Xunit;
using CollectionsClasses;
namespace CollectionsTests
{
    public class IntArrayFacts
    {
        private IntArray AddedArray(params int[] numbers)
        {
            IntArray array = new IntArray();
            foreach (var number in numbers)
                array.Add(number);

            return array;
        }

        [Fact]
        public void Test_Count_Should_Return_0_When_Array_Is_Empty()
        {

            var array = new IntArray();
            Assert.Equal(0, array.Count);
        }

        [Fact]
        public void Test_Count_Should_Return_Correctly_Array_Is_Full()
        {

            var array = AddedArray(1, 2, 3, 4);
            Assert.Equal(4, array.Count);
        }

        [Fact]
        public void Test_Count_Should_Return_Correctly_Array_Is_Not_Full()
        {
            var array = AddedArray(1, 2, 3);
            Assert.Equal(3, array.Count);
        }

        [Fact]
        public void Test_Count_Should_Return_Correctly_Array_Is_Larger_Then_4()
        {
            var array = AddedArray(1, 2, 3, 4, 5, 5);
            Assert.Equal(6, array.Count);
        }

        [Fact]
        public void Test_Add_Should_Correctly_Add_One_Element_For_One_Integer_Array()
        {
            var array = new IntArray();
            array.Add(1);
            Assert.Equal(1, array.Count);
        }

        [Fact]
        public void Test_Add_Should_Correctly_Add_More_Elements_For_Array()
        {
            IntArray array = AddedArray(1, 3, 6, 5, 4, 3, 8, 2, 4, 6, 6, 6);
            Assert.Equal(12, array.Count);
        }

        [Fact]
        public void Test_Element_Should_Correctly_Access_Array_For_One_Element_Array()
        {
            IntArray array = AddedArray(1);
            Assert.Equal(1, array[0]);
        }

       /* [Fact]
        public void Test_Element_Should_Return_Negative_When_Index_Is_Larger_Then_Array_Capacity()
        {
            IntArray array = AddedArray(1);
            Assert.Equal(-1, array[5]);
        }

        [Fact]
        public void Test_Element_Should_Return_Negative__When_Element_Is_Smaller_Then_0()
        {
            IntArray array = AddedArray(1);
            Assert.Equal(-1, array[-10]);
        }*/

        [Fact]
        public void Test_Element_Should_Access_Array_Correctly_For_Larger_Array()
        {
            IntArray array = AddedArray(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20, int.MaxValue);
            Assert.Equal(20, array[10]);
        }

        [Fact]
        public void Test_SetElement_Should_Set__Element_For_Simple_Array()
        {
            IntArray array = AddedArray(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20, int.MaxValue);
            array[10]=220;
            Assert.Equal(220, array[10]);
        }

        [Fact]
        public void Test_Contains_Should_Return_True_When_Array_Contains_Wanted_Value()
        {
            IntArray array = AddedArray(1, 2, 3, 4, 5, 6);

            Assert.True(array.Contains(5));
        }

        [Fact]
        public void Test_Contains_Should_Return_False_When_Array_Does_Not_Contain_Wanted_Value()
        {
            IntArray array = AddedArray(1, 2, 3, 4, 5, 6);

            Assert.False(array.Contains(10));
        }

        [Fact]
        public void Test_Contains_Should_Return_False__For_Empty_Array()
        {
            IntArray array = new IntArray();

            Assert.False(array.Contains(10));
        }

        [Fact]
        public void Test_IndexOf_Should_Return_Correct_Index_When_Array_Contains_Given_Element()
        {
            IntArray array = AddedArray(1, 2, 3, 4, 5, 6);

            Assert.Equal(3, array.IndexOf(4));
        }

        [Fact]
        public void Test_IndexOf_Should_Return_Negative_When_Array_Does_NotContains_Given_Element()
        {
            IntArray array = AddedArray(1, 2, 3, 4, 5, 6);

            Assert.Equal(-1, array.IndexOf(100));
        }

        [Fact]
        public void Test_Clear_Should_Remove_all_elements_4_elements_Array()
        {
            //Given
            IntArray array = AddedArray(1, 2, 3, 4, 5, 6);
            //When
            array.Clear();
            //Then
            Assert.Equal(0, array.Count);

        }

        [Fact]
        public void Test_Insert_Should_Correctly_Insert_Element_when_Array_Is_Shorter_Then_4()
        {
            //Given
            IntArray array = AddedArray(1, 2, 3);
            //When
            array.Insert(1, 5);
            //Then
            Assert.Equal(1, array.IndexOf(5));
        }

        [Fact]
        public void Test_Insert_Should_Correctly_Insert_Element_when_Array_Is_Longer_Then_4()
        {
            //Given
            IntArray array = AddedArray(1, 2, 3, 4, 5, 6, 7, 8);
            //When
            array.Insert(5, 100);
            //Then
            Assert.Equal(5, array.IndexOf(100));
        }

        [Fact]
        public void Test_Insert_Should_Correctly_Insert_Element_At_Middle_Position()
        {
            //Given
            IntArray array = AddedArray(1, 2, 3, 4, 5, 6, 7, 8);
            //When
            array.Insert(3, 100);
            //Then
            Assert.Equal(3, array.IndexOf(100));
            Assert.Equal(9, array.Count);
        }

        [Fact]
        public void Test_Insert_Should_Correctly_Insert_Element_At_Last_Position()
        {
            //Given
            IntArray array = AddedArray(1, 2, 3, 4);
            //When
            array.Insert(3, 100);
            //Then
            Assert.Equal(3, array.IndexOf(100));
            Assert.Equal(5, array.Count);
        }

        [Fact]
        public void Test_Insert_Should_Correctly_Insert_Element_Array_Has_Exactly_4_elements()
        {
            //Given
            IntArray array = AddedArray(1, 2, 3,4);
            //When
            array.Insert(1, 100);
            //Then
            array.Add(10);
            Assert.Equal(1, array.IndexOf(100));
            Assert.Equal(4, array.IndexOf(4));
            Assert.Equal(6, array.Count);
            
        }

      /*  [Fact]
        public void Test_Insert_Should_Correctly_Insert_Element_Index_Is_Larger_Then_Length()
        {
            //Given
            IntArray array = AddedArray(1, 2, 3, 4);
            //When
            array.Insert(900, 100);
            //Then
            Assert.Equal(1, array.IndexOf(100));
            Assert.Equal(3, array.IndexOf(4));
            Assert.Equal(4, array.Count);

        }*/


        [Fact]
        public void Test_Remove_Should_Correctly_Remove_Element_Simple_Array()
        {
            //Given
            IntArray array = AddedArray(1, 2, 3, 4);
            //When
            array.Remove(3);
            //Then
            Assert.Equal(2, array.IndexOf(4));
            Assert.Equal(-1, array.IndexOf(3));
            Assert.Equal(3, array.Count);
        }

        [Fact]
        public void Test_Remove_Should_Correctly_Remove_Element_5_Elements_Array()
        {
            //Given
            IntArray array = AddedArray(1, 2, 3, 4, 5);
            //When
            array.Remove(5);
            //Then
            Assert.Equal(-1, array.IndexOf(5));
            Assert.Equal(3, array.IndexOf(4));
            Assert.Equal(4, array.Count);
        }


        [Fact]
        public void Test_Remove_Should_Correctly_Remove_Element_1_Element_Array()
        {
            //Given
            IntArray array = AddedArray(1);
            //When
            array.Remove(1);
            //Then
            Assert.Equal(-1, array.IndexOf(1));
            Assert.Equal(0, array.Count);
        }

        [Fact]
        public void Test_RemoveAt_Should_Correctly_Remove_Element_Index_Is_1()
        {
            //Given
            IntArray array = AddedArray(1, 2, 3);
            //When
            array.RemoveAt(1);
            //Then
            Assert.Equal(-1, array.IndexOf(2));
            Assert.Equal(2, array.Count);
        }

    }
}
