using Nrun.Domain;

namespace Nrun.Post.Dto
{
    public class PostMapProfile : AutoMapper.Profile
    {
        public PostMapProfile()
        {
            CreateMap<Domain.Post, PostDto>()
                .ForMember(x=>x.LikeCount,z=>z.MapFrom(y=>y.Likes.Count))
                .ForMember(x=>x.Comments ,z=>z.MapFrom(y=>y.Comments))
                .ForMember(x=>x.User ,z=>z.MapFrom(y=>y.CreatorUser));
            
            CreateMap<Comment, CommentDto>()
                .ForMember(x=>x.CreatorUser ,z=>z.MapFrom(y=>y.CreatorUser));
        }
    }
}