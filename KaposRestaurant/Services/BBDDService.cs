using KaposRestaurant.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaposRestaurant.Services
{
    public static class BbddService
    {
        private static readonly RestauranteBD _contexto = new RestauranteBD();

        static BbddService()
        {
            _contexto.CATEGORIAS.Load();
            _contexto.COMANDAS.Load();
            _contexto.FACTURAs.Load();
            _contexto.ELEMENTOS.Load();

        }

        public static ObservableCollection<FACTURA> GetFacturas()
        {
            return _contexto.FACTURAs.Local;
        }

        public static ObservableCollection<CATEGORIA> GetCategorias()
        {
            return _contexto.CATEGORIAS.Local;
        }

        public static ObservableCollection<ELEMENTO> GetElementos()
        {
            return _contexto.ELEMENTOS.Local;
        }

        public static ObservableCollection<COMANDA> GetComandas()
        {
            return _contexto.COMANDAS.Local;
        }

        public static int AddFactura(FACTURA item)
        {
            _contexto.FACTURAs.Add(item);
            return _contexto.SaveChanges();
        }

        public static int AddCategoria(CATEGORIA item)
        {
            _contexto.CATEGORIAS.Add(item);
            return _contexto.SaveChanges();
        }

        public static int AddComanda(COMANDA item)
        {
            _contexto.COMANDAS.Add(item);
            return _contexto.SaveChanges();
        }
        public static int AddElemento(ELEMENTO item)
        {
            _contexto.ELEMENTOS.Add(item);
            return _contexto.SaveChanges();
        }

        public static int DeleteFactura(FACTURA item)
        {
            _contexto.FACTURAs.Remove(item);
            return _contexto.SaveChanges();
        }
        public static int DeleteComanda(COMANDA item)
        {
            _contexto.COMANDAS.Remove(item);
            return _contexto.SaveChanges();
        }
        public static int DeleteElemento(ELEMENTO item)
        {
            _contexto.ELEMENTOS.Remove(item);
            return _contexto.SaveChanges();
        }
        public static int DeleteCategoria(CATEGORIA item)
        {
            _contexto.CATEGORIAS.Remove(item);
            return _contexto.SaveChanges();
        }

        public static int ActualizarBbdd()
        {
            return _contexto.SaveChanges();
        }

        public static bool ExisteCategoria(CATEGORIA item)
        {
            var consulta = from n in _contexto.CATEGORIAS
                           where n.NombreCategoria == item.NombreCategoria
                           select n;

            if (consulta.Count() > 0)
                return true;

            return false;
        }

        public static bool ExisteElemento(ELEMENTO item)
        {
            var consulta = from n in _contexto.ELEMENTOS
                           where n.NombreElemento == item.NombreElemento
                           select n;

            if (consulta.Count() <= 0)
                return false;

            return true;
        }

        public static bool HayElementosEnCategoria(CATEGORIA item)
        {
            var consulta = from n in _contexto.ELEMENTOS
                           where n.Categoria == item.IdCategoria
                           select n;

            if (consulta.Count() > 0)
                return true;

            return false;
        }

        public static ObservableCollection<ELEMENTO> GetElementosCategoria(CATEGORIA item)
        {
            var consulta = from n in _contexto.ELEMENTOS
                           where item.IdCategoria == n.Categoria
                           select n;

            return new ObservableCollection<ELEMENTO>(consulta.ToList());
        }
        
      
        public static ObservableCollection<ELEMENTO> GetElementoFactura(int id)
        {
            ObservableCollection<ELEMENTO> elementosresult = new ObservableCollection<ELEMENTO>();
            var consulta = from x in _contexto.FACTURAs
                           where id == x.IdComanda
                           select x;

            ObservableCollection<FACTURA> facturas_recuperadas = new ObservableCollection<FACTURA>(consulta.ToList());
            foreach(FACTURA x in facturas_recuperadas)
            {
                var consulta2 = from y in _contexto.ELEMENTOS
                                where x.IdElemento == y.IdElemento
                                select y;
                elementosresult.Add(consulta2.ToList().First());
               
            }

            return elementosresult;

        }

        public static int CantidadELementosFacturas(int id)
        {
            int resultado=0;
            var consulta = from x in _contexto.FACTURAs
                           where id == x.IdComanda
                           select x;
            foreach(FACTURA x in consulta)
            {
                resultado += x.CantidadElementos;
            }
            return resultado;
        }

        public static double CalcularPrecioPorELmento(int cantidad, int id)
        {
            double precio = 0;

            var consulta = from x in _contexto.ELEMENTOS
                           where x.IdElemento == id
                           select x;
            foreach(ELEMENTO y in consulta)
            {
                precio += y.Precio;
            }
            return precio;

        }

        



    }
}
