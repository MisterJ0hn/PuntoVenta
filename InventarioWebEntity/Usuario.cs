using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventarioWebEntity
{
    //public class Usuario
    //{
    //    private int idUsuario;
    //    private int tipoPerfil;
    //    private String nombre;
    //    private String mail;
    //    private String usuario;
    //    private String pass;
    //    private String activo;
    //    private String fechaRegistro;
    //    private String cliente;

    //    public Usuario()
    //    {
    //    }

    //    public Usuario(int idUsuario,int tipoPerfil,String nombre,String mail,String usuario,String pass,String activo,String fechaRegistro,String cliente)
    //    {
    //        this.idUsuario=idUsuario;
    //        this.tipoPerfil = tipoPerfil;
    //        this.nombre=nombre;
    //        this.mail=mail;
    //        this.usuario=usuario;
    //        this.pass=pass;
    //        this.activo=activo;
    //        this.fechaRegistro=fechaRegistro;
    //        this.cliente=cliente;
    //    }

    //    public int IdUsuario
    //    {
    //        get { return idUsuario; }
    //        set { idUsuario = value; }
    //    }
    //    public int TipoPerfil
    //    {
    //        get { return tipoPerfil; }
    //        set { tipoPerfil = value; }
    //    }
    //    public String Nombre
    //    {
    //        get { return nombre; }
    //        set { nombre = value; }
    //    }
    //    public String Mail
    //    {
    //        get { return mail; }
    //        set { mail = value; }
    //    }
    //    public String Usuario1
    //    {
    //        get { return usuario; }
    //        set { usuario = value; }
    //    }
    //    public String Pass
    //    {
    //        get { return pass; }
    //        set { pass = value; }
    //    }
    //    public String Activo
    //    {
    //        get { return activo; }
    //        set { activo = value; }
    //    }
    //    public String FechaRegistro
    //    {
    //        get { return fechaRegistro; }
    //        set { fechaRegistro = value; }
    //    }
    //    public String cliente1
    //    {
    //        get { return cliente; }
    //        set { cliente = value; }
    //    }
    //}
//Public Inventario Web
    public class Usuario
    {
        private int idUsuario;
        private int tipoPerfil;
        private String nombre;
        private String apellido;
        private String correo;
        private String usuario;
        private String clave;
        private int activo;
        private String fechaRegistro;
        private int idEmpresa;

        public Usuario()
        {
        }

        public Usuario(int idUsuario, int tipoPerfil, String nombre, String apellido, String correo, String usuario, String clave, int activo, String fechaRegistro, int idEmpresa)
        {
            this.idUsuario = idUsuario;
            this.tipoPerfil = tipoPerfil;
            this.nombre = nombre;
            this.apellido = apellido;
           
            this.correo = correo;
            this.usuario = usuario;
            this.clave = clave;
            this.activo = activo;
            this.fechaRegistro = fechaRegistro;
            this.idEmpresa = idEmpresa;
        }

        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
        public int TipoPerfil
        {
            get { return tipoPerfil; }
            set { tipoPerfil = value; }
        }
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public String Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public String Mail
        {
            get { return correo; }
            set { correo = value; }
        }
        public String Usuario1
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public String Pass
        {
            get { return clave; }
            set { clave = value; }
        }
        public int Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        public String FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }
        public int cliente1
        {
            get { return idEmpresa; }
            set { idEmpresa = value; }
        }
    }
}
