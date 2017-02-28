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
            internal sbyte Balance;
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
                this.Balance = 0;
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
        private bool flag = false;

        public BinarySearchTree ()
            {
            this.root = null;
            }

        public void Insert (T value)
            {
            this.root = Insert(value , null , root);
            }

        private BinaryTreeNode<T> Insert (T value, BinaryTreeNode<T> parentNode, BinaryTreeNode<T> node)
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
                    node.Balance--;
                    if (node.Balance < -1)
                        if (node.LeftChild.LeftChild.LeftChild != null)
                            {
                            if (Equals(node.LeftChild.LeftChild.LeftChild.value , value))
                                RightTurn(node , node.LeftChild);
                            }
                        else
                    if (Equals(node.LeftChild.LeftChild.value , value))                  // LEFT LEFT
                            RightTurn(node , node.LeftChild);
                        else //if (Equals(node.LeftChild.RightChild.LeftChild.value , value) || Equals(node.LeftChild.RightChild.RightChild.value , value))
                            LeftRightTurn(node , node.LeftChild , node.LeftChild.RightChild);
                    }
                else if (compareTo > 0)
                    {
                    node.RightChild = Insert(value , node , node.RightChild);
                    node.Balance++;
                    if (node.Balance > 1)
                        if (node.RightChild.RightChild.RightChild != null)
                            {
                            if (Equals(node.RightChild.RightChild.RightChild.value , value))
                                LeftTurn(node , node.RightChild);
                            }
                        else
                        if (Equals(node.RightChild.RightChild.value , value))               // RIGHT RIGHT
                            LeftTurn(node , node.RightChild);
                        else //if (Equals(node.LeftChild.RightChild.LeftChild.value , value) || Equals(node.LeftChild.RightChild.RightChild.value , value))
                            RightLeftTurn(node , node.RightChild , node.RightChild.LeftChild);
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

        private void RightTurn (BinaryTreeNode<T> A, BinaryTreeNode<T> B)
            {
            A.LeftChild = B.RightChild;
            B.RightChild = A;
            B.Balance = 0;
            A.Balance = 0;

            B.parent = A.parent;
            flag = true;
            if (Equals(root , A))
                {
                A.parent = B;
                }
            else
                {
                A.parent.Balance++;
                A.parent.LeftChild = B;
                A.parent = B;
                }
            }

        private void LeftTurn (BinaryTreeNode<T> A , BinaryTreeNode<T> B)
            {
            
            A.RightChild = B.LeftChild;
            B.LeftChild = A;
            B.Balance = 0;
            A.Balance = 0;
            B.parent = A.parent;
            flag = true;
            if (Equals(root , A))
                { 
                A.parent = B;
                }
            else
                {
                A.parent.Balance--;
                A.parent.RightChild = B;
                A.parent = B;
                }
            }

        private void LeftRightTurn (BinaryTreeNode<T> A , BinaryTreeNode<T> B, BinaryTreeNode<T> C)
            {
            if (C.RightChild == null)
                {
                B.Balance = 0;
                B.RightChild = C.LeftChild;
                }
            else
                A.Balance = 0;

            A.LeftChild = C;
            C.LeftChild = B;
            RightTurn(A , C);
            }

        private void RightLeftTurn (BinaryTreeNode<T> A , BinaryTreeNode<T> B , BinaryTreeNode<T> C)
            {
            if (C.LeftChild == null)
                {
                B.Balance = 0;
                B.LeftChild = C.RightChild;
                }
            else
                A.Balance = 0;

            A.RightChild = C;
            C.RightChild = B;
            LeftTurn(A , C);
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
            if(nodeToDelete != null)
                {
                Remove(nodeToDelete);
                }
            }

        private void Remove (BinaryTreeNode<T> node)
            {
            if (node.LeftChild != null && node.RightChild != null)
                {
                BinaryTreeNode<T> replacement = node.RightChild;
                while(replacement.LeftChild != null)
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
            }

        public void PrintTreeDFS ()
            {
            PrintTreeDFS(this.root);
            Console.WriteLine();
            }

        private void PrintTreeDFS(BinaryTreeNode<T> node)
            {
            if(node != null)
                {
                PrintTreeDFS(node.LeftChild);
                Console.Write(node.value + " ");
                PrintTreeDFS(node.RightChild);
                Console.WriteLine();
                }
            
            }
        }

    class Program
        {
        static void Main (string[] args)
            {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            for (int i = 0 ; i <20 ; i++)
                {
                tree.Insert(i);
                tree.ToString();
                Console.ReadKey();
                }
            

            }
        }
    }
