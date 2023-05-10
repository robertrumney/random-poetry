using UnityEngine;
using System.Collections.Generic;

public class PoetryGenerator : MonoBehaviour 
{
    public List<string> adjectives = new List<string>() { "mysterious", "serene", "vibrant", "wistful", "gloomy", "melancholic", "dazzling", "serendipitous", "enchanting", "ethereal", "harmonious", "futuristic", "mesmerizing", "radiant", "peaceful", "whimsical", "blissful", "resplendent", "majestic", "ephemeral", "ethereal", "nostalgic", "evocative", "dreamlike", "scintillating", "sparkling", "tranquil", "mystical", "fantastical", "hazy", "heavenly" };
    public List<string> nouns = new List<string>() { "moon", "sun", "stars", "ocean", "forest", "mountain", "river", "sky", "flower", "butterfly", "bird", "rain", "snow", "wind", "cloud", "fire", "earth", "light", "darkness", "dream", "fantasy", "illusion", "memory", "reflection", "imagination", "silence", "music", "love", "hope", "fear" };

    private bool useThe;
    private bool useAnd;
    private bool useOr;

    private void Start () 
    {
        GeneratePoetryLine();
    }

    private void GeneratePoetryLine() 
    {
        string poetryLine = "";

        // randomly choose which boolean operators to use
        ChooseBooleanOperators();

        // randomly select an adjective and a noun
        string adjective = adjectives[Random.Range(0, adjectives.Count)];
        string noun = nouns[Random.Range(0, nouns.Count)];

        // apply the boolean operators to create the poetry line
        if (useThe) {
            poetryLine += "The ";
        }

        poetryLine += adjective;

        if (useAnd) {
            poetryLine += " and ";
        } else if (useOr) {
            poetryLine += " or ";
        } else {
            poetryLine += " ";
        }

        if (useThe) {
            poetryLine += "the ";
        }

        poetryLine += noun + ".";

        Debug.Log(poetryLine);
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
