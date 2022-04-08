using System;
using System.Threading;

namespace questions
{
    internal class Program
    {
        public const int row = 4;
        public const int col = 10;
        static int level = 0;
        static char answer;
        static int typeOfAnswer = 0;
        static int checkAnswer = 2;
        static int score = 0;
        static string[,] questions = new string[col, row]
        {
                {
                    " 1. Which one is most powerful groups in Azerbaijan army?",
                    "XTQ",
                    "DTX",
                    "XTD"
                },
                {
                    " 2. When started second Karabkh War?",
                    "27 September 2020",
                    "20 January 1992",
                    "3 April 2016"
                },
                {
                    " 3. When Fatih Sultan Mehmet conquered Istanbul?",
                    "1453",
                    "1542",
                    "1121"
                },
                {
                    " 4. Palastine (Jerusalem) occupied by ..?",
                    "Israel",
                    "Syria",
                    "America"
                },
                {
                    " 5. When was hijrat?",
                    "622",
                    "640",
                    "654"
                },
                {
                    " 6. Who was first khalifa?",
                    "Abu Bakr",
                    "Omar bin Khattab",
                    "Ali bin Abutalib"
                },
                {
                    " 7. How many times is prayer commanded in the Quran?",
                    "5",
                    "3",
                    "7"
                },
                {
                    " 8. What is a person who does not pray intentionally?",
                    "Kafir",
                    "Still Muslim",
                    "Christian"
                },
                {
                    " 9. Which is not an excuse not to pray?",
                    "my heart is clean",
                    "to fall asleep",
                    "forget"
                },
                {
                    " 10. What will happen before the end of the world?",
                    "Muslims will get win!",
                    "No one knows it.",
                    "Humanity will destroy themselves..."
                },
        };

        static void Visual()
        {
            Console.WindowHeight = 30;
            Console.WindowWidth = 100;
            Console.Title = "Anket.exe";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Magenta;
        }

        static void Question()
        {
            Console.WriteLine("\t\t\t\t\tAnket");
            Console.WriteLine("\n" + questions[level, 0] + "\n");
        }

        static void Answers()
        {
            Random random = new Random();
            int answerType = 0;
            answerType = random.Next(1, 4);
            if (answerType == 1)
            {
                if (checkAnswer == 1) { Console.BackgroundColor = ConsoleColor.Green; Console.ForegroundColor = ConsoleColor.Black; }
                if (checkAnswer == 0) { Console.BackgroundColor = ConsoleColor.Red; Console.ForegroundColor = ConsoleColor.Black; }
                if (checkAnswer == 2) { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Magenta; }
                Console.WriteLine(" A) " + questions[level, 1]);
                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(" B) " + questions[level, 2]);
                Console.WriteLine(" C) " + questions[level, 3]);
                typeOfAnswer = 1;
                if (checkAnswer == 1 || checkAnswer == 0) { Score(); Thread.Sleep(2000); checkAnswer = 2; }
            }
            else if (answerType == 2)
            {
                if (checkAnswer == 2) { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Magenta; }
                Console.WriteLine(" A) " + questions[level, 3]);
                Console.WriteLine(" B) " + questions[level, 2]);
                if (checkAnswer == 1) { Console.BackgroundColor = ConsoleColor.Green; Console.ForegroundColor = ConsoleColor.Black; }
                if (checkAnswer == 0) { Console.BackgroundColor = ConsoleColor.Red; Console.ForegroundColor = ConsoleColor.Black; }
                Console.WriteLine(" C) " + questions[level, 1]);
                typeOfAnswer = 2;
                if (checkAnswer == 1 || checkAnswer == 0) { Score(); Thread.Sleep(2000); checkAnswer = 2; }
            }
            else
            {
                if (checkAnswer == 2) { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Magenta; }
                Console.WriteLine(" A) " + questions[level, 2]);
                if (checkAnswer == 1) { Console.BackgroundColor = ConsoleColor.Green; Console.ForegroundColor = ConsoleColor.Black; }
                if (checkAnswer == 0) { Console.BackgroundColor = ConsoleColor.Red; Console.ForegroundColor = ConsoleColor.Black; }
                Console.WriteLine(" B) " + questions[level, 1]);
                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(" C) " + questions[level, 3]);
                typeOfAnswer = 3;
                if (checkAnswer == 1 || checkAnswer == 0) { Score(); Thread.Sleep(2000); checkAnswer = 2; }
            }
            answerType = 0;
        }

        static void Check()
        {
            if (typeOfAnswer == 1 && answer == 'a' || typeOfAnswer == 2 && answer == 'c' || typeOfAnswer == 3 && answer == 'b')
            {
                checkAnswer = 1; score += 10;
            }
            else { checkAnswer = 0; score -= 10; }
        }

        static void Score()
        {
            Visual();
            if (score < 0)
            {
                score = 0;
            }
            Console.WriteLine("\n Score: " + score);
        }

        static void Result()
        {
            Visual();
            Console.Clear();
            Console.WriteLine("\n\t\t\tQuiz Complented");
            Console.WriteLine("\n\nYour Score is: " + score);
        }

        static void Play()
        {
            for (int i = 0; i < col; i++)
            {
                Question();
                Answers();
                Score();
                answer = (Console.ReadKey(intercept: true).KeyChar);
                Console.Clear();
                Check();
                Question();
                Answers();
                Score();
                Console.Clear();
                Visual();
                checkAnswer = 2;
                level++;
                if (level == 10) Result();
            }
        }

        static void Run()
        {
            Visual();
            Play();
        }
        static void Main(string[] args)
        {
            Visual();
            Run();

            Console.ReadKey();
        }
    }
}
