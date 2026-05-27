using System.Collections;
using System.Collections.Generic;
using System.Text;
using AssignmentSystem.Services;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment01
{
    public class StudentSolution : MonoBehaviour, IAssignment
    {

        #region Lecture

        public void LCT01_SyntaxArray()
        {
            string[] ironManSuit = new string[2];
            ironManSuit[0] = "Mark I";
            ironManSuit[1] = "Mark II";
            string tonyStarkWear = ironManSuit[0];
            Debug.Log($" TonyStark Wear: {tonyStarkWear}");
            Debug.Log($"Room size: {ironManSuit.Length}");
            Debug.Log(ironManSuit[0]);
            Debug.Log(ironManSuit[1]);
        }

        public void LCT02_ArrayInitialize()
        {
            string[] spiderRoom = new string[3];
            spiderRoom[0] = "Classic SpiderMan";
            spiderRoom[1] = "Black Suit";
            spiderRoom[2] = "Iron Spider Suit";

            Debug.Log($"Room size: {spiderRoom.Length}");
            Debug.Log(spiderRoom[0]);
            Debug.Log(spiderRoom[1]);
            Debug.Log(spiderRoom[2]);

            string[] batRoom = new string[2];
            batRoom[0] = "Classic BatMan";
            batRoom[1] = "White bat";

            Debug.Log($"Room size: {batRoom.Length}");
            Debug.Log(batRoom[0]);
            Debug.Log(batRoom[1]);
        }

        public void LCT03_SyntaxLoop()
        {
            for (int i = 0; i < 10; i++)
            {
                Debug.Log("<10 : " + i);
            }
            Debug.Log("===");
            for (int i = 1; i <= 10; i++)
            {
                Debug.Log("<=10 : " + i);
            }
        }

        public void LCT04_LoopAndArray(string[] ironManSuitNames)
        {
            for (int i = 0; i < ironManSuitNames.Length; i++)
            {
                Debug.Log(ironManSuitNames[i]);
            }
            Debug.Log("===");
            for (int i = 0; i < ironManSuitNames.Length; i += 2)
            {
                Debug.Log(ironManSuitNames[i]);
            }
        }

        public void LCT05_Syntax2DArray()
        {
            int[,] my2DArray = new int[2, 2]{
        {1,2},
        {3,4}
    };
            Debug.Log("my2DArray[0, 0] = " + my2DArray[0, 0]);
            Debug.Log("my2DArray[0, 1] = " + my2DArray[0, 1]);
            Debug.Log("my2DArray[1, 0] = " + my2DArray[1, 0]);
            Debug.Log("my2DArray[1, 1] = " + my2DArray[1, 1]);

            my2DArray[0, 1] = 6;
            my2DArray[1, 1] = 8;
            Debug.Log("After change value");
            Debug.Log("my2DArray[0, 1] = " + my2DArray[0, 1]);
            Debug.Log("my2DArray[1, 1] = " + my2DArray[1, 1]);
        }

        public void LCT06_SizeOf2DArray(int[,] my2DArray)
        {
            Debug.Log("rows = " + my2DArray.GetLength(0));
            Debug.Log("cols = " + my2DArray.GetLength(1));
        }

        public void LCT07_SyntaxNestedLoop(int columns, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                string row = "";
                for (int j = 0; j < columns; j++)
                {
                    row += "*";
                }
                Debug.Log(row);
            }
        }

        #endregion

        #region Assignment

        public void AS01_RandomItemDrop(GameObject[] items)
        {
            if (items == null || items.Length == 0)
                return;

            Random.InitState(42);

            int randIndex = Random.Range(0, items.Length);

            Debug.Log("Got item: " + items[randIndex].name);
        }

        public void AS02_NestedLoopForCreate2DMap(GameObject[] floorTiles, int columns, int rows)
        {
            var oldTiles = GameObject.FindObjectsByType<Transform>(FindObjectsSortMode.None);
            foreach (var t in oldTiles)
            {
                if (t.name.StartsWith("["))
                {
                    Object.DestroyImmediate(t.gameObject);
                }
            }

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    GameObject tilePrefab = floorTiles[(x + y) % floorTiles.Length];

                    GameObject tile = Object.Instantiate(
                        tilePrefab,
                        new Vector3(x, y, 0),
                        Quaternion.identity
                    );

                    tile.name = $"[{x}:{y}]";
                }
            }
        }

        public void AS03_NestedLoopForMakingWallAround(GameObject wall, int columns, int rows)
        {
            var oldTiles = GameObject.FindObjectsByType<Transform>(FindObjectsSortMode.None);
            foreach (var t in oldTiles)
            {
                if (t.name.StartsWith("["))
                {
                    Object.DestroyImmediate(t.gameObject);
                }
            }

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    bool isBorder =
                        x == 0 || x == columns - 1 ||
                        y == 0 || y == rows - 1;

                    if (!isBorder) continue;

                    GameObject w = Object.Instantiate(
                        wall,
                        new Vector3(x, y, 0),
                        Quaternion.identity
                    );

                    w.name = $"[{x}:{y}]";
                }
            }
        }

        public void AS04_AttackEnemy(int[] enemyHP, int damage, int target)
        {
            if (enemyHP == null || enemyHP.Length == 0)
                return;

            int count = enemyHP.Length;

            enemyHP[0] -= damage;
            if (enemyHP[0] < 0) enemyHP[0] = 0;
            int firstHp = enemyHP[0];

            enemyHP[count - 1] -= damage;
            if (enemyHP[count - 1] < 0) enemyHP[count - 1] = 0;
            int lastHp = enemyHP[count - 1];

            enemyHP[target] -= damage;
            if (enemyHP[target] < 0) enemyHP[target] = 0;
            int targetHp = enemyHP[target];

            string output =
                "FirstEnemy hp :" + firstHp + "\n" +
                "LastEnemy hp :" + lastHp + "\n" +
                "TargetEnemy " + target + " hp :" + targetHp;

            Debug.Log(output);
        }

        public void AS05_DynamicIterationLoop(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Debug.Log(i - 1);
            }
        }

        public void AS06_WhileLoopAndArray(string[] ironManSuitNames)
        {
            int i = 0;
            while (i < ironManSuitNames.Length)
            {
                Debug.Log(ironManSuitNames[i]);
                i++;
            }
            Debug.Log("===");

            i = 0;
            while (i < ironManSuitNames.Length)
            {
                Debug.Log(ironManSuitNames[i]);
                i += 2;
            }
        }

        public void AS07_HealTargetAtIndex(int[] heroHPs, int heal, int targetIndex)
        {
            if (heroHPs == null || heroHPs.Length == 0)
                return;

            int count = heroHPs.Length;

            heroHPs[0] += heal;
            int firstHp = heroHPs[0];

            heroHPs[count - 1] += heal;
            int lastHp = heroHPs[count - 1];

            heroHPs[targetIndex] += heal;
            int targetHp = heroHPs[targetIndex];

            string output =
                "FirstHero hp :" + firstHp + "\n" +
                "LastHero hp :" + lastHp + "\n" +
                "TargetHero " + targetIndex + " hp :" + targetHp;

            Debug.Log(output);
        }

        public void AS08_RandomPickingDialogue(string[] dialogues)
        {
            if (dialogues == null || dialogues.Length == 0)
                return;

            int index = Random.Range(0, dialogues.Length);
            Debug.Log(dialogues[index]);
        }

        public void AS09_MultiplicationTable(int n)
        {
            for (int i = 1; i <= 12; i++)
            {
                Debug.Log(n + "x" + i + "=" + (n * i));
            }
        }

        public void AS10_FindSummationFromZeroToNUsingWhileLoop(int n)
        {
            int sum = 0;
            int i = 0;

            while (i <= n)
            {
                sum += i;
                i++;
            }

            Debug.Log("ผลรวมของ n จาก 0 ถึง " + n + " คือ " + sum);
        }

        public void AS11_SpawnEnemies(int[] enemyHPs, GameObject enemyPrefab)
        {
            if (enemyHPs == null || enemyPrefab == null)
                return;

            for (int i = 0; i < enemyHPs.Length; i++)
            {
                GameObject enemy = GameObject.Instantiate(enemyPrefab);
                enemy.transform.position = new Vector3(i + 1, 0, 0);

                Debug.Log("new enemy at position x = " + (i + 1));
            }
        }

        public IEnumerator AS12_CountTime(float CountTime)
        {
            float time = CountTime;

            while (time > 0)
            {
                Debug.Log(time);
                yield return new WaitForSeconds(1f);
                time--;
            }

            Debug.Log("End timer : " + CountTime);
        }

        public void AS13_SumOfNumbersInRow(int[,] matrix, int row)
        {
            int sum = 0;

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                sum += matrix[row, i];
            }

            Debug.Log(sum);
        }

        public void AS14_SumOfNumbersInColumn(int[,] matrix, int column)
        {
            int sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, column];
            }

            Debug.Log(sum);
        }

        public void AS15_MakeTheTriangle(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                string line = "";
                for (int j = 0; j < i; j++)
                {
                    line += "*";
                }
                Debug.Log(line);
            }
        }

        public void AS16_MultiplicationTableOf_2_3_and_4()
        {
            for (int i = 1; i <= 12; i++)
            {
                string line =
                    "2 x " + i + " = " + (2 * i) + "\t" +
                    "3 x " + i + " = " + (3 * i) + "\t" +
                    "4 x " + i + " = " + (4 * i);

                Debug.Log(line);
            }
        }


        #endregion

        #region Extra assignment

        public void EX_01_TicTacToeGame_TurnPlay(string[,] board, string playerTurn, int row, int column)
        {
            throw new System.NotImplementedException();
        }

        private void PrintBoard(string[,] board)
        {
            StringBuilder sb = new();
            for (int i = 0; i < 3; i++)
            {
                sb.AppendLine("-------------");
                sb.AppendLine("| " + board[i, 0] + " | " + board[i, 1] + " | " + board[i, 2] + " |");
            }
            sb.AppendLine("-------------");
            Debug.Log(sb.ToString());
        }
        #endregion
    }

}
