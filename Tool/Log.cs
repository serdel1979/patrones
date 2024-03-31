namespace Tool
{
    public sealed class Log
    {
        private static Log _Instance = null;

        private string _path;


        private static object _protected = new Object();

        private Log(string path)
        {
            _path = path;
        }


        public static Log GetInstance(string path)
        {

            lock (_protected)
            {
                if (_Instance == null)
                {
                    _Instance = new Log(path);
                }
            }
            return _Instance;
        }



        public void Save(string msg)
        {
            File.AppendAllText(_path, msg);
        }

    }
}
