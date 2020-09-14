using System;
using System.Collections.Generic;
using System.IO;

namespace Queststions
{
    class Program
    {
        static void Main(string[] args)
        {
                int points = 0;
                string intronum = "";
                string quizName = "";
                Boolean quizExists = true;
                string overWrite = "";
                Boolean newQ = true;
                string[] currentTq = new string[1000];
                string[] currentTa1 = new string[1000];
                string[] currentTa2 = new string[1000];
                string[] currentTa3 = new string[1000];
                string[] currentTac = new string[1000];
                string currentTart = "";
                int currentG = 0;
                int totalQ = 0;
                string keyword = "";
            Intro();
            
            void Intro(){
                intronum = ""; 
                while(intronum != "1" && intronum != "2" && intronum != "3"){
                    Console.Clear();
                    Console.WriteLine("This is Quiz Program");
                    Console.WriteLine("Press 1 to start the latest Quiz");
                    Console.WriteLine("Press 2 to make your own Quiz");
                    Console.WriteLine("Press 3 to load a Quiz");
                    intronum = Console.ReadLine();
                    }
                if(intronum == "1"){Questioner();}
                if(intronum == "2"){MakeQuiz();}
                if(intronum == "3"){LoadQuiz();}
            }

            void Questioner(){
                Console.Clear();
                string[] questions = File.ReadAllLines(@"Questions.txt"); //add Questions

                string[] answer1 = File.ReadAllLines(@"answer1.txt"); //add answer 1

                string[] answer2 = File.ReadAllLines(@"answer2.txt");  //add answer 2

                string[] answer3 = File.ReadAllLines(@"answer3.txt");  //add answer 3

                string[] answerc = File.ReadAllLines(@"answerc.txt"); //add correct answers

                string art = File.ReadAllText(@"ACII-ar.txt"); //add ACII-art

                int qMax = questions.Length;

                int currentQ = 0;
                string currentA = "";
                while(currentQ < qMax)
                {
                    currentA = "";
                    while(currentA != "1" && currentA != "2" && currentA != "3")
                    {
                        Console.WriteLine("Current Question is #" + currentQ);
                        Console.WriteLine("The Question is " + questions[currentQ]);
                        Console.WriteLine("Answer 1: " + answer1[currentQ]);
                        Console.WriteLine("Answer 2: " + answer2[currentQ]);
                        Console.WriteLine("Answer 3: " + answer3[currentQ]);
                        System.Console.WriteLine(art);
                        currentA = Console.ReadLine();
                        Console.Clear();
                        if(currentA == answerc[currentQ])
                            {
                                points+=1;
                            }                            
                    }
                    currentQ++;
                    if(questions[currentQ] == ""){
                        totalQ = currentQ;
                        currentQ = 10000000;
                    }
                }
                End();
            }

            void End()
                {
                    if(points == totalQ)
                    {
                        System.Console.WriteLine("Congratulations you got " + points + " points. Thats a perfect score");
                    }
                    else if(points >= totalQ/2 + totalQ/4)
                    {
                        System.Console.WriteLine("Congratulations you got " + points + " points. Thats almost perfect");
                    }
                    else if(points < totalQ/2+totalQ/4 && points >= totalQ/2)
                    {
                        System.Console.WriteLine("You got " + points + " points. Thats quite good");
                    }
                    else if(points < totalQ/2 && points >= totalQ/4)
                    {
                        System.Console.WriteLine("You got " + points + " points. Thats not good");
                    }
                    else if(points < totalQ/4 && points > 0)
                    {
                        System.Console.WriteLine("You got " + points + " points. Thats awful");
                    }
                    else if(points == 0)
                    {
                        System.Console.WriteLine("You got " + points + " points. Thats 0 out of " + totalQ + ". Not Good");
                    }

                    Console.ReadLine();                     
            }
    
            void LoadQuiz()
            {
                intronum = "";
                while(intronum != "1" && intronum != "2"){
                    Console.Clear();
                    Console.WriteLine("This is the site to load a Quiz");
                    Console.WriteLine("To load the premade Quiz press 1");
                    Console.WriteLine("To load you own quiz press 2");
                    intronum = Console.ReadLine();
                    
                    
                }
                if(intronum == "1")
                {
                        string[] questions = File.ReadAllLines(@"Questionsreset.txt"); //add Questions
                        string[] answer1 = File.ReadAllLines(@"answer1reset.txt"); //add answer 1
                        string[] answer2 = File.ReadAllLines(@"answer2reset.txt");  //add answer 2
                        string[] answer3 = File.ReadAllLines(@"answer3reset.txt");  //add answer 3
                        string[] answerc = File.ReadAllLines(@"answercreset.txt"); //add correct answers
                        string art = File.ReadAllText(@"ACII-artreset.txt"); //add art

                        File.WriteAllLines(@"Questions.txt", questions);
                        File.WriteAllLines(@"answer1.txt", answer1);
                        File.WriteAllLines(@"answer2.txt", answer2);
                        File.WriteAllLines(@"answer3.txt", answer3);
                        File.WriteAllLines(@"answerc.txt", answerc);
                        File.WriteAllText(@"ACII-ar.txt", art);
                        System.Console.WriteLine("Files overwriten, ruturn to main menu");
                        Console.Read();
                        Intro();
                }
                if(intronum == "2")
                    {
                    Console.Clear();
                    System.Console.WriteLine("What is you keyword?");
                    keyword = Console.ReadLine();

                     if (File.Exists(@keyword + "q.txt"))
                    {
                        string[] questions = File.ReadAllLines(@keyword + "q.txt"); //add Questions
                        string[] answer1 = File.ReadAllLines(@keyword + "a1.txt"); //add answer 1
                        string[] answer2 = File.ReadAllLines(@keyword + "a2.txt");  //add answer 2
                        string[] answer3 = File.ReadAllLines(@keyword + "a3.txt");  //add answer 3
                        string[] answerc = File.ReadAllLines(@keyword + "ac.txt"); //add correct answers
                        string art = File.ReadAllText(@keyword + "art.txt"); //add art

                        File.WriteAllLines(@"Questions.txt", questions);
                        File.WriteAllLines(@"answer1.txt", answer1);
                        File.WriteAllLines(@"answer2.txt", answer2);
                        File.WriteAllLines(@"answer3.txt", answer3);
                        File.WriteAllLines(@"answerc.txt", answerc);
                        File.WriteAllText(@"ACII-ar.txt", art);
                        System.Console.WriteLine("Files overwriten, ruturn to main menu");
                        Console.Read();
                        Intro();
                    }
                    else{
                        System.Console.WriteLine("Sorry I cant find that file");
                        System.Console.WriteLine("Try again");
                        Console.ReadLine();
                        LoadQuiz();
                    }
                }
            }

            void MakeQuiz() //Make Private Quiz that are ignored by .gitignore
            {
                while(quizName == "" && quizExists == true)
                {
                    Console.Clear();
                    Console.WriteLine("So you want to make your own Quiz");
                    System.Console.WriteLine("First you need to give it a name");
                    quizName = Console.ReadLine();
                    if (File.Exists(@quizName + "q.txt"))
                    {
                        overWrite = "";
                        while(overWrite != "1" && overWrite != "2"){
                            Console.Clear();
                            Console.WriteLine("Sorry the file exists already");
                            Console.WriteLine("Do you want to overwrite it?");
                            Console.WriteLine("1 for yes, 2 for no");
                            overWrite = Console.ReadLine();
                            if(overWrite == "1")
                            {
                                File.Delete(@quizName + "q.txt");
                                File.Delete(@quizName + "a1.txt");
                                File.Delete(@quizName + "a2.txt");
                                File.Delete(@quizName + "a3.txt");
                                File.Delete(@quizName + "a4.txt");
                                File.Delete(@quizName + "art.txt");
                            }
                            if(overWrite == "2")
                            {
                                quizExists = true;
                                quizName = "";
                            }
                        }
                    }                
                    
                }
                while(newQ == true)
                {
                    overWrite = "";
                    System.Console.WriteLine("Write a Question");
                    currentTq[currentG] = Console.ReadLine();
                    System.Console.WriteLine("Write the first answer");
                    currentTa1[currentG] = Console.ReadLine();
                    System.Console.WriteLine("Write the second answer");
                    currentTa2[currentG] = Console.ReadLine();
                    System.Console.WriteLine("Write the third answer");
                    currentTa3[currentG] = Console.ReadLine();
                    System.Console.WriteLine("Write what is the correct answer [1, 2, 3]");
                    currentTac[currentG] = Console.ReadLine();
                    while(overWrite != "1" && overWrite != "2")
                    {
                        Console.Clear();
                        Console.WriteLine("Do you want another question?");
                        Console.WriteLine("1 for yes, 2 for no");
                        overWrite = Console.ReadLine();
                        Console.Clear();
                        if(overWrite == "1")
                        {
                            currentG++;
                        }
                        if(overWrite == "2")
                        {        
                            Console.Clear();
                            newQ = false;
                            File.WriteAllLines(@quizName + "q.txt", currentTq);
                            File.WriteAllLines(@quizName + "a1.txt", currentTa1);
                            File.WriteAllLines(@quizName + "a2.txt", currentTa2);
                            File.WriteAllLines(@quizName + "a3.txt", currentTa3);
                            File.WriteAllLines(@quizName + "ac.txt", currentTac);
                            File.Create(@quizName + "art.txt");
                            System.Console.WriteLine("Files Created..");
                            System.Console.WriteLine("If you want-ACII art find the file " + quizName + "art.txt and paste in art.");
                            System.Console.WriteLine("Make sure not to have empty lines before or after art");
                            Console.ReadLine();
                            string quizAct = "";
                            while(quizAct != "1" && quizAct != "2"){
                                System.Console.WriteLine("Do you want to load the Quiz?");
                                Console.WriteLine("1 for yes, 2 for no");
                                quizAct = Console.ReadLine();
                                if(quizAct == "1")
                                {
                                    string[] questions = File.ReadAllLines(@quizName + "q.txt"); //add Questions
                                    string[] answer1 = File.ReadAllLines(@quizName + "a1.txt"); //add answer 1
                                    string[] answer2 = File.ReadAllLines(@quizName + "a2.txt");  //add answer 2
                                    string[] answer3 = File.ReadAllLines(@quizName + "a3.txt");  //add answer 3
                                    string[] answerc = File.ReadAllLines(@quizName + "ac.txt"); //add correct answers

                                    File.WriteAllLines(@"Questions.txt", questions);
                                    File.WriteAllLines(@"answer1.txt", answer1);
                                    File.WriteAllLines(@"answer2.txt", answer2);
                                    File.WriteAllLines(@"answer3.txt", answer3);
                                    File.WriteAllLines(@"answerc.txt", answerc);
                                    System.Console.WriteLine("Files overwriten, ruturn to main menu");
                                    Console.Read();
                                    Intro();
                                }
                                if(quizAct == "2"){Intro();}
                                
                            }
                        
                        }
                    }
                }
            }
        }
    }
}