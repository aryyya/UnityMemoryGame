using System.Collections.Generic;

public class Utility
{
    private static System.Random _random = new System.Random();

    public static void Shuffle(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = _random.Next(0, list.Count - 1);
            int currentElement = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = currentElement;
        }
    }

    public static string ToString(List<int> list)
    {
        string output = "{ ";
        for (int i = 0; i < list.Count; i++)
        {
            output += list[i].ToString();
            if (i < list.Count - 1)
            {
                output += ", ";
            }
        }
        return output + " }";
    }

    public static string GetNameWithSpace(string name)
    {
        string nameWithSpace = "";
        for (int i = 0; i < name.Length; i++)
        {
            char character = name[i];
            if (char.IsUpper(character) && i != 0)
            {
                nameWithSpace += " ";
            }
            nameWithSpace += character;
        }
        return nameWithSpace;
    }
}
