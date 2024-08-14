public class ElementalWords
{
    List<string[]> Elements = new List<string[]>
            {
                new [] {"H", "Hydrogen"},
                new [] {"He", "Helium"},
                new [] {"S", "Sulfur"},
                new [] {"N", "Nitrogen"},
                new [] {"Ac", "Actinium"},
                new [] {"K", "Potassium"},
                new [] {"Na", "Sodium"},
                new [] {"C", "Carbon"},
                new [] {"Sn", "Tin"},
                new [] {"Y", "Yttrium"},
                new [] {"Es", "Einsteinium"},
                new [] {"Be", "Beryllium"},
                 
        // ... other element
            };

    public List<List<string[]>> ElementalForms(string word)
    {
        // remove impossible elements
        var checkElements = Elements.Where(e => word.ToLower().Contains(e[0].ToLower())).ToList();
        
        // generate all combinations of elements
        var allCombinations = GetAllCombinations(checkElements, word.Length);

        var result = new List<List<string[]>>();
        foreach (var combination in allCombinations)
        {
            // check the result
            if (string.Concat(combination).ToLower() == word.ToLower())
            {
                result.Add(combination.Select(symbol => Elements.First(e => e[0] == symbol)).ToList());
            }
        }

        return result;
    }
    private static List<List<string>> GetAllCombinations(List<string[]> elements, int wordLength)
    {
        if (wordLength == 0)
        {
            // Base case: empty combination
            return new List<List<string>> { new List<string>() }; 
        }

        var result = new List<List<string>>();

        foreach (var element in elements)
        {
            // Optimization: check length before recursion
            if (element[0].Length <= wordLength) 
            {
                var shorterCombinations = GetAllCombinations(elements, wordLength - element[0].Length);
                foreach (var combination in shorterCombinations)
                {
                    var newCombination = new List<string>(combination) { element[0] };
                    result.Add(newCombination);
                }
            }
        }

        return result;
    }
}
