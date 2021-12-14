using LinkedLists.Core.Implementation.Tests.Mocks;
using LinkedLists.Core.Implementation.Tests.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LinkedLists.Core.Implementation.Tests.Tests
{
    public class SimpleLinkedListTests
    {
        [Fact]
        public void Add()
        {
            // Arrange
            var values = new [] { AstronomicalObjectMocks.Earth(), AstronomicalObjectMocks.Moon(), AstronomicalObjectMocks.Sol() };

            var linkedList = new SimpleLinkedList<AstronomicalObject>();

            // Act
            foreach (var value in values)
                linkedList.Add(value);

            // Assert
            var i = 0;
            foreach (var value in linkedList)
            {
                Assert.Equal(values[i], value);
                i++;
            }

            Assert.Equal(values.Length, linkedList.Length());
        }

        [Fact]
        public void AddFirst()
        {
            // Arrange
            var values = new[] { AstronomicalObjectMocks.Earth(), AstronomicalObjectMocks.Moon(), AstronomicalObjectMocks.Sol() };

            var linkedList = new SimpleLinkedList<AstronomicalObject>();

            // Act
            foreach (var value in values)
                linkedList.AddFirst(value);

            // Assert
            var i = values.Length - 1;
            foreach (var value in linkedList)
            {
                Assert.Equal(values[i], value);
                i--;
            }

            Assert.Equal(values.Length, linkedList.Length());
        }

        [Fact]
        public void RemoveOne()
        {
            // Arrange
            var earth = AstronomicalObjectMocks.Earth();
            var moon = AstronomicalObjectMocks.Moon();

            var values = new[] { earth, moon, earth };

            var linkedList = new SimpleLinkedList<AstronomicalObject>();

            foreach (var value in values)
                linkedList.Add(value);

            // Act
            var isRemoved1 = linkedList.RemoveOne(earth);
            var isRemoved2 = linkedList.RemoveOne(AstronomicalObjectMocks.Sol());

            // Assert
            var expected = new[] { moon, earth };

            var i = 0;
            foreach (var value in linkedList)
            {
                Assert.Equal(expected[i], value);
                i++;
            }

            Assert.Equal(expected.Length, linkedList.Length());
            Assert.True(isRemoved1);
            Assert.False(isRemoved2);
        }

        [Fact]
        public void RemoveOneLambda()
        {
            // Arrange
            var earth = AstronomicalObjectMocks.Earth();
            var moon = AstronomicalObjectMocks.Moon();
            var sol = AstronomicalObjectMocks.Sol();

            var values = new[] { earth, moon, sol };

            var linkedList = new SimpleLinkedList<AstronomicalObject>();

            foreach (var value in values)
                linkedList.Add(value);

            // Act
            var isRemoved1 = linkedList.RemoveOne(o => o.Mass > moon.Mass);
            var isRemoved2 = linkedList.RemoveOne(o => o.Class == AstronomicalClass.Galaxy);

            // Assert
            var expected = new[] { moon, sol };

            var i = 0;
            foreach (var value in linkedList)
            {
                Assert.Equal(expected[i], value);
                i++;
            }

            Assert.Equal(expected.Length, linkedList.Length());
            Assert.True(isRemoved1);
            Assert.False(isRemoved2);
        }

        [Fact]
        public void RemoveAll()
        {
            // Arrange
            var earth = AstronomicalObjectMocks.Earth();
            var moon = AstronomicalObjectMocks.Moon();

            var values = new[] { earth, moon, earth };

            var linkedList = new SimpleLinkedList<AstronomicalObject>();

            foreach (var value in values)
                linkedList.Add(value);

            // Act
            var removedCount = linkedList.RemoveAll(earth);

            // Assert
            var expected = new[] { moon };

            var i = 0;
            foreach (var value in linkedList)
            {
                Assert.Equal(expected[i], value);
                i++;
            }

            Assert.Equal(expected.Length, linkedList.Length());
            Assert.Equal(2, removedCount);
        }

        [Fact]
        public void RemoveAllLambda()
        {
            // Arrange
            var earth = AstronomicalObjectMocks.Earth();
            var moon = AstronomicalObjectMocks.Moon();
            var sol = AstronomicalObjectMocks.Sol();

            var values = new[] { earth, moon, sol };

            var linkedList = new SimpleLinkedList<AstronomicalObject>();

            foreach (var value in values)
                linkedList.Add(value);

            // Act
            var removedCount1 = linkedList.RemoveAll(o => o.Name == moon.Name || o.Name == sol.Name);
            var removedCount2 = linkedList.RemoveAll(o => o.Class == AstronomicalClass.Galaxy);

            // Assert
            var expected = new[] { earth };

            var i = 0;
            foreach (var value in linkedList)
            {
                Assert.Equal(expected[i], value);
                i++;
            }

            Assert.Equal(expected.Length, linkedList.Length());
            Assert.Equal(earth, linkedList.FirstOrDefault());
            Assert.Equal(earth, linkedList.LastOrDefault());
            Assert.Equal(2, removedCount1);
            Assert.Equal(0, removedCount2);
        }

        [Fact]
        public void Concat()
        {
            // Arrange
            var earth = AstronomicalObjectMocks.Earth();
            var moon = AstronomicalObjectMocks.Moon();
            var sol = AstronomicalObjectMocks.Sol();
            var orion = AstronomicalObjectMocks.OrionNebula();
            var milkyWay = AstronomicalObjectMocks.MilkyWay();

            var values1 = new[] { earth, moon, sol };
            var values2 = new[] { orion, milkyWay };

            var linkedList1 = new SimpleLinkedList<AstronomicalObject>();
            var linkedList2 = new SimpleLinkedList<AstronomicalObject>();

            foreach (var value in values1)
                linkedList1.Add(value);

            foreach (var value in values2)
                linkedList2.Add(value);

            // Act
            linkedList1.Concat(linkedList2);

            // Assert
            var expected = new[] { earth, moon, sol, orion, milkyWay };

            var i = 0;
            foreach (var value in linkedList1)
            {
                Assert.Equal(expected[i], value);
                i++;
            }

            Assert.Equal(expected.Length, linkedList1.Length());
            Assert.Equal(expected[0], linkedList1.FirstOrDefault());
            Assert.Equal(expected[^1], linkedList1.LastOrDefault());
        }

        [Fact]
        public void Where()
        {
            // Arrange
            var earth = AstronomicalObjectMocks.Earth();
            var moon = AstronomicalObjectMocks.Moon();
            var sol = AstronomicalObjectMocks.Sol();
            var orion = AstronomicalObjectMocks.OrionNebula();
            var milkyWay = AstronomicalObjectMocks.MilkyWay();

            var values = new[] { earth, moon, sol, orion, milkyWay };

            var linkedList = new SimpleLinkedList<AstronomicalObject>();

            foreach (var value in values)
                linkedList.Add(value);

            // Act
            var lambdaResults = linkedList.Where(o => o.Mass > moon.Mass && o.Mass < milkyWay.Mass);

            // Assert
            var expected = new[] { earth, sol, orion };

            var i = 0;
            foreach (var value in lambdaResults)
            {
                Assert.Equal(expected[i], value);
                i++;
            }

            Assert.Equal(expected.Length, lambdaResults.Length());
            Assert.Equal(expected[0], lambdaResults.FirstOrDefault());
            Assert.Equal(expected[^1], lambdaResults.LastOrDefault());
        }

        [Fact]
        public void FirstOrDefault()
        {
            // Arrange
            var earth = AstronomicalObjectMocks.Earth();
            var moon = AstronomicalObjectMocks.Moon();
            var sol = AstronomicalObjectMocks.Sol();

            var values = new[] { earth, moon, sol };

            var emptyList = new SimpleLinkedList<AstronomicalObject>();
            var filledList = new SimpleLinkedList<AstronomicalObject>();

            foreach (var value in values)
                filledList.Add(value);

            var lambdaResult = filledList.FirstOrDefault(o => o.Name == moon.Name);

            // Act

            // Assert
            Assert.Equal(default, emptyList.FirstOrDefault());
            Assert.Equal(earth, filledList.FirstOrDefault());
            Assert.Equal(moon.Name, lambdaResult.Name);
        }

        [Fact]
        public void LastOrDefault()
        {
            // Arrange
            var earth = AstronomicalObjectMocks.Earth();
            var moon = AstronomicalObjectMocks.Moon();
            var sol = AstronomicalObjectMocks.Sol();

            var values = new[] { earth, moon, sol };

            var emptyList = new SimpleLinkedList<AstronomicalObject>();
            var filledList = new SimpleLinkedList<AstronomicalObject>();

            foreach (var value in values)
                filledList.Add(value);

            // Act

            // Assert
            Assert.Equal(default, emptyList.LastOrDefault());
            Assert.Equal(sol, filledList.LastOrDefault());
        }

        [Fact]
        public void Any()
        {
            // Arrange
            var earth = AstronomicalObjectMocks.Earth();
            var moon = AstronomicalObjectMocks.Moon();
            var sol = AstronomicalObjectMocks.Sol();

            var values = new[] { earth, moon, sol };

            var emptyList = new SimpleLinkedList<AstronomicalObject>();
            var filledList = new SimpleLinkedList<AstronomicalObject>();

            foreach (var value in values)
                filledList.Add(value);

            var lambdaResult1 = filledList.Any(o => o.Name == sol.Name && o.Mass == sol.Mass);
            var lambdaResult2 = filledList.Any(o => o.Name == sol.Name && o.Mass != sol.Mass);

            // Act

            // Assert
            Assert.False(emptyList.Any());
            Assert.True(filledList.Any());
            Assert.True(lambdaResult1);
            Assert.False(lambdaResult2);
        }

        [Fact]
        public void GetEnumerator()
        {
            // Arrange
            var earth = AstronomicalObjectMocks.Earth();
            var moon = AstronomicalObjectMocks.Moon();
            var sol = AstronomicalObjectMocks.Sol();

            var values = new[] { earth, moon, sol };

            var linkedList = new SimpleLinkedList<AstronomicalObject>();

            foreach (var value in values)
                linkedList.Add(value);

            // Act
            var enumerator = linkedList.GetEnumerator();
            enumerator.MoveNext();

            // Assert
            for (int i = 0; i < values.Length; i++)
            {
                Assert.Equal(values[i], enumerator.Current);
                enumerator.MoveNext();
            }
        }
    }
}
