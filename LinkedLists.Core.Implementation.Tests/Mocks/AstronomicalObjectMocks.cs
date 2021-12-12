using LinkedLists.Core.Implementation.Tests.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists.Core.Implementation.Tests.Mocks
{
    public static class AstronomicalObjectMocks
    {
        public static AstronomicalObject Earth()
        {
            return new AstronomicalObject
            {
                Name = "Earth",
                Class = AstronomicalClass.Planet,
                Mass = 5.972E+24f
            };
        }

        public static AstronomicalObject Moon()
        {
            return new AstronomicalObject
            {
                Name = "Moon",
                Class = AstronomicalClass.Planet,
                Mass = 7.347E+22f
            };
        }

        public static AstronomicalObject Sol()
        {
            return new AstronomicalObject
            {
                Name = "Sol",
                Class = AstronomicalClass.Star,
                Mass = 1.989E+30f
            };
        }

        public static AstronomicalObject OrionNebula()
        {
            return new AstronomicalObject
            {
                Name = "Orion Nebula",
                Class = AstronomicalClass.Nebula,
                Mass = 1.989E+30f * 2000
            };
        }

        public static AstronomicalObject MilkyWay()
        {
            return new AstronomicalObject
            {
                Name = "Milky Way",
                Class = AstronomicalClass.Nebula,
                Mass = 1.989E+30f * 1E+12f
            };
        }
    }
}
