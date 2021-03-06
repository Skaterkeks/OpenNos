/*
 * This file is part of the OpenNos Emulator Project. See AUTHORS file for Copyright information
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 */

using System;

namespace OpenNos.Core
{
    public class LoginEncryption : EncryptionBase
    {
        #region Instantiation

        public LoginEncryption() : base(false)
        {
        }

        #endregion

        //public static string GetPassword(string passcrypt)
        //{
        //    bool equal = passcrypt.Length % 2 == 0 ? true : false;
        //    string str = equal == true ? passcrypt.Remove(0, 3) : passcrypt.Remove(0, 4);
        //    string decpass = string.Empty;
        //    for (int i = 0; i < str.Length; i += 2) decpass += str[i];
        //    if (decpass.Length % 2 != 0)
        //    {
        //        str = decpass = string.Empty;
        //        str = passcrypt.Remove(0, 2);
        //        for (int i = 0; i < str.Length; i += 2) decpass += str[i];
        //    }
        //    StringBuilder temp = new StringBuilder();
        //    for (int i = 0; i < decpass.Length; i += 2)
        //        temp.Append(Convert.ToChar(Convert.ToUInt32(decpass.Substring(i, 2), 16)));
        //    decpass = temp.ToString();
        //    return decpass;
        //}

        #region Methods

        public override string Decrypt(byte[] packet, int customParameter = 0)
        {
            try
            {
                string decryptedPacket = string.Empty;

                for (int i = 0; i < packet.Length; i++)
                {
                    if (packet[i] > 14) // (x - 15) ^ 195
                    {
                        decryptedPacket += Convert.ToChar((packet[i] - 15) ^ 195);
                    }
                    else //if (packet[i])// (256 - ( 15 - (x)))
                    {
                        decryptedPacket += Convert.ToChar((256 - (15 - (packet[i]))) ^ 195);
                    }
                }

                return decryptedPacket;
            }
            catch
            {
                return string.Empty;
            }
        }

        public override string DecryptCustomParameter(byte[] data)
        {
            throw new NotImplementedException();
        }

        public override byte[] Encrypt(string packet)
        {
            byte[] encryptedPacket = new byte[
                packet.Length + 1];

            for (int i = 0; i < packet.Length; i++)
            {
                encryptedPacket[i] = Convert.ToByte(packet[i] + 15);
            }

            encryptedPacket[encryptedPacket.Length - 1] = 25; //endpacket -> shows the server that the packet ends

            return encryptedPacket;
        }

        #endregion
    }
}