using BlazorCRUD.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Data.Dapper.Repositorios
{
    public interface IFilmRepository
    {
        //definir metodos(insert,update,delete)
        Task<IEnumerable<Film>> GetAllFilms();//mostrar todos
        Task<Film> GetFilmDetails(int id);//mostrar uno en especifico
        Task<bool> InsertFilm(Film film);

        Task<bool> UpdateFilm(Film film);

        Task<bool> DeleteFilm(int id);
    }
}
