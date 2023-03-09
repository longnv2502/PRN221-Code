// UI Layer
using DIConstructorInjectionPatternDemo;

class Program
{
    static void Main(string[] args)
    {
        BookManager bm;
        Console.WriteLine("Please, select reading type (XML or JSON)");
        var ans = Console.ReadLine();
        if (ans.ToLower() == "xml")
        {
            bm = new BookManager(new XMLBookReader());

        }
        else
        {

            bm = new BookManager(new JSONBookReader());
        }

        bm.ReadBooks();
        Console.ReadLine();
    }
}