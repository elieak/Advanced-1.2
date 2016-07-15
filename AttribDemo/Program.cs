using System;
using System.Reflection;

namespace AttribDemo
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(AnalayzeAssembly(Assembly.GetExecutingAssembly()));
        }

        [CodeReview("Elie A", "", true)]
        public class A { }

        [CodeReview("Elie B", "", true)]
        public class B { }

        [CodeReview("Elie C", "", false)]
        public class C { }

        private static bool AnalayzeAssembly(Assembly myAssembly)
        {
            foreach (var attribute in myAssembly.GetTypes())
            {
                var attributeList = attribute.GetCustomAttributes(typeof(CodeReviewAttribute), false);

                foreach (CodeReviewAttribute reviewAttribute in attributeList)
                {
                    Console.WriteLine($"Code review for type {attribute.Name}");
                    Console.WriteLine($"Name: {reviewAttribute._reviewerName}, " +
                                      $"Date: {reviewAttribute._reviewerDate}, " +
                                      $"Approved: {reviewAttribute._approved}");

                    if (reviewAttribute._approved) continue;
                    return false;
                }
            }
            return true;
        }
    }
}
