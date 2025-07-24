namespace FourthTask;

internal class PhotoBook
{
    public int NumPages { get; private set; }

    public PhotoBook(int numPages = 16) => NumPages = numPages;
}
