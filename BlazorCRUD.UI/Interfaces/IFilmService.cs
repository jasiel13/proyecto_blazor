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
        Task<Film> GetDetails(int id);
        Task<bool> DeleteFilm(int id);
        Task<bool> SaveFilm(Film film);
    }

    public interface IFileService
    {
        Task<IEnumerable<DbFile>> GetAllFiles();
        Task<DbFile> GetDetails(string id);
        Task<bool> DeleteFile(string id);
        Task<bool> SaveFile(DbFile film);
    }

}