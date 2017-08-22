using System;
namespace Data_Structures
{
    public class BST<T> where T : IComparable
    {
        private int NodeCount;
        private Node root;

        private class Node{
            public T data;
            public Node left, right;

            public Node(Node left, Node right, T val){
                this.data = val;
                this.left = left;
                this.right = right;
            }
        }

        // Default constructor
        public BST()
        {
            NodeCount = 0;
            root = null;
        }

        // Overload constructor 
		public BST(T data)
		{
			NodeCount = 1;
            root = new Node(null, null, data);
		}

        public int Size(){
            return NodeCount;
        }

        public bool IsEmpty(){
            return Size() == 0;
        }

        public bool Add(T data){
            if (Contains(data))
                return false;
            else{
                root = Add(root, data);
                NodeCount++;
                return true;
            }
        }

        private Node Add(Node node, T data){
            if(node == null){
                node = new Node(null, null, data);
            } else {
                // Insert lower elements in left subtree
                if(data.CompareTo(node.data) < 0){
                    node.left = Add(node.left, data);
                } else{
                    node.right = Add(node.right, data);
                }
            }
            return node;
        }

        public bool Remove(T data){
            if(Contains(data)){
                root = Remove(root, data);
                NodeCount--;
                return true;
            }
            return false;
        }

        private Node Remove(Node node, T data){
            if (node == null) return null;

            int CompareValue = data.CompareTo(node.data);

            // Explore left subtree
            if (CompareValue < 0)
            {
                node.left = Remove(node.left, data);
            }// Explore right subtree
            else if(CompareValue > 0)
            {
                node.right = Remove(node.right, data);
            } 
            // Target node is found to be current node!
            else {
                // Only right subtree or no subtree at all.
                // Swap victim node with its right child
                if (node.left == null)
                {
                    Node RightChild = node.right;
                    node.data = default(T);
                    node = null;
                    return RightChild;
                } else if(node.right == null){
                    Node LeftChild = node.left;
                    node.data = default(T);
                    node = null;
                    return LeftChild;
                } else {
                    // Find left-most node in right subtree
                    Node temp = MostLeft(node.right);
                    node.data = temp.data;

                    node.right = Remove(node.right, temp.data);
                }
            }
            return node;
        }

        private Node MostLeft(Node node){
            Node Current = node;
            while(Current.left != null){
                Current = Current.left;
            }
            return Current;
        }

        // Return true if BST contains data in param ==
        public bool Contains(T data){
            return Contains(root, data);
        }

        private bool Contains(Node node, T data){
            if (node == null) return false;

            int CompareValue = data.CompareTo(node.data);

            if (CompareValue < 0){
                return Contains(node.left, data);
            } else if(CompareValue > 0){
                return Contains(node.right, data);
            } else {
                return true;
            }
        }
        // =============================================

        // In Order ====================================
        public void PrintInOrder(){
            InOrder(this.root);
        }
		private void InOrder(Node root)
		{
            if (root == null) return;
            InOrder(root.left);
            Console.Write(root.data.ToString() + ", ");
            InOrder(root.right);
		}
		// =============================================
		// Pre Order ====================================
		public void PrintPreOrder()
		{
			PreOrder(this.root);
		}
		private void PreOrder(Node root)
		{
			if (root == null) return;
			Console.Write(root.data.ToString() + ", ");
            InOrder(root.left);
			InOrder(root.right);
		}
		// =============================================
		// Post Order ====================================
		public void PrintPostOrder()
		{
			PostOrder(this.root);
		}
		private void PostOrder(Node root)
		{
			if (root == null) return;
			InOrder(root.left);
            InOrder(root.right);
            Console.Write(root.data.ToString() + ", ");
		}
		// =============================================


		public int Height(){
            return Height(root);
        }

        private int Height(Node node){
            if (node == null) return 0;

            return Math.Max(Height(node.left), Height(node.right)) + 1;
        }




    }
}
