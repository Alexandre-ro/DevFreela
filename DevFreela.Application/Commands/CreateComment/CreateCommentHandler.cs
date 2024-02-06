using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly DevFreelaDbContext _context;
        
        public CreateCommentHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content,
                                            request.IdUser,
                                            request.IdProject);

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
