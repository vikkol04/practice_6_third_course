using System;
namespace ConsoleApp1
{
    internal class Kolokolnikov_var_4
    {
        static void Main (string[] args)
        {
            // №1. Create an array of 1000 elements, fill it with random numbers 
            // from 1 to 1000, and then find all primes.
            Console.WriteLine($"\n\n№1. --------------------------------------------------------\n");
            Console.ReadLine();
            int len = 1000;
            Random rand = new Random();
            int[] array = new int[len];
            for (int i = 0; i < len; i++)
            {
                array[i] = rand.Next(1, len+1);
            }
            Console.WriteLine($"Array with {len} numbers:\n{string.Join(", ", array)}.\n\nArray with prime numbers:");
            int count = 0;
            foreach (int i in array)
            {
                for (int ch_num = 2; ch_num <= 9; ch_num = ch_num != 4 ? ch_num + 2 : 3)
                {
                    if (i != ch_num && i % ch_num == 0) break;
                    if (ch_num == 9) 
                    {
                        Console.Write($"{i}, ");
                        count++;
                    }
                }
            }
            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
            Console.WriteLine($".\n\n{count} prime numbers have been discovered.\n");


            // №2. Create a dictionary where the key is the student's name and the value is their grade.
            // Find the student with the highest GPA
            Console.WriteLine($"\n\n№2. --------------------------------------------------------\n");
            Console.ReadLine();
            Dictionary<string, List<int>> students = new Dictionary<string, List<int>>
            {
                { "st1", new List<int> { 2, 3, 1, 2, 3 } },
                { "st2", new List<int> { 5, 2, 3, 4, 5 } },
                { "st3", new List<int> { 1, 3, 4, 2, 3 } },
                { "st4", new List<int> { 5, 5, 4, 3, 2 } },
            };

            // Student grades output by user request
            string input;
            List<string> keys = students.Keys.ToList();
            do
            {    
                Console.Write($"Enter one of the students ({String.Join(", ", keys)}): ");
                input = Console.ReadLine();
                if (students.ContainsKey(input))
                {
                    Console.WriteLine($"{input} grades: {String.Join(", ", students[input])}.");
                    Console.WriteLine($"{input} average grade: {students[input].Average()}.");
                }
                else if (input != "") Console.WriteLine("Student not found.");
            }
            while (input != "");

            //Output of students with their grade point averages
            Console.WriteLine("Students with their grade point averages:");
            foreach (string key in keys)
            {
                Console.WriteLine($"{key} : {students[key].Average()} ({String.Join(", ", students[key])})");
            }

            //finding students with the highest grade average
            HashSet<string> best_students = new HashSet<string>();
            List<double> avg_grades = new List<double>();
            foreach (var grades in students.Values.ToList()) avg_grades.Add(grades.Average());
            double max_avg_grade = avg_grades.Max();
            for (int i = 0; i < students.Count; i++) 
            {
                if (avg_grades[i] == max_avg_grade) best_students.Add(keys[i]);
            }
            Console.WriteLine($"Students with the highest grade average: {String.Join(", ", best_students)}");

            // №3. Create a string of 10 random words 
            // and then print only those that begin and end with the same letter.
            Console.WriteLine($"\n\n№3. --------------------------------------------------------\n");
            Console.ReadLine();
            string str_words = "Ada Aga Aha Aja Aka Ala Ama Ani Ara Ava\n" +
                               "Axa Aza Bib Bob Boo Bub Bye Coco Dado Deed\n" +
                               "Dido Dodo Echo Eke Elle Emme Epee Ese Ewe Eye\n" +
                               "Gaga Gigi Gogo Haha Hehe Hoho Huhu Iwi Jaja Jiji\n" +
                               "Juju Kaka Kiki Koko Lala Lilo Lulu Mama Meme Mimi\n";
            List<string> list_words = str_words.Trim().ToLower().Split(new char[] { ' ', '\n' }).ToList();
            Console.WriteLine($"All words:\n{str_words}\n\nWords with the same letter at the beginning and end:");
            foreach (string word in list_words)
            {
                if (word[0] == word[word.Length-1]) Console.Write($"{word}, ");
            }
            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
            Console.WriteLine(".\n\n");
        }
    }
}
