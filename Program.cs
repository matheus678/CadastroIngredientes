using System;
using CadastroIngredientes.db;

namespace CadastroIngredientes
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new hamburgueriaContext())
            {
                bool finalizar = false;
                while (!finalizar)
                {
                    Console.Write("Qual ingrediente você gostaria de adicionar na hamburgueria?");
                    string name = Console.ReadLine();
                    Console.Write($"O ingrediente {name} é do tipo 1(pão) 2(carne) ou 3(extra)? ");
                    int tipo = Convert.ToInt32(Console.ReadLine());

                    if (tipo != 1 && tipo != 2 && tipo != 3) 
                    {
                        Console.WriteLine("Digite um número válido");
                    }
                    else
                    {
                        var novoIngrediente = new Ingrediente
                        {
                            Id = Guid.NewGuid().ToString(),
                            Nome = name,
                            TipoIngredienteId = tipo,
                        };

                        db.Ingrediente.Add(novoIngrediente);
                        db.SaveChanges();
                        Console.WriteLine("Tudo certo! Seu ingrediente foi inserido com sucesso.");
                        Console.ReadKey();
                        finalizar = true;
                    }
                }
            }
        }
    }
}

