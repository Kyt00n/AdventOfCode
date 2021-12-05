using System;
using System.IO;
using System.Text;
namespace AdventOfCode
{
    class Program
    {
        static void Day1()
        {
            string path = @"/Users/kytoon/Projects/AdventOfCode/AdventOfCode/input.txt";
            string[] input = File.ReadAllLines(path);
            int increments = 0;

            for (int i = 0; i < input.Length - 3; i++)
            {

                if (int.Parse(input[i + 3]) > int.Parse(input[i]))
                {
                    increments++;
                    Console.WriteLine(input[i]);
                }
            }
            Console.WriteLine($"increments {increments}");
        }

        static void Day2()
        {
            string path = @"/Users/kytoon/Projects/AdventOfCode/AdventOfCode/input2.txt";
            string[] input = File.ReadAllLines(path);
            int pozycja = 0;
            int glebokosc = 0;
            int aim = 0;
            foreach (var line in input)
            {
                string[] result = line.Split(' ');
                if (result[0]=="forward")
                {
                    pozycja += int.Parse(result[1]);
                    glebokosc += int.Parse(result[1]) * aim;
                }
                else if (result[0]=="down")
                {
                    aim += int.Parse(result[1]);
                }
                else
                {
                    aim -= int.Parse(result[1]);
                }
            }
            Console.WriteLine($"Pozycja: {pozycja} \nGlebokosc: {glebokosc}\nMnoznik: {pozycja*glebokosc}");
        }

        static void Day3()
        {
            string path = @"/Users/kytoon/Projects/AdventOfCode/AdventOfCode/input3.txt";
            string[] bity = File.ReadAllLines(path);
            int temp = 0;
            string gamma = "";
            string epsilon = "";
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < bity.Length; j++)
                {
                    temp += int.Parse(bity[j][i].ToString());
                    
                }
                Console.WriteLine(temp);
                if (temp>500)
                {
                    gamma += "1";
                    epsilon += "0";
                }
                else
                {
                    gamma += "0";
                    epsilon += "1";
                }
                temp = 0;
            }
            Console.WriteLine($"gamma: {gamma}\nepsilon: {epsilon}");
            Console.WriteLine(Convert.ToInt32(gamma, 2).ToString());
            Console.WriteLine(Convert.ToInt32(epsilon, 2).ToString());
        }
        static void Main(string[] args)
        {
            Day3();

        }
    }
}
