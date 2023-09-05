using IntegrationTestsWebApi.Context;
using IntegrationTestsWebApi.Models;
using MediatR;

namespace IntegrationTestsWebApi.Services
{
    public class TestsService
    {
        private AppDbContext _context;
        private readonly IMediator _mediator;

        public TestsService(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public bool AddData(string name)
        {
            var data = new DbModel { Name = name };

            try
            {
                _context.DbModels.Add(data);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public DbModel? GetData(int id)
        {
            return _context.DbModels.FirstOrDefault(x => x.Id == id);
        }

        public bool DeleteData(int id)
        {
            var data = _context.DbModels.FirstOrDefault(x => x.Id == id);

            if (data != null)
            {
                _context.DbModels.Remove(data);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
