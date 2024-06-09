using Przykladowe_kolokwium_2.Entities;

namespace Przykladowe_kolokwium_2.Models;

public class ResponseModel
{
    public object Muzyk { get; set; }
    public IEnumerable<object> Utwory { get; set; }

    public ResponseModel(object muzyk, IEnumerable<object> utwory)
    {
        Muzyk = muzyk;
        Utwory = utwory;
    }
}