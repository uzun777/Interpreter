using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "SYSCALL r43";
            Interp(str);
            Console.ReadLine();
        }

        public static void Interp(string str)
        {
            byte[] stack = new byte[15];
            List<Regex> st = new List<Regex>();
            Regex ld = new Regex(@"LD\sr(\d+)\s#(\d+)");
            Regex mov = new Regex(@"MOV\sr(\d+)\sr(\d+)");
            Regex add = new Regex(@"ADD\sr(\d+)\sr(\d+)");
            Regex sub = new Regex(@"SUB\sr(\d+)\sr(\d+)");
            Regex br = new Regex(@"BR\s(\w+)");
            Regex brgz = new Regex(@"BRGZ\s(\w+)\sr(\d+)");
            Regex text = new Regex(@"(\w+):");
            Regex syscall = new Regex(@"SYSCALL\sr(\d+)");
            Regex clear = new Regex(@"(CLEAR)");

            MatchCollection b = syscall.Matches(str);
            Console.WriteLine(b[0].Groups[1]);


        }
    }
}
