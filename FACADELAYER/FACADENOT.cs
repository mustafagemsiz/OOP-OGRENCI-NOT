using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ENTITYLAYER;

namespace FACADELAYER
{
    public class FACADENOT
    {
        public static bool GUNCELLE(ENTITYNOT deger)
        {
            SqlCommand komut = new SqlCommand("NOTGUNCELLE", SQLBAGLANTI.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("OGRID", deger.OGRID);
            komut.Parameters.AddWithValue("SINAV1", deger.SINAV1);
            komut.Parameters.AddWithValue("SINAV2", deger.SINAV2);
            komut.Parameters.AddWithValue("SINAV3", deger.SINAV3);
            komut.Parameters.AddWithValue("PROJE", deger.PROJE);
            komut.Parameters.AddWithValue("ORTALAMA", deger.ORTALAMA);
            komut.Parameters.AddWithValue("DURUM", deger.DURUM);
            return komut.ExecuteNonQuery() > 0;
        }

        public static List<ENTITYNOT> LISTELE()
        {
            List<ENTITYNOT> degerler = new List<ENTITYNOT>();
            SqlCommand komut = new SqlCommand("NOTLISTESI", SQLBAGLANTI.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if(komut.Connection.State!= ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ENTITYNOT ent = new ENTITYNOT();
                ent.OGRID = Convert.ToUInt16(dr["OGRID"]);
                ent.AD = dr["AD"].ToString();
                ent.SOYAD = dr["SOYAD"].ToString();
                ent.SINAV1 = Convert.ToUInt16(dr["SINAV1"]);
                ent.SINAV2 = Convert.ToUInt16(dr["SINAV2"]);
                ent.SINAV3 = Convert.ToUInt16(dr["SINAV3"]);
                ent.PROJE = Convert.ToUInt16(dr["PROJE"]);
                ent.ORTALAMA = Convert.ToDouble(dr["ORTALAMA"]);
                ent.DURUM = dr["DURUM"].ToString();
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }
    }
}
