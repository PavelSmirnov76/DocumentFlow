using DocumentFlow.Server.Crypt;
using System.Numerics;
using System.Text;

namespace DigitalSignatureTests
{
    public class DigitalSignatureTests
    {
        readonly string message = "asdasdasdasdasdsadasdasdadasdasdasdasdasdsadasdasdasdasdassdas";

        readonly BigInteger d = BigInteger.Parse("55441196065363246126355624130324183196576709222340016572108097750006097525544");
        readonly BigInteger xq = BigInteger.Parse("57520216126176808443631405023338071176630104906313632182896741342206604859403");
        readonly BigInteger yq = BigInteger.Parse("17614944419213781543809391949654080031942662045363639260709847859438286763994");
        [Fact]
        public void Sing_()
        {
            

            var DigSing = new DigitalSignature();

            

            var sing = DigSing.SignMessage(Encoding.Default.GetBytes(message), d);

            var test = BitConverter.ToString(sing);

            String[] arr = test.Split('-');
            byte[] array = new byte[arr.Length];
            for (int i = 0; i < arr.Length; i++) array[i] = Convert.ToByte(arr[i], 16);


            var Q = new ECPoint
            {
                x = xq,
                y = yq
            };

            var checkSign = DigSing.SignVer(Encoding.Default.GetBytes(message), array, Q);

            Assert.True(checkSign);
        }
    }
}