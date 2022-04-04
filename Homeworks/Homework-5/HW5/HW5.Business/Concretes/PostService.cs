using HW5.Business.Abstracts;
using HW5.DataAccess.EntityFramework.Repository.Abstracts;
using HW5.Domain.Entities;

namespace HW5.Business.Concretes
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> repository;
        private readonly IUnitOfWork unitOfWork;

        public PostService(IRepository<Post> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        // Adding posts to the database.
        public void AddPosts(Post post)
        {
            repository.Add(post);
            unitOfWork.Commit();
        }
    }
}