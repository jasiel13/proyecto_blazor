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

    //public interface IFileRepository
    //{
    //    //definir metodos(insert,update,delete)
    //    Task<IEnumerable<File>> GetAllFiles();//mostrar todos
    //    Task<File> GetFileDetails(string id);//mostrar uno en especifico
    //    Task<bool> InsertFile(File file);

    //    Task<bool> UpdateFile(File file);

    //    Task<bool> DeleteFile(string id);
    //}

    public interface IFileRepository : IRepository<File>
    {
    }

    public interface IEmpleado2Repository : IRepository<Empleados>
    {

    }

    /// <summary>
    /// Repositorio generico
    /// </summary>
    /// <typeparam name="TEntity">Cualquier Objeto</typeparam>
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
    }


}