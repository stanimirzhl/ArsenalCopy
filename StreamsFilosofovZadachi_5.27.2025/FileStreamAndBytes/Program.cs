using (FileStream sourceStream = new FileStream("../../../Телевизионно предаване.docx", FileMode.Open, FileAccess.Read))
using (FileStream destinationStream = new FileStream("../../../Телевизионна предаване-Copy.docx", FileMode.Create, FileAccess.Write))
{
    byte[] buffer = new byte[4096];
    int bytesRead;

    while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
    {
        destinationStream.Write(buffer, 0, bytesRead);
    }
}
