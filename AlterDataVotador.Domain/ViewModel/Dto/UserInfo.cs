namespace AlterDataVotador.Domain.ViewModel.Dto
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Cliente { get; set; }

        //Nome Banco de dados
        public string ClientId { get; set; }
    }
}