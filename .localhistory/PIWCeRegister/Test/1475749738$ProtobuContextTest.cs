using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        ProtobufContext p;

        [SetUp]
        protected void SetUp()
        {
            m1.FirstName = "Alex";
            m1.LastName = "Smith";
            m1.address=new address();
            m1.Id = 1;
            m1.Pim_no = "2333";
            m1.m_occupation=new m_occupation();
            m1.Mobile_no = "01465232465";
            m1.Telephone_no = "01245645652";
            m1.ch_services=new List<ch_services>();          
        }


        [Test]
        public void ModelInjectionTest()
        {
            p=new ProtobufContext();
            p.Add(m1);
        }

        [Test]    
        public void ConstructorInitException_Test()
        {
            
            Assert.Throws<Exception>(
                () =>
                {
                    p = new ProtobufContext();
                    p.Executor<member>();
                });
        }
    }
}
