﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;


namespace EclipsePos.Apps.Util
{
    // Decorate the settings class with a SettingsProvider attribute
    // This tells ApplicationSettingsBase to use a non-default provider (e.g. not the 
    // LocalFileSettingsProvider, which targets the .config file)
    [SettingsProvider(typeof(EclipsePos.Apps.Util.EclipseSettingsProvider))]

    public class PosSettings : ApplicationSettingsBase
    {

        private static PosSettings posSettings;

        public static PosSettings Default
        {
            get
            {
                if (posSettings == null)
                {
                    posSettings = new PosSettings();
                }
                return posSettings;
            }

        }

        [ApplicationScopedSetting]
        [DefaultSettingValue("0")]
        public string Organization
        {
            get { return (string)this["organization"]; }
            set { this["organization"] = value; }
        }

        [ApplicationScopedSetting]
        [DefaultSettingValue("0")]
        public string Store
        {
            get { return (string)this["store"]; }
            set { this["store"] = value; }
        }

        [ApplicationScopedSetting]
        [DefaultSettingValue("0")]
        public int Station
        {
            get { return (int)this["station"]; }
            set { this["station"] = value; }
        }

        [ApplicationScopedSetting]
        [DefaultSettingValue("0")]
        public int Configuration
        {
            get { return (int)this["configuration"]; }
            set { this["configuration"] = value; }
        }

        [ApplicationScopedSetting]
        [DefaultSettingValue("true")]
        public bool PrintReceiptImmediate
        {
            get { return (bool)this["printReceiptImmediate"]; }
            set { this["printReceiptImmediate"] = value; }
        }


        [ApplicationScopedSetting]
        [DefaultSettingValue("true")]
        public bool Debug
        {
            get { return (bool)this["debug"]; }
            set { this["debug"] = value; }
        }

        [ApplicationScopedSetting]
        [DefaultSettingValue("10")]
        public uint BatchSpoolingSize
        {
            get { return (uint)this["batchSpoolingSize"]; }
            set { this["batchSpoolingSize"] = value; }
        }

        [ApplicationScopedSetting]
        [DefaultSettingValue("C:\\TEMP\\")]
        public string BatchSpoolingDirectory
        {
            get
            {
                return ((string)(this["batchSpoolingDirectory"]));
            }
            set
            {
                this["batchSpoolingDirectory"] = value;
            }
        }

        [ApplicationScopedSetting]
        [DefaultSettingValue("3")]
        public int SyncDirectionMasterData
        {
            get { return (int)this["syncDirectionMasterData"]; }
            set { this["syncDirectionMasterData"] = value; }
        }

        [ApplicationScopedSetting]
        [DefaultSettingValue("2")]
        public int SyncDirectionTransactionData
        {
            get { return (int)this["syncDirectionTransactionData"]; }
            set { this["syncDirectionTransactionData"] = value; }
        }

        [ApplicationScopedSetting]
        [DefaultSettingValue("4")]
        public int SyncDirectionConfigurationData
        {
            get { return (int)this["SyncDirectionConfigurationData"]; }
            set { this["SyncDirectionConfigurationData"] = value; }
        }



    }
}
