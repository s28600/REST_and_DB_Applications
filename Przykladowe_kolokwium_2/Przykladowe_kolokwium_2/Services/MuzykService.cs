using Microsoft.EntityFrameworkCore;
using Przykladowe_kolokwium_2.Context;
using Przykladowe_kolokwium_2.Entities;
using Przykladowe_kolokwium_2.Models;

namespace Przykladowe_kolokwium_2.Services;

public class MuzykService : IMuzykService
{
    private readonly LabelDbContext _labelDbContext;

    public MuzykService(LabelDbContext labelDbContext)
    {
        _labelDbContext = labelDbContext;
    }

    public ResponseModel GetMuzyk(int id)
    {
        Muzyk? muzyk =  _labelDbContext.Muzycy.FindAsync(id).Result;
        MuzykResponseModel muzykResponseModel = new MuzykResponseModel(muzyk.Imie, muzyk.Nazwisko, muzyk.Pseudonim);
        var utwory = _labelDbContext.Utwory.Where(utwor => 
            _labelDbContext.Wykonawcy.Where(wykonawca => wykonawca.IdMuzyk == id)
                .Select(e => e.IdUtwor)
                .ToList()
                .Contains(utwor.IdUtwor))
            .Select(e => new {e.NazwaUtworu, e.CzasTrwania})
            .ToList();
        return new ResponseModel(muzykResponseModel, utwory);
    }
}