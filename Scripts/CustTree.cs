using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dectree
{

    public class Node
    {

        public string maintext;
        // Type of encounter
        public string type;
        // An array of effects incurred by the decision 
        public int[] effect;
        public string[] optiontext;
        public Node option1;
        public Node option2;
        public Node option3;

        public Node(string mt, string typ, int[] eff, string[] optext, Node op1 = null, Node op2 = null, Node op3 = null)
        {
            maintext = mt;
            type = typ;
            effect = eff;
            option1 = op1;
            option2 = op2;
            option3 = op3;
            optiontext = optext;

        }
    }


    public class CustTree
    {
        // The tree has a reference to the  
        public Node root;

        // Checks if there is an element in current path of tree
        // Path Example: [1, 2, 2] -> Checks if Left -> Middle -> Middle exists
        bool checkBlank(int[] path)
        {
            Node cur = root;
            int length = path.Length;
            for (int i = 0; i<length; ++i)
            {
                int dir = path[i];
                if (dir == 1)
                {
                    cur = cur.option1; 
                } 
                else if (dir == 2)
                {
                    cur = cur.option2; 
                }
                else
                {
                    cur = cur.option3; 
                }
            }
            if (cur == null) return true; 
            else return false;       
        }





        /// <summary>
        /// Inserts a new node into the tree given the path. 
        /// The path must exist to create it, with 0 as special case for creating the initial tree
        /// </summary>
        /// <param name="path"></param>
        /// <param name="mt"></param>
        /// <param name="typ"></param>
        /// <param name="eff"></param>
        public void insertNode(int[] path, string mt, string typ, int[] eff, string[] optext)
        {
            Node toIns = new Node(mt, typ, eff, optext); 
            // Special case where we create new tree
            if (path[0] == 0)
            {
                root = toIns;
                return;

            }
            if (checkBlank(path))
            {
                Node cur = root;
                int length = path.Length;
                for (int i = 0; i<length-1; ++i)
                {
                    int dir = path[i];
                    
                    if (dir == 1)
                    {
                        cur = cur.option1;
                    }
                    else if (dir == 2)
                    {
                        cur = cur.option2;
                    }
                    else if (dir == 3)
                    {
                        cur = cur.option3;
                    }
                    // cur is now the node we want to deal with
                
                }
                if (path[length-1] == 1)
                {
                    cur.option1 = toIns; 
                }
                else if (path[length-1] == 2)
                {
                    cur.option2 = toIns;
                }
                else if (path[length-1] == 3)
                {
                    cur.option3 = toIns;
                }

           
                // root = prevroot;
            }
            else
            {
                Debug.LogError("Can not insert node into non-empty path");
            }

        }

        /// <summary>
        /// Updates root to new value to follow the tree
        /// </summary>
        /// <param name="dir"></param>
        public void stepTree(int dir)
        {
            if (dir == 1)
            {
                root = root.option1;
            } 
            else if (dir == 2)
            {
                root = root.option2;
            }
            else
            {
                root = root.option3;
            }
        }

        public void printTree(Node cur)
        {
            if (cur != null)
            {
                Debug.Log(cur.maintext);
            }
            else
            {
                return;
            }
            if (cur.option1 != null)
            {
                printTree(cur.option1); 
            }
            if (cur.option2 != null)
            {
                printTree(cur.option2);
            }
            if (cur.option3 != null)
            {
                printTree(cur.option3);
            }
            return;
            
                
        }



    }


}
