using ExpressionEvaluator.tokenizer.tokens;
using ExpressionEvaluator.tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string s = "14 + 4 + 6 - 6 / 34*55-55";
            Tokenizer tizer = new Tokenizer(s);

            Console.ReadKey();
        }
    }
}
