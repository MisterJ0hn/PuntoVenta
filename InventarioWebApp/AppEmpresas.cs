using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventarioWebDao;
using System.Collections;
using InventarioWebEntity;
using System.Data;

namespace InventarioWebApp
{
    public class AppEmpresas
    {
        public ArrayList entregaProveedor(int idMaestra)
        {
            ArrayList empresas = new ArrayList();
            Empresa objProv = new Empresa();

            return empresas;
        }

        public void AppAgregarEmpresa(String rutEmpresa, String nombreEmpresa, String razonSocial, int idMaestra, int tipoEmpresa)
        {
            DaoEmpresas gestion = new DaoEmpresas();
            Empresa objEmpresa = new Empresa();

            objEmpresa.rutEmpresa = rutEmpresa;
            objEmpresa.nombreEmpresa = nombreEmpresa;
            objEmpresa.razonSocial = razonSocial;
            objEmpresa.idMaestra = idMaestra;
            objEmpresa.idTipoEmpresa = tipoEmpresa;

            gestion.AgregarEmpresa(objEmpresa, idMaestra, tipoEmpresa);
            
        }
        public void AppAgregarSucursal(String rutEmpresa, String nombreSucursal, String direccionSucursal, String telefonoSucursal, int idComuna,int idMaestra)
        {
            DaoEmpresas gestion = new DaoEmpresas();
            Sucursal objSucursal = new Sucursal();
            int idSucursal;

            objSucursal.rutEmpresa = rutEmpresa;
            objSucursal.nombreSucursal = nombreSucursal;
            objSucursal.direccionSucursal = direccionSucursal;
            objSucursal.idCOmuna = idComuna;



            idSucursal=gestion.AgregarSucursal(objSucursal, idMaestra);

        }

        public void AppModificarEmpresa(String rutEmpresa, String nombreEmpresa, String razonSocial, int idMaestra, int tipoEmpresa)
        {
            DaoEmpresas gestion = new DaoEmpresas();
            Empresa objEmpresa = new Empresa();

            objEmpresa.rutEmpresa = rutEmpresa;
            objEmpresa.nombreEmpresa = nombreEmpresa;
            objEmpresa.razonSocial = razonSocial;
            objEmpresa.idMaestra = idMaestra;
            objEmpresa.idTipoEmpresa = tipoEmpresa;

            gestion.ModificarEmpresa(objEmpresa, idMaestra, tipoEmpresa);

        }

        public void AppModificarSucursal(String rutEmpresa, String nombreSucursal, String direccionSucursal, String telefonoSucursal,  int idMaestra, int idComuna, int IdSucursal)
        {
            DaoEmpresas gestion = new DaoEmpresas();
            Sucursal objSucursal = new Sucursal();
            objSucursal.idSucursal=IdSucursal;
            objSucursal.rutEmpresa = rutEmpresa;
            objSucursal.nombreSucursal = nombreSucursal;
            objSucursal.direccionSucursal = direccionSucursal;
            objSucursal.telefonoSucursal = telefonoSucursal;
            objSucursal.idCOmuna = idComuna;
            objSucursal.idMaestra = idMaestra;
            gestion.ModificarSucursal(objSucursal);

        }

        public ArrayList AppSeleccionaEmpresa(String rutEmpresa)
        {
            DaoEmpresas conexion = new DaoEmpresas();
            ArrayList arrEmpresa = new ArrayList();
            ArrayList empres = new ArrayList();

            arrEmpresa = conexion.seleccionaEmpresa(rutEmpresa);

            foreach (Empresa objEmpresa in arrEmpresa)
            {
                empres.Add(objEmpresa.rutEmpresa);
                empres.Add(objEmpresa.nombreEmpresa);
                empres.Add(objEmpresa.razonSocial);

            }
            return empres;
        }
        
        public ArrayList AppSeleccionaSucursal(int idSucursal)
        {
            DaoEmpresas conexion = new DaoEmpresas();
            ArrayList arr = new ArrayList();
            ArrayList suc = new ArrayList();

            arr= conexion.seleccionaSucursal(idSucursal);

            foreach (Sucursal objSucursal in arr)
            {
                suc.Add(objSucursal.nombreSucursal);
                suc.Add(objSucursal.direccionSucursal);
                suc.Add(objSucursal.telefonoSucursal);
                suc.Add(objSucursal.idCOmuna);
            }
            return suc;

        }

        public DataTable getRegion()
        {
            DaoEmpresas conexion = new DaoEmpresas();
            DataTable arrRegion = new DataTable();

            arrRegion = conexion.LlenaCombos("IdRegion", "NombreRegion","REGION");
            return arrRegion;
        }
        public ArrayList getCiudad(int idRegion, int idCiudad=0)
        {
            DaoEmpresas conexion = new DaoEmpresas();
            DataTable arrCiudad = new DataTable();
            ArrayList arr = new ArrayList();
            if (idCiudad > 0)
            {
                ArrayList indices = new ArrayList();
                indices = conexion.IndicesCR(idCiudad, "CI");

                idRegion = Convert.ToInt32(indices[1].ToString());

            }
            arrCiudad = conexion.LlenaCombos("IdCiudad", "NombreCiudad", "CIUDAD", "IdRegion="+idRegion.ToString());
            arr.Add(arrCiudad);
            arr.Add(idRegion);
            return arr;
        }
        public  ArrayList getComuna(int idCiudad,int idComuna=0)
        {
            DaoEmpresas conexion = new DaoEmpresas();
            DataTable arrComuna = new DataTable();
            ArrayList arr= new ArrayList();
            if (idComuna > 0)
            {
                ArrayList indices = new ArrayList();
                indices = conexion.IndicesCR(idComuna, "C");

                idCiudad = Convert.ToInt32(indices[0].ToString());

            }
            
            arrComuna = conexion.LlenaCombos("IdComuna", "NombreComuna", "COMUNA", "IdCiudad=" + idCiudad.ToString());
            arr.Add(arrComuna);
            arr.Add(idCiudad);
            return arr;
        }
        public int AgregarSucursal(String nombre, String direccion,String telefono, String rut, int idComuna, int idMaestra)
        {
            DaoConexion conexion = new DaoConexion();
            ArrayList arrValores = new ArrayList();
            ArrayList arrCampos = new ArrayList();
           
            arrValores.Add("'" + rut.ToString() + "'");
            arrValores.Add("'" + nombre.ToString() + "'");
            arrValores.Add("'" + direccion.ToString() + "'");
            arrValores.Add("'" + telefono.ToString() + "'");
            arrValores.Add(idComuna.ToString());
            arrValores.Add(idMaestra.ToString());
            conexion.AddValue(arrValores);
            arrCampos.Add("RutEmpresa");
            arrCampos.Add("NombreSucursal");
            arrCampos.Add("DireccionSucursal");
            arrCampos.Add("TelefonoSucursal");
            arrCampos.Add("IdComuna");
            arrCampos.Add("IdMaestra");
     

            int idSucursal = conexion.InsertSql("SUCURSAL", arrCampos, true);

            return idSucursal;
        }

    }
}