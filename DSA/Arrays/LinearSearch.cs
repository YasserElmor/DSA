namespace Arrays
{
    public static class LinearSearch
    {
        public static int GetIndex<T>(List<T> list, T value) where T : IEquatable<T>
        {
            int index = -1;
            if (list.Count != 0)
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Equals(value))
                    {
                        return i;
                    }
                }
            return index;
        }
    }
}
