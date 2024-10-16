namespace _18_Maximum_Path_Sum_I
{
    class Program
    {
        static void Main()
        {
            var triangle = new Triangle();
            triangle.LoadTriangle("C:\\Users\\angel\\Documents\\ProjectEuler\\18_Maximum_Path_Sum_I\\triangle.txt");
            Console.WriteLine(triangle.FindMaximumPathSum());
        }
    }

    class Triangle
    {
        private List<List<int>> _triangle = new();
        private Dictionary<(int, int), int> _memo = new();

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

        private int FindMaximumPathSum(int row, int col) //recursion my beloved <3
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