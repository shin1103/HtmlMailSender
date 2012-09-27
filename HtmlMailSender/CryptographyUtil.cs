using System;
using System.Collections.Generic;
using System.Text;

using System.Security.Cryptography;


namespace SHashiba.HtmlMailSender
{
    static class CryptographyUtil
    {
        private static string _key = "HtmlMailSender";

            #region "�Í��E����"

        /// <summary>
        /// ��������Í�������
        /// </summary>
        /// <param name="str">�Í������镶����</param>
        /// <returns>�Í������ꂽ������</returns>
        public static string EncryptString(string str)
        {
            //��������o�C�g�^�z��ɂ���
            byte[] bytesIn = System.Text.Encoding.UTF8.GetBytes(str);

            //DESCryptoServiceProvider�I�u�W�F�N�g�̍쐬
            System.Security.Cryptography.DESCryptoServiceProvider des =
                new System.Security.Cryptography.DESCryptoServiceProvider();

            //���L�L�[�Ə������x�N�^������
            //�p�X���[�h���o�C�g�z��ɂ���
            byte[] bytesKey = System.Text.Encoding.UTF8.GetBytes(_key);
            //���L�L�[�Ə������x�N�^��ݒ�
            des.Key = ResizeBytesArray(bytesKey, des.Key.Length);
            des.IV = ResizeBytesArray(bytesKey, des.IV.Length);

            //�Í������ꂽ�f�[�^�������o�����߂�MemoryStream
            System.IO.MemoryStream msOut = new System.IO.MemoryStream();
            //DES�Í����I�u�W�F�N�g�̍쐬
            System.Security.Cryptography.ICryptoTransform desdecrypt =
                des.CreateEncryptor();
            //�������ނ��߂�CryptoStream�̍쐬
            System.Security.Cryptography.CryptoStream cryptStreem =
                new System.Security.Cryptography.CryptoStream(msOut,
                desdecrypt,
                System.Security.Cryptography.CryptoStreamMode.Write);
            //��������
            cryptStreem.Write(bytesIn, 0, bytesIn.Length);
            cryptStreem.FlushFinalBlock();
            //�Í������ꂽ�f�[�^���擾
            byte[] bytesOut = msOut.ToArray();

            //����
            cryptStreem.Close();
            msOut.Close();

            //Base64�ŕ�����ɕύX���Č��ʂ�Ԃ�
            return System.Convert.ToBase64String(bytesOut);
        }

        /// <summary>
        /// �Í������ꂽ������𕜍�������
        /// </summary>
        /// <param name="str">�Í������ꂽ������</param>
        /// <returns>���������ꂽ������</returns>
        public static string DecryptString(string str)
        {
            //DESCryptoServiceProvider�I�u�W�F�N�g�̍쐬
            System.Security.Cryptography.DESCryptoServiceProvider des =
                new System.Security.Cryptography.DESCryptoServiceProvider();

            //���L�L�[�Ə������x�N�^������
            //�p�X���[�h���o�C�g�z��ɂ���
            byte[] bytesKey = System.Text.Encoding.UTF8.GetBytes(_key);
            //���L�L�[�Ə������x�N�^��ݒ�
            des.Key = ResizeBytesArray(bytesKey, des.Key.Length);
            des.IV = ResizeBytesArray(bytesKey, des.IV.Length);

            //Base64�ŕ�������o�C�g�z��ɖ߂�
            byte[] bytesIn = System.Convert.FromBase64String(str);
            //�Í������ꂽ�f�[�^��ǂݍ��ނ��߂�MemoryStream
            System.IO.MemoryStream msIn =
                new System.IO.MemoryStream(bytesIn);
            //DES�������I�u�W�F�N�g�̍쐬
            System.Security.Cryptography.ICryptoTransform desdecrypt =
                des.CreateDecryptor();
            //�ǂݍ��ނ��߂�CryptoStream�̍쐬
            System.Security.Cryptography.CryptoStream cryptStreem =
                new System.Security.Cryptography.CryptoStream(msIn,
                desdecrypt,
                System.Security.Cryptography.CryptoStreamMode.Read);

            //���������ꂽ�f�[�^���擾���邽�߂�StreamReader
            System.IO.StreamReader srOut =
                new System.IO.StreamReader(cryptStreem,
                System.Text.Encoding.UTF8);
            //���������ꂽ�f�[�^���擾����
            string result = srOut.ReadToEnd();

            //����
            srOut.Close();
            cryptStreem.Close();
            msIn.Close();

            return result;
        }


        /// <summary>
        /// ���L�L�[�p�ɁA�o�C�g�z��̃T�C�Y��ύX����
        /// </summary>
        /// <param name="bytes">�T�C�Y��ύX����o�C�g�z��</param>
        /// <param name="newSize">�o�C�g�z��̐V�����傫��</param>
        /// <returns>�T�C�Y���ύX���ꂽ�o�C�g�z��</returns>
        private static byte[] ResizeBytesArray(byte[] bytes, int newSize)
        {
            byte[] newBytes = new byte[newSize];
            if (bytes.Length <= newSize)
            {
                for (int i = 0; i < bytes.Length; i++)
                    newBytes[i] = bytes[i];
            }
            else
            {
                int pos = 0;
                for (int i = 0; i < bytes.Length; i++)
                {
                    newBytes[pos++] ^= bytes[i];
                    if (pos >= newBytes.Length)
                        pos = 0;
                }
            }
            return newBytes;
        }

        #endregion

            }


}
