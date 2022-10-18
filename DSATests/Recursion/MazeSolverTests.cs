using NUnit.Framework;
using System.Drawing;

namespace DSA.Recursion.Tests
{
    [TestFixture()]
    public class MazeSolverTests
    {

        [Test]
        public void Init_SolutionExists_ReturnListOfPathPointsTaken()
        {

            string[] map = new string[]
            {
                "###########",
                "##E     ###",
                "#####S#####"
            };

            MazeSolver mazeSolver = new(map);

            List<Point> output = mazeSolver.Init()!;

            List<Point> expected = new()
            {
                new Point{X=5,Y=2},
                new Point{X=5,Y=1},
                new Point{X=4,Y=1},
                new Point{X=3,Y=1},
                new Point{X=2,Y=1}
            };

            Assert.That(output, Is.EquivalentTo(expected));

        }

        [Test]
        public void Init_NoSolutionExists_ReturnNull()
        {
            string[] map = new string[]
            {
                "### # ##E##",
                "### #     #",
                "##S #######"
            };

            MazeSolver mazeSolver = new(map);

            List<Point> output = mazeSolver.Init()!;

            Assert.That(output, Is.Null);
        }
    }
}
