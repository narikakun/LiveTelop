﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LiveTelop.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.4.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Normal")]
        public global::System.Windows.Forms.FormWindowState F1State {
            get {
                return ((global::System.Windows.Forms.FormWindowState)(this["F1State"]));
            }
            set {
                this["F1State"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0, 0")]
        public global::System.Drawing.Point F1Location {
            get {
                return ((global::System.Drawing.Point)(this["F1Location"]));
            }
            set {
                this["F1Location"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1282, 114")]
        public global::System.Drawing.Size F1Size {
            get {
                return ((global::System.Drawing.Size)(this["F1Size"]));
            }
            set {
                this["F1Size"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool beta_status {
            get {
                return ((bool)(this["beta_status"]));
            }
            set {
                this["beta_status"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool eew_forecast {
            get {
                return ((bool)(this["eew_forecast"]));
            }
            set {
                this["eew_forecast"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool eew_warning {
            get {
                return ((bool)(this["eew_warning"]));
            }
            set {
                this["eew_warning"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool eew_demo_forecast {
            get {
                return ((bool)(this["eew_demo_forecast"]));
            }
            set {
                this["eew_demo_forecast"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool eew_demo_warning {
            get {
                return ((bool)(this["eew_demo_warning"]));
            }
            set {
                this["eew_demo_warning"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2")]
        public int telop_scrollspeed {
            get {
                return ((int)(this["telop_scrollspeed"]));
            }
            set {
                this["telop_scrollspeed"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int color_pattern {
            get {
                return ((int)(this["color_pattern"]));
            }
            set {
                this["color_pattern"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int layout_pattern {
            get {
                return ((int)(this["layout_pattern"]));
            }
            set {
                this["layout_pattern"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool error_report {
            get {
                return ((bool)(this["error_report"]));
            }
            set {
                this["error_report"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool time_second {
            get {
                return ((bool)(this["time_second"]));
            }
            set {
                this["time_second"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool time_digital {
            get {
                return ((bool)(this["time_digital"]));
            }
            set {
                this["time_digital"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("■ 緊急地震速報 {alertflg}第{reportnum}報  ■ {time:d}日{time:H}時{time:m}分ごろ、{regionname}で最大" +
            "震度{calcintensity}と推定される地震が発生した模様です。震源の深さは、{depth}、マグニチュードは{magunitude}と推定されます。")]
        public string eew_text {
            get {
                return ((string)(this["eew_text"]));
            }
            set {
                this["eew_text"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string telop_level_s {
            get {
                return ((string)(this["telop_level_s"]));
            }
            set {
                this["telop_level_s"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool bouyomi {
            get {
                return ((bool)(this["bouyomi"]));
            }
            set {
                this["bouyomi"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100")]
        public int bouyomi_speed {
            get {
                return ((int)(this["bouyomi_speed"]));
            }
            set {
                this["bouyomi_speed"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100")]
        public int bouyomi_pitch {
            get {
                return ((int)(this["bouyomi_pitch"]));
            }
            set {
                this["bouyomi_pitch"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100")]
        public int bouyomi_volume {
            get {
                return ((int)(this["bouyomi_volume"]));
            }
            set {
                this["bouyomi_volume"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int bouyomi_type {
            get {
                return ((int)(this["bouyomi_type"]));
            }
            set {
                this["bouyomi_type"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("localhost")]
        public string bouyomi_ip {
            get {
                return ((string)(this["bouyomi_ip"]));
            }
            set {
                this["bouyomi_ip"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("50080")]
        public string bouyomi_port {
            get {
                return ((string)(this["bouyomi_port"]));
            }
            set {
                this["bouyomi_port"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool eew_forecast_wav {
            get {
                return ((bool)(this["eew_forecast_wav"]));
            }
            set {
                this["eew_forecast_wav"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool eew_warning_wav {
            get {
                return ((bool)(this["eew_warning_wav"]));
            }
            set {
                this["eew_warning_wav"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool eew_form {
            get {
                return ((bool)(this["eew_form"]));
            }
            set {
                this["eew_form"] = value;
            }
        }
    }
}
