namespace CCCA.Aplicacao
{
    public class PedidoFeitoCommand
    {
        public double Total { get; set; }

        public PedidoFeitoCommand(double total)
        {
            Total = total;
        }
    }
}