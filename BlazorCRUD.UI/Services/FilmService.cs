using BlazorCRUD.Data.Dapper.Repositorios;
using BlazorCRUD.Model;
using BlazorCRUD.UI.Data;
using BlazorCRUD.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.UI.Services
{
    public class FilmService : IFilmService
    {
        private readonly SqlConfiguration _configuration;

        //poner la capa de acceso de datos instanciar la interfaz filmrepository
        private IFilmRepository _filmRepository;

        //creamos un cosntructor que traera la configuracionde la conexion a la bd a la capa de acceso de datos
        public FilmService(SqlConfiguration configuration)
        {
            _configuration = configuration;
            _filmRepository = new FilmRepository(configuration.ConnectionString);
        }
        public Task<bool> DeleteFilm(int id)
        {
            return _filmRepository.DeleteFilm(id);
        }

        public Task<IEnumerable<Film>> GetAllFilms()
        {   //mostrar la lista de film
            return _filmRepository.GetAllFilms();
        }

        public Task<Film> GetDetails(int id)
        {   //traer los datos correspondientes a fil correspondiente y mostrarlos en el input
            return _filmRepository.GetFilmDetails(id);
        }

        public Task<bool> SaveFilm(Film film)
        {
            /*guardar los datos insertados en la bd
            si film id es = a 0 insertar los datos y sino que no retorne nada*/
            if (film.id == 0)
            {
                return _filmRepository.InsertFilm(film);
            }
            else
            {
                //aqui se realiza el update de los datos del film
                return _filmRepository.UpdateFilm(film);
            }
        }
    }
}
