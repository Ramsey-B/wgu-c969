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
    internal class UpdateSql {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal UpdateSql() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CustomerManagement.Data.Sql.UpdateSql", typeof(UpdateSql).Assembly);
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
        ///   Looks up a localized string similar to UPDATE address SET address1 = @address1, address2 = @address2, cityId = @cityId, postalCode = @postalCode, phone = @phone, lastUpdated = @lastUpdated, lastUpdatedBy = @lastUpdatedBy WHERE id = @id;.
        /// </summary>
        internal static string Address {
            get {
                return ResourceManager.GetString("Address", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE appointment SET customerId = @CustomerId, userId = @UserId, title = @Title, description = @Description, location = @Location, crewName = @crewName, type = @type, start = @start, end = @end, lastUpdated = @lastUpdated, lastUpdatedBy = @lastUpdatedBy WHERE id = @id;.
        /// </summary>
        internal static string Appointment {
            get {
                return ResourceManager.GetString("Appointment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE city SET name = @name, countryId = @countryId, lastUpdated = @lastUpdated, lastUpdatedBy = @lastUpdatedBy WHERE id = @id;.
        /// </summary>
        internal static string City {
            get {
                return ResourceManager.GetString("City", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE country SET name = @name, lastUpdated = @lastUpdated, lastUpdatedBy = @lastUpdatedBy WHERE id = @id;.
        /// </summary>
        internal static string Country {
            get {
                return ResourceManager.GetString("Country", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE customer SET name = @name, addressId = @addressId, active = @active, lastUpdated = @lastUpdated, lastUpdatedBy = @lastUpdatedBy WHERE id = @id;.
        /// </summary>
        internal static string Customer {
            get {
                return ResourceManager.GetString("Customer", resourceCulture);
            }
        }
    }
}
