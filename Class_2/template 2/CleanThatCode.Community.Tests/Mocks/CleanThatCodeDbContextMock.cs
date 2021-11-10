using System; 
using System.Collections.Generic;
using CleanThatCode.Community.Models.Entities; 
using CleanThatCode.Community.Repositories.Data;
using CleanThatCode.Community.Tests.Mocks;


namespace CleanThatCode.Community.Tests
{
    public class CleanThatCodeDbContextMock : ICleanThatCodeDbContext
    {
        public IEnumerable<Comment> Comments => FakeData.Comments;

        public IEnumerable<Post> Posts => FakeData.Posts;
    }
}


