﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casgem.EntityLayer.Concrete
{
    public class Ilanlar
    {
        public ObjectId _id { get; set; }

        public string ImageUrl { get; set; } // kiralık , satılık

        public string IlanAdi { get; set; }
        public DateTime IlanTarihi { get; set; }
        public string Ucret { get; set; }
        public string BanyoSayısı { get; set; }
        public string BalkonSayısı { get; set; }
        public string Kimden { get; set; }
        public string Takas { get; set; }
        public string Sehir { get; set; }
        public string Tipi { get; set; } // kiralık , satılık
        public bool Esyali { get; set;}
        public string KatSayisi { get; set; } 
        public string BulunduguKat { get; set; }
        public int BinaYasi { get; set; }
        public string OdaSayisi { get; set; }

        public string UserName { get; set; }

        //public int KullaniciId { get; set; }


    }
}
