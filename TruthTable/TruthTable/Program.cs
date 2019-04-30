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
using System.Collections.Generic;

namespace TruthTable
{
    public abstract class ThreeItemTruthRow
    {
        protected ThreeItemTruthRow(bool p, bool q, bool r)
        {
            P = p; Q = q; R = r;
        }

        public bool P { get; protected set; }
        public bool Q { get; protected set; }
        public bool R { get; protected set; }

        public abstract bool GetTruthValue();
    }

    public class MyCustomThreeItemTruthRow : ThreeItemTruthRow
    {
        public MyCustomThreeItemTruthRow(bool p, bool q, bool r)
            : base(p, q, r)
        {
        }

        public override bool GetTruthValue()
        {
            // My custom logic
            return (!P && Q && R) || (P && !Q && R) || (P && Q && !R) || (P && Q && R);
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            // Print Header P Q R
            Console.WriteLine(" P   |  Q  |  R");
            var myTruthTable = GenerateTruthTable();//.ToList();
            //Print only true values
            //foreach (var item in myTruthTable)
            //{
            //    if (item.GetTruthValue())
            //        Console.WriteLine("{0}, {1}, {2}", item.P, item.Q, item.R);
            //}

            ////Print all values
            //foreach (var itemTruthRow in myTruthTable)
            //{
            //    Console.WriteLine("{0}, {1}, {2}", itemTruthRow.P, itemTruthRow.Q, itemTruthRow.R);
            //}
            //Print P and Q values
            foreach (var itemTruthRow in myTruthTable)
            {
                Console.WriteLine("{0}, {1}", itemTruthRow.P, itemTruthRow.Q);
            }
            ////Print only false values
            //foreach (var item in myTruthTable)
            //{
            //    if (!item.GetTruthValue())
            //        Console.WriteLine("{0}, {1}, {2}", item.P, item.Q, item.R);
            //}

            // Evaluate P OR Q and print values.
            Console.WriteLine("\n P OR Q ");
            foreach (var itemTruthRow in myTruthTable)
            {
                if (itemTruthRow.P || itemTruthRow.Q)    
                    Console.WriteLine(true);
                else
                    Console.WriteLine(false);

            }
            Console.ReadLine();
        }

        // 
        public static IEnumerable<MyCustomThreeItemTruthRow> GenerateTruthTable()
        {
            for (var p = 0; p < 2; p++)
                for (var q = 0; q < 2; q++)
                    for (var r = 0; r < 2; r++)
                        yield return new MyCustomThreeItemTruthRow(
                            Convert.ToBoolean(p),
                            Convert.ToBoolean(q),
                            Convert.ToBoolean(r));
        }
    }
}
