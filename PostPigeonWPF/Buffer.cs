using System.Collections.Generic;
using DBConnect;

namespace PostPigeonWPF
{
    public static class Buffer
    {
        public static List<Template> GetData()
        {
            var db = new ConnectDB();
            db.OpenDB();
            var sql = "SELECT name, annotation FROM table_template";
            var result = db.SelectQuery(sql);
            
            var res = new List<Template>();

            while (result.Read())
            {
                var temp = new Template()
                {
                    Name = result.GetString("name"),
                    Annotation = result.GetString("annotation")
                };
                res.Add(temp);
            }
            
            return res;
        }

        public static List<string> GetName()
        {
            var listName = new List<string>();
            
            var temp = GetData();
            foreach (var item in temp)
            {
                listName.Add(item.Name);
            }

            return listName;
        }
    }
}