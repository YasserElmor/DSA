using System.Collections;
using System.Drawing;

namespace DSA.Recursion
{
    public class MazeSolver
    {

        // "###   ##E##"
        // "### #     #"
        // "##S #######" 

        // Starting from S
        // don't go off the map
        // don't hit a wall
        // don't re-visit a location you've been into
        // Find E


        private readonly string[] _map;
        private Point _start;
        public MazeSolver(string[] map)
        {
            _map = map;
            _start = GetStartingPoint(_map);
        }

        public List<Point>? Init()
        {
            return FindPath(_map, new(), _start);
        }

        // TODO: the path finder only follows a single path as visited points can't be revisited
        // TODO: the mechanism of adding points to the path has to be changed to accomodate paths that don't work from the first try
        private static List<Point>? FindPath(string[] map, List<Point> path, Point start)
        {
            path.Add(start);

            List<SuperPoint> nextPointOptions = GetNextPointOptions(map, start, path);
            List<SuperPoint> validOptions = nextPointOptions.Where(e => e.IsAccessible).ToList();

            Point? winner = validOptions.FirstOrDefault(e => e.IsAWinner)?.Point;
            if (winner is not null)
            {
                path.Add((Point)winner);
                return path;
            }

            if (validOptions.Count > 0)
            {
                foreach (var option in validOptions)
                {
                    return FindPath(map, path, option.Point);
                }
            }
            return null;
        }

        private static List<SuperPoint> GetNextPointOptions(string[] map, Point point, List<Point> path)
        {
            SuperPoint up = GetSuperPoint(map, new(point.X, point.Y + 1), path);
            SuperPoint right = GetSuperPoint(map, new(point.X + 1, point.Y), path);
            SuperPoint down = GetSuperPoint(map, new(point.X, point.Y - 1), path);
            SuperPoint left = GetSuperPoint(map, new(point.X - 1, point.Y), path);

            return new() { up, right, down, left };
        }

        private static SuperPoint GetSuperPoint(string[] map, Point point, List<Point> path)
        {
            string? pointRepresentation = GetPointMapRepresentation(map, point.X, point.Y);

            SuperPoint superPoint = new() { Point = point };

            bool offTheMap = pointRepresentation == null;
            bool isAWall = pointRepresentation == "#";
            bool wasVisited = path.Contains(point);
            bool isAWinner = pointRepresentation == "E";

            if (isAWinner)
                superPoint.IsAWinner = true;

            if (!(offTheMap || isAWall || wasVisited))
                superPoint.IsAccessible = true;

            return superPoint;
        }

        private static string? GetPointMapRepresentation(string[] map, int x, int y)
        {
            try
            {
                string pointRepresentation = map[y][x].ToString();

                return pointRepresentation;
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        private static Point GetStartingPoint(string[] map)
        {
            string? startingLine = map.FirstOrDefault(x => x.Contains('S'));

            if (startingLine is null)
                throw new Exception("Invalid Maze, No Starting Point Detected");

            int x = startingLine.IndexOf("S");
            int y = map.ToList().IndexOf(startingLine);

            return new Point(x, y);
        }

        private class SuperPoint
        {
            public Point Point { get; set; }
            public bool IsAccessible { get; set; } = false;
            public bool IsAWinner { get; set; } = false;
        }
    }
}
