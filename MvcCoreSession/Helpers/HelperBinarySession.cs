using System.Runtime.Serialization.Formatters.Binary;

namespace MvcCoreSession.Helpers
{
    public class HelperBinarySession
    {
        //TENDREMOS DOS METODOS STATIC
        //UNO PARA CONVERTIR OBJECT A BINARY
        public static byte[] ObjectToByte(Object objecto)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, objecto);
                return stream.ToArray();
            }
        }

        //OTRO METODO PARA RECUPERAR UN BINARY A OBJET
        public static Object ByteToObject(byte[] data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Seek(0, SeekOrigin.Begin);
                Object objeto = (Object)formatter.Deserialize(stream);
                return objeto;
            }
        }
    }
}
