namespace MatrixCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix one = MatrixLoader.ReadMatrix("1.txt");
            Matrix two = MatrixLoader.ReadMatrix("2.txt");
            Matrix res = Matrix.Multyply(one, two);
            Console.WriteLine($"{one}*\n{two}=\n{res}");
            MatrixLoader.SaveMatrix(res, "/res.txt");
        }
    }
}