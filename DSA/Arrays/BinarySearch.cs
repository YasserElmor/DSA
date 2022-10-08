namespace Arrays
{
    public static class BinarySearch
    {
        public static int GetIndex(List<int> list, int value, int acc = 0)
        {
            if (list[list.Count - 1] < value || list[0] > value)
                return -1;

            int midIndex = (int)Math.Floor((double)((list.Count - 1) / 2));

            if (list[midIndex] == value)
                return acc + midIndex;

            if (list.Count == 1)
                return -1;

            bool keepRHS = list[midIndex] < value;

            int low = keepRHS ? midIndex + 1 : 0;
            int high = keepRHS ? list.Count : midIndex;

            List<int> halvedList = list.Skip(low).Take(high - low).ToList();

            acc += keepRHS ? list.Count() - halvedList.Count : 0;

            return GetIndex(halvedList, value, acc);
        }
    }
}

