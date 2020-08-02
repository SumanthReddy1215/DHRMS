using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSoft.AppConfiguration.Helper
{
    public class PasswordManager : IPasswordService
    {
        private string _encryptKey;
        public PasswordManager(string encryptKey)
        {
            this._encryptKey = encryptKey;
        }

        public string Decrypt(string encrytedPassword)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(string password)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsValidate(string password)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsValidate(string password, ref string errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}
