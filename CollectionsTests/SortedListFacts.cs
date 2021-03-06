﻿using Xunit;
using CollectionsClasses;

namespace CollectionsTests
{
    public class SortedListFacts
    {
        [Fact]
        public void Test_Add_Method_IntList_Should_Be_Sorted_2_elements()
        {
            //Given
            SortedList<int> array = new SortedList<int>
            {
                2,
                1
            };
            //Then
            Assert.Equal(1, array.IndexOf(2));
            Assert.Equal(0, array.IndexOf(1));
        }

        [Fact]
        public void Test_Add_Method_StringList_Should_Be_Sorted_4_elements()
        {
            //Given
            SortedList<string> array = new SortedList<string>
            {
                "c",
                "a",
                "b",
                "d"
            };
            //Then
            Assert.Equal(0, array.IndexOf("a"));
            Assert.Equal(1, array.IndexOf("b"));
            Assert.Equal(2, array.IndexOf("c"));
            Assert.Equal(3, array.IndexOf("d"));
        }

        [Fact]
        public void Test_Add_Method_ByteList_Should_Be_Sorted_1_Element()
        {
            //Given
            SortedList<byte> array = new SortedList<byte>
            {
                3
            };
            //Then
            Assert.Equal(0, array.IndexOf(3));
        }

        [Fact]
        public void Test_Add_Method_CharList_Should_Be_Sorted_When_It_Has_Repeated_Values()
        {
            //Given
            SortedList<char> array = new SortedList<char>
            {
                'a',
                'a',
                'r',
                'a'
            };
            //Then
            Assert.Equal(3, array.IndexOf('r'));
            Assert.Equal(-1, array.IndexOf('\t'));
        }

        [Fact]
        public void Should_Insert_Element_When_Resulting_IntList_Is_Sorted()
        {
            //Given
            SortedList<int> array = new SortedList<int>
            {
                1,
                4,
                6,
                8
            };
            //When
            array.Insert(2, 5);
            //Then
            Assert.Equal(2, array.IndexOf(5));
            Assert.Equal(5, array.Count);
        }

        [Fact]
        public void Should_Not_Insert_Element_When_Resulting_IntList_Is_Unsorted()
        {
            //Given
            SortedList<int> array = new SortedList<int>
            {
                1,
                4,
                6,
                8
            };
            //When
            array.Insert(2, 100);
            //Then
            Assert.Equal(-1, array.IndexOf(100));
            Assert.Equal(4, array.Count);
        }

        [Fact]
        public void Insert_Method_Should_Function_Correctly_For_Empty_List()
        {
            //Given
            SortedList<float> array = new SortedList<float>();
            //When
            array.Insert(0, 100);
            //Then
            Assert.Equal(0, array.IndexOf(100));
            Assert.Single(array);
        }

        [Fact]
        public void Should_Get_Element_For_Simple_List()
        {
            var array = new SortedList<double>
            {
                1,
                5,
                10
            };

            Assert.Equal(5, array[1]);
        }

        [Fact]
        public void Should_Set_element_when_resulting_List_is_Sorted()
        {
            var array = new SortedList<byte>
            {
                1,
                5,
                10
            };
            array[1] = 3;
            Assert.Equal(3, array[1]);
        }

        [Fact]
        public void Should_Not_Set_element_when_resulting_List_is_NOT_Sorted()
        {
            var array = new SortedList<byte>
            {
                1,
                5,
                10
            };
            array[1] = 100;
            Assert.Equal(5, array[1]);
        }

        [Fact]
        public void Should_Set_Element_List_Has_Repeated_Values()
        {
            var array = new SortedList<byte>
            {
                2,
                2,
                2
            };
            array[1] = 2;
            Assert.Equal(2, array[1]);
        }

        [Fact]
        public void Should_Set_Element_Array_Has_Two_Elements_and_Repeated_Values()
        {
            var array = new SortedList<byte>
            {
                4,
                4
            };
            array[1] = 4;
            Assert.Equal(4, array[1]);
        }

        [Fact]
        public void Should_Not_Set_Element_List_Has_2_Same_elements()
        {
            var array = new SortedList<byte>
            {
                4,
                4
            };
            array[1] = 3;
            Assert.Equal(4, array[1]);
        }

        [Fact]
        public void Should_Set_Element_List_Has_One_Element()
        {
            var array = new SortedList<byte>
            {
                4
            };
            array[0] = 3;
            Assert.Equal(3, array[0]);
        }

        [Fact]
        public void Should_Set_Element_Empty_List()
        {
            var array = new SortedList<byte>
            {
                [0] = 3
            };
            Assert.Empty(array);
        }
    }
}
