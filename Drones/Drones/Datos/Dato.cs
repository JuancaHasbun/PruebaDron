
using Drones.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drones.Datos
{
    public class Dato
    {       
        List<Dron> listDron = new List<Dron>();
        List<Medicamentos> medicamentos = new List<Medicamentos>();
       public void Main(string[] args)
        {
            medicamentos.Add(new Medicamentos("Paracetamol", 100, "Codigo: 1", "Imagen: 1.jpg"));
            medicamentos.Add(new Medicamentos("Aspirina", 200, "Codigo: 2", "Imagen: 2.jpg"));
            medicamentos.Add(new Medicamentos("Diclofenaco", 300, "Codigo: 3", "Imagen: 3.jpg"));
            medicamentos.Add(new Medicamentos("Ibuprofeno", 400, "Codigo: 4", "Imagen: 4.jpg"));
            medicamentos.Add(new Medicamentos("Paracetamol", 500, "Codigo: 5", "Imagen: 5.jpg"));
          
        }
        public string crearDron(string num, string modelo, int peso, int capbat, string estado)
        {
            try
            {
                Dron dron = new Dron();
                dron.numeroDeSerie = num;
                dron.modelo = modelo;
                dron.peso = peso;
                dron.capbateria = capbat;
                dron.estado = estado;

                listDron.Add(dron);

                return JsonConvert.SerializeObject("Dron agregado con exito");
            }catch(Exception e)
            {
                string msg = "El error es" + e;
                return JsonConvert.SerializeObject(msg);
            }
            
        }

        public string cargarDron(string numDeSerie, string medicamento)
        {
            int peso = 0;
            string msg = string.Empty;
            foreach(Medicamentos medicamento1 in medicamentos)
            {
                if(medicamento1.Nombre == medicamento)
                {
                    peso = medicamento1.peso;
                }
            }    
            foreach(Dron dron in listDron)
            {
                if(dron.numeroDeSerie == numDeSerie)
                {
                    if(dron.peso + peso <= 500)
                    {
                        dron.peso += peso;
                    }
                    else
                    {
                      msg = "El peso exede el maximo";
                        return JsonConvert.SerializeObject(msg);
                    }
                    
                }
            }
            msg = "Dron Cargado";
            return JsonConvert.SerializeObject(msg);
        }

        public string DronParaCarga()
        {
            List<Dron> listCarga = new List<Dron>();

            foreach(Dron dron in listDron)
            {
                if(dron.estado == "INACTIVO")
                {
                    listCarga.Add(dron);
                }
            }

            return JsonConvert.SerializeObject(listCarga);
        }

        public string comprobarBateria(String numDeSerie)
        {
            string dron = string.Empty;
            foreach(Dron dronF in listDron)
            {
                if(dronF.numeroDeSerie == numDeSerie)
                {
                    dron = dronF.capbateria.ToString();
                    if(dronF.capbateria < 25)
                    {
                        dronF.estado = "CARGANDO";
                    }
                }
            }

            return JsonConvert.SerializeObject(dron);
        }

        public string comprobarPeso(String numDeSerie)
        {
            string dron = string.Empty;
            foreach (Dron dronF in listDron)
            {
                if (dronF.numeroDeSerie == numDeSerie)
                {
                    dron = dronF.peso.ToString();
                }
            }

            return JsonConvert.SerializeObject(dron);
        }



    }
}
