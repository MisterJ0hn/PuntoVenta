using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace InventarioWebDao
{
    public class DaoConexion
    {
        private ArrayList arrOr=new ArrayList();
        private ArrayList arrAnd = new ArrayList();
        private ArrayList arrValue = new ArrayList();
        //private String strCadenaConexion = "Data Source=localhost;User ID=sa;Password=955763;Initial Catalog=InventarioWeb";
        private String strCadenaConexion = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=InventarioWeb;Data Source=HANSZUÑIGA-PC";
        public ArrayList QuerySql(String sql)
        {
            SqlCommand cmd;
            SqlConnection conn =new SqlConnection(this.strCadenaConexion);
            ArrayList arrConexion=new ArrayList();
            SqlDataReader drRegistros;

            conn.Open();
            sql = sql + GeneraWhere();
            cmd = new SqlCommand(sql, conn);
            drRegistros = cmd.ExecuteReader();
            arrConexion.Add(drRegistros);
            arrConexion.Add(conn);
            return arrConexion;
            
        }


        public int InsertSql(String tabla, ArrayList arrCampos=null, Boolean retornarId=false)
        {
            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(this.strCadenaConexion);

            String sql="INSERT INTO "+tabla;

            if (arrCampos != null && arrCampos.Count > 0)
            {
                sql = sql + " (";
                int listC=arrCampos.Count;
                int iC = 0;
                foreach (String dato in arrCampos)
                {
                    sql = sql + dato;
                    iC++;
                    if (iC < listC)
                    {
                        sql = sql + ",";
                    }

                }
                sql = sql + ")";

            }

            int listV1=this.arrValue.Count;
            if (listV1 > 0)
            {
                int iV1 = 0;
                sql = sql + " VALUES ";
                foreach (ArrayList arrSubValue in this.arrValue)
                {
                    
                    int iV2 = 0;
                    int listV2 = arrSubValue.Count;
                    if (listV2 > 0)
                    {
                        sql = sql + " (";
                        foreach (String dato in arrSubValue)
                        {
                            sql = sql + dato;

                            iV2++;
                            if (iV2 < listV2)
                            {
                                sql = sql + ",";
                            }
                        }
                        sql = sql + ")";
                    }

                    iV1++;
                    if (iV1 < listV1)
                    {
                        sql = sql + ",";
                    }

                }

            } 
            int id = 0;
            try
            {
                conn.Open();
               
                if (retornarId)
                {

                    sql = sql + "SELECT SCOPE_IDENTITY()";
                    cmd = new SqlCommand(sql, conn);
                    id = Convert.ToInt32(cmd.ExecuteScalar());

                }
                else
                {
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteReader();

                }
                conn.Close();
            }catch(SqlException se){

            }
             return id;
        }

        public void UpdateSql(String tabla, ArrayList arrValores, String Where)
        {
            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(this.strCadenaConexion);

            String sql = "UPDATE " + tabla;

            if (arrValores != null && arrValores.Count > 0)
            {
                sql = sql + " SET ";
                int listC = arrValores.Count;
                int iC = 0;
                foreach (String dato in arrValores)
                {
                    sql = sql + dato;
                    iC++;
                    if (iC < listC)
                    {
                        sql = sql + ",";
                    }

                }

            }

            sql = sql + " WHERE " + Where;


            conn.Open();
            cmd = new SqlCommand(sql, conn);
                
            cmd.ExecuteReader();

           
            conn.Close();
            
        }


        public void AddValue(ArrayList value)
        {
            this.arrValue.Add(value);
        }
        public void AddOr( String valor)
        {
            this.arrOr.Add(valor);

        }

        public void addAnd(String valor) 
        {
            this.arrAnd.Add(valor);
        }
        public String GeneraWhere()
        {
            String consulta="";

            if (this.arrAnd.Count > 0 || this.arrOr.Count > 0)
            {
                consulta = " WHERE ";


                if (this.arrAnd.Count > 0)
                {

                    int last = this.arrAnd.Count;
                    int i = 0;

                    foreach (String dato in this.arrAnd)
                    {
                        consulta = consulta + dato.ToString();
                        i++;
                        if (last > i)
                        {
                            consulta = consulta + " AND ";
                        }

                    }
                    if (this.arrOr.Count > 0)
                    {
                        consulta = consulta + "AND ";
                    }
                }

                if (this.arrOr.Count > 0)
                {

                    int last = this.arrOr.Count;
                    int i = 0;
                    consulta = consulta + "(";
                    foreach (String dato in this.arrOr)
                    {
                        consulta = consulta + dato.ToString();
                        i++;
                        if (last > i)
                        {
                            consulta = consulta + " OR ";
                        }

                    }
                    consulta = consulta + ")";
                }
            }
          
            return consulta;
        }

    }
}