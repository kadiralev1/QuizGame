using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace QuizGame
{
    public class GameManager
    {
        public static List<Question> question; // list containing all the questions
        public static List<HighScore> highScores; //list contating top 5 best scores
        private string qFilePath = @"C:\C#\QuizGame 11.05.2020\QuizGame\bin\Debug\netcoreapp3.1\questions.xml";
        private string hsFilePath = @"C:\C#\QuizGame 11.05.2020\QuizGame\bin\Debug\netcoreapp3.1\highScores.xml";

        public GameManager()
        {
            question = new List<Question>();
            highScores = new List<HighScore>();
            loadQuestionsFromFile();
            loadHighScoresFormFile();

        }
        public void saveHighScoresToFile()
        {
            using (Stream fs = new FileStream(hsFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<HighScore>));
                serializer.Serialize(fs, highScores);
            }
        }
        public static void sortHighScores()
        {
            var sort = highScores.OrderBy("Scores");

            foreach (HighScore s in sort)
            {
                Console.WriteLine(s.Scores);
            }
        }
        public void addScore(int score)
        {
            if (highScores.Count >= 0 && highScores.Count < 5)
            {
                if (highScores.Count == 0) highScores.Add(new HighScore("Player", score, "Normal", DateTime.Today));
                else
                {
                    int couter = 0;
                    foreach (HighScore s in highScores)
                    {
                        if (score >= s.Scores)
                        {
                            highScores.Insert(couter, new HighScore("Player", score, "Normal", DateTime.Today));
                            break;
                        }

                        couter++;
                    }
                }
            }

        }

        public void loadHighScoresFormFile()
        {
            if (File.Exists(hsFilePath))
            {

                XmlSerializer serializer = new XmlSerializer(typeof(List<HighScore>));
                using (FileStream fs = File.OpenRead(hsFilePath))
                {
                    highScores = (List<HighScore>)serializer.Deserialize(fs);
                }
            }
            else
            {
                saveHighScoresToFile();
            }

        }

        public void resetQuestionsToDefault()
        {
            //Method that creates the file with questions againmethod that creates the file with questions again
            question.Clear();
            //1
            question.Add(new Question("What is the length of the equator?", "40 123 km", "40 321 km", "40 057 km", "40 075 km", "D", 1, "Geography"));
            //2
            question.Add(new Question("Which planet from the sun is the earth?", "1", "2", "3", "4", "C", 1, "Astronomy"));
            //3
            question.Add(new Question("4 + 4 * 4 = ?", "64", "20", "32", "16", "B", 1, "Maths"));
            //4
            question.Add(new Question("Which of these languages ​​is the programming language?", "HTML", "C++", "XML", "CSS", "B", 1, "Programming"));
            //5
            question.Add(new Question("How many voivodeships (provinces) are there in Poland?", "12", "14", "16", "18", "C", 2, "Geography"));
            //6
            question.Add(new Question("What is the distance from the earth to the moon?", "101 200 km", "203 900 km", "384 400 km", "732 210 km", "C", 2, "Astronomy"));
            //7
            question.Add(new Question("How many states are the US divided into?", "48", "50", "52", "53", "B", 2, "Geography"));
            //8
            question.Add(new Question("WWhat is the area of ​​a cube with a side of 4 cm?", "96 cm2", "64 cm2", "16 cm2", "32 cm2", "A", 2, "Maths"));
            //9
            question.Add(new Question("How many horsepowers does McLaren F1 have?", "627 hp", "532 hp", "619 hp", "701 hp", "A", 3, "Automotive"));
            //10
            question.Add(new Question("1+2*3-4/5 =", "1", "0.6", "6.2", "-0.6", "C", 3, "Maths"));
            //11
            question.Add(new Question("What is the nearest galaxy to ours?", "Milky Way", "Betelgeuse", "Alpha Centauri", "Andromeda", "D", 3, "Astronomy"));
            //12
            question.Add(new Question("How long is one day on Mars?", "24h 15m", "23h 47m", "24h 01m", "24h 37m", "D", 3, "Astronomy"));
            //13
            question.Add(new Question("Who Invented the light bulb?", "Alexander Graham Bell", "Leonardo da Vinci", "Thomas Alva Edison", "Nikola Tesla", "C", 1, "Science"));
            //14
            question.Add(new Question("Which of the following men does not have a chemical element named for him?", "Niels Bohr", "Isaac Newton", "Enrico Fermi", "Albert Einstein", "B", 1, "Science"));
            //15 
            question.Add(new Question("In the context of Apple iPhones, what is Siri?", "The name of the camera", "The name of a game", "A talking personal assistant", "The photo editing app", "C", 1, "Technology"));
            //16
            question.Add(new Question("Roughly how many years ago was fire - making technology devised?", "10,000", "Over 50,000", "100,000", "Over 500,000", "D", 1, "Technology"));
            //17
            question.Add(new Question("What is the fastest animal on earth?", "Peregrine Falcon", "Frigate Bird", "Sail Fish", "Cheetah", "A", 2, "Zoology"));
            //18
            question.Add(new Question("Which Is The Biggest Land Animal?", "Brown Bear", "Affican Elephant", "Giraffe", "Crocodile", "B", 2, "Zoology"));
            //19
            question.Add(new Question("Arctic King, Saladin and Tom Thumb are which types of vegetable?", "Lettuce", "Tomato", "Potato", "Cabbage", "A", 2, "General Knowledge"));
            //20
            question.Add(new Question("Who of these is considered by many to be the greatest science and technology thinker in history?", "Leonardo da Vinci", "Michelangelo", "Raphael", "Donatello", "A", 2, "General Knowledge"));
            //21
            question.Add(new Question("What is a baby oyster called?", "Saccostrea", "Nacre", "Magallana", "Spat", "D", 3, "General Knowledge"));
            //22
            question.Add(new Question("Which English cathedral was destroyed by fire in 1666?", "Birmingham", "Coventry", "St Paul's", "Lichfield", "C", 3, "History"));
            //23
            question.Add(new Question("Who was the first English monarch to abdicate?", "Richard II", "Edward VIII", "George V", "William IV", "B", 3, "History"));
            //24
            question.Add(new Question("Dempo, Churchill Brothers, and Salgaocar are famous successful Indian what?", "Volleyball Clubs", "Handball Clubs", "Football Club", "Cricket Clubs", "C", 3, "Sport"));
            saveQuestionsToFile();
        }
        public void loadQuestionsFromFile()
        {
            //loading questions form file, if file doesn't exist resetQuestionsToDefault is called
            if (File.Exists(qFilePath))
            {

                XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));
                using (FileStream fs = File.OpenRead(qFilePath))
                {
                    question = (List<Question>)serializer.Deserialize(fs);
                }
            }
            else
            {
                resetQuestionsToDefault();
            }


        }
        public void saveQuestionsToFile()
        {
            using (Stream fs = new FileStream(qFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));
                serializer.Serialize(fs, question);
            }
        }

        public void addQuestion(Question newQuestion)
        {
            //adding new question on the end of the list
            question.Add(new Question(newQuestion.Text,newQuestion.A,newQuestion.B,newQuestion.C,newQuestion.D,newQuestion.Answer,newQuestion.DiffLvl,newQuestion.Cat));
            saveQuestionsToFile();


            Console.WriteLine("What you want to do ? ");
            Console.WriteLine("1-) Main Menu");
            Console.WriteLine("2-) Administration Panel");
            int answer = int.Parse(Console.ReadLine());

            switch (answer)
            {
                case 1:
                    mainMenu object1 = new mainMenu();
                    object1.displayMainMenu();
                    break;
                case 2:
                    administrationPanelOptions();
                    break;
                default:
                    break;
            }

        }
        public void removeQuestion(int index)
        {
            //removing question with specific index
            Question questionToRemove = null;
            foreach (Question q in question)
            {
                if (q.ID == index) questionToRemove = q;
            }
            if (questionToRemove == null)
            {
                Console.WriteLine("Wrong ID");
            }
            else
            {
                question.Remove(questionToRemove);
            }


        }

        public void administrationPanel(string userPassword)
        {
            string password = "1234";

            if (password.Equals(userPassword))
            {
                Console.WriteLine("Password is correct. ");
                administrationPanelOptions();
            }
            else
            {
                mainMenu response = new mainMenu();
                response.displayMainMenu();
            }
        }

        public void administrationPanelOptions()
        {
            Console.WriteLine("1-) See all questions...");
            Console.WriteLine("2-) View and Edit question...");
            Console.WriteLine("3-) Add new question");
            int answer = int.Parse(Console.ReadLine());

            switch (answer)
            {
                case 1:
                    getAllQuestions();
                    break;
                case 2:
                    viewAndEditQuestion();
                    break;
                case 3:
                    addNewQuestion();
                    break;
                default:
                    break;
            }
        }

        public void getAllQuestions()
        {
            loadQuestionsFromFile();

            foreach (var questio in question)
            {
                Console.WriteLine("Category: " + questio.Cat +" Difficulty Level: "+questio.DiffLvl+"\n"
                    +" "+questio.Text + "\n"
                    + " " + "A) "+questio.A + " " + "B) " + questio.B + " " + "C) " + questio.C + " " + "D) " + questio.D + "\n"
                    + "  Correct Answer: "+ questio.Answer
                    );;
            }
            Console.WriteLine("What you want to do ? ");
            Console.WriteLine("1-) Main Menu");
            Console.WriteLine("2-) Administration Panel");
            int answer = int.Parse(Console.ReadLine());

            switch (answer)
            {
                case 1:
                    mainMenu object1 = new mainMenu();
                    object1.displayMainMenu();
                    break;
                case 2:
                    administrationPanelOptions();
                    break;
                default:
                    break;
            }
        }

        public void viewAndEditQuestion()
        {
            loadQuestionsFromFile();

            foreach (var questio in question)
            {
                Console.WriteLine("Question ID: "+questio.ID+" Category: " + questio.Cat + " Difficulty Level: " + questio.DiffLvl + "\n"
                    + " " + questio.Text + "\n"
                    + " " + "A) " + questio.A + " " + "B) " + questio.B + " " + "C) " + questio.C + " " + "D) " + questio.D + "\n"
                    + "  Correct Answer: " + questio.Answer
                    ); ;
            }

            Console.WriteLine("Enter the id of question: ");
            int id = int.Parse(Console.ReadLine());

            foreach (var wantedQuestion in question)
            {
                if (wantedQuestion.ID == id)
                {
                    Console.WriteLine("What you want to change ?"+"\n"
                        + "Press 1 for category: " +"\n" +
                        "Press 2 for difficulty level: " + "\n" +
                        "Press 3 for question body: " + "\n" +
                        "Press 4 for A: " + "\n" +
                        "Press 5 for B: " + "\n" +
                        "Press 6 for C: " + "\n" +
                        "Press 7 for D: " + "\n" +
                        "Press 8 for Correct answer: "
                        );
                    int choosen = int.Parse(Console.ReadLine());
                    switch (choosen)
                    {
                        case 1:
                            Console.WriteLine("Enter the new category: ");
                            wantedQuestion.Cat = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter the difficulty level: ");
                            wantedQuestion.DiffLvl = int.Parse(Console.ReadLine());
                            break;
                        case 3:
                            Console.WriteLine("Enter the question body: ");
                            wantedQuestion.Text = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Enter the new A: ");
                            wantedQuestion.A = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Enter the new B: ");
                            wantedQuestion.B = Console.ReadLine();
                            break;
                        case 6:
                            Console.WriteLine("Enter the new C: ");
                            wantedQuestion.C = Console.ReadLine();
                            break;
                        case 7:
                            Console.WriteLine("Enter the new D: ");
                            wantedQuestion.D = Console.ReadLine();
                            break;
                        case 8:
                            Console.WriteLine("Enter the new correct answer: ");
                            wantedQuestion.Answer = Console.ReadLine();
                            break;
                        default:
                            break;
                    }
                }
            }
            saveQuestionsToFile();

            Console.WriteLine("What you want to do ? ");
            Console.WriteLine("1-) Main Menu");
            Console.WriteLine("2-) Administration Panel");
            int answer = int.Parse(Console.ReadLine());

            switch (answer)
            {
                case 1:
                    mainMenu object1 = new mainMenu();
                    object1.displayMainMenu();
                    break;
                case 2:
                    administrationPanelOptions();
                    break;
                default:
                    break;
            }
        }

        public void addNewQuestion()
        {
            Question newQuestion = new Question();
            Console.WriteLine("Enter the category : ");
            newQuestion.Cat = Console.ReadLine();
            Console.WriteLine("Enter the difficulty level of question( 1 to 3 (Easy,Medium,Hard)): ");
            newQuestion.DiffLvl = int.Parse(Console.ReadLine());
            Console.WriteLine("Question body: ");
            newQuestion.Text = Console.ReadLine();
            Console.WriteLine("Correct answer: ");
            newQuestion.Answer = Console.ReadLine();
            Console.WriteLine("A: ");
            newQuestion.A = Console.ReadLine();
            Console.WriteLine("B: ");
            newQuestion.B = Console.ReadLine();
            Console.WriteLine("C: ");
            newQuestion.C = Console.ReadLine();
            Console.WriteLine("D: ");
            newQuestion.D = Console.ReadLine();

            addQuestion(newQuestion);
        }

}
    public static class EnumerablePropertyAccessorExtensions
    {
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> enumerable, string property)
        {
            return enumerable.OrderBy(x => GetProperty(x, property));
        }

        private static object GetProperty(object o, string propertyName)
        {
            return o.GetType().GetProperty(propertyName).GetValue(o, null);
        }
    }
}
