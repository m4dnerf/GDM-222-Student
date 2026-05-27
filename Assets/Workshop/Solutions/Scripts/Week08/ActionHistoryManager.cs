using NUnit.Compatibility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
namespace Solution
{
    public class ActionHistoryManager : MonoBehaviour
    {
        // 1. Undo System using Stack
   private Stack<Vector2> undostack = new Stack<Vector2>();
   private Stack<Vector2> redostack = new Stack<Vector2>();

        // 2. Auto-Move System using Queue
        private Queue<Vector2> autoMoveQueue = new Queue<Vector2>();
        #region "This Is undoStack Function"

        /// Saves the current player state (position) to the undo stack.
        public void SaveStateForUndo(Vector2 currentPosition)
        {
            if (undostack.Count == 0 || !undostack.Peek().Equals(currentPosition))
            {
                {
                    undostack.Push(currentPosition);
                    if(redostack.Count > 0 )
                    {
                        redostack.Clear();
                        Debug.Log("Redo stack cleared");
                    }
                    Debug.Log($"State is saved : Position {currentPosition}");
                    
                }
            }
        }
        /// Reverts the player's state to the previous one using the undo stack.
        /// </summary>
        public void UndoLastMove(OOPPlayer player)
        {
           if (undostack.Count > 1)
            {
                
                Vector2 currentPosition = undostack.Pop();
                redostack.Push(currentPosition);
                Vector2 previousState = undostack.Peek();
                transform.position = previousState;

                int toX = (int)transform.position.x;
                int toY = (int)transform.position.y;

                player.UpdatePosition(toX, toY);
                Debug.Log("Undo successful");
            }
        }
        public void RedoLastMove(OOPPlayer player)
        {
            if(redostack.Count > 0)
            {
                Vector2 stateToRedo = redostack.Pop();

                undostack.Push(stateToRedo);
                transform.position = stateToRedo;
                int toX = (int)(transform.position.x);
                int toY = (int)(transform.position.y);

                player.UpdatePosition(toX, toY);
                Debug.Log("Redo successful");
            }
            else
            {
                Debug.Log("Cannot Redo");
            }
        }
        #endregion

        #region "This Is autoMoveQueue Function"

        public void StartAutoMoveSequence(OOPPlayer player)
        {
            List<Vector2> sequence = new List<Vector2>
            {
                Vector2.right,
                Vector2.up,
                Vector2.down,
                Vector2.left,
                Vector2.right,
                Vector2.up,


            };
            StartCoroutine(ProcessAutoMoveSequence(sequence,player));
        }
        public IEnumerator ProcessAutoMoveSequence(List<Vector2> moves, OOPPlayer player)
        {
            player.isAutoMoving = true;
            autoMoveQueue.Clear();
            // 1. เตรียม Queue: ล้าง Queue เดิมและเพิ่มลำดับการเคลื่อนที่ใหม่
           foreach (var move in moves)
            {
                autoMoveQueue.Enqueue(move);

            }
            Debug.Log($"Auto move sequence started with {autoMoveQueue.Count} steps");


            // 2. ประมวลผล Queue ทีละขั้นตอน
            while (autoMoveQueue.Count > 0)
            {
                Vector2 nextDirection = autoMoveQueue.Dequeue();
                player.Move(nextDirection);
                yield return new WaitForSeconds(0.5f);
            }

            player.isAutoMoving = false;

            Debug.Log("Auto-move sequence finished.");
        }

        #endregion

    }
}

