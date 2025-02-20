using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("==========================================Data Set==================================");
        string filePath = "--File Path--";

        var (leftList, rightList) = ReadNumbersFromFile(filePath);

        for (int i = 0; i < leftList.Count; i++)
        {
            Console.WriteLine(leftList[i] + " " + rightList[i]);
        }

        Console.WriteLine("===================================================================================");
        Console.ReadLine();   

        var result = CalcListDiffrence(leftList, rightList);

        Console.WriteLine("Total amount of diffrences: " + result);
    }

    public static (List<int> LeftList, List<int> RightList) ReadNumbersFromFile(string filePath)
    {
        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();

        try
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                string[] numberStrings = System.Text.RegularExpressions.Regex.Split(line, @"\s{3}");

                int leftNumber = Convert.ToInt32(numberStrings[0]);
                leftList.Add(leftNumber);


                int rightNumber = Convert.ToInt32(numberStrings[1]);
                rightList.Add(rightNumber);

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }

        leftList.Sort();
        rightList.Sort();

        return (leftList, rightList);
    }

    public static int CalcListDiffrence(List<int> leftNumbers, List<int> rightNumbers)
    {
        var result = 0;

        for (int i = 0; i < leftNumbers.Count; i++)
        {
            var leftNumber = leftNumbers[i];
            var rightNumber = rightNumbers[i];

            var diff = Math.Abs(rightNumber - leftNumber);
            result += diff;
        }
        return result;
    }

}