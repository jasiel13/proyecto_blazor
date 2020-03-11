using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorCRUD.Model
{
    public class Xml_datos
    {
        public Guid uuid { get; set; }
        public DateTime fecha { get; set; }
        public Decimal total { get; set; }
        public string emisor_rfc { get; set; }
        public string emisor_nombre { get; set; }
        public string receptor_rfc { get; set; }
        public string receptor_nombre { get; set; }
        public string serie { get; set; }
        public string folio { get; set; }
        public string efectocomprobante { get; set; }
        public string estadocomprobante { get; set; }
        public DateTime fechacancelacion { get; set; }
        
    }
}

