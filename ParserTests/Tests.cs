using System;
using NUnit.Framework;
using Lab1Parser;

namespace ParserTests
{
    [TestFixture]
    public class Tests
    {
        ini_parser parser = new ini_parser("D:\\LABS\\2 COURSE\\OOP_LABS\\Lab1Parser\\test.ini");
        
        [Test]
        public void GetStringTest()
        {
            Assert.AreEqual("a.com", parser.GetSetting<string>("COMMON", "keke"));
        }
        
        [Test]
        public void GetIntTest()
        {
            Assert.AreEqual(123, parser.GetSetting<int>("sss", "int"));
        }
        
        [Test]
        public void GetIntWithCommentTest()
        {
            Assert.AreEqual(3, parser.GetSetting<int>("COMMENT", "int_with_comment"));
        }
        
        [Test]
        public void GetFloatTest()
        {
            Assert.AreEqual(3.2, parser.GetSetting<float>("COMMON", "float"));
        }
        
    }
}