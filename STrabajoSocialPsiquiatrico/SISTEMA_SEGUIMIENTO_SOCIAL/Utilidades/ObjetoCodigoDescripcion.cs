using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SISTEMA_SEGUIMIENTO_SOCIAL.Utilidades
{
    public class ObjetoCodigoDescripcion
    {


        private string codigo;
        private string descripcion;

        public string Codigo{
            set { this.codigo = value; }
            get { return this.codigo;}
        }

        public string Descripcion
        {
            set { this.descripcion = value; }
            get { return this.descripcion; }
        }

        public static string DisplayMember = "Descripcion";
        public static string ValueMember = "Codigo";

        public ObjetoCodigoDescripcion(string codigo, string descripcion)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
        }

        public ObjetoCodigoDescripcion()
        {
            // TODO: Complete member initialization
        }

        public static List<ObjetoCodigoDescripcion> generarListaClasesActividades()
        {
            List<ObjetoCodigoDescripcion> listaActividades = new List<ObjetoCodigoDescripcion>();
            listaActividades.Add(new ObjetoCodigoDescripcion("G", "ADMINISTRATIVA"));
            listaActividades.Add(new ObjetoCodigoDescripcion("P", "PACIENTE"));

            return listaActividades;
        }

        public static List<ObjetoCodigoDescripcion> generarListaTiposServicios()
        {
            List<ObjetoCodigoDescripcion> listaSexo = new List<ObjetoCodigoDescripcion>();
            listaSexo.Add(new ObjetoCodigoDescripcion("E", "EXTERNO"));
            listaSexo.Add(new ObjetoCodigoDescripcion("I", "INTERNO"));

            return listaSexo;
        }

        //I','R','S'
        public static List<ObjetoCodigoDescripcion> generarListaClasesServicios()
        {
            List<ObjetoCodigoDescripcion> listaSexo = new List<ObjetoCodigoDescripcion>();
            listaSexo.Add(new ObjetoCodigoDescripcion("I", "INGRESO"));
            listaSexo.Add(new ObjetoCodigoDescripcion("R", "REINGRESO"));
            listaSexo.Add(new ObjetoCodigoDescripcion("S", "ATENCIÓN MEDICA"));
            return listaSexo;
        }

        public static List<ObjetoCodigoDescripcion> generarListaSexo()
        {
            List<ObjetoCodigoDescripcion> listaSexo = new List<ObjetoCodigoDescripcion>();
            listaSexo.Add(new ObjetoCodigoDescripcion("M","MASCULINO"));
            listaSexo.Add(new ObjetoCodigoDescripcion("F","FEMENINO"));
            
            return listaSexo;
        }

        public static List<ObjetoCodigoDescripcion> generarListaTipoUsuario()
        {
            List<ObjetoCodigoDescripcion> listaSexo = new List<ObjetoCodigoDescripcion>();
            listaSexo.Add(new ObjetoCodigoDescripcion("A", "ADMINISTRADOR"));
            listaSexo.Add(new ObjetoCodigoDescripcion("T", "TRABAJADOR(A) SOCIAL"));

            return listaSexo;
        }

        public static List<ObjetoCodigoDescripcion> generarRelacionesFamiliares()
        {
            List<ObjetoCodigoDescripcion> listaRelacionesFamiliares = new List<ObjetoCodigoDescripcion>();
            listaRelacionesFamiliares.Add(new ObjetoCodigoDescripcion("B", "BUENA"));
            listaRelacionesFamiliares.Add(new ObjetoCodigoDescripcion("R", "REGULAR"));
            listaRelacionesFamiliares.Add(new ObjetoCodigoDescripcion("M", "MALA"));

            return listaRelacionesFamiliares;
        }

        //'P'->Proceso,'A'->Anulado,'F'->Finalizado 
        public static List<ObjetoCodigoDescripcion> generarListaEstadoReferencia()
        {
            List<ObjetoCodigoDescripcion> listaRelacionesFamiliares = new List<ObjetoCodigoDescripcion>();
            listaRelacionesFamiliares.Add(new ObjetoCodigoDescripcion("P", "PROCESO"));
            listaRelacionesFamiliares.Add(new ObjetoCodigoDescripcion("A", "ANULADO"));
            listaRelacionesFamiliares.Add(new ObjetoCodigoDescripcion("F", "FINALIZADO"));

            return listaRelacionesFamiliares;
        }

        //'I'->INSTITUCIONAL [INTERCONSULTA] , 'O'->OTROS 
        public static List<ObjetoCodigoDescripcion> generarListaTipoReferencia()
        {
            List<ObjetoCodigoDescripcion> listaRelacionesFamiliares = new List<ObjetoCodigoDescripcion>();
            listaRelacionesFamiliares.Add(new ObjetoCodigoDescripcion("I", "UN CENTRO MEDICO"));
            listaRelacionesFamiliares.Add(new ObjetoCodigoDescripcion("O", "OTRA INSTITUCION"));            

            return listaRelacionesFamiliares;
        }


        //'M'->MUY BUENA,'B'->BUENA,'R'->REGULAR,'L'->MALA
        public static List<ObjetoCodigoDescripcion> generarListaCondicionesVivienda()
        {
            List<ObjetoCodigoDescripcion> listaRelacionesFamiliares = new List<ObjetoCodigoDescripcion>();
            listaRelacionesFamiliares.Add(new ObjetoCodigoDescripcion("M", "MUY BUENA"));
            listaRelacionesFamiliares.Add(new ObjetoCodigoDescripcion("B", "BUENA"));            
            listaRelacionesFamiliares.Add(new ObjetoCodigoDescripcion("R", "REGULAR"));
            listaRelacionesFamiliares.Add(new ObjetoCodigoDescripcion("M", "MALA"));
            
            return listaRelacionesFamiliares;
        }

        
        public static List<ObjetoCodigoDescripcion> generarListaLugarVivienda()
        {
            List<ObjetoCodigoDescripcion> listaRelacionesFamiliares = new List<ObjetoCodigoDescripcion>();
            listaRelacionesFamiliares.Add(new ObjetoCodigoDescripcion("C", "CASA"));
            listaRelacionesFamiliares.Add(new ObjetoCodigoDescripcion("D", "DEPARTAMENTO"));            
            listaRelacionesFamiliares.Add(new ObjetoCodigoDescripcion("H", "HABITACION"));
            listaRelacionesFamiliares.Add(new ObjetoCodigoDescripcion("O", "OTROS"));

            return listaRelacionesFamiliares;
        }

         //--'P'->PROPIA,'A'->ALQUILADA,'N'->ANTICRETICO,'O'->OTROS
        public static List<ObjetoCodigoDescripcion> generarListaTipoVivienda()
        {
            List<ObjetoCodigoDescripcion> listaRelacionesFamiliares = new List<ObjetoCodigoDescripcion>();
            listaRelacionesFamiliares.Add(new ObjetoCodigoDescripcion("P", "PROPIA"));
            listaRelacionesFamiliares.Add(new ObjetoCodigoDescripcion("A", "ALQUILADA"));
            listaRelacionesFamiliares.Add(new ObjetoCodigoDescripcion("N", "ANTICRETICO"));
            listaRelacionesFamiliares.Add(new ObjetoCodigoDescripcion("C", "CEDIDA"));

            return listaRelacionesFamiliares;
        }

        //'E'->'RESPONSABLE ECONOMICO', 'F'->FAMILIAR, 'R'->SOLO RESPONSABLE, 'A'->Ambos(Familiar y Economico)
        public static List<ObjetoCodigoDescripcion> generarListaTipoResponsable()
        {
            List<ObjetoCodigoDescripcion> listaTiposResponsables = new List<ObjetoCodigoDescripcion>();
            listaTiposResponsables.Add(new ObjetoCodigoDescripcion("R", "SOLO RESPONSABLE"));
            listaTiposResponsables.Add(new ObjetoCodigoDescripcion("E", "RESPONSABLE ECONOMICO"));
            //listaTiposResponsables.Add(new ObjetoCodigoDescripcion("F", "FAMILIAR"));            
            listaTiposResponsables.Add(new ObjetoCodigoDescripcion("A", "AMBOS"));

            return listaTiposResponsables;
        }

        public static List<ObjetoCodigoDescripcion> generarListaEstadoCivil()
        {//DE','SO','CA','VI','DI','CO')),
            List<ObjetoCodigoDescripcion> listaEstadoCivil = new List<ObjetoCodigoDescripcion>();
            listaEstadoCivil.Add(new ObjetoCodigoDescripcion("DE", "DESCONOCIDO"));
            listaEstadoCivil.Add(new ObjetoCodigoDescripcion("SO", "SOLTERO(A)"));
            listaEstadoCivil.Add(new ObjetoCodigoDescripcion("CA", "CASADO(A)"));
            listaEstadoCivil.Add(new ObjetoCodigoDescripcion("VI", "VIUDO(A)"));
            listaEstadoCivil.Add(new ObjetoCodigoDescripcion("DI", "DIVORCIADO(A)"));
            listaEstadoCivil.Add(new ObjetoCodigoDescripcion("CO", "CONCUBINADO(A)"));

            return listaEstadoCivil;
        }

        public static List<ObjetoCodigoDescripcion> generarListaIdioma()
        {
            List<ObjetoCodigoDescripcion> listaIdiomas = new List<ObjetoCodigoDescripcion>();
            listaIdiomas.Add(new ObjetoCodigoDescripcion("E", "ESPAÑOL"));
            listaIdiomas.Add(new ObjetoCodigoDescripcion("Q", "QUECHUA"));
            listaIdiomas.Add(new ObjetoCodigoDescripcion("Y", "AYMARA"));
            listaIdiomas.Add(new ObjetoCodigoDescripcion("G", "GUARANI"));
            listaIdiomas.Add(new ObjetoCodigoDescripcion("I", "INGLES"));
            listaIdiomas.Add(new ObjetoCodigoDescripcion("A", "ALEMAN"));
            listaIdiomas.Add(new ObjetoCodigoDescripcion("M", "MUDO"));
            listaIdiomas.Add(new ObjetoCodigoDescripcion("O", "OTROS"));

            return listaIdiomas;
        }

        public static List<ObjetoCodigoDescripcion> generarListaGradoInstruccion()
        {//'A','P','S','U','T','S')),
            List<ObjetoCodigoDescripcion> listaGradoInstruccion = new List<ObjetoCodigoDescripcion>();
            listaGradoInstruccion.Add(new ObjetoCodigoDescripcion("A", "ANALFABETO"));
            listaGradoInstruccion.Add(new ObjetoCodigoDescripcion("P", "PRIMARIA"));
            listaGradoInstruccion.Add(new ObjetoCodigoDescripcion("S", "SECUNDARIA"));
            listaGradoInstruccion.Add(new ObjetoCodigoDescripcion("U", "UNIVERSITARIA"));
            listaGradoInstruccion.Add(new ObjetoCodigoDescripcion("T", "TECNICO SUPERIOR"));
            listaGradoInstruccion.Add(new ObjetoCodigoDescripcion("R", "SUPERIOR"));

            return listaGradoInstruccion;
        }


//        'C','E','R',
//'A','T','M','J','P','D','N','O')),--'C'->Catolico,'E'->Evangelico,'R'->Cristiano, --DE LA OTRA BD
//--A->Adventista,'T'->Ateo,'M'->Mormon,'J'->TestigoJeova,'P'->Protestante,'D'->Desconocido,
//--'N'->Ninguno,'O'->Otros)

        public static List<ObjetoCodigoDescripcion> generarListaReligion()
        {//'A','P','S','U','T','S')),
            List<ObjetoCodigoDescripcion> listaReligion = new List<ObjetoCodigoDescripcion>();
            listaReligion.Add(new ObjetoCodigoDescripcion("C", "CATOLICO"));
            listaReligion.Add(new ObjetoCodigoDescripcion("E", "EVANGELICO"));
            listaReligion.Add(new ObjetoCodigoDescripcion("R", "CRISTIANO"));
            listaReligion.Add(new ObjetoCodigoDescripcion("A", "ADVENTISTA"));
            listaReligion.Add(new ObjetoCodigoDescripcion("T", "ATEO"));
            listaReligion.Add(new ObjetoCodigoDescripcion("M", "MORMON"));
            listaReligion.Add(new ObjetoCodigoDescripcion("J", "TESTIGO DE JEHOVA"));
            listaReligion.Add(new ObjetoCodigoDescripcion("P", "PROTESTANTE"));
            listaReligion.Add(new ObjetoCodigoDescripcion("D", "DESCONOCIDO"));
            listaReligion.Add(new ObjetoCodigoDescripcion("N", "NINGUNO"));
            listaReligion.Add(new ObjetoCodigoDescripcion("O", "OTROS"));

            return listaReligion;
        }

        public static String obtenerSignificadoCodigoEstadoCivil(string CodigoEstadoCivil)
        {
            switch (CodigoEstadoCivil)
            {
                case "DE" : return "DESCONOCIDO";
                case "SO" : return "SOLTERO(A)";
                case "CA" : return  "CASADO(A)";
                case "VI" : return "VIUDO(A)";
                case "DI" : return "DIVORCIADO(A)";
                case "CO" : return "CONCUBINADO(A)";
                default : return "";
            }
        }

        public static String obtenerSignificadoCodigoReligion(string CodigoReligion)
        {
            switch (CodigoReligion)
            {
                case "C": return "CATOLICO";
                case "E": return "EVANGELICO";
                case "R": return "CRISTIANO";
                case "A": return "ADVENTISTA";
                case "T": return "ATEO";
                case "M": return "MORMON";
                case "J": return "TESTIGO DE JEHOVA";
                case "P": return "PROTESTANTE";
                case "D": return "DESCONOCIDO";
                case "N": return "NINGUNO";
                case "O": return "OTROS";
                default: return "";
            }
        }

        public static String obtenerSignificadoCodigoGradoInstruccion(string CodigoGradoInstruccion)
        {
            switch (CodigoGradoInstruccion)
            {
               case "A": return "ANALFABETO";
               case "P": return "PRIMARIA";
               case "S": return "SECUNDARIA";
               case "U": return "UNIVERSITARIA";
               case "T": return "TECNICO SUPERIOR";
               case "R" : return "SUPERIOR";
               default: return "";
             }         
        }

    }
}
