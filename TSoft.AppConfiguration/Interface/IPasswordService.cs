using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSoft.AppConfiguration
{
    public interface IPasswordService
    {
        string Encrypt(string password);
        string Decrypt(string encrytedPassword);
        bool  IsValidate(string password);
        bool IsValidate(string password,ref string errorMessage);
    }
}
