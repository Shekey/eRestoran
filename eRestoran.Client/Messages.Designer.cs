﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eRestoran.Client {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("eRestoran.Client.Messages", typeof(Messages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Zaokruzite na 2 decimale!.
        /// </summary>
        internal static string Cijena_decimale {
            get {
                return ResourceManager.GetString("Cijena_decimale", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cijena je obavezna!.
        /// </summary>
        internal static string Cijena_req {
            get {
                return ResourceManager.GetString("Cijena_req", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Neispravan format, unesite sa &apos; . &apos;.
        /// </summary>
        internal static string Cijena_zarez {
            get {
                return ResourceManager.GetString("Cijena_zarez", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cijeli broj !.
        /// </summary>
        internal static string Integer {
            get {
                return ResourceManager.GetString("Integer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ime je obavezno!.
        /// </summary>
        internal static string Naziv_req {
            get {
                return ResourceManager.GetString("Naziv_req", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ne smijete imate negativnu vrijednost..
        /// </summary>
        internal static string NegVrijednost {
            get {
                return ResourceManager.GetString("NegVrijednost", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email nije ispravan !.
        /// </summary>
        internal static string NeispravanEmail {
            get {
                return ResourceManager.GetString("NeispravanEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Obavezan unos !.
        /// </summary>
        internal static string Univerzalno {
            get {
                return ResourceManager.GetString("Univerzalno", resourceCulture);
            }
        }
    }
}
