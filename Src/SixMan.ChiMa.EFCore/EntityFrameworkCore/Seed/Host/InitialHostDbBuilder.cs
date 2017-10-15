namespace SixMan.ChiMa.EFCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly ChiMaDbContext _context;

        public InitialHostDbBuilder(ChiMaDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
