using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = {@"SYSCALL r43","CLEAR", "LD r5 #5"};
            Console.ReadLine();
        }

        public static void Interp(string[] strMas)
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

            for (int val=0;val<strMas.Length;val++)
            {
                var ldMatch = ld.Match(strMas[val]);
                var movMatch = mov.Match(strMas[val]);
                var addMatch = add.Match(strMas[val]);
                var subMatch = sub.Match(strMas[val]);
                var brMatch = br.Match(strMas[val]);
                var brgzMatch = brgz.Match(strMas[val]);
                var textMatch = text.Match(strMas[val]);
                var syscallMatch = syscall.Match(strMas[val]);
                var clearMatch = clear.Match(strMas[val]);

             
                
                if (ldMatch.Success)
                {
                    stack[Int32.Parse(ldMatch.Groups[0].Value)] = Byte.Parse(ldMatch.Groups[1].Value);
                }

                if (movMatch.Success)
                {
                    stack[Int32.Parse(movMatch.Groups[0].Value)] = stack[Int32.Parse(movMatch.Groups[1].Value)];
                }

                if (addMatch.Success)
                {
                    stack[Int32.Parse(addMatch.Groups[0].Value)] += stack[Int32.Parse(addMatch.Groups[1].Value)];
                }

                if (subMatch.Success)
                {
                    stack[Int32.Parse(subMatch.Groups[0].Value)] = stack[Int32.Parse(subMatch.Groups[1].Value)];
                }

                if (brMatch.Success)
                {
                    val = stack[Int32.Parse(brMatch.Groups[0].Value)];
                }

                //BRGZ

                if (syscallMatch.Success)
                {
                    Console.WriteLine(stack[Int32.Parse(syscallMatch.Groups[0].Value)]);
                }

                if (clearMatch.Success)
                {
                    stack = null;
                }
            }

        }
    }
}
