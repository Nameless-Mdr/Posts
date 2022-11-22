﻿namespace Domain.Entity
{
    public class Comment
    {
        public Guid Id { get; set; }

        public string Text { get; set; } = null!;

        public DateTimeOffset DateCreated { get; set; }

        public Guid AuthorId { get; set; }

        public Guid PostId { get; set; }


        public User.User Author { get; set; } = null!;

        public virtual Post Post { get; set; } = null!;
    }
}
