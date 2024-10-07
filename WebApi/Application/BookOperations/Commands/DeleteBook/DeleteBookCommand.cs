using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.Commands.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly IBookStoreDbContext _dbContext;

        public int BookId { get; set; }

        public DeleteBookCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {

            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
                throw new InvalidOperationException("Silinecek kitap bulunamadi.");

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}