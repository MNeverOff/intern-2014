﻿using System;
using System.Net;
using System.Threading;
using Client;
using Client.Parameters;
using HighLevelClient;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Test
    {
        private IPEndPoint ipEndPoint1;
        private IPEndPoint ipEndPoint2;
        private IPEndPoint ipEndPoint3;
        private EnterpriseClient enterpriseClient;

        [SetUp]
        public void SetUp()
        {
            ipEndPoint1 = new IPEndPoint(new IPAddress(new byte[] { 192, 168, 52, 178 }), 5088);
            ipEndPoint2 = new IPEndPoint(new IPAddress(new byte[] { 192, 168, 52, 178 }), 5086);
            ipEndPoint3 = new IPEndPoint(new IPAddress(new byte[] { 192, 168, 52, 178 }), 5087);
            enterpriseClient = new EnterpriseClient(new[] {ipEndPoint1, ipEndPoint2, ipEndPoint3});
        }

        [Test]
        public void Test1()
        {
            for(var i = 0; i < 10; ++i)
            {
                var key = Guid.NewGuid().ToString();
                var value = Guid.NewGuid().ToString();
                enterpriseClient.Write(key, value);
                var result = enterpriseClient.Read(key);
                Assert.AreEqual(value, result);
            }
        }
    }
}
