﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFHE.Topic.Model;

namespace DFHE.Topic.Repository
{
    public class TopicContext:DbContext
    {
        public TopicContext()
            : base("name=DFHE_TopicEntities")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Page> Page { get; set; }
        public virtual DbSet<Respondent> Respondent { get; set; }
        public virtual DbSet<Template> Template { get; set; }
        public virtual DbSet<Topic.Model.Topic> Topic { get; set; }
        public virtual DbSet<User> User { get; set; }

    }
}