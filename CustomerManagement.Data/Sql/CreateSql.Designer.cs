﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CustomerManagement.Data.Sql {
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
    internal class CreateSql {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CreateSql() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CustomerManagement.Data.Sql.CreateSql", typeof(CreateSql).Assembly);
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
        ///   Looks up a localized string similar to INSERT INTO address (address1, address2, cityId, postalCode, phone, createdDate, createdBy, lastUpdatedDate, lastUpdatedBy) VALUES (@address1, @address2, @cityId, @postalCode, @phone, @createdDate, @createdBy, @lastUpdatedDate, @lastUpdatedBy);.
        /// </summary>
        internal static string Address {
            get {
                return ResourceManager.GetString("Address", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO appointment (customerId, userId, title, description, location, crewName, type, start, end, createdDate, createdBy, lastUpdatedDate, lastUpdatedBy) VALUES (@customerId, @userId, @title, @description, @location, @crewName, @type, @start, @end, @createdDate, @createdBy, @lastUpdatedDate, @lastUpdatedBy);.
        /// </summary>
        internal static string Appointment {
            get {
                return ResourceManager.GetString("Appointment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO city (name, countryId, createdDate, createdBy, lastUpdatedDate, lastUpdatedBy) VALUES (@name, @countryId, @createdDate, @createdBy, @lastUpdatedDate, @lastUpdatedBy);.
        /// </summary>
        internal static string City {
            get {
                return ResourceManager.GetString("City", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO country (name, createdDate, createdBy, lastUpdatedDate, lastUpdatedBy) VALUES (@name, @createdDate, @createdBy, @lastUpdatedDate, @lastUpdatedBy);.
        /// </summary>
        internal static string Country {
            get {
                return ResourceManager.GetString("Country", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO customer (name, addressId, active, createdDate, createdBy, lastUpdatedDate, lastUpdatedBy) VALUES (@name, @addressId, @active, @createdDate, @createdBy, @lastUpdatedDate, @lastUpdatedBy);.
        /// </summary>
        internal static string Customer {
            get {
                return ResourceManager.GetString("Customer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO user (username, password, active, createdDate, createdBy, lastUpdatedDate, lastUpdatedBy) VALUES (@username, @password, @active, @createdDate, @createdBy, @lastUpdatedDate, @lastUpdatedBy);.
        /// </summary>
        internal static string User {
            get {
                return ResourceManager.GetString("User", resourceCulture);
            }
        }
    }
}
