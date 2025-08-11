namespace Task4PhotoBook;

internal class PhotoBook
{
    public int NumPages { get; protected set; }

    public PhotoBook(int numPages = 16) => NumPages = numPages;
}
