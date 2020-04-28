
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
    public class DataAccess: IDataAccess
    {
        
        private static DataAccess _instance = null;

        public List<Severity> Severities { get;  }

        public List<Category> Categories { get; }


        public Dictionary <string,Group> Groups {get;}

        private DataAccess()
        {
            Severities = GetSeverities();
 
            Categories = GetCategories();


            Groups = GetGroups();



        }
        private List<Severity> GetSeverities()
        {
            List<Severity> Severities =  new List<Severity> ();
            
            Severities.Add( new Severity {Id = 1,Code="LOW",        Name="Low",     Description= "Low"});
            Severities.Add( new Severity {Id = 1,Code="High",       Name="High",    Description= "High"});
            Severities.Add( new Severity {Id = 1,Code="Very High",  Name="VeryHigh",Description= "Very High"});
            Severities.Add( new Severity {Id = 1,Code="Advise",     Name="Advise",  Description= "Advise"});

            return Severities;

            
            

        }
        
        private List<Category> GetCategories()
        {
            List<Category> Categorys = new List<Category> ();
            Categorys.Add(new Category{Id = 1,Code="Alarm",     Name="Alarm",       Description="Alarm"});
            Categorys.Add(new Category{Id = 1,Code="Warning",   Name="Warning",     Description="Warning"});
            Categorys.Add(new Category{Id = 1,Code="Advise",    Name="Advise",      Description="Advise"});

            return Categorys;

        }


        private Dictionary<string,Group> GetGroups()
        {
            Dictionary<string,Group> Groups =  new Dictionary<string,Group>();

            Groups.Add("Mantenimiento",new Group{Id= 1, Code = "Mantenimiento", Description= "Maintenance"});
            Groups.Add("Operacion",new Group{Id= 1, Code = "Operacion", Description= "Operation"});
            Groups.Add("Instrumentacion",new Group{Id= 1, Code = "Instrumentacion", Description= "Instrumentation"});

            return Groups;
        }

        public static DataAccess Instance
    {
        get 
        {
            // The first call will create the one and only instance.
            if (_instance == null)
            {
                _instance = new DataAccess();
            }

            // Every call afterwards will return the single instance created above.
            return _instance;
        }
    }
    }

}