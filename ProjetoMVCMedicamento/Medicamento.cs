using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMedicamento
{
    internal class Medicamento
    {
        private int id;
        private string nome;
        private string laboratorio;
        private Queue<Lote> lotes;

        public Medicamento()
        {
            lotes = new Queue<Lote>();
        }

        public Medicamento(int id, string nome, string laboratorio)
        {
            this.id = id;
            this.nome = nome;
            this.laboratorio = laboratorio;
            lotes = new Queue<Lote>();
        }

        public Queue<Lote> Lotes
        {
            get { return lotes; }
        }

        public Queue<Lote> GetLotes()
        {
            return lotes;
        }


        public int QtdeDisponivel()
        {
            int qtdeTotal = 0;
            foreach (var lote in lotes)
            {
                qtdeTotal += lote.Qtde;
            }
            return qtdeTotal;
        }

        public void Comprar(Lote lote)
        {
            lotes.Enqueue(lote);
        }

        public bool Vender(int qtde)
        {
            int qtdeRestante = qtde;
            Queue<Lote> lotesTemp = new Queue<Lote>();

            while (lotes.Count > 0 && qtdeRestante > 0)
            {
                Lote loteAtual = lotes.Dequeue();
                if (loteAtual.Qtde > qtdeRestante)
                {
                    loteAtual.Qtde -= qtdeRestante;
                    lotesTemp.Enqueue(loteAtual);
                    qtdeRestante = 0;
                }
                else
                {
                    qtdeRestante -= loteAtual.Qtde;
                }
            }

            if (qtdeRestante > 0) return false;

            while (lotesTemp.Count > 0)
            {
                lotes.Enqueue(lotesTemp.Dequeue());
            }

            return true;
        }


        public override string ToString()
        {
            return $"{id}-{nome}-{laboratorio}-{QtdeDisponivel()}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Medicamento)
            {
                Medicamento outro = (Medicamento)obj;
                return this.id == outro.id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
    }
}
