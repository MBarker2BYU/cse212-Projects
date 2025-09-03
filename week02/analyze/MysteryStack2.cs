public static class MysteryStack2 {

    /// <summary>
    /// Checks if the input string is a valid float or can be converted to one.
    /// </summary>
    /// <param name="text">The input string to check</param>
    /// <returns>True if the string is a valid float, otherwise false</returns>
    private static bool IsFloat(string text)
    {
        //Try to convert to a float
        return float.TryParse(text, out _);
    }

    // Implement an RPN (Reverse Polish Notation) calculator
    // The input is a string containing space-separated tokens
    // The output is a single float value
    /// <param name="text">The input string to evaluate</param>
    /// <returns>The result of the RPN evaluation</returns>
    public static float Run(string text)
    {
        // Create a stack to hold the float values
        var stack = new Stack<float>();

        // Split the input text into tokens and process each one
        foreach (var item in text.Split(' '))
        {
            // Check if the item is an operator
            if (item == "+" || item == "-" || item == "*" || item == "/")
            {
                // Ensure there are at least two operands in the stack
                if (stack.Count < 2)
                    throw new ApplicationException("Invalid Case 1!");

                // Pop the top operand from the stack
                var op2 = stack.Pop();
                // Pop the next operand from the stack
                var op1 = stack.Pop();

                // Result variable
                float res;

                // Perform the operation based on the operator
                if (item == "+")
                {
                    // Add the two operands
                    res = op1 + op2;
                }
                else if (item == "-")
                {
                    // Subtract the two operands
                    res = op1 - op2;
                }
                else if (item == "*")
                {
                    // Multiply the two operands
                    res = op1 * op2;
                }
                else
                {
                    // Check for division by zero
                    if (op2 == 0)
                        throw new ApplicationException("Invalid Case 2!");

                    // Divide the two operands
                    res = op1 / op2;
                }

                // Push the result back onto the stack
                stack.Push(res);
            }
            // Check if the item is a float
            else if (IsFloat(item))
            {
                // Parse the item as a float and push it onto the stack     
                stack.Push(float.Parse(item));
            }
            // Check if the item is an empty string
            else if (item == "")
            {
            }
            else
            {
                throw new ApplicationException("Invalid Case 3!");
            }
        }

        // Ensure there is exactly one result on the stack
        if (stack.Count != 1)
            throw new ApplicationException("Invalid Case 4!");

        // Return the final result
        return stack.Pop();
    }
}