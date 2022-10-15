using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Numerics;

namespace DocumentFlow.Server.Crypt
{
    public class DigitalSignature
    {
        private readonly BigInteger p = BigInteger.Parse("57896044618658097711785492504343953926634992332820282019728792003956564821041");
        private readonly BigInteger q = BigInteger.Parse("57896044618658097711785492504343953927082934583725450622380973592137631069619");

        private readonly ECPoint G = new ECPoint
        {
            a = BigInteger.Parse("7"),
            b = BigInteger.Parse("43308876546767276905765904595650931995942111794451039583252968842033849580414"),
            x = BigInteger.Parse("2"),
            y = BigInteger.Parse("4018974056539037503335449422937059775635739389905545080690979365213431566280"),
            FieldChar = BigInteger.Parse("57896044618658097711785492504343953926634992332820282019728792003956564821041")

        };

        public byte[] SignMessage(byte[] message, BigInteger d)
        {
            var e = CalcE(DecimalToBinaryConversion(ConvertByteArrToBinaryString(GetHash(message))));

            var random = new Random();

            byte[] data = new byte[32];

            var r = new BigInteger();
            var s = new BigInteger();

            do
            {
                var k = RandomK(data, random);
                var C = ECPoint.multiply(k, G);
                r = C.x % q;
                s = ((r * d) + (k * e)) % q;
            } while ((r == 0) || (s == 0));
            var sign = new byte[64];

            

            var Rvector = r.ToByteArray();
            var Svector = s.ToByteArray();

            for (int i = 0; i < 32; i++)
            {
                sign[i] = Rvector[i];
            }
            for (int i = 32; i < 64; i++)
            {
                sign[i] = Svector[i - 32];
            }

            return sign;
        }

        public bool SignVer(byte[] message, byte[] sign, ECPoint Q)
        {


            var Rvector = new byte[32];
            var Svector = new byte[32];

            for (int i = 0; i < 32; i++)
            {
                Rvector[i] = sign[i];
            }
            for (int i = 32; i < 64; i++)
            {
                Svector[i - 32] = sign[i];
            }

            var r = new BigInteger(Rvector);
            var s = new BigInteger(Svector);

            if ((r < 1) || (r > (p - 1)) || (s < 1) || (s > (q - 1)))
                return false;

            var e = CalcE(DecimalToBinaryConversion(ConvertByteArrToBinaryString(GetHash(message))));

            BigInteger v = Inverse.ModInverse(e, q);
            BigInteger z1 = (s * v) % q;
            BigInteger z2 = q + ((-(r * v)) % q);

            Q.a = G.a;
            Q.b = G.b;
            Q.FieldChar = p;

            ECPoint A = ECPoint.multiply(z1, G);
            ECPoint B = ECPoint.multiply(z2, Q);
            var C = A + B;
            BigInteger R = C.x % q;
            if (R == r)
                return true;
            else
                return false;
        }

        private byte[] GetHash(byte[] message)
        {
            var G256 = new HashFunctionStreebog(256);

            return G256.GetHash(message);
        }

        private string ConvertByteArrToBinaryString(byte[] arr)
        {
            var bitstr = "";

            for (int i = 0; i < 32; i++)
            {
                int by = arr[i];

                string sub = "";

                for (int j = 0; j < 8; j++)
                {
                    if (by % 2 == 1)
                    {
                        sub += "1";
                    }
                    else
                    {
                        sub += "0";
                    }

                    by /= 2;
                }
                char[] ch = sub.ToCharArray();
                Array.Reverse(ch);
                bitstr += new string(ch);
            }

            return bitstr;
        }

        private static BigInteger DecimalToBinaryConversion(string binaryString)
        {
            var alpha = new BigInteger();

            for (int i = 0; i < 256; i++)
            {
                if (binaryString[i] == '1')
                {
                    alpha += (BigInteger)Math.Pow(2, 255 - i);
                }
            }

            return alpha;
        }

        private BigInteger CalcE(BigInteger alpha)
        {
            var e = alpha % q;

            if (e == 0)
            {
                e = 1;
            }

            return e;
        }

        private BigInteger RandomK(byte[] data, Random random)
        {
            var k = new BigInteger(data);

            do
            { 
                random.NextBytes(data);
                k = new BigInteger(data);
            } while ((k < 0) || (k > q));

            return k;
        }
        private static string Padding(string input, int size)
        {
            if (input.Length < size)
            {
                do
                {
                    input = "0" + input;
                } while (input.Length < size);
            }
            return input;
        }


    }
}
