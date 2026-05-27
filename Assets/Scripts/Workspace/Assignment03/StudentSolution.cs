using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AssignmentSystem.Services;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment03
{
    public class StudentSolution : MonoBehaviour, IAssignment
    {
        #region Lecture

        public void LCT01_SyntaxLinkedList()
        {
           // 1. สร้าง LinkedList ของประเภท string
            LinkedList<string> linkedList = new LinkedList<string>();

            // 2. เพิ่มข้อมูลที่ท้ายของ LinkedList
            linkedList.AddLast("Node 1");
            linkedList.AddLast("Node 2");

            // 3. เพิ่มข้อมูลที่ต้นของ LinkedList
            linkedList.AddFirst("Node 0");

            // 4. แสดงเนื้อหาใน LinkedList
            LCT01_PrintLinkedList(linkedList);

            // 5. เช้าถึงข้อมูลใน LinkedList
            LinkedListNode<string> firstNode = linkedList.First;
            Debug.Log("first", firstNode.Value);
            LinkedListNode<string> lastNode = linkedList.Last;
            Debug.Log("last", lastNode.Value);
            LinkedListNode<string> node1 = linkedList.Find("Node 1");
            Debug.Log(node1.Previous.Value);
            Debug.Log(node1.Next.Value);
            if (firstNode.Previous == null)
            {
                Debug.Log("firstNode.Previous is null");
            }
            if (lastNode.Next == null)
            {
                Debug.Log("lastNode.Next is null");
            }

            // 6. add node ก่อน หรือ หลัง node ที่กำหนด
            linkedList.AddAfter(node1, "Node 1.5");
            linkedList.AddBefore(node1, "Node 0.5");
            LCT01_PrintLinkedList(linkedList);

            // 6. ลบ Node แรก
            linkedList.RemoveFirst();
            LCT01_PrintLinkedList(linkedList);

            // 7. ลบ Node ตามค่าที่กำหนด
            linkedList.Remove("Node 2");
            LCT01_PrintLinkedList(linkedList);
        }

        private void LCT01_PrintLinkedList(LinkedList<string> linkedList)
        {
            Debug.Log("LinkedList...");
            foreach(var node in linkedList)
            {
                Debug.Log(node);
            }
        }

        public void LCT02_SyntaxHashTable()
        {
            
            Hashtable hashtable = new Hashtable();
            //Key Value
            hashtable.Add(1,"Apple");
            hashtable.Add(2,"Banana");
            hashtable.Add("bad-fruit","Rotten Tomato");

            string fruit1 = (string)hashtable[1];
            string fruit2 = (string)hashtable[2];
            string badFruit = (string)hashtable["bad-fruit"];

            Debug.Log($"fruit1: {fruit1}");
            Debug.Log($"fruit2: {fruit2}");
            Debug.Log($"badFruit: {badFruit}");

            LCT02_PrintHashTable(hashtable);

            int key = 2;
            if (hashtable.ContainsKey(key))
            {
                Debug.Log($"found {key}");
            }
            else
            {
                Debug.Log($"not found {key}");
            }

            int keyToRemove = 1;
            hashtable.Remove(keyToRemove);
            LCT02_PrintHashTable(hashtable);
        }
        public void LCT02_PrintHashTable(Hashtable hashtable)
        {
            Debug.Log("table ...");
            foreach(DictionaryEntry entry in hashtable)
            {
                Debug.Log($"Key: {entry.Key}, Value: {entry.Value}");
            }
        }

        public void LCT03_SyntaxDictionary()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Assignment

        public void AS01_CountWords(string[] words)
        {
            Dictionary<string, int> dict = new();

            foreach (string word in words)
            {
                if (dict.ContainsKey(word))
                    dict[word]++;
                else
                    dict[word] = 1;
            }

            foreach (var kvp in dict)
            {
                Debug.Log($"word: '{kvp.Key}' count: {kvp.Value}");
            }
        }

        public void AS02_CountNumber(int[] numbers)
        {
            Dictionary<int, int> dict = new();

            foreach (int num in numbers)
            {
                if (dict.ContainsKey(num))
                    dict[num]++;
                else
                    dict[num] = 1;
            }

            foreach (var kvp in dict)
            {
                Debug.Log($"number: {kvp.Key} count: {kvp.Value}");
            }
        }

        public void AS03_CheckValidBrackets(string input)
        {
            Stack<char> stack = new();

            foreach (char c in input)
            {
                if (c == '(' || c == '[' || c == '{')
                    stack.Push(c);
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0)
                    {
                        Debug.Log("Invalid");
                        return;
                    }

                    char open = stack.Pop();

                    if ((c == ')' && open != '(') ||
                        (c == ']' && open != '[') ||
                        (c == '}' && open != '{'))
                    {
                        Debug.Log("Invalid");
                        return;
                    }
                }
            }

            Debug.Log(stack.Count == 0 ? "Valid" : "Invalid");
        }

        public void AS04_PrintReverseLinkedList(LinkedList<int> list)
        {
            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            LinkedListNode<int> node = list.Last;
            while (node != null)
            {
                Debug.Log(node.Value);
                node = node.Previous;
            }
        }

        public void AS05_FindMiddleElement(LinkedList<string> list)
        {
            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            int midIndex = list.Count / 2;
            LinkedListNode<string> node = list.First;

            for (int i = 0; i < midIndex; i++)
                node = node.Next;

            Debug.Log(node.Value);
        }

        public void AS06_MergeDictionaries(Dictionary<string, int> dict1, Dictionary<string, int> dict2)
        {
            Dictionary<string, int> result = new(dict1);

            foreach (var kvp in dict2)
            {
                if (result.ContainsKey(kvp.Key))
                    result[kvp.Key] += kvp.Value;
                else
                    result[kvp.Key] = kvp.Value;
            }

            foreach (var kvp in result)
            {
                Debug.Log($"key: {kvp.Key}, value: {kvp.Value}");
            }
        }

        public void AS07_RemoveDuplicatesFromLinkedList(LinkedList<int> list)
        {
            HashSet<int> seen = new();
            LinkedListNode<int> node = list.First;

            while (node != null)
            {
                if (!seen.Contains(node.Value))
                {
                    seen.Add(node.Value);
                    Debug.Log(node.Value);
                }
                node = node.Next;
            }
        }

        public void AS08_TopFrequentNumber(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                Debug.Log("Input array is empty");
                return;
            }

            Dictionary<int, int> dict = new();

            foreach (int num in numbers)
            {
                if (dict.ContainsKey(num))
                    dict[num]++;
                else
                    dict[num] = 1;
            }

            int topNumber = numbers[0];
            int maxCount = dict[topNumber];

            foreach (var kvp in dict)
            {
                if (kvp.Value > maxCount)
                {
                    topNumber = kvp.Key;
                    maxCount = kvp.Value;
                }
            }

            Debug.Log($"{topNumber} count: {maxCount}");
        }

        public void AS09_PlayerInventory(Dictionary<string, int> inventory, string itemName, int quantity)
        {
            if (inventory == null)
            {
                Debug.Log("Inventory is null");
                return;
            }

            if (inventory.ContainsKey(itemName))
                inventory[itemName] += quantity;
            else
                inventory[itemName] = quantity;

            foreach (var kvp in inventory)
            {
                Debug.Log($"{kvp.Key}: {kvp.Value}");
            }
        }

        #endregion

        #region Extra

        public void EX01_GameEventQueue(LinkedList<GameEvent> eventQueue)
        {
            throw new System.NotImplementedException();
        }

        public void EX02_PlayerStatsTracker(Dictionary<string, int> playerStats, string statName, int value)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
