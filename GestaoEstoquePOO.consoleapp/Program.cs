using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEstoquePOO.consoleapp
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Console.WriteLine("Gestão de Equipamentos em POO");
            Console.WriteLine();
            Controlador controler = new Controlador();
            controladorChamado controler1 = new controladorChamado();

            #region InfoEquipamento
            string nome, fabricante;
            double precoAquisicao;
            int nSerie;
            DateTime dataFabricacao;
            #endregion

            #region InfoChamado
            string chamado, equipamento, descricao;
            DateTime dataAbertura;
            #endregion

            while (true)
            {
               
                string MenuEntrada = EhOpcaoMenuEntrada();

                if (MenuEntrada.Equals("s", StringComparison.OrdinalIgnoreCase))
                    break;

                if (MenuEntrada == "1")
                {
                    string OpcaoDoCadastro = EhOpcaoCadastro();

                    switch (OpcaoDoCadastro)
                    {
                        case "1":
                            cadastro(out nome, out precoAquisicao, out nSerie);
                            informaocaocadastro(controler, nome, out fabricante, precoAquisicao, nSerie, out dataFabricacao);
                            break;

                        case "2":
                            ehVizualicacaoEquipamento(controler);
                            break;

                        case "3":
                            ehEditarEquipamento(controler);
                            break;

                        case "4":
                            ehVizualisarEquipamentolista(controler);
                            break;
                    }
                }
                else if (MenuEntrada == "2")
                {
                    string OpcaoChamado = EhOpcaoChamado();

                    if (MenuEntrada.Equals("s", StringComparison.OrdinalIgnoreCase))
                        break;

                    int diasaberto = 0;

                    
                    switch (OpcaoChamado)
                    {

                        case "1":

                            opcaoabrirChamado(controler1, out chamado, out equipamento, out descricao, out dataAbertura, diasaberto);
                            break;

                        case "2":
                            opcaoVizualicarChamado(controler1);
                            break;

                        case "3":
                            opcaoEditarChamado(controler, controler1, diasaberto);
                            break;

                        case "4":
                            ehOpcaoExcluirChamado(controler1);
                            break;
                    }
                }

            }



        }

        private static void ehOpcaoExcluirChamado(controladorChamado controler1)
        {
            controler1.VisualizaChamadosAbertos();

            Console.WriteLine("Digite o id do Chamado que deseja excluir: ");
            int idExcluir = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            controler1.ExcluirChamado(idExcluir);
            Console.ReadLine();
            Console.Clear();
        }

        private static void opcaoEditarChamado(Controlador controler, controladorChamado controler1, int diasaberto)
        {
            controler.VisualizaEquipamnetos();
            controler1.VisualizaChamadosAbertos();

            Console.WriteLine("Digite o id do equipamento que deseja editar: ");
            int idEditar = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            Console.Write("Digite o Titulo do Seu Chamado: ");
            string chamadoEdit = Console.ReadLine();

            Console.WriteLine("Digite o equipamento a qual Referese o Chamado: ");
            string equipamentoEdit = Console.ReadLine();

            Console.WriteLine("Descreva o problema apresentado pelo equipamento: ");
            string descricaoEdit = Console.ReadLine();

            Console.WriteLine("Digite a data de abertura do Chamado no formato dd/MM/yyyy: ");
            DateTime dataAberturaEdit = Convert.ToDateTime(Console.ReadLine());


            chamados chEditado = new chamados(chamadoEdit, equipamentoEdit, descricaoEdit, dataAberturaEdit, diasaberto);

            controler1.EditarChamado(idEditar, chEditado);
            Console.ReadLine();
            Console.Clear();
        }

        private static void opcaoVizualicarChamado(controladorChamado controler1)
        {
            controler1.VisualizaChamadosAbertos();
            Console.ReadLine();
            Console.Clear();
        }

        private static void opcaoabrirChamado(controladorChamado controler1, out string chamado, out string equipamento, out string descricao, out DateTime dataAbertura, int diasaberto)
        {
            Opcao1CadastroChamado(out chamado, out equipamento, out descricao, out dataAbertura);
            metodosdoChamado(controler1, chamado, equipamento, descricao, dataAbertura, diasaberto);
            Console.ReadLine();
            Console.Clear();
        }

        private static void metodosdoChamado(controladorChamado controler1, string chamado, string equipamento, string descricao, DateTime dataAbertura, int diasaberto)
        {
            chamados ch = new chamados(chamado, equipamento, descricao, dataAbertura, diasaberto);
            controler1.InsereChamado(ch);
        }

        private static void Opcao1CadastroChamado(out string chamado, out string equipamento, out string descricao, out DateTime dataAbertura)
        {
            Console.WriteLine("Digite o ID do equipamento para abertura de chamado:");
            int Ids = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o Titulo do Seu Chamado: ");
            chamado = Console.ReadLine();

            Console.WriteLine("Digite o equipamento a qual Referese o Chamado: ");
            equipamento = Console.ReadLine();

            Console.WriteLine("Descreva o problema apresentado pelo equipamento: ");
            descricao = Console.ReadLine();

            bool validaData1 = false;
            do
            {
                Console.Write("Digite a Data de abertura do Chamado no Formato dd/mm/yyyy: ");
                dataAbertura = Convert.ToDateTime(Console.ReadLine());
                if ((Convert.ToDateTime(dataAbertura)) >= (Convert.ToDateTime(DateTime.Now)))
                {
                    validaData1 = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A Data de Abertura Não pode ser Maior que a Data de Hoje!");
                    Console.ResetColor(); ;
                }

                break;

            } while (validaData1);
        }

        private static void informaocaocadastro(Controlador controler, string nome, out string fabricante, double precoAquisicao, int nSerie, out DateTime dataFabricacao)
        {
            dataFabricacao = datafabricacao();
            fabricante = ehFabricante();

            metodocadastro(controler, nome, fabricante, precoAquisicao, nSerie, dataFabricacao);

            Console.ReadLine();
            Console.Clear();
        }

        private static void ehVizualisarEquipamentolista(Controlador controler)
        {
            controler.VisualizaEquipamnetos();

            Console.WriteLine("Digite o id do equipamento que deseja excluir: ");
            int idExcluir = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            controler.ExcluirEquipamentos(idExcluir);
            Console.ReadLine();
            Console.Clear();
        }

        private static void ehEditarEquipamento(Controlador controler)
        {
            controler.VisualizaEquipamnetos();

            Console.WriteLine("Digite o id do equipamento que deseja editar: ");
            int idEditar = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Insira o nome do equipamento: ");
            string nomeEditado = Console.ReadLine();

            Console.WriteLine("Insira o preço de aquisição: ");
            double precoAquisicaoEditado = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Insira o número de série: ");
            int nSerieEditado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Insira a data: ");
            DateTime dataFabricacaoEditado = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Insira o fabricante: ");
            string fabricanteEditado = Console.ReadLine();

            equipamento eEditado = new equipamento(nomeEditado, precoAquisicaoEditado, nSerieEditado, dataFabricacaoEditado, fabricanteEditado);

            controler.EditarEquipamentos(idEditar, eEditado);
            Console.ReadLine();
            Console.Clear();
        }

        private static void ehVizualicacaoEquipamento(Controlador controler)
        {
            controler.VisualizaEquipamnetos();
            Console.ReadLine();
            Console.Clear();
        }

        private static void metodocadastro(Controlador controler, string nome, string fabricante, double precoAquisicao, int nSerie, DateTime dataFabricacao)
        {
            equipamento e = new equipamento(nome, precoAquisicao, nSerie, dataFabricacao, fabricante);
            controler.InsereEquipamnetos(e);
        }

        private static string ehFabricante()
        {
            string fabricante;
            Console.WriteLine("Digite o fabricante do equipamento: ");
            fabricante = Console.ReadLine();
            return fabricante;
        }

        private static DateTime datafabricacao()
        {
            DateTime dataFabricacao;
            bool validaData = false;
            do
            {
                Console.Write("Digite a Data de Fabricação do Equipamento no Formato dd/mm/yyyy: ");
                dataFabricacao = Convert.ToDateTime(Console.ReadLine());
                if ((Convert.ToDateTime(dataFabricacao)) >= (Convert.ToDateTime(DateTime.Now)))
                {
                    validaData = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A Data de Fabricação Não pode ser Maior que a Data de Hoje!");
                    Console.ResetColor();
                   
                }
                break;
            } while (validaData);
            
            return dataFabricacao;
        }

        private static void cadastro(out string nome, out double precoAquisicao, out int nSerie)
        {
            bool nomeInvalido = false;
            do
            {
                Console.Write("Digite o nome do equipamento: ");
                nome = Console.ReadLine();
                if (nome.Length < 6)
                {
                    nomeInvalido = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nome inválido. No mínimo 6 caracteres");
                    Console.ResetColor(); ;
                }

            } while (nomeInvalido);

            Console.WriteLine("Digite o preço de aquisição do equipamento: ");
            precoAquisicao = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Digite o número de série do equipamento: ");
            nSerie = Convert.ToInt32(Console.ReadLine());
        }

        private static string EhOpcaoChamado()
        {
            Console.WriteLine("Digite 1 para registrar Chamado: ");
            Console.WriteLine("Digite 2 para visualizar Chamado: ");
            Console.WriteLine("Digite 3 para editar Chamado: ");
            Console.WriteLine("Digite 4 para excluir Chamado: ");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();
            Console.Clear();
            return opcao;
        }

        private static string EhOpcaoMenuEntrada()
        {
            Console.WriteLine("Digite 1 para o Cadastro de Equipamentos");
            Console.WriteLine("Digite 2 para o Controle de Chamados");

            Console.WriteLine("Digite S para Sair");

            string opcao = Console.ReadLine();
            return opcao;
        }

        private static string EhOpcaoCadastro()
        {
            Console.WriteLine("Digite 1 para registrar equipamento: ");
            Console.WriteLine("Digite 2 para visualizar equipamento: ");
            Console.WriteLine("Digite 3 para editar equipamento: ");
            Console.WriteLine("Digite 4 para excluir equipamento: ");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();
            Console.Clear();
            return opcao;
        }
    }
}
