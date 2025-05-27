using (StreamReader reader = new StreamReader("../../../Program.cs"))
{
	using (StreamWriter write = new StreamWriter("../../../LineProgram.txt"))
	{
        int lineNumber = 0;
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            lineNumber++;
            string message = $"Line {lineNumber}: {line}";
            Console.WriteLine(message);
            write.WriteLine(message);
        }
    }
}
