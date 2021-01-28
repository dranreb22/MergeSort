using System;
using System.Diagnostics;
using System.IO;

namespace Merge_Sort
{
    class Program
    {
        static int[] MergeAndSort(int[] array, left, right)
        {
            
            int[] sortedArray = new int[array.Length];
            return sortedArray;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("How many values shall we sort?(Ensuring dataset matching input value and" +
    " edit code respectively.");
            int n = Convert.ToInt32(Console.ReadLine());
            string fileNum = n + "numbers.txt";
            string filePath = "C:\\Users\\berna\\Documents\\C sharp practice\\NumGenerated\\" + fileNum;
            string[] lines = File.ReadAllLines(filePath);
            int[] array = Array.ConvertAll(lines, int.Parse);

            int size = array.Length;
            int middle = size / 2;
            int left = 0;
            int right = size - 1;

            var timer = Stopwatch.StartNew();

            var sortedArray = MergeAndSort(array);
            //foreach (int value in testArray[])
            //{

            //}

            timer.Stop();
            var timespan = timer.Elapsed;

            //using (StreamWriter sw = new StreamWriter(fileNum + "output.txt"))
            //{
            //    foreach (int value in array)
            //        sw.WriteLine(value);
            //}

            //using (StreamWriter timespent = File.AppendText(fileNum + "output.txt"))
            //{
            //    timespent.WriteLine(String.Format("{0:00}:{1:00}:{2:000000000000000000000000000000000000000}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds));
            //}


            Console.WriteLine(String.Format("{0:00}:{1:00}:{2:000000000000000000000000000000000000000}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds));


            Console.ReadLine();
        }
    }
}
