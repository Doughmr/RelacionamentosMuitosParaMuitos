namespace muitospramuitos.Models
{
    public class Pais
    {   
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }
        public DateTime Nascimento { get; set; }
        public int IdFilho { get; set; }
    }
}
