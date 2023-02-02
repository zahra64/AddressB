
using AddressBook_ConsoleApp.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_ConsoleApp.Services
{
    internal class FileService
    {

        public void Save(string filePath, string content)
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(content);
        }
      

            public string Read(string filePath)
             {
                 try
                 {
                     using var sr = new StreamReader(filePath);
                //return JsonConvert.DeserializeObject<List<IContactPerson>>(sr.ReadToEnd())!;
                 return sr.ReadToEnd();
            }
                 catch { return null!; }
            }

    }
}

/*     internal void Read(string filePath)
     {
         try
         {
             using var sr = new StreamReader(filePath);
             contacts = JsonConvert.DeserializeObject<List<IContactPerson>>(sr.ReadToEnd())!;
         }
         catch { contacts = new List<IContactPerson>(); }
     }*/

/*     private string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";
     private List<IContactPerson> contacts;

     public string FilePath { get; set; } = null!;

     public void ReadFromFile()
     {
         try
         {
             using var sr = new StreamReader(filePath);
             contacts = JsonConvert.DeserializeObject<List<IContactPerson>>(sr.ReadToEnd())!;
         }
         catch { contacts = new List<IContactPerson>(); }
     }


     public void SaveToFile()
     {
         using var sw = new StreamWriter(filePath);
         sw.WriteLine(JsonConvert.SerializeObject(contacts));
     }*/





