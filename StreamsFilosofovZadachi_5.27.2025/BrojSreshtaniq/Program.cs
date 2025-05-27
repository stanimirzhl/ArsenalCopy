
Dictionary<string, int> wordsCount = new Dictionary<string, int>();

using (StreamReader reader = new StreamReader("../../../words.txt"))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        wordsCount[line] = 0;
    }
    using (StreamReader reader2 = new StreamReader("../../../text.txt"))
    {
        using (StreamWriter writer = new StreamWriter("../../../result.txt"))
        {
            while ((line = reader2.ReadLine()) != null)
            {
                string[] words = line.Split(new char[] { ' ', '.', ',', '!', '?', ';', ':', '…', '-', '\'', '\"', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    if (wordsCount.ContainsKey(word.ToLower()))
                    {
                        wordsCount[word.ToLower()]++;
                    }
                }
            }
            foreach (KeyValuePair<string, int> kvp in wordsCount.OrderByDescending(kvp => kvp.Value))
            {
                writer.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}