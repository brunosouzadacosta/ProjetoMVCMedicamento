using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMedicamento
{
    internal class Medicamentos
    {
        private List<Medicamento> listaMedicamentos;

        public Medicamentos()
        {
            listaMedicamentos = new List<Medicamento>();
        }

        public List<Medicamento> ListaMedicamentos
        {
            get { return listaMedicamentos; }
        }

        public void Adicionar(Medicamento medicamento)
        {
            listaMedicamentos.Add(medicamento);
        }

        public bool Deletar(Medicamento medicamento)
        {
            if (medicamento.QtdeDisponivel() == 0)
            {
                listaMedicamentos.Remove(medicamento);
                return true;
            }
            return false;
        }

        public Medicamento Pesquisar(Medicamento medicamento)
        {
            foreach (var med in listaMedicamentos)
            {
                if (med.Equals(medicamento))
                {
                    return med;
                }
            }
            return null; // Retorna null se não encontrado
        }
    }
}
