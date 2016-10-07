using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using NUnit.Framework;
using PIWCeRegister.Source.Models;
using PIWCeRegister.Source.Services;

namespace PIWCeRegister.Test
{
    [TestFixture]

    public class ProtobuContextTest
    {
        private member m1, m2, m3, m4;
        ProtobufContext p;

        [SetUp]
        protected void SetUp()
        {
            m1 = new member
            {
                FirstName = "Alex",
                LastName = "Smith",
                address = new address(),
                Id = 1,
                Pim_no = "2333",
                m_occupation = new m_occupation(),
                Mobile_no = "01465232465",
                Telephone_no = "01245645652",
                ch_services = new List<ch_services>()
            };
        }


        [Test]
        public void ModelInjectionTest()
        {
            p = new ProtobufContext();
            p.Add(m1);
            p.ExecutorInterface<member>(p.ModelsList.ElementAt(0));
           
            var members= p.Context<member>();

            Console.WriteLine(members.ElementAt(0).FirstName);
        }

        [Test]
        public void ModelFindTypeTest()
        {
            p = new ProtobufContext();
            p.Add(m1);
            p.ExecutorInterface<member>(p.ModelsList.ElementAt(0));

            Console.WriteLine(p.Context<member>());

        }

        [Test]
        public void SerialisationTest()
        {
            p = new ProtobufContext();
            p.Add(m1);
            p.ExecutorInterface<member>(p.ModelsList.ElementAt(0));

            var members = p.Context<member>();

            p.SerialiseAndStoreList(members);
        }

         [Test]
        public void DeserialisationTest()
        {
            p = new ProtobufContext();
            p.Add(m1);
            p.ExecutorInterface<member>(p.ModelsList.ElementAt(0));

            var members = p.DeserialiseAndLoadList<member>();

            Console.Write(members);
        }
        [Test]
        public void ConstructorInitException_Test()
        {
            Assert.Throws<Exception>(
                () =>
                {
                    p = new ProtobufContext();
                    p.Executor<member>();
                    p.Executor<ch_services>();
                });
        }
    }
}
