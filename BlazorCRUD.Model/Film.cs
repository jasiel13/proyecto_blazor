using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorCRUD.Model
{
    public class Film
    {
        public int id { get; set; }
        public string title { get; set; }
        public string director { get; set; }
        public DateTime releasedate { get; set; }
    }

    public class DbFile
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //internal InputFile Owner { get; set; }
        private Stream _stream;

        public event EventHandler OnDataRead;

        public DateTime LastModified { get; set; }

        public string Name { get; set; }

        public long Size { get; set; }

        public string Type { get; set; }

        public String Data
        {
            get;
            set;
            //get
            //{
            //    //_stream ??= Owner.OpenFileStream(this);
            //    return _stream;
            //}
            //set
            //{
            //    Data =new srea
            //}
        }

        internal void RaiseOnDataRead()
        {
            OnDataRead?.Invoke(this, null);
        }
    }
}