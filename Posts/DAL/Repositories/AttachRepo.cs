using AutoMapper;
using BLL.Models.Attach;
using DAL.Interfaces;
using Domain.Entity.Attach;
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
            var attach = await _context.Attaches.AsNoTracking().FirstOrDefaultAsync(x => x.FilePath == path);

            return _mapper.Map<GetAttachModel>(attach) ?? new GetAttachModel();
        }

        public async Task<Guid> InsertAttach(MetaDataModel meta, string path)
        {
            var attach = new Attach()
            {
                Id = Guid.NewGuid(),
                Name = meta.Name,
                MimeType = meta.MimeType,
                FilePath = path,
                Size = meta.Size,
                PostId = meta.PostId
            };

            await _context.Attaches.AddAsync(attach);

            await _context.SaveChangesAsync();

            return attach.Id;
        }
    }
}
