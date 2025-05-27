using (StreamReader reader = new StreamReader("../../../text.txt"))
{
    string line;
    int lineNumber = 0;
    while ((line = reader.ReadLine()) != null)
    {
        if (lineNumber % 2 != 0)
        {
            Console.WriteLine(line);
        }
        lineNumber++;
    }
}

