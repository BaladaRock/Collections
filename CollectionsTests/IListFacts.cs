using Xunit;
using CollectionsClasses;

namespace CollectionsTests
{
     public class IListFacts
     {
         [Fact]
         public void Test_Swap_Method_For_List_Of_Integers()
         {
            var intList = new List<int> { 3, 4 };
            var (a, b) = List<int>.Swap(intList[0], intList[1]);
            intList[0] = a;
            intList[1] = b;
            Assert.Equal(1, intList.IndexOf(3));
         }

        [Fact]
        public void Test_Remove_Method_For_List_Of_Integers()
        {
            var intList = new List<int> { 3, 4 };
            var checkRemove = intList.Remove(3);

            Assert.True(checkRemove);
            Assert.Equal(4, intList[0]);
            Assert.Equal(-1, intList.IndexOf(3));
        }

        [Fact]
        public void Test_Remove_Should_Return_False_When_Item_Does_Not_Exist()
        {
            var intList = new List<int> { 1, 2 };
            var checkRemove = intList.Remove(100);

            Assert.False(checkRemove);
            Assert.Equal(1, intList[0]);
            Assert.Equal(-1, intList.IndexOf(3));
        }

        [Fact]
        public void Test_Remove_Should_Return_False_When_List_Is_Empty()
        {
            var intList = new List<int>();
            var checkRemove = intList.Remove(100);

            Assert.False(checkRemove);
            Assert.Equal(-1, intList.IndexOf(3));
        }

        [Fact]
        public void Test_IsReadOnly_Should_Return_False_When_List_Is_Empty()
        {
            var intList = new List<int>();

            Assert.False(intList.IsReadOnly);
            Assert.Equal(-1, intList.IndexOf(3));
        }

        [Fact]
        public void Copy_List_To_Array_When_Array_Has_Enough_Capacity()
        {
            //Given
            var intList = new List<int> { 1, 2, 3 };
            int[] array = new int[10];
            array[0] = 1;
            array[1] = 2;
            array[2] = 3;
            //When
            intList.CopyTo(array, 3);
            //Then
            Assert.Equal(1, array[3]);
            Assert.Equal(2, array[4]);
            Assert.Equal(3, array[5]);
            //Check if part before and after index has remained unchanged
            Assert.Equal(0, array[6]);
            Assert.Equal(1, array[0]);
            Assert.Equal(3, array[2]);
        }

        [Fact]
        public void Copy_List_To_Array_When_Array_Does_Not_Have_Enough_Capacity()
        {
            //Given
            var intList = new List<int> { 1, 2, 3 };
            int[] array = new int[5];
            array[0] = 1;
            array[1] = 2;
            array[2] = 3;
            //When
            intList.CopyTo(array, 3);
            //Then
            Assert.Equal(0, array[3]);
            Assert.Equal(0, array[4]);
            //Check if part before and after index has remained unchanged
            Assert.Equal(2, array[1]);
            Assert.Equal(1, array[0]);
            Assert.Equal(3, array[2]);
        }

        [Fact]
        public void Copy_List_To_Array_For_Empty_Array()
        {
            //Given
            var intList = new List<int> { 1, 2, 3 };
            int[] array = new int[2];
            //When
            intList.CopyTo(array, 3);
            //Then
            Assert.Equal(0, array[1]);
            Assert.Equal(0, array[0]);
        }

        [Fact]
        public void Copy_List_To_Array_When_Index_Is_Smaller_Then_0()
        {
            //Given
            var intList = new List<int> { 1, 2, 3 };
            int[] array = new int[5];
            array[0] = 1;
            array[1] = 2;
            array[2] = 3;
            //When
            intList.CopyTo(array, -2);
            //Then
            Assert.Equal(0, array[3]);
            Assert.Equal(0, array[4]);
            //Check if part before and after index has remained unchanged
            Assert.Equal(2, array[1]);
            Assert.Equal(1, array[0]);
            Assert.Equal(3, array[2]);
        }

        [Fact]
        public void Copy_List_To_Array_When_Array_Is_Empty()
        {
            //Given
            var intList = new List<int> { 1, 2, 3 };
            int[] array = new int[1];
            //When
            intList.CopyTo(array, 0);
            //Then
            Assert.Equal(0, array[0]);
            
        }


    }
}
