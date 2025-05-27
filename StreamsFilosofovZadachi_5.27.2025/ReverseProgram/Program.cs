using (StreamReader reader = new StreamReader("../../../Program.cs"))
{
    using (StreamWriter writer = new StreamWriter("../../../ReverseProgram.txt"))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            for (int i = line.Length - 1; i >= 0; i--)
            {
                writer.Write(line[i]);
                Console.Write(line[i]);
            }
            Console.WriteLine();
        }
    }
}
