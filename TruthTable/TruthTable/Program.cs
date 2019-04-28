// SOURCE: Harold
// AUTHOR: Sanfoundry
// FILENAME: GetFileTime
// PURPOSE: C# Program to demonstrate a truth table.
// STUDENT: Antonio Santana
// DATE: 28 April 2019
// Changes: Trying to replicate Harold R truth table.
//print("Expression s1")
//print(s1)
//print(" ")
//s2 = (p & q) | (p & r)
//print("Expression s2")
//print(s2)
//print(" ")
//compare = s1 == s2
//print("Compare s1 and s2")
//print(compare)

using System;

namespace TruthTable
{
    public abstract class ThreeItemTruthRow
    {
        protected ThreeItemTruthRow(bool a, bool b, bool c)
        {
            A = a; B = b; C = c;
        }

        public bool A { get; protected set; }
        public bool B { get; protected set; }
        public bool C { get; protected set; }

        public abstract bool GetTruthValue();
    }

    public class MyCustomThreeItemTruthRow : ThreeItemTruthRow
    {
        public MyCustomThreeItemTruthRow(bool a, bool b, bool c)
            : base(a, b, c)
        {
        }

        public override bool GetTruthValue()
        {
            // My custom logic
            return (!A && B && C) || (A && !B && C) || (A && B && !C) || (A && B && C);
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            // 
            var myTruthTable = GenerateTruthTable().ToList();
            //Print only true values
            foreach (var item in myTruthTable)
            {
                if (item.GetTruthValue())
                    Console.WriteLine("{0}, {1}, {2}", item.A, item.B, item.C);
            }

            ////Print all values
            //foreach (var itemTruthRow in myTruthTable)
            //{
            //    Console.WriteLine("{0}, {1}, {2}", itemTruthRow.A, itemTruthRow.B, itemTruthRow.C);
            //}
            ////Print only false values
            //foreach (var item in myTruthTable)
            //{
            //    if (!item.GetTruthValue())
            //        Console.WriteLine("{0}, {1}, {2}", item.A, item.B, item.C);
            //}
            Console.ReadLine();
        }

        // 
        public static IEnumerable<MyCustomThreeItemTruthRow> GenerateTruthTable()
        {
            for (var a = 0; a < 2; a++)
                for (var b = 0; b < 2; b++)
                    for (var c = 0; c < 2; c++)
                        yield return new MyCustomThreeItemTruthRow(
                            Convert.ToBoolean(a),
                            Convert.ToBoolean(b),
                            Convert.ToBoolean(c));
        }
    }
}