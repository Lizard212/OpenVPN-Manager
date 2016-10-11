using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenVPNForm.Manager;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            VPNConnector a = new VPNConnector();
            bool result  = a.Connect( "C:\\Program Files\\OpenVPN\\config", "vpn.ovpn");
            Assert.IsTrue(result);
        }
    }
}
