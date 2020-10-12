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
        public void CheckGet()
        {
            Assert.AreEqual("a.com", parser.GetSetting<string>("COMMON", "keke"));
            Assert.AreEqual(123, parser.GetSetting<int>("COMMON", "int"));
            Assert.AreEqual(3.2, parser.GetSetting<float>("COMMON", "float"));
        }
        
        
        [Test]
        public void CheckSpaces()
        {
            Assert.AreEqual(12, parser.GetSetting<int>("SSS", "qq"));
            Assert.AreEqual(13, parser.GetSetting<int>("SSS", "pp"));
        }

        [Test]
        public void CheckComments()
        {
            Assert.AreEqual(3, parser.GetSetting<int>("COMMENT", "int_with_comment"));
        }
    }
}