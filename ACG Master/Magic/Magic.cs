
    using ProtoBuf;
    using System;
    using System.IO;
    using System.Linq;

    public static class Magic
    {
        public static byte[] Serialize(object obj)
        {
            if (obj == null) return null;

            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    Serializer.Serialize(stream, obj);
                    return stream.ToArray();
                }
            }
            catch { }


            return null;
        }

        public static T Deserialize<T>(byte[] data) where T : class
        {
            if (data == null) return null;

            try
            {
                using (MemoryStream stream = new MemoryStream(data))
                {
                    return Serializer.Deserialize<T>(stream);
                }
            }
            catch { }

            return null;
        }
    }




