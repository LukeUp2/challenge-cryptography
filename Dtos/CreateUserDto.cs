using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Criptografia.Api.Dtos
{
    public class CreateUserDto
    {
        public required string UserDocument { get; set; }
        public required string CreditCardToken { get; set; }
        public long Value { get; set; }
    }
}