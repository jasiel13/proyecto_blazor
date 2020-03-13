

using BlazorCRUD.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;


namespace BlazorCRUD.Data.Dapper.Repositorios
{
    //implementar la interfaz
    public class FilmRepository : IFilmRepository
    {
        //creamos una variable donde recibir la conexion a la bd
        private string ConnectionString;

        //luego creamos un cosntructor que recibe como parametros la cadena de conexion
        public FilmRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        //creamos un metodo para la conexion pero primero instalamos la libreria sql 
        protected SqlConnection dbConnection()
        {
            //devolvemos con un retunr la propiedad connectionstring seteada arriba
            return new SqlConnection(ConnectionString);
        }
        public async Task<bool> DeleteFilm(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM films WHERE id = @id";

            var result = await db.ExecuteAsync(sql.ToString(), new { id = id });

            return result > 0 ;
        }

        public async Task<IEnumerable<Film>> GetAllFilms()
        { //devolver la lista de todos los films
            var db = dbConnection();

            var sql = @"SELECT id,title,director,releasedate FROM films";

            return await db.QueryAsync<Film>(sql.ToString(), new { });
        }

        public async Task<Film> GetFilmDetails(int id)
        {
            //traer los datos correspondientes del film seleccionado y mostrarlos en el input
            var db = dbConnection();

            var sql = @"SELECT id,title,director,releasedate FROM films WHERE id = @id";

            return await db.QueryFirstOrDefaultAsync<Film>(sql.ToString(), new { id = id });
        }

        public async Task<bool> InsertFilm(Film film)
        {
            //ponemos la conexion
            var db = dbConnection();
            //creamos la sentencia sql
            var sql = @"INSERT INTO films (title,director,releasedate)VALUES(@title,@director,@releasedate)";

            //devolver el resultato de manera asincrona
            var result = await db.ExecuteAsync(sql.ToString(),new { film.title,film.director,film.releasedate});

            //el valor que devolvera sera bool si resultado es mayor a cero es true
            return result > 0;
        }

        public async Task<bool> UpdateFilm(Film film)
        {
            var db = dbConnection();

            var sql = @"UPDATE films SET title=@title, director=@director, releasedate=@releasedate WHERE id = @id";

            var result = await db.ExecuteAsync(sql.ToString(), new { film.title, film.director, film.releasedate, film.id});

            return result > 0;
        }
    }
}
