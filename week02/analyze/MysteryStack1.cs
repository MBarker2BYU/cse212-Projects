public static class MysteryStack1 {

    /// <summary>
    /// Reverses the input string using a stack
    /// </summary>
    /// <param name="text">The input string to reverse</param>
    /// <returns>The reversed string</returns>
    public static string Run(string text)
    {

        // Create a stack to hold the characters
        var stack = new Stack<char>();

        // Push each character onto the stack
        foreach (var letter in text)
            stack.Push(letter);

        // Initialize the result string
        var result = "";

        // Pop each character from the stack and append to the result
        while (stack.Count > 0)
            result += stack.Pop();

        // Return the reversed string
        return result;
    }
}