using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;



namespace EclipsePos.Data.Util
{
    // Decorate the settings class with a SettingsProvider attribute
    // This tells ApplicationSettingsBase to use a non-default provider (e.g. not the 
    // LocalFileSettingsProvider, which targets the .config file)
    [SettingsProvider(typeof(EclipsePos.Data.Util.EclipseSettingsProvider))]

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
        [DefaultSettingValue("")]
        public string DataSource
        {
            get { return (string)this["dataSource"]; }
            set { this["dataSource"] = value; }
        }

        
    }
}
