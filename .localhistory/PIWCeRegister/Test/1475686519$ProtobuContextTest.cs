using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PIWCeRegister.Source.Models;
using PIWCeRegister.Source.Services;

namespace PIWCeRegister.Test
{
    [TestFixture]

    public class ProtobuContextTest
    {
        private member m1,m2,m3,m4;
      

        [SetUp]
        protected void SetUp()
        {
            m1.FirstName = "Alex";
            m1.LastName = "Smith";
            m1.address=new address();
            m1.Id = 1;
            m1.Pim_no = "2333";
            m1.m_occupation=new m_occupation();
            m1.Mobile_no = "0146523236465";
            m1.ch_services=new List<ch_services>();
        }

        [Test]    
        public void ConstructorInitException_Test()
        {
            ProtobufContext p;
            Assert.Throws<Exception>(
                () =>
                {
                    p = new ProtobufContext(null);
                    p.Executor<member>();
                });
        }
    }
}
