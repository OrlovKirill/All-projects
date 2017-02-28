using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
    {
    public class BinarySearchTree<TKey,TValue> where TKey: IComparable<TKey>
        {

        internal class BinaryTreeNode
            {

            internal KeyValuePair<TKey , TValue> value;
            internal BinaryTreeNode parent;
            internal BinaryTreeNode LeftChild;
            internal BinaryTreeNode RightChild;

            public BinaryTreeNode (KeyValuePair<TKey,TValue> node)
                {
                if (Equals(node , null))
                    throw new ArgumentException("Cannot insert null value!");
                this.value = node;
                this.parent = null;
                this.LeftChild = null;
                this.RightChild = null;
                }

            public override string ToString ()
                {
                return this.value.ToString();
                }

            public override int GetHashCode ()
                {
                return this.value.GetHashCode();
                }

            public override bool Equals (object obj)
                {
                BinaryTreeNode other = (BinaryTreeNode)obj;
                return this.CompareTo(other.value.Key) == 0;
                }

            public int CompareTo (TKey key1)
                {
                return this.value.Key.CompareTo(key1);
                }

        public interface IComparable
                {
                int CompareTo (TKey other);
                }
            }

        private BinaryTreeNode root;
        private BinaryTreeNode UnbalancedNode;
        public List<KeyValuePair<TKey , TValue>> AvlList = new List<KeyValuePair<TKey , TValue>>();
        private bool flag = false;

        public BinarySearchTree ()
            {
            this.root = null;
            }

        public void Insert (KeyValuePair<TKey,TValue> value)
            {
            this.root = Insert(value , null , root);
            GetList();
            }

        private BinaryTreeNode Insert (KeyValuePair<TKey,TValue> value , BinaryTreeNode parentNode , BinaryTreeNode node)
            {
            if (node == null)
                {
                node = new BinaryTreeNode(value);
                node.parent = parentNode;
                }
            else
                {
                int compareTo = value.Key.CompareTo(node.value.Key);


                if (compareTo < 0)
                    {
                    node.LeftChild = Insert(value , node , node.LeftChild);
                    
                    if (ImBalance(node))       
                        {
                        if (value.Key.CompareTo(node.LeftChild.value.Key) < 0)
                            RightTurn(node , node.LeftChild);
                        else
                            LeftRightTurn(node , node.LeftChild , node.LeftChild.RightChild);
                        }
                    }

                else
                if (compareTo > 0)
                    {
                    node.RightChild = Insert(value , node , node.RightChild);

                    if (ImBalance(node))
                        {
                        // if (node.RightChild.RightChild != null)
                        if (value.Key.CompareTo(node.RightChild.value.Key) > 0)
                            LeftTurn(node , node.RightChild);
                        else
                            RightLeftTurn(node , node.RightChild , node.RightChild.LeftChild);
                        }
                    }
                }
            if (!flag)
                return node;
            else
                {
                flag = false;
                return node.parent;
                }
            }

        private void RightTurn (BinaryTreeNode A , BinaryTreeNode B)
            {
            A.LeftChild = B.RightChild;
            if (B.RightChild != null)
                B.RightChild.parent = A;
            B.RightChild = A;
            B.parent = A.parent;
            flag = true;
            A.parent = B;
            if (Equals(root , A))
                B.parent = null;
            }

        private void LeftTurn (BinaryTreeNode A , BinaryTreeNode B)
            {
            A.RightChild = B.LeftChild;
            if (B.LeftChild != null)
                B.LeftChild.parent = A;
            B.LeftChild = A;
            B.parent = A.parent;
            flag = true;
            A.parent = B;
            if (Equals(root , A))
                B.parent = null;
            }

        private void LeftRightTurn (BinaryTreeNode A , BinaryTreeNode B , BinaryTreeNode C)
            {
            B.RightChild = C.LeftChild;
            if (C.LeftChild != null)
                C.LeftChild.parent = B;
            A.LeftChild = C;
            C.LeftChild = B;
            B.parent = C;
            C.parent = A;
            RightTurn(A , C);
            }

        private void RightLeftTurn (BinaryTreeNode A , BinaryTreeNode B , BinaryTreeNode C)
            {
            B.LeftChild = C.RightChild;
            if (C.RightChild != null)
                C.RightChild.parent = B;
            A.RightChild = C;
            C.RightChild = B;
            B.parent = C;
            C.parent = A;
            LeftTurn(A , C);
            }

        private bool ImBalance (BinaryTreeNode node)
            {
            if (node.RightChild == null && node.LeftChild == null)
                return false;

            if ((node.RightChild != null && node.LeftChild != null))
                {
                if (Math.Abs(GetHeight(node.RightChild) - GetHeight(node.LeftChild)) > 1)
                    return true;
                }
            else
            if (node.RightChild != null)
                {
                if (GetHeight(node.RightChild) > 1)
                    return true;
                }
            else
                {
                if (GetHeight(node.LeftChild) > 1)
                    return true;
                }
            return false;
            }

        private int GetHeight (BinaryTreeNode node)
            {

            if (node == null)
                return 0;
            else
                {
                int height = 1;
                if (node.LeftChild != null && node.RightChild != null)
                    height += Math.Max(GetHeight(node.LeftChild) , GetHeight(node.RightChild));
                else
                    if (node.LeftChild == null && node.RightChild == null)
                    return 1;
                else
                        if (node.RightChild != null)
                    height += GetHeight(node.RightChild);
                else
                        if (node.LeftChild != null && !Equals(node,node.LeftChild))
                    height += GetHeight(node.LeftChild);

                return height;
                }
            }

        internal BinaryTreeNode Find (TKey key)
            {
            BinaryTreeNode node = this.root;
            while (node != null)
                {
                int compareTo = key.CompareTo(node.value.Key);
                if (compareTo < 0)
                    node = node.LeftChild;
                else
                    if (compareTo > 0)
                    node = node.RightChild;
                else
                    break;
                }
            return node;
            }

        public bool Contains (TKey key)
            {
            bool found = this.Find(key) != null;
            return found;
            }

        public void Remove (TKey key)
            {
            BinaryTreeNode nodeToDelete = Find(key);
            if (nodeToDelete != null)
                {
                Remove(nodeToDelete);
                AvlList.Remove(nodeToDelete.value);
                }
            }

        private void Remove (BinaryTreeNode node)
            {
            if (node.LeftChild != null && node.RightChild != null)
                {
                BinaryTreeNode replacement = node.RightChild;
                while (replacement.LeftChild != null)
                    {
                    replacement = replacement.LeftChild;
                    }
                node.value = replacement.value;
                node = replacement;
                }


            BinaryTreeNode theChild = node.LeftChild != null ? node.LeftChild : node.RightChild;
            if (theChild != null)
                {
                theChild.parent = node.parent;
                if (node.parent == null)
                    root = theChild;
                else
                    if (node.parent.LeftChild == node)
                    node.parent.LeftChild = theChild;
                else
                    node.parent.RightChild = theChild;
                }
            else
                {
                if (node.parent == null)
                    root = null;
                else
                    if (node.parent.LeftChild == node)
                    node.parent.LeftChild = null;
                else
                    node.parent.RightChild = null;
                }

            BinaryTreeNode UnbNode = FindUnbalancedNode();
            if (UnbNode != null)
                {
                if (GetHeight(UnbNode.LeftChild) > GetHeight(UnbNode.RightChild))                           // LEFT - ...
                    {
                    if (GetHeight(UnbNode.LeftChild.LeftChild) > GetHeight(UnbNode.LeftChild.RightChild))   // LEFT - LEFT
                        RightTurn(UnbNode , UnbNode.LeftChild);
                    else                                                                                    // LEFT - RIGHT
                        LeftRightTurn(UnbNode , UnbNode.LeftChild , UnbNode.LeftChild.RightChild);
                    }
                else                                                                                        // RIGHT - ...
                    {
                    if (GetHeight(UnbNode.RightChild.RightChild) > GetHeight(UnbNode.RightChild.LeftChild)) // RIGHT - RIGHT
                        LeftTurn(UnbNode , UnbNode.RightChild);
                    else                                                                                    // RIGHT - LEFT
                        RightLeftTurn(UnbNode , UnbNode.RightChild , UnbNode.RightChild.LeftChild);
                    }
                if (UnbNode.parent.parent == null)
                    root = UnbNode.parent;
                else
                    if (UnbNode.parent.parent.LeftChild == UnbNode)
                    UnbNode.parent.parent.LeftChild = UnbNode.parent;
                else
                    UnbNode.parent.parent.RightChild = UnbNode.parent;
                flag = false;
                }

            }

        private  void GetPair (BinaryTreeNode node)
            {
            if (!Equals(node,null))
                {
                GetPair(node.LeftChild);
                AvlList.Add(node.value);
                GetPair(node.RightChild);
                }
            }

        public List<KeyValuePair<TKey,TValue>> GetList ()
            {
            AvlList.Clear();
            GetPair(root);
            return AvlList;
            }

        private BinaryTreeNode FindUnbalancedNode ()
            {
            UnbalancedNode = null;
            FinUnNode(root);
            return UnbalancedNode;
            }

        private void FinUnNode (BinaryTreeNode node)
            {
            if (node != null)
                if (UnbalancedNode == null)
                    {
                    FinUnNode(node.LeftChild);
                    if (ImBalance(node))
                        UnbalancedNode = node;
                    FinUnNode(node.RightChild);
                    }

            }

        public void PrintTreeDFS ()
            {
            Console.WindowHeight = 49;
            Console.WindowWidth = 212;
            Console.WindowLeft = 0;
            Console.WindowTop = 0;
            PrintTreeDFS(this.root);


            }

        private void PrintTreeDFS (BinaryTreeNode node)
            {
            if (node != null)
                {
                PrintTreeDFS(node.LeftChild);
                Console.Write(node.value + " ");
                PrintTreeDFS(node.RightChild);
                }

            }
        }
    }
