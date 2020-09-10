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
            Questioner();
            
            void Intro(){
                System.Console.WriteLine("This is Quiz Program");
                System.Console.WriteLine("Press 1 to start the latest Quiz");
                System.Console.WriteLine("Press 2 to make your own Quiz");
                System.Console.WriteLine("Press 3 to load a Quiz [COMING SOON]");
            }

            void Questioner(){
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
                                currentQ++;
                            }
                        }
                    
                }
                System.Console.WriteLine("Congratulations you got " + points + " points");
                Console.ReadLine();
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