using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Cryptography;
public class cryptographServiceFake : ICryptographyService
{
    public bool Compare(string rawText, byte[] cypherText, byte[] salt)
    {
        throw new NotImplementedException();
    }
}
