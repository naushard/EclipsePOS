﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EclipsePOS.WPF.SystemManager.Inventory.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.6.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public short ItemListViewPresenter_Pricing_opt {
            get {
                return ((short)(this["ItemListViewPresenter_Pricing_opt"]));
            }
            set {
                this["ItemListViewPresenter_Pricing_opt"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public short ItemListViewPresenter_Tax_inclusive {
            get {
                return ((short)(this["ItemListViewPresenter_Tax_inclusive"]));
            }
            set {
                this["ItemListViewPresenter_Tax_inclusive"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public short ItemListViewPresenter_Tax_excempt {
            get {
                return ((short)(this["ItemListViewPresenter_Tax_excempt"]));
            }
            set {
                this["ItemListViewPresenter_Tax_excempt"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ItemListViewPresenter_Tax_group {
            get {
                return ((string)(this["ItemListViewPresenter_Tax_group"]));
            }
            set {
                this["ItemListViewPresenter_Tax_group"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ItemListViewPresenter_Item_group {
            get {
                return ((string)(this["ItemListViewPresenter_Item_group"]));
            }
            set {
                this["ItemListViewPresenter_Item_group"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ItemListViewPresenter_Dept {
            get {
                return ((string)(this["ItemListViewPresenter_Dept"]));
            }
            set {
                this["ItemListViewPresenter_Dept"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public int ItemListViewPresenter_FilterOption {
            get {
                return ((int)(this["ItemListViewPresenter_FilterOption"]));
            }
            set {
                this["ItemListViewPresenter_FilterOption"] = value;
            }
        }
    }
}