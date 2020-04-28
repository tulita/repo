

using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Linq;
using System.IO;

using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using AlarmUpload.Model;


namespace AlarmUpload.DataAccess
{
   public   interface IDataAccess
    {
         public List<Category> Categories { get;  }

         public List<Severity> Severities {get;} 

         public Dictionary<string,Group> Groups { get; }
        
    }


}