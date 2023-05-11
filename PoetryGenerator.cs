using UnityEngine;
using System.Collections.Generic;

public class PoetryGenerator : MonoBehaviour
{
    public List<string> adjectives = new List<string>() { "mysterious", "serene", "vibrant", "wistful", "gloomy", "melancholic", "dazzling", "serendipitous", "enchanting", "ethereal", "harmonious", "futuristic", "mesmerizing", "radiant", "peaceful", "whimsical", "blissful", "resplendent", "majestic", "ephemeral", "ethereal", "nostalgic", "evocative", "dreamlike", "scintillating", "sparkling", "tranquil", "mystical", "fantastical", "hazy", "heavenly" };
    public List<string> nouns = new List<string>() { "moon", "sun", "stars", "ocean", "forest", "mountain", "river", "sky", "flower", "butterfly", "bird", "rain", "snow", "wind", "cloud", "fire", "earth", "light", "darkness", "dream", "fantasy", "illusion", "memory", "reflection", "imagination", "silence", "music", "love", "hope", "fear" };

    private bool useThe;
    private bool useAnd;
    private bool useOr;

    public int lineCount = 5; // Number of lines to generate

    private void Start()
    {
        GeneratePoetryLines();
    }

    private void GeneratePoetryLines()
    {
        string poetryText = "";

        for (int i = 0; i < lineCount; i++)
        {
            if (i > 0)
            {
                // Determine line separation punctuation based on line index
                if (i % 2 == 0)
                {
                    poetryText += ". "; // Full stop
                }
                else
                {
                    poetryText += ", "; // Comma
                }
            }

            // randomly choose which boolean operators to use
            ChooseBooleanOperators();

            // randomly select an adjective and a noun
            string adjective = adjectives[Random.Range(0, adjectives.Count)];
            string noun = nouns[Random.Range(0, nouns.Count)];

            // apply the boolean operators to create the poetry line
            if (useThe)
            {
                poetryText += "The ";
            }

            poetryText += adjective;

            if (useAnd)
            {
                poetryText += " and ";
            }
            else if (useOr)
            {
                poetryText += " or ";
            }
            else
            {
                poetryText += " ";
            }

            if (useThe)
            {
                poetryText += "the ";
            }

            poetryText += noun;
        }

        Debug.Log(poetryText);
    }

    private void ChooseBooleanOperators()
    {
        // randomly choose which boolean operators to use, with different probabilities
        float andChance = Random.Range(0f, 1f);
        float orChance = Random.Range(0f, 1f);

        if (andChance > orChance)
        {
            useAnd = true;
            useOr = false;
        }
        else
        {
            useAnd = false;
            useOr = true;
        }

        useThe = Random.value > 0.5f;
    }

    public void AddAdjective(string adjective)
    {
        // add a new adjective to the list
        adjectives.Add(adjective);
    }

    public void AddNoun(string noun)
    {
        // add a new noun to the list
        nouns.Add(noun);
    }
}
