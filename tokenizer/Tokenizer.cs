using ExpressionEvaluator.tokenizer.tokens;
using System;
using System.Collections.Generic;

namespace ExpressionEvaluator.tokenizer.tokens
{
    class Tokenizer
    {
        String stringRep;

        public Tokenizer(String s)
        {
            stringRep = s;
            Queue<Token> output = Tokenize(stringRep);

            foreach (Token t in output)
            {
                Console.WriteLine(t.toString());
            }

        }

        /// <summary>
        /// Produces a queue of tokens from a list of Strings
        /// </summary>
        /// <param name="input"></param>
        /// <returns>A queue object with input split up and tokenized</returns>
        private Queue<Token> Tokenize(string input)
        {
            List<string> splitString = split(input);
            Queue<Token> outputQueue = new Queue<Token>();

            foreach (string token in splitString) //read a token
            {
                Console.Write("Found token: " + token);
                if (isNumber(token))
                {
                    outputQueue.Enqueue(new Numerical(token));
                }
                else if (isOperator(token)) //token is an operator
                { 
                    outputQueue.Enqueue(new Operation(token));
                }
            }    

            return outputQueue;

        }

        public List<String> split(String input)
        {
            string noSpace = string.Concat(input.Split(' '));
            char[] chars = noSpace.ToCharArray();
            List<String> output = new List<String>();


            int i = 0;
            while (i < chars.Length) //traverse char array
            {
                int nextIndex = i;
                while (nextIndex < chars.Length && isSameType(chars[i], chars[nextIndex])) //as long as they are of the same type, continue...
                {
                    nextIndex++;
                }
                output.Add(noSpace.Substring(i, nextIndex - i));
                i = nextIndex;

            }

            return output;

        }

        private bool isSameType(char c1, char c2)
        {
            return (isSpace(c1) && isSpace(c2)) || (isNumber(c1) && isNumber(c2)) || (isOperator(c1) && isOperator(c2));
        }

        private bool isSpace(String s)
        {
            foreach (char c in s)
            {
                if (!isSpace(c))
                {
                    return false;
                }
            }
            return true;
        }

        private bool isSpace(char symbol)
        {
            return symbol == 32;
        }

        private bool isNumber(String s)
        {
            foreach (char c in s)
            {
                if (!isNumber(c))
                {
                    return false;
                }
            }
            return true;
        }

        private bool isNumber(char symbol)
        {
            return (symbol >= 48 && symbol <= 57);
        }

        private bool isOperator(String s)
        {
            foreach (char c in s)
            {
                if (!isOperator(c))
                {
                    return false;
                }
            }
            return true;
        }

        private bool isOperator(char symbol)
        {
            return (symbol == 42 || symbol == 43 || symbol == 45 || symbol == 47);
        }
    }
}
