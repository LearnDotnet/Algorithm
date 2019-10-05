using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class MaxHeap
    {
        int size;
        int[] array;
        public MaxHeap(int size, int[] array)
        {
            this.array = array;
            this.size = size-1;

        }
        private void swap(int position1,int position2)
        {
            int temp = array[position1];
            array[position1] = array[position2];
            array[position2] = temp;
        }
        public void Heapify(int i)
        {
            int left = 2 * i;
            int right = 2 * i + 1;
            int largest;

            if (left <= size && array[left] > array[i])
                largest = left;
            else
                largest = i;

            if (right <= size && array[right] > array[i])
                largest = right;
            if(largest!=i)
            {
                swap(i,largest);
                Heapify(largest);
            }

        }
        public void CreateMaxHeap()
        {
            for (int i = size/2; i>=1; i--)
            {
                Heapify(i);
            }
        }

    }

    public class Program
    {
        public static void PrintArray<T>(T[] array)
        {
            foreach (T item in array)
            {
                Console.Write(item + ",");
            }
        }
        public static int[] GetIntegersArray(int size, string[] array)
        {
            int[] numbers = new int[size];
            int i = 0;
            foreach (string number in array)
            {
                numbers[i++] = int.Parse(number);
            }

            return numbers;
        }
        public static void BubbleSort(int size, int[] array)
        {
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }

            }
            //PrintArray<int>(array);

        }
        public static int LinearSearch(int[] array, int element)
        {
            int position = -1;
            int length = array.Length;
            for (int i = 0; i < length; i++)
            {
                if (array[i] == element)
                    position = i;
            }
            return position;
        }
        public static int BinarySearch(int[] array, int element)
        {
            int start = 0;
            int end = array.Length - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (array[mid] == element)
                    return mid;
                if (element > array[mid])
                    start = mid + 1;
                else
                    end = mid - 1;

            }
            return -1;

            //1 2 3 
            //0 1 2 
        }
        public static void SelectionSort(int[] array, int size)
        {
            int minimum_index;
            for (int i = 0; i < size - 1; i++)
            {
                //asuming that element is at postion i is minimum
                minimum_index = i;

                //looping through unsorted list checking for minimum
                for (int j = i + 1; j <= size - 1; j++)
                {

                    //if a minimum found then change the current minimum.
                    if (array[j] < array[minimum_index])
                    {
                        minimum_index = j;
                    }
                }

                //push the minimum to sorted list
                int temp = array[i];
                array[i] = array[minimum_index];
                array[minimum_index] = temp;

            }
        }
        public static void InsertionSort(int[] array, int size)
        {
            int hole, value;
            for (int i = 1; i < size; i++)
            {
                hole = i;
                value = array[hole];

                while (hole > 0 && array[hole - 1] > value)
                {
                    array[hole] = array[hole - 1];
                    hole = hole - 1;
                }
                array[hole] = value;


            }
        }

        #region Merge Sort
        public static void Merge(int[] array, int start, int mid, int end)
        {
            int tempSize = end - start + 1;
            int[] temp = new int[tempSize];
            int i = start;
            int j = mid + 1;
            int k = 0;

            while (i <= mid && j <= end)
            {
                if (array[i] < array[j])
                {
                    temp[k++] = array[i++];
                }
                else
                {
                    temp[k++] = array[j++];
                }
            }

            while (i <= mid)
            {
                temp[k++] = array[i++];
            }

            while (j <= end)
            {
                temp[k++] = array[j++];
            }

            k = 0;
            for (i = start; i <= end; i++)
            {
                array[i] = temp[k++];
            }

            return;
        }
        public static void MergeSort(int[] array, int start, int end)
        {
            if (start >= end)
                return;

            int mid = (start + end) / 2;

            MergeSort(array, start, mid);
            MergeSort(array, mid + 1, end);
            Merge(array, start, mid, end);



        }
        #endregion

        #region  Quick Sort
        public static void Swap(int[] array, int index1, int index2)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;

        }
        public static int Partiton(int[] array, int start, int end)
        {
            int Pivot = array[start];
            int PivotIndex = -1;
            int countLessthanPivot = 0;
            int i = 0;
            int j = 0;
            for (i = start + 1; i <= end; i++)
            {
                if (array[i] <= Pivot)
                {
                    countLessthanPivot++;
                }

            }
            PivotIndex = countLessthanPivot + start;
            Swap(array, start, PivotIndex);

            i = start;
            j = end;
            while (i < PivotIndex && j > PivotIndex)
            {
                if (array[i] <= Pivot)
                {
                    i++;
                }
                else if (array[j] > Pivot)
                {
                    j--;
                }
                else
                {
                    Swap(array, i, j);
                    i++; j--;
                }
            }

            return PivotIndex;

        }

        public static void QuickSort(int[] array, int start, int end)
        {
            if (start >= end)
                return;

            int pivotIndex = Partiton(array, start, end);
            QuickSort(array, start, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, end);


        }

        #endregion

        static void Main(string[] args)
        {


            //string[] input = Console.ReadLine().Split(' ');
            ////int[] numbers = GetIntegersArray(input.Length+1, input);
            //int size = input.Length+1;
            //int[] numbers=new int[size];

            //for (int i = 1; i <size; i++)
            //{
            //    numbers[i] = Convert.ToInt32(input[i - 1]);
            //}
            //MaxHeap maxheap = new MaxHeap(size, numbers);
            //maxheap.CreateMaxHeap();
            //PrintArray<int>(numbers);

            int [,] matrix=new int[10,10];
            for (int i = 0; i < 4; i++)
            {
                string []str = Console.ReadLine().Split(' ');
                for(int j = 0; j < 4; j++)
                {

                    matrix[i,j] = Int32.Parse(str[j]);
                }
            }

            Console.WriteLine("The matric is");
            for (int k = 0; k < 4; k++)
            {
                for (int x = 0; x < 4; x++)
                {
                    Console.Write(matrix[k,x] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
