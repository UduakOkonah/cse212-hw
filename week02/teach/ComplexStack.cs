public static class ComplexStack
{
    /// <summary>
    /// Checks if a string contains balanced brackets: (), [], and {}.
    /// Returns true if all brackets are properly matched and nested.
    /// </summary>
    /// <param name="line">The string to validate</param>
    /// <returns>True if balanced, False otherwise</returns>
    public static bool DoSomethingComplicated(string line)
    {
        var stack = new Stack<char>();

        foreach (var item in line)
        {
            if (item == '(' || item == '[' || item == '{')
            {
                stack.Push(item);
            }
            else if (item == ')')
            {
                if (stack.Count == 0 || stack.Pop() != '(')
                    return false;
            }
            else if (item == ']')
            {
                if (stack.Count == 0 || stack.Pop() != '[')
                    return false;
            }
            else if (item == '}')
            {
                if (stack.Count == 0 || stack.Pop() != '{')
                    return false;
            }
        }

        return stack.Count == 0;
    }
}