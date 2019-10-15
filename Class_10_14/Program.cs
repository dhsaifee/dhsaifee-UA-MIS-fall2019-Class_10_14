using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_10_14
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[50];
            int[] grades = new int[50];
            int count = GetData(names, grades);

            PrintData(names, grades, count);
            SortArrays(names, grades, count);

            Console.WriteLine("\nAfter sorting by names: ");
            PrintData(names, grades, count);

            int foundIndex;

            Console.Write("\nPlease enter a name to search (STOP to exit): ");
            string nameSearch = Console.ReadLine();

            while (nameSearch.ToUpper() != "STOP")
            {
                foundIndex = BinarySearch(names, nameSearch, count);

                if (foundIndex == -1)
                {
                    Console.WriteLine(nameSearch + " could not be found");
                }
                else
                {
                    Console.WriteLine(nameSearch + " is at index " + foundIndex);
                    Console.WriteLine(nameSearch + "'s grade is " + grades[foundIndex]);
                }

                Console.Write("\nPlease enter a name to search (STOP to exit): ");
                nameSearch = Console.ReadLine();
            }

            Console.ReadKey();
        }


        static int GetData(string[] names, int[] grades)
        {
            names[0] = "Jeff";
            names[1] = "Rachel";
            names[2] = "Sarah";
            names[3] = "Danish";
            names[4] = "Jackson";

            grades[0] = 95;
            grades[1] = 100;
            grades[2] = 97;
            grades[3] = 81;
            grades[4] = 90;

            return 5;
        }


        static void PrintData(string[] myStringArray, int[] myIntArray, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(myStringArray[i] + "\t\t" + myIntArray[i]);
            }
        }


        static void SortArrays(string[] names, int[] grades, int count)
        {
            int minIndex;

            for (int i = 0; i < count - 1; i++)
            {
                minIndex = i;

                for(int j = i + 1; j < count; j++)
                {
                    if(names[j].CompareTo(names[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    Swap(names, minIndex, i);
                    Swap(grades, minIndex, i);
                }
            }
        }


        static void Swap(string[] myArray, int x, int y)
        {
            string temp = myArray[x];
            myArray[x] = myArray[y];
            myArray[y] = temp;
        }


        static void Swap(int[] myArray, int x, int y)
        {
            int temp = myArray[x];
            myArray[x] = myArray[y];
            myArray[y] = temp;
        }


        static int BinarySearch(string[] myArray, string searchVal, int count)
        {
            int first = 0;
            int last = count - 1;
            int foundIndex = -1;
            bool notFound = true;
            int middle;
            searchVal = searchVal.ToUpper();

            while(notFound && (first <= last))
            {
                middle = (first + last) / 2;
                if(searchVal == myArray[middle].ToUpper())
                {
                    notFound = false;
                    foundIndex = middle;
                }
                else if(searchVal.CompareTo(myArray[middle].ToUpper()) < 0)
                {
                    last = middle - 1;
                }
                else
                {
                    first = middle + 1;
                }

            }

            return foundIndex;
        }

    }
}
