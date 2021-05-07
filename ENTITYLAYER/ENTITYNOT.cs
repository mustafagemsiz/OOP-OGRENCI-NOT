using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITYLAYER
{
    public class ENTITYNOT
    {
        int _OGRENCIID;
        int _SINAV1;
        int _SINAV2;
        int _SINAV3;
        int _PROJE;
        double _ORTALAMA;
        bool _DURUM;

        public int OGRENCIID { get => _OGRENCIID; set => _OGRENCIID = value; }
        public int SINAV1 { get => _SINAV1; set => _SINAV1 = value; }
        public int SINAV2 { get => _SINAV2; set => _SINAV2 = value; }
        public int SINAV3 { get => _SINAV3; set => _SINAV3 = value; }
        public int PROJE { get => _PROJE; set => _PROJE = value; }
        public double ORTALAMA { get => _ORTALAMA; set => _ORTALAMA = value; }
        public bool DURUM { get => _DURUM; set => _DURUM = value; }
    }
}
