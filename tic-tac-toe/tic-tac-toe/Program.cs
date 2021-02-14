using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
	class Program
	{
		static void Main(string[] args)
		{
			int[,] board = new int[3,3];
			int player = 1;
			int line=0, column=0;

            bool match = false;
            int retornoStatus;

			do
			{
				Console.Clear();
				Console.WriteLine("Jogo da velha!!!\n\n");
                
                Console.WriteLine("Partida em andamento...");
				imprimir_jogo(board);

				if(player % 2 != 0)
					readChoice(board, 1, ref line, ref column);
				else
					readChoice(board, 4, ref line, ref column);

                retornoStatus = verificaStatus(board);

                if (retornoStatus == 1)
                {
                    Console.Clear();
                    Console.WriteLine("---x---x---x---x--- Partida Finalizada ---x---x---x---x---");
                    Console.WriteLine("JOGADOR 1 GANHOU !!!");
			        imprimir_jogo(board);
                    match = true;
                }
                else
                   if(retornoStatus == 2)
                   {
                        Console.Clear();
                        Console.WriteLine("---x---x---x---x--- Partida Finalizada ---x---x---x---x---");
                        Console.WriteLine("JOGADOR 2 GANHOU !!!");
			            imprimir_jogo(board);
                        match = true;
                   }
                    else
                        if (retornoStatus == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("---x---x---x---x--- Partida Finalizada ---x---x---x---x---");
                            Console.WriteLine("EMPATE!!!");
			                imprimir_jogo(board);
                            match = true;
                        }

				player++;
			}while(!match);
        
			Console.WriteLine("Pressione qualquer tecla para sair...");
			Console.ReadKey();
		}

		static void readChoice(int[,] board, int player, ref int line, ref int column)
		{
			bool flag = false;

			do
			{
                if (player == 1)
                    Console.WriteLine("\nJogador 1");
                else
				    Console.WriteLine("\nJogador 2");
				Console.Write("Escolha a posição da linha: ");
				line = int.Parse(Console.ReadLine());
				Console.Write("Escolha a posição da coluna: ");
				column = int.Parse(Console.ReadLine());

				if(verificaPosicao(board, line, column))
				{
					board[line, column] = player;
					flag = false;
				}
				else
					flag = true;
					
			}while(flag);
		}

		static void imprimir_jogo(int[,] board)
		{
			Console.WriteLine("\n");
			Console.WriteLine("    0   1   2 \n");
			Console.WriteLine("0   "+board[0,0]+" | "+board[0,1]+" | "+board[0,2]);
			Console.WriteLine("   -----------");
			Console.WriteLine("1   "+board[1,0]+" | "+board[1,1]+" | "+board[1,2]);
			Console.WriteLine("   -----------");
			Console.WriteLine("2   "+board[2,0]+" | "+board[2,1]+" | "+board[2,2]);
		}


		static int verificaStatus(int[,] board)
		{
            int sum = 0;

			//Verificar linha:
            for (int line = 0; line < board.GetLength(0); line++)
            {
                for (int colunm = 0; colunm < board.GetLength(1); colunm++) 
                {
                    sum += board[line, colunm];
                }

                if (sum == 3)
                    return 1;
                else
                    if (sum == 12)
                        return 2;
            }

            //Verificar coluna:
            sum = 0;
            for (int colunm = 0; colunm < board.GetLength(0); colunm++)
            {
                for (int line = 0; line < board.GetLength(1); line++) 
                {
                    sum += board[line, colunm];
                }

                if (sum == 3)
                    return 1;
                else
                    if (sum == 12)
                        return 2;
            }

            //Verificar diagonal principal:
            sum = 0;
            for (int line = 0, colunm = 0; line < board.GetLength(0); line++, colunm++)
            {
                sum += board[line, colunm];

                if (sum == 3)
                    return 1;
                else if (sum == 12)
                    return 2;
            }

            //Verificar diagonal secundária:
            sum = 0;
            for (int line = 0, colunm = 2; line < board.GetLength(0); line++, colunm--) 
            {
               sum += board[line, colunm];

                if (sum == 3)
                    return 1;
                else if(sum == 12)
                    return 2;
            }

            //Empate
            sum = 0;
            for (int line = 0; line < board.GetLength(0); line++) 
            {
                for (int colunm = 0; colunm < board.GetLength(1); colunm++) 
                {
                    if(board[line, colunm] != 0)
                        sum++;
                }
            }

            if (sum == (board.GetLength(0) * board.GetLength(1)))
                return 0;

            return 3;
		}


		static bool verificaPosicao(int[,] board, int line, int column )
		{
			if(board[line, column] == 0 )
				return true;
			else
				return false;
		}

	}
}
