using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEstoquePOO.consoleapp
{
    class Controlador
    {
        private int id = 1;
        private int cont = 0;
        private equipamento[] arrayEquipamentos = new equipamento[100];
        private int[] ids = new int[99];

        public equipamento[] ArrayEquipamentos { get => arrayEquipamentos; set => arrayEquipamentos = value; }

        internal void InsereEquipamnetos(equipamento e)
        {
            arrayEquipamentos[cont] = e;
            ids[cont] = id;
            cont++;
            id++;

        }
        internal void VisualizaEquipamnetos()
        {

            Console.WriteLine("Equipamentos Cadastrados: ");
            Console.WriteLine("");
            for (int i = 0; i < arrayEquipamentos.Length; i++)
            {
                if (arrayEquipamentos[i] == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Nenhum Equipamento Cadsatrado !!");
                }
               else if (arrayEquipamentos[i] != null)
                {
                    Console.WriteLine("Id " + ids[i] + "\n" + arrayEquipamentos[i]);
                    Console.WriteLine("----------------");
                }
                
            }
           
        }

        internal void EditarEquipamentos(int id, equipamento eEditado)
        {
            for (int i = 0; i < arrayEquipamentos.Length; i++)
            {
                if (arrayEquipamentos[i] != null)
                {
                    if (ids[i] == id)
                    {
                        
                        arrayEquipamentos.SetValue(eEditado, i);
                    }
                }
            }

        }

        internal void ExcluirEquipamentos(int id)
        {

            for (int i = 0; i < arrayEquipamentos.Length; i++)
            {
                if (arrayEquipamentos[i] != null)
                {
                    if (ids[i] == id)
                    {

                        arrayEquipamentos = arrayEquipamentos.Where(val => val != arrayEquipamentos[i]).ToArray();
                        ids = ids.Where(val => val != ids[i]).ToArray();
                    }
                   
                }

            }
        }

    }
}
