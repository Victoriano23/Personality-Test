using System;
namespace Reflection
{
    class Program
    {
        static Dictionary<string, string> testResults = new Dictionary<string, string>(); // Stores Results Data
        static string userName;

        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Personality and Skills Assesment Program!");
            Console.WriteLine("The Personality and Skills Assessment Program is a tool designed to help individuals gain a deeper understanding of their unique personality traits and core skills.");
            Console.WriteLine("By engaging in a series of thoughtfully crafted questions, users will receive information about themselves.");
            Console.WriteLine("Please Enter your username");
            userName = Console.ReadLine();

            while (true)
            {
                // Clear the console screen
                Console.Clear();
                // Display selection menu

                Console.WriteLine("***********************************");
                Console.WriteLine("*     KNOW MORE ABOUT YOURSELF    *");
                Console.WriteLine("***********************************");
                Console.WriteLine("*  1. WHATS YOUR ZODIAC SIGN      *");
                Console.WriteLine("*  2. PERSONALITY TEST            *");
                Console.WriteLine("*  3. EQ TEST                     *");
                Console.WriteLine("*  4. CREATIVITY TEST             *");
                Console.WriteLine("*  5. SOCIAL TEST                 *");
                Console.WriteLine("*  6. VIEW TEST RESULTS           *");
                Console.WriteLine("*  7. EXIT                        *");
                Console.WriteLine("***********************************");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        zodiacsign();
                        break;
                    case 2:
                        personalitytest();
                        break;
                    case 3:
                        EQTEST();
                        break;
                    case 4:
                        creativityTest();
                        break;
                    case 5:
                        socialTest();
                        break;
                    case 6:
                        viewTestResults();
                        break;
                    case 7:
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("INVALID CHOICE.");
                        break;
                }
            }
        }

        // View Test Results
        static void viewTestResults()
        {
            Console.Clear();
            Console.WriteLine("********* TEST RESULTS *********");
            Console.WriteLine($"User: {userName}");

            if (testResults.Count == 0)
            {
                Console.WriteLine("No test results available.");
            }
            else
            {
                foreach (var result in testResults)
                {
                    Console.WriteLine($"{result.Key}: {result.Value}");
                }
            }

            Console.WriteLine("\nPress enter to continue");
            Console.ReadLine(); // Keep console open until user input
        }

        // Method to run zodiac sign
        static void zodiacsign()
        {
            Console.Clear();
            Console.WriteLine("Enter your birthdate (YYYY-MM-DD):");

            DateTime birthdate;
            if (!DateTime.TryParse(Console.ReadLine(), out birthdate))
            {
                Console.WriteLine("Invalid date format.");
                Console.ReadLine();
                return;
            }

            int age = CalculateAge(birthdate);
            string zodiacSign = GetZodiacSign(birthdate.Month, birthdate.Day);

            Console.WriteLine($"Your age is: {age}");
            Console.WriteLine($"Your zodiac sign is: {zodiacSign}");
            testResults["Zodiac Sign"] = $"Age: {age}, Sign: {zodiacSign}";

            Console.ReadLine();
        }

        static int CalculateAge(DateTime birthdate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthdate.Year;
            if (birthdate > today.AddYears(-age))
                age--;
            return age;
        }

        // Function to determine zodiac sign based on month and day
        static string GetZodiacSign(int month, int day)
        {
            if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
                return "Aries";
            else if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
                return "Taurus";
            else if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
                return "Gemini";
            else if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
                return "Cancer";
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
                return "Leo";
            else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
                return "Virgo";
            else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
                return "Libra";
            else if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
                return "Scorpio";
            else if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
                return "Sagittarius";
            else if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
                return "Capricorn";
            else if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
                return "Aquarius";
            else if ((month == 2 && day >= 19) || (month == 3 && day <= 20))
                return "Pisces";
            else
                return "Unknown";
        }

        // Method to play personality test
        static void personalitytest()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Personality Type Quiz!");
            Console.WriteLine("For each statement, enter a number from 1 to 5 based on how well it describes you.");
            Console.WriteLine("1: Strongly Disagree");
            Console.WriteLine("2: Disagree");
            Console.WriteLine("3: Neutral");
            Console.WriteLine("4: Agree");
            Console.WriteLine("5: Strongly Agree");

            string[] Questions = {
                "Do You feel energized after spending time with a large group of people.",
                "Do You prefer one-on-one conversations over group activities.",
                "Do You enjoy spending time alone to recharge.",
                "Do You feel comfortable being the center of attention in social situations.",
                "Do You find it easy to strike up a conversation with new people.",
                "Do You prefer a few close friends over many acquaintances.",
                "Do You tend to think before I speak.",
                "Do You often feel lonely if I don't have social interaction for a while.",
                "Do You enjoy participating in group activities and events.",
                "Do You find it exhausting to be in social settings for long periods of time."
            };

            int[] responses = new int[Questions.Length];

            // Ask Questions
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine($"\nQuestion {i + 1}: {Questions[i]}");
                responses[i] = GetValidResponse();
            }

            // Calculate total score
            int totalScore = CalculateTotalScore(responses);

            // Determine personality type based on score
            string personalityType = DeterminePersonalityType(totalScore);

            // Displays Personanlity Description
            string personalityDescription = ExplainPersonalityDescription(totalScore);

            // Output results
            Console.Clear();
            Console.WriteLine("\nPersonality Type Quiz Results:");
            Console.WriteLine($"Total Score: {totalScore}");
            Console.WriteLine($"Personality Type: {personalityType}");
            Console.WriteLine($"Personality Description: {personalityDescription}");
            testResults["Personality Test"] = $"Total Score: {totalScore}, Type: {personalityType}";

            Console.WriteLine("Press enter to continue");
            Console.ReadLine(); // Keep console open until user input
        }

        // Function to ensure valid response (1-5)
        static int GetValidResponse()
        {
            int response;
            while (!int.TryParse(Console.ReadLine(), out response) || response < 1 || response > 5)
            {
                Console.WriteLine("Please enter a number between 1 and 5.");
            }
            return response;
        }

        // Function to calculate total score
        static int CalculateTotalScore(int[] responses)
        {
            int totalScore = 0;
            foreach (int response in responses)
            {
                totalScore += response;
            }
            return totalScore;
        }

        // Function to determine personality type score
        static string DeterminePersonalityType(int totalScore)
        {
            if (totalScore >= 10 && totalScore <= 24)
            {
                return "Introvert";
            }
            else if (totalScore >= 25 && totalScore <= 34)
            {
                return "Ambivert";
            }
            else if (totalScore >= 35 && totalScore <= 50)
            {
                return "Extrovert";
            }
            else
            {
                return "Unknown";
            }
        }

        // Function to explain personality description based on total score
        static string ExplainPersonalityDescription(int totalScore)
        {
            if (totalScore >= 10 && totalScore <= 24)
            {
                return "You are someone who feels energized by the external world and social interactions.";
            }
            else if (totalScore >= 25 && totalScore <= 34)
            {
                return "You are a flexible individual who thrives both in solitude and company, and you make a great communicator and listener.";
            }
            else if (totalScore >= 35 && totalScore <= 50)
            {
                return "You are very talkative, sociable, active, and warm.";
            }
            else
            {
                return "Personality type cannot be determined with provided answers.";
            }
        }

        // Method to start EQ test
        static void EQTEST()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Emotional Intelligence Test!");
            Console.WriteLine("Answer each question to assess your emotional intelligence level.");
            Console.WriteLine("Please enter a number between 1 and 5 based on how well each statement applies to you.");
            Console.WriteLine("1: Strongly Disagree");
            Console.WriteLine("2: Disagree");
            Console.WriteLine("3: Neutral");
            Console.WriteLine("4: Agree");
            Console.WriteLine("5: Strongly Agree");

            string[] questions = {
                "I am aware of my emotions as I experience them.",
                "I can manage my emotions effectively, even in difficult situations.",
                "I am empathetic and can understand how others are feeling.",
                "I can build and maintain strong relationships with others.",
                "I am able to resolve conflicts in a positive manner."
            };

            int[] responses = new int[questions.Length];

            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"\nQuestion {i + 1}: {questions[i]}");
                responses[i] = GetValidResponse();
            }

            int totalScore = CalculateTotalScore(responses);
            string EQLevel = DetermineEQLevel(totalScore);

            Console.Clear();
            Console.WriteLine("\nEmotional Intelligence Test Results:");
            Console.WriteLine($"Total Score: {totalScore}");
            Console.WriteLine($"Emotional Intelligence Level: {EQLevel}");
            testResults["EQ Test"] = $"Total Score: {totalScore}, Level: {EQLevel}";

            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        // Determine EQ Level based on score
        static string DetermineEQLevel(int totalScore)
        {
            if (totalScore >= 20 && totalScore <= 25)
            {
                return "High EQ";
            }
            else if (totalScore >= 15 && totalScore <= 19)
            {
                return "Moderate EQ";
            }
            else if (totalScore >= 10 && totalScore <= 14)
            {
                return "Low EQ";
            }
            else
            {
                return "Very Low EQ";
            }
        }

        // Creativity Test
        static void creativityTest()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Creativity Test!");
            Console.WriteLine("Answer the following questions to assess your creativity level.");
            Console.WriteLine("Please enter a number between 1 and 5 based on how well each statement applies to you.");
            Console.WriteLine("1: Strongly Disagree");
            Console.WriteLine("2: Disagree");
            Console.WriteLine("3: Neutral");
            Console.WriteLine("4: Agree");
            Console.WriteLine("5: Strongly Agree");

            string[] questions = {
                "When faced with a problem, I often come up with multiple solutions.",
                "I enjoy imagining new and unusual scenarios.",
                "I often find myself thinking outside the box.",
                "I like experimenting with different ideas to see what works.",
                "I feel confident in my ability to generate innovative ideas."
            };

            int[] responses = new int[questions.Length];

            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"\nQuestion {i + 1}: {questions[i]}");
                responses[i] = GetValidResponse();
            }

            int totalScore = CalculateTotalScore(responses);
            string creativityLevel = DetermineCreativityLevel(totalScore);

            Console.Clear();
            Console.WriteLine("\nCreativity Test Results:");
            Console.WriteLine($"Total Score: {totalScore}");
            Console.WriteLine($"Creativity Level: {creativityLevel}");
            testResults["Creativity Test"] = $"Total Score: {totalScore}, Level: {creativityLevel}";

            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        static string DetermineCreativityLevel(int totalScore)
        {
            if (totalScore >= 20 && totalScore <= 25)
            {
                return "Highly Creative";
            }
            else if (totalScore >= 15 && totalScore <= 19)
            {
                return "Moderately Creative";
            }
            else if (totalScore >= 10 && totalScore <= 14)
            {
                return "Somewhat Creative";
            }
            else
            {
                return "Not Very Creative";
            }
        }

        // Social Test
        static void socialTest()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Social Interaction Test!");
            Console.WriteLine("Answer the following questions to assess your social skills.");
            Console.WriteLine("Please enter a number between 1 and 5 based on how well each statement applies to you.");
            Console.WriteLine("1: Strongly Disagree");
            Console.WriteLine("2: Disagree");
            Console.WriteLine("3: Neutral");
            Console.WriteLine("4: Agree");
            Console.WriteLine("5: Strongly Agree");

            string[] questions = {
                "I find it easy to strike up a conversation with new people.",
                "I enjoy attending social gatherings and meeting new people.",
                "I feel comfortable being the center of attention in social situations.",
                "I can easily understand social cues and respond appropriately.",
                "I feel energized after spending time with a large group of people."
            };

            int[] responses = new int[questions.Length];

            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"\nQuestion {i + 1}: {questions[i]}");
                responses[i] = GetValidResponse();
            }

            int totalScore = CalculateTotalScore(responses);
            string socialLevel = DetermineSocialLevel(totalScore);

            Console.Clear();
            Console.WriteLine("\nSocial Interaction Test Results:");
            Console.WriteLine($"Total Score: {totalScore}");
            Console.WriteLine($"Social Interaction Level: {socialLevel}");
            testResults["Social Test"] = $"Total Score: {totalScore}, Level: {socialLevel}";

            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        static string DetermineSocialLevel(int totalScore)
        {
            if (totalScore >= 20 && totalScore <= 25)
            {
                return "Highly Social";
            }
            else if (totalScore >= 15 && totalScore <= 19)
            {
                return "Moderately Social";
            }
            else if (totalScore >= 10 && totalScore <= 14)
            {
                return "Somewhat Social";
            }
            else
            {
                return "Less Social";
            }
        }
    }
}
