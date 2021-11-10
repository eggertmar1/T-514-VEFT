using CleanThatCode.Community.Repositories.Implementations;
using CleanThatCode.Community.Repositories.Interfaces;
using CleanThatCode.Community.Models.Entities;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using CleanThatCode.Community.Models.Dtos;
using CleanThatCode.Community.Repositories.Data;


namespace CleanThatCode.Community.Tests
{
    [TestClass]
    public class PostRepositoryTests 
    {
        private IPostRepository _PostRepository; 
        private readonly Mock<ICleanThatCodeDbContext> postRepositoryMock=new Mock<ICleanThatCodeDbContext>();
        // configuring values for the repository mock 

        private IEnumerable<Post> posts = Builder<Post>.CreateListOfSize(3)
                .TheFirst(2).With(x => x.Title = "Grayskull").With(x=> x.Author = "He-Man")
                .TheNext(1).With(x => x.Title = "Hack the planet!").With( x => x.Author = "Richard Stallman")
                .Build();

        [TestInitialize]
        public void Initialize()
        {
            postRepositoryMock.Setup(method => method.Posts).Returns(posts);
            //postRepositoryMock.Setup(d => d.GetAllPosts().Returns(posts));
            _PostRepository = new PostRepository(postRepositoryMock.Object);
        }
        [TestMethod]
        public void GetAllPosts_NoFilter_ShouldContainAListOfThree()
        {
            var posts = _PostRepository.GetAllPosts("","");
            Assert.AreEqual(3, posts.Count());
        }
        public void GetAllPosts_FilteredByTitle_ShouldContainAListOfTwo() 
        {
            var posts = _PostRepository.GetAllPosts("Grayskull","");
            Assert.AreEqual(2,posts.Count());
        }
        public void GetAllPosts_FilteredByAuthor_ShouldContainAListOfOne()
        {
            var posts = _PostRepository.GetAllPosts("","Stallman");
            Assert.AreEqual(1,posts.Count());
        }
    }
}