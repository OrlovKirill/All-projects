using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL___TREE
    {

    public class BinarySearchTree<T> where T : IComparable<T>
        {

        internal class BinaryTreeNode<T>: IComparable<BinaryTreeNode<T>> where T : IComparable<T>
            {

            internal T value;
            internal BinaryTreeNode<T> parent;
            internal BinaryTreeNode<T> LeftChild;
            internal BinaryTreeNode<T> RightChild;
            
            public BinaryTreeNode (T value)
                {
                if (value == null)
                    throw new ArgumentException("Cannot insert null value!");
                this.value = value;
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
                BinaryTreeNode<T> other = (BinaryTreeNode<T>)obj;
                return this.CompareTo(other) == 0;
                }

            public int CompareTo (BinaryTreeNode<T> other)
                {
                return this.value.CompareTo(other.value);
                }

            public interface IComparable<T>
                {
                int CompareTo (T other);
                }
            }

        private BinaryTreeNode<T> root;
        private BinaryTreeNode<T> UnbalancedNode;
        private bool flag = false;

        public BinarySearchTree ()
            {
            this.root = null;
            }

        public void Insert (T value)
            {
            this.root = Insert(value , null , root);
            }

        private BinaryTreeNode<T> Insert (T value , BinaryTreeNode<T> parentNode , BinaryTreeNode<T> node)
            {
            if (node == null)
                {
                node = new BinaryTreeNode<T>(value);
                node.parent = parentNode;
                }
            else
                {
                int compareTo = value.CompareTo(node.value);


                if (compareTo < 0)
                    {
                    node.LeftChild = Insert(value , node , node.LeftChild);

                    if (ImBalance(node))       // Если есть разбаланс
                        {
                        if (value.CompareTo(node.LeftChild.value)<0)
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
                        if (value.CompareTo(node.RightChild.value) > 0)
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

        private void RightTurn (BinaryTreeNode<T> A , BinaryTreeNode<T> B)
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

        private void LeftTurn (BinaryTreeNode<T> A , BinaryTreeNode<T> B)
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

        private void LeftRightTurn (BinaryTreeNode<T> A , BinaryTreeNode<T> B , BinaryTreeNode<T> C)
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

        private void RightLeftTurn (BinaryTreeNode<T> A , BinaryTreeNode<T> B , BinaryTreeNode<T> C)
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

        private bool ImBalance (BinaryTreeNode<T> node)
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

        private int GetHeight (BinaryTreeNode<T> node)
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
                        if (node.LeftChild != null)
                    height += GetHeight(node.LeftChild);

                return height;
                }
            }

        private BinaryTreeNode<T> Find (T value)
            {
            BinaryTreeNode<T> node = this.root;
            while (node != null)
                {
                int compareTo = value.CompareTo(node.value);
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

        public bool Contains (T value)
            {
            bool found = this.Find(value) != null;
            return found;
            }

        public void Remove (T value)
            {
            BinaryTreeNode<T> nodeToDelete = Find(value);
            if (nodeToDelete != null)
                {
                Remove(nodeToDelete);
                }
            }

        private void Remove (BinaryTreeNode<T> node)
            {
            if (node.LeftChild != null && node.RightChild != null)
                {
                BinaryTreeNode<T> replacement = node.RightChild;
                while (replacement.LeftChild != null)
                    {
                    replacement = replacement.LeftChild;
                    }
                node.value = replacement.value;
                node = replacement;
                }


            BinaryTreeNode<T> theChild = node.LeftChild != null ? node.LeftChild : node.RightChild;
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

            BinaryTreeNode<T> UnbNode = FindUnbalancedNode();
            if(UnbNode != null)
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
                }

            }

        private BinaryTreeNode<T> FindUnbalancedNode ()
            {
            UnbalancedNode = null;
            FinUnNode(root);
            return UnbalancedNode;
            }

        private void FinUnNode (BinaryTreeNode<T> node)
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

        public void PrintInConsole ()
            {
            int Height = GetHeight(root);
            int Width = Convert.ToInt16(Math.Pow(Convert.ToDouble(2) , Convert.ToDouble(GetHeight(root))));
            int i = 1;
            int j;
            string[,] arr = new string[Height,Width];
            Queue<BinaryTreeNode<T>> quene = new Queue<BinaryTreeNode<T>>();
            Queue<int> indexOfParents = new Queue<int>();
            arr[0 , Width / 2] = root.value.ToString();
            quene.Enqueue(root);
            indexOfParents.Enqueue(Width / 2);
            while (i < Height)
                {
                int count = quene.Count;
                for (int k = count ; k > 0 ; k--)
                    {
                    BinaryTreeNode<T> parent = quene.Dequeue();
                    int prevInd = indexOfParents.Dequeue();
                    if (parent.LeftChild != null)
                        {
                        arr[i , prevInd- Convert.ToInt16(Math.Pow(Convert.ToDouble(2) , Convert.ToDouble(Math.Abs(i-Height+ 1))))] = parent.LeftChild.ToString();
                        quene.Enqueue(parent.LeftChild);
                        indexOfParents.Enqueue(prevInd - Convert.ToInt16(Math.Pow(Convert.ToDouble(2) , Convert.ToDouble(Math.Abs(i - Height + 1)))));
                        }
                    if (parent.RightChild != null)
                        {
                        arr[i , prevInd + Convert.ToInt16(Math.Pow(Convert.ToDouble(2) , Convert.ToDouble(Math.Abs(i - Height + 1))))] = parent.RightChild.ToString();
                        quene.Enqueue(parent.RightChild);
                        indexOfParents.Enqueue(prevInd + Convert.ToInt16(Math.Pow(Convert.ToDouble(2) , Convert.ToDouble(Math.Abs(i - Height + 1)))));
                        }
                    }
                i++;
                }
            
            for (int h = 0 ; h < Height ; h++)
                {
                for (int w = 0 ; w < Width ; w++)
                    if (arr[h , w] == null)
                        Console.Write(" ");
                    else
                        Console.Write(arr[h , w]);
                Console.WriteLine();
                }
            Console.WriteLine("-------------------------------------------------");
            Console.ReadKey();
            }

        }

    class Program
        {
        static void Main (string[] args)
            {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            for (int i = 1 ; i < 1000 ; i++)
                {
                tree.Insert(i);
                tree.PrintInConsole();
                }
            
            tree.Remove(4);
            tree.PrintInConsole();
            tree.Remove(8);
            tree.PrintInConsole();
            tree.Remove(10);
            tree.PrintInConsole();

            }
        }
    }
