using System;

namespace Lab1Parser
{
    public class Programm
    {
        public static void Main(string[] args)
        {
            ini_parser parser = new ini_parser("D:\\LABS\\2 COURSE\\OOP_LABS\\Lab1Parser\\test.ini");
            Console.WriteLine(parser.GetSetting<string>("COMMON", "keke"));
            Console.WriteLine(parser.GetSetting<int>("COMMENT", "int_with_comment"));
            Console.WriteLine(parser.GetSetting<float>("COMMON", "float"));
        }
    }
}