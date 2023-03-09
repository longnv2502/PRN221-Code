namespace SingleResponsibilityPrincipleDemo01.Model
{
    interface IBook
    {
        string Title { get; set; }
        string Author { get; set; }
        string Price { get; set; }
    }
}