using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEstoquePOO.consoleapp
{
    internal class controladorChamado
    {
        private int id = 1;
        private int cont = 0;
        private chamados[] arrayChamados = new chamados[100];
        private int[] ids = new int[99];
        

        public chamados[] ArrayChamados { get => arrayChamados; set => arrayChamados = value; }

        internal void InsereChamado(chamados ch)
        {
            arrayChamados[cont] = ch;
            ids[cont] = id;
            cont++;
            id++;
        }

        internal void VisualizaChamadosAbertos()
        {
            Console.WriteLine("Lista de Chamados Abertos: ");
            Console.WriteLine("");   
            for (int i = 0; i < ArrayChamados.Length; i++)
            {
                if (ArrayChamados[i] == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Nenhum Chamado Aberto Até O Momento !!");
                }
               else if (ArrayChamados[i] != null)
                {
                    Console.WriteLine("Id " + ids[i] + "\n" + ArrayChamados[i]);
                    Console.WriteLine("----------------");
                    
                }
            }
           
        }

        internal void EditarChamado(int id, chamados chEditado)
        {
            for (int i = 0; i < ArrayChamados.Length; i++)
            {
                if (ArrayChamados[i] != null)
                {
                    if (ids[i] == id)
                    {
                        ArrayChamados.SetValue(chEditado, i);
                    }
                }
            }
        }

        internal void ExcluirChamado(int id)
        {
            for (int i = 0; i < ArrayChamados.Length; i++)
            {
                if (ArrayChamados[i] != null)
                {
                    if (ids[i] == id)
                    {
   
                        ArrayChamados = ArrayChamados.Where(val => val != ArrayChamados[i]).ToArray();
                        ids = ids.Where(val => val != ids[i]).ToArray();
                    }
                  
                }
            }
            
        }
    }

}