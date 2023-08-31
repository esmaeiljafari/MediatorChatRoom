using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.infrasturcture
{
    public class ReadConnection
    {

        public static infoConnnection GetConnection
        {
            get
            {
                if (_GetConnection == null)
                {
                    StreamReader reader = new StreamReader("connection.json");
                    string json = reader.ReadToEnd();
                    _GetConnection = System.Text.Json.JsonSerializer.Deserialize<infoConnnection>(json);
                }
                return _GetConnection;
            }
        }

        private static infoConnnection _GetConnection { get; set; }
    }
}
