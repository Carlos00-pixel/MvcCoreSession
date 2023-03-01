using MvcCoreSession.Helpers;

namespace MvcCoreSession.Extensions
{
    public static class SessionExtension
    {
        //QUEREMOS UN METODO GetObject<T>(KEY)
        public static T GetObject<T>(this ISession session, string key)
        {
            //QUEREMOS RECUPERAR DATOS DE LA SESSION
            //MEDIANTE UN KEY
            string json = session.GetString(key);
            
            if(json == null)
            {
                //CUANDO UTILIZAMOS GENERICOS, NO PODEMOS DEVOLVER NULL
                return default(T);
            }
            else
            {
                T data = 
                    HelperJsonSession.DeserializeObject<T>(json);
                return data;
            }
        }

        //QUEREMOS UN METODO SetObject<T>(KEY, OBJETO)
        public static void SetObject
            (this ISession session, string key, object value)
        {
            //TENEMOS QUE PASAR A JSON STRING EL OBJECT value
            string data =
                HelperJsonSession.SerializeObject(value);
            //ALMACENAMOS EL JSON EN SESSION
            session.SetString(key, data);
        }
    }
}
