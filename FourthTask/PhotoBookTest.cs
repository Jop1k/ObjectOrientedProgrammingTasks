namespace Task4PhotoBook;

internal static class PhotoBookTest
{
    public static void RunTest()
    {
        Console.WriteLine(new PhotoBook().NumPages);
        Console.WriteLine(new PhotoBook(24).NumPages);
        Console.WriteLine(new BigPhotoBook().NumPages);
    }
}
