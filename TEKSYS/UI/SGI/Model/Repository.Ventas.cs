using SGI.Enumeration;
using SGI.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SGI.Model
{
    public static partial class Repository
    {

        public static List<ClienteVenta> ClientesDisponiblesCache { get; set; }
        public static List<ProductoDisponible> ProductosDisponiblesCache { get; set; }

        #region Empleados

        public static List<Empleado> EmpleadosCache { get; set; }

        public static List<Puesto> PuestosCache { get; set; }

        public static List<Sexo> GetSexos()
        {
            List<Sexo> result = new List<Sexo>();
            result.Add(new Sexo("Masculino"));
            result.Add(new Sexo("Femenino"));
            result.Add(new Sexo("ND"));
            return result;
        }

        public static List<EstadoCivil> GetEstadoCivil()
        {
            List<EstadoCivil> result = new List<EstadoCivil>();
            result.Add(new EstadoCivil("Soltero"));
            result.Add(new EstadoCivil("Casado"));
            result.Add(new EstadoCivil("Viudo"));
            result.Add(new EstadoCivil("Divorciado"));
            return result;
        }

        #endregion


        #region ventas

        public static void InsertarAbono(int idVenta, int idUsuario, int idUbicacion, double cantidad, DateTime fechaAbono)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.InsAbono;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@idVenta", idVenta);
                        sqlCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
                        sqlCommand.Parameters.AddWithValue("@idUbicacion", idUbicacion);
                        sqlCommand.Parameters.AddWithValue("@cantidad", cantidad);
                        sqlCommand.Parameters.AddWithValue("@fechaAbono", fechaAbono);

                        conn.Open();

                        sqlCommand.ExecuteNonQuery();

                        conn.Close();

                        MessageBox.Show("Abono agregado correctamente");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error al guardar abono...", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }

        }

        public static int ValidarLimiteDeCredito(int idCliente, double totalVenta)
        {
            int resultado = 0;

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureValidarLimiteDeCredito;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@idCliente", idCliente);
                        sqlCommand.Parameters.AddWithValue("@CantidadVenta", totalVenta);
                        conn.Open();

                        var reader = sqlCommand.ExecuteScalar();

                        resultado = reader == DBNull.Value ? 1 : Convert.ToInt32(reader);

                        conn.Close();

                        return resultado;

                    }
                }
                catch (Exception ex)
                {
                    return 1;
                }
            }
        }

        public static int ValidarDocumentoVencido(int idCliente)
        {
            int resultado = 0;

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureValidarDocumentoVencido;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@idCliente", idCliente);

                        conn.Open();

                        var reader = sqlCommand.ExecuteScalar();

                        resultado = reader == DBNull.Value ? 1 : Convert.ToInt32(reader);

                        conn.Close();

                        return resultado;

                    }
                }
                catch (Exception ex)
                {
                    return 1;
                }
            }
        }


        public static List<Abonos> ObtenerAbonos(int idVenta)
        {
            var lst = new List<Abonos>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetAbonos;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@idVenta", idVenta);

                        //SqlParameter pTotalAbonos = new SqlParameter();
                        //pTotalAbonos.ParameterName = "@totalAbonos";
                        //pTotalAbonos.DbType = DbType.Decimal;
                        //pTotalAbonos.Direction = ParameterDirection.Output;
                        //sqlCommand.Parameters.Add(pTotalAbonos);

                        //SqlParameter pTotalVenta = new SqlParameter();
                        //pTotalVenta.ParameterName = "@totalVenta";
                        //pTotalVenta.DbType = DbType.Decimal;
                        //pTotalVenta.Direction = ParameterDirection.Output;
                        //sqlCommand.Parameters.Add(pTotalVenta);


                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();



                        while (reader.Read())
                        {
                            var model = new Abonos();
                            model.Cantidad = Convert.ToDouble(reader["Cantidad"]);
                            model.FechaAbono = Convert.ToDateTime(reader["FechaAbono"]);
                            lst.Add(model);
                        }



                        //totalAbonos = Convert.ToDouble(sqlCommand.Parameters["@totalAbonos"].Value);
                        //totalVenta = Convert.ToDouble(sqlCommand.Parameters["@totalVenta"].Value);

                        conn.Close();

                        return lst;

                    }
                }
                catch (Exception ex)
                {
                    return new List<Abonos>();
                }
            }
        }
        public static List<VentasAdeudos> ObtenerAdeudos(int idUbicacion, int idClientes)
        {
            var lst = new List<VentasAdeudos>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetAdeudos;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdUbicacion", idUbicacion);
                        sqlCommand.Parameters.AddWithValue("@IdCliente", idClientes);
                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            var model = new VentasAdeudos();
                            model.IdCliente = Convert.ToInt32(reader["Clave"]);
                            model.Nombre = reader["Nombre"].ToString();
                            model.Telefono = reader["Telefono"].ToString();
                            model.TipoDeCliente = reader["TipoDeCliente"].ToString();
                            model.LimiteDeCredito = Convert.ToDouble(reader["LimiteDeCredito"]);
                            model.Documentos = Convert.ToInt32(reader["Documentos"]);
                            model.DocumentosVencidos = Convert.ToInt32(reader["DocumentosVencidos"]);
                            model.SaldoVencido = Math.Round(Convert.ToDouble(reader["SaldoVencido"]), 2);
                            lst.Add(model);
                        }

                        conn.Close();

                        return lst;

                    }
                }
                catch (Exception ex)
                {
                    return new List<VentasAdeudos>();
                }
            }
        }

        public static List<ClienteVenta> GetClientesDisponibles()
        {
            var lstProduct = new List<ClienteVenta>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.GetClientesDisponibles;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            var cliente = new ClienteVenta();
                            cliente.idCliente = Convert.ToInt32(reader["IdCliente"]);
                            cliente.Nombre = reader["NombreComercial"].ToString();
                            cliente.Direccion = reader["Direccion"].ToString();
                            cliente.RFC = reader["Rfc"].ToString();
                            cliente.Telefono = reader["Telefono1"].ToString();
                            cliente.CP = reader["Cp"].ToString();
                            cliente.Ciudad = reader["Ciudad"].ToString();
                            cliente.Estado = reader["Estado"].ToString();
                            cliente.idTipoCliente = Convert.ToInt32(reader["idTipoCliente"].ToString());
                            cliente.TipoCliente = reader["TipoDecliente"].ToString();
                            //cliente.DescuentoCliente = Convert.ToDouble(reader["Descuento"].ToString());
                            cliente.DescuentoCliente = 0;
                            lstProduct.Add(cliente);
                        }

                        conn.Close();

                        return lstProduct;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo los clientes", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<ClienteVenta>();
                }
            }
        }

        public static List<ProductoDisponible> GetProductosDisponibles()
        {
            var lstProduct = new List<ProductoDisponible>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.GetProductosDisponibles;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            var producto = new ProductoDisponible();
                            producto.IdProducto = Convert.ToInt32(reader["idproducto"]);
                            producto.NombreProducto = reader["NombreProducto"].ToString();
                            producto.CveProveedor = reader["cveproveedor"].ToString();
                            producto.CveTeknobike = reader["cveteknobike"].ToString();
                            producto.IdUbicacion = Convert.ToInt32(reader["IdUbicacion"]);
                            producto.Ubicacion = reader["ubicacion"].ToString();
                            producto.IdMarca = Convert.ToInt32(reader["idmarca"]);
                            producto.Marca = reader["marca"].ToString();
                            producto.PrecioUnitario = Convert.ToDouble(reader["precio_publico"].ToString());
                            producto.Inventario = Convert.ToInt32(reader["Cantidad"].ToString());
                            producto.IdInventario = Convert.ToInt32(reader["idInventario"].ToString());
                            producto.Cantidad = 1;
                            lstProduct.Add(producto);
                        }
                        conn.Close();

                        return lstProduct;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo los productos", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<ProductoDisponible>();
                }
            }
        }

        public static List<DescuentosDisponibles> GetDescuentosDisponibles(int idProducto, int idMarca, int idUbicacion, int idTipoCliente, DateTime fecha)
        {
            var descuentos = new List<DescuentosDisponibles>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.GetDescuentosDisponibles;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@idProducto", SqlDbType.Int).Value = idProducto;
                        sqlCommand.Parameters.Add("@idMarca", SqlDbType.Int).Value = idMarca;
                        sqlCommand.Parameters.Add("@idUbicacion", SqlDbType.Int).Value = idUbicacion;
                        sqlCommand.Parameters.Add("@idTipoCliente", SqlDbType.Int).Value = idTipoCliente;
                        sqlCommand.Parameters.Add("@datetime", SqlDbType.DateTime).Value = fecha.ToString();
                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            var descuento = new DescuentosDisponibles();
                            descuento.IdDescuento = Convert.ToInt32(reader["idDescuento"]);
                            descuento.Descuento = Convert.ToDouble(reader["Descuento"].ToString());
                            descuento.TipoDescuento = reader["TipoDescuento"].ToString();
                            descuentos.Add(descuento);
                        }
                        conn.Close();
                        return descuentos;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo los descuentos", MessageBoxButton.OK, MessageBoxImage.Error);
                    return descuentos;
                }
            }
        }

        public static int InsVenta(DateTime fechaventa, int idubicacion, int idvendedor, int idcliente,
            string comentarios, int idTipoVenta, double total)
        {
            var outid = -1;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.InsVenta;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@idventa", SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                        sqlCommand.Parameters.Add("@idvendedor", SqlDbType.Int).Value = idvendedor;
                        sqlCommand.Parameters.Add("@idUbicacion", SqlDbType.Int).Value = idubicacion;
                        sqlCommand.Parameters.Add("@idCliente", SqlDbType.Int).Value = idcliente;
                        sqlCommand.Parameters.Add("@FechaVenta", SqlDbType.DateTime).Value = fechaventa.ToString();
                        sqlCommand.Parameters.Add("@comentario", SqlDbType.VarChar).Value = comentarios;
                        sqlCommand.Parameters.Add("@idTipoDeVenta", SqlDbType.Int).Value = idTipoVenta;
                        sqlCommand.Parameters.Add("@total", SqlDbType.Int).Value = total;
                        conn.Open();

                        sqlCommand.ExecuteNonQuery();

                        Int32.TryParse(sqlCommand.Parameters["@idventa"].Value.ToString(), out outid);

                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error al guardar la venta...", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw ex;
                }
            }
            return outid;
        }

        public static int InsVentaDetalle(int idproducto, int cantidad, double precio, string comentario, int idventa, string tipoDescuento, int idDescuento, double descuento, int idUbicacion, string series, string pedimento, double descuentoTotal, double total)
        {
            var outid = -1;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.InsVentaDetalle;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@idproducto", SqlDbType.Int).Value = idproducto;
                        sqlCommand.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;
                        sqlCommand.Parameters.Add("@Preciounitario", SqlDbType.Float).Value = precio;
                        sqlCommand.Parameters.Add("@idventa", SqlDbType.Int).Value = idventa;
                        sqlCommand.Parameters.Add("@comentario", SqlDbType.VarChar).Value = comentario;
                        sqlCommand.Parameters.Add("@tipodescuento", SqlDbType.VarChar).Value = tipoDescuento;
                        sqlCommand.Parameters.Add("@iddescuento", SqlDbType.Int).Value = idDescuento;
                        sqlCommand.Parameters.Add("@descuento", SqlDbType.Float).Value = descuento;
                        sqlCommand.Parameters.Add("@idubicacion", SqlDbType.Int).Value = idUbicacion;
                        sqlCommand.Parameters.Add("@conserie", SqlDbType.VarChar).Value = series;
                        sqlCommand.Parameters.Add("@pedimento", SqlDbType.VarChar).Value = pedimento;
                        sqlCommand.Parameters.Add("@descuentoTotal", SqlDbType.Float).Value = descuentoTotal;
                        sqlCommand.Parameters.Add("@total", SqlDbType.Float).Value = total;
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        outid = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error intentando guardar el detalle de venta ", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            return outid;
        }

        public static List<TipoDeVenta> GetTipoDeVenta()
        {
            var lst = new List<TipoDeVenta>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetTipoDeVenta;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            var model = new TipoDeVenta();
                            model.Id = Convert.ToInt32(reader["Id"]);
                            model.Nombre = reader["Tipo"].ToString();
                            lst.Add(model);
                        }

                        conn.Close();

                        return lst;

                    }
                }
                catch (Exception ex)
                {
                    return new List<TipoDeVenta>();
                }
            }
        }

        public static List<EstatusDeVenta> GetStatusDeVenta()
        {
            var lst = new List<EstatusDeVenta>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetStatusDeVenta;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            var model = new EstatusDeVenta();
                            model.Id = Convert.ToInt32(reader["Id"]);
                            model.Nombre = reader["Estatus"].ToString();
                            lst.Add(model);
                        }

                        conn.Close();

                        return lst;

                    }
                }
                catch (Exception ex)
                {
                    return new List<EstatusDeVenta>();
                }
            }
        }

        public static List<Ventas> ObtenerVentas(DateTime? fechaInicial, DateTime? fechaFinal,
            int idUbicacion, int idTipoVenta, int idEstatus, int idCliente)
        {
            var lst = new List<Ventas>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetVentas;
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.AddWithValue("@fechaInicial", fechaInicial);
                        sqlCommand.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                        sqlCommand.Parameters.AddWithValue("@idUbicacion", idUbicacion);
                        sqlCommand.Parameters.AddWithValue("@idTipoVenta", idTipoVenta);
                        sqlCommand.Parameters.AddWithValue("@IdEstatus", idEstatus);
                        sqlCommand.Parameters.AddWithValue("@IdCliente", idCliente);

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            var model = new Ventas();
                            model.IdVenta = Convert.ToInt32(reader["idVenta"]);
                            model.Fecha = Convert.ToDateTime(reader["FechaVenta"]);
                            model.IdUbicacion = Convert.ToInt32(reader["idUbicacion"]);
                            model.Ubicacion = reader["Ubicacion"].ToString();
                            model.IdVendedor = Convert.ToInt32(reader["idVendedor"]);
                            model.Vendedor = reader["Vendedor"].ToString();
                            model.IdCliente = Convert.ToInt32(reader["idCliente"]);
                            model.Cliente = reader["Cliente"].ToString();
                            model.IdTipoDeVenta = Convert.ToInt32(reader["idTipoDeVenta"]);
                            model.TipoDeVenta = reader["TipoVenta"].ToString();
                            model.IdEstatus = Convert.ToInt32(reader["idEstatus"]);
                            model.Estatus = reader["Estatus"].ToString();
                            model.MontoTotal = Convert.ToDouble(reader["total"]);
                            lst.Add(model);
                        }

                        conn.Close();

                        return lst;

                    }
                }
                catch (Exception ex)
                {
                    return new List<Ventas>();
                }
            }
        }

        public static List<VentasDetalle> ObtenerVentasDetalle(int IdVenta)
        {
            var lst = new List<VentasDetalle>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProcedureGetDetalleVentas;
                        sqlCommand.CommandType = CommandType.StoredProcedure;


                        sqlCommand.Parameters.AddWithValue("@idVenta", IdVenta);

                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            var model = new VentasDetalle();
                            model.Producto = reader["Producto"].ToString();
                            model.Clave = reader["Clave"].ToString();
                            model.Pedimento = reader["pedimento"].ToString();
                            model.Cantidad = Convert.ToDouble(reader["Cantidad"]);
                            model.PrecioUnitario = Convert.ToDouble(reader["PrecioUnitario"]);
                            model.Descuento = Convert.ToDouble(reader["descuento"]);
                            model.Total = Convert.ToDouble(reader["total"]);

                            lst.Add(model);
                        }

                        conn.Close();

                        return lst;

                    }
                }
                catch (Exception ex)
                {
                    return new List<VentasDetalle>();
                }
            }
        }



        #endregion

        #region clientes

        public static List<Cliente> ClientesCache { get; set; }

        /// <summary>
        /// Obtiene los clientes de una ubicacion
        /// </summary>
        /// <param name="idUbicacion"></param>
        /// <returns></returns>
        public static List<Cliente> GetClientes(int idUbicacion)
        {
            List<Cliente> clientes = new List<Cliente>(); ;

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.GetClientePorId;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@idCliente", SqlDbType.Int).Value = -1;
                        sqlCommand.Parameters.Add("@idUbicacion", SqlDbType.Int).Value = idUbicacion;
                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            var cliente = new Cliente();
                            cliente.IdCliente = Convert.ToInt32(reader["idCliente"]);
                            cliente.IdTipoCliente = Convert.ToInt32(reader["IdTipoCliente"]);
                            cliente.TipoCliente = reader["TipoDeCliente"].ToString();
                            cliente.Ubicacion = reader["Ubicacion"].ToString();
                            cliente.IdUsario = Convert.ToInt32(reader["IdUsuario"]);
                            cliente.NombreUsuario = reader["Nombre"].ToString();
                            cliente.Incobrable = Convert.ToBoolean(reader["Incobrable"]);
                            cliente.NombreFiscal = reader["NombreFiscal"].ToString(); ;
                            cliente.RFC = reader["RFC"].ToString();
                            cliente.Direccion = reader["Direccion"].ToString(); ;
                            cliente.Colonia = reader["Colonia"].ToString(); ;
                            cliente.Estado = reader["Estado"].ToString(); ;
                            cliente.Zona = reader["Zona"].ToString(); ;
                            cliente.CP = reader["CP"].ToString(); ;
                            cliente.IdTipoPersona = Convert.ToInt32(reader["IdTipoPersona"]);
                            cliente.TipoPersona = reader["TipoPersona"].ToString(); ;
                            cliente.NombreComercial = reader["NombreComercial"].ToString(); ;
                            cliente.PaginaWeb = reader["PaginaWeb"].ToString(); ;
                            cliente.Contacto = reader["Contacto"].ToString(); ;
                            cliente.TelefonoContacto = reader["TelefonoContacto"].ToString(); ;
                            cliente.DireccionEnvio = reader["DireccionEnvio"].ToString(); ;
                            cliente.Telefono1 = reader["Telefono1"].ToString(); ;
                            cliente.Telefono2 = reader["Telefono2"].ToString(); ;
                            cliente.Telefono3 = reader["Telefono3"].ToString(); ;
                            cliente.Fax = reader["Fax"].ToString(); ;
                            cliente.Email = reader["Email"].ToString(); ;
                            cliente.SaldoInicial = Convert.ToDouble(reader["SaldoInicial"]);
                            cliente.LimiteDeCredito = Convert.ToDouble(reader["LimiteDeCredito"]);
                            cliente.DiasCredito = Convert.ToInt32(reader["DiasCredito"]);
                            cliente.SaldoDelCliente = Convert.ToDouble(reader["SaldoDelCliente"]);
                            cliente.SaldoAFavor = Convert.ToDouble(reader["SaldoAFavor"]);
                            cliente.CreditoUtilizado = Convert.ToDouble(reader["CreditoUtilizado"]);
                            cliente.TotalCreditoUtilizado = Convert.ToDouble(reader["TotalCreditoUtilizado"]);
                            cliente.TotalTraspaso = Convert.ToDouble(reader["TotalTraspaso"]);
                            cliente.Usuario = reader["Usuario"].ToString(); ;
                            cliente.Password = reader["Password"].ToString(); ;
                            cliente.PermitirComprarPorInternet = Convert.ToBoolean(reader["PermitirComprarPorInternet"]);

                            clientes.Add(cliente);

                        }

                        conn.Close();

                        return clientes;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo los clientes", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new List<Cliente>();
                }
            }
        }

        public static Cliente GetCliente(int idCliente, int idUbicacion)
        {
            Cliente cliente = null;

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.GetClientePorId;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;
                        sqlCommand.Parameters.Add("@idUbicacion", SqlDbType.Int).Value = idUbicacion;
                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            cliente = new Cliente();
                            cliente.IdCliente = Convert.ToInt32(reader["idCliente"]);
                            cliente.IdTipoCliente = Convert.ToInt32(reader["IdTipoCliente"]);
                            cliente.TipoCliente = reader["TipoDeCliente"].ToString();
                            cliente.Ubicacion = reader["Ubicacion"].ToString();
                            cliente.IdUsario = Convert.ToInt32(reader["IdUsuario"]);
                            cliente.NombreUsuario = reader["Nombre"].ToString();
                            cliente.Incobrable = Convert.ToBoolean(reader["Incobrable"]);
                            cliente.NombreFiscal = reader["NombreFiscal"].ToString(); ;
                            cliente.RFC = reader["RFC"].ToString();
                            cliente.Direccion = reader["Direccion"].ToString(); ;
                            cliente.Colonia = reader["Colonia"].ToString(); ;
                            cliente.Estado = reader["Estado"].ToString(); ;
                            cliente.Zona = reader["Zona"].ToString(); ;
                            cliente.CP = reader["CP"] != DBNull.Value ? reader["CP"].ToString() : "0";
                            cliente.IdTipoPersona = Convert.ToInt32(reader["IdTipoPersona"]);
                            cliente.TipoPersona = reader["TipoPersona"].ToString(); ;
                            cliente.NombreComercial = reader["NombreComercial"].ToString(); ;
                            cliente.PaginaWeb = reader["PaginaWeb"].ToString(); ;
                            cliente.Contacto = reader["Contacto"].ToString(); ;
                            cliente.TelefonoContacto = reader["TelefonoContacto"].ToString(); ;
                            cliente.DireccionEnvio = reader["DireccionEnvio"].ToString(); ;
                            cliente.Telefono1 = reader["Telefono1"].ToString(); ;
                            cliente.Telefono2 = reader["Telefono2"].ToString(); ;
                            cliente.Telefono3 = reader["Telefono3"].ToString(); ;
                            cliente.Fax = reader["Fax"].ToString(); ;
                            cliente.Email = reader["Email"].ToString(); ;
                            cliente.SaldoInicial = Convert.ToDouble(reader["SaldoInicial"]);
                            cliente.LimiteDeCredito = Convert.ToDouble(reader["LimiteDeCredito"]);
                            cliente.DiasCredito = Convert.ToInt32(reader["DiasCredito"]);
                            cliente.SaldoDelCliente = Convert.ToDouble(reader["SaldoDelCliente"]);
                            cliente.SaldoAFavor = Convert.ToDouble(reader["SaldoAFavor"]);
                            cliente.CreditoUtilizado = Convert.ToDouble(reader["CreditoUtilizado"]);
                            cliente.TotalCreditoUtilizado = Convert.ToDouble(reader["TotalCreditoUtilizado"]);
                            cliente.TotalTraspaso = Convert.ToDouble(reader["TotalTraspaso"]);
                            cliente.Usuario = reader["Usuario"].ToString(); ;
                            cliente.Password = reader["Password"].ToString(); ;
                            cliente.PermitirComprarPorInternet = Convert.ToBoolean(reader["PermitirComprarPorInternet"]);


                        }

                        conn.Close();

                        return cliente;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo los clientes", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
        }


        /// <summary>
        /// Obtiene el cliente por identificador de cliente
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public static Cliente GetCliente(int idCliente)
        {
            Cliente cliente = null;

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.GetClientePorId;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente == -1 ? DBNull.Value : (object)idCliente;
                        sqlCommand.Parameters.Add("@idUbicacion", SqlDbType.Int).Value = -1;
                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            cliente = new Cliente();
                            cliente.IdCliente = Convert.ToInt32(reader["idCliente"]);
                            cliente.IdTipoCliente = Convert.ToInt32(reader["IdTipoCliente"]);
                            cliente.TipoCliente = reader["TipoCliente"].ToString();
                            cliente.Ubicacion = reader["Ubicacion"].ToString();
                            cliente.IdUsario = Convert.ToInt32(reader["IdUsuario"]);
                            cliente.NombreUsuario = reader["Nombre"].ToString();
                            cliente.Incobrable = Convert.ToBoolean(reader["Incobrable"]);
                            cliente.NombreFiscal = reader["NombreFiscal"].ToString(); ;
                            cliente.RFC = reader["RFC"].ToString();
                            cliente.Direccion = reader["Direccion"].ToString(); ;
                            cliente.Colonia = reader["Colonia"].ToString(); ;
                            cliente.Estado = reader["Estado"].ToString(); ;
                            cliente.Zona = reader["Zona"].ToString(); ;
                            cliente.CP = reader["CP"].ToString(); ;
                            cliente.IdTipoPersona = Convert.ToInt32(reader["IdTipoPersona"]);
                            cliente.TipoPersona = reader["TipoPersona"].ToString(); ;
                            cliente.NombreComercial = reader["NombreComercial"].ToString(); ;
                            cliente.PaginaWeb = reader["PaginaWeb"].ToString(); ;
                            cliente.Contacto = reader["Contacto"].ToString(); ;
                            cliente.TelefonoContacto = reader["TelefonoContacto"].ToString(); ;
                            cliente.DireccionEnvio = reader["DireccionEnvio"].ToString(); ;
                            cliente.Telefono1 = reader["Telefono1"].ToString(); ;
                            cliente.Telefono2 = reader["Telefono2"].ToString(); ;
                            cliente.Telefono3 = reader["Telefono3"].ToString(); ;
                            cliente.Fax = reader["Fax"].ToString(); ;
                            cliente.Email = reader["Email"].ToString(); ;
                            cliente.SaldoInicial = Convert.ToDouble(reader["SaldoInicial"]);
                            cliente.LimiteDeCredito = Convert.ToDouble(reader["LimiteDeCredito"]);
                            cliente.DiasCredito = Convert.ToInt32(reader["DiasCredito"]);
                            cliente.SaldoDelCliente = Convert.ToDouble(reader["SaldoDelCliente"]);
                            cliente.SaldoAFavor = Convert.ToDouble(reader["SaldoAFavor"]);
                            cliente.CreditoUtilizado = Convert.ToDouble(reader["CreditoUtilizado"]);
                            cliente.TotalCreditoUtilizado = Convert.ToDouble(reader["TotalCreditoUtilizado"]);
                            cliente.TotalTraspaso = Convert.ToDouble(reader["TotalTraspaso"]);
                            cliente.Usuario = reader["Usuario"].ToString(); ;
                            cliente.Password = reader["Password"].ToString(); ;
                            cliente.PermitirComprarPorInternet = Convert.ToBoolean(reader["PermitirComprarPorInternet"]);


                        }

                        conn.Close();

                        return cliente;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error obteniendo los clientes", MessageBoxButton.OK, MessageBoxImage.Error);
                    return new Cliente();
                }
            }
        }

        /// <summary>
        /// Inserta un usuario.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public static int InsCliente(Cliente cliente)
        {
            var outid = -1;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.InsCliente;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@IdTipoCliente", SqlDbType.Int).Value = cliente.IdTipoCliente;
                        sqlCommand.Parameters.Add("@IdUbicacion", SqlDbType.Int).Value = cliente.IdUbicacion;
                        sqlCommand.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = cliente.IdUsario;
                        sqlCommand.Parameters.Add("@Incobrable", SqlDbType.Int).Value = cliente.Incobrable;
                        sqlCommand.Parameters.Add("@NombreComercial", SqlDbType.VarChar).Value = cliente.NombreComercial;
                        sqlCommand.Parameters.Add("@PaginaWeb", SqlDbType.VarChar).Value = cliente.PaginaWeb;
                        sqlCommand.Parameters.Add("@Contacto", SqlDbType.VarChar).Value = cliente.Contacto;
                        sqlCommand.Parameters.Add("@TelefonoContacto", SqlDbType.VarChar).Value = cliente.TelefonoContacto;
                        sqlCommand.Parameters.Add("@DireccionEnvio", SqlDbType.VarChar).Value = cliente.DireccionEnvio;
                        sqlCommand.Parameters.Add("@Celular", SqlDbType.VarChar).Value = cliente.Celular;
                        sqlCommand.Parameters.Add("@Telefono1", SqlDbType.VarChar).Value = cliente.Telefono1;
                        sqlCommand.Parameters.Add("@Telefono2", SqlDbType.VarChar).Value = cliente.Telefono2;
                        sqlCommand.Parameters.Add("@Telefono3", SqlDbType.VarChar).Value = cliente.Telefono3;
                        sqlCommand.Parameters.Add("@Fax", SqlDbType.VarChar).Value = cliente.Fax;
                        sqlCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = cliente.Email;
                        sqlCommand.Parameters.Add("@NombreFiscal", SqlDbType.VarChar).Value = cliente.NombreFiscal;
                        sqlCommand.Parameters.Add("@Rfc", SqlDbType.VarChar).Value = cliente.RFC;
                        sqlCommand.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = cliente.Direccion;
                        sqlCommand.Parameters.Add("@Colonia", SqlDbType.VarChar).Value = cliente.Colonia;
                        sqlCommand.Parameters.Add("@Estado", SqlDbType.VarChar).Value = cliente.Estado;
                        sqlCommand.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = cliente.Ciudad;
                        sqlCommand.Parameters.Add("@Zona", SqlDbType.VarChar).Value = cliente.Zona;
                        sqlCommand.Parameters.Add("@IdTipoPersona", SqlDbType.Int).Value = cliente.IdTipoPersona;
                        sqlCommand.Parameters.Add("@Cp", SqlDbType.Int).Value = cliente.CP;
                        sqlCommand.Parameters.Add("@SaldoInicial", SqlDbType.Float).Value = cliente.SaldoInicial;
                        sqlCommand.Parameters.Add("@LimiteDeCredito", SqlDbType.Float).Value = cliente.LimiteDeCredito;
                        sqlCommand.Parameters.Add("@DiasDeCredito", SqlDbType.Float).Value = cliente.DiasCredito;
                        sqlCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = cliente.Usuario;
                        sqlCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = cliente.Password;
                        sqlCommand.Parameters.Add("@PermitirComprarPorInternet", SqlDbType.Bit).Value = cliente.PermitirComprarPorInternet;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        outid = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error intentando guardar el cliente ", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            return outid;
        }

        /// <summary>
        /// Modificacion de un usuario.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public static int UpdCliente(Cliente cliente)
        {
            var outid = -1;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.UpdCliente;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@IdCliente", SqlDbType.Int).Value = cliente.IdCliente;
                        sqlCommand.Parameters.Add("@IdTipoCliente", SqlDbType.Int).Value = cliente.IdTipoCliente;
                        sqlCommand.Parameters.Add("@IdUbicacion", SqlDbType.Int).Value = cliente.IdUbicacion;
                        sqlCommand.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = cliente.IdUsario;
                        sqlCommand.Parameters.Add("@Incobrable", SqlDbType.Int).Value = cliente.Incobrable;
                        sqlCommand.Parameters.Add("@NombreComercial", SqlDbType.VarChar).Value = cliente.NombreComercial;
                        sqlCommand.Parameters.Add("@PaginaWeb", SqlDbType.VarChar).Value = cliente.PaginaWeb;
                        sqlCommand.Parameters.Add("@Contacto", SqlDbType.VarChar).Value = cliente.Contacto;
                        sqlCommand.Parameters.Add("@TelefonoContacto", SqlDbType.VarChar).Value = cliente.TelefonoContacto;
                        sqlCommand.Parameters.Add("@DireccionEnvio", SqlDbType.VarChar).Value = cliente.DireccionEnvio;
                        sqlCommand.Parameters.Add("@Celular", SqlDbType.VarChar).Value = cliente.Celular;
                        sqlCommand.Parameters.Add("@Telefono1", SqlDbType.VarChar).Value = cliente.Telefono1;
                        sqlCommand.Parameters.Add("@Telefono2", SqlDbType.VarChar).Value = cliente.Telefono2;
                        sqlCommand.Parameters.Add("@Telefono3", SqlDbType.VarChar).Value = cliente.Telefono3;
                        sqlCommand.Parameters.Add("@Fax", SqlDbType.VarChar).Value = cliente.Fax;
                        sqlCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = cliente.Email;
                        sqlCommand.Parameters.Add("@NombreFiscal", SqlDbType.VarChar).Value = cliente.NombreFiscal;
                        sqlCommand.Parameters.Add("@Rfc", SqlDbType.VarChar).Value = cliente.RFC;
                        sqlCommand.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = cliente.Direccion;
                        sqlCommand.Parameters.Add("@Colonia", SqlDbType.VarChar).Value = cliente.Colonia;
                        sqlCommand.Parameters.Add("@Estado", SqlDbType.VarChar).Value = cliente.Estado;
                        sqlCommand.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = cliente.Ciudad;
                        sqlCommand.Parameters.Add("@Zona", SqlDbType.VarChar).Value = cliente.Zona;
                        sqlCommand.Parameters.Add("@IdTipoPersona", SqlDbType.Int).Value = cliente.IdTipoPersona;
                        sqlCommand.Parameters.Add("@Cp", SqlDbType.Int).Value = cliente.CP;
                        sqlCommand.Parameters.Add("@SaldoInicial", SqlDbType.Float).Value = cliente.SaldoInicial;
                        sqlCommand.Parameters.Add("@LimiteDeCredito", SqlDbType.Float).Value = cliente.LimiteDeCredito;
                        sqlCommand.Parameters.Add("@DiasDeCredito", SqlDbType.Float).Value = cliente.DiasCredito;
                        sqlCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = cliente.Usuario;
                        sqlCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = cliente.Password;
                        sqlCommand.Parameters.Add("@PermitirComprarPorInternet", SqlDbType.Bit).Value = cliente.PermitirComprarPorInternet;

                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        outid = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error intentando guardar el cliente ", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            return outid;
        }

        /// <summary>
        /// Elimina un cliente
        /// </summary>
        /// <param name="idCliente"></param>
        public static void DeleteCliente(int idCliente)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.DeleteCliente;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error borrando el registro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public static List<TipoPersona> GetTipoDePersona()
        {
            var lst = new List<TipoPersona>();

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.GetTipoPersona;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            var model = new TipoPersona();
                            model.Id = Convert.ToInt32(reader["Id"]);
                            model.Tipo = reader["Tipo"].ToString();
                            lst.Add(model);
                        }

                        conn.Close();

                        return lst;

                    }
                }
                catch (Exception ex)
                {
                    return new List<TipoPersona>();
                }
            }
        }

        #endregion

        #region agente aduanal

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<AgenteAduanal> ObtenerAgente()
        {
            List<AgenteAduanal> tipoCli = new List<AgenteAduanal>();


            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureObtenerAgentes;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        conn.Open();
                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            AgenteAduanal tc = new AgenteAduanal();
                            tc.Id = Convert.ToInt32(reader["Id"]);
                            tc.Nombre = reader["Nombre"].ToString();
                            tc.Direccion = reader["Direccion"].ToString();
                            tipoCli.Add(tc);
                        }

                        conn.Close();

                        return tipoCli;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return new List<AgenteAduanal>();
                }
            }
        }

        public static bool InsertarAgente(string nombre, string direccion)
        {

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureInsertarAgentes;
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

        public static bool ActualizarAgente(int idAgente, string nombre, string direccion)
        {

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureActualizarAgentes;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Id", idAgente);
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

        public static bool EliminarAgente(int idAgente)
        {

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureEliminarAgentes;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Id", idAgente);


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

        #region Almacen

        public static List<Almacen> ObtenerAlmacen()
        {
            List<Almacen> tipoCli = new List<Almacen>();


            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureObtenerAlmacen;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        conn.Open();
                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            Almacen tc = new Almacen();
                            tc.Id = Convert.ToInt32(reader["Id"]);
                            tc.Nombre = reader["Nombre"].ToString();
                            tc.Direccion = reader["Direccion"].ToString();
                            tipoCli.Add(tc);
                        }

                        conn.Close();

                        return tipoCli;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return new List<Almacen>();
                }
            }
        }

        public static bool InsertarAlmacen(string nombre, string direccion)
        {

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureInsertarAlmacen;
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

        public static bool ActualizarAlmacen(int idAgente, string nombre, string direccion)
        {

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureActualizarAlmacen;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Id", idAgente);
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

        public static bool EliminarAlmacen(int idAgente)
        {

            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.ProdecureEliminarAlmacen;
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Id", idAgente);


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

        #region Traspasos

        public static int InsTraspaso(int idUbicacionDestino, int idUbicacionOrigen, string pedimento, DateTime fechaSalida, int idPaqueteria, int idInventario, string guia, int cantidadBloqueada)
        {
            var outid = -1;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.InsTraspaso;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@idUbicacion", SqlDbType.Int).Value = idUbicacionDestino;
                        sqlCommand.Parameters.Add("@idUbicacionOrigen", SqlDbType.Int).Value = idUbicacionOrigen;
                        sqlCommand.Parameters.Add("@pedimento", SqlDbType.VarChar).Value = pedimento;
                        sqlCommand.Parameters.Add("@fechaSalida", SqlDbType.DateTime).Value = fechaSalida;
                        sqlCommand.Parameters.Add("@idPaqueteria", SqlDbType.Int).Value = idPaqueteria;
                        sqlCommand.Parameters.Add("@idInventario", SqlDbType.Int).Value = idInventario;
                        sqlCommand.Parameters.Add("@Guia", SqlDbType.VarChar).Value = guia;
                        sqlCommand.Parameters.Add("@CantidadBloqueada", SqlDbType.Int).Value = cantidadBloqueada;
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error al guardar el traspaso...", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw ex;
                }
            }
            return outid;
        }

        //public static List<ProductoDetalle> ObtenerTraspaso(DateTime fechainicial, DateTime fechafinal, int idUbicacion, string producto)
        public static List<ProductoDetalle> ObtenerTraspaso(DateTime fechainicial, DateTime fechafinal, int idUbicacion, string guia)
        {
            var list = new List<ProductoDetalle>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.GetTraspaso;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@fechaInicial", SqlDbType.DateTime).Value = fechainicial;
                        sqlCommand.Parameters.Add("@fechaFinal", SqlDbType.DateTime).Value = fechafinal;
                        sqlCommand.Parameters.Add("@idUbicacion", SqlDbType.Int).Value = idUbicacion;
                        sqlCommand.Parameters.Add("@guia", SqlDbType.VarChar).Value = guia;
                        conn.Open();
                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            ProductoDetalle tc = new ProductoDetalle();
                            tc.FechaSalida = Convert.ToDateTime(reader["Fecha_Salida"].ToString());
                            // tc.FechaEntrega = reader["Fecha_Llegada"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["Fecha_Salida"].ToString());
                            tc.Guia = reader["Guia"].ToString();
                            // tc.IdProducto = Convert.ToInt32(reader["idProducto"].ToString());
                            //  tc.Producto = reader["Producto"].ToString();
                            // tc.Pedimento = reader["Pedimento"].ToString();
                            tc.IdUbicacionOrigen = Convert.ToInt32(reader["IdUbicacionOrigen"].ToString());
                            tc.Origen = reader["Origen"].ToString();
                            tc.IdUbicacionDestino = Convert.ToInt32(reader["IdUbicacionDestino"].ToString());
                            tc.Destino = reader["Destino"].ToString();
                            // tc.Cantidad = Convert.ToInt32(reader["CantidadBloqueada"].ToString());
                            tc.Paqueteria = reader["Paqueteria"].ToString();
                            list.Add(tc);
                        }

                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error al guardar el traspaso...", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw ex;
                }
            }
            return list;
        }

        public static void RecibirInventario(int idOrigen, int IdDestino, string guia, string xml, ref int error, ref string msgError)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.InsRecepcionInventario;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@idOrigen", SqlDbType.VarChar).Value = idOrigen;
                        sqlCommand.Parameters.Add("@idDestino", SqlDbType.VarChar).Value = IdDestino;
                        sqlCommand.Parameters.Add("@Guia", SqlDbType.VarChar).Value = guia;
                        sqlCommand.Parameters.Add("@Xml", SqlDbType.VarChar).Value = xml;

                        SqlParameter errorId = new SqlParameter();
                        errorId.ParameterName = "@Error";
                        errorId.DbType = DbType.Int32;
                        errorId.Direction = ParameterDirection.Output;
                        sqlCommand.Parameters.Add(errorId);

                        SqlParameter errorMsgP = new SqlParameter();
                        errorMsgP.ParameterName = "@ErrorMSG";
                        errorMsgP.DbType = DbType.String;
                        errorMsgP.Size = 1024;
                        errorMsgP.Direction = ParameterDirection.Output;
                        sqlCommand.Parameters.Add(errorMsgP);


                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                        error = Convert.ToInt32(sqlCommand.Parameters["@Error"].Value.ToString());
                        msgError = sqlCommand.Parameters["@ErrorMSG"].Value.ToString();

                        conn.Close();

                    }
                }
                catch (Exception ex)
                {
                    error = -1;
                    msgError = ex.InnerException.ToString();
                    // MessageBox.Show("Error" + ex.ToString(), "Error al guardar el traspaso...", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }

        public static List<ProductoDetalle> ObtenerTraspasoDetalle(string guia)
        {
            var list = new List<ProductoDetalle>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = conn;
                        sqlCommand.CommandText = Constants.GetTraspasoDetalle;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@Guia", SqlDbType.VarChar).Value = guia;
                        conn.Open();
                        var reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            ProductoDetalle tc = new ProductoDetalle();
                            tc.IdInventario = Convert.ToInt32(reader["idInventario"]);
                            // tc.FechaSalida = Convert.ToDateTime(reader["Fecha_Salida"].ToString());
                            // tc.FechaEntrega = reader["Fecha_Llegada"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["Fecha_Salida"].ToString());
                            // tc.Guia = reader["Guia"].ToString();
                            // tc.IdUbicacionOrigen = Convert.ToInt32(reader["IdUbicacionOrigen"].ToString());
                            tc.IdProducto = Convert.ToInt32(reader["idProducto"].ToString());
                            tc.Producto = reader["Producto"].ToString();
                            tc.Pedimento = reader["Pedimento"].ToString();
                            tc.Origen = reader["Origen"].ToString();
                            tc.Destino = reader["Destino"].ToString();
                            tc.CantidadDisponible = Convert.ToInt32(reader["Cantidad"]);
                            //tc.Paqueteria = reader["Paqueteria"].ToString();
                            list.Add(tc);
                        }

                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "Error al guardar el traspaso...", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw ex;
                }
            }
            return list;
        }


        #endregion
    }
}
