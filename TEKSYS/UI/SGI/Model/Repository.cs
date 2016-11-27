namespace SGI.Model
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    using System.Windows;
    using System.Configuration;
    using SGI.Enumeration;
    using System.Data;
    using SGI.Model.Entidades;

    #endregion
    public static partial class Repository
    {
        #region Private Fields

        private static string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        #endregion

        #region Public Fields
        public static List<Usuario> UsuariosDisponiblesCache { get; set; }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <returns></returns>
        public static bool InsUser(string userName, string password, ref int errorCode, ref string messageError)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsUser;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 60).Value = userName;
                        sqlCommand.Parameters.Add("@Pass", System.Data.SqlDbType.VarChar, 60).Value = password;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();

                        return true;

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="url"></param>
        /// <param name="activo"></param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <returns></returns>
        public static bool InsFamily(string familia, string url, ref int errorCode, ref string messageError, int activo = 1)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsFamily;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Familia", System.Data.SqlDbType.NVarChar, 50).Value = familia;
                        sqlCommand.Parameters.Add("@Url", System.Data.SqlDbType.NVarChar, 50).Value = url;
                        sqlCommand.Parameters.Add("@Activo", System.Data.SqlDbType.Int).Value = activo;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();

                        return errorCode >= 0;

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="activo"></param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <returns></returns>
        public static bool InsertMarca(string marca, ref int errorCode, ref string messageError, int activo = 1)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsertMarcas;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Marca", System.Data.SqlDbType.NVarChar, 50).Value = marca;
                        sqlCommand.Parameters.Add("@Activo", System.Data.SqlDbType.Int).Value = activo;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();

                        return errorCode >= 0;

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="activo"></param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <returns></returns>
        public static bool InsertColor(string color, string claveColor, ref int errorCode, ref string messageError, int activo = 1)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsertColor;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Color", System.Data.SqlDbType.NVarChar, 50).Value = color;
                        sqlCommand.Parameters.Add("@ClaveColor", System.Data.SqlDbType.NVarChar, 20).Value = claveColor;
                        sqlCommand.Parameters.Add("@Activo", System.Data.SqlDbType.Int).Value = activo;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();

                        return errorCode >= 0;

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <returns></returns>
        public static bool InsTrademark(string name, ref int errorCode, ref string messageError)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsTrademark;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 60).Value = name;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();

                        return true;

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <returns></returns>
        public static bool InsModels(string name, ref int errorCode, ref string messageError)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsModels;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 60).Value = name;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();

                        return true;

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <returns></returns>
        public static bool InsCoins(string name, ref int errorCode, ref string messageError)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsCoins;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 60).Value = name;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();

                        return true;

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <returns></returns>
        public static bool InsOfferType(string name, ref int errorCode, ref string messageError)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsOfferType;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 60).Value = name;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();

                        return true;

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool UpdOfferType(int id, string name)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureUpdOffertType;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 60).Value = name;
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();

                        return true;

                    }
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idOfferType"></param>
        /// <returns></returns>
        public static bool DelOfferType(int idOfferType)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureDelOfferType;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 60).Value = idOfferType;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();

                        return true;

                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Inserta una nueva familia en el catalogo de familias
        /// </summary>
        /// <param name="family"></param>
        public static bool InsProducts(Product product, ref int errorCode, ref string messageError)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsProducts;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id_Modelo", System.Data.SqlDbType.Int).Value = product.SelectedModel;
                        sqlCommand.Parameters.Add("@Id_Marca", System.Data.SqlDbType.Int).Value = product.SelectedTrademark;
                        sqlCommand.Parameters.Add("@Id_Familia", System.Data.SqlDbType.Int).Value = product.SelectedFamily;
                        sqlCommand.Parameters.Add("@Id_Moneda", System.Data.SqlDbType.Int).Value = product.SelectedCoin;
                        sqlCommand.Parameters.Add("@Clave_Proveedor", System.Data.SqlDbType.VarChar, 50).Value = product.Providers;
                        sqlCommand.Parameters.Add("@Clave_Teknobike", System.Data.SqlDbType.VarChar, 50).Value = product.TeknobikeKey;
                        sqlCommand.Parameters.Add("@Sku", System.Data.SqlDbType.VarChar, 50).Value = product.Sku;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 100).Value = product.Name;
                        sqlCommand.Parameters.Add("@Description", System.Data.SqlDbType.VarChar, 60).Value = product.Description;
                        sqlCommand.Parameters.Add("@Precio_Mayoreo", System.Data.SqlDbType.VarChar).Value = product.Wholesale;
                        sqlCommand.Parameters.Add("@Precio_Medio_Mayoreo", System.Data.SqlDbType.Decimal).Value = product.MediumWholesale;
                        sqlCommand.Parameters.Add("@Precio_Publico", System.Data.SqlDbType.Decimal).Value = product.PublicPrice;
                        sqlCommand.Parameters.Add("@Costo", System.Data.SqlDbType.Decimal).Value = product.Cost;
                        sqlCommand.Parameters.Add("@Piezas", System.Data.SqlDbType.Int).Value = product.Pieces;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// Inserta un nuevo elemento a la tabla [Productos].[Precios_Ofertas]
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="offerTypeId"></param>
        /// <param name="price"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <returns></returns>
        public static bool InsOfferPrice(int productId, int offerTypeId, double? price, DateTime? beginDate, DateTime? endDate, ref int errorCode, ref string messageError)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsOfferPrice;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id_Producto", System.Data.SqlDbType.Int).Value = productId;
                        sqlCommand.Parameters.Add("@Id_Producto_Tipo_Oferta", System.Data.SqlDbType.Int).Value = offerTypeId;
                        sqlCommand.Parameters.Add("@Precio", System.Data.SqlDbType.Decimal).Value = price;
                        sqlCommand.Parameters.Add("@fecha_Inicio", System.Data.SqlDbType.Date).Value = beginDate;
                        sqlCommand.Parameters.Add("@Fecha_Final", System.Data.SqlDbType.Date).Value = endDate;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();

                        return true;

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// Inserta un nuevo elemento en la tabla [dbo].[Costo_Concepto]
        /// </summary>
        /// <param name="name"></param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <returns></returns>
        public static bool InsCostConcept(string name, ref int errorCode, ref string messageError)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsCostConcept;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 60).Value = name;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();

                        return true;

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }


        /// <summary>
        /// Inserta un nuevo proveedor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <returns></returns>
        public static bool InsProvider(Provider model, ref int errorCode, ref string messageError)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsProviders;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 100).Value = model.Name;
                        sqlCommand.Parameters.Add("@RFC", System.Data.SqlDbType.VarChar, 20).Value = model.Rfc;
                        sqlCommand.Parameters.Add("@Direccion", System.Data.SqlDbType.VarChar, 100).Value = model.Address;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();

                        return true;

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        public static bool InsArchivo(ArchivoAdjunto archivo)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = "Compras.InsertArchivo";
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@tipo", System.Data.SqlDbType.VarChar).Value = archivo.TipoArchivo;
                        sqlCommand.Parameters.Add("@ruta", System.Data.SqlDbType.VarChar).Value = archivo.RutaArchivo;
                        sqlCommand.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = archivo.NombreArchivo;
                        sqlCommand.Parameters.Add("@idoc", System.Data.SqlDbType.Int).Value = archivo.IdOC;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();

                        return true;

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();

                    return false;
                }
            }
        }

        public static List<ArchivoAdjunto> GetArchivos(int idoc)
        {
            var archivos = new List<ArchivoAdjunto>();
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = "Compras.GetArchivos";
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@idoc", System.Data.SqlDbType.Int).Value = idoc;

                        conn.Open();
                        var reader = sqlCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            var item = new ArchivoAdjunto();
                            item.TipoArchivo = reader["TipoArchivo"].ToString();
                            item.RutaArchivo = reader["RutaArchivo"].ToString();
                            item.NombreArchivo = reader["NombreArchivo"].ToString();
                            archivos.Add(item);
                        }
                        conn.Close();

                        return archivos;

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();

                    return archivos;
                }
            }
            return archivos;
        }

        /// <summary>
        /// Ingresa un nuevo concepto de pago
        /// </summary>
        /// <param name="name">concepto de pago</param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <returns></returns>
        public static bool InsPaymentCondition(string name, ref int errorCode, ref string messageError)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsPaymentCondition;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 60).Value = name;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();

                        return true;

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// Ingresa un nuevo estatus de compra
        /// </summary>
        /// <param name="name">concepto de pago</param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <returns></returns>
        public static bool InsStatusBuy(string name, bool sendNotify, ref int errorCode, ref string messageError)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsStatusBuy;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 60).Value = name;
                        sqlCommand.Parameters.Add("@EnviaNotificacion", System.Data.SqlDbType.Bit).Value = sendNotify;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();

                        return true;

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// Ingresa un nuevo estatus de compra
        /// </summary>
        /// <param name="name">concepto de pago</param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <returns></returns>
        public static bool InsOrderBuy(OrderBuy model, ref int errorCode, ref string messageError)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsOrderBuy;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@IdProveedor", System.Data.SqlDbType.Int).Value = model.IdProvider;
                        sqlCommand.Parameters.Add("@IdEmpleadoComprador", System.Data.SqlDbType.Int).Value = model.IdEmployeeBuyer;
                        sqlCommand.Parameters.Add("@IdEmpleadoValidador", System.Data.SqlDbType.Int).Value = model.IdEmployeeValidator;
                        sqlCommand.Parameters.Add("@IdCondicionPago", System.Data.SqlDbType.Int).Value = model.IdPaymentCondition;
                        sqlCommand.Parameters.Add("@OrdenCompra", System.Data.SqlDbType.VarChar, 30).Value = model.NumberOrderBuy;
                        sqlCommand.Parameters.Add("@FechaColocacion", System.Data.SqlDbType.Date).Value = model.DateColocation;
                        sqlCommand.Parameters.Add("@FechaValidacion", System.Data.SqlDbType.Date).Value = model.DateValidation;
                        sqlCommand.Parameters.Add("@IdStatus", System.Data.SqlDbType.Int).Value = model.IdBuyStatus;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);
                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <returns></returns>
        public static bool InsOrderBuyDetails(string xml, int IdOrderBuy, int IdOrderBuyStatus, ref int errorCode, ref string messageError)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsOrderBuyDetail;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@IdOrdenCompra", System.Data.SqlDbType.Int).Value = IdOrderBuy;
                        sqlCommand.Parameters.Add("@IdStatusOrderBuy", System.Data.SqlDbType.Int).Value = IdOrderBuyStatus;
                        sqlCommand.Parameters.Add("@String", System.Data.SqlDbType.VarChar).Value = xml;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@Message", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@Message"].Value.ToString();

                        conn.Close();

                        return true;

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// Obtiene el login del usuario.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static Usuario GetUserExist(string name, string password, int idUbicacion)
        {
            Usuario model = null;

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetUser;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@UserName", System.Data.SqlDbType.VarChar, 60).Value = name;
                        sqlCommand.Parameters.Add("@PassWord", System.Data.SqlDbType.VarChar, 300).Value = password;
                        sqlCommand.Parameters.Add("@idUbicacion", System.Data.SqlDbType.Int).Value = idUbicacion;

                        conn.Open();

                        var dr = sqlCommand.ExecuteReader();

                        while (dr.Read())
                        {
                            model = new Usuario();
                            model.Id = Convert.ToInt32(dr["id"]);
                            model.Nombre = dr["nombre"].ToString();
                            model.Codigo = dr["codigo"].ToString();
                        }

                        conn.Close();

                        return model;
                    }
                }
                catch (Exception ex)
                {
                    // return new Usuario() { Id = -1 };
                    return null;
                }
            }
        }

        public static int GetVerifySend(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetVerifySend;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@IdStatus", System.Data.SqlDbType.Int).Value = id;

                        conn.Open();

                        object result = sqlCommand.ExecuteScalar();

                        conn.Close();

                        if (result == null)
                            return 0;
                        else
                            return Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }


        /// <summary>
        /// Obtiene una lista del catalogo de modelos.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //public static List<Models> GetModels(string model)
        //{
        //    List<Models> lstModels = new List<Models>();           

        //    using (SqlConnection conn = new SqlConnection())
        //    {
        //        try
        //        {
        //            conn.ConnectionString = connectionString;

        //            using (SqlCommand sqlCommand = new SqlCommand())
        //            {
        //                sqlCommand.Connection = conn;
        //                sqlCommand.CommandText = Constants.ProcedureGetModels;
        //                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //                sqlCommand.Parameters.Add("@Modelo", System.Data.SqlDbType.VarChar, 60).Value = model;

        //                conn.Open();

        //                var reader = sqlCommand.ExecuteReader();

        //                while (reader.Read())
        //                {
        //                    Models modelAux = new Models();
        //                    modelAux.Id = Convert.ToInt32(reader["Id"].ToString());
        //                    modelAux.Model = reader["Modelo"].ToString();
        //                    lstModels.Add(modelAux);
        //                }

        //                conn.Close();

        //                return lstModels;

        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error" + ex.ToString(), "Error obteniendo modelos", MessageBoxButton.OK, MessageBoxImage.Error);
        //            return new List<Models>();
        //        }
        //    }
        //}

        /// <summary>
        /// Obtiene una lista del catalogo de modelos.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<Coin> GetCoins(string coinName)
        {
            List<Coin> lstCoins = new List<Coin>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetCoins;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Monedas", System.Data.SqlDbType.VarChar, 60).Value = coinName;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            Coin modelAux = new Coin();
                            modelAux.Id = Convert.ToInt32(reader["Id"].ToString());
                            modelAux.CoinName = reader["Moneda"].ToString();
                            lstCoins.Add(modelAux);
                        }

                        conn.Close();

                        return lstCoins;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo monedas", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<Coin>();
                }
            }
        }

        /// <summary>
        /// Obtiene una lista del costo conceptos.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<CosteConcept> GetCosteConcept(string name)
        {
            List<CosteConcept> lstCoins = new List<CosteConcept>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetCostConcept;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 60).Value = name;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            CosteConcept modelAux = new CosteConcept();
                            modelAux.Id = Convert.ToInt32(reader["Id"].ToString());
                            modelAux.ConceptName = reader["Concepto"].ToString();
                            lstCoins.Add(modelAux);
                        }

                        conn.Close();

                        return lstCoins;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo monedas", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<CosteConcept>();
                }
            }
        }

        /// <summary>
        /// Obtiene una lista del catalogo de familias.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<Families> GetFamilies(string familyName)
        {
            List<Families> lstFamilies = new List<Families>();
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetFamilies;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Familia", System.Data.SqlDbType.NVarChar, 50).Value = familyName;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            Families modelAux = new Families();
                            modelAux.Id = reader.GetInt32(0);
                            modelAux.FamilyName = reader.GetString(1);
                            modelAux.Url = reader.GetString(2);
                            modelAux.Active = (reader.GetInt32(3) > 0);
                            lstFamilies.Add(modelAux);
                        }

                        conn.Close();

                        return lstFamilies;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo familias", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<Families>();
                }
            }
        }

        /// <summary>
        /// Obtiene una lista del catalogo de familias.
        /// </summary>
        /// <param name="marca"></param>
        /// <returns></returns>
        public static List<Brand> GetMarcas(string marca)
        {
            List<Brand> lstMarcas = new List<Brand>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetMarcas;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Marca", System.Data.SqlDbType.NVarChar, 50).Value = marca;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            Brand modelAux = new Brand();
                            modelAux.Id = reader.GetInt32(0);
                            modelAux.Marca = reader.GetString(1);
                            modelAux.Active = (reader.GetInt32(2) > 0);
                            lstMarcas.Add(modelAux);
                        }

                        conn.Close();

                        return lstMarcas;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo marcas", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<Brand>();
                }
            }
        }

        /// <summary>
        /// Obtiene una lista del catalogo de familias.
        /// </summary>
        /// <param name="marca"></param>
        /// <returns></returns>
        public static List<Color> GetColores(string color, string claveColor)
        {
            List<Color> lstColores = new List<Color>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetColores;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Color", System.Data.SqlDbType.NVarChar, 50).Value = color;
                        sqlCommand.Parameters.Add("@ClaveColor", System.Data.SqlDbType.NVarChar, 20).Value = claveColor;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            Color modelAux = new Color();
                            modelAux.Id = reader.GetInt32(0);
                            modelAux.ColorString = reader.GetString(1);
                            modelAux.ClaveColor = reader.GetString(2);
                            modelAux.Active = (reader.GetInt32(3) > 0);
                            lstColores.Add(modelAux);
                        }

                        conn.Close();

                        return lstColores;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo colores", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<Color>();
                }
            }
        }

        /// <summary>
        /// Obtiene una lista del catalogo de marcas.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<Trademark> GetTrademarks(string trademarkName)
        {
            List<Trademark> lstTrademarks = new List<Trademark>();


            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetTrademark;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Marcas", System.Data.SqlDbType.VarChar, 60).Value = trademarkName;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            Trademark modelAux = new Trademark();
                            modelAux.Id = Convert.ToInt32(reader["Id"].ToString());
                            modelAux.TrademarkName = reader["Marca"].ToString();
                            lstTrademarks.Add(modelAux);
                        }

                        conn.Close();

                        return lstTrademarks;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo familias", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<Trademark>();
                }
            }
        }

        /// <summary>
        /// Obtiene una lista del catalogo de marcas.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<Product> GetProducts(string productName)
        {
            List<Product> lstProducts = new List<Product>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetProducts;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Producto", System.Data.SqlDbType.VarChar, 60).Value = productName;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            Product modelAux = new Product();
                            modelAux.Id = Convert.ToInt32(reader["Id"]);
                            modelAux.Name = reader["Producto"].ToString();
                            modelAux.Description = reader["Description"].ToString();
                            modelAux.IdTrademark = Convert.ToInt32(reader["IdMarca"]);
                            modelAux.SelectedFamily = reader["Id_Familia"].ToString();
                            modelAux.SelectedModel = reader["Id_Modelo"].ToString();
                            modelAux.SelectedCoin = reader["Id_Moneda"].ToString();
                            modelAux.TrademarkName = reader["Marca"].ToString();

                            modelAux.Providers = reader["Clave_Proveedor"].ToString();
                            modelAux.TeknobikeKey = reader["Clave_Teknobike"].ToString();
                            modelAux.Sku = reader["Sku"].ToString();

                            modelAux.Cost = reader["Costo"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["Costo"]);
                            modelAux.Wholesale = reader["Mayoreo"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["Mayoreo"]);
                            modelAux.MediumWholesale = reader["Precio_Medio_Mayoreo"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["Precio_Medio_Mayoreo"]);
                            modelAux.PublicPrice = reader["Precio_Publico"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["Precio_Publico"]);
                            modelAux.Pieces = Convert.ToInt32(reader["Piezas"]);


                            lstProducts.Add(modelAux);
                        }

                        conn.Close();

                        return lstProducts;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo familias", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<Product>();
                }
            }
        }

        /// <summary>
        /// Obtiene una lista del catalogo de proveedores.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<Provider> GetProviders(string name)
        {
            List<Provider> lstProducts = new List<Provider>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetProviders;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 60).Value = name;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            Provider modelAux = new Provider();
                            modelAux.Id = Convert.ToInt32(reader["Id"]);
                            modelAux.Name = reader["Nombre"].ToString();
                            modelAux.Rfc = reader["RFC"].ToString();
                            modelAux.Address = reader["Direccion"].ToString();
                            lstProducts.Add(modelAux);
                        }

                        conn.Close();

                        return lstProducts;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo familias", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<Provider>();
                }
            }
        }

        public static List<Ubicacion> ObtenerUbicaciones()
        {
            List<Ubicacion> ubicaciones = new List<Ubicacion>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureObtenerUbicacion;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            Ubicacion modelAux = new Ubicacion();
                            modelAux.Id = Convert.ToInt32(reader["Id"]);
                            modelAux.Nombre = reader["Nombre"].ToString();
                            modelAux.Activo = Convert.ToBoolean(reader["Activo"].ToString());
                            modelAux.EsMatriz = Convert.ToBoolean(reader["EsMatriz"].ToString());
                            ubicaciones.Add(modelAux);
                        }

                        conn.Close();

                        return ubicaciones;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo ubicaciones", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<Ubicacion>();
                }
            }
        }

        public static List<TipoMovInventario> ObtenerTipoMovInventario()
        {
            List<TipoMovInventario> tipoMov = new List<TipoMovInventario>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureObtenerTipoMovInventario;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            TipoMovInventario modelAux = new TipoMovInventario();
                            modelAux.Id = Convert.ToInt32(reader["Id"]);
                            modelAux.Nombre = reader["Nombre"].ToString();
                            tipoMov.Add(modelAux);
                        }

                        conn.Close();

                        return tipoMov;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo tipo de mov de inventario", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<TipoMovInventario>();
                }
            }
        }

        public static List<HistoricoMovInv> ObtenerHistMovInventario(DateTime? fechaInicial, DateTime? fechaFinal, int idUbicacion, int idTipoMov, string producto)
        {
            List<HistoricoMovInv> movInv = new List<HistoricoMovInv>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureObtenerHistMovInventario;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@fechaInicial", fechaInicial);
                        sqlCommand.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                        sqlCommand.Parameters.AddWithValue("@idUbicacion", idUbicacion);
                        sqlCommand.Parameters.AddWithValue("@idTipoMov", idTipoMov);
                        sqlCommand.Parameters.AddWithValue("@producto", producto);
                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            HistoricoMovInv modelAux = new HistoricoMovInv();
                            modelAux.FechaMovimiento = Convert.ToDateTime(reader["Fecha_Movimiento"]);
                            modelAux.Movimiento = reader["Movimiento"].ToString();
                            modelAux.Ubicacion = reader["Ubicacion"].ToString();
                            modelAux.Pedimento = reader["Pedimento"].ToString();
                            modelAux.Producto = reader["Producto"].ToString();
                            modelAux.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                            movInv.Add(modelAux);
                        }

                        conn.Close();

                        return movInv;

                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error" + ex.ToString(), "Error obteniendo tipo de mov de inventario", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<HistoricoMovInv>();
                }
            }
        }

        /// <summary>
        /// Obtiene una lista del catalogo de marcas.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<ProductInOffert> GetProductsInOffert(string productName)
        {
            List<ProductInOffert> lst = new List<ProductInOffert>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetProductsInOffert;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Producto", System.Data.SqlDbType.VarChar, 60).Value = productName;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            ProductInOffert modelAux = new ProductInOffert();
                            modelAux.IdProductIntOffer = Convert.ToInt32(reader["IdProductoPrecioOferta"]);
                            modelAux.IdProduct = Convert.ToInt32(reader["IdProducto"]);
                            modelAux.ProductName = reader["Producto"].ToString();
                            modelAux.ProductDescription = reader["DescripcionProducto"].ToString();
                            modelAux.IdOfferType = Convert.ToInt32(reader["IdTipoOferta"]);
                            modelAux.OfferType = reader["Tipo_Oferta"].ToString();
                            modelAux.BeginDate = reader["Fecha_Inicio"] == DBNull.Value ? null : (DateTime?)(reader["fecha_Inicio"]);
                            modelAux.EndDate = reader["Fecha_Final"] == DBNull.Value ? null : (DateTime?)(reader["Fecha_Final"]);
                            modelAux.OffertPrice = Convert.ToDouble(reader["PrecioOferta"]);

                            lst.Add(modelAux);
                        }

                        conn.Close();

                        return lst;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo Precios en oferta", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<ProductInOffert>();
                }
            }
        }

        /// <summary>
        /// Obtiene una lista del catalogo de marcas.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<OfferType> GetOfferType(string offerTypeName)
        {
            List<OfferType> lst = new List<OfferType>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetOfferType;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@TipoOferta", System.Data.SqlDbType.VarChar, 60).Value = offerTypeName;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            OfferType modelAux = new OfferType();
                            modelAux.Id = Convert.ToInt32(reader["Id"]);
                            modelAux.OfferTypeName = reader["Tipo_Oferta"].ToString();
                            lst.Add(modelAux);
                        }

                        conn.Close();

                        return lst;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo familias", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<OfferType>();
                }
            }
        }

        /// <summary>
        /// Obtiene una lista de conceptos de pago.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<PaymentCondition> GetPaymentConditions(string name)
        {
            List<PaymentCondition> lstCoins = new List<PaymentCondition>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetPaymentCondition;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 60).Value = name;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            PaymentCondition modelAux = new PaymentCondition();
                            modelAux.Id = Convert.ToInt32(reader["Id"].ToString());
                            modelAux.Name = reader["Nombre"].ToString();
                            lstCoins.Add(modelAux);
                        }

                        conn.Close();

                        return lstCoins;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo conceptos de pago", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<PaymentCondition>();
                }
            }
        }

        /// <summary>
        /// Obtiene una lista de estados de compra.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<StatusBuy> GetStatusBuy(string name)
        {
            List<StatusBuy> lstCoins = new List<StatusBuy>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetStatusBuy;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 60).Value = name;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            StatusBuy modelAux = new StatusBuy();
                            modelAux.Id = Convert.ToInt32(reader["Id"].ToString());
                            modelAux.Name = reader["Nombre"].ToString();
                            modelAux.SendNotify = Convert.ToBoolean(reader["EnviaNotificacion"]);
                            lstCoins.Add(modelAux);
                        }

                        conn.Close();

                        return lstCoins;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo conceptos de pago", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<StatusBuy>();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<OrderBuy> GetOrdersBuy(DateTime beginDate, DateTime endDate)
        {
            List<OrderBuy> lstCoins = new List<OrderBuy>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetOrderBuy;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@BeginDate", System.Data.SqlDbType.Date).Value = beginDate;
                        sqlCommand.Parameters.Add("@EndDate", System.Data.SqlDbType.Date).Value = endDate;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            OrderBuy modelAux = new OrderBuy();
                            modelAux.Id = Convert.ToInt32(reader["Id"].ToString());
                            modelAux.IdProvider = Convert.ToInt32(reader["IdProveedor"].ToString());
                            modelAux.ProviderName = reader["Proveedor"].ToString();
                            modelAux.IdEmployeeBuyer = Convert.ToInt32(reader["IdEmpleadoComprador"].ToString());
                            modelAux.EmployeeBuyeerName = reader["EmpComprador"].ToString();
                            modelAux.IdEmployeeValidator = Convert.ToInt32(reader["IdEmpleadoValidador"].ToString());
                            modelAux.EmployeeValidatorName = reader["EmpValidador"].ToString();
                            modelAux.IdPaymentCondition = Convert.ToInt32(reader["IdCondicionPago"].ToString());
                            modelAux.ConditionPayment = reader["CondicionPago"].ToString();
                            modelAux.NumberOrderBuy = reader["OrdenCompra"].ToString();
                            modelAux.DateColocation = reader["FechaColocacion"] != DBNull.Value ? ((DateTime?)reader["FechaColocacion"]) : null;
                            modelAux.DateValidation = reader["FechaValidacion"] != DBNull.Value ? ((DateTime?)reader["FechaValidacion"]) : null;
                            modelAux.IdBuyStatus = Convert.ToInt32(reader["IdStatus"].ToString());
                            modelAux.StatusName = reader["EstatusCompra"].ToString();
                            modelAux.IsNotifyBuyStatus = Convert.ToBoolean(reader["EnviaNotificacion"]);

                            lstCoins.Add(modelAux);
                        }

                        conn.Close();

                        return lstCoins;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.ToString(), "Error obteniendo ordenes de compra", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<OrderBuy>();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<OrderBuyDetail> GetOrdersBuyDetail(int @idOrderBuy)
        {
            List<OrderBuyDetail> lstCoins = new List<OrderBuyDetail>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetDetailOrderBuy;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@IdOrdenCompra", System.Data.SqlDbType.Int).Value = @idOrderBuy;


                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            OrderBuyDetail modelAux = new OrderBuyDetail();
                            modelAux.Sequence = Convert.ToInt32(reader["Sequence"].ToString());
                            modelAux.ProductId = Convert.ToInt32(reader["IdProducto"].ToString());
                            modelAux.ProductName = reader["Producto"].ToString();
                            modelAux.ProductDescription = reader["ProductoDescripcion"].ToString();
                            modelAux.IdTrademark = Convert.ToInt32(reader["IdMarca"].ToString());
                            modelAux.TrademarkName = reader["Marca"].ToString();
                            modelAux.IdOrderBuy = Convert.ToInt32(reader["IdOrdenCompra"].ToString());
                            modelAux.IdProvider = Convert.ToInt32(reader["IdProveedor"].ToString());
                            modelAux.Total = reader["Costo"] != DBNull.Value ? Convert.ToDouble(reader["Costo"].ToString()) : 0;
                            modelAux.Pieces = Convert.ToInt32(reader["Piezas"].ToString());
                            modelAux.Price = Convert.ToDouble(reader["Precio"].ToString());

                            lstCoins.Add(modelAux);
                        }

                        conn.Close();

                        return lstCoins;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.ToString(), "Error obteniendo detalle de orden de compra", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<OrderBuyDetail>();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static void DelProduct(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureDelProduct;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@ProductId", System.Data.SqlDbType.VarChar).Value = id;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static bool DelFamily(int id, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureDelFamily;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static bool DeleteMarca(int id, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureDeleteMarca;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static bool DeleteColor(int id, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureDeleteColor;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static bool DelTrademark(int id, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureDelTrademark;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static bool DelModels(int id, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureDelModels;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static bool DelCoins(int id, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureDelCoins;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// Elimina un costo concepto
        /// </summary>
        /// <param name="id"></param>
        public static bool DelCosteConcept(int id, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureDelCosteConcept;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static bool DelProductInOffert(int id, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureDelPriceOffert;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static bool DelProviders(int id, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureDelProviders;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static bool DelPaymentCondition(int id, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureDelPaymentCondition;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// Elimina un estado de compra
        /// </summary>
        /// <param name="id"></param>
        public static bool DelStatusBuy(int id, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureDelStatusBuy;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// Elimina un estado de compra
        /// </summary>
        /// <param name="id"></param>
        public static bool DelOrderBuy(int id, ref int error, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureDelOrderBuy;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out error);

                        msg = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static bool UpdFamily(int id, string familia, string url, ref int errorCode, ref string messageError, int activo = 1)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureUpdFamily;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                        sqlCommand.Parameters.Add("@Familia", System.Data.SqlDbType.NVarChar, 50).Value = familia;
                        sqlCommand.Parameters.Add("@Url", System.Data.SqlDbType.NVarChar, 50).Value = url;
                        sqlCommand.Parameters.Add("@Activo", System.Data.SqlDbType.Int).Value = activo;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();


                        return errorCode >= 0;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static bool UpdateMarca(int id, string marca, ref int errorCode, ref string messageError, int activo = 1)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureUpdateMarca;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                        sqlCommand.Parameters.Add("@Marca", System.Data.SqlDbType.NVarChar, 50).Value = marca;
                        sqlCommand.Parameters.Add("@Activo", System.Data.SqlDbType.Int).Value = activo;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();


                        return errorCode >= 0;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static bool UpdateColor(int id, string color, string claveColor, ref int errorCode, ref string messageError, int activo = 1)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureUpdateColor;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                        sqlCommand.Parameters.Add("@Color", System.Data.SqlDbType.NVarChar, 50).Value = color;
                        sqlCommand.Parameters.Add("@ClaveColor", System.Data.SqlDbType.NVarChar, 20).Value = claveColor;
                        sqlCommand.Parameters.Add("@Activo", System.Data.SqlDbType.Int).Value = activo;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();


                        return errorCode >= 0;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static bool UpdTrademark(int id, string name, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureUpdTrademark;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 60).Value = name;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// Inserta una nueva familia en el catalogo de familias
        /// </summary>
        /// <param name="family"></param>
        public static bool UpdProducts(Product product)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureUpdProduct;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id_Producto", System.Data.SqlDbType.Int).Value = product.Id;
                        sqlCommand.Parameters.Add("@Id_Modelo", System.Data.SqlDbType.Int).Value = product.SelectedModel;
                        sqlCommand.Parameters.Add("@Id_Marca", System.Data.SqlDbType.Int).Value = product.SelectedTrademark;
                        sqlCommand.Parameters.Add("@Id_Familia", System.Data.SqlDbType.Int).Value = product.SelectedFamily;
                        sqlCommand.Parameters.Add("@Id_Moneda", System.Data.SqlDbType.Int).Value = product.SelectedCoin;
                        sqlCommand.Parameters.Add("@Clave_Proveedor", System.Data.SqlDbType.VarChar, 50).Value = product.Providers;
                        sqlCommand.Parameters.Add("@Clave_Teknobike", System.Data.SqlDbType.VarChar, 50).Value = product.TeknobikeKey;
                        sqlCommand.Parameters.Add("@Sku", System.Data.SqlDbType.VarChar, 50).Value = product.Sku;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 100).Value = product.Name;
                        sqlCommand.Parameters.Add("@Description", System.Data.SqlDbType.VarChar, 60).Value = product.Description;
                        sqlCommand.Parameters.Add("@Precio_Mayoreo", System.Data.SqlDbType.VarChar).Value = product.Wholesale;
                        sqlCommand.Parameters.Add("@Precio_Medio_Mayoreo", System.Data.SqlDbType.Decimal).Value = product.MediumWholesale;
                        sqlCommand.Parameters.Add("@Precio_Publico", System.Data.SqlDbType.Decimal).Value = product.PublicPrice;
                        sqlCommand.Parameters.Add("@Costo", System.Data.SqlDbType.Decimal).Value = product.Cost;
                        sqlCommand.Parameters.Add("@Piezas", System.Data.SqlDbType.Int).Value = product.Pieces;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        conn.Close();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return false;
                }
            }
        }


        /// <summary>
        /// Inserta una nueva familia en el catalogo de familias
        /// </summary>
        /// <param name="family"></param>
        public static bool UpdProviders(Provider provider, ref string msgError)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureUpdProviders;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = provider.Id;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 100).Value = provider.Name;
                        sqlCommand.Parameters.Add("@RFC", System.Data.SqlDbType.VarChar, 100).Value = provider.Rfc;
                        sqlCommand.Parameters.Add("@Direccion", System.Data.SqlDbType.VarChar, 100).Value = provider.Address;
                        conn.Open();

                        sqlCommand.ExecuteNonQuery();

                        conn.Close();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    msgError = ex.ToString();
                    return false;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static bool UpdModels(int id, string name, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureUpdModels;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 60).Value = name;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static bool UpdCoins(int id, string name, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureUpdCoins;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 60).Value = name;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static bool UpdCosteConcept(int id, string name, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureUpdCosteConcept;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 60).Value = name;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static bool UpdPriceInOffert(int id, int idProduct, int idOffertType, double price, DateTime? beginDate, DateTime? endDate, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;



                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureUpdPriceOffert;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                        sqlCommand.Parameters.Add("@Id_Producto", System.Data.SqlDbType.Int).Value = idProduct;
                        sqlCommand.Parameters.Add("@Id_Producto_Tipo_Oferta", System.Data.SqlDbType.Int).Value = idOffertType;
                        sqlCommand.Parameters.Add("@Precio", System.Data.SqlDbType.Decimal).Value = price;
                        sqlCommand.Parameters.Add("@Fecha_Inicio", System.Data.SqlDbType.Date).Value = beginDate;
                        sqlCommand.Parameters.Add("@Fecha_Final", System.Data.SqlDbType.Date).Value = endDate;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static bool UpdPaymentCondition(int id, string name, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureUpdPaymentCondition;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 60).Value = name;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static bool UpdStatusBuy(int id, string name, bool sendNotify, ref int errorCode, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureUpdStatusBuy;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 60).Value = name;
                        sqlCommand.Parameters.Add("@EnviaNotificacion", System.Data.SqlDbType.Bit).Value = sendNotify;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        msg = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    errorCode = -1;
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// Ingresa un nuevo estatus de compra
        /// </summary>
        /// <param name="name">concepto de pago</param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <returns></returns>
        public static bool UpdOrderBuy(OrderBuy model, ref int error, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureUpdOrderBuy;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = model.Id;
                        sqlCommand.Parameters.Add("@IdProveedor", System.Data.SqlDbType.Int).Value = model.IdProvider;
                        sqlCommand.Parameters.Add("@IdEmpleadoComprador", System.Data.SqlDbType.Int).Value = model.IdEmployeeBuyer;
                        sqlCommand.Parameters.Add("@IdEmpleadoValidador", System.Data.SqlDbType.Int).Value = model.IdEmployeeValidator;
                        sqlCommand.Parameters.Add("@IdCondicionPago", System.Data.SqlDbType.Int).Value = model.IdPaymentCondition;
                        sqlCommand.Parameters.Add("@OrdenCompra", System.Data.SqlDbType.VarChar, 30).Value = model.NumberOrderBuy;
                        sqlCommand.Parameters.Add("@FechaColocacion", System.Data.SqlDbType.Date).Value = model.DateColocation;
                        sqlCommand.Parameters.Add("@FechaValidacion", System.Data.SqlDbType.Date).Value = model.DateValidation;
                        sqlCommand.Parameters.Add("@IdStatus", System.Data.SqlDbType.Int).Value = model.IdBuyStatus;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@Message", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();


                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out error);
                        msg = sqlCommand.Parameters["@Message"].Value.ToString();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    error = -1;
                    msg = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="medida"></param>
        /// <param name="claveMedida"></param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <param name="activo"></param>
        /// <returns></returns>
        public static bool InsertMedida(string medida, string claveMedida, ref int errorCode, ref string messageError, int activo = 1)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsertMedida;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Medida", System.Data.SqlDbType.NVarChar, 40).Value = medida;
                        sqlCommand.Parameters.Add("@ClaveMedida", System.Data.SqlDbType.NVarChar, 10).Value = claveMedida;
                        sqlCommand.Parameters.Add("@Activo", System.Data.SqlDbType.Int).Value = activo;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();

                        return errorCode >= 0;

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="medida"></param>
        /// <param name="claveMedida"></param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <param name="activo"></param>
        /// <returns></returns>
        public static bool UpdateMedida(int id, string medida, string claveMedida, ref int errorCode, ref string messageError, int activo = 1)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureUpdateMedida;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                        sqlCommand.Parameters.Add("@Medida", System.Data.SqlDbType.NVarChar, 40).Value = medida;
                        sqlCommand.Parameters.Add("@ClaveMedida", System.Data.SqlDbType.NVarChar, 10).Value = claveMedida;
                        sqlCommand.Parameters.Add("@Activo", System.Data.SqlDbType.Int).Value = activo;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();


                        return errorCode >= 0;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="medida"></param>
        /// <param name="claveMedida"></param>
        /// <returns></returns>
        public static List<Measure> GetMedidas(string medida, string claveMedida)
        {
            List<Measure> lstMedidas = new List<Measure>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetMedidas;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Medida", System.Data.SqlDbType.NVarChar, 40).Value = medida;
                        sqlCommand.Parameters.Add("@ClaveMedida", System.Data.SqlDbType.NVarChar, 10).Value = claveMedida;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            Measure modelAux = new Measure();
                            modelAux.Id = reader.GetInt32(0);
                            modelAux.MedidaString = reader.GetString(1);
                            modelAux.ClaveMedida = reader.GetString(2);
                            modelAux.Active = (reader.GetInt32(3) > 0);
                            lstMedidas.Add(modelAux);
                        }

                        conn.Close();

                        return lstMedidas;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo medidas", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<Measure>();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool DeleteMedida(int id, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureDeleteMedida;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idFamilia"></param>
        /// <param name="subFamilia"></param>
        /// <param name="url"></param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <param name="activo"></param>
        /// <returns></returns>
        public static bool InsertSubFamily(int idFamilia, string subFamilia, string url, ref int errorCode, ref string messageError, int activo = 1)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsertSubFamilia;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@IdFamilia", System.Data.SqlDbType.Int).Value = idFamilia;
                        sqlCommand.Parameters.Add("@SubFamilia", System.Data.SqlDbType.NVarChar, 50).Value = subFamilia;
                        sqlCommand.Parameters.Add("@Url", System.Data.SqlDbType.NVarChar, 50).Value = url;
                        sqlCommand.Parameters.Add("@Activo", System.Data.SqlDbType.Int).Value = activo;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();

                        return errorCode >= 0;

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idFamilia"></param>
        /// <param name="subFamilia"></param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <param name="activo"></param>
        /// <returns></returns>
        public static bool UpdateSubFamilia(int id, int idFamilia, string subFamilia, string url, ref int errorCode, ref string messageError, int activo = 1)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureUpdateSubFamilia;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                        sqlCommand.Parameters.Add("@IdFamilia", System.Data.SqlDbType.Int).Value = idFamilia;
                        sqlCommand.Parameters.Add("@SubFamilia", System.Data.SqlDbType.NVarChar, 50).Value = subFamilia;
                        sqlCommand.Parameters.Add("@Url", System.Data.SqlDbType.NVarChar, 50).Value = url;
                        sqlCommand.Parameters.Add("@Activo", System.Data.SqlDbType.Int).Value = activo;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();


                        return errorCode >= 0;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idFamilia"></param>
        /// <param name="subFamilia"></param>
        /// <returns></returns>
        public static List<SubFamilies> GetSubFamilias(int idFamilia, string subFamilia, string family)
        {
            List<SubFamilies> lstMedidas = new List<SubFamilies>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetSubFamilias;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@IdFamilia", System.Data.SqlDbType.Int).Value = idFamilia;
                        sqlCommand.Parameters.Add("@SubFamilia", System.Data.SqlDbType.NVarChar, 50).Value = subFamilia;
                        sqlCommand.Parameters.Add("@Familia", System.Data.SqlDbType.NVarChar, 50).Value = family;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            SubFamilies modelAux = new SubFamilies();
                            modelAux.Id = reader.GetInt32(0);
                            modelAux.IdFamilia = reader.GetInt32(1);
                            modelAux.SubFamilyName = reader.GetString(2);
                            modelAux.Url = reader.GetString(3);
                            modelAux.Active = (reader.GetInt32(4) > 0);
                            modelAux.FamilyName = reader.GetString(5);
                            lstMedidas.Add(modelAux);
                        }

                        conn.Close();

                        return lstMedidas;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo subfamilias", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<SubFamilies>();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool DeleteSubFamilia(int id, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureDeleteSubFamilia;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<Models> GetModels(string model)
        {
            List<Models> lstModels = new List<Models>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetModelos;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Modelo", System.Data.SqlDbType.NVarChar, 50).Value = model;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            Models modelAux = new Models();
                            modelAux.Id = reader.GetInt32(0);
                            modelAux.Model = reader.GetString(1);
                            modelAux.Active = reader.GetBoolean(2);
                            lstModels.Add(modelAux);
                        }

                        conn.Close();

                        return lstModels;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo modelos", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<Models>();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelo"></param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <param name="activo"></param>
        /// <returns></returns>
        public static bool InsertModelo(string modelo, ref int errorCode, ref string messageError, int activo = 1)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsertModelo;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Modelo", System.Data.SqlDbType.NVarChar, 50).Value = modelo;
                        sqlCommand.Parameters.Add("@Activo", System.Data.SqlDbType.Int).Value = activo;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();

                        return errorCode >= 0;

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="modelo"></param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <param name="activo"></param>
        /// <returns></returns>
        public static bool UpdateModelo(int id, string modelo, ref int errorCode, ref string messageError, int activo = 1)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureUpdateModelo;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                        sqlCommand.Parameters.Add("@Modelo", System.Data.SqlDbType.NVarChar, 50).Value = modelo;
                        sqlCommand.Parameters.Add("@Activo", System.Data.SqlDbType.Int).Value = activo;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();


                        return errorCode >= 0;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool DeleteModelo(int id, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureDeleteModelo;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        ///
        public static bool InsertProducto(Product product, ref int errorCode, ref string messageError)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsertProducto;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@ID_MODELO", System.Data.SqlDbType.Int).Value = product.IdModel;
                        sqlCommand.Parameters.Add("@ID_SUBFAMILIA", System.Data.SqlDbType.Int).Value = product.IdSubFamily;
                        sqlCommand.Parameters.Add("@ID_MARCA", System.Data.SqlDbType.Int).Value = product.IdTrademark;
                        sqlCommand.Parameters.Add("@ID_MEDIDA", System.Data.SqlDbType.Int).Value = product.IdMeasure;
                        sqlCommand.Parameters.Add("@ID_COLOR", System.Data.SqlDbType.Int).Value = product.IdColor;
                        sqlCommand.Parameters.Add("@ID_MONEDA", System.Data.SqlDbType.SmallInt).Value = product.IdCoin;
                        sqlCommand.Parameters.Add("@ID_PROVEEDOR", System.Data.SqlDbType.Int).Value = product.IdProvider;
                        sqlCommand.Parameters.Add("@CVE_PROVEEDOR", System.Data.SqlDbType.VarChar, 50).Value = product.CveProvider;
                        sqlCommand.Parameters.Add("@CVE_TEKNOBIKE", System.Data.SqlDbType.VarChar, 50).Value = product.CveTeknobike;
                        sqlCommand.Parameters.Add("@NOMBRE", System.Data.SqlDbType.VarChar, 250).Value = product.Name;
                        sqlCommand.Parameters.Add("@IMAGEN", System.Data.SqlDbType.VarChar, 60).Value = String.IsNullOrEmpty(product.Image) ? "Ninguna" : product.Image;
                        sqlCommand.Parameters.Add("@DESCRIPCION", System.Data.SqlDbType.Text).Value = product.Description;

                        SqlParameter parameterWholesale = sqlCommand.Parameters.Add("@PRECIO_MAYOREO", System.Data.SqlDbType.Decimal);
                        parameterWholesale.Value = product.Wholesale;
                        parameterWholesale.Precision = 18;
                        parameterWholesale.Scale = 2;

                        SqlParameter parameterMediumWholesale = sqlCommand.Parameters.Add("@PRECIO_MEDIO_MAYOREO", System.Data.SqlDbType.Decimal);
                        parameterMediumWholesale.Value = product.MediumWholesale;
                        parameterMediumWholesale.Precision = 18;
                        parameterMediumWholesale.Scale = 2;

                        SqlParameter parameterPublicPrice = sqlCommand.Parameters.Add("@PRECIO_PUBLICO", System.Data.SqlDbType.Decimal);
                        parameterPublicPrice.Value = product.PublicPrice;
                        parameterPublicPrice.Precision = 18;
                        parameterPublicPrice.Scale = 2;

                        SqlParameter parameterCost = sqlCommand.Parameters.Add("@COSTO", System.Data.SqlDbType.Decimal);
                        parameterCost.Value = product.Cost;
                        parameterCost.Precision = 18;
                        parameterCost.Scale = 2;

                        sqlCommand.Parameters.Add("@INTERNET", System.Data.SqlDbType.Bit).Value = product.Internet;
                        sqlCommand.Parameters.Add("@Activo", System.Data.SqlDbType.Int).Value = product.Active;

                        sqlCommand.Parameters.Add("@preciodistribuidor", System.Data.SqlDbType.Float).Value = product.PrecioDistribuidor;
                        sqlCommand.Parameters.Add("@addvalorem", System.Data.SqlDbType.Float).Value = product.AddValorioum;
                        sqlCommand.Parameters.Add("@IGI", System.Data.SqlDbType.Float).Value = product.IGI;
                        sqlCommand.Parameters.Add("@impuesto3", System.Data.SqlDbType.Float).Value = product.Impuesto3;
                        sqlCommand.Parameters.Add("@UPC", System.Data.SqlDbType.VarChar).Value = product.UPC;
                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();

                        return errorCode >= 0;

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static List<Product> GetProducts(string product, string description, int idMatriz)
        {
            List<Product> lstProduct = new List<Product>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetProductos;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 250).Value = product;
                        sqlCommand.Parameters.Add("@Descripcion", System.Data.SqlDbType.Text).Value = description;
                        sqlCommand.Parameters.Add("@Matriz", System.Data.SqlDbType.Int).Value = idMatriz;
                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            Product productAux = new Product();
                            productAux.Id = Convert.ToInt32(reader["IdProducto"]);
                            productAux.CveProvider = reader["cve_proveedor"].ToString();
                            productAux.CveTeknobike = reader["cve_teknobike"].ToString();
                            productAux.Name = reader["nombre"].ToString();
                            productAux.Image = reader["imagen"].ToString();
                            productAux.Description = reader["descripcion"].ToString();
                            productAux.Wholesale = Convert.ToDouble(reader["precio_mayoreo"]);
                            productAux.MediumWholesale = Convert.ToDouble(reader["precio_medio_mayoreo"]);
                            productAux.PublicPrice = Convert.ToDouble(reader["precio_publico"]);
                            productAux.Cost = Convert.ToDouble(reader["costo"]);
                            productAux.Internet = Convert.ToBoolean(reader["internet"]);
                            productAux.IdFamily = Convert.ToInt32(reader["IdFamilia"]);
                            productAux.SelectedFamily = reader["familia"].ToString();
                            productAux.IdColor = Convert.ToInt32(reader["IdColor"]);
                            productAux.ColorName = reader["color"].ToString();
                            productAux.IdModel = Convert.ToInt32(reader["IdModelo"]);
                            productAux.SelectedModel = reader["modelo"].ToString();
                            productAux.IdTrademark = Convert.ToInt32(reader["IdMarca"]);
                            productAux.SelectedTrademark = reader["marca"].ToString();
                            productAux.IdMeasure = Convert.ToInt32(reader["IdMedida"]);
                            productAux.MeasureName = reader["medida"].ToString();

                            productAux.IdSubFamily = Convert.ToInt32(reader["IdSubFamilia"]);
                            productAux.SubFamilyName = reader["subfamilia"].ToString();
                            productAux.UltimaCompra = reader["UltimaCompra"].ToString();
                            productAux.UltimaVenta = reader["ultimasVentas"].ToString();
                            productAux.PrecioDistribuidor = Convert.ToDouble(reader["PrecioDistribuidor"]);
                            productAux.AddValorioum = Convert.ToDouble(reader["addvalorem"]);
                            productAux.IGI = Convert.ToDouble(reader["IGI"]);
                            productAux.Impuesto3 = Convert.ToDouble(reader["porcento3"]);
                            productAux.IdProvider = Convert.ToInt32(reader["id_proveedor"]);
                            productAux.InventarioTotal = Convert.ToInt32(reader["InventarioTotal"]);
                            productAux.Inventario = Convert.ToInt32(reader["Inventario"]);
                            productAux.UPC = reader["UPC"].ToString();
                            lstProduct.Add(productAux);
                        }

                        conn.Close();

                        return lstProduct;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo productos", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<Product>();
                }
            }
        }

        //public static List<Product> GetProducts(string product, string description)
        //{
        //    List<Product> lstProduct = new List<Product>();

        //    using (SqlConnection conn = new SqlConnection())
        //    {
        //        try
        //        {
        //            conn.ConnectionString = connectionString;

        //            using (SqlCommand sqlCommand = new SqlCommand())
        //            {
        //                sqlCommand.Connection = conn;
        //                sqlCommand.CommandText = Constants.ProcedureGetProductos;
        //                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //                sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 250).Value = product;
        //                sqlCommand.Parameters.Add("@Descripcion", System.Data.SqlDbType.Text).Value = description;

        //                conn.Open();

        //                var reader = sqlCommand.ExecuteReader();

        //                while (reader.Read())
        //                {
        //                    Product productAux = new Product();
        //                    productAux.Id = reader.GetInt32(0);
        //                    productAux.CveProvider = reader.GetString(4);
        //                    productAux.CveTeknobike = reader.GetString(5);
        //                    productAux.Name = reader.GetString(6);
        //                    productAux.Image = reader.GetString(7);
        //                    productAux.Description = reader.GetString(8);
        //                    productAux.Wholesale = (double)reader.GetDecimal(9);
        //                    productAux.MediumWholesale = (double)reader.GetDecimal(10);
        //                    productAux.PublicPrice = (double)reader.GetDecimal(11);
        //                    productAux.Cost = (double)reader.GetDecimal(12);
        //                    productAux.Internet = reader.GetBoolean(13);
        //                    productAux.IdFamily = reader.GetInt32(15);
        //                    productAux.SelectedFamily = reader.GetString(16);
        //                    productAux.IdColor = reader.GetInt32(17);
        //                    productAux.ColorName = reader.GetString(18);
        //                    productAux.IdModel = reader.GetInt32(19);
        //                    productAux.SelectedModel = reader.GetString(20);
        //                    productAux.IdTrademark = reader.GetInt32(21);
        //                    productAux.SelectedTrademark = reader.GetString(22);
        //                    productAux.IdMeasure = reader.GetInt32(23);
        //                    productAux.MeasureName = reader.GetString(24);

        //                    lstProduct.Add(productAux);
        //                }

        //                conn.Close();

        //                return lstProduct;

        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error" + ex.ToString(), "Error obteniendo productos", MessageBoxButton.OK, MessageBoxImage.Error);
        //            return new List<Product>();
        //        }
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="errorCode"></param>
        /// <param name="messageError"></param>
        /// <param name="activo"></param>
        /// <returns></returns>
        public static bool UpdateProducto(Product product, ref int errorCode, ref string messageError, int activo = 1)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureUpdateProducto;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = product.Id;
                        sqlCommand.Parameters.Add("@ID_MODELO", System.Data.SqlDbType.Int).Value = product.IdModel;
                        sqlCommand.Parameters.Add("@ID_SUBFAMILIA", System.Data.SqlDbType.Int).Value = product.IdSubFamily;
                        sqlCommand.Parameters.Add("@ID_MARCA", System.Data.SqlDbType.Int).Value = product.IdTrademark;
                        sqlCommand.Parameters.Add("@ID_MEDIDA", System.Data.SqlDbType.Int).Value = product.IdMeasure;
                        sqlCommand.Parameters.Add("@ID_COLOR", System.Data.SqlDbType.Int).Value = product.IdColor;
                        sqlCommand.Parameters.Add("@ID_MONEDA", System.Data.SqlDbType.SmallInt).Value = product.IdCoin;
                        sqlCommand.Parameters.Add("@ID_PROVEEDOR", System.Data.SqlDbType.Int).Value = product.IdProvider;
                        sqlCommand.Parameters.Add("@CVE_PROVEEDOR", System.Data.SqlDbType.VarChar, 50).Value = product.CveProvider;
                        sqlCommand.Parameters.Add("@CVE_TEKNOBIKE", System.Data.SqlDbType.VarChar, 50).Value = product.CveTeknobike;
                        sqlCommand.Parameters.Add("@NOMBRE", System.Data.SqlDbType.VarChar, 250).Value = product.Name;
                        sqlCommand.Parameters.Add("@IMAGEN", System.Data.SqlDbType.VarChar, 60).Value = product.Image;
                        sqlCommand.Parameters.Add("@DESCRIPCION", System.Data.SqlDbType.Text).Value = product.Description;

                        SqlParameter parameterWholesale = sqlCommand.Parameters.Add("@PRECIO_MAYOREO", System.Data.SqlDbType.Decimal);
                        parameterWholesale.Value = product.Wholesale;
                        parameterWholesale.Precision = 18;
                        parameterWholesale.Scale = 2;

                        SqlParameter parameterMediumWholesale = sqlCommand.Parameters.Add("@PRECIO_MEDIO_MAYOREO", System.Data.SqlDbType.Decimal);
                        parameterMediumWholesale.Value = product.MediumWholesale;
                        parameterMediumWholesale.Precision = 18;
                        parameterMediumWholesale.Scale = 2;

                        SqlParameter parameterPublicPrice = sqlCommand.Parameters.Add("@PRECIO_PUBLICO", System.Data.SqlDbType.Decimal);
                        parameterPublicPrice.Value = product.PublicPrice;
                        parameterPublicPrice.Precision = 18;
                        parameterPublicPrice.Scale = 2;

                        SqlParameter parameterCost = sqlCommand.Parameters.Add("@COSTO", System.Data.SqlDbType.Decimal);
                        parameterCost.Value = product.Cost;
                        parameterCost.Precision = 18;
                        parameterCost.Scale = 2;

                        sqlCommand.Parameters.Add("@preciodistribuidor", System.Data.SqlDbType.Float).Value = product.PrecioDistribuidor;
                        sqlCommand.Parameters.Add("@addvalorem", System.Data.SqlDbType.Float).Value = product.AddValorioum;
                        sqlCommand.Parameters.Add("@IGI", System.Data.SqlDbType.Float).Value = product.IGI;
                        sqlCommand.Parameters.Add("@impuesto3", System.Data.SqlDbType.Float).Value = product.Impuesto3;
                        sqlCommand.Parameters.Add("@upc", System.Data.SqlDbType.VarChar).Value = product.UPC;
                        sqlCommand.Parameters.Add("@INTERNET", System.Data.SqlDbType.Bit).Value = product.Internet;
                        sqlCommand.Parameters.Add("@Activo", System.Data.SqlDbType.Int).Value = product.Active;

                        sqlCommand.Parameters.Add("@Error", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@ErrorMessage", System.Data.SqlDbType.VarChar, 200).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@Error"].Value.ToString(), out errorCode);

                        messageError = sqlCommand.Parameters["@ErrorMessage"].Value.ToString();

                        conn.Close();

                        return errorCode >= 0;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    errorCode = -1;
                    messageError = ex.ToString();
                    return false;
                }
            }
        }

        public static bool DeleteProducto(int id, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureDeleteProducto;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="marca"></param>
        /// <returns></returns>
        public static List<Provider> GetSuppliers(int IdSupplier)
        {
            List<Provider> lstSuppliers = new List<Provider>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetSuppliers;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id_supplier", System.Data.SqlDbType.Int).Value = IdSupplier;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            Provider supplierAux = new Provider();
                            supplierAux.Id = Convert.ToInt32(reader["id"]);
                            supplierAux.Name = reader["nombre"].ToString();
                            supplierAux.CompanyName = reader["razon_social"].ToString();
                            supplierAux.Address = reader["direccion"].ToString();
                            supplierAux.Correo = reader["correo"].ToString();
                            supplierAux.Rfc = reader["RFC"].ToString();
                            supplierAux.IdTipoPago = reader["IdTipoPago"] == DBNull.Value ? -1 : Convert.ToInt32(reader["IdTipoPago"]);
                            supplierAux.TipoPago = reader["TipoPago"] == DBNull.Value ? string.Empty : reader["TipoPago"].ToString();
                            supplierAux.CantidadDeDias = reader["dias"] == DBNull.Value ? 0 : Convert.ToInt32(reader["dias"]);
                            lstSuppliers.Add(supplierAux);
                        }

                        conn.Close();

                        return lstSuppliers;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo proveedores", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<Provider>();
                }
            }
        }

        public static void AdminProveedores(int IdSupplier, string nombre, string razon, string direccion, string correo, string rfc, int accion, int idTipoPago, int dias)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.AdminProveedores;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = IdSupplier;
                        sqlCommand.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = nombre;
                        sqlCommand.Parameters.Add("@razonsocial", System.Data.SqlDbType.VarChar).Value = razon;
                        sqlCommand.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = direccion;
                        sqlCommand.Parameters.Add("@correo", System.Data.SqlDbType.VarChar).Value = correo;
                        sqlCommand.Parameters.Add("@rfc", System.Data.SqlDbType.VarChar).Value = rfc;
                        sqlCommand.Parameters.Add("@accion", System.Data.SqlDbType.Int).Value = accion;
                        sqlCommand.Parameters.Add("@idTipoPago", System.Data.SqlDbType.Int).Value = idTipoPago;
                        sqlCommand.Parameters.Add("@noDias", System.Data.SqlDbType.Int).Value = dias;
                        conn.Open();

                        sqlCommand.ExecuteNonQuery();

                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error proveedores", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdSupplier"></param>
        /// <returns></returns>
        public static List<TypePay> GetTypePay()
        {
            List<TypePay> lstTypePay = new List<TypePay>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetTypePay;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            TypePay TypePayAux = new TypePay();
                            TypePayAux.Id = reader.GetInt32(0);
                            TypePayAux.description = reader.GetString(1);
                            TypePayAux.Active = reader.GetBoolean(2);
                            lstTypePay.Add(TypePayAux);
                        }

                        conn.Close();

                        return lstTypePay;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo tipos de pagos", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<TypePay>();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ob"></param>
        /// <returns></returns>
        public static int InsertOrderBuy(OrderBuy ob, int accion)
        {

            int id_order = 0;

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsertOrderBuy;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@Id_proveedor", System.Data.SqlDbType.Int).Value = ob.IdProvider;
                        sqlCommand.Parameters.Add("@Info_factura", System.Data.SqlDbType.NVarChar, 500).Value = "EJEMPLO";
                        sqlCommand.Parameters.Add("@direccion_envio", System.Data.SqlDbType.VarChar, 500).Value = DBNull.Value;
                        sqlCommand.Parameters.Add("@fecha_emision", System.Data.SqlDbType.DateTime).Value = ob.FechaEmision;
                        sqlCommand.Parameters.Add("@fecha_entrega", System.Data.SqlDbType.DateTime).Value = ob.FechaEntrega;
                        sqlCommand.Parameters.Add("@nombre_comprador", System.Data.SqlDbType.VarChar).Value = "";
                        sqlCommand.Parameters.Add("@nombre_validador", System.Data.SqlDbType.VarChar).Value = "";
                        //sqlCommand.Parameters.Add("@id_tipo_pago", System.Data.SqlDbType.Int).Value = ob.IdPaymentCondition;
                        //sqlCommand.Parameters.Add("@dias", System.Data.SqlDbType.Int).Value = ob.Dias;
                        sqlCommand.Parameters.Add("@idUsuario", System.Data.SqlDbType.Int).Value = ob.idGenerador;
                        sqlCommand.Parameters.Add("@accion", System.Data.SqlDbType.Int).Value = accion;
                        sqlCommand.Parameters.Add("@IDIN", System.Data.SqlDbType.Int).Value = ob.Id;
                        sqlCommand.Parameters.Add("@idUbicacion", System.Data.SqlDbType.Int).Value = ob.IdUbicacion;
                        sqlCommand.Parameters.Add("@id_orden_out", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@id_orden_out"].Value.ToString(), out id_order);

                        conn.Close();

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    id_order = -1;
                    throw ex;
                }
            }

            return id_order;
        }


        public static int InsertOrderBuyDetail(DetalleOrdenCompraModel obd)
        {

            int aux = 1;

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsertOrderBuyDetail;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        obd.Quantity = obd.Recibido;
                        obd.Amount = obd.Monto;
                        sqlCommand.Parameters.Add("@Id_Orden", System.Data.SqlDbType.Int).Value = obd.Id_OrderBuy;
                        sqlCommand.Parameters.Add("@Id_Producto", System.Data.SqlDbType.Int).Value = obd.IdProduct;
                        sqlCommand.Parameters.Add("@cantidad", System.Data.SqlDbType.Int).Value = obd.Quantity;
                        sqlCommand.Parameters.Add("@precio_unitario", System.Data.SqlDbType.Decimal).Value = obd.UnitPrice;
                        sqlCommand.Parameters.Add("@UOM", System.Data.SqlDbType.VarChar, 500).Value = "";
                        sqlCommand.Parameters.Add("@impuestos", System.Data.SqlDbType.Decimal).Value = obd.Tax;
                        sqlCommand.Parameters.Add("@monto", System.Data.SqlDbType.Decimal).Value = obd.Amount;
                        // no aplica en la tabla
                        //sqlCommand.Parameters.Add("@descripcion", System.Data.SqlDbType.VarChar).Value = obd.ProductDescription;
                        //sqlCommand.Parameters.Add("@fecha_Entrega", System.Data.SqlDbType.DateTime).Value = obd.DateOutPut;
                        sqlCommand.Parameters.Add("@linea", System.Data.SqlDbType.Int).Value = obd.Line;
                        sqlCommand.Parameters.Add("@iddetalle", System.Data.SqlDbType.Int).Value = obd.Id;

                        conn.Open();

                        sqlCommand.ExecuteNonQuery();

                        conn.Close();

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    aux = -1;
                    throw ex;
                }
            }

            return aux;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<OrderBuy> GetOC(int? idOC, DateTime? fecha_emision = null, DateTime? fecha_entrega = null)
        {
            List<OrderBuy> lstOC = new List<OrderBuy>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetOC;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        if (idOC.HasValue)
                            sqlCommand.Parameters.Add("@IdOC", System.Data.SqlDbType.Int).Value = idOC.Value;
                        else
                            sqlCommand.Parameters.Add("@IdOC", System.Data.SqlDbType.Int).Value = DBNull.Value;

                        if (fecha_emision.HasValue)
                            sqlCommand.Parameters.Add("@FechaEmision", System.Data.SqlDbType.DateTime).Value = fecha_emision.Value;
                        else
                            sqlCommand.Parameters.Add("@FechaEmision", System.Data.SqlDbType.DateTime).Value = DBNull.Value;

                        if (fecha_entrega.HasValue)
                            sqlCommand.Parameters.Add("@FechaEntrega", System.Data.SqlDbType.DateTime).Value = fecha_entrega.Value;
                        else
                            sqlCommand.Parameters.Add("@FechaEntrega", System.Data.SqlDbType.DateTime).Value = DBNull.Value;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            OrderBuy OC = new OrderBuy();
                            OC.Id = reader.GetInt32(0);
                            OC.IdProvider = reader.GetInt32(1);
                            OC.Direccion_Envio = reader.GetString(2);
                            OC.FechaEmision = reader.GetDateTime(3);
                            OC.FechaEntrega = reader.GetDateTime(4);
                            OC.StatusName = reader.GetString(5);
                            OC.Dias = reader.GetInt32(6);
                            OC.ConditionPayment = reader.GetString(7);
                            OC.ProviderName = reader.GetString(8);
                            lstOC.Add(OC);
                        }

                        conn.Close();

                        return lstOC;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo ordenes de compra", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<OrderBuy>();
                }
            }
        }

        public static List<OrdenesDisponibles> ObtenerOrdenesDisp(int? OCseleccionada, int? idProvSeleccionado, string estatus)
        {
            List<OrdenesDisponibles> lstOC = new List<OrdenesDisponibles>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureObtenerOrdenesDisp;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@OrdenDeCompra", System.Data.SqlDbType.Int).Value = OCseleccionada == null ? DBNull.Value : (object)OCseleccionada;
                        sqlCommand.Parameters.Add("@IdProveedor", System.Data.SqlDbType.Int).Value = idProvSeleccionado == null ? DBNull.Value : (object)idProvSeleccionado;
                        sqlCommand.Parameters.Add("@Status", System.Data.SqlDbType.VarChar).Value = String.IsNullOrEmpty(estatus) == null ? DBNull.Value : (object)estatus;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            var OC = new OrdenesDisponibles();
                            OC.IdOrden = Convert.ToInt32(reader["IdOrden"]);
                            OC.NombreProveedor = reader["Proveedor"].ToString();
                            OC.IdProveedor = Convert.ToInt32(reader["idProveedor"]);
                            OC.FechaEmision = Convert.ToDateTime(reader["fecha_emision"]);
                            OC.FechaEntrega = reader["fecha_entrega"] == DBNull.Value ? null : (DateTime?)reader["fecha_entrega"];
                            OC.CodigoEstado = reader["Estatus"].ToString();
                            OC.CondicionPagoNombre = reader["TipoPago"].ToString();
                            OC.Dias = Convert.ToInt32(reader["dias"]);
                            OC.CorreoProveedor = reader["CorreoProv"] == DBNull.Value ? "" : reader["CorreoProv"].ToString();
                            OC.DetalleOc = reader["detalleOC"] == DBNull.Value ? "" : reader["detalleOC"].ToString();
                            OC.Total = reader["Total"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Total"]);

                            OC.idGenerador = reader["idUsuarioGenera"] == DBNull.Value ? null : (int?)(reader["idUsuarioGenera"]);
                            OC.IdRecibe = reader["idUsuarioRecibe"] == DBNull.Value ? null : (int?)(reader["idUsuarioRecibe"]);
                            OC.IdAutoriza = reader["idUsuarioAutoriza"] == DBNull.Value ? null : (int?)(reader["idUsuarioAutoriza"]);

                            OC.Genera = reader["Genera"] == DBNull.Value ? "" : reader["Genera"].ToString();
                            OC.Recibe = reader["Recibe"] == DBNull.Value ? "" : reader["Recibe"].ToString();
                            OC.Autoriza = reader["Autoriza"] == DBNull.Value ? "" : reader["Autoriza"].ToString();
                            OC.RutaFoto = reader["RutaArchivo"] == DBNull.Value ? "" : reader["RutaArchivo"].ToString();

                            OC.IdUbicacion = Convert.ToInt32(reader["idUbicacion"]);
                            OC.Ubicacion = reader["Ubicacion"].ToString();

                            lstOC.Add(OC);
                        }

                        conn.Close();

                        return lstOC;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo ordenes de compra", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<OrdenesDisponibles>();
                }
            }
        }

        public static List<DetalleOrdenCompraModel> ObtenerDetalleOrden(int idOC)
        {
            List<DetalleOrdenCompraModel> lstOCDetalle = new List<DetalleOrdenCompraModel>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureObtenerDetalleOC;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@idOrdenCompra", System.Data.SqlDbType.Int).Value = idOC;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            DetalleOrdenCompraModel OCD = new DetalleOrdenCompraModel();

                            OCD.CveTecnobike = reader.GetString(0);
                            OCD.CveProveedor = reader.GetString(1);
                            OCD.Nombre = reader.GetString(3);
                            OCD.Quantity = reader.GetInt32(4);
                            OCD.UnitPrice = (double)reader.GetDecimal(5);
                            OCD.Tax = (double)reader.GetDecimal(6);
                            OCD.Amount = (double)reader.GetDecimal(7);
                            OCD.UOM = reader.GetString(8);
                            OCD.Id = reader.GetInt32(9);
                            OCD.Id_OrderBuy = reader.GetInt32(10);
                            OCD.Total = (double)reader.GetDecimal(11);
                            OCD.IdProduct = reader.GetInt32(12);
                            OCD.Line = reader.GetInt32(13);
                            OCD.Recibido = OCD.Quantity;

                            //OCD.Id = reader.GetInt32(10);
                            //OCD.Id_OrderBuy = reader.GetInt32(1);
                            //OCD.ProductDescription = reader.GetString(2);
                            //OCD.Quantity = reader.GetInt32(3);
                            //OCD.UnitPrice = (double)reader.GetDecimal(4);
                            //OCD.Tax = (double)reader.GetDecimal(5);
                            //OCD.Amount = (double)reader.GetDecimal(6);
                            //OCD.Description = reader.GetString(7);
                            //OCD.DateDelevery = reader.GetDateTime(8);
                            //OCD.Line = reader.GetInt32(9);
                            //OCD.Total = OCD.Amount + OCD.Tax;
                            lstOCDetalle.Add(OCD);
                        }

                        conn.Close();

                        return lstOCDetalle;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo el detalle de la ordene de compra", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<DetalleOrdenCompraModel>();
                }
            }
        }

        public static List<InventarioProducto> ObtenerInventario(int? idUbicacion, string producto)
        {
            List<InventarioProducto> lstOCDetalle = new List<InventarioProducto>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureObtenerInventario;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@idUbicacion", System.Data.SqlDbType.Int).Value = idUbicacion == null ? DBNull.Value : (object)idUbicacion;
                        sqlCommand.Parameters.Add("@producto", System.Data.SqlDbType.VarChar).Value = String.IsNullOrEmpty(producto) ? DBNull.Value : (object)producto;
                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            InventarioProducto inv = new InventarioProducto();

                            inv.ClaveTek = reader["cve_teknobike"].ToString();
                            inv.ClaveProv = reader["cve_proveedor"].ToString();
                            inv.Nombre = reader["nombre"].ToString();
                            inv.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                            inv.FechaMovimiento = Convert.ToDateTime(reader["Fecha_Movimiento"]);
                            inv.Ubicacion = reader["Ubicacion"].ToString();
                            inv.IdMovimiento = Convert.ToInt64(reader["id"].ToString());
                            inv.SubFamilia = reader["subfamilia"].ToString();
                            inv.Familia = reader["familia"].ToString();
                            inv.Modelo = reader["modelo"].ToString();
                            inv.Medida = reader["medida"].ToString();
                            inv.Marca = reader["marca"].ToString();
                            inv.Pedimento = reader["Pedimento"].ToString();
                            inv.Color = reader["color"].ToString();
                            lstOCDetalle.Add(inv);
                        }

                        conn.Close();

                        return lstOCDetalle;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo el inventario", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<InventarioProducto>();
                }
            }
        }

        public static List<DetalleInventario> GetDetalleInventario(Int64 idMov)
        {
            List<DetalleInventario> lstOCDetalle = new List<DetalleInventario>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.DetalleInventarioById;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@idMovimiento", System.Data.SqlDbType.BigInt).Value = idMov;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            DetalleInventario inv = new DetalleInventario();
                            inv.Id = reader.GetInt64(0);
                            inv.IdMovimiento = reader.GetInt64(1);
                            inv.IDOCDetalle = reader.GetInt32(2);
                            inv.Serie = reader["serie"] == DBNull.Value ? "" : reader["serie"].ToString();
                            inv.Vendido = reader.GetBoolean(4);
                            inv.FechaVenta = reader["FechaVenta"] == DBNull.Value ? null : (DateTime?)reader.GetDateTime(5);
                            inv.FechaEntrada = reader["FechaEntrada"] == DBNull.Value ? null : (DateTime?)reader.GetDateTime(6);
                            lstOCDetalle.Add(inv);
                        }

                        conn.Close();

                        return lstOCDetalle;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo el inventario", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<DetalleInventario>();
                }
            }
        }


        public static void ActualizarEstadoOrden(int idOC, int idEstado, int idUsuario, string ruta, string pedimento)
        {

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureActualizarEstadoOrden;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@idOrdenCompra", System.Data.SqlDbType.Int).Value = idOC;
                        sqlCommand.Parameters.Add("@idEstado", System.Data.SqlDbType.Int).Value = idEstado;
                        sqlCommand.Parameters.Add("@idusuario", System.Data.SqlDbType.Int).Value = idUsuario;
                        sqlCommand.Parameters.Add("@ruta", System.Data.SqlDbType.VarChar).Value = String.IsNullOrEmpty(ruta) ? DBNull.Value : (object)ruta;
                        sqlCommand.Parameters.Add("@pedimento", System.Data.SqlDbType.VarChar).Value = string.IsNullOrEmpty(pedimento) ? DBNull.Value : (object)pedimento;
                        conn.Open();

                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Orden Actualizada correctamente!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error al Actualizar de estado la orden", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw ex;
                }
            }
        }

        public static void ActualizarInventario(int idProducto, int cantidadReal, DateTime fecha, int idUbicacion, int idDetalleCompra, string pedimento, Dictionary<int, SerieModel> seriales)
        {
            int idMov = -1;

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureActualizarInventario;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@idProducto", System.Data.SqlDbType.Int).Value = idProducto;
                        sqlCommand.Parameters.Add("@CantidadReal", System.Data.SqlDbType.Int).Value = cantidadReal;
                        sqlCommand.Parameters.Add("@FechaMovimiento", System.Data.SqlDbType.DateTime).Value = fecha;
                        sqlCommand.Parameters.Add("@idUbicacion", System.Data.SqlDbType.Int).Value = idUbicacion;
                        sqlCommand.Parameters.Add("@pedimento", System.Data.SqlDbType.VarChar).Value = pedimento;

                        SqlParameter idMovP = new SqlParameter();
                        idMovP.ParameterName = "@id_orden_out";
                        idMovP.DbType = DbType.Int32;
                        idMovP.Direction = ParameterDirection.Output;
                        sqlCommand.Parameters.Add(idMovP);


                        conn.Open();

                        sqlCommand.ExecuteNonQuery();

                        idMov = Convert.ToInt32(sqlCommand.Parameters["@id_orden_out"].Value.ToString());

                        conn.Close();
                        //MessageBox.Show("Orden Actualizada correctamente!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    }


                    if (idMov > 0)
                    {
                        if (seriales != null && seriales.Count > 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("<Seriales>");


                            foreach (var item in seriales.Values)
                            {
                                sb.Append("<Serial>");
                                sb.Append("<idMov>" + idMov + "</idMov>");
                                sb.Append("<idProducto>" + idProducto + "</idProducto>");
                                sb.Append("<Serie>" + (String.IsNullOrEmpty(item.Valor) ? string.Empty : item.Valor) + "</Serie>");
                                sb.Append("<idDetalleCompra>" + idDetalleCompra + "</idDetalleCompra>");
                                sb.Append("<idUbicacion>" + idUbicacion + "</idUbicacion>");
                                sb.Append("<fechaEntrada>" + fecha.ToString("dd-MM-yyyy HH:mm:ss") + "</fechaEntrada>");
                                sb.Append("<pedimento>" + (string.IsNullOrEmpty(pedimento) ? string.Empty : pedimento) + "</pedimento>");
                                sb.Append("</Serial>");
                            }

                            sb.Append("</Seriales>");



                            using (SqlCommand sqlCommand = new SqlCommand())
                            {
                                sqlCommand.Connection = conn;
                                sqlCommand.CommandText = "[Inventarios].[ActualizarDetalleInventarioXml]";
                                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                                sqlCommand.Parameters.Add("@Xml", System.Data.SqlDbType.Xml).Value = sb.ToString();
                                //sqlCommand.Parameters.Add("@idProducto", System.Data.SqlDbType.Int).Value = idProducto;
                                //sqlCommand.Parameters.Add("@idDetalleCompra", System.Data.SqlDbType.Int).Value = idDetalleCompra;
                                //sqlCommand.Parameters.Add("@Serie", System.Data.SqlDbType.VarChar).Value = String.IsNullOrEmpty(item.Valor) ? DBNull.Value : (object)item.Valor;
                                //sqlCommand.Parameters.Add("@idUbicacion", System.Data.SqlDbType.Int).Value = idUbicacion;
                                //sqlCommand.Parameters.Add("@fechaEntrada", System.Data.SqlDbType.DateTime).Value = fecha;
                                //sqlCommand.Parameters.Add("@pedimento", System.Data.SqlDbType.VarChar).Value = string.IsNullOrEmpty(pedimento) ? string.Empty : pedimento;
                                conn.Open();

                                sqlCommand.ExecuteNonQuery();
                                conn.Close();
                            }



                        }
                        else
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("<Seriales>");

                            for (int i = 0; i < cantidadReal; i++)
                            {
                                sb.Append("<Serial>");
                                sb.Append("<idMov>" + idMov + "</idMov>");
                                sb.Append("<idProducto>" + idProducto + "</idProducto>");
                                sb.Append("<idDetalleCompra>" + idDetalleCompra + "</idDetalleCompra>");
                                sb.Append("<Serie>" + string.Empty + "</Serie>");
                                sb.Append("<idUbicacion>" + idUbicacion + "</idUbicacion>");
                                sb.Append("<fechaEntrada>" + fecha.ToString("dd-MM-yyyy HH:mm:ss") + "</fechaEntrada>");
                                sb.Append("<pedimento>" + (string.IsNullOrEmpty(pedimento) ? string.Empty : pedimento) + "</pedimento>");
                                sb.Append("</Serial>");

                                //using (SqlCommand sqlCommand = new SqlCommand())
                                //{
                                //    sqlCommand.Connection = conn;
                                //    sqlCommand.CommandText = Constants.ActualizarDetalleInv;
                                //    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                                //    sqlCommand.Parameters.Add("@IDMOV", System.Data.SqlDbType.Int).Value = idMov;
                                //    sqlCommand.Parameters.Add("@idProducto", System.Data.SqlDbType.Int).Value = idProducto;
                                //    sqlCommand.Parameters.Add("@idDetalleCompra", System.Data.SqlDbType.Int).Value = idDetalleCompra;
                                //    sqlCommand.Parameters.Add("@Serie", System.Data.SqlDbType.DateTime).Value = DBNull.Value;
                                //    sqlCommand.Parameters.Add("@idUbicacion", System.Data.SqlDbType.Int).Value = idUbicacion;
                                //    sqlCommand.Parameters.Add("@fechaEntrada", System.Data.SqlDbType.DateTime).Value = fecha;
                                //    sqlCommand.Parameters.Add("@pedimento", System.Data.SqlDbType.VarChar).Value = pedimento;
                                //    conn.Open();

                                //    sqlCommand.ExecuteNonQuery();
                                //    conn.Close();
                                //}
                            }

                            sb.Append("</Seriales>");


                            using (SqlCommand sqlCommand = new SqlCommand())
                            {
                                sqlCommand.Connection = conn;
                                sqlCommand.CommandText = "[Inventarios].[ActualizarDetalleInventarioXml]";
                                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                                sqlCommand.Parameters.Add("@Xml", System.Data.SqlDbType.Xml).Value = sb.ToString();
                                conn.Open();
                                sqlCommand.ExecuteNonQuery();
                                conn.Close();
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error al Actualizar el inventario", MessageBoxButton.OK, MessageBoxImage.Error);
                    //throw ex;
                }
            }
        }

        public static List<DetalleOrdenCompraModel> GetOCDetalle(int idOC)
        {
            List<DetalleOrdenCompraModel> lstOCDetalle = new List<DetalleOrdenCompraModel>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetOCDetalle;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@IdOC", System.Data.SqlDbType.Int).Value = idOC;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            DetalleOrdenCompraModel OCD = new DetalleOrdenCompraModel();
                            OCD.Id = reader.GetInt32(0);
                            OCD.Id_OrderBuy = reader.GetInt32(1);
                            OCD.ProductDescription = reader.GetString(2);
                            OCD.Quantity = reader.GetInt32(3);
                            OCD.UnitPrice = (double)reader.GetDecimal(4);
                            OCD.Tax = (double)reader.GetDecimal(5);
                            OCD.Amount = (double)reader.GetDecimal(6);
                            OCD.Description = reader.GetString(7);
                            OCD.DateDelevery = reader.GetDateTime(8);
                            OCD.Line = reader.GetInt32(9);
                            OCD.Total = OCD.Amount + OCD.Tax;
                            lstOCDetalle.Add(OCD);
                        }

                        conn.Close();

                        return lstOCDetalle;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo el detalle de la ordene de compra", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<DetalleOrdenCompraModel>();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idOC"></param>
        /// <param name="idEstatus"></param>
        /// <returns></returns>
        public static string UpdateEstatusOC(int idOC, int idEstatus)
        {

            string estatus = string.Empty;

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureUpdateEstatusOC;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@IdOC", System.Data.SqlDbType.Int).Value = idOC;
                        sqlCommand.Parameters.Add("@IdEstatus", System.Data.SqlDbType.Int).Value = idEstatus;
                        sqlCommand.Parameters.Add("@NombreEstatus", System.Data.SqlDbType.VarChar, 400).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        var obj = sqlCommand.Parameters["@NombreEstatus"].Value ?? string.Empty;

                        estatus = obj.ToString();

                        conn.Close();



                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    estatus = "-1";
                }
            }

            return estatus;
        }

        public static void EliminarDetalle(int idDetalle)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.eliminarDetalle;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@idDetalle", System.Data.SqlDbType.Int).Value = idDetalle;
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetOCLastId()
        {
            int last_id = 0;

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetOCLastId;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@last_id_oc", System.Data.SqlDbType.Int).Direction =
                            System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        var obj = sqlCommand.Parameters["@last_id_oc"].Value;

                        last_id = (int)obj;

                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    last_id = -1;
                }
            }

            return last_id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetOCDLastId()
        {
            int last_id = 0;

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetOCDLastId;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@last_id_ocd", System.Data.SqlDbType.Int).Direction =
                            System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        var obj = sqlCommand.Parameters["@last_id_ocd"].Value ?? default(int);

                        last_id = (int)obj;

                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    last_id = -1;
                }
            }

            return last_id;
        }

        #region empleados

        public static bool InsEmployee(Empleado model, int idUbiacion, ref int error, ref string errorMessage)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.SPInsEmpleado;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@IdPuesto", System.Data.SqlDbType.Int).Value = model.IdPuesto;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 50).Value = model.Nombre;
                        sqlCommand.Parameters.Add("@Apellidos", System.Data.SqlDbType.VarChar, 50).Value = model.Apellidos;
                        sqlCommand.Parameters.Add("@FechaNacimiento", System.Data.SqlDbType.DateTime).Value = model.FechaNacimiento;
                        sqlCommand.Parameters.Add("@LugarNacimiento", System.Data.SqlDbType.VarChar, 60).Value = model.LugarNacimiento;
                        sqlCommand.Parameters.Add("@Sexo", System.Data.SqlDbType.VarChar, 60).Value = model.Sexo;
                        sqlCommand.Parameters.Add("@EstadoCivil", System.Data.SqlDbType.VarChar, 60).Value = model.EstadoCivil;
                        sqlCommand.Parameters.Add("@Domicilio", System.Data.SqlDbType.VarChar, 100).Value = model.Domicilio;
                        sqlCommand.Parameters.Add("@CP", System.Data.SqlDbType.Int).Value = model.CP;
                        sqlCommand.Parameters.Add("@Email", System.Data.SqlDbType.VarChar, 60).Value = model.Email;
                        sqlCommand.Parameters.Add("@Telefono", System.Data.SqlDbType.VarChar, 60).Value = model.Telefono;
                        sqlCommand.Parameters.Add("@Celular", System.Data.SqlDbType.VarChar, 60).Value = model.Celular;
                        sqlCommand.Parameters.Add("@Salario", System.Data.SqlDbType.VarChar, 60).Value = model.Salario;
                        sqlCommand.Parameters.Add("@FechaIngreso", System.Data.SqlDbType.DateTime).Value = model.FechaIngreso;
                        sqlCommand.Parameters.Add("@IdUbicacion", System.Data.SqlDbType.Int).Value = idUbiacion;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    errorMessage = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static bool UpdEmployee(Empleado model, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.SPUpdEmpleado;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = model.Id;
                        sqlCommand.Parameters.Add("@IdPuesto", System.Data.SqlDbType.Int).Value = model.Id;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 100).Value = model.Nombre;
                        sqlCommand.Parameters.Add("@Apellidos", System.Data.SqlDbType.Date).Value = model.FechaIngreso;
                        sqlCommand.Parameters.Add("@FechaNacimiento", System.Data.SqlDbType.VarChar, 1024).Value = model.Foto;
                        sqlCommand.Parameters.Add("@LugarNacimiento", System.Data.SqlDbType.VarChar, 60).Value = model.Email;
                        sqlCommand.Parameters.Add("@Sexo", System.Data.SqlDbType.Int).Value = model.Id;
                        sqlCommand.Parameters.Add("@EstadoCivil", System.Data.SqlDbType.Int).Value = model.Id;
                        sqlCommand.Parameters.Add("@Domicilio", System.Data.SqlDbType.Int).Value = model.Id;
                        sqlCommand.Parameters.Add("@CP", System.Data.SqlDbType.Int).Value = model.Id;
                        sqlCommand.Parameters.Add("@Email", System.Data.SqlDbType.Int).Value = model.Id;
                        sqlCommand.Parameters.Add("@Telefono", System.Data.SqlDbType.Int).Value = model.Id;
                        sqlCommand.Parameters.Add("@Celular", System.Data.SqlDbType.Int).Value = model.Id;
                        sqlCommand.Parameters.Add("@Salario", System.Data.SqlDbType.Int).Value = model.Id;
                        sqlCommand.Parameters.Add("@FechaIngreso", System.Data.SqlDbType.Int).Value = model.Id;
                        sqlCommand.Parameters.Add("@IdUbicacion", System.Data.SqlDbType.Int).Value = model.Id;
                        sqlCommand.Parameters.Add("@Activo", System.Data.SqlDbType.Int).Value = model.Id;
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static bool DelEmployee(int id, ref string msg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.SPDelEmpleado;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUbicacion"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<Empleado> GetEmployees(string name, int idUbicacion)
        {
            List<Empleado> lst = new List<Empleado>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.SPGetEmpleados;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@IdUbicacion", System.Data.SqlDbType.Int).Value = idUbicacion;


                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            Empleado modelAux = new Empleado();
                            modelAux.Id = Convert.ToInt32(reader["Id"]);
                            modelAux.IdPuesto = Convert.ToInt32(reader["IdPuesto"]);
                            modelAux.Nombre = reader["Nombre"].ToString();
                            modelAux.Apellidos = reader["Apellidos"].ToString();
                            modelAux.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"].ToString());
                            modelAux.LugarNacimiento = reader["LugarNacimiento"].ToString();
                            modelAux.Sexo = reader["Sexo"].ToString();
                            modelAux.EstadoCivil = reader["EstadoCivil"].ToString();
                            modelAux.Domicilio = reader["Domicilio"].ToString();
                            modelAux.CP = Convert.ToInt32(reader["CP"].ToString());
                            modelAux.Ciudad = reader["Apellidos"].ToString();
                            modelAux.Email = reader["Email"].ToString();
                            modelAux.Celular = reader["Celular"].ToString();
                            modelAux.Telefono = reader["Telefono"].ToString();
                            modelAux.Salario = Convert.ToDouble(reader["Salario"].ToString());
                            //modelAux.Apellidos = reader["Apellidos"].ToString();
                            modelAux.FechaIngreso = reader["FechaIngreso"] != DBNull.Value ? (DateTime?)reader["FechaIngreso"] : null;
                            //modelAux.Foto = reader["foto"].ToString();

                            modelAux.IsActive = Convert.ToBoolean(reader["Activo"]);
                            lst.Add(modelAux);
                        }

                        conn.Close();

                        return lst;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo empleados", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<Empleado>();
                }
            }
        }

        /// <summary>
        /// Obtiene una lista del catalogo de empleados.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<Empleado> GetEmployees(string name)

        {
            List<Empleado> lst = new List<Empleado>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.SPGetEmpleados;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 100).Value = name;


                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            Empleado modelAux = new Empleado();
                            modelAux.Id = Convert.ToInt32(reader["Id"]);
                            modelAux.Nombre = reader["Nombre"].ToString();
                            modelAux.FechaIngreso = reader["FechaDeContratacion"] != DBNull.Value ? (DateTime?)reader["FechaDeContratacion"] : null;
                            modelAux.Foto = reader["foto"].ToString();
                            modelAux.Email = reader["correo"].ToString();
                            modelAux.IsActive = Convert.ToBoolean(reader["Activo"]);
                            lst.Add(modelAux);
                        }

                        conn.Close();

                        return lst;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo empleados", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<Empleado>();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<string> GetEmployeesMails()
        {
            List<string> lst = new List<string>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetEmployeeListMails;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            string email = reader["Email"].ToString();
                            lst.Add(email);
                        }

                        conn.Close();

                        return lst;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo empleados", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<string>();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static bool InsPuesto(Puesto model, ref string errorMessage)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.SPInsPuesto;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 100).Value = model.Nombre;
                        sqlCommand.Parameters.Add("@Salario", System.Data.SqlDbType.Float).Value = model.Salario;
                        sqlCommand.Parameters.Add("@Activo", System.Data.SqlDbType.VarChar, 1024).Value = model.Activo;
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    errorMessage = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static bool UpdPuesto(Puesto model, ref string errorMessage)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.SPUpdPuesto;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@IdPuesto", System.Data.SqlDbType.Int).Value = model.IdPuesto;
                        sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 100).Value = model.Nombre;
                        sqlCommand.Parameters.Add("@Salario", System.Data.SqlDbType.Float).Value = model.Salario;
                        sqlCommand.Parameters.Add("@Activo", System.Data.SqlDbType.VarChar, 1024).Value = model.Activo;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    errorMessage = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static bool DelPuesto(Puesto model, ref string errorMessage)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.SPDelPuesto;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@IdPuesto", System.Data.SqlDbType.Int).Value = model.IdPuesto;
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    errorMessage = ex.ToString();
                    conn.Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUbicacion"></param>
        /// <returns></returns>
        public static List<Puesto> GetPuesto(int idUbicacion)
        {
            List<Puesto> lst = new List<Puesto>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.SPGetPuestos;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@IdUbicacion", System.Data.SqlDbType.Int).Value = idUbicacion;


                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            Puesto modelAux = new Puesto();
                            modelAux.IdPuesto = Convert.ToInt32(reader["IdPuesto"]);
                            modelAux.Nombre = reader["Puesto"].ToString();
                            modelAux.Salario = Convert.ToDouble(reader["Salario"].ToString());
                            modelAux.Activo = Convert.ToBoolean(reader["Activo"]);
                            lst.Add(modelAux);
                        }

                        conn.Close();

                        return lst;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo empleados", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<Puesto>();
                }
            }
        }


        public static List<Checadas> GetChecadas(int idEmpleado)
        {
            List<Checadas> lst = new List<Checadas>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.SPGetChecadas;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@idEmpleado", System.Data.SqlDbType.Int).Value = idEmpleado;


                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            Checadas modelAux = new Checadas();
                            modelAux.IdChecada = Convert.ToInt32(reader["IdChecada"]);
                            modelAux.Fecha = Convert.ToDateTime(reader["Fecha"].ToString());
                            modelAux.Justificacion = reader["Justificacion"].ToString();
                            modelAux.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                            modelAux.Estado = reader["Estado"].ToString();
                            modelAux.JustitificadoPor = reader["JustificadaPor"].ToString();

                            lst.Add(modelAux);
                        }

                        conn.Close();



                    }


                    foreach (var l in lst)
                    {
                        using (SqlCommand sqlCommand = new SqlCommand())
                        {
                            sqlCommand.Connection = conn;
                            sqlCommand.CommandText = Constants.SPGetChecadaDetalle;
                            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            sqlCommand.Parameters.Add("@IdChecada", System.Data.SqlDbType.Int).Value = l.IdChecada;


                            conn.Open();

                            var reader = sqlCommand.ExecuteReader();

                            while (reader.Read())
                            {
                                ChecadaDetalle modelAux = new ChecadaDetalle();
                                modelAux.IdChecada = Convert.ToInt32(reader["IdChecada"]);
                                modelAux.IdChecadaDetalle = Convert.ToInt32(reader["IdChecadaDetalle"].ToString());
                                modelAux.Entrada = Convert.ToDateTime(reader["Entrada"].ToString());
                                modelAux.SalidaComida = Convert.ToDateTime(reader["SalidaComida"]);
                                modelAux.EntradaComida = Convert.ToDateTime(reader["EntradaComida"].ToString());
                                modelAux.Salida = Convert.ToDateTime(reader["Salida"].ToString());

                                l.Detalles.Add(modelAux);
                            }

                            conn.Close();
                        }
                    }

                    return lst;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo empleados", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<Checadas>();
                }
            }
        }

        public static bool RegistrarChecadas(int idEmpleado)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.SPInsChecada;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@IdEmpleado", System.Data.SqlDbType.Int).Value = idEmpleado;
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return false;
                }
            }
        }

        #endregion

        #region Inventarios

        public static List<string> ObtenerPedimentosPorProducto(int idProducto)
        {
            List<string> lst = new List<string>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureObtenerPedimentoXProducto;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCommand.Parameters.AddWithValue("@idProducto", idProducto);

                        conn.Open();
                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            var str = reader["Pedimento"].ToString();
                            lst.Add(str);
                        }

                        conn.Close();

                        return lst;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return new List<string>();
                }
            }
        }


        public static int ObtenerTotalDeProductosEnInventario(int idUbicacion)
        {
            int total = 0;

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureTotalProductosInventario;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCommand.Parameters.AddWithValue("@IdUbicacion", idUbicacion);

                        conn.Open();
                        var reader = sqlCommand.ExecuteScalar();

                        if (reader == DBNull.Value)
                        {
                            total = 0;
                        }
                        else
                        {
                            total = Convert.ToInt32(reader);
                        }



                        conn.Close();

                        return total;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return 0;
                }
            }
        }



        #endregion

        #region Tipos De cliente

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<TipoCliente> ObtenerTipoClientes()
        {
            List<TipoCliente> tipoCli = new List<TipoCliente>();


            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureObtenerTipoDeCliente;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        conn.Open();
                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            TipoCliente tc = new TipoCliente();
                            tc.Id = Convert.ToInt32(reader["Id"]);
                            tc.TipoClientes = reader["TipoDeCliente"].ToString();
                            tc.Descuentos = Convert.ToDouble(reader["Descuento"]);
                            tipoCli.Add(tc);
                        }

                        conn.Close();

                        return tipoCli;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return new List<TipoCliente>();
                }
            }
        }

        public static bool InsertarTipoCliente(string tipoDeCliente, double descuento)
        {

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureInsertarTipoDeCliente;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@TipoDeCliente", tipoDeCliente);
                        sqlCommand.Parameters.AddWithValue("@Descuento", descuento);

                        conn.Open();
                        var reader = sqlCommand.ExecuteNonQuery();

                        conn.Close();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return false;
                }
            }
        }

        public static bool ActualizarTipoCliente(int idtipoDeCliente, string tipoDeCliente, double descuento)
        {

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureActualizarTipoDeCliente;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Id", idtipoDeCliente);
                        sqlCommand.Parameters.AddWithValue("@TipoDeCliente", tipoDeCliente);
                        sqlCommand.Parameters.AddWithValue("@Descuento", descuento);

                        conn.Open();
                        var reader = sqlCommand.ExecuteNonQuery();

                        conn.Close();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return false;
                }
            }
        }

        public static bool EliminarTipoCliente(int idtipoDeCliente)
        {

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureEliminarTipoDeCliente;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Id", idtipoDeCliente);


                        conn.Open();
                        var reader = sqlCommand.ExecuteNonQuery();

                        conn.Close();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return false;
                }
            }
        }

        #endregion

        #region Conceptos Importacion

        public static List<ConceptosImportacion> ObtenerConceptosDeImportacion()
        {
            List<ConceptosImportacion> lst = new List<ConceptosImportacion>();


            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureObtenerConceptoImportacion;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        conn.Open();
                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            ConceptosImportacion model = new ConceptosImportacion();
                            model.Id = Convert.ToInt32(reader["Id"]);
                            model.Concepto = reader["Concepto"].ToString();

                            lst.Add(model);
                        }

                        conn.Close();

                        return lst;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return new List<ConceptosImportacion>();
                }
            }
        }

        public static bool InsertarConceptosDeImportacion(string concepto)
        {

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureInsertarConceptoImportacion;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Concepto", concepto);


                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return false;
                }
            }
        }

        public static bool ActualizarConceptosDeImportacion(int idConcepto, string concepto)
        {

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureActualizarConceptoImportacion;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Id", idConcepto);
                        sqlCommand.Parameters.AddWithValue("@Concepto", concepto);

                        conn.Open();
                        var reader = sqlCommand.ExecuteNonQuery();
                        conn.Close();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return false;
                }
            }
        }

        public static bool EliminarConceptosDeImportacion(int idConcepto)
        {

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureEliminarConceptoImportacion;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Id", idConcepto);


                        conn.Open();
                        var reader = sqlCommand.ExecuteNonQuery();

                        conn.Close();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return false;
                }
            }
        }

        #endregion

        #region Gastos de Importacion

        public static int InsertarGastosImportacion(int idOrdenCompra, int IdAgenteAduanal, string NoCuenta, DateTime? fecha, string xml)
        {
            var errorReturn = 0;

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureInsertarGastosDeImportacion;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdOrdenCompra", idOrdenCompra);
                        sqlCommand.Parameters.AddWithValue("@IdAgenteAduanal", IdAgenteAduanal);
                        sqlCommand.Parameters.AddWithValue("@NoCuenta", NoCuenta);
                        sqlCommand.Parameters.AddWithValue("@Fecha", fecha);
                        sqlCommand.Parameters.AddWithValue("@Xml", xml);

                        SqlParameter error = new SqlParameter();
                        error.ParameterName = "@Error";
                        error.DbType = DbType.Int32;
                        error.Direction = ParameterDirection.Output;
                        sqlCommand.Parameters.Add(error);

                        SqlParameter errorMsg = new SqlParameter();
                        errorMsg.ParameterName = "@ErrorMSG";
                        errorMsg.DbType = DbType.String;
                        errorMsg.Size = 255;
                        errorMsg.Direction = ParameterDirection.Output;
                        sqlCommand.Parameters.Add(errorMsg);

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        errorReturn = Convert.ToInt32(sqlCommand.Parameters["@Error"].Value);
                        var txt = sqlCommand.Parameters["@ErrorMSG"].Value.ToString();

                        conn.Close();

                        return errorReturn;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return -1;
                }
            }
        }

        public static GastoImportacion ObtenerGastoDeImportacion(int idOrdenCompra)
        {
            GastoImportacion lst = null;


            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureObtenerGastosDeImportacion;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdOrdenCompra", idOrdenCompra);

                        conn.Open();
                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            lst = new GastoImportacion();
                            lst.IdAgenteAduanal = Convert.ToInt32(reader["IdAgenteAduanal"]);
                            lst.IdOrdenDeCompra = Convert.ToInt32(reader["IdOrdenDeCompra"]);
                            lst.NoCuenta = reader["NoCuenta"].ToString();
                            lst.Fecha = Convert.ToDateTime(reader["fecha"]);
                        }

                        conn.Close();

                        return lst;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return null;
                }
            }
        }

        public static List<GastosImportacionDetalle> ObtenerGastoDeImportacionDetalle(int idOrdenCompra)
        {
            List<GastosImportacionDetalle> lst = new List<GastosImportacionDetalle>();


            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureObtenerGastosDeImportacionDetalle;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdOrdenCompra", idOrdenCompra);

                        conn.Open();
                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            var model = new GastosImportacionDetalle();
                            model.IdConcepto = Convert.ToInt32(reader["IdConceptoImportacion"]);
                            model.Concepto = reader["Concepto"].ToString();
                            model.CostoEstimado = Convert.ToDouble(reader["CostoEstimado"]);
                            model.FechaCostoEstimado = string.IsNullOrEmpty(reader["FechaCostoEstimado"].ToString()) ? (DateTime?)null : Convert.ToDateTime(reader["FechaCostoEstimado"]);
                            model.CostoReal = Convert.ToDouble(reader["CostoReal"]);
                            model.FechaCostoReal = string.IsNullOrEmpty(reader["FechaCostoReal"].ToString()) ? (DateTime?)null : Convert.ToDateTime(reader["FechaCostoReal"]);
                            lst.Add(model);
                        }

                        conn.Close();

                        return lst;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return new List<GastosImportacionDetalle>();
                }
            }
        }

        #endregion

        #region Paqueterias
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Paqueterias> ObtenerPaqueterias()
        {
            List<Paqueterias> lstPaq = new List<Paqueterias>();


            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureObtenerPaqueterias;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        conn.Open();
                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            Paqueterias paq = new Paqueterias();
                            paq.Id = Convert.ToInt32(reader["Id"]);
                            paq.Nombre = reader["Nombre"].ToString();
                            paq.Direccion = reader["Direccion"].ToString();
                            lstPaq.Add(paq);
                        }

                        conn.Close();

                        return lstPaq;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return new List<Paqueterias>();
                }
            }
        }

        public static bool InsetarPaqueteria(string nombre, string direccion)
        {

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureInsertarPaqueterias;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Nombre", nombre);
                        sqlCommand.Parameters.AddWithValue("@Direccion", direccion);

                        conn.Open();
                        var reader = sqlCommand.ExecuteNonQuery();

                        conn.Close();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return false;
                }
            }
        }

        public static bool ActualizarPaqueteria(int idPaqueteria, string nombre, string direccion)
        {

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureActualizarPaqueterias;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Id", idPaqueteria);
                        sqlCommand.Parameters.AddWithValue("@Nombre", nombre);
                        sqlCommand.Parameters.AddWithValue("@Direccion", direccion);

                        conn.Open();
                        var reader = sqlCommand.ExecuteNonQuery();

                        conn.Close();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return false;
                }
            }
        }

        public static bool EliminarPaqueteria(int idPaqueteria)
        {

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureEliminarPaqueterias;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Id", idPaqueteria);


                        conn.Open();
                        var reader = sqlCommand.ExecuteNonQuery();

                        conn.Close();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return false;
                }
            }
        }


        #endregion

        #region Orden de compra Homologada

        public static int InsertOrderHomologadaDetalle(OrdenCompraProveedor obd)
        {

            int aux = 1;

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsertOrderBuyDetail;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        //obd.Quantity = obd.Recibido;
                        //obd.Amount = obd.Monto;
                        sqlCommand.Parameters.Add("@Id_Orden", System.Data.SqlDbType.Int).Value = obd.IdOrdenCompra;
                        sqlCommand.Parameters.Add("@Id_Producto", System.Data.SqlDbType.Int).Value = obd.IdProducto;
                        sqlCommand.Parameters.Add("@cantidad", System.Data.SqlDbType.Int).Value = obd.Cantidad;
                        sqlCommand.Parameters.Add("@precio_unitario", System.Data.SqlDbType.Decimal).Value = obd.PrecioUnitario;
                        sqlCommand.Parameters.Add("@UOM", System.Data.SqlDbType.VarChar, 500).Value = "";
                        sqlCommand.Parameters.Add("@impuestos", System.Data.SqlDbType.Decimal).Value = obd.Impuestos;
                        sqlCommand.Parameters.Add("@monto", System.Data.SqlDbType.Decimal).Value = obd.Total;
                        sqlCommand.Parameters.Add("@linea", System.Data.SqlDbType.Int).Value = obd.Linea;
                        sqlCommand.Parameters.Add("@iddetalle", System.Data.SqlDbType.Int).Value = -1;

                        conn.Open();

                        sqlCommand.ExecuteNonQuery();

                        conn.Close();

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    aux = -1;

                }
            }

            return aux;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ob"></param>
        /// <returns></returns>
        public static int InsertarOrderDeCompraHomologada(OrderBuy ob, int accion)
        {

            int id_order = 0;

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureInsertarOCHomologada;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@Id_proveedor", System.Data.SqlDbType.Int).Value = ob.IdProvider;
                        sqlCommand.Parameters.Add("@Info_factura", System.Data.SqlDbType.NVarChar, 500).Value = "EJEMPLO";
                        sqlCommand.Parameters.Add("@direccion_envio", System.Data.SqlDbType.VarChar, 500).Value = DBNull.Value;
                        sqlCommand.Parameters.Add("@fecha_emision", System.Data.SqlDbType.DateTime).Value = ob.FechaEmision;
                        sqlCommand.Parameters.Add("@fecha_entrega", System.Data.SqlDbType.DateTime).Value = DBNull.Value;
                        sqlCommand.Parameters.Add("@nombre_comprador", System.Data.SqlDbType.VarChar).Value = "";
                        sqlCommand.Parameters.Add("@nombre_validador", System.Data.SqlDbType.VarChar).Value = "";
                        sqlCommand.Parameters.Add("@idUsuario", System.Data.SqlDbType.Int).Value = ob.idGenerador;
                        sqlCommand.Parameters.Add("@accion", System.Data.SqlDbType.Int).Value = accion;
                        sqlCommand.Parameters.Add("@IDIN", System.Data.SqlDbType.Int).Value = ob.Id;
                        sqlCommand.Parameters.Add("@idUbicacion", System.Data.SqlDbType.Int).Value = ob.IdUbicacion;
                        sqlCommand.Parameters.Add("@id_orden_out", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@id_orden_out"].Value.ToString(), out id_order);

                        conn.Close();

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    id_order = -1;
                    throw ex;
                }
            }

            return id_order;
        }

        public static void EliminarOrderDeCompraDetalle(int idOrdenCompra)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureEliminarOCPorHomologacion;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@idOrdenCompra", System.Data.SqlDbType.Int).Value = idOrdenCompra;
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        conn.Close();

                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                }
            }


        }

        public static List<OrdenCompraProveedor> ObtenerOrdenDeCompraPorProveedor(int idProveedor)
        {
            List<OrdenCompraProveedor> lst = new List<OrdenCompraProveedor>();


            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureObtenerOCPorProveedor;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@idProveedor", idProveedor);

                        conn.Open();
                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            OrdenCompraProveedor model = new OrdenCompraProveedor();
                            model.IdOrdenCompra = Convert.ToInt32(reader["IdOrden"]);
                            model.IdProveedor = Convert.ToInt32(reader["idProveedor"]);
                            model.Proveedor = reader["Proveedor"].ToString();
                            model.IdUbicacion = Convert.ToInt32(reader["idUbicacion"]);
                            model.Ubicacion = reader["Ubicacion"].ToString();
                            model.IdProducto = Convert.ToInt32(reader["idProducto"]);
                            model.Producto = reader["Producto"].ToString();
                            model.Cantidad = Convert.ToInt32(reader["cantidad"]);
                            model.PrecioUnitario = Convert.ToDouble(reader["precio_unitario"]);
                            model.UOM = reader["UOM"].ToString();
                            model.Total = Convert.ToDouble(reader["monto"]);
                            model.Impuestos = Convert.ToDouble(reader["impuestos"]);
                            model.Linea = Convert.ToInt32(reader["linea"]);

                            lst.Add(model);
                        }

                        conn.Close();

                        return lst;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return new List<OrdenCompraProveedor>();
                }
            }
        }


        #endregion

        #region Usuarios

        public static List<Usuario> GetUsuarios(int idUbicacion)
        {
            List<Usuario> lstProducts = new List<Usuario>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ObtenerUsuarios;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@idUbicacion", idUbicacion);

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            Usuario modelAux = new Usuario();
                            modelAux.Id = Convert.ToInt32(reader["Id"]);
                            modelAux.Codigo = reader["codigo"].ToString();
                            modelAux.Nombre = reader["nombre"].ToString();
                            modelAux.Correo = reader["correo"].ToString();
                            modelAux.Foto = reader["foto"].ToString();
                            modelAux.IdTipoUsuario = Convert.ToInt32(reader["IdTipoUsuario"]);
                            modelAux.TipoUsuario = reader["TipoDeUsuario"].ToString();
                            modelAux.IdUbicacion = Convert.ToInt32(reader["idUbicacion"]);
                            modelAux.Ubicacion = reader["Ubicacion"].ToString();
                            lstProducts.Add(modelAux);
                        }

                        conn.Close();

                        return lstProducts;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<Usuario>();
                }
            }
        }


        public static void AdminUsuarios(Usuario usuario, int accion, ref int idError, ref string errorMsg)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.AdminUsuarios;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = usuario.Id;
                        sqlCommand.Parameters.Add("@codigo", System.Data.SqlDbType.VarChar).Value = usuario.Codigo;
                        sqlCommand.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = usuario.Nombre;
                        sqlCommand.Parameters.Add("@correo", System.Data.SqlDbType.VarChar).Value = usuario.Correo;
                        sqlCommand.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = usuario.Foto;
                        sqlCommand.Parameters.Add("@accion", System.Data.SqlDbType.Int).Value = accion;
                        sqlCommand.Parameters.Add("@idUbicacion", System.Data.SqlDbType.Int).Value = usuario.IdUbicacion;
                        sqlCommand.Parameters.Add("@idTipoUsuario", System.Data.SqlDbType.Int).Value = usuario.IdTipoUsuario;
                        sqlCommand.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = usuario.Password;

                        SqlParameter error = new SqlParameter();
                        error.ParameterName = "@error";
                        error.DbType = DbType.Int32;
                        error.Direction = ParameterDirection.Output;
                        sqlCommand.Parameters.Add(error);

                        SqlParameter msg = new SqlParameter();
                        msg.ParameterName = "@msg";
                        msg.DbType = DbType.String;
                        msg.Size = 200;
                        msg.Direction = ParameterDirection.Output;
                        sqlCommand.Parameters.Add(msg);



                        conn.Open();

                        sqlCommand.ExecuteNonQuery();

                        idError = sqlCommand.Parameters["@error"].Value == DBNull.Value ? 0 : Convert.ToInt32(sqlCommand.Parameters["@error"].Value.ToString());
                        errorMsg = sqlCommand.Parameters["@msg"].Value == DBNull.Value ? string.Empty : sqlCommand.Parameters["@msg"].Value.ToString();

                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }


        public static List<TipoUsuario> ObtenerTipoUsuario()
        {
            List<TipoUsuario> lst = new List<TipoUsuario>();


            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureObtenerTipoUsuario;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        conn.Open();
                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            TipoUsuario model = new TipoUsuario();
                            model.Id = Convert.ToInt32(reader["Id"]);
                            model.TipoUsuarioSistema = reader["TipoDeUsuario"].ToString();

                            lst.Add(model);
                        }

                        conn.Close();

                        return lst;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return new List<TipoUsuario>();
                }
            }
        }


        #endregion

        #region Tipo De Notificacion

        public static int InsertarUsuarioTipoNotificacion(int IdUbicacion, int IdTipoNotificacion, string xml)
        {
            var errorReturn = 0;

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureInsertarUsuarioTipoNotificacion;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@idUbicacion", IdUbicacion);
                        sqlCommand.Parameters.AddWithValue("@idTipoNotificacion", IdTipoNotificacion);
                        sqlCommand.Parameters.AddWithValue("@Xml", xml);

                        SqlParameter error = new SqlParameter();
                        error.ParameterName = "@Error";
                        error.DbType = DbType.Int32;
                        error.Direction = ParameterDirection.Output;
                        sqlCommand.Parameters.Add(error);

                        SqlParameter errorMsg = new SqlParameter();
                        errorMsg.ParameterName = "@ErrorMSG";
                        errorMsg.DbType = DbType.String;
                        errorMsg.Size = 255;
                        errorMsg.Direction = ParameterDirection.Output;
                        sqlCommand.Parameters.Add(errorMsg);

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        errorReturn = Convert.ToInt32(sqlCommand.Parameters["@Error"].Value);
                        var txt = sqlCommand.Parameters["@ErrorMSG"].Value.ToString();

                        conn.Close();

                        return errorReturn;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return -1;
                }
            }
        }

        public static List<TipoDeNotificacion> ObtenerTipoDeNotificacion()
        {
            List<TipoDeNotificacion> lst = new List<TipoDeNotificacion>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureObtenerTipoNotificacion;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            TipoDeNotificacion modelAux = new TipoDeNotificacion();
                            modelAux.IdTipoNotificacion = Convert.ToInt32(reader["Id"]);
                            modelAux.TipoNotificacion = reader["TipoNotificacion"].ToString();
                            lst.Add(modelAux);
                        }

                        conn.Close();

                        return lst;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo tipo de notificaciones", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<TipoDeNotificacion>();
                }
            }
        }

        public static List<string> ObtenerCorreosPorTipoDeNotificacion(int idTipoNotificacion, int idUbicacion)
        {
            List<string> lst = new List<string>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureObtenerCorreosPorTipoNotificacion;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@idTipoOperacion", idTipoNotificacion);
                        sqlCommand.Parameters.AddWithValue("@idUbicacion", idUbicacion);
                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            string s = reader["correo"].ToString();
                            lst.Add(s);
                        }

                        conn.Close();

                        return lst;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo tipo de notificaciones", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<string>();
                }
            }
        }


        #endregion

        #region Correos

        public static List<Usuario> ObtenerUsuariosPorNotificacion(int idUbicacion, int idTipoNotificacion)
        {
            List<Usuario> lstProducts = new List<Usuario>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureObtenerUsuariosPorNotificacion;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@idUbicacion", idUbicacion);
                        sqlCommand.Parameters.AddWithValue("@idTipoNotificacion", idTipoNotificacion);

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            Usuario modelAux = new Usuario();
                            modelAux.Id = Convert.ToInt32(reader["IdEmpleado"]);
                            modelAux.Nombre = reader["nombre"].ToString();
                            modelAux.Correo = reader["correo"].ToString();
                            lstProducts.Add(modelAux);
                        }

                        conn.Close();

                        return lstProducts;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<Usuario>();
                }
            }
        }


        #endregion

        #region Archivos Adjuntos

        /// <summary>
        /// otiene los tipos de documentos disponibles
        /// </summary>
        /// <returns></returns>
        public static List<TipoDocumentos> ObtenerTipoDocumento()
        {
            List<TipoDocumentos> lst = new List<TipoDocumentos>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureObtenerTipoDocumento;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        conn.Open();
                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            TipoDocumentos model = new TipoDocumentos();
                            model.IdDocumento = Convert.ToInt32(reader["Id"]);
                            model.Nombre = reader["nombre"].ToString();

                            lst.Add(model);
                        }

                        conn.Close();

                        return lst;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return new List<TipoDocumentos>();
                }
            }


        }

        public static bool GuardarDocumentoAdjunto(string xml, int idOc)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureInsertOrdenCompraAdjuntos;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdOrdenCompra", idOc);
                        sqlCommand.Parameters.AddWithValue("@Xml", xml);

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return false;
                }
            }


        }

        public static List<ArchivoAdjunto> ObtenerDocumentosAdjuntosPorOC(int idOrdenCompra)
        {
            List<ArchivoAdjunto> lst = new List<ArchivoAdjunto>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureGetAdjuntosPorOrdenDeCompra;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@idOrdenCompra", idOrdenCompra);

                        conn.Open();
                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            ArchivoAdjunto model = new ArchivoAdjunto();
                            model.idTipo = Convert.ToInt32(reader["idAjunto"]);
                            model.TipoArchivo = reader["TipoDocumento"].ToString();
                            model.NombreArchivo = reader["RutaArchivo"].ToString();
                            model.IdOC = Convert.ToInt32(reader["idOrdenCompra"]);

                            lst.Add(model);
                        }

                        conn.Close();

                        return lst;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return new List<ArchivoAdjunto>();
                }
            }


        }


        #endregion
    }
}
