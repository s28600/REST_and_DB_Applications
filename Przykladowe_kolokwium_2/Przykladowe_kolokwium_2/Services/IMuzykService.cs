using Przykladowe_kolokwium_2.Entities;
using Przykladowe_kolokwium_2.Models;

namespace Przykladowe_kolokwium_2.Services;

public interface IMuzykService
{
    public ResponseModel GetMuzyk(int id);
}