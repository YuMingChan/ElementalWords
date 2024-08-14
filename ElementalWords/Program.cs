
namespace ElementalWordFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = "Beach"; // Replace with your desired word

            var elementalWords = new ElementalWords();
            var results = elementalWords.ElementalForms(word);

            foreach (var combination in results)
            {
                foreach (var element in combination)
                {
                    Console.Write($"{element[0]} ({element[1]}) ");
                }
                Console.WriteLine(); // Add a newline after each combination
            }
            Console.Read();
        }
    }
}
