using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEvaluator.tokenizer.tokens
{
    class Operation : Token
    { 
        private OperatorEnum opType;
        private PrecedenceEnum precedence;
        public Operation(string op)
        {
            findType(op);
        }

        private void findType(string op)
        {
            switch (op)
            {
                case "+": opType = OperatorEnum.Addition; precedence = PrecedenceEnum.Left; break;
                case "-": opType = OperatorEnum.Subtraction; precedence = PrecedenceEnum.Left; break;
                case "*": opType = OperatorEnum.Multiplication; precedence = PrecedenceEnum.Left; break;
                case "/": opType = OperatorEnum.Divition; precedence = PrecedenceEnum.Left; break;
                case "^": opType = OperatorEnum.Power; precedence = PrecedenceEnum.Right; break;
                default: throw new InvalidOperationException(op + " is not an operation!");
            }
                
        }

        public PrecedenceEnum getPrecedence()
        {
            return precedence;
        }
        public string toString()
        {
            return "Operation: " + opType.ToString();
        }
    }
}
