using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Labs.Full.NUnitTest
{
    public class ExtensionsTest
    {
        private List<int>? _vtList;
        private List<Tuple<int>>? _rtList;

        [SetUp]
        public void Setup()
        {
            _vtList = new List<int> { 1, 2, 3, 4, 5, 6 };
            _rtList = new List<Tuple<int>>
            {
                new(1),
                new(2),
                new(3),
                new(4),
                new(5),
                new(6)
            };
        }

        [Test]
        public void Enumerable_AppendDistinct_Twice()
        {
            var a = _vtList;
            var b= _vtList.RandomResortList();
            var c = _vtList.Count + 1;

            a.AppendDistinct(b);
            a.AppendDistinct(100);

            Assert.That(a.Count(), Is.EqualTo(c));
        }

        [Test]
        public void Enumerable_UnionAll_ValueTypesDistinct()
        {
            // Arrange
            var a= new List<int> { 1, 2, 3, 4, 5, 6 };
            var b = new List<int> { 4, 5, 6, 7, 8, 9 };

            // Act
            var c = new List<List<int>> { a, b }.UnionAll();

            // Assert
            Assert.That(c.Count(),Is.EqualTo(9));
        }

        [Test]
        public void Enumerable_UnionAll_ReferenceTypesDistinct()
        {
            // Arrange
            var a = new List<Tuple<int>>
            {
                new (1),
                new (2),
                new (3),
                new (4),
                new (5),
                new (6)
            };
            var b = new List<Tuple<int>>
            {
                new (4),
                new (5),
                new (6),
                new (7),
                new (8),
                new (9)
            };

            // Act
            var c = new List<List<Tuple<int>>> { a, b }.UnionAll();

            // Assert
            Assert.That(c.Count(), Is.EqualTo(9));
        }

        [Test]
        public void Enumerable_AllFoundIn_ValueTypes()
        {
            // Arrange
            var a = new List<int> { 1, 2, 3, 4, 5, 6 };
            var b1 = new List<int> { 4, 5 };
            var b2 = new List<int> { 4, 5, 7 };

            // Act
            var c1 = b1.AllFoundIn(a);
            var c2 = b2.AllFoundIn(a);

            // Assert
            Assert.That(c1, Is.EqualTo(true));
            Assert.That(c2, Is.EqualTo(false));
        }

        [Test]
        public void Enumerable_AllFoundIn_ReferenceTypes()
        {
            // Arrange
            var a = new List<Tuple<int>>
            {
                new (1),
                new (2),
                new (3),
                new (4),
                new (5),
                new (6)
            };
            var b1 = new List<Tuple<int>>
            {
                new (4),
                new (5)
            };
            var b2 = new List<Tuple<int>>
            {
                new (4),
                new (5),
                new (7)
            };
            List<Tuple<int>>? b3 = null;

           // Act
           var c1 =b1.AllFoundIn(a);
            var c2 = b2.AllFoundIn(a); 
            var c3 = b3.AllFoundIn(a);

            // Assert
            Assert.That(c1, Is.EqualTo(true));
            Assert.That(c2, Is.EqualTo(false));
            Assert.That(c3, Is.EqualTo(false));
        }

        [Test]
        public void Enumerable_NotFoundIn_ValueTypes()
        {
            // Arrange
            var a = new List<int> { 1, 2, 3, 4, 5, 6 };
            var b1 = new List<int> { 7, 8 };
            var b2 = new List<int> { 5, 7 };
            List<int>? b3 = null;

            // Act
            var c1 = b1.NotFoundIn(a);
            var c2 = b2.NotFoundIn(a);
            var c3 = b3.NotFoundIn(a);

            // Assert
            Assert.That(c1, Is.EqualTo(true));
            Assert.That(c2, Is.EqualTo(false));
            Assert.That(c3, Is.EqualTo(false));
        }

        [Test]
        public void Enumerable_NotFoundIn_ReferenceTypes()
        {
            // Arrange
            var a = new List<Tuple<int>>
            {
                new (1),
                new (2),
                new (3),
                new (4),
                new (5),
                new (6)
            };
            var b1 = new List<Tuple<int>>
            {
                new (7),
                new (8)
            };
            var b2 = new List<Tuple<int>>
            {
                new (5),
                new (7)
            };
            List<Tuple<int>>? b3 = null;

            // Act
            var c1 = b1.NotFoundIn(a);
            var c2 = b2.NotFoundIn(a);
            var c3 = b3.NotFoundIn(a);

            // Assert
            Assert.That(c1, Is.EqualTo(true));
            Assert.That(c2, Is.EqualTo(false));
            Assert.That(c3, Is.EqualTo(false));
        }

        [Test]
        public void Enumerable_RandomResortList_AlmostDifferent()
        {
            // Arrange
            var a = new List<int> { 1, 2, 3, 4, 5, 6 };
            var b = a;

            // Act
            var c =a.RandomResortList();

            // Assert
            Assert.That(b.Equals(a), Is.EqualTo(true));
            Assert.That(c.Equals(a), Is.EqualTo(false));
        }

        [Test]
        public void Enumerable_Redim_ShrinkOrExtend()
        {
            // Arrange
            var a = new [] { 1, 2, 3, 4, 15, 6 ,9,50};
            var b = new [] { 7, 8, 6 };
            int[]? c = null;

            // Act
            var r1 = a.Redim(5);
            var r2 = b.Redim(5);
            var r3 = c.Redim(5);
            
            // Assert
            Assert.That(r1.Length, Is.EqualTo(5));
            Assert.That(r1[4],Is.EqualTo(15));
            Assert.That(r2.Length, Is.EqualTo(5));
            Assert.That(r2[4], Is.EqualTo(0));
            Assert.That(r3.Length, Is.EqualTo(5));
            Assert.That(r3[4], Is.EqualTo(0));
        }

        [Test]
        public void Enumerable_IsAsc_ValueTypes()
        {
            // Arrange
            var a = new List<int> { 1, 2, 3, 4, 5, 6 };
            var b = new List<int> { 7, 8 ,6,8,10};
            List<int>? c = null;

            // Act
            var c1 = a.IsAsc(o=>o);
            var c2 = b.IsAsc(o=>o);
            var c3 = c.IsAsc(o=>o);

            // Assert
            Assert.That(c1, Is.EqualTo(true));
            Assert.That(c2, Is.EqualTo(false));
            Assert.That(c3, Is.EqualTo(true));
        }

        [Test]
        public void Enumerable_IsAsc_ReferenceTypes()
        {
            // Arrange
            var a = new List<Tuple<int>>
            {
                new (1),
                new (2),
                new (3),
                new (4),
                new (5),
                new (6)
            };
            var b = new List<Tuple<int>>
            {
                new (1),
                new (2),
                new (3),
                new (5),
                new (4),
                new (6)
            };
            List<Tuple<int>>? c = null;
            List<Tuple<int>> d = new List<Tuple<int>> { new(5) };

            // Act
            var r1 = a.IsAsc(o => o.Item1);
            var r2 = b.IsAsc(o => o.Item1);
            var r3 = c.IsAsc(o => o.Item1);
            var r4 = c.IsAsc(o => o.Item1);

            // Assert
            Assert.That(r1, Is.EqualTo(true));
            Assert.That(r2, Is.EqualTo(false));
            Assert.That(r3, Is.EqualTo(true));
            Assert.That(r4, Is.EqualTo(true));
        }


    }
}