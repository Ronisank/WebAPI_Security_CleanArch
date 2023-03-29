﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Profile
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }

        public Profile()
        {
        }

        public Profile(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
