using System;
using System.Linq;
using NUnit.Framework;
using PIWCeRegister.Source.Models;
using PIWCeRegister.Source.Services;

namespace PIWCeRegister.Test
{
    [TestFixture]

    public class ProtobuContextTest
    {
        [SetUp]
        protected void SetUp()
        {
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
