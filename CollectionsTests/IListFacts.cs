using Xunit;
using CollectionsClasses;
using System;

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
            Assert.Equal(0, intList.IndexOf(4));
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
        public void Test_Exception_For_Remove_Method_List_Is_ReadOnly()
        {
            var intList = new List<int>();
            var roList = intList.AsReadOnly();
            //When
            var checkRemove = Assert.Throws<NotSupportedException>(() => roList.Remove(100));
            //Then
            Assert.False(intList.IsReadOnly);
            Assert.True(roList.IsReadOnly);
            Assert.Equal("List is readonly!", checkRemove.Message);
        }

        [Fact]
        public void Test_Exception_For_RemoveAt_Method_Index_Is_Not_Valid()
        {
            var intList = new List<int> { 1, 2, 3, 4 };

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => intList.RemoveAt(100));

            Assert.Equal("index", exception.ParamName);
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
            ArgumentException error = Assert.Throws<ArgumentException>(() => intList.CopyTo(array, 3));
            //Then
            Assert.Equal("array", error.ParamName);
        }

        [Fact]
        public void Copy_List_To_Array_For_Empty_Array()
        {
            //Given
            var intList = new List<int> { 1, 2, 3 };
            int[] array = new int[2];
            //When
            Exception error = Assert.Throws<ArgumentException>(() => intList.CopyTo(array, 3));
            //Then
            Assert.Equal(0, array[1]);
            Assert.Equal(0, array[0]);
            Assert.Equal("Given index does not exist!\r\nParameter name: arrayIndex", error.Message);
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
            Exception error = Assert.Throws<ArgumentOutOfRangeException>(() => intList.CopyTo(array, -2));
            //Then
            Assert.Equal("Index does not exist!\r\nParameter name: arrayIndex", error.Message);
        }

        [Fact]
        public void Copy_List_To_Array_When_Array_Is_Empty()
        {
            //Given
            var intList = new List<int> { 1, 2, 3 };
            int[] array = new int[0];
            //When
            var error = Assert.Throws<ArgumentException>(() => intList.CopyTo(array, 0));
            //Then
            Assert.Equal("arrayIndex", error.ParamName);
        }

        [Fact]
        public void Copy_List_To_Array_When_Array_Is_Null()
        {
            //Given
            var intList = new List<int> { 1, 2, 3 };
            int[] array = null;
            //When
            var error = Assert.Throws<ArgumentNullException>(() => intList.CopyTo(array, 0));
            //Then
            Assert.Equal("array", error.ParamName);
        }

        [Fact]
        public void Test__Get_Element_When_Index_Is_0()
        {
            //Given
            var intList = new List<int> { 1, 2, 3};
            //Then
            Assert.Equal(1, intList[0]);
        }

        [Fact]
        public void Test_Exception_Get_Element_When_List_Is_Empty()
        {
            //Given
            var intList = new List<int>();
            //When
            var exception = Assert.Throws<ArgumentException>(() => intList[0]);
            //Then
            Assert.Equal("List is empty!", exception.Message);
        }

        [Fact]
        public void Test_Exception_Get_Element_When_List_Is_ReadOnly()
        {
            //Given
            var intList = new List<int> { 1, 2, 3 };
            //When
            var readOnly = intList.AsReadOnly();
            //Then
            Assert.Equal(2, readOnly[1]);
        }

        [Fact]
        public void Test_Exception_Get_Element_When_Index_Is_Larger_Then_List_Capacity()
        {
            //Given
            var intList = new List<int> { 1, 2, 3 };
            //When
            var error = Assert.Throws<ArgumentOutOfRangeException>(() => intList[7]);
            //Then
            Assert.Equal("Index does not exist!\r\nParameter name: index", error.Message);
        }

        [Fact]
        public void Test_Exception_Get_Element_When_Index_Is_Smaller_Then_0()
        {
            //Given
            var intList = new List<int> { 1, 2, 3 };
            //When
            var error = Assert.Throws<ArgumentOutOfRangeException>(() => intList[-4]);
            //Then
            Assert.Equal("Index does not exist!\r\nParameter name: index", error.Message);
        }

        [Fact]
        public void Test_Exception_Set_Element_When_Index_Is_Smaller_Then_0()
        {
            //Given
            var intList = new List<int> { 1, 2, 3 };
            //When
            var error = Assert.Throws<ArgumentOutOfRangeException>(() => intList[-4] = 3);
            //Then
            Assert.Equal("Index does not exist!\r\nParameter name: index", error.Message);
        }

        [Fact]
        public void Test_Exception_Set_Element_Should_Throw_Exception_For_ROList()
        {
            //Given
            var intList = new List<int> { 1, 2, 3 };
            var ro = intList.AsReadOnly();
            //When
            var error = Assert.Throws<NotSupportedException>(() => ro[2] = 3);
            //Then
            Assert.Equal("List is readonly!", error.Message);
        }

        [Fact]
        public void Test_Insert_Should_Correctly_Insert_Element_For_Empty_List()
        {
            //Given
            var list = new List<string>();
            //When
            list.Insert(0, "Andrei");
            //Then
            Assert.Single(list);
            Assert.Equal("Andrei", list[0]);
        }

        [Fact]
        public void Test_Exception_For_Insert_Method_Index_Is_Smaller_Then_0()
        {
            //Given
            var intList = new List<int> { 1, 2, 3, 4, 5 };
            //When
            var error = Assert.Throws<ArgumentOutOfRangeException>(() => intList.Insert(-4, 3));
            //Then
            Assert.Null(error.ActualValue);
        }

        [Fact]
        public void Test_Exception_For_Insert_Method_Index_Is_Greater_Then_Count()
        {
            //Given
            var intList = new List<int> { 1, 2, 3, 4, 5 };
            //When
            var error = Assert.Throws<ArgumentOutOfRangeException>(() => intList.Insert(100, 3));
            //Then
            Assert.Equal("index", error.ParamName);
        }

        [Fact]
        public void Test_Exception_For_Insert_Method_List_Is_ReadOnly()
        {
            //Given
            var intList = new List<int> { 1, 2, 3, 4, 5 };
            List<int> readOnly = intList.AsReadOnly();
            //When
            intList.Insert(2, 100);
            var exception = Assert.Throws<NotSupportedException>(() => readOnly.Insert(2, 100));
            //Then
            Assert.Equal("List is readonly!", exception.Message);
            Assert.Equal(100, intList[2]);
            Assert.Equal(6, intList.Count);
            Assert.Equal(3, readOnly[2]);
            Assert.Equal(5, readOnly.Count);
        }

        [Fact]
        public void Test_Exception_For_Add_Method_List_Is_ReadOnly()
        {
            //Given
            var intList = new List<int> { 1, 2, 3, 4, 5 };
            var ro = intList.AsReadOnly();
            //When
            var error = Assert.Throws<NotSupportedException>(() => ro.Add(7));
            //Then
            Assert.Equal("List is readonly!", error.Message);
            Assert.Equal(5, ro.Count);
            Assert.Equal(5, intList.Count);
        }

        [Fact]
        public void Test_Clear_Method_Should_Clear_List()
        {
            //Given
            var intList = new List<int> { 1, 2, 3 };
            //When
            intList.Clear();
            var exception = Assert.Throws<ArgumentException>(() => intList[0]);
            //Then
            Assert.Empty(intList);
            Assert.Equal("List is empty!", exception.Message);
        }

        [Fact]
        public void Test_Exception_For_Clear_Method_List_Is_ReadOnly()
        {
            //Given
            var intList = new List<int> { 1, 2, 3 };
            var ro = intList.AsReadOnly();
            //When
            var error = Assert.Throws<NotSupportedException>(() => ro.Clear());
            //Then
            Assert.Equal("List is readonly!", error.Message);
        }

        [Fact]
        public void Test_ReadOnly_property_Should_return_TRUE()
        {
            var list = new List<string> { "a", "b", "c" };
            var readOnly = list.AsReadOnly();
            Assert.True(readOnly.IsReadOnly);
            Assert.False(list.IsReadOnly);
        }

        [Fact]
        public void Test_ReadOnly_property_Should_return_FALSE()
        {
            var list = new List<string> { "a", "b", "c" };
            //Then
            Assert.False(list.IsReadOnly);
        }
    }
}
