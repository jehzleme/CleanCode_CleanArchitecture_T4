namespace CleanCodeCleanArchitecture.Dominio
{
    public class Item
    {
        public string Descricao { get; private set; }
        public double Preco { get; private set; }
        public int Quantidade { get; private set; }

        public Item(string descricao, double preco, int quantidade)
        {
            Descricao = descricao;
            Preco = preco;
            Quantidade = quantidade;
        }
    }
}