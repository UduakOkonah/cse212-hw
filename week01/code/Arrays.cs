public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN:
        // Step 1: Create a new array of doubles with size 'length'
        // Step 2: Use a for loop that goes from 0 to length - 1
        // Step 3: In each iteration, store number * (index + 1) in the array
        // Step 4: Return the filled array

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} rotated by 3 becomes 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN:
        // Step 1: Get the last 'amount' items using GetRange()
        // Step 2: Get the first part of the list (from index 0 to count - amount)
        // Step 3: Clear the original list
        // Step 4: Add the right part first, then the left part

        int count = data.Count;

        List<int> rightPart = data.GetRange(count - amount, amount);
        List<int> leftPart = data.GetRange(0, count - amount);

        data.Clear();
        data.AddRange(rightPart);
        data.AddRange(leftPart);
    }
}
