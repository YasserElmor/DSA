
using Arrays;
using DSA.Recursion;
using LinkedLists;
using System.Drawing;

namespace EntryPoint
{
    public static class App
    {
        public static void Main()
        {
            string[] map = new string[]
            {
                "###   ##E##",
                "### #     #",
                "##S #######"
            };

            MazeSolver mazeSolver = new(map);



            List<Point>? path = mazeSolver.Init();
            if (path != null)
                foreach (var item in path!)
                {
                    Console.WriteLine(item);
                }
        }

    }

}