﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaClinica
{
    [Serializable]
    class Medico : Profesional
    {
        #region Atributo y Propiedad
        
        private enum EnumEspecialidad
        {
            Alergología, AnestesiologíayReanimación, Cardiología, Dermatología, Endocrinología, Gastroenterología, Geriatría, Ginecología, HematologíaYHemoterapia, HidrologíaMedica, Infectología, MedicinaAeroespacial, MedicinaDelDeporte, MedicinaDelTrabajo, MedicinaDeUrgencias, MedicinaFamiliarYComunitaria, MedicinaFísicaYRehabilitación, MedicinaIntensiva, MedicinaInterna, MedicinaLegalYForense, MedicinaPaliativa, MedicinaPreventivaYSaludPública, Nefrología, Neonatología, Neumología, Neurología, Nutriología, ObstetriciaespecialidadMédicaYObstetriciamatronería, Oftalmología, OncologíaMédica, OncologíaRadioterápica, Pediatría, Psiquiatría, Rehabilitación, Reumatología, ToxicologíaYUrología
        }
        private String _Especialidad;

        public String Especialidad 
        {            
            get { return Enum.GetName(typeof(EnumEspecialidad), this._Especialidad); }
            set { this._Especialidad = value; }
        }        
        
        #endregion


        #region Métodos        

        public void Diagnosticar()
        {

        }

        public void Tratar()
        {

        }

        public List<Paciente> PacientesListosParaAlta()
        {
            List<Paciente> listaPacientesCurados = new List<Paciente>();

            for (int i = 0; i < this.Pacientes.Count; i++)
            {
                if (this.Pacientes[i].EstaCurado == true)
                {
                    listaPacientesCurados.Add(this.Pacientes[i]);
                }
            }
            return listaPacientesCurados;
        }

        public Object LeeEnum(String especialidad)
        {
            String[] opcionesDisponibles = Enum.GetNames(typeof(EnumEspecialidad));
            String especialidadIntroducida;

            opcionesDisponibles[1].Insert(0, "Anestesiología y Reanimación"); opcionesDisponibles[8].Insert(0, "Hematología y Hemoterapia");
            opcionesDisponibles[11].Insert(0, "Medicina Aeroespacial"); opcionesDisponibles[12].Insert(0, "Medicina del Deporte");
            opcionesDisponibles[13].Insert(0, "Medicina del Trabajo"); opcionesDisponibles[14].Insert(0, "Medicina de Urgencias");
            opcionesDisponibles[15].Insert(0, "Medicina Familiar y Comunitaria"); opcionesDisponibles[16].Insert(0, "Medicina Física y Rehabilitación");
            opcionesDisponibles[17].Insert(0, "Medicina Intensiva"); opcionesDisponibles[18].Insert(0, "Medicina Interna");
            opcionesDisponibles[19].Insert(0, "Medicina Legal y Forense"); opcionesDisponibles[20].Insert(0, "Medicina Paliativa");
            opcionesDisponibles[21].Insert(0, "Medicina Preventiva y Salud Pública"); opcionesDisponibles[27].Insert(0, "Obstetricia (especialidad Médica) y Obstetricia (matronería)");
            opcionesDisponibles[30].Insert(0, "Oncología Radioterápica"); opcionesDisponibles[35].Insert(0, "Toxicología y Urología");

            while (true)
            {
                if (!Enum.IsDefined(typeof(EnumEspecialidad), especialidad))
                {
                    for (int i = 0; i < opcionesDisponibles.Length; i++)
                    {
                        Console.WriteLine(opcionesDisponibles[i]);
                    }

                    Console.WriteLine("Introduce la especialidad: ");
                    especialidadIntroducida = Console.ReadLine();
                }
                else
                {
                    this.Especialidad = Enum.GetName(typeof(EnumEspecialidad), especialidad);
                    return (EnumEspecialidad)Enum.Parse(typeof(EnumEspecialidad), especialidad);
                }
            }
        }

        #endregion


        #region Constructores

        public Medico() : base()
        {

        }

        public Medico(String nombre, String apellidos, String dni, String especialidad) : base(nombre, apellidos, dni)
        {
            LeeEnum(especialidad);
        }

        public Medico(Medico obj) : base(obj)
        {
            
        }

        #endregion
    }
}
