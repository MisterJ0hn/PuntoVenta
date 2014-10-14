using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using InventarioWebEntity;
using InventarioWebDao;
using System.IO;

namespace InventarioWebApp
{
    public class AppGestionU
    {
        public DataTable UsuariosTabla()
        {
            DataTable dt = new DataTable();
            DaoGestionU gestorUsuarios = new DaoGestionU();

            Usuario objUsuario = new Usuario();
            ArrayList arrUsuario = new ArrayList();

            arrUsuario = gestorUsuarios.UsuariosTodos();
            dt.Columns.AddRange(new DataColumn[5] { 
                new DataColumn("NombreUsuario", typeof(String)), 
                new DataColumn("Apellido", typeof(String)), 
                new DataColumn("Usuario", typeof(String)), 
                new DataColumn("Empresa", typeof(int)), 
                new DataColumn("FechaRegistro", typeof(String)) 
            });

            foreach (Usuario user in arrUsuario)
            {
                Console.WriteLine(user.Nombre);
                dt.Rows.Add(user.Nombre, user.Apellido, user.Usuario1, user.cliente1, user.FechaRegistro);
            }

            return dt;

        }
        public DataTable UsuariosFiltro(String filtro)
        {
            DataTable dt = new DataTable();
            DaoGestionU gestorUsuarios = new DaoGestionU();

            Usuario objUsuario = new Usuario();
            ArrayList arrUsuario = new ArrayList();
           
            arrUsuario = gestorUsuarios.UsuariosTodos(filtro);
            dt.Columns.AddRange(new DataColumn[5] { 
                new DataColumn("Nombre", typeof(String)), 
                new DataColumn("Apellido", typeof(String)), 
                new DataColumn("Usuario", typeof(String)), 
                new DataColumn("Empresa", typeof(int)), 
                new DataColumn("FechaRegistro", typeof(String)) 
            });

            foreach (Usuario user in arrUsuario)
            {
                Console.WriteLine(user.Nombre);
                dt.Rows.Add(user.Nombre, user.Apellido, user.Usuario1, user.cliente1, user.FechaRegistro);
            }

            return dt;
        }
        public DataTable CboEmpresas(int IdMaestra)
        {
            DataTable dt = new DataTable();
            DaoGestionU gestorUsuarios = new DaoGestionU();

           
            ArrayList arrEmpresa = new ArrayList();
           
            arrEmpresa = gestorUsuarios.EmpresasPorMaestra(IdMaestra);
            dt.Columns.AddRange(new DataColumn[2] { 
                new DataColumn("Rut", typeof(String)), 
                new DataColumn("Nombre", typeof(String))
            });

            foreach (Empresa empresa in arrEmpresa)
            {
                //Console.WriteLine(user.Nombre);
                dt.Rows.Add(empresa.rutEmpresa, empresa.nombreEmpresa);
            }

            return dt;
        }
        public DataTable CboSucursal(String rutEmpresa)
        {
            DataTable dt = new DataTable();
            DaoGestionU gestorUsuarios = new DaoGestionU();


            ArrayList arrSucursales= new ArrayList();
            arrSucursales= gestorUsuarios.SucursalesPorMaestra(rutEmpresa);
            dt.Columns.AddRange(new DataColumn[2] { 
                new DataColumn("id", typeof(String)), 
                new DataColumn("Nombre", typeof(String))
            });

            foreach (Sucursal sucursales in arrSucursales)
            {
                //Console.WriteLine(user.Nombre);
                dt.Rows.Add(sucursales.idSucursal, sucursales.nombreSucursal);
            }

            return dt;
        }
        public DataTable CboRol()
        {
            DataTable dt = new DataTable();
            DaoGestionU gestorUsuarios = new DaoGestionU();


            ArrayList arrRol = new ArrayList();

            arrRol = gestorUsuarios.Roles();
            dt.Columns.AddRange(new DataColumn[2] { 
                new DataColumn("id", typeof(String)), 
                new DataColumn("Nombre", typeof(String))
            });

            foreach (Rol roles in arrRol)
            {
                //Console.WriteLine(user.Nombre);
                dt.Rows.Add(roles.idRol, roles.nombre);
            }

            return dt;
        }

        public void AppAgregarUsuarios(String nombre, String apellido, String correo, String usuario, String clave, int idRol, int idSucursal, int idMaestra)
        {
            Usuario objUsuario =new Usuario();
            DaoGestionU addUsuario = new DaoGestionU();
            
            objUsuario.Nombre = nombre;
            objUsuario.Apellido = apellido;
            objUsuario.Mail = correo;
            objUsuario.Usuario1 = usuario;
            objUsuario.Pass = clave;
            objUsuario.TipoPerfil = idRol;
            objUsuario.cliente1 = idMaestra;
           
            int idUsuario = addUsuario.AgregarUsuario(objUsuario);
            addUsuario.AgregarUsuarioSucursal(idUsuario, idSucursal);
              
        }

        public void AppModificarUsuarios(String nombre, String apellido, String correo, String usuario, String clave, int idRol, int idSucursal, int idMaestra, int idUsuario)
        {
            Usuario objUsuario = new Usuario();
            DaoGestionU addUsuario = new DaoGestionU();
            objUsuario.IdUsuario = idUsuario;
            objUsuario.Nombre = nombre;
            objUsuario.Apellido = apellido;
            objUsuario.Mail = correo;
            objUsuario.Usuario1 = usuario;
            objUsuario.Pass = clave;
            objUsuario.TipoPerfil = idRol;
            objUsuario.cliente1 = idMaestra;

            addUsuario.ModificarUsuario(objUsuario);
            addUsuario.ModificarSucursalUsuario(idUsuario, idSucursal);

        }

        public ArrayList AppSeleccionaUsuario(String IdUsuario)
        {
            DaoGestionU gestion = new DaoGestionU();
            ArrayList arrUsuario = new ArrayList();
            Usuario objUsuario = new Usuario();
            ArrayList arrUsuarioReturn = new ArrayList();
            
            arrUsuario=gestion.UsuariosTodos("", IdUsuario);
            foreach (Usuario user in arrUsuario)
            {
                ArrayList arrdatos = new ArrayList();
                arrdatos = gestion.SucursalPorUsuario(user.IdUsuario);

                //Console.WriteLine(user.Nombre);
                arrUsuarioReturn.Add(user.Nombre);//0
                arrUsuarioReturn.Add(user.Apellido);//1
                arrUsuarioReturn.Add(user.Usuario1);//2
                arrUsuarioReturn.Add(user.cliente1);//3
                arrUsuarioReturn.Add(user.IdUsuario);//4
                arrUsuarioReturn.Add(user.Mail);//5
                arrUsuarioReturn.Add(user.Pass);//6
                arrUsuarioReturn.Add(user.TipoPerfil);//7
                foreach (Sucursal objSucursal in arrdatos)
                {
                    //Console.WriteLine(user.Nombre);
                    arrUsuarioReturn.Add(objSucursal.rutEmpresa);//8
                    arrUsuarioReturn.Add(objSucursal.idSucursal);//9
                    AppEmpresas appEmp = new AppEmpresas();
                    ArrayList arrEmp = new ArrayList();
                    arrEmp = appEmp.AppSeleccionaEmpresa(objSucursal.rutEmpresa);

                    arrUsuarioReturn.Add(arrEmp[1].ToString());//10


                    ArrayList arrSuc = new ArrayList();
                    arrSuc = appEmp.AppSeleccionaSucursal(objSucursal.idSucursal);

                    arrUsuarioReturn.Add(arrSuc[0].ToString());//11
                }
                


            }

            return arrUsuarioReturn;

        }
    }
}