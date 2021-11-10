using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanThatCode.Community.Tests.Mocks;
using CleanThatCode.Community.Repositories.Interfaces;
using CleanThatCode.Community.Repositories.Implementations;
using CleanThatCode.Community.Models.Dtos;


namespace CleanThatCode.Community.Tests
{
    [TestClass]
    public class CommentRepositoryTests 
    {
        private ICommentRepository _commentRepository;
        [TestInitialize]
        public void Initialize() 
        {
            _commentRepository = new CommentRepository(new CleanThatCodeDbContextMock());
        }
        [TestMethod]

        public void GetAllCommentsByPostId_GivenValidPostId_shouldReturnNoComments()
        {
            var comments = _commentRepository.GetAllCommentsByPostId(1928);
            int counter = 0;
            foreach ( CommentDto comment in comments)
            {
                counter++;
            }
            Assert.AreEqual(0, counter);
        }
        public void GetAllCommentsByPostId_GivenValidPostId_shouldReturnTwoComments()
        {
            var comments = _commentRepository.GetAllCommentsByPostId(1);
            int counter = 0;
            foreach ( CommentDto comment in comments)
            {
                counter++;
            }
            Assert.AreEqual(2, counter);
        }
    }
}