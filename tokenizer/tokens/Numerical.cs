using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator.tokenizer.tokens
{
    
    class Numerical : Token
    {
        private double value;

        public Numerical(double value)
        {
            this.value = value;
        }

        public Numerical(string value)
        {
            if (!double.TryParse(value, out this.value))
            {
                throw new FormatException("Can not parse non-numerical values as Numerical Token: " + value + " is not numerical");
            }
        }

        public double getValue()
        {
            return value;
        }

        public string toString()
        {
            return "Numerical: " + value.ToString();
        }
    }
}
