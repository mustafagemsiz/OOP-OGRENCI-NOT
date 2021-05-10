﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ENTITYLAYER;

namespace FACADELAYER
{
    public class FACADEKULUP
    {
        public static int EKLE(ENTITYKULUP deger)
        {           
            SqlCommand komut = new SqlCommand("KULUPEKLE", SQLBAGLANTI.baglanti);

            komut.CommandType = CommandType.StoredProcedure;

            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("KULUPAD",deger.KULUPAD);
            return komut.ExecuteNonQuery();
        }

        public static bool SIL(int deger)
        {
            SqlCommand komut = new SqlCommand("KULUPSIL", SQLBAGLANTI.baglanti);

            komut.CommandType = CommandType.StoredProcedure;

            if(komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("KULUPID", deger);

            return komut.ExecuteNonQuery() > 0;
        }

        public static bool GUNCELLE(ENTITYKULUP deger)
        {
            SqlCommand komut = new SqlCommand("KULUPGUNCELLE", SQLBAGLANTI.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open) 
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("KULUPAD", deger.KULUPAD);
            komut.Parameters.AddWithValue("KULUPID", deger.KULUPID);
            return komut.ExecuteNonQuery() > 0;           
        }

        public static List<ENTITYKULUP> LISTELE()
        {
            List<ENTITYKULUP> degerler = new List<ENTITYKULUP>();
            SqlCommand komut = new SqlCommand("KULUPLISTESI", SQLBAGLANTI.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ENTITYKULUP ent = new ENTITYKULUP();
                ent.KULUPID = Convert.ToInt16(dr["KULUPID"]);
                ent.KULUPAD = dr["KULUPAD"].ToString();
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
            
        }
    }
}
