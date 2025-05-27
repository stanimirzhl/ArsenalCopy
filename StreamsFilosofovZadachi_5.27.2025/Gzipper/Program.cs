using System.IO.Compression;

using (FileStream inputStream = new FileStream("../../../text.txt", FileMode.Open, FileAccess.Read))
using (FileStream outputStream = new FileStream("../../../compressedText.txt", FileMode.Create, FileAccess.Write))
using (GZipStream compressor = new GZipStream(outputStream, CompressionMode.Compress))
{
    inputStream.CopyTo(compressor);
}

