using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _18_Maximum_Path_Sum_I
{
    class Program
    {
        static void Main(string[] args)
        {
            var triangle = new Triangle();
            triangle.LoadTriangle("C:\\Users\\angel\\Documents\\ProjectEuler\\18_Maximum_Path_Sum_I\\triangle.txt");
            Console.WriteLine(triangle.FindMaximumPathSum());
        }
    }

    class Triangle
    {
        private List<List<int>> _triangle = new List<List<int>>();
        private Dictionary<(int, int), int> _memo = new Dictionary<(int, int), int>();

        public void LoadTriangle(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var row = line.Split(' ').Select(int.Parse).ToList();
                _triangle.Add(row);
            }
        }

        public int FindMaximumPathSum()
        {
            return FindMaximumPathSum(0, 0);
        }

        private int FindMaximumPathSum(int row, int col)
        {
            if (row == _triangle.Count - 1)
                return _triangle[row][col];

            if (_memo.ContainsKey((row, col)))
                return _memo[(row, col)];

            int leftPathSum = FindMaximumPathSum(row + 1, col);
            int rightPathSum = FindMaximumPathSum(row + 1, col + 1);

            int maxPathSum = _triangle[row][col] + Math.Max(leftPathSum, rightPathSum);
            _memo[(row, col)] = maxPathSum;

            return maxPathSum;
        }
    }
}