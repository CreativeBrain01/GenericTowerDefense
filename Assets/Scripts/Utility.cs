using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility
{
    public static double Exponent(double leftVal, int rightVal)
    {
        if (rightVal == 0) return 1;
        if (rightVal == 1) return leftVal;
        if (rightVal == -1) return 1 / leftVal;

        double result = leftVal;
        if (rightVal >= 2)
        {
            for (int i = 1; i < rightVal; i++)
            {
                result *= leftVal;
            }
        }
        else if (rightVal <= -2)
        {
            for (int i = -1; i > rightVal; i--)
            {
                result *= leftVal;
            }
            result = 1 / result;
        }

        return result;
    }

    public static int multipleRounding(int numToRound, int multiple)
    {
        if (multiple == 0)
            return numToRound;

        int remainder = Mathf.Abs(numToRound) % multiple;
        if (remainder == 0)
            return numToRound;

        if (numToRound < 0)
            return -(Mathf.Abs(numToRound) - remainder);
        else
            return numToRound + multiple - remainder;
    }
}
