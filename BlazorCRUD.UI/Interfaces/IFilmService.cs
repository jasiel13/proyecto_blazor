using BlazorCRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.UI.Interfaces
{
    //metodos para la interface de servicios
    public interface IFilmService
    {
        Task<IEnumerable<Film>> GetAllFilms();
        Task<Film>GetDetails(int id);
        Task<bool> DeleteFilm(int id);
        Task<bool> SaveFilm(Film film);
    }
}
