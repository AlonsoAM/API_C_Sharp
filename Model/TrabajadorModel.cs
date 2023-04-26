using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace novaltyAPI.Model
{
    public class TrabajadorModel
    {
        public int id { get; set; }
        public string dni { get; set; }
        public string trabajador { get; set; }
        public string cargo { get; set; }
        public string form_pago { get; set; }
        public string banco { get; set; }
        public string cuenta { get; set; }

    }

    public class ParamsInsertarTrabajadorModel
    {
        public string tra_dni { get; set; }
        public string tra_ape { get; set; }
        public string tra_nom { get; set; }
        public int id_car_tra { get; set; }
        public int id_form_pago { get; set; }
        public int id_ban { get; set; }
        public string tra_num_cue { get; set; }
    }

    public class ParamsActualizarTrabajadorModel
    {
        public int id_tra { get; set; }
        public string tra_dni { get; set; }
        public string tra_ape { get; set; }
        public string tra_nom { get; set; }
        public int id_car_tra { get; set; }
        public int id_form_pago { get; set; }
        public int id_ban { get; set; }
        public string tra_num_cue { get; set; }
    }
}