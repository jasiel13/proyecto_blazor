using BlazorCRUD.Model;
using MongoDB.Driver;
// se quito esto using ServiceStack;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;


namespace BlazorCRUD.Data.Dapper.Repositorios
{
    public interface IMongoContext : IDisposable
    {
        void AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        IMongoCollection<T> GetCollection<T>(string name);
    }
    public class FileRepository : BaseRepository<DbFile>, IFileRepository
    {
        public FileRepository(IMongoContext context) : base(context)
        {
        }
    }

    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoContext Context;
        protected IMongoCollection<TEntity> DbSet;

        protected BaseRepository(IMongoContext context)
        {
            Context = context;
        }

        public virtual void Add(TEntity obj)
        {
            ConfigDbSet();
            Context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }

        private void ConfigDbSet()
        {
            DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            ConfigDbSet();
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            ConfigDbSet();
            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public virtual void Update(TEntity obj)
        {
            ConfigDbSet();
            //aqui se tenia getid pero no se reconocia le puse tostring
            Context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", obj.ToString()), obj));
        }

        public virtual void Remove(Guid id)
        {
            ConfigDbSet();
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id)));
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }

    //public class FileRepository : IFileRepository
    //{

    //    //private readonly IMongoCollection<File> _empleados;
    //    protected readonly IMongoCollection<File> DbSet;
    //    //protected readonly Imon _context;
    //    private readonly IMongoDatabase _mongoDatabase;
    //    private MongoClient _mongodbclient;

    //    //
    //    private readonly IFileRepository _FileRepository;

    //    public FileRepository (ArchivosDBMDatabaseSettings settings)
    //    {
    //        var client = new MongoClient(settings.ConnectionString);
    //        var database = client.GetDatabase(settings.DatabaseName);
    //        //_mongoDatabase = client
    //        _mongodbclient = client;
    //        _mongoDatabase = database;
    //        DbSet = _mongoDatabase.GetCollection<File>(typeof(File).Name);
    //        _FileRepository = 
    //    }

    //    public Task<bool> DeleteFile(string id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public async Task<IEnumerable<File>> GetAllFiles()
    //    {
    //        _mongoDatabase.GetCollection<File>("Files");
    //        //_mongoDatabase.ListCollectionNamesAsync();
    //        var all = await FindAsync(Builders<File>.Filter.Empty);
    //        return _mongoDatabase.fin
    //        _files.

    //        List<File> archivos = new List<File>();
    //        File arch1 = new File() { Id = "21515", Data = "data", LastModified = DateTime.Today, Name = "archivo.txt", Size = 156, Type = "XML" };
    //        archivos.Add(arch1);
    //        IEnumerable<File> files = archivos;

    //        //throw new NotImplementedException();

    //        return Convert(new List<File> { archivos };
    //    }

    //    public Task<File> GetFileDetails(string id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<bool> InsertFile(File file)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<bool> UpdateFile(File file)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}