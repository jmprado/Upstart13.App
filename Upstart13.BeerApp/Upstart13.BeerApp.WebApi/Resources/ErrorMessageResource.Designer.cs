﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Upstart13.BeerApp.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ErrorMessageResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorMessageResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Upstart13.BeerApp.Resources.ErrorMessageResource", typeof(ErrorMessageResource).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} cannot contains dummy word..
        /// </summary>
        public static string DummyIsForbidenError {
            get {
                return ResourceManager.GetString("DummyIsForbidenError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email format is not valid..
        /// </summary>
        public static string InvalidEmailError {
            get {
                return ResourceManager.GetString("InvalidEmailError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Maximum length of {0} is &apos;{1}&apos; characters..
        /// </summary>
        public static string MaxLengthError {
            get {
                return ResourceManager.GetString("MaxLengthError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} is required..
        /// </summary>
        public static string RequiredError {
            get {
                return ResourceManager.GetString("RequiredError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please select {0}..
        /// </summary>
        public static string RequiredSelectError {
            get {
                return ResourceManager.GetString("RequiredSelectError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The minimum length of &apos;{0}&apos; is {2} characters and maximum length is {1} characters..
        /// </summary>
        public static string StringLengthError {
            get {
                return ResourceManager.GetString("StringLengthError", resourceCulture);
            }
        }
    }
}