using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.Models.Attach;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class AttachRepo : IAttachRepo
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;

        public AttachRepo(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetAttachModel> GetAttach(string path)
        {
            var attach = await _context.Attaches.AsNoTracking().Where(x => x.FilePath == path).
                ProjectTo<GetAttachModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return attach ?? new GetAttachModel();
        }
    }
}
