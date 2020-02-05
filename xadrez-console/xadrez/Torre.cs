using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(cor, tab)
        {

        }
        public override string ToString()
        {
            return "T";
        }
        private bool PodeMover(Posicao posicao)
        {
            Peca p = Tab.Peca(posicao);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao posicao = new Posicao(0, 0);

            //cima
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while(Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tab.Peca(posicao) != null && Tab.Peca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.Linha = posicao.Linha - 1;
            }

            //abaixo
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tab.Peca(posicao) != null && Tab.Peca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.Linha = posicao.Linha + 1;
            }

            //direita
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tab.Peca(posicao) != null && Tab.Peca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.Coluna = posicao.Coluna + 1;
            }
            //esquerda
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tab.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tab.Peca(posicao) != null && Tab.Peca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.Coluna = posicao.Coluna - 1;
            }

            return mat;
        }
    }
}
