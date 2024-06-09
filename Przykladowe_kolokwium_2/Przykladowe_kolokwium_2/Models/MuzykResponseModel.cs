namespace Przykladowe_kolokwium_2.Models;

public class MuzykResponseModel
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Pseudonim { get; set; }

    public MuzykResponseModel(string imie, string nazwisko, string pseudonim)
    {
        Imie = imie;
        Nazwisko = nazwisko;
        Pseudonim = pseudonim;
    }
}