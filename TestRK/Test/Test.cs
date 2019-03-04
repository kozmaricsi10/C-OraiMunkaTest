using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestRK.Test
{
    class Test
    {
        JaratKezelo test;

        [SetUp]
        public void SetUp()
        {
            test = new JaratKezelo();
        }

        [Test]
        public void UjJarat()
        {
            test.UjJarat("1548", "Budapest", "Cyprus", new DateTime(2019, 3, 30, 4, 05, 0));

        }
      
        [Test]
        public void Keses()
        {

            test.UjJarat("1548", "Budapest", "Cyprus", new DateTime(2019, 3, 30, 4, 05, 0));
            test.Keses("1548", 30);
            Assert.AreEqual(new DateTime(2019, 3, 30, 4, 35, 0) , test.MikorIndul("1548"));
        }

        [Test]
        public void Keses2()
        {

            test.UjJarat("1548", "Budapest", "Cyprus", new DateTime(2019, 3, 30, 4, 05, 0));
            test.Keses("1548", -30);
            Assert.AreEqual(new DateTime(2019, 3, 30, 3, 35, 0), test.MikorIndul("1548"));
        }

        [Test]
        public void Keses3()
        {

            test.UjJarat("1548", "Budapest", "Cyprus", new DateTime(2019, 3, 30, 4, 05, 0));
            test.Keses("1548", 40);
            test.Keses("1548", -10);
            Assert.AreEqual(new DateTime(2019, 3, 30, 4, 35, 0), test.MikorIndul("1548"));
        }


    }
}
