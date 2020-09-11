using System;
using System.Collections.Generic;
using System.IO;

namespace Queststions
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean random = false;


                string[] questions = File.ReadAllLines(@"Questions.txt"); //add Questions

                string[] answer1 = File.ReadAllLines(@"answer1.txt"); //add answer 1

                string[] answer2 = File.ReadAllLines(@"answer2.txt");  //add answer 2

                string[] answer3 = File.ReadAllLines(@"answer3.txt");  //add answer 3

                string[] answerc = File.ReadAllLines(@"answerc.txt"); //add correct answers

                int qMax = questions.Length;
                int points = 0;
                string intronum = "";
                string quizName = "";
                Boolean quizExists = true;
                string overWrite = "";
                Boolean newQ = true;
                string[] currentTq = new string[100];
                string[] currentTa1 = new string[100];
                string[] currentTa2 = new string[100];
                string[] currentTa3 = new string[100];
                string[] currentTac = new string[100];
                int currentG = 0;
            Intro();
            
            void Intro(){
                intronum = ""; 
                while(intronum != "1" && intronum != "2" && intronum != "3"){
                    Console.Clear();
                    Console.WriteLine("This is Quiz Program");
                    Console.WriteLine("Press 1 to start the latest Quiz");
                    Console.WriteLine("Press 2 to make your own Quiz [COMING SOON]");
                    Console.WriteLine("Press 3 to load a Quiz [COMING SOON]");
                    intronum = Console.ReadLine();
                    }
                if(intronum == "1"){Questioner();}
                if(intronum == "2"){MakeQuiz();}
                if(intronum == "3"){LoadQuiz();}
            }

            void Questioner(){
                Console.Clear();
                if(random==true)
                {

                }
                else
                {
                    int currentQ = 0;
                    string currentA = "";
                    while(currentQ < qMax){
                        currentA = "";
                            while(currentA != "1" && currentA != "2" && currentA != "3")
                            {
                                Console.WriteLine("Current Question is #" + currentQ);
                                Console.WriteLine("The Question is " + questions[currentQ]);
                                Console.WriteLine("Answer 1: " + answer1[currentQ]);
                                Console.WriteLine("Answer 2: " + answer2[currentQ]);
                                Console.WriteLine("Answer 3: " + answer3[currentQ]);
                                currentA = Console.ReadLine();
                                Console.Clear();
                                if(currentA == answerc[currentQ])
                                    {
                                        points+=1;
                                    }
                                
                            }
                            currentQ++;
                        }
                    
                }
                if(points<=qMax/4){
                    System.Console.WriteLine("You got " + points + " points, thats awful");
                    Console.ReadLine();
                }
                else if(points>qMax/4 && points<=qMax/2){
                    System.Console.WriteLine("You got " + points + " points, thats not good");
                    Console.ReadLine();
                }
                else if(points>qMax/2 && points<qMax){
                    System.Console.WriteLine("You got " + points + " points, thats good");
                    Console.ReadLine();
                }
                else if(points == qMax){
                    System.Console.WriteLine("You got " + points + " points, thats a perfect score");
                    Console.ReadLine();
                }
                    else{
                    System.Console.WriteLine("You got " + points + " points");
                    Console.ReadLine();
                }
                
            }
        
            void LoadQuiz()
            {
                intronum = "";
                while(intronum != "1" && intronum != "2"){
                    Console.Clear();
                    Console.WriteLine("This is the site to load a Quiz");
                    Console.WriteLine("To load you own quiz press 1");
                    Console.WriteLine("To load the premade Quiz press 2");
                    intronum = Console.ReadLine();
                    
                    
                }
                if(intronum == "1"){Console.Clear();}
                if(intronum == "2")
                    {
                    Console.Clear();
                    //Take Backups and overwrite Main .txts
                    }
            }

            void MakeQuiz()
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
                            }
                            if(overWrite == "2")
                            {
                                quizExists = true;
                                quizName = "";
                            }
                        }
                    }                
                    
                }
                /*
                File.Create(@quizName + "q.txt");
                File.Create(@quizName + "a1.txt");
                File.Create(@quizName + "a2.txt");
                File.Create(@quizName + "a3.txt");
                File.Create(@quizName + "ac.txt");
                */
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
                        if(overWrite == "1")
                        {
                            currentG++;
                        }
                        if(overWrite == "2")
                        {
                            newQ = false;
                            File.WriteAllLines(@"text.txt", currentTq);
                            File.WriteAllLines(@quizName + "q.txt", currentTq);
                            File.WriteAllLines(@quizName + "a1.txt", currentTa1);
                            File.WriteAllLines(@quizName + "a2.txt", currentTa2);
                            File.WriteAllLines(@quizName + "a3.txt", currentTa3);
                            File.WriteAllLines(@quizName + "ac.txt", currentTac);
                        }
                    }
                }
            }
        }
    }
}


/*Plan
program 1 läser en fil hur många frågor (x)
program 2 tar hur många x det är och skappar 5 array med den längden
Array String Fråga, Array String Svar 1, Array String Svar 2, Array String Svar 3, Array int rättsvar
program 3 tar en fråga itaget läser Varje array i en tillfälig "Svar", 3 Frågor och hemligt svar som byts till nästa fråga


*/