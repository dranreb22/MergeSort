using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Merge_Sort
{
    class Program
    {
        static int[] Merge(int[] array, int middle, int left, int right)
        {
            //setting up the sizes of the arrays to be merged
            int sizeLeftArr = middle - left+1;
            int sizeRightArr = right - middle;

            
            //storage arrays based on number of sizes set up
            int[] leftArr = new int[sizeLeftArr];
            int[] rightArr = new int[sizeRightArr];

            //filling in values of the two separate arrays
            for (int i = 0; i < sizeLeftArr; ++i)
            {
                leftArr[i] = array[left + i];
            }
            for (int i = 0; i < sizeRightArr; ++i)
            {
                rightArr[i] = array[middle + 1 + i];
            }

            //pos1 = position of left array
            //pos2 = position of right array
            //index = position of array to be filled in (result array)
            int pos1 = 0, pos2 = 0, index = left;

            //while the left position is smaller than the left size
            //and right position is smaller than the right size
            while (pos1 < sizeLeftArr && pos2 < sizeRightArr)
            {
                //if the left value is smaller than the right value
                //put smaller value in the resulting array and increment that position
                if (leftArr[pos1] <= rightArr[pos2])
                {
                    array[index] = leftArr[pos1];
                    pos1++;
                }
                else
                {
                    array[index] = rightArr[pos2];
                    pos2++;
                }
                index++;
            }

            //fill in remaining values (when the recursion reaches the bottom, 
            //a lot of left over values would be lost
            //skipped over as the arrays fill in with proper sorting
            while (pos1 < sizeLeftArr)
            {
                array[index] = leftArr[pos1];
                index++;
                pos1++;
            }
            while (pos2 < sizeRightArr)
            {
                array[index] = rightArr[pos2];
                index++;
                pos2++;
            }

            return array;
        }

        static int[] MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);

                Merge(array, middle, left, right);
            }
            return array;
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

            MergeSort(array, left, right);

            var timer = Stopwatch.StartNew();


            timer.Stop();
            var timespan = timer.Elapsed;

            using (StreamWriter sw = new StreamWriter(n + "NumbersOut.txt"))
            {
                foreach (int value in array)
                    sw.WriteLine(value);
            }

            using (StreamWriter timespent = File.AppendText(n + "NumbersOut.txt"))
            {
                timespent.WriteLine(String.Format("{0:00}:{1:00}:{2:000000000000000000000000000000000000000}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds));
            }


            Console.WriteLine(String.Format("Time taken to run: {0:00}:{1:00}:{2:000000000000000000000000000000000000000}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds));


            Console.ReadLine();
        }
    }
}
