using Lab7_c;
using static Lab7_c.BibliotekExtensions;
using static System.Formats.Asn1.AsnWriter;

internal class Program
{
    private static void Main(string[] args)
    {
        Buch b1 = new Buch("The Bible", "Many people", 850, 1);
        Buch b2 = new Buch("Harry Potter", "J.K. Rowling", 9000, 2);
        Buch b3 = new Buch("The Lord of the Rings", "J.R.R. Tolkien", 15032, 3); ;
        Buch b4 = new Buch("The Da Vince Code", "Dan Brown", 2304, 4);
        Buch b5 = new Buch("The City of Ember", "DuPrau", 5000, 5);
        Console.WriteLine(b1);

        Bibliotek bibliotek = new Bibliotek();
        bibliotek.AddBuch(b1);
        bibliotek.AddBuch(b2);
        bibliotek.AddBuch(b3);
        bibliotek.AddBuch(b4);
        bibliotek.AddBuch(b5);
        Console.WriteLine(bibliotek);
        Console.WriteLine("---------------------");
        //bibliotek.RemoveBuch(1);
        //bibliotek.RemoveBuch(3);
        
        Console.WriteLine(bibliotek);

        string fileNameJSON = "Bücher.json";
        string fileNameBinary = "Bücher.bin";

        FileManager.SerializationJSON(bibliotek, fileNameJSON);
        FileManager.SerializationBinary(bibliotek, fileNameBinary);



        Bibliotek bibliotek2 = FileManager.DeserializationJSON(fileNameJSON);
        Console.WriteLine("Read from JSON\n--------------------------------------------------\n");
        Console.WriteLine(bibliotek2);


        Bibliotek bibliotek3 = FileManager.DeserializationBinary(fileNameBinary);
        Console.WriteLine("Read from Binary\n--------------------------------------------------\n");
        Console.WriteLine(bibliotek3);

        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine(BibliotekSorter.FilterByMinPages(bibliotek,3400));

    }
}