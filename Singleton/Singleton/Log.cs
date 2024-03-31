using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton.Singleton
{
    public class Log
    {

        private readonly static Log _instance = new Log();
        private string _path = "log.txt";
        private Log(){}


        public static Log Instance
        {
            get { return _instance; }
        }

        public void Save(string msg)
        {
            File.AppendAllText(_path, msg+ Environment.NewLine);
        }

    }
}
