using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace MedianProblem
{
    class Program
    {



        public static void Main()
        {
            List<string> inputList = new List<string>();
          
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
                while (!reader.EndOfStream)
                {
                    inputList.Add(reader.ReadLine());
                    if (inputList.Count == 2)
                    {
                        NewMethod(inputList);
                        break;
                    }
                }
        }

        private static void NewMethod(List<string> inputList)
        {
            int allowedListSize = Convert.ToInt32(inputList[0]);

            List<int> givenList = ReadLineConvertInList(inputList[1]);

            //int allowedListSize = Convert.ToInt32(Console.ReadLine());

            //List<int> givenList = ReadLinePlaceinArray();

            List<int> finalList = new List<int>();
            finalList = findMedianOFGivenArray(givenList, allowedListSize);


            findMedianOfFinalList(finalList);
        }

        private static List<int> ReadLineConvertInList(string secondinput)
        {
            List<int> secondListinput = new List<int>(Array.ConvertAll(secondinput.Split(' '), int.Parse));

            return secondListinput;
        }

        private static List<int> findMedianOFGivenArray(List<int> givenList, int allowedListSize)
        {
             List<List<int>> listOfSubList = new List<List<int>>();
             List<int> tempLists = new List<int>();
            List<int> finalSorted = new List<int>();
            List<List<int>> resultSubLists = listCreator(givenList, allowedListSize, listOfSubList, tempLists);

            resultSubLists.ForEach(arr => {
                int size = arr.Count;
                finalSortedListIndexCalculator(finalSorted, arr, size);
            });

           if(finalSorted.Count > allowedListSize)
            {
                return findMedianOFGivenArray(new List<int>(finalSorted), allowedListSize);
            }

            finalSorted.Sort();
            return finalSorted;

        }

        private static void finalSortedListIndexCalculator(List<int> finalSorted, List<int> array, int size)
        {
            if (size % 2 == 0)
            {
                int index = size / 2;
                if (index == 0)
                {
                    finalSorted.Add(array[index]);
                }
                else
                {
                    finalSorted.Add(array[index - 1]);
                }
            }
            else
            {
                int index = size / 2;
                finalSorted.Add(array[index]);
            }
        }

        private static void findMedianOfFinalList(List<int> finalList)
        {
            string printResult;
            int index = finalList.Count / 2;
            if (finalList.Count % 2 == 0)
            {
              printResult = (finalList[index - 1].ToString());
            }
            else
            {
                printResult = (finalList[index].ToString());
            }
            Console.WriteLine(printResult);
        }

        static List<List<int>> listCreator( List<int> givenList, int listSize, List<List<int>> resultSubLists, List<int> tempLists)
        {

            if (givenList.Count == 0)
            {
                tempLists.Sort();

                resultSubLists.Add(tempLists);

                return resultSubLists;
            }
            else
            {
                if (tempLists.Count == listSize)
                {
                    tempLists.Sort();
                    resultSubLists.Add(tempLists);
                    tempLists = new List<int>();
                }
                else
                {
                    tempLists.Add(givenList[0]);
                    givenList.RemoveAt(0);

                }
            }

            return listCreator( givenList, listSize, resultSubLists, tempLists);
        }

       

        static List<int> ReadLinePlaceinArray()
        {
            //int[] arr = new int[] { 1 ,2 ,5, 4, 6, 3, 7, 8 };

            int[] arr = new int[] { 16 ,3 ,2, 4, 11 ,1, 12, 8, 9, 7, 10, 13, 15, 17 };

            //int[] arr = new int[] { 20 ,2 ,7 ,18, 10, 1, 17, 5, 13, 15, 19, 9, 11, 16, 8, 14, 3 ,12, 6, 4 };
            //int[] arr = new int[] { -8 ,- 15 ,7 ,- 2, 0, 14, - 4, 15, - 7, - 12, - 9, 13, - 10, 6, - 3, 11, - 1, 2, 1, 9, 4, - 13, - 14, - 6, 5, 10, - 11 ,12 ,- 5 ,8 ,3 };

            List<int> list = new List<int>(arr);

            return list;

        }
    }
}
