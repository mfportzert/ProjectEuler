using System;
namespace ProjectEuler
{
    public class NumberToLetters
    {
        private static string[] s_Digits = new string[10]
        {
            "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
        };

        private static string[] s_TenToNineteen = new string[10]
        {
            "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
        };

        private static string[] s_Tens = new string[10]
        {
            "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
        };

        private static string s_Hundred = "hundred";

        private static string[] s_Milestones = new string[3]
        {
            "", "thousand", "million"
        };

        private enum Prefix
        {
            None = 0,
            Space = 1,
            And = 2,
            Dash = 3,
        }

        private static Dictionary<Prefix, string> s_Prefixes = new Dictionary<Prefix, string>()
        {
            { Prefix.None, "" },
            { Prefix.Space, " " },
            { Prefix.And, " and " },
            { Prefix.Dash, "-" },
        };

        public static string Convert(int number)
        {
            string letters = string.Empty;
            var strNumber = number.ToString();
            var length = strNumber.Length;
            Prefix nextPrefix = Prefix.None;
            for (int i = 0; i < length;)
            {
                int milestoneIndex = (int) Math.Floor(((length - i) - 1) / 3f);

                if ((length - i) % 3 == 0) // hundreds
                {
                    int digit = strNumber[i] - '0';
                    if (digit != 0)
                    {
                        if (nextPrefix == Prefix.And)
                            nextPrefix = Prefix.Space;

                        letters += s_Prefixes[nextPrefix] + s_Digits[digit] + " " + s_Hundred;
                        nextPrefix = Prefix.And;
                    }
                    i++;
                }

                if ((length - i) % 3 == 2) // tens
                {
                    int digit = strNumber[i] - '0';
                    if (digit != 0)
                    {
                        letters += s_Prefixes[nextPrefix];

                        var nextDigit = strNumber[i + 1] - '0';
                        if (digit == 1)
                        {
                            letters += s_TenToNineteen[nextDigit];
                            nextPrefix = Prefix.Space;
                            i++;
                        }
                        else
                        {
                            letters += s_Tens[digit];
                            nextPrefix = nextDigit != 0 ? Prefix.Dash : Prefix.None;
                        }
                    }
                    i++;
                }

                if ((length - i) % 3 == 1) // single digits
                {
                    int digit = strNumber[i] - '0';
                    if (digit != 0)
                        letters += s_Prefixes[nextPrefix] + s_Digits[digit];
                    i++;
                    nextPrefix = Prefix.Space;
                }

                letters += s_Prefixes[nextPrefix] + s_Milestones[milestoneIndex];
                nextPrefix = Prefix.And;
            }
            return letters;
        }
    }
}

