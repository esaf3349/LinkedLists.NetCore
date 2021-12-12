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
            linkedList.RemoveOne(earth);

            // Assert
            var expected = new[] { moon, earth };

            var i = 0;
            foreach (var value in linkedList)
            {
                Assert.Equal(expected[i], value);
                i++;
            }

            Assert.Equal(expected.Length, linkedList.Length());
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
            linkedList.RemoveAll(earth);

            // Assert
            var expected = new[] { moon };

            var i = 0;
            foreach (var value in linkedList)
            {
                Assert.Equal(expected[i], value);
                i++;
            }

            Assert.Equal(expected.Length, linkedList.Length());
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

            // Act

            // Assert
            Assert.Equal(default, emptyList.FirstOrDefault());
            Assert.Equal(earth, filledList.FirstOrDefault());
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

            // Act

            // Assert
            Assert.False(emptyList.Any());
            Assert.True(filledList.Any());
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
