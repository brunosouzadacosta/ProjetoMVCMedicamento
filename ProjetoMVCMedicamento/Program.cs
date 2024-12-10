using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMedicamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Medicamentos medicamentos = new Medicamentos();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("0. Finalizar processo");
                Console.WriteLine("1. Cadastrar medicamento");
                Console.WriteLine("2. Consultar medicamento (sintético)");
                Console.WriteLine("3. Consultar medicamento (analítico)");
                Console.WriteLine("4. Comprar medicamento (cadastrar lote)");
                Console.WriteLine("5. Vender medicamento (abater do lote mais antigo)");
                Console.WriteLine("6. Listar medicamentos");

                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        continuar = false;
                        break;
                    case 1:
                        CadastrarMedicamento(medicamentos);
                        break;
                    case 2:
                        ConsultarMedicamentoSintetico(medicamentos);
                        break;
                    case 3:
                        ConsultarMedicamentoAnalitico(medicamentos);
                        break;
                    case 4:
                        ComprarMedicamento(medicamentos);
                        break;
                    case 5:
                        VenderMedicamento(medicamentos);
                        break;
                    case 6:
                        ListarMedicamentos(medicamentos);
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        static void CadastrarMedicamento(Medicamentos medicamentos)
        {
            Console.WriteLine("Informe o ID do medicamento:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o nome do medicamento:");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe o laboratório do medicamento:");
            string laboratorio = Console.ReadLine();

            Medicamento medicamento = new Medicamento(id, nome, laboratorio);
            medicamentos.Adicionar(medicamento);
            Console.WriteLine("Medicamento cadastrado com sucesso!");
        }

        static void ConsultarMedicamentoSintetico(Medicamentos medicamentos)
        {
            Console.WriteLine("Informe o ID do medicamento para consulta:");
            int id = int.Parse(Console.ReadLine());
            Medicamento medicamento = medicamentos.Pesquisar(new Medicamento(id, "", ""));
            if (medicamento != null)
            {
                Console.WriteLine(medicamento.ToString());
            }
            else
            {
                Console.WriteLine("Medicamento não encontrado.");
            }
        }

        static void ConsultarMedicamentoAnalitico(Medicamentos medicamentos)
        {
            Console.WriteLine("Informe o ID do medicamento para consulta:");
            int id = int.Parse(Console.ReadLine());
            Medicamento medicamento = medicamentos.Pesquisar(new Medicamento(id, "", ""));
            if (medicamento != null)
            {
                Console.WriteLine(medicamento.ToString());
                foreach (var Medicamento in medicamentos.ListaMedicamentos)
                {
                    Console.WriteLine(medicamento.ToString());

                    foreach (var lote in medicamento.GetLotes())
                    {
                        Console.WriteLine(lote.ToString());
                    }
                }
            }
            else
            {
                Console.WriteLine("Medicamento não encontrado.");
            }
        }

        static void ComprarMedicamento(Medicamentos medicamentos)
        {
            Console.WriteLine("Informe o ID do medicamento:");
            int id = int.Parse(Console.ReadLine());
            Medicamento medicamento = medicamentos.Pesquisar(new Medicamento(id, "", ""));
            if (medicamento != null)
            {
                Console.WriteLine("Informe o ID do lote:");
                int loteId = int.Parse(Console.ReadLine());
                Console.WriteLine("Informe a quantidade do lote:");
                int qtde = int.Parse(Console.ReadLine());
                Console.WriteLine("Informe a data de vencimento do lote (dd/MM/yyyy):");
                DateTime venc = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                Lote lote = new Lote(loteId, qtde, venc);
                medicamento.Comprar(lote);
                Console.WriteLine("Lote comprado com sucesso!");
            }
            else
            {
                Console.WriteLine("Medicamento não encontrado.");
            }
        }

        static void VenderMedicamento(Medicamentos medicamentos)
        {
            Console.WriteLine("Informe o ID do medicamento:");
            int id = int.Parse(Console.ReadLine());
            Medicamento medicamento = medicamentos.Pesquisar(new Medicamento(id, "", ""));
            if (medicamento != null)
            {
                Console.WriteLine("Informe a quantidade a ser vendida:");
                int qtde = int.Parse(Console.ReadLine());
                if (medicamento.Vender(qtde))
                {
                    Console.WriteLine("Venda realizada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não há quantidade suficiente para a venda.");
                }
            }
            else
            {
                Console.WriteLine("Medicamento não encontrado.");
            }
        }

        static void ListarMedicamentos(Medicamentos medicamentos)
        {
            foreach (var medicamento in medicamentos.ListaMedicamentos)
{
            Console.WriteLine(medicamento.ToString());

            // Acessando os lotes de cada medicamento
            foreach (var lote in medicamento.Lotes)
                {
                    Console.WriteLine(lote.ToString());
                }
}
        }
    }
}
