using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AssignmentSystem.Services;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment04
{
    public class StudentSolution : MonoBehaviour, IAssignment
    {
        #region Lecture
        public void LCT01_SelectionSortAscending(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[j] < numbers[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = numbers[minIndex];
                numbers[minIndex] = numbers[i];
                numbers[i] = temp;
            }
            foreach (var n_ in numbers)
            {
                Debug.Log(n_);
            }
        }

        public void LCT02_BubbleSortAscending(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
            foreach (var n_ in numbers)
            {
                Debug.Log(n_);
            }
        }

        public void LCT03_InsertionSortAscending(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n; i++)
            {
                int key = numbers[i];
                int j = i - 1;

                while (j >= 0 && numbers[j] > key)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }
                numbers[j + 1] = key;

            }
            foreach (var n_ in numbers)
            {
                Debug.Log(n_);
            }
        }
        #endregion

        #region Assignment

        public void AS01_SelectionSortDescending(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int maxIndex = i;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] > numbers[maxIndex])
                    {
                        maxIndex = j;
                    }
                }

                int temp = numbers[i];
                numbers[i] = numbers[maxIndex];
                numbers[maxIndex] = temp;
            }

            foreach (int num in numbers)
            {
                Debug.Log(num);
            }
        }

        public void AS02_BubbleSortDescending(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - i - 1; j++)
                {
                    if (numbers[j] < numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }

            foreach (int num in numbers)
            {
                Debug.Log(num);
            }
        }

        public void AS03_InsertionSortDescending(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                int key = numbers[i];
                int j = i - 1;

                while (j >= 0 && numbers[j] < key)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }

                numbers[j + 1] = key;
            }

            foreach (int num in numbers)
            {
                Debug.Log(num);
            }
        }

        public void AS04_FindTheSecondLargestNumber(int[] numbers)
        {
            int largest = int.MinValue;
            int secondLargest = int.MinValue;

            foreach (int num in numbers)
            {
                if (num > largest)
                {
                    secondLargest = largest;
                    largest = num;
                }
                else if (num > secondLargest && num < largest)
                {
                    secondLargest = num;
                }
            }

            Debug.Log(secondLargest);
        }

        #endregion

        #region Extra

        public void EX01_FindLongestConsecutiveSequence(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                Debug.Log("The longest consecutive sequence is: 0");
                return;
            }

            HashSet<int> set = new HashSet<int>(numbers);
            int longest = 0;

            foreach (int num in set)
            {
                // เช็คว่าเป็นจุดเริ่มต้นของ sequence หรือไม่
                if (!set.Contains(num - 1))
                {
                    int currentNum = num;
                    int currentStreak = 1;

                    while (set.Contains(currentNum + 1))
                    {
                        currentNum++;
                        currentStreak++;
                    }

                    if (currentStreak > longest)
                    {
                        longest = currentStreak;
                    }
                }
            }

            Debug.Log("The longest consecutive sequence is: " + longest);
        }
        #endregion
    }
}
