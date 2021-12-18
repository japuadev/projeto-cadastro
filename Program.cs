using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunes = new Aluno[5];
            int i = 0;
            string opcaoUsuario = MenuUsuario();

            while(opcaoUsuario != "0")
            {
                switch(opcaoUsuario)
                {
                    case "1": 
                        Console.WriteLine("Digite o nome do alune: ");
                        Aluno alune = new Aluno();
                        alune.Nome = Console.ReadLine();
                        Console.WriteLine();

                        Console.WriteLine("Digite a nota do alune: ");
                        if(decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            alune.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota precisa ser decimal.");
                        }

                        alunes[i] = alune;
                        i++;

                        break;
                    
                    case "2":
                        foreach(var a in alunes)
                        {
                            if(a.Nota > 0){
                            Console.WriteLine($"ALUNE: {a.Nome} - NOTA: {a.Nota}");
                            }
                        }

                        break;
                    
                    case "3":
                        decimal notaTotal = 0;
                        var numAlunes = 0;
                        
                        for(int j = 0; j < alunes.Length; j++)
                        {
                            if(alunes[i].Nota > 0)
                            {
                                notaTotal = notaTotal + alunes[i].Nota;
                                numAlunes++;
                            }
                        }

                        var mediaGeral = notaTotal/numAlunes;
                        Conceito conceitoMedia;

                        if(mediaGeral < 2)
                        {
                            conceitoMedia = Conceito.E;
                        }
                        else if(mediaGeral <4)
                        {
                            conceitoMedia = Conceito.D;
                        }
                        
                        else if(mediaGeral <6)
                        {
                            conceitoMedia = Conceito.C;
                        }
                        
                        else if(mediaGeral <8)
                        {
                            conceitoMedia = Conceito.B;
                        }
                        
                        else
                        {
                            conceitoMedia = Conceito.A;
                        }

                        Console.WriteLine($"MEDIA GERAL: {mediaGeral}");
                        Console.WriteLine($"CONCEITO GERAL: {conceitoMedia}");

                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = MenuUsuario();
            }
        }

        static string MenuUsuario()
        {
            Console.WriteLine("__________________________");
            Console.WriteLine("|      MENU PROFESSOR     |");
            Console.WriteLine("|                         |");           
            Console.WriteLine("|    ESCOLHA A OPCAO:     |");
            Console.WriteLine("|  1 - Cadastrar Alune    |");
            Console.WriteLine("|  2 - Listar Alunes      |");
            Console.WriteLine("|  3 - Calcular Media     |");
            Console.WriteLine("|  0 - Sair               |");
            Console.WriteLine("|_________________________|");

            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
