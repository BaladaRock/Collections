using Xunit;
using CollectionsClasses;

namespace CollectionsTests
{
    public class SortedIntArrayFacts
    {

        [Fact]
        public void Test_Add_Method_Array_Should_Be_Sorted_2_elements()
        {
            //Given
            SortedIntArray array = new SortedIntArray();
            //When
            array.Add(2);
            array.Add(1);
            //Then
            Assert.Equal(1, array.IndexOf(2));
            Assert.Equal(0, array.IndexOf(1));
        }

        [Fact]
        public void Test_Add_Method_Array_Should_Be_Sorted_4_elements()
        {
            //Given
            SortedIntArray array = new SortedIntArray();
            //When
            array.Add(3);
            array.Add(1);
            array.Add(2);
            array.Add(100);
            //Then
            Assert.Equal(0, array.IndexOf(1));
            Assert.Equal(1, array.IndexOf(2));
            Assert.Equal(2, array.IndexOf(3));
            Assert.Equal(3, array.IndexOf(100));
        }

        [Fact]
        public void Test_Add_Method_Array_Should_Be_Sorted_1_Element()
        {
            //Given
            SortedIntArray array = new SortedIntArray();
            //When
            array.Add(3);
            //Then
            Assert.Equal(0, array.IndexOf(3));
        }

        [Fact]
        public void Test_Add_Method_Array_Should_Be_Sorted_When_It_Has_Repeated_Values()
        {
            //Given
            SortedIntArray array = new SortedIntArray();
            //When
            array.Add(1);
            array.Add(1);
            array.Add(1);
            array.Add(1);
            //Then
            Assert.Equal(0, array.IndexOf(1));
            Assert.Equal(-1, array.IndexOf(2));
        }

        [Fact]
        public void Test_Insert_Method_Should_Insert_Element_When_Resulting_Array_Is_Sorted()
        {
            //Given
            SortedIntArray array = new SortedIntArray();
            //When
            array.Add(1);
            array.Add(4);
            array.Add(6);
            array.Add(8);
            array.Insert(2, 5);
            //Then
            Assert.Equal(2, array.IndexOf(5));
            Assert.Equal(5, array.Count);
        }

        [Fact]
        public void Test_Insert_Method_Should_Not_Insert_Element_When_Resulting_Array_Is_Unsorted()
        {
            //Given
            SortedIntArray array = new SortedIntArray();
            //When
            array.Add(1);
            array.Add(4);
            array.Add(6);
            array.Add(8);
            array.Insert(2, 100);
            //Then
            Assert.Equal(-1, array.IndexOf(100));
            Assert.Equal(4, array.Count);
        }

        [Fact]
        public void Test_Insert_Method_Should__Insert_For_Empty_Array()
        {
            //Given
            SortedIntArray array = new SortedIntArray();
            //When
            array.Insert(0, 100);
            //Then
            Assert.Equal(0, array.IndexOf(100));
            Assert.Equal(1, array.Count);
        }

        [Fact]
        public void Test_Get_Should_Get__Element_For_Simple_Array()
        {
            var array = new SortedIntArray();

            array.Add(1);
            array.Add(5);
            array.Add(10);

            Assert.Equal(5, array[1]);
        }

        [Fact]
        public void Test_Set_Should_Set_When_Resulted_Array_Is_Sorted()
        {
            var array = new SortedIntArray();
            array.Add(1);
            array.Add(5);
            array.Add(10);
            array[1] = 3;
            Assert.Equal(3, array[1]);
        }

        [Fact]
        public void Test_Set_Should_Not_Set__Element_When_Resulted_Array_Is_Not_Sorted()
        {
            var array = new SortedIntArray();
            array.Add(1);
            array.Add(5);
            array.Add(10);
            array[1] = 100;
            Assert.Equal(5, array[1]);
        }

        [Fact]
        public void Test_Set_Should__Set__Element_Array_Has_Repeated_Values()
        {
            var array = new SortedIntArray();
            array.Add(2);
            array.Add(2);
            array.Add(2);
            array[1] = 2;
            Assert.Equal(2, array[1]);
        }

        [Fact]
        public void Test_Set_Should__Set__Element_Array_Has_Two_Elements_and_Repeated_Values()
        {
            var array = new SortedIntArray();
            array.Add(4);
            array.Add(4);
            array[1] = 4;
            Assert.Equal(4, array[1]);
        }

        [Fact]
        public void Test_Set_Should_Not_Set__Element_Array_Has_Two_Elements()
        {
            var array = new SortedIntArray();
            array.Add(4);
            array.Add(4);
            array[1] = 3;
            Assert.Equal(4, array[1]);
        }

        [Fact]
        public void Test_Set_Should_Set_Element_Array_Has_One_Element()
        {
            var array = new SortedIntArray();
            array.Add(4);
            array[0] = 3;
            Assert.Equal(3, array[0]);
        }

        [Fact]
        public void Test_Set_Should_Set_Element_Empty_Array()
        {
            var array = new SortedIntArray();
            array[0] = 3;
            Assert.Equal(3, array[0]);
        }
    }
}
