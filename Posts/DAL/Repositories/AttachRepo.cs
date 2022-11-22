using AutoMapper;
using BLL.Models.Attach;
using DAL.Interfaces;
using Domain.Entity.Attach;
using Domain.Entity.MetaData;
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

        public async Task<Guid> InsertContent(MetaDataModel meta, string path, Guid postId)
        {
            var attach = new Content()
            {
                Id = Guid.NewGuid(),
                Name = meta.Name,
                MimeType = meta.MimeType,
                FilePath = path,
                Size = meta.Size,
                PostId = postId
            };

            await _context.Contents.AddAsync(attach);

            await _context.SaveChangesAsync();

            return attach.Id;
        }

        public async Task<Guid> InsertAvatar(MetaDataModel meta, string path, Guid ownerId)
        {
            var avatar = new Avatar()
            {
                Id = Guid.NewGuid(),
                Name = meta.Name,
                MimeType = meta.MimeType,
                FilePath = path,
                Size = meta.Size,
                OwnerId = ownerId
            };

            await _context.Avatars.AddAsync(avatar);

            await _context.SaveChangesAsync();

            return avatar.Id;
        }

        public async Task<Guid> UpdateAvatar(MetaDataModel meta, string path, Guid ownerId)
        {
            var removingAvatar = await _context.Avatars.FirstOrDefaultAsync(x => x.OwnerId == ownerId);

            _context.Avatars.Remove(removingAvatar!);

            return await InsertAvatar(meta, path, ownerId);
        }

        public async Task<bool> UserExists(Guid userId)
        {
            return await _context.Avatars.AnyAsync(x => x.OwnerId == userId);
        }
    }
}
