using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public static class Randomizer
{
    private static Random random = new Random();

    public static int GetRandom(int from, int to)
    {
        return random.Next(from, to);
    }
}
