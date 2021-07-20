
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineStorage
{
    public class FileIOservise
    {
        private readonly string PATH;
        public FileIOservise(string path)
        {
            PATH = path;
        }
        public BindingList<Medicine> Load()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<Medicine>();
            }
            using (var rider = File.OpenText(PATH))
            {
                var fileText = rider.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Medicine>>(fileText);
            }
        }
        public void SaveData(object medicineData)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(medicineData);
                writer.Write(output);
            }

        }
    }
}
