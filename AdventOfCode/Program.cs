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
                if (item != null) oxygen = item;
            }
            foreach (var item in temp2)
            {
                if (item != null) co2 = item;
            }
            System.Console.WriteLine($"oxygen: {oxygen},\nco2: {co2},\nwynik: {Convert.ToInt32(oxygen,2)*Convert.ToInt32(co2,2)}");
        }
        class Bingo{
            public Value[,] values = new Value[5,5];
        }
        class Value{
            public int number;
            public bool isChecked = false;
            public Value(int n){
                number = n;
            }
        }
        class Pozycja{
            public int rzad;
            public int kolumna;
            public Pozycja(int row, int col){
                rzad = row;
                kolumna = col;
            }
        }
        static Pozycja inBingo(Bingo bingo, int wynik){
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if(bingo.values[i, j].number == wynik){
                        bingo.values[i, j].isChecked = true;
                        return new Pozycja(i,j);
                    }
                }
            }
            return null;
        }
        
        static int finalScore(Bingo bingo, int wynik){
            int outt = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if(!bingo.values[i,j].isChecked){
                        outt += bingo.values[i,j].number;
                    }
                }
            }
            return outt*wynik;
        }
        static void Day4()
        {
            string path = @"/Users/kytoon/Projects/AdventOfCode/AdventOfCode/input4.txt";
            string[] bingo = File.ReadAllLines(path);
            string[] wyniki = bingo[0].Split(',');
            Bingo[] tablice = new Bingo[100];
            List<Dictionary<int,int>> matchesCol = new List<Dictionary<int, int>>();
            List<Dictionary<int,int>> matchesRow = new List<Dictionary<int, int>>();
            string[] temp;
            string linia;
            int licznik = 0;
            for (int i = 2; i < 602; i=i+6) //ilosc macierzy
            {
                
                tablice[licznik] = new Bingo();
                matchesCol.Add(new Dictionary<int,int>());
                matchesRow.Add(new Dictionary<int,int>());
                for (int n = 0; n < 5; n++) //rzedy macierzy
                {
                    linia = bingo[i+n];
                    if(linia[0]==' '){
                        linia = '0' + linia.Substring(1);
                    }
                    temp = System.Text.RegularExpressions.Regex.Split( linia, @"\s+");
                    for (int m = 0; m < 5; m++) //kolumny macierzy
                    {
                        tablice[licznik].values[n,m] = new Value(int.Parse(temp[m]));
                    }
                
                }
                licznik++;
            }
            foreach(var wynik in wyniki){
                for(int i=0; i<100;i++){
                    Pozycja kordy = inBingo(tablice[i], int.Parse(wynik));
                    if(kordy != null){
                        bool isWin = false;

                        if(matchesRow[i].ContainsKey(kordy.rzad)){
                            if(++matchesRow[i][kordy.rzad] == 5) {isWin = true;}
                        }
                        else{
                            matchesRow[i].Add(kordy.rzad, 1);
                        }
                        
                        if(matchesCol[i].ContainsKey(kordy.kolumna)){
                            if(++matchesCol[i][kordy.kolumna] == 5) {isWin = true;}  
                        }
                        else{
                            matchesCol[i].Add(kordy.kolumna, 1);
                        }
                        if (isWin){
                            System.Console.WriteLine(finalScore(tablice[i], int.Parse(wynik)));
                            return;
                        }
                    }
                }
            }
        
            
        }
        static void Main(string[] args)
        {  
            Day4();
        }
    }
}
