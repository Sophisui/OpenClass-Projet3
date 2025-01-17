﻿using System.Resources;
using System.Reflection;
using System.Globalization;

namespace P3AddNewFunctionalityDotNetCore.Models.Resources.Models.Services {
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public static class ProductService
    {
        private static ResourceManager resourceManager = new ResourceManager("P3AddNewFunctionalityDotNetCore.Models.Resources.Models.Services.ProductService", Assembly.GetExecutingAssembly());
        private static CultureInfo resourceCulture;

        public static string MissingName
        {
            get
            {
                return resourceManager.GetString("MissingName", resourceCulture);
            }
        }
        public static string MissingPrice
        {
            get
            {
                return resourceManager.GetString("MissingPrice", resourceCulture);
            }
        }
        public static string MissingStock
        {
            get
            {
                return resourceManager.GetString("MissingStock", resourceCulture);
            }
        }
        public static string PriceNotANumber
        {
            get
            {
                return resourceManager.GetString("PriceNotANumber", resourceCulture);
            }
        }
        public static string PriceNotGreaterThanZero
        {
            get
            {
                return resourceManager.GetString("PriceNotGreaterThanZero", resourceCulture);
            }
        }
        public static string StockNotAnInteger
        {
            get
            {
                return resourceManager.GetString("StockNotAnInteger", resourceCulture);
            }
        }
        public static string StockNotGreaterThanZero
        {
            get
            {
                return resourceManager.GetString("StockNotGreaterThanZero", resourceCulture);
            }
        }
    }
        
}
