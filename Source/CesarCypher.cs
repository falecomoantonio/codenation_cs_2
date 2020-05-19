using System;
using System.Text;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        public static int SEED = 3;

        public string Crypt(string message)
        {
            if (message == null)
                throw new ArgumentNullException(message);

            if (message == string.Empty)
                return string.Empty;

            string tmpStr = message.ToLower();
            char[] phrase = tmpStr.ToCharArray();

            int MIN = 97, // A
                MAX = 122; // Z
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < tmpStr.Length; i++)
            {
                int currentElem = (int)phrase[i];
                if (currentElem >= MIN && currentElem <= MAX)
                {
                    int value = currentElem + SEED;

                    if (value > MAX)
                    {
                        value = MIN + (value - MAX) - 1;
                    }

                    sb.Append((char)value);
                }
                else if (currentElem == 32 || (currentElem >= 48 && currentElem <= 57))
                {
                    // Não é caractere de A a Z
                    sb.Append((char)currentElem);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }

            }

            return sb.ToString();
        }

        public string Decrypt(string cryptedMessage) 
        {
            if (cryptedMessage == null)
                throw new ArgumentNullException(cryptedMessage);

            if (cryptedMessage == string.Empty)
                return string.Empty;

            string tmpStr = cryptedMessage.ToLower();
            char[] phrase = tmpStr.ToCharArray();

            int MIN = 97, // A
                MAX = 122; // Z

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < tmpStr.Length; i++)
            {
                int currentElem = (int)phrase[i];
                if (currentElem >= MIN && currentElem <= MAX)
                {
                    int value = currentElem - SEED;

                    if (value < MIN)
                    {
                        value = MAX - (MIN - value) + 1;
                    }

                    sb.Append((char)value);
                }
                else if (currentElem == 32 || (currentElem >= 48 && currentElem <= 57))
                {
                    // Não é caractere de A a Z
                    sb.Append((char)currentElem);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }

            }

            return sb.ToString();
        }
    }
}
