﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APINetMok.Properties {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("APINetMok.Properties.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
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
        ///   Busca una cadena traducida similar a No es posible guardar, el dato {0} ya existe, por favor modifíquelo e intente de nuevo..
        /// </summary>
        internal static string AlreadyExist {
            get {
                return ResourceManager.GetString("AlreadyExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Consulta Fallida.
        /// </summary>
        internal static string FailedQuery {
            get {
                return ResourceManager.GetString("FailedQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a No fue posible almacenar los datos. Por favor intente más tarde..
        /// </summary>
        internal static string FailedToSave {
            get {
                return ResourceManager.GetString("FailedToSave", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Error interno del servidor. Por favor comuníquese con el administrador del sistema..
        /// </summary>
        internal static string InternalServerError {
            get {
                return ResourceManager.GetString("InternalServerError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Registro no encontrado en la consulta.
        /// </summary>
        internal static string RecordNotFound {
            get {
                return ResourceManager.GetString("RecordNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a No se puede eliminar debido a que existe un préstamo.
        /// </summary>
        internal static string ReferentialIntegrity {
            get {
                return ResourceManager.GetString("ReferentialIntegrity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Se creó satisfactoriamente {0}{1} .
        /// </summary>
        internal static string SuccessfulCreation {
            get {
                return ResourceManager.GetString("SuccessfulCreation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Se eliminó  satisfactoriamente el registro con Identificador  {0}.
        /// </summary>
        internal static string SuccessfulDelete {
            get {
                return ResourceManager.GetString("SuccessfulDelete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Se actualizó satisfactoriamente {0}{1}.
        /// </summary>
        internal static string SuccessfulUpdate {
            get {
                return ResourceManager.GetString("SuccessfulUpdate", resourceCulture);
            }
        }
    }
}
