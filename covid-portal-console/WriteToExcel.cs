using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace covid_portal_console
{
    public class WriteToExcel<T> where T : class
    {
        public List<T> Data { get; set; }

        public WriteToExcel(List<T> data)
        {
            Data = data;
        }

        public string CreateFile(List<T> data)
        {

            StringBuilder sb = new StringBuilder();
            var propList = new List<string>();

            foreach (var item in typeof(T).GetProperties())
            {
                
                propList.Add(item.Name);
            }
            sb.AppendLine(string.Join(",",propList));

            foreach (var item in Data)
            {
                var res = (object)item;
                var propValues = new List<string>();
                foreach (var prop in propList)
                {
                    var propVal = res.GetType().GetProperty(prop).GetValue(res, null);
                    propValues.Add(propVal.ToString());
                }
                
                sb.AppendLine(string.Join(",", propValues));
            }

            var result = sb.ToString();

            using (FileStream file = File.Create("../../../Data/demoFile.csv"))
            {
                Byte[] content = new UTF8Encoding(true).GetBytes(result);
                file.Write(content, 0, content.Length);
            }

            return result;
        }
    }
}
