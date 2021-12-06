using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
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
                //Console.WriteLine(temp);
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
            //part 2
            string oxygen = "";
            string co2 = "";
            int temp1 = 0;
            string bit = "0";
            string test = "";
            string[] temp2 = new string[1000];
            bity.CopyTo(temp2, 0);
            

            for (int i = 0; i < 12; i++)
            {
                foreach (var j in bity)
                {
                    if (j != null)
                    {
                        if (j[i].ToString() == "0") temp1++;
                    }

                }
                if (temp1 > bity.Count(s => s != null) / 2) bit = "0";//jest wiecej 0 mniej 1
                else bit = "1";
                //Console.WriteLine($"temp1: {temp1}\nbity.Count: {bity.Count(s => s != null)}\nbit: {bit}\nstep: {i+1}");
                temp1 = 0;
                if (bity.Count(s => s != null) == 1) break;
                for (int j = 0; j < bity.Length; j++)
                {
                    if (bity[j] != null)
                    {
                        if (bity[j][i].ToString() != bit)
                        {
                            bity[j] = null;
                        }
                    }

                }
                
            }
            for (int i = 0; i < 12; i++)
            {
                foreach (var j in temp2)
                {
                    if (j != null)
                    {
                        if (j[i].ToString() == "0") temp1++;
                    }

                }
                if (temp1 > temp2.Count(s => s != null) / 2) bit = "0";//jest wiecej 1 mniej 0
                else bit = "1";
                //Console.WriteLine($"temp1: {temp1}\nbity.Count: {bity.Count(s => s != null)}\nbit: {bit}");
                temp1 = 0;
                if (temp2.Count(s => s != null) == 1) break;
                for (int j = 0; j < temp2.Length; j++)
                {
                    if (temp2[j] != null)
                    {
                        if (temp2[j][i].ToString() == bit)
                        {
                            temp2[j] = null;
                        }
                    }

                }
                

            }
            foreach (var item in bity)
            {
                if (item != null)
                {
                    Console.WriteLine($"bity: {item}");
                    Console.WriteLine(Convert.ToInt32(item, 2));
                }
            }
            foreach (var item in temp2)
            {
                if (item != null)
                {
                    Console.WriteLine(item);
                    Console.WriteLine(Convert.ToInt32(item, 2));
                }
            }
            /*bity = temp2;
            for (int i = 0; i < 12; i++)
            {
                foreach (var j in bity)
                {
                    if (j != null)
                    {
                        if (j[i].ToString() == "0") temp1++;

                    }

                }
                if (temp1 > bity.Count(s => s != null) / 2) bit = "1";//jest wiecej 1
                else bit = "0";
                Console.WriteLine($"temp1: {temp1}\nbity.Count: {bity.Count(s => s != null)}\nbit: {bit}");
                test += bit.ToString();
                if (bit == "0") //odwrocone bo bit jest o tym co usunac
                {
                    //oxygen += "0";
                    co2 += "0";
                }
                else
                {
                    //oxygen += "1";
                    co2 += "1";
                }
                temp1 = 0;
                for (int j = 0; j < bity.Length; j++)
                {
                    if (bity[j] != null)
                    {
                        if (bity[j][i].ToString() != bit)
                        {
                            bity[j] = null;
                        }

                    }

                }
            }

            Console.WriteLine($"oxygen: {oxygen}  dec:{Convert.ToInt32(oxygen, 2)}\nco2: {co2}  dec:{Convert.ToInt32(co2, 2)}\ntest: {test}\n mnożenie: {(Convert.ToInt32(oxygen, 2))*(Convert.ToInt32(co2, 2))}");
            */

        }
        static void Main(string[] args)
        {
            /*string[] test = {"1","01","10", null };
            //Console.WriteLine(test.Count(s => s != null));
            //foreach (var item in test)
            {
                if (item != null)
                {

                    Console.WriteLine(item);
                }
            }*/
            Day3();
        }
    }
}
