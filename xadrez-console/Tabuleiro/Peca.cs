using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtoMovimento { get; set; }
        public Tabuleiro Tab { get; set; }

        public Peca(Cor cor, Tabuleiro tab)
        {
            Posicao = null;
            Cor = cor;
            QtoMovimento = 0;
            Tab = tab;
        }

        public void IncrementarQtemovimentos()
        {
            QtoMovimento++;
        }

        public abstract bool[,] MovimentosPossiveis();
        

    }
}
