﻿using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public PartidaDeXadrez Partida;
        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(cor, tab)
        {
            Partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExisteInimigo(Posicao posicao)
        {
            Peca p = Tab.Peca(posicao);
            return p != null && p.Cor != Cor;
        }

        private bool Livre(Posicao posicao)
        {
            return Tab.Peca(posicao) == null;
        }

        private bool PodeMover(Posicao posicao)
        {
            Peca p = Tab.Peca(posicao);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            if (Cor == Cor.Branca)
            {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QtoMovimento == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                // #JogadaEspecial En Passant
                if (Posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna -1);
                    if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.Peca(esquerda) == Partida.VulneravelEnPassant)
                    {
                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }
                    
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.Peca(direita) == Partida.VulneravelEnPassant)
                    {
                        mat[direita.Linha -1, direita.Coluna] = true;
                    }
                }

            }
            else
            {
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QtoMovimento == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                // #JogadaEspecial En Passant
                if (Posicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.Peca(esquerda) == Partida.VulneravelEnPassant)
                    {
                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.Peca(direita) == Partida.VulneravelEnPassant)
                    {
                        mat[direita.Linha + 1, direita.Coluna] = true;
                    }
                }

            }
            
            return mat;
        }


    }
}
