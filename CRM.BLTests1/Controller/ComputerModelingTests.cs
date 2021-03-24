using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CRM.BL.Controller.Tests
{
    [TestClass()]
    public class ComputerModelingTests
    {
        [TestMethod()]
        public void ComputerModelingTest()
        {
            var model = new ComputerModeling();
            model.Start();
            Thread.Sleep(10000);
        }

    }
}