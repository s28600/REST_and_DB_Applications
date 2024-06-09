namespace Przykladowe_kolokwium_2.Entities;

public class Utwor
{
    public int IdUtwor { get; set; }
    public string NazwaUtworu { get; set; }
    public double CzasTrwania { get; set; }
    public int? IdAlbum { get; set; }
    
    public virtual Album Album { get; set; }
    public virtual ICollection<WykonawcaUtworu> Muzycy { get; set; } = new List<WykonawcaUtworu>();
}