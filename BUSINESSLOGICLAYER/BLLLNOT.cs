using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITYLAYER;
using FACADELAYER;
namespace BUSINESSLOGICLAYER
{
    public class BLLLNOT
    {
        public static bool GUNCELLE(ENTITYNOT deger)
        {
            if(deger.OGRID>0&&deger.OGRID<=100&&deger.SINAV1>0&&deger.SINAV1<=100  && deger.SINAV2 > 0 && deger.SINAV2 <= 100 &&  deger.SINAV3 > 0 && deger.SINAV3 <= 100 && deger.PROJE > 0 && deger.PROJE <= 100 &&  deger.ORTALAMA > 0 && deger.ORTALAMA <= 100)
            {
                return FACADENOT.GUNCELLE(deger);
            }
            return false;
        }

        public static List<ENTITYNOT> LISTELE()
        {
            return FACADENOT.LISTELE();
        }
    }
}
