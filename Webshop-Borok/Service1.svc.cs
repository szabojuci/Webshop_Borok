using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Webshop_Borok.Models;


namespace Webshop_Borok
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    public class Service1 : IService1
    {
        public static Dictionary<string, Borok> BorokLista = new Dictionary<string, Borok>();
        public List<Borok> BorokLista_CS()
        {
            List<Borok> lista = new List<Borok>();
            Controller.BorokController borokController = new Controller.BorokController();
            List<Record> records = borokController.Select();
            foreach(Record record in records)
            {
                lista.Add(record as Borok);
            }
            return lista;
        }

        public List<Borok> BorokLista_Web()
        {
            return BorokLista_CS();
        }
        public string BorokHozzaAdas_CS(Borok borok)
        {
            Controller.BorokController borokController = new Controller.BorokController();
            return borokController.Insert(borok);
        }
        public string BorokHozzaAdas_Web(Borok borok)
        {
            return BorokHozzaAdas_CS(borok);
        }
        public string BorokModosit_CS(Borok borok)
        {
            Controller.BorokController borokController = new Controller.BorokController();
            return borokController.Update(borok);
        }

        public string FelhasznaloModosit_Web(Borok borok)
        {
            return BorokModosit_CS(borok);
        }
        public string BorokTorol_CS(int id)
        {
            Controller.BorokController borokController = new Controller.BorokController();
            return borokController.Delete(id);
        }

        public string BorokTorol_Web(int id)
        {
            return BorokTorol_CS(id);
        }

        public string BorHozzaAdas_CS(Borok borok)
        {
            throw new NotImplementedException();
        }

        public string BorhozzaAdas_Web(Borok borok)
        {
            throw new NotImplementedException();
        }

        public string BorModosit_CS(Borok borok)
        {
            throw new NotImplementedException();
        }

        public string BorModosit_WEB(Borok borok)
        {
            throw new NotImplementedException();
        }

        public string BorTorol_CS(int id)
        {
            throw new NotImplementedException();
        }

        public string BorTorol_WEB(int id)
        {
            throw new NotImplementedException();
        }
    }
}

