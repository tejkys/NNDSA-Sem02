using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NNDSA_Sem02
{
    public class SplayTree<K, V> where K : IComparable<K>
    {
        private Node? _root;

        private class Node
        {
            public K Key { get; set; }
            public V Value { get; set; }
            public Node? Parent { get; set; }
            public Node? LeftChild { get; set; }
            public Node? RightChild { get; set; }

            public Node(K key, V value, Node? parent)
            {
                Key = key;
                Value = value;
                Parent = parent;
                LeftChild = null;
                RightChild = null;
            }

            public int GetHeight()
            {
                int height = 0;
                var tmp = this.Parent;
                while (tmp is not null)
                {
                    height++;
                    tmp = tmp.Parent;
                }

                return height;
            }
        }
        
        public int GetHeight()
        {
            return GetHeight(_root);
        }

        private class GraphicsTree
        {
            private SplayTree<K, V> _tree;

            private const int NodeRadius = 15;
            private Bitmap _bmp;
            private Graphics _graphics;
            private readonly Pen _nodePen = new Pen(Color.Green, 3);
            private readonly Pen _connectionPen = new Pen(Color.Black, 2);
            private readonly Font _font = new Font("Arial", 10);
            private readonly SolidBrush _fontBrush = new SolidBrush(Color.Black);

            private int TreeHeight => _tree.GetHeight();
            private int TotalWidth => Math.Min((int)Math.Pow(2, TreeHeight) * NodeRadius, 8182);

            public GraphicsTree(SplayTree<K, V> tree)
            {
                _tree = tree;
                _bmp = new Bitmap(TotalWidth+NodeRadius*2, (1+TreeHeight)*NodeRadius*2, PixelFormat.Format32bppArgb);
                _graphics = Graphics.FromImage(_bmp);
            }

            public Bitmap GetImage()
            {
                if (_tree._root == null) return new Bitmap(1920, 1080);
                var stack = new Stack<Node>();
                var current = _tree._root;

                Dictionary<Node, Point> points = new();

                points.Add(current, CalculatePoint(current, new Point(0, 0)));
                DrawPoint(points[current].X, points[current].Y, current.Key.ToString());
                while (current != null || stack.Count > 0)
                {
                    while (current != null)
                    {
                        if (current.LeftChild is not null && !points.ContainsKey(current.LeftChild))
                        {
                            var childPoint = CalculatePoint(current.LeftChild, points[current]);
                            points.Add(current.LeftChild, childPoint);
                        }
                        stack.Push(current);
                        current = current.LeftChild;
                    }
                    current = stack.Pop();
                    if (current.LeftChild is not null)
                    {
                        Point childPoint;
                        if (!points.ContainsKey(current.LeftChild))
                        {
                            childPoint = CalculatePoint(current.LeftChild, points[current]);
                            points.Add(current.LeftChild, childPoint);
                        }
                        else
                        {
                            childPoint = points[current.LeftChild];
                        }

                        DrawConnection(points[current], childPoint);
                        DrawPoint(childPoint.X, childPoint.Y, current.LeftChild.Key.ToString());
                    }

                    if (current.RightChild is not null)
                    {
                        Point childPoint;
                        if (!points.ContainsKey(current.RightChild))
                        {
                            childPoint = CalculatePoint(current.RightChild, points[current]);
                            points.Add(current.RightChild, childPoint);
                        }
                        else
                        {
                            childPoint = points[current.RightChild];
                        }
                        
                        DrawConnection(points[current], childPoint);
                        DrawPoint(childPoint.X, childPoint.Y, current.RightChild.Key.ToString());
                    }

                    current = current.RightChild;
                }


                return _bmp;
            }

            private void DrawPoint(int x, int y, string name)
            {
                _graphics.DrawEllipse(_nodePen, x - NodeRadius, y - NodeRadius, NodeRadius * 2, NodeRadius * 2);
                _graphics.DrawString(name, _font, _fontBrush, x+ NodeRadius, y+NodeRadius);

            }

            private void DrawConnection(Point a, Point b)
            {
                _graphics.DrawLine(_connectionPen, a, b);
            }

            private Point CalculatePoint(Node node, Point previous)
            {
                var height = node.GetHeight();
                var parent = node.Parent;
                var isRoot = _tree._root == node;
                var left = isRoot ? false : parent.LeftChild == node;
                var test = TreeHeight;
                var test2 = TotalWidth;
                return new Point(left ? previous.X - TotalWidth / (int)Math.Pow(2, height+1) : previous.X + TotalWidth / (int)Math.Pow(2, height+1), previous.Y + NodeRadius * 2);
            }

        }
        public void Clear() { 
            _root = null;
        }
        public Bitmap GetImage()
        {
            var graphicsTree = new GraphicsTree(this);

            return graphicsTree.GetImage();
        }
        //public void Insert(K key, V value)
        //{
        //    if (_root == null)
        //    {
        //        _root = new Node(key, value, null);
        //        return;
        //    }

        //    var current = _root;
        //    Node? parent = null;
        //    while (current != null)
        //    {
        //        parent = current;
        //        if (key.CompareTo(current.Key) < 0)
        //        {
        //            current = current.LeftChild;
        //        }
        //        else
        //        {
        //            current = current.RightChild;
        //        }
        //    }

        //    Node newNode = new(key, value, null);
        //    newNode.Parent = parent;
        //    if (key.CompareTo(parent.Key) < 0)
        //    {
        //        parent.LeftChild = newNode;
        //    }
        //    else
        //    {
        //        parent.RightChild = newNode;
        //    }

        //    Splay(newNode);
        //}
        public void Insert(K key, V value)
        {
            if (_root == null)
            {
                _root = new Node(key, value, null);
                return;
            }

            var closestNode = FindClosestNode(key);
            Splay(closestNode);
            var newNode = new Node(key, value, null);
            if (key.CompareTo(closestNode.Key) < 0)
            {
                newNode.LeftChild = closestNode.LeftChild;
                if (closestNode.LeftChild != null)
                {
                    closestNode.LeftChild.Parent = newNode;
                }
                newNode.RightChild = closestNode;
                closestNode.LeftChild = null;
                closestNode.Parent = newNode;
            }
            else
            {
                newNode.RightChild = closestNode.RightChild;
                if (closestNode.RightChild != null)
                {
                    closestNode.RightChild.Parent = newNode;
                }
                newNode.LeftChild = closestNode;
                closestNode.RightChild = null;
                closestNode.Parent = newNode;
            }

            _root = newNode;
        }

        public V? Find(K key)
        {
            var node = FindNode(key);
            if (node != null)
            {
                Splay(node);
                return node.Value;
            }
            return default(V?);
        }

        private Node? FindNode(K key)
        {
            Node? current = _root;
            while (current != null)
            {
                int cmp = key.CompareTo(current.Key);
                if (cmp == 0)
                {
                    return current;
                }
                else if (cmp < 0)
                {
                    current = current.LeftChild;
                }
                else
                {
                    current = current.RightChild;
                }
            }
            return null;
        }
        private Node? FindClosestNode(K key)
        {
            var current = _root;
            Node? closest = null;

            while (current != null)
            {
                closest = current;
                if (key.CompareTo(current.Key) ==0)
                {
                    break;
                }
                else if (key.CompareTo(current.Key) < 0)
                {
                    current = current.LeftChild;
                }
                else
                {
                    current = current.RightChild;
                }
            }

            return closest;
        }
        public void Delete(K key)
        {
            var node = FindNode(key);
            if (node == null) return;
            Splay(node);
            var rootLeft = _root.LeftChild;
            if(rootLeft is not null)
                rootLeft.Parent = null;
            var rootRight = _root.RightChild;
            if (rootRight is not null)
                rootRight.Parent = null;
            
            var leftMax = rootLeft;
            while (leftMax?.RightChild != null)
            {
                leftMax = leftMax.RightChild;
            }

            if (leftMax != null)
            {
                _root = rootLeft;
                Splay(leftMax);
                _root.RightChild = rootRight;
                if (rootRight is not null)
                    rootRight.Parent = _root;
            }
            else
            {
                _root = rootRight;
            }

        }

        public List<V> GetInorderList()
        {
            Stack<Node> stack = new();
            List<V> result = new();
            Node? tmp = _root;

            while (stack.Count > 0 || tmp != null)
            {
                if (tmp != null)
                {
                    stack.Push(tmp);
                    tmp = tmp.LeftChild;
                }
                else
                {   
                    tmp = stack.Pop();
                    result.Add(tmp.Value);

                    tmp = tmp.RightChild;
                }
            }
            return result;
        }
        private void Splay(Node node)
        {
            while (node.Parent != null)
            {
                var parent = node.Parent;
                var grandparent = parent.Parent;

                if (grandparent == null)
                {
                    if (node == parent.LeftChild)
                    {
                        RotateRight(parent);
                    }
                    else
                    {
                        RotateLeft(parent);
                    }
                }
                else if (node == parent.LeftChild && parent == grandparent.LeftChild)
                {
                    RotateRight(grandparent);
                    RotateRight(parent);
                }
                else if (node == parent.RightChild && parent == grandparent.RightChild)
                {
                    RotateLeft(grandparent);
                    RotateLeft(parent);
                }
                else if (node == parent.RightChild && parent == grandparent.LeftChild)
                {
                    RotateLeft(parent);
                    RotateRight(grandparent);
                }
                else
                {
                    RotateRight(parent);
                    RotateLeft(grandparent);
                }
            }
        }

        private void RotateLeft(Node node)
        {
            var right = node.RightChild;
            node.RightChild = right.LeftChild;
            if (right.LeftChild != null)
            {
                right.LeftChild.Parent = node;
            }
            right.Parent = node.Parent;
            if (node.Parent == null)
            {
                _root = right;
            }
            else if (node == node.Parent.LeftChild)
            {
                node.Parent.LeftChild = right;
            }
            else
            {
                node.Parent.RightChild = right;
            }
            right.LeftChild = node;
            node.Parent = right;
        }

        private void RotateRight(Node node)
        {
            var left = node.LeftChild;
            node.LeftChild = left.RightChild;
            if (left.RightChild != null)
            {
                left.RightChild.Parent = node;
            }
            left.Parent = node.Parent;
            if (node.Parent == null)
            {
                _root = left;
            }
            else if (node == node.Parent.RightChild)
            {
                node.Parent.RightChild = left;
            }
            else
            {
                node.Parent.LeftChild = left;
            }
            left.RightChild = node;
            node.Parent = left;
        }
        private int GetHeight(Node? node)
        {
            if (node == null)
                return 0;

            return Math.Max(GetHeight(node.LeftChild), GetHeight(node.RightChild)) + 1;
        }
    }
}