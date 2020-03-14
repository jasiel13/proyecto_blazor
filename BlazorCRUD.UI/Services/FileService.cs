using BlazorCRUD.Data.Dapper;
using BlazorCRUD.Data.Dapper.Repositorios;
using BlazorCRUD.Model;
using BlazorCRUD.UI.Data;
using BlazorCRUD.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace BlazorCRUD.UI.Services
{
    public interface IMongoContext : IDisposable
    {
        void AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        IMongoCollection<T> GetCollection<T>(string name);
    }

    public class FileService : IFileService
    {
        //private readonly IFileService fileService;
        protected IMongoCollection<DbFile> DbSet;
        protected readonly IMongoContext Context;

        public FileService(IArchivosDBMDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            DbSet = database.GetCollection<DbFile>(settings.FilesCollectionName);
        }
        private void ConfigDbSet()
        {
            DbSet = Context.GetCollection<DbFile>(typeof(DbFile).Name);
            //Context = Context.GetCollection<DbFile>(typeof(DbFile).Name);
        }

        public Task<bool> DeleteFile(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DbFile>> GetAllFiles()
        {
            //var all = fileService.GetAllFiles();
            var all = await DbSet.FindAsync(Builders<DbFile>.Filter.Empty);
            return all.ToList();
            //throw new NotImplementedException();
        }

        public Task<DbFile> GetDetails(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveFile(DbFile file)
        {
            var insert = DbSet.InsertOneAsync(file);
            return null;
            //AddCommand(() => DbSet.InsertOneAsync(obj));

        }
    }


    //public class FileService : IFileService
    //{
    //    private readonly IMongoCollection<File> _files;

    //    //poner la capa de acceso de datos instanciar la interfaz filmrepository
    //    private IFileRepository _fileRepository;

    //    //creamos un cosntructor que traera la configuracionde la conexion a la bd a la capa de acceso de datos
    //    public FileService(IArchivosDBMDatabaseSettings settings)
    //    {
    //        var client = new MongoClient(settings.ConnectionString);
    //        var database = client.GetDatabase(settings.DatabaseName);

    //        _files = database.GetCollection<File>(settings.FilesCollectionName);
    //    }
    //    public Task<bool> DeleteFile(string id)
    //    {
    //        return _fileRepository.DeleteFile(id);
    //    }

    //    public Task<IEnumerable<File>> GetAllFiles()
    //    {   //mostrar la lista de film
    //        //oiber 
    //        List<File> archivos = new List<File>();
    //        File arch1 = new File() { Id = "21515", Data = "data", LastModified = DateTime.Today, Name = "archivo.txt", Size = 156, Type = "XML" };
    //        archivos.Add(arch1);
    //        IEnumerable<File> files = archivos;

    //        //return archivos; 
    //        return _fileRepository.GetAllFiles();
    //    }

    //    public Task<File> GetDetails(string id)
    //    {   //traer los datos correspondientes a fil correspondiente y mostrarlos en el input
    //        return _fileRepository.GetFileDetails(id);
    //    }

    //    public Task<bool> SaveFile(File file)
    //    {
    //        /*guardar los datos insertados en la bd
    //        si film id es = a 0 insertar los datos y sino que no retorne nada*/
    //        if (file.Id == "0")
    //        {
    //            return _fileRepository.InsertFile(file);
    //        }
    //        else
    //        {
    //            //aqui se realiza el update de los datos del film
    //            return _fileRepository.UpdateFile(file);
    //        }
    //    }
    //}


}