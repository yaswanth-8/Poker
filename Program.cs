namespace PokerCombination
{
    internal class Poker
    {
        public static char[] pokerArr = { 'A', '2', '3', '4', '5', '6', '7', '8', '9', '1', 'J', 'Q', 'K' };
        public static string[] inputPoker = { "", "", "", "", "" };
        static void Main(string[] args)
        {
            //string[] inputPoker = { "8h", "6h", "Qh", "4h", "Jh" };
            Console.WriteLine("Enter Poker Ranking");
            for (int i = 0; i < inputPoker.Length; i++)
            {
                inputPoker[i] = Console.ReadLine();
            }

            /*string[] inputRoyalFlush = { "10h", "Jh", "Qh", "Ah", "Kh" };
            string[] inputStraightFlush = { "2h", "3h", "4h", "5h", "6h" };
            string[] inputFourOfAKind = { "8s", "10c", "10d", "10d", "10h" };
            string[] inputFullHouse = {"6c", "6h", "6d","Ks", "Kh" };
            string[] inputFlush = { "8h", "6h", "Qh", "Ah", "Kh" };
            string[] inputStraight = { "2h", "3h", "4h", "5c", "6d" };
            string[] inputThreeOfAKind = { "8s", "9c", "8d", "10d", "8h" };
            string[] inputTwoPair = { "8h", "8h", "Qh", "Kh", "Qh" };
            string[] inputPair = { "8h", "8h", "Qh", "Kh", "Jh" };*/


            if (isRoyalFlush(inputPoker))
            {
                Console.WriteLine("ROYAL FLUSH");
            }
            else if (isStraightFlush(inputPoker))
            {
                Console.WriteLine("STRAIGHT FLUSH");
            }
            else if (isFourOfAKind(inputPoker))
            {
                Console.WriteLine("FOUR OF A KIND");
            }
            else if (isFullHouse(inputPoker))
            {
                Console.WriteLine("FULL HOUSE");
            }
            else if (isFlush(inputPoker))
            {
                Console.WriteLine("FLUSH");
            }
            else if (isStraight(inputPoker))
            {
                Console.WriteLine("STRAIGHT");
            }
            else if (isThreeOfAKind(inputPoker))
            {
                Console.WriteLine("THREE OF A KIND");
            }
            else if (isTwoPair(inputPoker))
            {
                Console.WriteLine("TWO PAIR");
            }
            else if (isPair(inputPoker))
            {
                Console.WriteLine("PAIR");
            }
            else
            {
                Console.WriteLine("HIGH CARD");
            }

        }
        public static bool isRoyalFlush(string[] input)
        {
            if (input[0][0] == '1' && input[1][0] == 'J' && input[2][0] == 'Q' && input[3][0] == 'A' && input[4][0] == 'K')
            {
                if (isSameSuit(input))
                {
                    return true;
                }
                /*if (input[0][2] == 'h' && input[1][1] == 'h' && input[2][1] == 'h' && input[3][1] == 'h' && input[4][1] == 'h')
                {
                    return true;
                }*/
            }
            return false;
        }
        public static bool isSameSuit(string[] input)
        {
            char theChar = input[0][input[0].Length - 1];
            for (int i = 0; i < 5; i++)
            {
                if (input[i][input[i].Length - 1] != theChar)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool isStraightFlush(string[] input)
        {
            for (int i = 0; i < 9; i++)
            {
                if (input[0][0] == pokerArr[i])
                {
                    if (input[1][0] == pokerArr[i + 1] && input[2][0] == pokerArr[i + 2] && input[3][0] == pokerArr[i + 3] && input[4][0] == pokerArr[i + 4])
                    {
                        if (input[0][1] == 'h' && input[1][1] == 'h' && input[2][1] == 'h' && input[3][1] == 'h' && input[4][1] == 'h')
                        {
                            return true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return false;
        }
        public static bool isFourOfAKind(string[] input)
        {
            char check = ' ';
            int count = 1;
            for (int i = 0; i < 2; i++)
            {
                count = 1;
                check = input[i][0];
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (check == input[j][0])
                    {
                        count++;
                        if (count == 4)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        public static bool isFullHouse(string[] input)
        {
            Dictionary<char, int> pokerDict = new Dictionary<char, int>();
            char oneChar = input[0][1];
            for (int i = 0; i < input.Length; i++)
            {
                if (pokerDict.ContainsKey(input[i][0]))
                {
                    pokerDict[input[i][0]] += 1;
                }
                else
                {
                    pokerDict.Add(input[i][0], 1);
                    oneChar = input[i][0];
                }
            }
            if (pokerDict.Count == 2 && (pokerDict[oneChar] == 2 || pokerDict[oneChar] == 3))
            {
                return true;
            }
            return false;
        }
        public static bool isFlush(string[] input)
        {
            char theChar = input[0][input[0].Length - 1];

            for (int i = 0; i < 5; i++)
            {
                if (input[i][input[i].Length - 1] == theChar)
                {
                    if (i > 0 && input[i - 1][0] == 'J' && input[i][0] == 'Q')
                    {
                        return false;
                    }
                    if (i > 0 && input[i - 1][0] == 'Q' && input[i][0] == 'K')
                    {
                        return false;
                    }
                    if (i > 0 && input[i - 1][0] == '1' && input[i][0] == 'J')
                    {
                        return false;
                    }
                    if (i > 0 && input[i - 1][0] == 'A' && input[i][0] == '2')
                    {
                        return false;
                    }

                    if (i > 0 && input[i - 1][0] == input[i][0] - 1)
                    {
                        return false;
                    }
                    continue;
                }
                else
                {
                    return false;
                }

            }
            return true;
        }
        public static bool isStraight(string[] input)
        {
            for (int i = 0; i < 9; i++)
            {
                if (input[0][0] == pokerArr[i])
                {
                    if (input[1][0] == pokerArr[i + 1] && input[2][0] == pokerArr[i + 2] && input[3][0] == pokerArr[i + 3] && input[4][0] == pokerArr[i + 4])
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return false;
        }
        public static bool isThreeOfAKind(string[] input)
        {
            char check = ' ';
            int count = 1;
            for (int i = 0; i < 3; i++)
            {
                count = 1;
                check = input[i][0];
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (check == input[j][0])
                    {
                        count++;
                        if (count == 3)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        public static bool isTwoPair(string[] input)
        {
            Dictionary<char, int> pokerDict = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (pokerDict.ContainsKey(input[i][0]))
                {
                    pokerDict[input[i][0]] += 1;
                }
                else
                {
                    pokerDict.Add(input[i][0], 1);
                }
            }
            foreach (var key in pokerDict.Keys)
            {
                if (pokerDict[key] > 2)
                {
                    return false;
                }
            }
            if (pokerDict.Count == 3)
            {
                return true;
            }
            return false;
        }
        public static bool isPair(string[] input)
        {
            Dictionary<char, int> pokerDict = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (pokerDict.ContainsKey(input[i][0]))
                {
                    pokerDict[input[i][0]] += 1;
                }
                else
                {
                    pokerDict.Add(input[i][0], 1);
                }
            }
            if (pokerDict.Count == 4)
            {
                return true;
            }
            return false;
        }
    }
}
