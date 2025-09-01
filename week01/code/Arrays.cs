public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Define the results array
        var results = new double[length];

        //Inner loop to populate the results array
        for (var index = 0; index < length; index++)
        {
            //Populate the results array with multiples of the number
            //Add 1 to the index to get the correct multiple
            results[index] = number * (index + 1);
        }

        return results;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Get the count of the list
        var count = data.Count;

        //Handle edge case where amount is 0 or equal to count
        amount = amount % count;

        //get the elements to rotate
        var temp = data.GetRange(count - amount, amount);

        //remove the elements to rotate
        data.RemoveRange(count - amount, amount);

        //Insert the elements at the beginning of the list
        //This will effectively rotate the list to the right
        data.InsertRange(0, temp);
    }
}
