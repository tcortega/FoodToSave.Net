using System.Buffers.Text;
using System.Linq;
using System.Text;

namespace FoodToSave.Net.Utils;

internal static class StringExtensions
{
    public static byte[] GetBytesFromBase64(this string encoded)
    {
        var paddingNeeded = encoded.Length % 4;
        if (paddingNeeded > 0)
        {
            encoded += new string('=', 4 - paddingNeeded);
        }
        var encodedBytes = Encoding.UTF8.GetBytes(encoded);
        
        var paddingCount = encoded.Count(c => c == '=');
        var outputLength = (encoded.Length - paddingCount) * 3 / 4;
        var outputArray = new byte[outputLength];
        Base64.DecodeFromUtf8(encodedBytes, outputArray, out _, out _);

        return outputArray;
    }
}