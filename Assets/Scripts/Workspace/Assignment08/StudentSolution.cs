using PlasticGui.WorkspaceWindow.QueryViews;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment08
{
    public class StudentSolution : IAssignment
    {
        class Action
        {
            public string Name;
            public int Value;
        }

        #region Lecture

        public void LCT01_StackSyntax()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Debug.Log($"Count: {stack.Count}");
            
            var popped = stack.Pop();
            Debug.Log($"Popped: {popped}");

            var top = stack.Peek();
            Debug.Log($"Peek: {top}");
            Debug.Log($"Count after peek: {stack.Count}");
            stack.Clear();
        }

        public void LCT02_QueueSyntax()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);   
            queue.Enqueue(2);
            queue.Enqueue(3);

            Debug.Log($"Count: {queue.Count}");

            var dequeued = queue.Dequeue();
            Debug.Log($"Count: {dequeued}");

            var front = queue.Peek();
            Debug.Log($"Peek: {front}");
            Debug.Log($"Count after dequeue: {queue.Count}");

        }

        public void LCT03_ActionStack()
        {
            Action action1 = new Action { Name = "Action 1" };
            Action action2 = new Action { Name = "Action 2" };
            Action action3 = new Action { Name = "Action 3" };
            Stack<Action> actionstack = new Stack<Action>();
            actionstack.Push(action1);
            actionstack.Push(action2);
            actionstack.Push(action3);
            while(actionstack.Count > 0)
            {
                var action = actionstack.Pop();
                Debug.Log($"Executing {action.Name}");
            }
        }

        public void LCT04_ActionQueue()
        {
            Action action1 = new Action { Name = "Action 1" };
            Action action2 = new Action { Name = "Action 2" };
            Action action3 = new Action { Name = "Action 3" };
            
            Queue<Action> actionqueue = new Queue<Action>();
            actionqueue.Enqueue(action1);
            actionqueue.Enqueue(action2);   
            actionqueue.Enqueue(action3);

            while (actionqueue.Count > 0)
            {
                var action = actionqueue.Dequeue();
                Debug.Log($"Executing {action.Name}");
            }

        }

        #endregion

        #region Assignment

        public void ASN01_ReverseString(string str)
        {
            throw new NotImplementedException();
        }

        public void ASN02_StackPalindrome(string str)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Extra

        public void EX01_ParenthesesChecker(string str)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
