using Xunit;
using CollectionsClasses;

namespace CollectionsTests
{
    public class ObjectEnumeratorFacts
    {

        [Fact]
        public void Test_Add_Should_Correctly_Add_Elements_Without_Explicity_Calling_Add_Method()
        {
            object a = (object)2;
            object b = (object)"Coding is hard";

            var array = new ObjectArray { a, b };

            Assert.Equal(2, array.Count);
            Assert.Equal(1, array.IndexOf("Coding is hard"));

        }


        [Fact]
        public void Test_Enumerator_For_Mixed_Array()
        {
            //Given
            var array = new ObjectArray {
                (object)true, (object)false,
                (object)"IT", (object)null,
                (object)string.Empty, (object)int.MaxValue
            };

            array.Insert(1, 1);
            array.Insert(4, string.Empty);

            //When
            var enumerator = array.GetEnumerator();

            for (int i = 0; i < 8; i++)
                enumerator.MoveNext();

            var getCurrent = enumerator.Current;

            //Then
            Assert.Equal(int.MaxValue, getCurrent);
            Assert.False(array.Contains("eu"));
            Assert.True(array.Contains(null));
            Assert.Equal(0, array.IndexOf(true));
            Assert.Equal(1, array.IndexOf(1));
            Assert.Equal(8, array.Count);

        }

        [Fact]
        public void Test_Enumerator_For_Given_Object()
        {
            object a = (object)2;
            object b = (object)"Coding is hard";

            var array = new ObjectArray { a, b };
            var enumerator = array.GetEnumerator();/*new ObjectEnumerator(array)*/
            enumerator.MoveNext();
            enumerator.MoveNext();
            var getCurrent = enumerator.Current;

            Assert.Equal(b, getCurrent);
            Assert.Equal(1, array.IndexOf("Coding is hard"));

        }

        [Fact]
        public void Test_Reset_Method_For_Simple_Array()
        {
            object a = (object)2;
            object b = (object)"Coding is hard";

            var array = new ObjectArray { a, b };
            var enumerator = array.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(a, enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(b, enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void Test_Current_Property__For_Simple_Array()
        {
            object a = (object)2;
            object b = (object)"Coding is hard";

            var array = new ObjectArray { a, b };
            array[0] = (object)100;

            var enumerator = array.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(100, enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(b, enumerator.Current);
            Assert.False(enumerator.MoveNext());

        }

        [Fact]
        public void Test_Reset_Method_For_Empty_Array()
        {
            //Given
            var array = new ObjectArray();
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