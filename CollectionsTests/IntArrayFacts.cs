using System;
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
            {
                array.Add(number);
            }

            return array;
        }

        [Fact]
        public void Test_Count_Should_Return_0_When_Array_Is_Empty()
        {

            var array = new IntArray();
            Assert.Equal(0, array.Count());
        }

        [Fact]
        public void Test_Count_Should_Return_Correctly_Array_Is_Full()
        {

            var array = AddedArray(1, 2, 3, 4);
            Assert.Equal(4, array.Count());
        }

        [Fact]
        public void Test_Count_Should_Return_Correctly_Array_Is_Not_Full()
        {
            var array = AddedArray(1, 2, 3);
            Assert.Equal(3, array.Count());
        }

        [Fact]
        public void Test_Count_Should_Return_Correctly_Array_Is_Larger_Then_4()
        {
            var array = AddedArray(1, 2, 3, 4, 5, 5);
            Assert.Equal(6, array.Count());
        }

        [Fact]
        public void Test_Add_Should_Correctly_Add_One_Element_For_One_Integer_Array()
        {
            var array = new IntArray();
            array.Add(1);
            Assert.Equal(1, array.Count());
        }

        [Fact]
        public void Test_Add_Should_Correctly_Add_More_Elements_For_Array()
        {
            IntArray array = AddedArray(1, 3, 6, 5, 4, 3, 8, 2, 4, 6, 6, 6); 
            Assert.Equal(12, array.Count());
        }

        [Fact]
        public void Test_Element_Should_Correctly_For_One_Element_Array()
        {
            IntArray array = AddedArray(1);
            Assert.Equal(1, array.Element(0));
        }

        [Fact]
        public void Test_Element_Should_Correctly_When_Element_Is_Larger_Then_Array_Capacity()
        {
            IntArray array = AddedArray(1);
            Assert.Equal(-1, array.Element(5));
        }

        [Fact]
        public void Test_Element_Should_Correctly_When_Element_Is_Smaller_Then_0()
        {
            IntArray array = AddedArray(1);
            Assert.Equal(-1, array.Element(-10));
        }

        [Fact]
        public void Test_Element_Should_Correctly_For_Larger_Array()
        {
            IntArray array = AddedArray(1,2,3,4,5,6,7,8,9,10,20,int.MaxValue);
            Assert.Equal(20, array.Element(10));
        }

        [Fact]
        public void Test_SetElement_Should_Set__Element_For_Simple_Array()
        {
            IntArray array = AddedArray(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20, int.MaxValue);
            array.SetElement(10, 220);
            Assert.Equal(220, array.Element(10));
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
    }
}
