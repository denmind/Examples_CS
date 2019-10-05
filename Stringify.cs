using System;

namespace Example_1
{
    internal class Stringify
    {
        public void Demonstrate()
        {
            string input = "";

            Console.WriteLine("#1 Stringify demo: ");
            Console.WriteLine("Function will accept a number from 1 to 999 and convert it to a word number\n");

            while (input != "EXIT")
            {
                int number;

                Console.Write("Enter number [1-999]:\t");

                input = Console.ReadLine();
                number = int.Parse(input);
                input = Wordify(number);

                Console.WriteLine("Equivalent of {0}:\t{1}\n", number, input);
            }
        }

        private string Wordify(int num)
        {
            string value = "N/A";

            if (Between(num, 1, 9, true))
            {
                //Ones place
                value = Ones(num);
            }
            else if (Between(num, 10, 19, true))
            {
                //Special case
                value = Special(num);
            }
            else if (Between(num, 20, 99, true))
            {
                int ones = num % 10,
                    tens = num / 10;

                //Tenths place
                value = Tenths(tens);

                //Ones place
                value += (ones == 0) ? Special(tens) : Ones(ones);
            }
            else if (Between(num, 100, 999, true))
            {
                int hundredths = num / 100,
                    tens = (num / 10) % 10,
                    ones = num % 10;

                //Hundredths place
                value = Hundredths(hundredths);

                //Tenths place
                if (tens != 0)
                {
                    value += Tenths(tens);
                }

                //Ones place
                value += (ones == 0) ? Special(tens) : Ones(ones);
            }

            return value;
        }

        private bool Between(int number, int left, int right, bool inclusive)
        {
            bool value;

            if (inclusive)
            {
                value = (number >= left && number <= right);
            }
            else
            {
                value = (number > left && number < right);
            }

            return value;
        }

        private string Special(int num)
        {
            string value = "";

            switch (num)
            {
                case 10: value = "ten"; break;
                case 11: value = "eleven"; break;
                case 12: value = "twelve"; break;
                case 13: value = "thirteen"; break;
                case 14: value = "fourteen"; break;
                case 15: value = "fifteen"; break;
                case 16: value = "sixteen"; break;
                case 17: value = "seventeen"; break;
                case 18: value = "eighteen"; break;
                case 19: value = "nineteen"; break;
            }

            return value;
        }
        private string Hundredths(int num)
        {
            string value = "";

            //Get equivalent
            value = Ones(num);

            //Add word hundred
            value += " hundred";

            //Add space
            value += " ";

            return value;
        }
        private string Tenths(int num)
        {
            string value = "";

            switch (num)
            {
                case 2: value = "twenty"; break;
                case 3: value = "thirty"; break;
                case 4: value = "fourty"; break;
                case 5: value = "fifty"; break;
                case 6: value = "sixty"; break;
                case 7: value = "seventy"; break;
                case 8: value = "eighty"; break;
                case 9: value = "ninety"; break;
            }

            //Add space
            value += " ";

            return value;
        }
        private string Ones(int num)
        {
            string value = "";

            switch (num)
            {
                case 1: value = "one"; break;
                case 2: value = "two"; break;
                case 3: value = "three"; break;
                case 4: value = "four"; break;
                case 5: value = "five"; break;
                case 6: value = "six"; break;
                case 7: value = "seven"; break;
                case 8: value = "eight"; break;
                case 9: value = "nine"; break;
            }

            return value;
        }
    }
}
