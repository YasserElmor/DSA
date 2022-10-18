
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
                "###########",
                "##E     ###",
                "#####S#####"
            };

            new MazeSolver(map).Init()?.ForEach(e => { Console.WriteLine(e); });
        }

    }

}