using HW6.ViewModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_Tests
{
    [TestFixture]
    [SetUpFixture]
    public class Test
    {
        MainViewModel vm = new MainViewModel();

        [Test]
        public void ImageIndexChangeTest()
        {
            vm.ImgIndex += 1;
            Assert.AreEqual(1, vm.ImgIndex);
        }
    }
}
