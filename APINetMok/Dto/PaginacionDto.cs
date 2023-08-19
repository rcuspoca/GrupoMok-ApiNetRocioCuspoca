namespace APINetMok.Dto
{
    public class PaginacionDto
    {
        public int Pagina { get; set; } = 1;
        private int recordsPorPagina = 5;

        private readonly int cantidadMaximaPorPagina = 10;

        public int RecordsPorPagina
        {
            get { return recordsPorPagina; }
            set
            {
                recordsPorPagina = (value > cantidadMaximaPorPagina) ? cantidadMaximaPorPagina : value;
                
            }
        }
    }
}
