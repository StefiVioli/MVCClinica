using MVCClinica.Data;
using MVCClinica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCClinica.Repositorio
{

    static public class AdminMedico
    {
        private static MedicoDbContext context = new MedicoDbContext();


        //Listar todos
        public static List<Medico> Listar()
        {
            var medicos = context.Medicos.ToList();
            return medicos;
        }

        //Carga
        public static void Cargar(Medico medico)
        {
            context.Medicos.Add(medico);
            context.SaveChanges();
        }

        //Modificación
        public static void Modificar(Medico medico)
        {
            //context.Entry(medico).State = EntityState.Modified;
            context.Medicos.Attach(medico);
            context.SaveChanges();
        }

        public static Medico BuscarMedicoId(int id)
        {
            Medico medico = context.Medicos.Find(id);
            context.Entry(medico).State = EntityState.Detached;
            return medico;
        }


        //Eliminación
        public static void Eliminar(Medico medico)
        {
            context.Medicos.Remove(medico);
            context.SaveChanges();
        }

        //Traer médicos por especialidad
        public static List<Medico> TraerPorEspecialidad(string especialidad)
        {
            List<Medico> medicosEspecialidad = (from m in context.Medicos
                                                where m.Especialidad == especialidad
                                                select m).ToList();
            return medicosEspecialidad;
        }

    }
}




//Ver detalle de un médico por Id 
