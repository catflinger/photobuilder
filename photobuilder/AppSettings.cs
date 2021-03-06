﻿using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Drawing;
using System.Text;

namespace Photobuilder
{
    public class AppSettings : ApplicationSettingsBase
    {
        [UserScopedSetting()]
        [DefaultSettingValue(@"C:\CODE\Content\photodiary\source")]
        public string sourceFolder
        {
            get { return ((string)this["sourceFolder"]); }
            set { this["sourceFolder"] = value; }
        }
        [UserScopedSetting()]
        [DefaultSettingValue(@"C:\CODE\Content\photodiary\dist")]
        public string distFolder
        {
            get { return ((string)this["distFolder"]); }
            set { this["distFolder"] = value; }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("120")]
        public int thumbWidth
        {
            get { return (int)this["thumbWidth"]; }
            set { this["thumbWidth"] = value; }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("80")]
        public int thumbHeight
        {
            get { return (int)this["thumbHeight"]; }
            set { this["thumbHeight"] = value; }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("900")]
        public int largeHeight
        {
            get { return (int)this["largeHeight"]; }
            set { this["largeHeight"] = value; }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("100")]
        public long thumbQuality
        {
            get { return (long)this["thumbQuality"]; }
            set { this["thumbQuality"] = value; }
        }
        [UserScopedSetting()]
        [DefaultSettingValue("75")]
        public long largeQuality
        {
            get { return (long)this["largeQuality"]; }
            set { this["largeQuality"] = value; }
        }
        [UserScopedSetting()]
        [DefaultSettingValue("false")]
        public bool incrementalProcessing
        {
            get { return (bool)this["incrementalProcessing"]; }
            set { this["incrementalProcessing"] = value; }
        }
        [UserScopedSetting()]
        [DefaultSettingValue("0")]
        public DayOfWeek FirstDayOfWeek
        {
            get { return (DayOfWeek)this["FirstDayOfWeek"]; }
            set { this["FirstDayOfWeek"] = value; }
        }
        [UserScopedSetting()]
        [DefaultSettingValue("#FFFFFF")]
        public string BlankColor
        {
            get { return (string)this["BlankColor"]; }
            set { this["BlankColor"] = value; }
        }
        [UserScopedSetting()]
        [DefaultSettingValue("#FFFFFF")]
        public string PlaceholderColor
        {
            get { return (string)this["PlaceholderColor"]; }
            set { this["PlaceholderColor"] = value; }
        }
        [UserScopedSetting()]
        [DefaultSettingValue("ftp.server.com")]
        public string FtpHost
        {
            get { return (string)this["FtpHost"]; }
            set { this["FtpHost"] = value; }
        }
        [UserScopedSetting()]
        [DefaultSettingValue("somefolder/otherfolder")]
        public string FtpPath
        {
            get { return (string)this["FtpPath"]; }
            set { this["FtpPath"] = value; }
        }
        [UserScopedSetting()]
        [DefaultSettingValue("username")]
        public string FtpUser
        {
            get { return (string)this["FtpUser"]; }
            set { this["FtpUser"] = value; }
        }
        [UserScopedSetting()]
        [DefaultSettingValue("*****")]
        public string FtpPassword
        {
            get { return decrypt((string)this["FtpPassword"]); }
            set { this["FtpPassword"] = encrypt(value); }
        }

        private byte[] salt = new byte[] { 0x01, 0xFF, 0x6E };

        private string encrypt(string source) {

            byte[] encryptedData = ProtectedData.Protect(
                Encoding.Unicode.GetBytes(source),
                salt,
                DataProtectionScope.CurrentUser);

            return Convert.ToBase64String(encryptedData);
        }
        private string decrypt(string source)
        {
            try
            {
                byte[] decryptedData = ProtectedData.Unprotect(
                    Convert.FromBase64String(source),
                    salt,
                    DataProtectionScope.CurrentUser);
                return Encoding.Unicode.GetString(decryptedData);
            }
            catch
            {
                return null;
            }
        }
    }
}
